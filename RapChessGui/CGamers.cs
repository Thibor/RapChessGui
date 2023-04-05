using System;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using NSChess;
using System.Windows.Forms;

namespace RapChessGui
{

	public class CGamerBook : CProcessBuf
	{
		public bool optionSended = false;
		public bool isBookStarted = false;
		/// <summary>
		/// Is no move int the open book.
		/// </summary>
		public bool isBookFail = false;
		public string name = string.Empty;

		public bool SetProgram(string path, string param, string name)
		{
			optionSended = false;
			isBookStarted = false;
			isBookFail = false;
			this.name = name;
			return SetProgram(path, param);
		}

	}

	public class CGamerEngine : CProcessBuf
	{
		/// <summary>
		/// Ceation of the protocol header has started.
		/// </summary>
		public bool isPrepareStarted = false;
		/// <summary>
		/// The engine is already running.
		/// </summary>
		public bool isEngRunning = false;
		/// <summary>
		/// Creation of the protocol header is complete.
		/// </summary>
		public bool isPreparedUci = false;
		/// <summary>
		/// The position of the chess pieces has been sent to the winboard chess engine.
		/// </summary>
		public bool isPositionXb = false;
		/// <summary>
		/// Phase of prepare uci engine.
		/// </summary>
		public int phaseUci = 0;
	}

	public class CGamer
	{
		/// <summary>
		/// Count moves maked by book.
		/// </summary>
		public int countMovesBook;
		/// <summary>
		/// Count moves maked by engine.
		/// </summary>
		public int countMovesEngine;
		public int depthTotal;
		public int depthCount;
		public int depthMax;
		public int msgPriority = 0;
		public int scoreI;
		public ulong infMs;
		public ulong nodes;
		public ulong nps;
		public ulong npsTotal;
		public ulong npsCount;
		public string strScore;
		public string strDepth;
		public int depth;
		public int seldepth;
		int hash;
		public string ponder;
		public string pv;
		public string lastMove;
		public double timerStart;
		public Stopwatch timer = new Stopwatch();
		public CProcessBuf curProcess = null;
		public CGamerBook gamerBook = new CGamerBook();
		public CGamerEngine gamerEngine = new CGamerEngine();
		public CBook book = null;
		public CEngine engine = null;
		public CPlayer player = new CPlayer();


		public int Hash
		{
			get
			{
				return hash;
			}
			set
			{
				if (hash < 0)
					hash = 0;
				if (hash > 1000)
					hash = 1000;
				hash = value;
			}
		}

		public CGamer()
		{
			InitNewGame();
		}

		public Bitmap GetBitmap(int height, out int width)
		{
			Bitmap bmp = GetBitmap();
			double ratio = (double)bmp.Width / bmp.Height;
			width = Convert.ToInt32(height * ratio);
			return bmp;
		}


		public Bitmap GetBitmap()
		{
			Bitmap bmp = FormChess.This.Icon.ToBitmap();
			if (engine == null)
				return bmp;
			string path = engine.GetFileName();
			if (!File.Exists(path))
				return bmp;
			string dir = Path.GetDirectoryName(path);
			string name = Path.GetFileNameWithoutExtension(path);
			string p = $@"{dir}\{name}.bmp";
			try
			{
				if (File.Exists(p))
					return new Bitmap(p);
				string[] an = engine.name.Split();
				if (an.Length > 0)
				{
					p = $@"{dir}\{an[0]}.bmp";
					if (File.Exists(p))
						return new Bitmap(p);
				}
				string[] filePaths = Directory.GetFiles(dir, "*.bmp");
				if (filePaths.Length == 1)
					return new Bitmap(filePaths[0]);
				filePaths = Directory.GetFiles(dir);
				foreach (string fp in filePaths)
				{
					string ext = Path.GetExtension(fp);
					if ((ext == ".bmp") || (ext == ".jpg") || (ext == ".jpeg") || (ext == ".png") || (ext == ".gif"))
						return new Bitmap(Image.FromFile(fp));
				}
			}
			catch (Exception ex)
			{
				FormChess.log.Add(ex.Message);
			}
			return Icon.ExtractAssociatedIcon(path).ToBitmap();
		}

		public string GetMessage(out bool book)
		{
			book = false;
			string msg = String.Empty;
			if (curProcess == gamerEngine)
			{
				msg = gamerEngine.GetMessage(timer.IsRunning,out bool stop);
				if (stop)
					timer.Stop();
				return msg;
			}
			if (curProcess == gamerBook)
			{
				book = true;
				return gamerBook.GetMessage();
			}
			return msg;
		}

