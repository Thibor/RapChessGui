using NSChess;
using NSUci;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RapChessGui
{
    public partial class FormAutodetect : Form
    {
        const int countTests = 20;
        static int countAuto = 0;
        static int countDone = 0;
        static int tick = 0;
        static int testMode = 0;
        public static string pathAutoEng = @"Log\protocol.log";
        public static string pathAutoElo = @"Log\accuracy.log";
        static CEngine testEngine = null;
        readonly static Stopwatch testWatch = new Stopwatch();
        static CProcess testProcess = null;
        static FormAutodetect This;
        readonly static List<string> report = new List<string>();
        public Stopwatch timer = new Stopwatch();
        readonly static CUci uci = new CUci();
        double lastTime = 0;
        double lastLeft = 0;
        int lastValue = 0;
        static CChess chess = new CChess();

        public FormAutodetect()
        {
            InitializeComponent();
            This = this;
            testProcess = new CProcess(OnDataReceivedTest);
            FormOptions.SetFontSize(this);
        }

        #region process

        delegate void DeleMessageTest(string message);


        readonly static DeleMessageTest deleMessageTest = new DeleMessageTest(NewMessageTest);

        private void OnDataReceivedTest(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    Invoke(deleMessageTest, new object[] { e.Data.Trim() });
                }
            }
            catch { }
        }

        public static void NewMessageTest(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                return;
            uci.SetMsg(msg);
            string bst = testEngine.protocol == CProtocol.uci ? uci.GetStr("bestmove") : uci.GetStr("move");
            bool bstOk = chess.IsValidMove(bst, out _, out _, out _);
            WriteLineFromEngine(msg);
            switch (testMode)
            {
                case 1:
                    if (msg.IndexOf("option name UCI_Elo type spin") == 0)
                    {
                        testEngine.modeElo = true;
                        testEngine.eloMax = uci.GetInt("max");
                    }
                    if (msg == "uciok")
                        testEngine.protocol = CProtocol.uci;
                    break;
                case 2:
                case 3:
                    if (bstOk)
                        testEngine.modeTime ^= true;
                    break;
                case 5:
                case 6:
                    if (bstOk)
                        testEngine.modeDepth ^= true;
                    break;
                case 8:
                case 9:
                    if (bstOk)
                        testEngine.modeStandard ^= true; ;
                    break;
                case 11:
                case 12:
                    if (bstOk)
                        testEngine.modeTournament ^= true;
                    break;
                case 14:
                case 15:
                    if (bstOk)
                        testEngine.modeNodes ^= true;
                    break;
                case 16:
                case 17:
                    if (bstOk)
                        testEngine.modeInfinite ^= true;
                    break;
                case 18:
                    if (bstOk)
                        testEngine.modeFen ^= true;
                    break;
                case 19:
                    if (bst=="g2h1")
                        testEngine.modeSearchmoves ^= true;
                    break;

            }
        }

        public static void TestStop()
        {
            if (testEngine.protocol == CProtocol.uci)
                testProcess?.WriteLine("stop");
            else
                testProcess?.WriteLine("?");
        }

        public static void TestRestart()
        {
            tick = 40;
            testProcess?.Restart();
        }

        public static void TestUci(string command)
        {
            EngineWriteLine("uci", 100);
            EngineWriteLine("ucinewgame", 100);
            EngineWriteLine("position startpos moves b1a3 b8a6");
            EngineWriteLine(command);
        }

        void TestXb(string command)
        {
            EngineWriteLine("xboard", 100);
            EngineWriteLine("new", 100);
            EngineWriteLine("post");
            EngineWriteLine("force");
            EngineWriteLine("b1a3");
            EngineWriteLine("b8a6");
            EngineWriteLine("white");
            EngineWriteLine(command);
            EngineWriteLine("go");
        }

        void ShowProtocol()
        {
            if (testEngine.protocol == CProtocol.uci)
                ConsoleWriteLine("protocol uci");
            else
                ConsoleWriteLine("protocol xb");
        }

        void ShowTime()
        {
            if (testEngine.modeTime)
                ConsoleWriteLine("mode time ok");
            else
                ConsoleWriteLine("mode time fail");
        }

        void ShowDepth()
        {
            if (testEngine.modeDepth)
                ConsoleWriteLine("mode depth ok");
            else
                ConsoleWriteLine("mode depth fail");
        }

        void ShowStandard()
        {
            if (testEngine.modeStandard)
                ConsoleWriteLine("mode standart ok");
            else
                ConsoleWriteLine("mode standart fail");
        }

        void ShowTournament()
        {
            if (testEngine.modeTournament)
                ConsoleWriteLine("mode tournament ok");
            else
                ConsoleWriteLine("mode tournament fail");
        }

        void ShowNodes()
        {
            if (testEngine.modeNodes)
                ConsoleWriteLine("mode nodes ok");
            else
                ConsoleWriteLine("mode nodes fail");
        }

        void ShowInfinite()
        {
            if (testEngine.modeInfinite)
                ConsoleWriteLine("mode infinite ok");
            else
                ConsoleWriteLine("mode infinite fail");
        }

        void ShowSearchmoves()
        {
            if (testEngine.modeSearchmoves)
                ConsoleWriteLine("mode searchmoves ok");
            else
                ConsoleWriteLine("mode searchmoves fail");
        }

        void ShowElo()
        {
            if (testEngine.modeElo)
                ConsoleWriteLine("mode elo ok");
            else
                ConsoleWriteLine("mode elo fail");
        }

        string OkFail(bool v)
        {
            return v ? "ok" : "fail";
        }

        void TestFen()
        {
            ConsoleWriteLine("start test fen");
            string fen = "4Rnk1/6pp/rpp2p2/3p4/3P4/2Pq1NP1/r4PKP/Q3R3 w - - 0 27";
            testEngine.modeFen = false;
            chess.SetFen(fen);
            TestRestart();
            if (testEngine.protocol == CProtocol.uci)
            {
                EngineWriteLine("uci", 100);
                EngineWriteLine("ucinewgame", 100);
                EngineWriteLine($"position fen {fen}");
                EngineWriteLine($"go movetime 1000");
            }
            else
            {
                EngineWriteLine("xboard", 100);
                EngineWriteLine("new", 100);
                EngineWriteLine("post");
                EngineWriteLine("force");
                EngineWriteLine($"board {fen}");
                EngineWriteLine("st 100");
                EngineWriteLine(chess.WhiteTurn ? "white" : "black");
                EngineWriteLine("go");
            }
        }

        void TestSearchmoves()
        {
            ConsoleWriteLine("start test searchmoves");
            string fen = "4Rnk1/6pp/rpp2p2/3p4/3P4/2Pq1NP1/r4PKP/Q3R3 w - - 0 27";
            chess.SetFen(fen);
            TestRestart();
            EngineWriteLine("uci", 100);
            EngineWriteLine("ucinewgame", 100);
            EngineWriteLine($"position fen {fen}");
            EngineWriteLine($"go movetime 1000 searchmoves g2h1");
        }

        void TestSummary()
        {
            testProcess?.WriteLine("quit");
            ConsoleWriteLine($"engine {testEngine.name}");
            ShowProtocol();
            ShowTime();
            ShowDepth();
            ShowStandard();
            ShowTournament();
            ShowNodes();
            ShowInfinite();
            ShowSearchmoves();
            ShowElo();
            ConsoleWriteLine($"mode fen {OkFail(testEngine.modeFen)}");
            ConsoleWriteLine();
            if (!testEngine.IsPlayableMode())
                testEngine.protocol = CProtocol.unknow;
            testEngine.SaveToIni();
            tick = 0;
            testMode = -1;
            countDone++;
        }

        void NextPhase()
        {
            tick = 20;
            testMode++;
            ConsoleWriteLine("Next phase");
            testWatch.Restart();
            progressBar.Value = countDone * countTests + testMode;
            switch (testMode)
            {
                case 0:
                    testEngine = FormChess.engineList.GetEngineAuto();
                    if (testEngine == null)
                    {
                        ConsoleWriteLine("finish");
                        File.WriteAllLines(pathAutoEng, report);
                        testTimer.Stop();
                        testProcess.Terminate();
                        Close();
                    }
                    else if (!testEngine.FileExists())
                    {
                        ConsoleWriteLine($"engine {testEngine.name} file not exist");
                        testEngine.protocol = CProtocol.unknow;
                        testEngine.SaveToIni();
                        CListEngine.iniFile.Save();
                        tick = 0;
                        testMode = -1;
                    }
                    else
                    {
                        testEngine.SetUniqueName();
                        lName.Text = testEngine.name;
                        ConsoleWriteLine($"engine {testEngine.name} ready");
                        FormEditEngine.engineName = testEngine.name;
                        tick = 0;
                        testEngine.protocol = CProtocol.xb;
                        testEngine.modeElo = false;
                        testProcess.SetProgram(testEngine.GetPath(), testEngine.arguments);
                        testTimer.Start();
                    }
                    break;
                case 1:
                    chess.SetFen();
                    chess.MakeMoves("b1a3 b8a6");
                    tick = 40;
                    ConsoleWriteLine("start test protocol");
                    testProcess.WriteLine("uci", 1000);
                    break;
                case 2:
                    ShowProtocol();
                    if (testEngine.protocol == CProtocol.xb)
                        testProcess.WriteLine("xboard", 1000);
                    testEngine.modeTime = false;
                    ConsoleWriteLine("start test time 1");
                    if (testEngine.protocol == CProtocol.uci)
                        TestUci("go movetime 1000");
                    else
                        TestXb("st 1");
                    break;
                case 3:
                    if (testEngine.modeTime)
                    {
                        ConsoleWriteLine("start test time 2");
                        if (testEngine.protocol == CProtocol.uci)
                            TestUci("go movetime 10000");
                        else
                            TestXb("st 10");
                    }
                    else
                        NextPhase();
                    break;
                case 4:
                    TestRestart();
                    break;
                case 5:
                    ShowTime();
                    testEngine.modeDepth = false;
                    ConsoleWriteLine("start test depth 1");
                    if (testEngine.protocol == CProtocol.uci)
                        TestUci("go depth 3");
                    else
                        TestXb("sd 3");
                    break;
                case 6:
                    if (testEngine.modeDepth)
                    {
                        ConsoleWriteLine("start test depth 2");
                        if (testEngine.protocol == CProtocol.uci)
                            TestUci("go depth 60");
                        else
                            TestXb("sd 60");
                    }
                    else
                        NextPhase();
                    break;
                case 7:
                    TestRestart();
                    break;
                case 8:
                    ShowDepth();
                    testEngine.modeStandard = false;
                    ConsoleWriteLine("start test standard 1");
                    if (testEngine.protocol == CProtocol.uci)
                        TestUci("go wtime 500 btime 500 winc 0 binc 0");
                    else
                        TestXb("time 50");
                    break;
                case 9:
                    if (testEngine.modeStandard)
                    {
                        ConsoleWriteLine("start test standard 2");
                        if (testEngine.protocol == CProtocol.uci)
                            TestUci("go wtime 1000000 btime 1000000 winc 0 binc 0");
                        else
                            TestXb("time 100000");
                    }
                    else
                        NextPhase();
                    break;
                case 10:
                    TestRestart();
                    break;
                case 11:
                    ShowStandard();
                    testEngine.modeTournament = false;
                    ConsoleWriteLine("start test tournament 1");
                    if (testEngine.protocol == CProtocol.uci)
                        TestUci("go wtime 20000 btime 20000 winc 0 binc 0 movestogo 80");
                    else
                        TestXb("level 80 0:20 0");
                    break;
                case 12:
                    if (testEngine.modeTournament)
                    {
                        ConsoleWriteLine("start test tournament 2");
                        if (testEngine.protocol == CProtocol.uci)
                            TestUci("go wtime 20000 btime 20000 winc 0 binc 0 movestogo 1");
                        else
                            TestXb("level 1 0:20 0");
                    }
                    else
                        NextPhase();
                    break;
                case 13:
                    TestRestart();
                    break;
                case 14:
                    ShowTournament();
                    testEngine.modeNodes = false;
                    ConsoleWriteLine("start test nodes 1");
                    if (testEngine.protocol == CProtocol.uci)
                        TestUci("go nodes 1000");
                    else
                        NextPhase();
                    break;
                case 15:
                    if (testEngine.modeNodes)
                    {
                        ConsoleWriteLine("start test nodes 2");
                        TestUci("go nodes 100000000");
                    }
                    else
                        NextPhase();
                    break;
                case 16:
                    ConsoleWriteLine("start test infinite 1");
                    TestRestart();
                    if (testEngine.protocol == CProtocol.uci)
                    {
                        testEngine.modeInfinite = true;
                        TestUci("go infinite");
                    }
                    else
                    {
                        testEngine.modeInfinite = false;
                        NextPhase();
                    }
                    break;
                case 17:
                    if (testEngine.modeInfinite)
                    {
                        testEngine.modeInfinite = false;
                        ConsoleWriteLine("start test infinite 2");
                        TestStop();
                    }
                    else
                        NextPhase();
                    break;
                case 18:
                    TestFen();
                    break;
                case 19:
                    testEngine.modeSearchmoves = false;
                    if (testEngine.protocol == CProtocol.uci)
                        TestSearchmoves();
                    else
                        NextPhase();
                    break;
                case 20:
                    TestSummary();
                    break;
            }
        }

        private void testTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = timer.Elapsed;
            double sec = ts.TotalSeconds;
            int min = Convert.ToInt32(ts.TotalMinutes);
            sslTime.Text = $"Time {min}:{ts.Seconds:D2}";
            if (lastValue != progressBar.Value)
            {
                lastValue = progressBar.Value;
                lastTime = sec;
                double speed = sec > 0 ? progressBar.Value / sec : 0;
                sec = speed > 0 ? (progressBar.Maximum - progressBar.Value) / speed : 0;
                ts = TimeSpan.FromSeconds(sec);
                lastLeft = sec;
            }
            else
            {
                sec = lastLeft - (sec - lastTime);
                if (sec < 0)
                    sec = 0;
                ts = TimeSpan.FromSeconds(sec);
            }
            min = Convert.ToInt32(ts.TotalMinutes);
            sslLeft.Text = $"Left {min}:{ts.Seconds:D2}";
            if (--tick <= 0)
                NextPhase();
        }

        void StartTestAuto()
        {
            countDone = 0;
            countAuto = FormChess.engineList.CountAuto();
            progressBar.Maximum = countAuto * countTests;
            progressBar.Value = 0;
            tbConsole.Clear();
            report.Clear();
            tick = 0;
            testMode = -1;
            timer.Restart();
            testTimer.Start();
        }

        #endregion

        static void ConsoleWriteLine(string line = "")
        {
            TimeSpan ts = testWatch.Elapsed;
            string s = $"{ts.Seconds:D2}";
            string m = $"{ts.Milliseconds:D3}";
            string t = $"{s}.{m}";
            This.tbConsole.AppendText($"{t} {line}{Environment.NewLine}");
            report.Add($"{t} {line}");
        }

        static void EngineWriteLine(string line, int sleep = 0)
        {
            ConsoleWriteLine($"> {line}");
            testProcess.WriteLine(line, sleep);
        }

        static void WriteLineFromEngine(string line)
        {
            ConsoleWriteLine($"< {line}");
        }

        private void FormAutodetect_FormClosing(object sender, FormClosingEventArgs e)
        {
            testTimer.Stop();
            testProcess?.Terminate();
        }

        private void FormAutodetect_Shown(object sender, EventArgs e)
        {
            StartTestAuto();
        }
    }
}
