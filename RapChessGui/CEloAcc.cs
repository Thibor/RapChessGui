﻿using System;
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
                DateTime edt = File.GetLastWriteTime(e.GetFileName());
                bool old = (e.eloAccDT < dt) || (e.eloAccDT < edt) || (e.eloAccDT < e.DT);
                if (old && e.modeTime && e.modeFen && ((e.protocol == CProtocol.uci) || (e.protocol == CProtocol.winboard)))
                {
                    log.Add($"Start {e.name}");
                    await Task.Run(() => EloAccuracyTask(e));
                    count++;
                }
            }
            if (count > 0)
            {
                Console.Beep();
                log.Add("Finish");
            }
        }

        public static double WiningChances(int centipawns)
        {
            return 50 + 50 * (2 / (1 + Math.Exp(-0.00368208 * centipawns)) - 1);
        }

        public static double GetAccuracy(double winPercentBefore, double winPercentAfter)
        {
            return 103.1668 * Math.Exp(-0.04354 * (winPercentBefore - winPercentAfter)) - 3.1669;
        }

        public static double GetAccuracy(int scoreBefore, int scoreAfter)
        {
            double winPercentBefore = WiningChances(scoreBefore);
            double winPercentAfter = WiningChances(scoreAfter);
            return GetAccuracy(winPercentBefore, winPercentAfter);
        }

        void EloAccuracyTask(CEngine e)
        {
            CChess chess = new CChess();
            CTData td = new CTData();
            int totalCount = 0;
            double totalLoss = 0;
            double totalAccuracy = 0;
            double totalWeight = 0;
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
                    StudentWriteLine("go movetime 1000");
                }
                else
                {
                    chess.SetFen(line.fen);
                    StudentWriteLine("new");
                    Thread.Sleep(100);
                    StudentWriteLine("post");
                    StudentWriteLine("force");
                    StudentWriteLine($"board {line.fen}");
                    StudentWriteLine("st 100");
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
                    {
                        int scoreBst = line.First().score;
                        int scoreCur = line.GetScore(td.bestMove);
                        double bstWC = WiningChances(scoreBst);
                        double curWC = WiningChances(scoreCur);
                        double accuracy = GetAccuracy(bstWC, curWC);
                        double loss = bstWC - curWC +1;
                        totalCount++;
                        totalAccuracy += accuracy;
                        totalLoss += loss;
                        totalWeight += accuracy * loss;
                    }
                } while (!td.done);
                if (fail)
                    break;
            }
            if (fail)
                log.Add($"{e.name} fail");
            else
            {
                e.accuracy = totalAccuracy/totalCount;
                e.weight = totalWeight/totalLoss;
                e.eloAccDT = DateTime.Now;
                e.SaveToIni();
                log.Add($"{e.name} accuracy {e.accuracy:N2} weight {e.weight:N2}");
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

    }
}