		public bool IsWhite()
		{
			return this == CGamers.GamerWhite();
		}

		public bool IsBlack()
		{
			return this == CGamers.GamerBlack();
		}

		public bool IsHuman()
		{
			return player.IsHuman();
		}

		public bool IsComputer()
		{
			return player.IsComputer();
		}

		void OptionsToEngine()
		{
			if (player.humanElo)
			{
				SendMessageToEngine("setoption name UCI_LimitStrength value true");
				SendMessageToEngine($"setoption name UCI_Elo value {CPlayerList.humanPlayer.StrElo}");
			}
			else
				foreach (string op in engine.options)
					SendMessageToEngine($"setoption {op}");
		}

		void OptionsToBook()
		{
			foreach (string op in book.options)
				SendMessageToBook($"book setoption {op}");
			if (book.options.Count > 0)
				SendMessageToBook("book optionend");
			gamerBook.optionSended = true;
		}

		public void NextPhaseUci()
		{
			switch (++gamerEngine.phaseUci)
			{
				case 1:
					SendMessageToEngine("uci");
					break;
				case 2:
					OptionsToEngine();
					SendMessageToEngine("isready");
					break;
				case 3:
					SendMessageToEngine("ucinewgame");
					SendMessageToEngine("isready");
					break;
				case 4:
					gamerEngine.isPreparedUci = true;
					break;
			}
		}

		public void Restart()
		{
			gamerBook.Restart();
			gamerEngine.Restart();
		}

		public void EngineRestart()
		{
			gamerEngine.isPrepareStarted = false;
			gamerEngine.Restart();
		}

		public void EngineStop()
		{
			if (engine?.protocol == CProtocol.uci)
				SendMessageToEngine("stop");
			else
				SendMessageToEngine("?");
		}

		public void EngineTerminate()
		{
			gamerEngine.Terminate();
		}

		public void EngineQuit()
		{
			SendMessageToEngine("quit");
		}

		public void InitNewGame()
		{
			curProcess = null;
			gamerBook.isBookStarted = false;
			gamerBook.isBookFail = false;
			gamerEngine.isEngRunning = false;
			gamerEngine.isPrepareStarted = false;
			gamerEngine.isPreparedUci = false;
			gamerEngine.isPositionXb = false;
			gamerEngine.phaseUci = 0;
			hash = 0;
			infMs = 0;
			countMovesBook = 0;
			countMovesEngine = 0;
			nodes = 0;
			nps = 0;
			npsTotal = 0;
			npsCount = 0;
			depthTotal = 0;
			depthCount = 0;
			timerStart = 0;
			timer.Reset();
			InitNextMove();
			if (gamerBook == CGamers.bookSta)
				gamerBook = new CGamerBook();
		}

		public void InitNextMove()
		{
			depth = 0;
			msgPriority = 0;
			seldepth = 0;
			scoreI = 0;
			lastMove = String.Empty;
			ponder = String.Empty;
			pv = String.Empty;
			strScore = String.Empty;
			strDepth = String.Empty;
		}

		public void MoveDone()
		{
			if (gamerBook.isBookStarted && !gamerBook.isBookFail)
				countMovesBook++;
			else
			{
				countMovesEngine++;
				if (depth > 0)
				{
					depthCount++;
					depthTotal += depth;
				}
				if (nps > 0)
				{
					npsCount++;
					npsTotal += nps;
					if ((npsTotal > (ulong.MaxValue >> 1)) && ((npsCount & 1) == 0))
					{
						npsTotal >>= 1;
						npsCount >>= 1;
					}
				}
			}
		}

		public string GetName()
		{
			if (player.name == String.Empty)
				return IsWhite() ? "White" : "Black";
			else
				return player.name;
		}

		public int GetDepthAvg()
		{
			return (depthTotal + depth) / (depthCount + 1);
		}

		public ulong GetNpsAvg()
		{
			return (npsTotal + nps) / (npsCount + 1);
		}

		public string GetEngineFile()
		{
			if (engine == null)
				return string.Empty;
			else
				return engine.file;
		}

		public string GetEngineName()
		{
			return engine == null ? Global.none : engine.name;
		}

