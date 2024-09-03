using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using NSUci;
using System.Globalization;
using System.Xml.Linq;
using System.Net.Sockets;
using System.Diagnostics.Eventing.Reader;
using NSChess;
using System.Drawing;
using System.Threading;
using RapLog;
using System.Diagnostics.Contracts;
using System.Windows.Forms.DataVisualization.Charting;

namespace RapChessGui
{
    class CTData
    {
        public bool done = false;
        public bool uciOk = false;
        public bool readyOk = false;
        public string bestMove = string.Empty;

        public void Assign(CTData td)
        {
            done = td.done;
            uciOk = td.uciOk;
            readyOk = td.readyOk;
            bestMove = td.bestMove;
        }
    }

    internal class CEloAcc
    {
        readonly object locker = new object();
        public CMSList msList = new CMSList();
        Process studentProcess;
        readonly CTData tData = new CTData();
        readonly CUci uci = new CUci();
        readonly static Random rnd = new Random();
        readonly CRapLog log = new CRapLog(@"Log\autodetect elo.log");

        public CTData GetTData()
        {
            CTData td = new CTData();
            lock (locker)
            {
                td.Assign(tData);
            }
            return td;
        }

        public void SetTData(CTData td)
        {
            lock (locker)
            {
                tData.Assign(td);
            }
        }

        void StudentTerminate()
        {
            try
            {
                if ((studentProcess != null) && (studentProcess.StartInfo.FileName != String.Empty))
                {
                    studentProcess.OutputDataReceived -= StudentDataReceived;
                    studentProcess.Kill();
                    studentProcess.StartInfo.FileName = String.Empty;
                }
            }
            catch { }
        }

        void StudentWriteLine(string msg)
        {
            if (studentProcess.StartInfo.FileName != String.Empty)
                studentProcess.StandardInput.WriteLine(msg);
        }

        void StudentDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    CTData td = GetTData();
                    uci.SetMsg(e.Data);
                    switch (uci.command)
                    {
                        case "uciok":
                            td.uciOk = true;
                            break;
                        case "readyok":
                            td.readyOk = true;
                            break;
                        case "bestmove":
                            uci.GetValue("bestmove", out td.bestMove);
                            td.done = true;
                            break;
                        case "move":
                            uci.GetValue("move", out td.bestMove);
                            td.done = true;
                            break;
                    }
                    SetTData(td);
                }
            }
            catch { }
        }

        public bool SetStudent(string studentFile, string studentArguments)
        {
            StudentTerminate();
            if (!File.Exists(studentFile))
                return false;
            studentProcess = new Process();
            studentProcess.StartInfo.FileName = studentFile;
            studentProcess.StartInfo.Arguments = studentArguments;
            studentProcess.StartInfo.WorkingDirectory = Path.GetDirectoryName(studentFile);
            studentProcess.StartInfo.CreateNoWindow = true;
            studentProcess.StartInfo.RedirectStandardInput = true;
            studentProcess.StartInfo.RedirectStandardOutput = true;
            studentProcess.StartInfo.RedirectStandardError = true;
            studentProcess.StartInfo.UseShellExecute = false;
            studentProcess.OutputDataReceived += StudentDataReceived;
            studentProcess.EnableRaisingEvents = true;
            studentProcess.Start();
            studentProcess.BeginOutputReadLine();
            return true;
        }

        async void EloAccuracy(DateTime dt)
        {
            int count = 0;
            int r = rnd.Next(FormChess.engineList.Count);
            for (int n = 0; n < FormChess.engineList.Count; n++)
            {
                CEngine e = FormChess.engineList[(n + r) % FormChess.engineList.Count];
                if ((e.eloAccDT.ToString() != dt.ToString()) && e.modeTime && e.modeFen && ((e.protocol == CProtocol.uci) || (e.protocol == CProtocol.winboard)))
                {
                    log.Add($"Start {e.name}");
                    await Task.Run(() => EloAccuracyTask(e, dt));
                    count++;
                }
            }
            if (count > 0)
            {
                Console.Beep();
                log.Add("Finisch");
            }
        }

        void EloAccuracyTask(CEngine e, DateTime dt)
        {
            CChess chess = new CChess();
            CTData td = new CTData();
            long centyLoss = 0;
            SetStudent(e.GetPath(), e.arguments);
            bool fail = false;
            if (e.protocol == CProtocol.uci)
                StudentWriteLine("uci");
            else
                StudentWriteLine("xboard");
            Thread.Sleep(100);
            foreach (CMSLine line in msList)
            {
                td.done = false;
                SetTData(td);
                if (e.protocol == CProtocol.uci)
                {
                    StudentWriteLine("ucinewgame");
                    Thread.Sleep(100);
                    StudentWriteLine($"position fen {line.fen}");
                    StudentWriteLine("go movetime 2000");
                }
                else
                {
                    chess.SetFen(line.fen);
                    StudentWriteLine("new");
                    Thread.Sleep(100);
                    StudentWriteLine("post");
                    StudentWriteLine("force");
                    StudentWriteLine($"board {line.fen}");
                    StudentWriteLine("st 200");
                    StudentWriteLine(chess.WhiteTurn ? "white" : "black");
                    StudentWriteLine("go");
                }
                if (fail)
                    break;
                Stopwatch sw = Stopwatch.StartNew();
                do
                {
                    if (sw.ElapsedMilliseconds > 3000)
                    {
                        fail = true;
                        break;
                    }
                    td = GetTData();
                    if (td.done)
                        centyLoss += line.CentyLoss(td.bestMove);
                } while (!td.done);
                if (fail)
                    break;
            }
            if (fail)
                log.Add($"{e.name} fail");
            else
            {
                double accuracy = GetAccuracy(msList.Count, centyLoss);
                e.eloAcc = GetElo(accuracy);
                e.eloAccDT = dt;
                e.SaveToIni();
                log.Add($"{e.name} test {msList.Count} accuracy {accuracy} elo {e.eloAcc}");
            }
            StudentTerminate();
        }

        public void Start()
        {
            string fn = @"books\accuracy.epd";
            if (!msList.LoadFromEpd(fn))
                return;
            DateTime dt = File.GetLastWriteTime(fn);
            EloAccuracy(dt);
        }

        public int GetElo(double accuracy)
        {
            accuracy /= 100.0;
            accuracy = (accuracy - 0.6) / 0.4;
            if (accuracy < 0)
                accuracy = 0;
            return Convert.ToInt32(accuracy * 3500);
        }

        public double GetAccuracy(long cc, long cl)
        {
            if (cc == 0)
                return 0;
            double max = cc * CMSLine.blunder;
            return ((max - cl) * 100.0) / max;
        }

    }
}
