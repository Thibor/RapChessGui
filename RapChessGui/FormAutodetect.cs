using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using NSUci;

namespace RapChessGui
{
	public partial class FormAutodetect : Form
	{
		static int countAuto = 0;
		static int countDone = 0;
		static int tick = 0;
		static bool testResult = false;
		static int testMode = 0;
		public static string path = @"History\autodetect.log";
		static CEngine testEngine = null;
		readonly static Stopwatch testWatch = new Stopwatch();
		static CProcess testProcess = null;
		static FormAutodetect This;
		readonly static List<string> report = new List<string>();
		readonly static CUci uci = new CUci();

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
			bool con = !string.IsNullOrEmpty(bst);
			bool bstOk = (bst.Length == 4) && ((bst[0] != bst[2]) || (bst[1] != bst[3]));
			if (testResult && con && !bstOk && (testMode > 1))
				testResult = false;
			WriteLine(msg);
			switch (testMode)
			{
				case 1:
					if(msg.IndexOf("option name UCI_Elo type spin") == 0)
					{
						testEngine.modeElo = true;
						testEngine.elo = uci.GetInt("max");
					}
					if (msg == "uciok")
						testEngine.protocol = CProtocol.uci;
					break;
				case 2:
				case 3:
					if (con)
						testEngine.modeTime = testResult;
					break;
				case 5:
				case 6:
					if (con)
						testEngine.modeDepth = testResult;
					break;
				case 8:
				case 9:
					if (con)
						testEngine.modeStandard = testResult;
					break;
				case 11:
				case 12:
					if (con)
						testEngine.modeTournament = testResult;
					break;
				case 14:
				case 15:
					if (con)
						testEngine.modeNodes = testResult;
					break;
				case 17:
				case 18:
					if (con)
						testEngine.modeInfinite = testResult;
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

		public static void TestQuit()
		{
			testProcess?.WriteLine("quit");
		}

		public static void TestRestart()
		{
			tick = 40;
			testProcess?.Restart();
		}

		public static void TestUci(string command)
		{
			testProcess.WriteLine("uci", true);
			testProcess.WriteLine("ucinewgame", true);
			testProcess.WriteLine("isready", true);
			testProcess.WriteLine("position startpos moves b1a3 b8a6", true);
			testProcess.WriteLine(command, true);
		}

		void TestXb(string command)
		{
			testProcess.WriteLine("new", true);
			testProcess.WriteLine("post", true);
			testProcess.WriteLine("force", true);
			testProcess.WriteLine("b1a3", true);
			testProcess.WriteLine("b8a6", true);
			testProcess.WriteLine("white", true);
			testProcess.WriteLine(command, true);
			testProcess.WriteLine("go", true);
		}

		void ShowProtocol()
		{
			if (testEngine.protocol == CProtocol.uci)
				WriteLine("protocol uci");
			else
				WriteLine("protocol xb");
		}

		void ShowTime()
		{
			if (testEngine.modeTime)
				WriteLine("mode time ok");
			else
				WriteLine("mode time fail");
		}

		void ShowDepth()
		{
			if (testEngine.modeDepth)
				WriteLine("mode depth ok");
			else
				WriteLine("mode depth fail");
		}

		void ShowStandard()
		{
			if (testEngine.modeStandard)
				WriteLine("mode standart ok");
			else
				WriteLine("mode standart fail");
		}

		void ShowTournament()
		{
			if (testEngine.modeTournament)
				WriteLine("mode tournament ok");
			else
				WriteLine("mode tournament fail");
		}

		void ShowNodes()
		{
			if (testEngine.modeNodes)
				WriteLine("mode nodes ok");
			else
				WriteLine("mode nodes fail");
		}

		void ShowInfinite()
		{
			if (testEngine.modeInfinite)
				WriteLine("mode infinite ok");
			else
				WriteLine("mode infinite fail");
		}

		void ShowElo()
		{
			if (testEngine.modeElo)
				WriteLine("mode elo ok");
			else
				WriteLine("mode elo fail");
		}

		void NextPhase()
		{
			tick = 20;
			testWatch.Restart();
			testMode++;
			progressBar.Value = countDone * 19 + testMode;
			switch (testMode)
			{
				case 0:
					testEngine = FormChess.engineList.GetEngineAuto();
					if (testEngine == null)
					{
						WriteLine("finish");
						File.WriteAllLines(path, report);
						testTimer.Stop();
						testProcess.Terminate();
						Close();
					}
					else if (!testEngine.FileExists())
					{
						WriteLine($"engine {testEngine.name} file not exist");
						testEngine.protocol = CProtocol.unknow;
						testEngine.SaveToIni();
						CEngineList.iniFile.Save();
						tick = 0;
						testMode = -1;
					}
					else
					{
						testEngine.SetUniqueName();
						lName.Text = testEngine.name;
						WriteLine($"engine {testEngine.name} ready");
						FormEditEngine.engineName = testEngine.name;
						tick = 0;
						testEngine.protocol = CProtocol.winboard;
						testEngine.modeElo = false;
						testProcess.SetProgram(testEngine.GetPath(), testEngine.arguments);
						testTimer.Start();
					}
					break;
				case 1:
					tick = 40;
					WriteLine("start test protocol");
					testProcess.WriteLine("uci", true);
					break;
				case 2:
					ShowProtocol();
					if (testEngine.protocol == CProtocol.winboard)
						testProcess.WriteLine("xboard", true);
					testEngine.modeTime = false;
					testResult = true;
					WriteLine("start test time 1");
					if (testEngine.protocol == CProtocol.uci)
						TestUci("go movetime 1000");
					else
						TestXb("st 1");
					break;
				case 3:
					if (testEngine.modeTime)
					{
						testResult = false;
						WriteLine("start test time 2");
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
					testResult = true;
					WriteLine("start test depth 1");
					if (testEngine.protocol == CProtocol.uci)
						TestUci("go depth 3");
					else
						TestXb("sd 3");
					break;
				case 6:
					if (testEngine.modeDepth)
					{
						testResult = false;
						WriteLine("start test depth 2");
						if (testEngine.protocol == CProtocol.uci)
							TestUci("go depth 60");
						else
							TestXb("sd 100");
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
					testResult = true;
					WriteLine("start test standard 1");
					if (testEngine.protocol == CProtocol.uci)
						TestUci("go wtime 500 btime 500 winc 0 binc 0");
					else
						TestXb("time 50");
					break;
				case 9:
					if (testEngine.modeStandard)
					{
						testResult = false;
						WriteLine("start test standard 2");
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
					testResult = true;
					WriteLine("start test tournament 1");
					if (testEngine.protocol == CProtocol.uci)
						TestUci("go wtime 20000 btime 20000 winc 0 binc 0 movestogo 80");
					else
						TestXb("level 80 0:20 0");
					break;
				case 12:
					if (testEngine.modeTournament)
					{
						testResult = false;
						WriteLine("start test tournament 2");
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
					testResult = true;
					WriteLine("start test nodes 1");
					if (testEngine.protocol == CProtocol.uci)
						TestUci("go nodes 1000");
					else
						NextPhase();
					break;
				case 15:
					if (testEngine.modeNodes)
					{
						testResult = false;
						WriteLine("start test nodes 2");
						TestUci("go nodes 100000000");
					}
					else
						NextPhase();
					break;
				case 16:
					TestRestart();
					break;
				case 17:
					ShowNodes();
					testResult = false;
					WriteLine("start test infinite 1");
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
				case 18:
					if (testEngine.modeInfinite)
					{
						testResult = true;
						WriteLine("start test infinite 2");
						TestStop();
					}
					else
						NextPhase();
					break;
				case 19:
					TestQuit();
					WriteLine($"engine {testEngine.name}");
					ShowProtocol();
					ShowTime();
					ShowDepth();
					ShowStandard();
					ShowTournament();
					ShowNodes();
					ShowInfinite();
					ShowElo();
					WriteLine();
					if (!testEngine.IsPlayableMode())
						testEngine.protocol = CProtocol.unknow;
					testEngine.SaveToIni();
					tick = 0;
					testMode = -1;
					countDone++;
					break;
			}
		}

		private void testTimer_Tick(object sender, EventArgs e)
		{
			if (--tick <= 0)
				NextPhase();
		}

		void StartTestAuto()
		{
			countDone = 0;
			countAuto = FormChess.engineList.CountAuto();
			progressBar.Maximum = countAuto * 19;
			progressBar.Value = 0;
			tbConsole.Clear();
			report.Clear();
			tick = 0;
			testMode = -1;
			testTimer.Start();
		}

		#endregion

		static void WriteLine(string line = "")
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(testWatch.Elapsed.TotalMilliseconds);
			string t = dt.ToString("ss.fff");
			This.tbConsole.AppendText($"{t} {line}\n");
			report.Add($"{t} {line}");
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