		/// <summary>
		/// Start or prepare engine or book.
		/// </summary>
		public void TryStart()
		{
			if (player.IsComputer())
				if ((book != null) && (!gamerBook.isBookFail))
				{
					if (!gamerBook.optionSended)
						OptionsToBook();
					if (!gamerBook.isBookStarted)
					{
						SendMessageToBook(CHistory.GetPosition());
						SendMessageToBook("go");
						gamerBook.isBookStarted = true;
					}
				}
				else if (engine != null)
					if (!gamerEngine.isPrepareStarted)
						EngPrepare();
					else if (gamerEngine.isPreparedUci && !gamerEngine.isEngRunning)
						EngMakeMove();
		}

		public void TimerStart()
		{

			timer.Start();
			timerStart = timer.Elapsed.TotalMilliseconds;
		}

		public void Undo()
		{
			if (engine != null)
				if (engine.protocol == CProtocol.winboard)
					gamerEngine.isPositionXb = false;
		}

		/// <summary>
		/// Prepare engine.
		/// </summary>
		void EngPrepare()
		{
			gamerEngine.isPrepareStarted = true;
			lastMove = String.Empty;
			if (engine.protocol == CProtocol.uci)
				NextPhaseUci();
			else
			{
				SendMessageToEngine("xboard");
				gamerEngine.isPreparedUci = true;
				XbGo();
			}
		}

		public int GetRemainingMs()
		{
			int v = Convert.ToInt32(player.levelValue.GetUciValue());
			int t = Convert.ToInt32(v - timer.Elapsed.TotalMilliseconds);
			return t < 1 ? 1 : t;
		}

		public string GetTimeXB(long ms)
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(ms);
			return dt.ToString("mm:ss");
		}

		void UciGo()
		{
			SendMessageToEngine(CHistory.GetPosition());
			if (player.levelValue.level == CLevel.standard)
			{
				CGamer gw = CGamers.GamerWhite();
				CGamer gb = CGamers.GamerBlack();
				SendMessageToEngine($"go wtime {gw.GetRemainingMs()} btime {gb.GetRemainingMs()} winc 0 binc 0");
			}
			else
				SendMessageToEngine($"go {player.levelValue.GetUci()} {player.levelValue.GetUciValue()}");
			TimerStart();
		}

		void XbGoTournament()
		{
			int ms = GetRemainingMs();
			SendMessageToEngine($"level 0 {GetTimeXB(ms)} 0");
		}

		void XbGoStandard()
		{
			if (engine.modeStandard)
			{
				CGamer gs = CGamers.GamerSec();
				SendMessageToEngine($"time {GetRemainingMs() / 10}");
				SendMessageToEngine($"otim {gs.GetRemainingMs() / 10}");
			}
			else
				XbGoTournament();
		}

		void XbGoTime()
		{
			int ms = player.levelValue.GetUciValue();
			if (engine.modeTime)
				SendMessageToEngine($"st {ms / 1000}");
			else
				SendMessageToEngine($"level 0 0 {ms / 1000}");
		}

		void XbGoDepth()
		{
			int d = player.levelValue.GetUciValue();
			SendMessageToEngine($"sd {d}");
		}

		void XbGo()
		{
			switch (player.levelValue.level)
			{
				case CLevel.standard:
					XbGoStandard();
					break;
				case CLevel.depth:
					XbGoDepth();
					break;
				case CLevel.time:
					XbGoTime();
					break;
			}
		}

		/// <summary>
		/// Prepare or start engine when is his turn.
		/// </summary>
		public void EngMakeMove()
		{
			if (engine.protocol == CProtocol.uci)
				UciGo();
			else
			{
				if (gamerEngine.isPositionXb)
				{
					XbGo();
					SendMessageToEngine(CHistory.LastUmo());
				}
				else
				{
					SendMessageToEngine("new");
					XbGo();
					SendMessageToEngine("post");
					if (CHistory.fen != CChess.defFen)
					{
						SendMessageToEngine($"setboard {CHistory.fen}");
					}
					SendMessageToEngine("force");
					foreach (CHisMove m in CHistory.moveList)
						SendMessageToEngine(m.umo);
					if ((CHistory.moveList.Count & 1) == 0)
						SendMessageToEngine("white");
					else
						SendMessageToEngine("black");
					SendMessageToEngine("go");
					gamerEngine.isPositionXb = true;
				}
				TimerStart();
			}
			gamerEngine.isEngRunning = true;
		}

		public void SendMessageToBook(string msg)
		{

			Color col = IsWhite() ? Color.DimGray : Color.Black;
			FormLogEngines.AppendTimeText($"book {player.name}", col);
			FormLogEngines.AppendText($" < {msg}\n", Color.Brown);
			gamerBook.WriteLine(msg);
			curProcess = gamerBook;
		}

