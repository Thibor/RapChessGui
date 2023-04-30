using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NSUci;

namespace RapChessGui
{
	public partial class FormAutodetect : Form
	{
		static int countAuto = 0;
		static int countDone = 0;
		static int tick = 0;
		static int testMode = 0;
		public static string path = @"History\autodetect.log";
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
			bool bstOk = (bst.Length ==2)||(bst.Length==3)||((bst.Length == 4) && ((bst[0] != bst[2]) || (bst[1] != bst[3])));
			WriteLineFromEngine(msg);
			switch (testMode)
			{
				case 1:
					if(msg.IndexOf("option name UCI_Elo type spin") == 0)
					{
						testEngine.modeElo = true;
						testEngine.elo = uci.GetInt("max");
						testEngine.hisElo.Clear();
						testEngine.hisElo.Add(testEngine.elo);
						testEngine.hisElo.Add(testEngine.elo);
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
				case 17:
				case 18:
					if (bstOk)
						testEngine.modeInfinite ^= true;
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
			WriteLineToEngine("uci");
			WriteLineToEngine("ucinewgame");
			WriteLineToEngine("isready");
			WriteLineToEngine("position startpos moves b1a3 b8a6");
			WriteLineToEngine(command);
		}

		void TestXb(string command)
		{
			WriteLineToEngine("xboard");
			WriteLineToEngine("new");
			WriteLineToEngine("post");
			WriteLineToEngine("force");
			WriteLineToEngine("b1a3");
			WriteLineToEngine("b8a6");
			WriteLineToEngine("white");
			WriteLineToEngine(command);
			WriteLineToEngine("go");
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
			testMode++;
			WriteLine("Next phase");
			testWatch.Restart();
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
						CListEngine.iniFile.Save();
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
					WriteLine("start test time 1");
					if (testEngine.protocol == CProtocol.uci)
						TestUci("go movetime 1000");
					else
						TestXb("st 1");
					break;
				case 3:
					if (testEngine.modeTime)
					{
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
					WriteLine("start test depth 1");
					if (testEngine.protocol == CProtocol.uci)
						TestUci("go depth 3");
					else
						TestXb("sd 3");
					break;
				case 6:
					if (testEngine.modeDepth)
					{
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
					WriteLine("start test standard 1");
					if (testEngine.protocol == CProtocol.uci)
						TestUci("go wtime 500 btime 500 winc 0 binc 0");
					else
						TestXb("time 50");
					break;
				case 9:
					if (testEngine.modeStandard)
					{
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
					WriteLine("start test tournament 1");
					if (testEngine.protocol == CProtocol.uci)
						TestUci("go wtime 20000 btime 20000 winc 0 binc 0 movestogo 80");
					else
						TestXb("level 80 0:20 0");
					break;
				case 12:
					if (testEngine.modeTournament)
					{
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
					WriteLine("start test nodes 1");
					if (testEngine.protocol == CProtocol.uci)
						TestUci("go nodes 1000");
					else
						NextPhase();
					break;
				case 15:
					if (testEngine.modeNodes)
					{
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
						testEngine.modeInfinite = false;
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
			progressBar.Maximum = countAuto * 19;
			progressBar.Value = 0;
			tbConsole.Clear();
			report.Clear();
			tick = 0;
			testMode = -1;
			timer.Restart();
			testTimer.Start();
		}

		#endregion

		static void WriteLine(string line = "")
		{
			TimeSpan ts = testWatch.Elapsed;
			string s = $"{ts.Seconds:D2}";
			string m = $"{ts.Milliseconds:D3}";
			string t = $"{s}.{m}";
			This.tbConsole.AppendText($"{t} {line}\n");
			report.Add($"{t} {line}");
		}

		static void WriteLineToEngine(string line)
		{
			WriteLine($"> {line}");
			testProcess.WriteLine(line, true);
		}

		static void WriteLineFromEngine(string line)
		{
			WriteLine($"< {line}");
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
