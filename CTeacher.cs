using NSUci;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace RapChessGui
{

    class CDataT
    {
        public bool started = false;
        public bool done = false;
        public int cp = 0;
        public int mate = 0;
        public string move = string.Empty;
        public string pv= string.Empty;

        public void Assign(CDataT dt)
        {
            started = dt.started;
            done = dt.done;
            cp = dt.cp;
            mate = dt.mate;
            move = dt.move;
            pv = dt.pv;
        }
    }

    internal class CTeacher
    {
        public bool firstPhase = true;
        public int index = 0;
        public int depth = 15;
        public int cp = 0;
        public int mate = 0;
        public string fen = string.Empty;
        public string move=string.Empty;
        readonly object locker = new object();
        Process processTeacher = new Process();
        readonly CDataT dataT = new CDataT();
        readonly CUci uci = new CUci();

        public CDataT GetTData()
        {
            CDataT dt = new CDataT();
            lock (locker)
            {
                dt.Assign(dataT);
            }
            return dt;
        }

        public void SetTData(CDataT dt)
        {
            lock (locker)
            {
                dataT.Assign(dt);
            }
        }

        public bool IsStarted()
        {
            CDataT dt = GetTData();
            return dt.started;
        }

        void TeacherDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    CDataT dt = GetTData();
                    uci.SetMsg(e.Data);
                    switch (uci.command)
                    {
                        case "bestmove":
                            uci.GetValue("bestmove", out dt.move);
                            dt.done = true;
                            break;
                        case "info":
                            if (uci.GetValue("cp", out string cp))
                                int.TryParse(cp,out dt.cp);
                            if (uci.GetValue("mate", out string mate))
                                int.TryParse(mate, out dt.mate);
                            int index = uci.GetIndex("pv");
                            if (index > 0)
                                dt.pv = uci.GetValue(index+1,index+2);
                            break;
                    }
                    SetTData(dt);
                }
            }
            catch { }
        }

        public bool SetTeacher(string fileName, string arguments)
        {
            TeacherTerminate();
            if (!File.Exists(fileName))
                return false;
            processTeacher = new Process();
            processTeacher.StartInfo.FileName = fileName;
            processTeacher.StartInfo.Arguments = arguments;
            processTeacher.StartInfo.WorkingDirectory = Path.GetDirectoryName(fileName);
            processTeacher.StartInfo.CreateNoWindow = true;
            processTeacher.StartInfo.RedirectStandardInput = true;
            processTeacher.StartInfo.RedirectStandardOutput = true;
            processTeacher.StartInfo.RedirectStandardError = true;
            processTeacher.StartInfo.UseShellExecute = false;
            processTeacher.OutputDataReceived += TeacherDataReceived;
            processTeacher.EnableRaisingEvents = true;
            processTeacher.Start();
            processTeacher.BeginOutputReadLine();
            TeacherWriteLine("uci");
            return true;
        }

        public void TeacherTerminate()
        {
            CDataT dt = new CDataT();
            SetTData(dt);
            try
            {
                if ((processTeacher != null) && (processTeacher.StartInfo.FileName != String.Empty))
                {
                    processTeacher.OutputDataReceived -= TeacherDataReceived;
                    processTeacher.Kill();
                    processTeacher.StartInfo.FileName = String.Empty;
                }
            }
            catch { }
        }

        void TeacherWriteLine(string msg)
        {
            if (processTeacher?.StartInfo.FileName != String.Empty)
                processTeacher.StandardInput.WriteLine(msg);
        }

        public void Start(string fen,int depth)
        {
            firstPhase = true;
            this.fen = fen;
            this.depth = depth;
            CDataT dt = new CDataT();
            dt.started = true;
            SetTData(dt);
            TeacherWriteLine("ucinewgame");
            Thread.Sleep(100);
            TeacherWriteLine($"position fen {fen}");
            TeacherWriteLine($"go depth {depth}");
        }

        public void Start(string moves)
        {
            firstPhase = false;
            CDataT dt = new CDataT();
            dt.started = true;
            SetTData(dt);
            TeacherWriteLine("ucinewgame");
            Thread.Sleep(100);
            TeacherWriteLine($"position fen {fen}");
            TeacherWriteLine($"go depth {depth} searchmoves {moves}");
        }

    }
}