		public void SendMessageToEngine(string msg)
		{

			Color col = IsWhite() ? Color.DimGray : Color.Black;
			FormLogEngines.AppendTimeText($"{player.name}", col);
			FormLogEngines.AppendText($" < {msg}\n", Color.Brown);
			gamerEngine.WriteLine(msg);
			curProcess = gamerEngine;
		}

		public string GetBookName()
		{
			return book?.name ?? "Book";
		}

		public string GetMode()
		{
			return player?.levelValue.LongName() ?? "Mode";
		}

		public string GetProtocol()
		{
			if (engine == null)
				return "Protocol";
			return CData.ProtocolToStr(engine.protocol);
		}

		public string GetDepth()
		{
			if (depth > 0)
				return $"{depth} / {seldepth} / {GetDepthAvg()}";
			return String.Empty;
		}

		public Color GetScoreColor()
		{
			double dr = 1.0;
			double dg = 1.0;
			if (scoreI > 0)
				dr = 1.0 - scoreI / 500.0;
			if (scoreI < 0)
				dg = 1.0 + scoreI / 500.0;
			if (dr < 0)
				dr = 0;
			if (dg < 0)
				dg = 0;
			return Color.FromArgb(200, Convert.ToInt32(dr * 0xff), Convert.ToInt32(dg * 0xff), 0);
		}

		public string GetTime(out bool low)
		{
			low = false;
			TimeSpan ts = timer.Elapsed;
			double ms = ts.TotalMilliseconds;
			CLevel level = CLevel.standard;
			int value = 0;
			if (player != null)
			{
				level = player.levelValue.level;
				value = player.levelValue.GetUciValue();
			}
			if (level == CLevel.standard)
			{
				double v = Convert.ToDouble(value);
				double t = v - ms;
				ts = TimeSpan.FromMilliseconds(t);
				if ((CData.gameMode != CGameMode.game) && (ts.TotalMilliseconds < -FormOptions.marginStandard) && (FormOptions.marginStandard >= 0) && timer.IsRunning)
				{
					FormChess.This.SetGameState(CGameState.time);
					return "Time out";
				}
				if (ts.TotalSeconds < 10)
				{
					low = true;
					return $"{ts.TotalSeconds:N2}";
				}
			}
			else if (level == CLevel.time)
			{
				double v = Convert.ToDouble(value);
				if ((CData.gameMode != CGameMode.game) && ((ms - timerStart) > (v + FormOptions.marginTime)) && (FormOptions.marginTime >= 0) && (value > 0) && timer.IsRunning)
				{
					FormChess.This.SetGameState(CGameState.time);
					return "Time out";
				}
				ts.Add(TimeSpan.FromMilliseconds(ms));
			}
			else
				ts.Add(TimeSpan.FromMilliseconds(ms));
			return ts.ToString(@"hh\:mm\:ss");
		}

		public string GetElo()
		{
			if (player == null)
				return "Elo";
			else
				return $"Elo {player.StrElo}";
		}

		public string GetPlayerName()
		{
			if (player == null)
				return Global.human;
			else
				return player.GetName();
		}

		public void SetPlayer(CPlayer p)
		{
			SetPlayer(p, p.BookName);
		}

		public void SetPlayer(CPlayer p, string b)
		{
			player = p;
			SetBook(b);
			SetEngine(p.EngineName);
		}

		public void SetPlayer(CPlayer p, CGamerBook b)
		{
			player = p;
			book = FormChess.bookList.GetBookByName(p.BookName);
			gamerBook = b;
			SetEngine(p.EngineName);
		}

		public void SetPlayer()
		{
			SetPlayer(player);
		}

		public void SetPlayer(string name)
		{
			CPlayer p = FormChess.playerList.GetPlayerByName(name);
			SetPlayer(p);
		}

		public void SetBook(string b)
		{
			book = FormChess.bookList.GetBookByName(b);
			if (book == null)
				gamerBook.Terminate();
			else
				gamerBook.SetProgram(book.GetPath(), book.arguments);
		}

		public void SetEngine(string e)
		{
			engine = FormChess.engineList.GetEngineByName(e);
			if (engine == null)
				gamerEngine.Terminate();
			else
				gamerEngine.SetProgram(engine.GetPath(), engine.arguments);
		}

	}

	class CGamers
	{
		/// <summary>
		/// Index of current gammer
		/// </summary>
		static int curIndex = 0;
		readonly static CGamer[] gamers = new CGamer[2];
		public static CGamerBook bookSta = new CGamerBook();

		public bool WhiteTurn
		{
			get { return curIndex == 0; }
			set { curIndex = value ? 0 : 1; }
		}

		public CGamers()
		{
			gamers[0] = new CGamer();
			gamers[1] = new CGamer();
		}

		public bool Check(out string msg)
		{
			msg = String.Empty;
			foreach (CGamer g in gamers)
				if (!g.player.Check(out msg))
					return false;
			return true;
		}

		public void Next()
		{
			CGamer cg = GamerCur();
			cg.timer.Stop();
			cg.gamerBook.isBookStarted = false;
			cg.gamerBook.isBookFail = false;
			cg.gamerEngine.isEngRunning = false;
			curIndex ^= 1;
			cg = GamerCur();
			cg.InitNextMove();
			if (cg.player.IsHuman())
				cg.TimerStart();
			if (FormChess.chess.WhiteTurn)
				FormLogEngines.AddMove(FormChess.chess.MoveNumber);
		}

		public void InitNewGame()
		{
			curIndex = 0;
			foreach (CGamer g in gamers)
				g.InitNewGame();
			bookSta.Clear();
		}

		public void Rotate()
		{
			(gamers[1], gamers[0]) = (gamers[0], gamers[1]);
		}

		public CGamer GetGamer(string name)
		{
			foreach (CGamer p in gamers)
				if (p.player.name == name)
					return p;
			return null;
		}

		public int GetMsgPriority()
		{
			return gamers[0].msgPriority > gamers[1].msgPriority ? gamers[0].msgPriority : gamers[1].msgPriority;
		}

		public static CGamer GamerWhite()
		{
			return gamers[0];
		}

		public static CGamer GamerBlack()
		{
			return gamers[1];
		}

		public CGamer GamerWinner()
		{
			return gamers[(FormChess.chess.halfMove & 1) ^ 1];
		}

		public CGamer GamerLoser()
		{
			return gamers[FormChess.chess.halfMove & 1];
		}

		public CGamer GamerHuman()
		{
			foreach (CGamer g in gamers)
				if (g.player.IsHuman())
					return g;
			return null;
		}

		public CGamer GamerComputer()
		{
			foreach (CGamer g in gamers)
				if (g.player.IsComputer())
					return g;
			return null;
		}

		public static CGamer GamerCur()
		{
			return gamers[curIndex];
		}

		public static CGamer GamerSec()
		{
			return gamers[curIndex ^ 1];
		}

		public void Restart()
		{
			foreach (CGamer g in gamers)
				g.Restart();
		}

		public void Terminate()
		{
			foreach (CGamer g in gamers)
			{
				g.timer.Stop();
				g.gamerEngine.Close(true);
				if (g.gamerBook != CGamers.bookSta)
					g.gamerBook.Close(false);
			}
		}

		public void Undo()
		{
			foreach (CGamer g in gamers)
				g.Undo();
		}

		public CPlayer GetHuman()
		{
			foreach (CGamer g in gamers)
				if (g.player.IsHuman())
					return g.player;
			return null;
		}

		public void SetPlayers(CPlayer pw, CPlayer pb)
		{
			Terminate();
			InitNewGame();
			if ((pw.BookName != bookSta.name) && (pb.BookName != bookSta.name))
			{
				CBook bw = FormChess.bookList.GetBookByName(pw.BookName);
				CBook bb = FormChess.bookList.GetBookByName(pb.BookName);
				string bfw = string.Empty;
				string bfb = string.Empty;
				if (bw != null)
					bw.GetBFFromOption(out bfw);
				if (bb != null)
					bb.GetBFFromOption(out bfb);
				if ((bw != null) && (bfw != string.Empty))
					bookSta.SetProgram(pw.book.GetPath(), pw.book.arguments, pw.BookName);
				else if ((bb != null) && (bfb != string.Empty))
					bookSta.SetProgram(pb.book.GetPath(), pb.book.arguments, pb.BookName);
			}
			foreach (CGamer g in gamers)
				g.gamerBook = new CGamerBook();
			if (!string.IsNullOrEmpty(bookSta.name) && (pw.BookName == bookSta.name))
				gamers[0].SetPlayer(pw, bookSta);
			else
				gamers[0].SetPlayer(pw);
			if (!string.IsNullOrEmpty(bookSta.name) && (pb.BookName == bookSta.name))
				gamers[1].SetPlayer(pb, bookSta);
			else
				gamers[1].SetPlayer(pb);
		}


	}
}