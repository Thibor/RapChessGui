using NSChess;
using NSUci;
using RapIni;
using RapLog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RapChessGui
{


	public partial class FormChess : Form
	{
		#region variable

		[DllImport("gdi32.dll")]
		private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

		[DllImport("user32")]
		private static extern bool ShowScrollBar(IntPtr hwnd, int wBar, [MarshalAs(UnmanagedType.Bool)] bool bShow);

		public const int WM_GAME_NEXT = 1024;
		public static IntPtr handle;
		public static FormChess This;
		public static bool boardRotate;
		public static string mode = "Game";
		string continuations = String.Empty;
		List<int> moves = new List<int>();
		public static CRapIni iniFile = new CRapIni(@"Ini\options.ini");
		public static CReaderList readerList = new CReaderList();
		readonly CBoard Board = new CBoard();
		readonly CEcoList EcoList = new CEcoList();
		readonly CUci uci = new CUci();
		public static CChess chess = new CChess();
		readonly SoundPlayer audioMove = new SoundPlayer(Properties.Resources.Move);
		readonly SoundPlayer audioCapture = new SoundPlayer(Properties.Resources.Capture);
		readonly SoundPlayer audioCastling = new SoundPlayer(Properties.Resources.Castling);
		readonly SoundPlayer audioCheck = new SoundPlayer(Properties.Resources.Check);
		public static CRapLog log = new CRapLog(@"History\RapChessGui.log");
		public static PrivateFontCollection pfc = new PrivateFontCollection();
		public static CBookList bookList = new CBookList();
		public static CEngineList engineList = new CEngineList();
		public static CPlayerList playerList = new CPlayerList();
		readonly FormLogProgram formLogProgram = new FormLogProgram();
		readonly FormLogGames formLogGames = new FormLogGames();
		readonly FormLogEngines formLogEngines = new FormLogEngines();
		readonly FormLastGame formLastGame = new FormLastGame();
		readonly FormOptions formOptions = new FormOptions();
		readonly FormChartB formChartB = new FormChartB();
		readonly FormChartP formChartP = new FormChartP();
		readonly FormChartE formChartE = new FormChartE();
		readonly FormListB formListB = new FormListB();
		readonly FormListE formListE = new FormListE();
		readonly FormListP formListP = new FormListP();
		readonly FormEditEngine formEngine = new FormEditEngine();
		readonly FormEditBook formBook = new FormEditBook();
		readonly FormEditPlayer formPlayer = new FormEditPlayer();
		readonly CGamerList GamerList = new CGamerList();

		#endregion

		#region initiation

		protected override void WndProc(ref Message m)
		{
			const int WM_SYSCOMMAND = 0x0112;
			const int SC_MINIMIZE = 0xF020;
			switch (m.Msg)
			{
				case WM_SYSCOMMAND:
					int command = m.WParam.ToInt32() & 0xfff0;
					if (command == SC_MINIMIZE)
						SplitSaveToIni();
					break;
				case WM_GAME_NEXT:
					NextGame();
					break;
			}
			base.WndProc(ref m);
		}

		public FormChess()
		{
			This = this;
			CreateDir("Books");
			CreateDir("Engines");
			CreateDir(@"Engines/Auto");
			CreateDir("History");
			CreateDir("Ini");
			CData.UpdateFileEngine();
			CData.UpdateBookReader();
			int fontLength = Properties.Resources.ChessPiece.Length;
			byte[] fontData = Properties.Resources.ChessPiece;
			IntPtr data = Marshal.AllocCoTaskMem(fontLength);
			Marshal.Copy(fontData, 0, data, fontLength);
			uint cFonts = 0;
			AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);
			pfc.AddMemoryFont(data, fontLength);
			Marshal.FreeCoTaskMem(data);
			InitializeComponent();
			IniLoad();
			bookList.Update();
			Reset(true);
			Font fontChess = new Font(pfc.Families[0], 16);
			Font fontChessPromo = new Font(pfc.Families[0], 32);
			labTakenT.Font = fontChess;
			labTakenD.Font = fontChess;
			foreach (Control c in tlpPromotion.Controls)
				(c as Label).Font = fontChessPromo;
			foreach (Control c in tlpEdit.Controls)
				(c as Label).Font = fontChess;
			toolTip1.Active = FormOptions.showTips;
			CWinMessage.winHandle = Handle;
			BoardPrepare();
			combMainMode.SelectedIndex = 0;
			timerAnimation.Enabled = true;
			EditSelected = "P";
		}

		void CreateDir(string dir)
		{
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
		}

		void IniLoad()
		{
			Width = iniFile.ReadInt("position>width", Width);
			Height = iniFile.ReadInt("position>height", Height);
			if (Width < 600)
				Width = 600;
			if (Height < 600)
				Height = 600;
			int x = iniFile.ReadInt("position>x", Location.X);
			int y = iniFile.ReadInt("position>y", Location.Y);
			if (x < 0)
				x = 0;
			if (y < 0)
				y = 0;
			Location = new Point(x, y);
			if (iniFile.ReadBool("position>maximized", false))
				WindowState = FormWindowState.Maximized;
			readerList.LoadFromIni();
			bookList.LoadFromIni();
			engineList.LoadFromIni();
			playerList.LoadFromIni();
			CModeGame.LoadFromIni();
			CModeMatch.LoadFromIni();
			CModeTournamentB.LoadFromIni();
			CModeTournamentE.LoadFromIni();
			CModeTournamentP.LoadFromIni();
			CModeTraining.LoadFromIni();
		}

		void IniSave()
		{
			bool maximized = WindowState == FormWindowState.Maximized;
			int width = maximized ? RestoreBounds.Width : Width;
			int height = maximized ? RestoreBounds.Height : Height;
			int x = maximized ? RestoreBounds.X : Location.X;
			int y = maximized ? RestoreBounds.Y : Location.Y;
			iniFile.Write("position>maximized", maximized);
			iniFile.Write("position>width", width);
			iniFile.Write("position>height", height);
			iniFile.Write("position>x", x);
			iniFile.Write("position>y", y);
			SplitSaveToIni();
			iniFile.Save();
			CBookList.iniFile.Save();
			CEngineList.iniFile.Save();
			CPlayerList.iniFile.Save();
			CReaderList.iniFile.Save();
		}

		void SplitSaveToIni(SplitContainer sc)
		{
			int size = sc.Orientation == Orientation.Horizontal ? sc.Size.Height : sc.Size.Width;
			double p = (double)sc.SplitterDistance / size;
			iniFile.Write($"position>split>{sc.Name}", p);
		}

		void SplitLoadFromIni(SplitContainer sc)
		{
			int size = sc.Orientation == Orientation.Horizontal ? sc.Size.Height : sc.Size.Width;
			double o = (double)sc.SplitterDistance / size;
			double p = iniFile.ReadDouble($"position>split>{sc.Name}", o);
			if (p > 1)
				p = 1;
			int d = Convert.ToInt32(p * size);
			try
			{
				if (d > sc.Panel1MinSize)
					sc.SplitterDistance = d;
			}
			catch { }
		}

		void SplitLoadFromIni()
		{
			SplitLoadFromIni(splitContainerMain);
			SplitLoadFromIni(splitContainerBoard);
			SplitLoadFromIni(splitContainerChart);
			SplitLoadFromIni(splitContainerTourB);
			SplitLoadFromIni(splitContainerTourE);
			SplitLoadFromIni(splitContainerTourP);
			SplitLoadFromIni(scTournamentEList);
			SplitLoadFromIni(scTournamentPList);
		}

		void SplitSaveToIni()
		{
			SplitSaveToIni(splitContainerMain);
			SplitSaveToIni(splitContainerBoard);
			SplitSaveToIni(splitContainerChart);
			SplitSaveToIni(splitContainerTourB);
			SplitSaveToIni(splitContainerTourE);
			SplitSaveToIni(splitContainerTourP);
			SplitSaveToIni(scTournamentEList);
			SplitSaveToIni(scTournamentPList);
		}

		#endregion initiation

		#region main

		void ShowFormBook(string bookName = "")
		{
			FormEditBook.bookName = bookName;
			formBook.ShowDialog(this);
			Reset();
		}

		void ShowFormEngine(string engineName = "")
		{
			FormEditEngine.engineName = engineName;
			formEngine.ShowDialog(this);
			Reset();
		}

		void ShowFormPlayer(string playerName = "")
		{
			FormEditPlayer.playerName = playerName;
			formPlayer.ShowDialog(this);
			Reset();
		}

		void MakeBoardSquare()
		{
			splitContainerBoard.SplitterDistance = panBoard.Height;
		}

		void PlaySound(bool capture, bool castling, bool check)
		{
			if (FormOptions.soundOn)
				if (capture)
					audioCapture.Play();
				else if (castling)
					audioCastling.Play();
				else if (check)
					audioCheck.Play();
				else
					audioMove.Play();
		}

		void SquareBoard()
		{
			splitContainerBoard.SplitterDistance = panBoard.Height;
		}

		void GameLoop()
		{
			labGameTime.Text = FormLogEngines.GetTime();
			CGamer g = GamerList.GamerCur();
			string msg = g.GetMessage(out int pid);
			if (!String.IsNullOrEmpty(msg))
				GetMessage(pid, msg);
			if (CBoard.animated || CDrag.dragged)
				RenderBoard();
			else if (CData.gameState == CGameState.normal)
			{
				g.TryStart();
				ShowInfo(GamerList.GamerCur());
				ShowInfo(GamerList.GamerSec());
			}
		}

		void ComClear()
		{
			continuations = String.Empty;
			Text = $"RapChessGui Games {CData.gamesPlayed} Draws {CData.gamesDraw} Time out {CData.gamesTime} Errors {CData.gamesError}";
			CData.eco = String.Empty;
			CData.gameState = CGameState.normal;
			labEloD.BackColor = Color.LightGray;
			labEloD.ForeColor = Color.Black;
			labEloT.BackColor = Color.LightGray;
			labEloT.ForeColor = Color.Black;
			labEco.Text = String.Empty;
			ShowInfo("Good luck", Color.Gainsboro);
			labResult.Hide();
			chartMain.Series[0].Points.Clear();
			chartMain.Series[1].Points.Clear();
			lvMoves.Items.Clear();
			lvMovesW.Items.Clear();
			lvMovesB.Items.Clear();
			PrepareFen();
			GamerList.Init();
		}

		void ComShow()
		{
			CGamer gw = GamerList.gamers[0];
			CGamer gb = GamerList.gamers[1];
			FormLogEngines.WriteHeader(gw, gb);
			ShowGamers();
			ShowInfo(gw);
			ShowInfo(gb);
			SetBoardRotate();
			if (GamerList.GamerCur().player.IsHuman())
				moves = chess.GenerateValidMoves(out _);
		}

		public void SetColor()
		{
			CBoard.SetColor();
			labPlayerW.BackColor = CBoard.colorLabelB;
			labPlayerB.BackColor = CBoard.colorLabelB;
			labEngineW.BackColor = CBoard.colorLabelB;
			labEngineB.BackColor = CBoard.colorLabelB;
			labBookNW.BackColor = CBoard.colorLabelB;
			labBookNB.BackColor = CBoard.colorLabelB;
			labModeW.BackColor = CBoard.colorLabelB;
			labModeB.BackColor = CBoard.colorLabelB;
			labProtocolW.BackColor = CBoard.colorLabelB;
			labProtocolB.BackColor = CBoard.colorLabelB;
			labMemoryW.BackColor = CBoard.colorLabelB;
			labMemoryB.BackColor = CBoard.colorLabelB;
			labScoreW.BackColor = CBoard.colorLabelW;
			labScoreB.BackColor = CBoard.colorLabelW;
			labDepthW.BackColor = CBoard.colorLabelW;
			labDepthB.BackColor = CBoard.colorLabelW;
			labNodesW.BackColor = CBoard.colorLabelW;
			labNodesB.BackColor = CBoard.colorLabelW;
			labNpsW.BackColor = CBoard.colorLabelW;
			labNpsB.BackColor = CBoard.colorLabelW;
			labBookCW.BackColor = CBoard.colorLabelW;
			labBookCB.BackColor = CBoard.colorLabelW;
			chartMain.PaletteCustomColors[0] = CBoard.colorChartM;
			chartMain.PaletteCustomColors[1] = CBoard.colorChartD;
			chartGame.PaletteCustomColors[0] = CBoard.colorChartD;
			chartMatch.PaletteCustomColors[0] = CBoard.colorChartD;
			chartTournamentB.PaletteCustomColors[0] = CBoard.colorChartM;
			chartTournamentB.PaletteCustomColors[1] = CBoard.colorChartD;
			chartTournamentB.PaletteCustomColors[2] = CBoard.colorChartL;
			chartTournamentE.PaletteCustomColors[0] = CBoard.colorChartM;
			chartTournamentE.PaletteCustomColors[1] = CBoard.colorChartD;
			chartTournamentE.PaletteCustomColors[2] = CBoard.colorChartL;
			chartTournamentP.PaletteCustomColors[0] = CBoard.colorChartM;
			chartTournamentP.PaletteCustomColors[1] = CBoard.colorChartD;
			chartTournamentP.PaletteCustomColors[2] = CBoard.colorChartL;
			BackColor = CBoard.colorChartD;
			chartGame.Invalidate();
			chartMatch.Invalidate();
			ShowAutoElo();
			TournamentBReset();
			TournamentEReset();
			TournamentPReset();
		}

		void NextGame()
		{
			switch (CData.gameMode)
			{
				case CGameMode.match:
					MatchStart();
					break;
				case CGameMode.tourB:
					TournamentBStart();
					break;
				case CGameMode.tourE:
					TournamentEStart();
					break;
				case CGameMode.tourP:
					TournamentPStart();
					break;
				case CGameMode.training:
					TrainingStart();
					break;
			}
		}

		void PrepareFen(string fen = CChess.defFen)
		{
			CDrag.lastSou = -1;
			CDrag.lastDes = -1;
			chess.SetFen(fen);
			CHistory.SetFen(chess.GetFen(), chess.halfMove);
			Board.ClearArrows();
			Board.ClearColors();
			Board.Fill();
		}

		void ShowGamers()
		{
			CGamer gw = GamerList.gamers[0];
			CGamer gb = GamerList.gamers[1];
			labPlayerW.Text = gw.GetPlayerName();
			labPlayerB.Text = gb.GetPlayerName();
			labEngineW.Text = gw.GetEngineName();
			labEngineB.Text = gb.GetEngineName();
			labBookNW.Text = gw.GetBook();
			labBookNB.Text = gb.GetBook();
			labModeW.Text = gw.GetMode();
			labModeB.Text = gb.GetMode();
			labProtocolW.Text = gw.GetProtocol();
			labProtocolB.Text = gb.GetProtocol();
			labMemoryW.Text = gw.GetMemory();
			labMemoryB.Text = gb.GetMemory();
			splitContainerMoves.Panel1Collapsed = gw.player.IsHuman();
			splitContainerMoves.Panel2Collapsed = gb.player.IsHuman();
		}

		void ShowInfo(CGamer g)
		{
			if (g.isWhite)
			{
				labScoreW.Text = $"Score {g.strScore}";
				labDepthW.Text = $"Depth {g.strDepth}";
				labNodesW.Text = $"Nodes {g.nodes:N0}";
				labNpsW.Text = $"Nps {g.GetNpsAvg():N0}";
				labBookCW.Text = $"Book {g.countMovesBook}";
				labColW.BackColor = g.GetScoreColor();
				pbHashW.Value = g.Hash;
			}
			else
			{
				labScoreB.Text = $"Score {g.strScore}";
				labDepthB.Text = $"Depth {g.strDepth}";
				labNodesB.Text = $"Nodes {g.nodes:N0}";
				labNpsB.Text = $"Nps {g.GetNpsAvg():N0}";
				labBookCB.Text = $"Book {g.countMovesBook}";
				labColB.BackColor = g.GetScoreColor();
				pbHashB.Value = g.Hash;
			}
			if (boardRotate ^ g.isWhite)
			{
				if (CData.gameState == CGameState.normal)
				{
					labTimeD.Text = g.GetTime(out bool low);
					if ((g.timer.IsRunning) || (CData.gameState != CGameState.normal))
					{
						labTimeD.BackColor = low ? CBoard.colorRed : CBoard.colorLabelB;
						labTimeD.ForeColor = CBoard.colorMessage;
					}
					else
					{
						labTimeD.BackColor = Color.LightGray;
						labTimeD.ForeColor = Color.Black;
					}
				}
				labEloD.Text = g.GetElo();
			}
			else
			{
				if (CData.gameState == CGameState.normal)
				{
					labTimeT.Text = g.GetTime(out bool low);
					if ((g.timer.IsRunning) || (CData.gameState != CGameState.normal))
					{
						labTimeT.BackColor = low ? CBoard.colorRed : CBoard.colorLabelB;
						labTimeT.ForeColor = CBoard.colorMessage;
					}
					else
					{
						labTimeT.BackColor = Color.LightGray;
						labTimeT.ForeColor = Color.Black;
					}
				}
				labEloT.Text = g.GetElo();
			}
		}

		public void SetGameState(CGameState gs, CGamer gamer = null, string umo = "")
		{
			ShowMoveNumber();
			if (gs == CGameState.normal)
			{
				CData.gameState = CGameState.normal;
				return;
			}
			if (CData.gameState != CGameState.normal)
				return;
			CData.gameState = gs;
			CGamer gw = GamerList.GamerWinner();
			CGamer gl = GamerList.GamerLoser();
			if (gamer == gw)
			{
				gw = gl;
				gl = gamer;
			}
			CPlayer pw = gw.player;
			CPlayer pl = gl.player;
			CColor winColor = gw.isWhite ? CColor.white : CColor.black;
			string infoMsg = String.Empty;
			Color infoCol = Color.Silver;
			switch (CData.gameState)
			{
				case CGameState.mate:
					infoMsg = $"{pw.name} win";
					infoCol = Color.Lime;
					break;
				case CGameState.stalemate:
					winColor = CColor.none;
					infoMsg = "Stalemate";
					infoCol = Color.Yellow;
					break;
				case CGameState.repetition:
					winColor = CColor.none;
					infoMsg = "Threefold repetition";
					infoCol = Color.Yellow;
					break;
				case CGameState.move50:
					winColor = CColor.none;
					infoMsg = "Fifty-move rule";
					infoCol = Color.Yellow;
					break;
				case CGameState.material:
					winColor = CColor.none;
					infoMsg = "Insufficient material";
					infoCol = Color.Yellow;
					break;
				case CGameState.resignation:
					infoMsg = $"{pl.name} resign";
					infoCol = Color.Red;
					break;
				case CGameState.time:
					CData.gamesTime++;
					infoMsg = $"{pl.name} time out";
					infoCol = Color.Red;
					log.Add($"Time out {pl.name} {chess.GetFen()}");
					FormLogEngines.AppendText($"Time out {pl.name}\n", Color.Red);
					break;
				case CGameState.error:
					CData.gamesError++;
					labError.Show();
					infoMsg = $"{pl.name} make wrong move";
					infoCol = Color.Red;
					log.Add($"Wrong move {pl.name} ({umo}) {chess.GetFen()}");
					FormLogEngines.AppendText($"Wrong move: ({umo})\n", Color.Red);
					FormLogEngines.AppendText($"Fen: {chess.GetFen()}\n", Color.Black);
					break;
			}
			CGamer gWhi = GamerList.GamerWhite();
			CGamer gBla = GamerList.GamerBlack();
			FormLogEngines.AppendTimeText($" White: {gWhi.player.name}\n", Color.DimGray);
			FormLogEngines.AppendTimeText($" Engine: {gWhi.GetEngineName()}\n", Color.DimGray);
			FormLogEngines.AppendTimeText($" Clock: {gWhi.GetTime(out _)} Book: {gWhi.countMovesBook} Engine: {gWhi.countMovesEngine}\n", Color.DimGray);
			FormLogEngines.AppendTimeText($" Black: {gBla.player.name}\n", Color.Black);
			FormLogEngines.AppendTimeText($" Engine: {gBla.GetEngineName()}\n", Color.Black);
			FormLogEngines.AppendTimeText($" Clock: {gBla.GetTime(out _)} Book: {gBla.countMovesBook} Engine: {gBla.countMovesEngine}\n", Color.Black);
			FormLogEngines.AppendTimeText($" Finish {tssInfo.Text}\n", Color.Olive);
			if (winColor == CColor.none)
				CData.gamesDraw++;
			CData.gamesPlayed++;
			CreateRtf();
			CreatePgn();
			GamerList.Terminate();
			if (CData.gameMode == CGameMode.game)
				GameEnd(pw, pl, winColor == CColor.none);
			else
			{
				if (CData.gameMode == CGameMode.match)
					CModeMatch.GameEnd(winColor);
				if (CData.gameMode == CGameMode.tourB)
					TournamentBEnd(gw, gl, winColor == CColor.none);
				if (CData.gameMode == CGameMode.tourE)
					TournamentEEnd(gw, gl, winColor == CColor.none);
				if (CData.gameMode == CGameMode.tourP)
					TournamentPEnd(pw, pl, winColor == CColor.none);
				if (CData.gameMode == CGameMode.training)
					TrainingEnd(gw, winColor == CColor.none);
				Task.Delay(FormOptions.gameBreak * 1000).ContinueWith(t => CWinMessage.Message(WM_GAME_NEXT));
			}
			CPlayer hu = GamerList.GetHuman();
			if ((hu != null) && (CModeGame.ranked))
			{
				string elo = hu.hisElo.Change().ToString("+#;-#;0");
				elo = $"elo {hu.elo} ({elo})";
				if (winColor == CColor.none)
					infoMsg = $"{infoMsg} {elo}";
				else if (hu == pl)
				{
					infoMsg = $"You lost new {elo}";
					infoCol = Color.Red;
				}
				else
					infoMsg = $"You win new {elo}";
			}
			ShowInfo(infoMsg, infoCol, 2);
			labResult.Text = tssInfo.Text;
			labResult.ForeColor = tssInfo.ForeColor;
			labResult.Show();
		}

		public void BoardPrepare()
		{
			SetColor();
			SetBoardRotate();
			Board.Resize(panBoard.Width, panBoard.Height);
			RenderBoard();
		}

		void AddLines(CGamer g)
		{
			DateTime dt = new DateTime();
			try
			{
				dt = dt.AddMilliseconds(g.infMs);
			}
			catch
			{
				log.Add($"milliseconds {g.engine.name} {g.infMs}");
			}
			ListViewItem lvi = new ListViewItem(new[] { dt.ToString("mm:ss.ff"), g.strScore, g.strDepth, g.nodes.ToString("N0"), g.nps.ToString("N0"), g.pv });
			ListView lv = g.isWhite ? lvMovesW : lvMovesB;
			if ((lv.Items.Count & 1) > 0)
				lvi.BackColor = CBoard.colorMessage;
			lv.Items.Insert(0, lvi);
		}

		void SetPv(int i, CGamer g)
		{
			int selfdepth = 0;
			string pv = String.Empty;
			List<int> moves = new List<int>();
			for (int n = i; n < uci.tokens.Length; n++)
			{
				string move = uci.tokens[n];
				if (chess.IsValidMove(move, out string umo, out string san, out int emo))
				{
					selfdepth++;
					if (moves.Count == 0)
					{
						g.lastMove = umo;
						Board.arrowCur.AddMoves(umo);
						RenderBoard();
					}
					chess.MakeMove(emo);
					moves.Add(emo);
					if (FormOptions.isSan)
						pv += $" {san}";
					else
						pv += $" {umo}";
				}
			}
			for (int n = moves.Count - 1; n >= 0; n--)
				chess.UnmakeMove(moves[n]);
			if (pv != String.Empty)
				g.pv = pv;
			g.seldepth = selfdepth;
			g.strDepth = g.GetDepth();
			ShowInfo(pv, Color.Gainsboro, 0, g);
			AddLines(g);
		}

		public void GetMessageUci(CGamer g, string msg)
		{
			uci.SetMsg(msg);
			switch (uci.command)
			{
				case "uciok":
				case "readyok":
					g.NextPhaseUci();
					break;
				case "enginemove":
					g.isBookFail = true;
					break;
				case "bestmove":
					g.timer.Stop();
					if (GamerList.GamerCur() == g)
					{
						uci.GetValue("bestmove", out string umo);
						uci.GetValue("ponder", out g.ponder);
						if (g.isBookStarted && !g.isBookFail)
						{
							if (g.strScore == String.Empty)
								g.strScore = "book";
							ShowInfo($"book {umo}", Color.Aquamarine, 0, g);
							if ((g.engine != null) && (g.engine.protocol == CProtocol.winboard))
								g.isPositionXb = false;
						}
						MakeMove(umo);
					}
					break;
				case "log":
					log.Add($"{g.GetName()} => {uci.GetValue(1, 0)}");
					break;
				case "info":
					if (uci.GetIndex("string", 0) == 1)
					{
						ShowInfo(uci.GetValue(2, uci.tokens.Length - 1), Color.Gainsboro, 2, g);
						break;
					}
					string s;
					ulong nps = 0;
					if (uci.GetValue("hashfull", out s))
						g.Hash = Int32.Parse(s);
					if (uci.GetValue("cp", out s))
					{
						g.strScore = s;
						g.scoreI = Int32.Parse(s);
					}
					if (uci.GetValue("mate", out s))
					{
						int ip = Int32.Parse(s);
						if (ip > 0)
						{
							g.strScore = $"+{s}M";
							g.scoreI = 0xffff - ip;
						}
						else
						{
							g.strScore = $"{s}M";
							g.scoreI = -0xffff + ip;
						}
					}
					if (uci.GetValue("depth", out s))
						g.depth = Int32.Parse(s);
					if (uci.GetValue("nodes", out s))
					{
						try
						{
							g.nodes = (ulong)Convert.ToInt64(s);
						}
						catch
						{
							g.nodes = 0;
						}
					}
					if (uci.GetValue("nps", out s))
					{
						try
						{
							g.nps = (ulong)Convert.ToUInt64(s);
						}
						catch
						{
							g.nps = 0;
						}
						nps = g.nps;
					}
					if (uci.GetValue("time", out s))
					{
						try
						{
							g.infMs = (ulong)Convert.ToInt64(s);
						}
						catch
						{
							g.infMs = 0;
						}
						if (nps == 0)
							nps = g.infMs > 0 ? (g.nodes * 1000) / g.infMs : 0;
					}
					if (nps > 0)
						g.nps = nps;
					int i = uci.GetIndex("pv", 0);
					if (i > 0)
						SetPv(i + 1, g);
					break;
			}
		}

		bool GetMoveXb(string xmo, out string umo)
		{
			umo = xmo = new string(xmo.Where(c => !char.IsControl(c)).ToArray()).ToLower();
			if ((xmo == "o-o") || (xmo == "0-0"))
				umo = chess.WhiteTurn ? "e1g1" : "e8g8";
			if ((xmo == "o-o-o") || (xmo == "0-0-0"))
				umo = chess.WhiteTurn ? "e1c1" : "e8c8";
			if (chess.IsValidMove(umo, out _))
				return true;
			if (umo.Length > 4)
			{
				umo = umo.Substring(0, 4);
				if (chess.IsValidMove(umo, out _))
					return true;
			}
			umo += "q";
			if (chess.IsValidMove(umo, out _))
				return true;
			umo = xmo;
			return false;
		}

		public void GetMessageXb(CGamer g, string msg)
		{
			string umo;
			uci.SetMsg(msg);
			switch (uci.command)
			{
				case "0-1":
				case "1-0":
				case "1/2-1/2":
					SetGameState(CGameState.resignation, g);
					break;
				case "move":
					uci.GetValue("ponder", out g.ponder);
					GetMoveXb(uci.tokens[1], out umo);
					MakeMove(umo);
					break;
				default:
					string s = msg.ToLower();
					if (s.Contains("move"))
					{
						if (GetMoveXb(uci.GetValue("move"), out umo))
							MakeMove(umo);
					}
					else if (s.Contains("resign") || s.Contains("illegal"))
						SetGameState(CGameState.resignation, g);
					else if (g.isPreparedUci && Char.IsDigit(uci.tokens[0][0]) && (uci.tokens.Length > 4))
					{
						try
						{
							g.depth = Int32.Parse(uci.tokens[0]);
							g.strScore = uci.tokens[1];
							g.scoreI = Convert.ToInt32(g.strScore);
							g.infMs = (ulong)Convert.ToInt64(uci.tokens[2]) * 10;
							g.nodes = (ulong)Convert.ToInt64(uci.tokens[3]);
							ulong nps = g.infMs > 0 ? (g.nodes * 1000) / g.infMs : 0;
							if (nps > 0)
								g.nps = nps;
							SetPv(4, g);
						}
						catch
						{
							log.Add($"{g.player.name} ({g.player.Engine}) ({msg})");
						}
					}
					break;
			}
		}


		public void GetMessage(int pid, string msg)
		{
			CGamer gamer = GamerList.GetGamerPid(pid, out string protocol);
			if (gamer != null)
			{
				FormLogEngines.SetMessage(gamer, protocol, msg);
				if ((protocol == "Uci") || (protocol == "Book"))
					GetMessageUci(gamer, msg);
				if (protocol == "Winboard")
					GetMessageXb(gamer, msg);
			}
		}

		void CreateRtf(string fn)
		{
			FormLogEngines.Save($"History\\{fn}.rtf");
		}

		void CreateRtf()
		{
			CreateRtf(combMainMode.Text);
			if (CData.gameState == CGameState.time)
				CreateRtf("Time");
			if (CData.gameState == CGameState.error)
				CreateRtf("Error");
		}
		void CreatePgn(string fn)
		{
			File.WriteAllText($"History\\{fn}.pgn", formLogGames.textBox1.Text);
		}

		void CreatePgn()
		{
			List<string> list = new List<string>();
			string result = "1/2-1/2";
			if ((CData.gameState == CGameState.mate) || (CData.gameState == CGameState.time) || (CData.gameState == CGameState.error) || (CData.gameState == CGameState.resignation))
				if ((CHistory.moveList.Count & 1) > 0)
					result = "1-0";
				else
					result = "0-1";
			list.Add("");
			list.Add("[Site \"RapChessGui\"]");
			list.Add($"[Event \"{combMainMode.Text}\"]");
			list.Add($"[Date \"{DateTime.Now:yyyy.MM.dd}\"]");
			list.Add($"[Round \"{CData.gamesPlayed}\"]");
			list.Add($"[White \"{GamerList.gamers[0].player.name}\"]");
			list.Add($"[Black \"{GamerList.gamers[1].player.name}\"]");
			list.Add($"[WhiteElo \"{GamerList.gamers[0].player.elo}\"]");
			list.Add($"[BlackElo \"{GamerList.gamers[1].player.elo}\"]");
			list.Add($"[Result \"{result}\"]");
			list.Add("");
			list.Add($"{CHistory.GetPgn()} {result}");
			foreach (String s in list)
				formLogGames.textBox1.Text += $"{s}\r\n";
			formLogGames.textBox1.Select(0, 0);
			CreatePgn(combMainMode.Text);
			if (CData.gameState == CGameState.time)
				CreatePgn("Time");
			if (CData.gameState == CGameState.error)
				CreatePgn("Error");
		}

		void SetMode(CGameMode mode)
		{
			GamerList.Terminate();
			string fen = chess.GetFen();
			ComClear();
			CData.gameMode = mode;
			switch (mode)
			{
				case CGameMode.game:
					GameShow();
					break;
				case CGameMode.match:
					MatchShow();
					break;
				case CGameMode.tourB:
					break;
				case CGameMode.tourE:
					break;
				case CGameMode.training:
					TrainingShow();
					break;
				case CGameMode.edit:
					FenToInter(fen);
					break;
			}
			ComShow();
		}

		bool IsGameLong()
		{
			return !CModeGame.finished;
		}

		bool IsGameProgress()
		{
			return CData.gameState == CGameState.normal;
		}

		bool IsGameComputer()
		{
			return GamerList.GamerComputer() != null;
		}

		bool IsGameRanked()
		{
			return (cbComputer.Text == "Auto") && FormOptions.autoElo && (CData.gameMode == CGameMode.game);
		}

		void SetUnranked()
		{
			if (CModeGame.ranked == true)
			{
				CModeGame.ranked = false;
				CPlayerList.humanPlayer.elo = CPlayerList.humanPlayer.hisElo.Last().ToString();
				CModeGame.SaveToIni();
			}
			ShowAutoElo();
		}

		void ShowInfo(string info, Color color, int ip = 0, CGamer g = null)
		{
			if (ip >= GamerList.GetMsgPriority())
			{
				tssInfo.Text = info;
				tssInfo.ForeColor = color;
				if (g != null)
					g.msgPriority = ip;
			}
		}

		CGamer GamerD()
		{
			return GamerList.gamers[boardRotate ? 1 : 0];
		}

		CGamer GamerT()
		{
			return GamerList.gamers[boardRotate ? 0 : 1];
		}

		void ShowAutoElo()
		{
			labEloD.BackColor = Color.LightGray;
			labEloD.ForeColor = Color.Black;
			labEloT.BackColor = Color.LightGray;
			labEloT.ForeColor = Color.Black;
			if (IsGameRanked() && CModeGame.ranked)
			{
				if (GamerD().player.IsHuman())
				{
					labEloD.BackColor = CBoard.colorLabelB;
					labEloD.ForeColor = CBoard.colorMessage;
				}
				if (GamerT().player.IsHuman())
				{
					labEloT.BackColor = CBoard.colorLabelB;
					labEloT.ForeColor = CBoard.colorMessage;
				}
			}
		}

		bool ShowLastGame()
		{
			if (CModeGame.finished)
				return false;
			CPlayer hu = CPlayerList.humanPlayer;
			hu.NewElo(hu.GetEloLess());
			int oe = hu.hisElo.Penultimate();
			int ne = hu.hisElo.Last();
			ShowInfo($"Yours new elo is {ne} ({ne - oe})", Color.Red);
			CModeGame.SetFinished(true);
			CModeGame.SaveToIni();
			return true;
		}

		void ShowFormLastGame(string name)
		{
			FormLastGame.lastName = name;
			if (formLastGame.Visible)
				formLastGame.Focus();
			else
				formLastGame.Show(this);
		}

		void UpdateEngineList()
		{
			CData.UpdateFileEngine();
			engineList.AutoUpdate();
			Reset();
		}

		void ResetListEngine()
		{
			cbEngine.Items.Clear();
			cbMatchEngine1.Items.Clear();
			cbMatchEngine2.Items.Clear();
			cbTrainerEngine.Items.Clear();
			cbTrainedEngine.Items.Clear();
			cbEngine.Sorted = true;
			cbMatchEngine1.Sorted = true;
			cbMatchEngine2.Sorted = true;
			cbTrainerEngine.Sorted = true;
			cbTrainedEngine.Sorted = true;
			foreach (CEngine e in engineList)
				if (e.FileExists())
				{
					cbEngine.Items.Add(e.name);
					cbMatchEngine1.Items.Add(e.name);
					cbMatchEngine2.Items.Add(e.name);
					cbTrainerEngine.Items.Add(e.name);
					cbTrainedEngine.Items.Add(e.name);
				}
			cbEngine.Sorted = false;
			cbMatchEngine1.Sorted = false;
			cbMatchEngine2.Sorted = false;
			cbTrainerEngine.Sorted = false;
			cbTrainedEngine.Sorted = false;
			cbEngine.Items.Insert(0, Global.none);
			cbMatchEngine1.Items.Insert(0, Global.none);
			cbMatchEngine2.Items.Insert(0, Global.none);
			cbTrainerEngine.Items.Insert(0, Global.none);
			cbTrainedEngine.Items.Insert(0, Global.none);
			cbEngine.Text = Global.none;
			cbMatchEngine1.Text = Global.none;
			cbMatchEngine2.Text = Global.none;
			cbTrainerEngine.Text = Global.none;
			cbTrainedEngine.Text = Global.none;
		}

		void ResetListBook()
		{
			cbBook.Items.Clear();
			cbMatchBook1.Items.Clear();
			cbMatchBook2.Items.Clear();
			cbTrainerBook.Items.Clear();
			cbTrainedBook.Items.Clear();
			cbBook.Sorted = true;
			cbMatchBook1.Sorted = true;
			cbMatchBook2.Sorted = true;
			cbTrainerBook.Sorted = true;
			cbTrainedBook.Sorted = true;
			foreach (CBook b in bookList)
				if (b.FileExists())
				{
					cbBook.Items.Add(b.name);
					cbMatchBook1.Items.Add(b.name);
					cbMatchBook2.Items.Add(b.name);
					cbTrainerBook.Items.Add(b.name);
					cbTrainedBook.Items.Add(b.name);
				}
			cbBook.Sorted = false;
			cbMatchBook1.Sorted = false;
			cbMatchBook2.Sorted = false;
			cbTrainerBook.Sorted = false;
			cbTrainedBook.Sorted = false;
			cbBook.Items.Insert(0, Global.none);
			cbMatchBook1.Items.Insert(0, Global.none);
			cbMatchBook2.Items.Insert(0, Global.none);
			cbTrainerBook.Items.Insert(0, Global.none);
			cbTrainedBook.Items.Insert(0, Global.none);
			cbBook.Text = Global.none;
			cbMatchBook1.Text = Global.none;
			cbMatchBook2.Text = Global.none;
			cbTrainerBook.Text = Global.none;
			cbTrainedBook.Text = Global.none;
		}

		void Reset(bool forced = false)
		{
			CBoard.SetColor();
			BackColor = CBoard.colorChartD;
			if (!forced && !CData.reset)
				return;
			CData.reset = false;
			playerList.SaveToIni();
			ResetListEngine();
			ResetListBook();
			TournamentBReset();
			TournamentEReset();
			TournamentPReset();
			lvTourBList.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
			lvTourEList.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
			lvTourPList.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
			GameShow();
			MatchShow();
			TrainingShow();
		}

		void ShowEco()
		{
			labEco.Text = $"{CData.eco} - {CHistory.GetMovesNotation(4)}";
		}

		void ShowMoveNumber()
		{
			tssMove.Text = $"Move {chess.MoveNumber} {chess.move50} {chess.GenerateValidMoves(out _).Count}";
		}

		public bool MakeMove(string umo)
		{
			umo = umo.Trim('\0').ToLower();
			if (CData.gameState != CGameState.normal)
				return false;
			Board.arrowCur.Clear();
			CGamer cg = GamerList.GamerCur();
			cg.timer.Stop();
			double m = GamerList.curIndex == 0 ? 0.01 : -0.01;
			chartMain.Series[GamerList.curIndex].Points.Add(cg.scoreI * m);
			if (IsGameRanked() && CModeGame.ranked && (cg.engine == null) && ((chess.halfMove >> 1) == 4))
				CModeGame.SetFinished(false);
			if (!chess.IsValidMove(umo, out umo, out int emo))
			{
				SetGameState(CGameState.error, cg, umo);
				return false;
			}
			PlaySound(chess.IsCapture(emo), chess.IsCastling(emo), chess.IsCheck(emo));
			cg.MoveDone();
			string san = chess.UmoToSan(umo);
			CChess.UmoToSD(umo, out CDrag.lastSou, out CDrag.lastDes);
			Board.MakeMove(emo);
			chess.MakeMove(umo, out _, out int piece);
			CHistory.AddMove(piece, emo, umo, san);
			MoveToLvMoves(chess.halfMove - 1, CHistory.LastPiece(), cg.strScore);
			CEco eco = EcoList.GetEcoFen(chess.GetEpd());
			if (cg.player.IsHuman())
			{
				tssInfo.Text = String.Empty;
				Board.ClearArrows();
				if (eco != null)
					ShowInfo(eco.name, Color.Lime);
				else if ((continuations != String.Empty) && (!continuations.Contains(umo)))
				{
					ShowInfo("You missed the opening moves", Color.Pink);
					Board.arrowEco.AddMoves(continuations);
				}
			}
			if (cg.isWhite)
				labMemoryW.Text = cg.GetMemory();
			else
				labMemoryB.Text = cg.GetMemory();
			if (eco != null)
			{
				labEco.ForeColor = Color.Brown;
				CData.eco = eco.name;
				ShowEco();
				continuations = eco.continuations;
			}
			else
			{
				labEco.ForeColor = Color.Black;
				continuations = String.Empty;
			}
			SetGameState(chess.GetGameState());
			if (CData.gameState == CGameState.normal)
			{
				GamerList.Next();
				if (GamerList.GamerCur().player.IsHuman())
					moves = chess.GenerateValidMoves(out _);
				else
					if (GamerList.GamerCur().isWhite)
					lvMovesW.Items.Clear();
				else
					lvMovesB.Items.Clear();
			}
			SetBoardRotate();
			return true;
		}

		void SetBoardRotate()
		{
			boardRotate = (GamerList.gamers[1].player.IsHuman() && GamerList.gamers[0].player.IsComputer()) ^ CData.rotateBoard;
			if ((GamerList.gamers[1].player.IsHuman()) && (GamerList.gamers[0].player.IsHuman()))
				boardRotate = !chess.WhiteTurn;
		}

		public void RenderBoard(bool forced = false)
		{
			CGamer gt, gd;
			if (boardRotate)
			{
				gt = GamerList.gamers[0];
				gd = GamerList.gamers[1];
				labNameT.Text = gt.player.name;
				labNameD.Text = gd.player.name;
				labColorT.BackColor = Color.White;
				labColorD.BackColor = Color.Black;
				labTakenT.ForeColor = Color.White;
				labTakenD.ForeColor = Color.Black;
				labMaterialT.ForeColor = Color.White;
				labMaterialD.ForeColor = Color.Black;
			}
			else
			{
				gt = GamerList.gamers[1];
				gd = GamerList.gamers[0];
				labNameT.Text = gt.player.name;
				labNameD.Text = gd.player.name;
				labColorT.BackColor = Color.Black;
				labColorD.BackColor = Color.White;
				labTakenT.ForeColor = Color.Black;
				labTakenD.ForeColor = Color.White;
				labMaterialT.ForeColor = Color.Black;
				labMaterialD.ForeColor = Color.White;
			}
			if (CBoard.animated || CDrag.dragged || forced)
				Board.RenderBoard();
			if (CBoard.animated)
				CBoard.finished = false;
			CBoard.UpdatePosition();
			if (!CBoard.animated && !CBoard.finished)
			{
				CBoard.finished = true;
				if (!tlpPromotion.Visible)
				{
					Board.Fill();
					RenderTaken();
				}
			}
			Graphics pg = panBoard.CreateGraphics();
			Board.RenderArrows(pg);
			pg.Dispose();
		}

		void RenderTaken()
		{
			int[] arrPiece = { 0, 0, 0, 0, 0, 0, 0, 0 };
			int[] arrMaterial = { 0, 1, 3, 3, 5, 8, 0, 0 };
			int material = 0;
			for (int y = 0; y < 8; y++)
				for (int x = 0; x < 8; x++)
				{
					int piece = chess.board[y *8 + x];
					int rank = piece & 7;
					if ((piece & CChess.colorWhite) > 0)
					{
						arrPiece[rank]++;
						material += arrMaterial[rank];
					}
					if ((piece & CChess.colorBlack) > 0)
					{
						arrPiece[rank]--;
						material -= arrMaterial[rank];
					}
				}
			string w = "";
			string b = "";
			for (int n = 5; n > 0; n--)
			{
				for (int c = 0; c < arrPiece[n]; c++)
					w += " pnbrqk"[n];
				for (int c = 0; c > arrPiece[n]; c--)
					b += " pnbrqk"[n];
			}
			string mw = material.ToString();
			if (material > 0)
				mw = $"+{mw}";
			string mb = (-material).ToString();
			if (-material > 0)
				mb = $"+{mb}";
			if (boardRotate)
			{
				labTakenT.Text = w;
				labTakenD.Text = b;
				labMaterialT.Text = mw;
				labMaterialD.Text = mb;
			}
			else
			{
				labTakenT.Text = b;
				labTakenD.Text = w;
				labMaterialT.Text = mb;
				labMaterialD.Text = mw;
			}
		}

		void LoadFen(string fen)
		{
			combMainMode.SelectedIndex = 0;
			SetMode(CGameMode.game);
			if (!chess.SetFen(fen))
			{
				MessageBox.Show("Wrong fen");
				return;
			}
			CHistory.SetFen(chess.GetFen(), chess.halfMove);

			CChess.UmoToSD(CHistory.LastUmo(), out CDrag.lastSou, out CDrag.lastDes);
			Board.ClearArrows();
			Board.Fill();
			HistoryToLvMoves();
			SetingsToGamers();
			int curColor = chess.halfMove & 1;
			GamerList.curIndex = curColor;
			if (GamerList.GamerCur().player.IsComputer())
				GamerList.Rotate(curColor);

			CGamer gw = GamerList.gamers[0];
			CGamer gb = GamerList.gamers[1];
			FormLogEngines.WriteHeader(gw, gb);
			FormLogEngines.AppendTimeText($"Fen {chess.GetFen()}\n", Color.Gray);
			ShowInfo($"Load fen {chess.GetFen()}", Color.Lime);
			ShowInfo(gw);
			ShowInfo(gb);

			moves = chess.GenerateValidMoves(out _);
			CData.gameState = CGameState.normal;
			SetUnranked();
			SetGameState(chess.GetGameState());
			SetBoardRotate();
			RenderBoard(true);
		}

		void LoadFromHistory()
		{
			labEloD.BackColor = Color.LightGray;
			labEloD.ForeColor = Color.Black;
			labEloT.BackColor = Color.LightGray;
			labEloT.ForeColor = Color.Black;
			labEco.Text = String.Empty;
			labResult.Hide();
			chess.SetFen(CHistory.fen);
			foreach (CHisMove m in CHistory.moveList)
				chess.MakeMove(m.emo);
			CChess.UmoToSD(CHistory.LastUmo(), out CDrag.lastSou, out CDrag.lastDes);
			Board.ClearArrows();
			Board.Fill();
			HistoryToLvMoves();
			SetingsToGamers();
			int curColor = chess.halfMove & 1;
			GamerList.curIndex = curColor;
			if (GamerList.GamerCur().player.IsComputer())
				GamerList.Rotate(curColor);
			moves = chess.GenerateValidMoves(out _);
			CData.gameState = CGameState.normal;
			SetGameState(chess.GetGameState());
			SetBoardRotate();
			SetUnranked();
			RenderBoard(true);
		}

		void LoadPgn(string pgn)
		{
			combMainMode.SelectedIndex = 0;
			SetMode(CGameMode.game);
			string[] ml = pgn.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			chess.SetFen();
			CHistory.SetFen();
			foreach (string san in ml)
			{
				if (Char.IsDigit(san, 0))
					continue;
				string umo2 = chess.SanToUmo(san);
				string san2 = chess.UmoToSan(umo2);
				if (chess.MakeMove(umo2, out int emo, out int piece))
					CHistory.AddMove(piece, emo, umo2, san2);
				else break;
			}

			CChess.UmoToSD(CHistory.LastUmo(), out CDrag.lastSou, out CDrag.lastDes);
			Board.ClearArrows();
			Board.Fill();
			HistoryToLvMoves();
			SetingsToGamers();
			int curColor = chess.halfMove & 1;
			GamerList.curIndex = curColor;
			if (GamerList.GamerCur().player.IsComputer())
				GamerList.Rotate(curColor);

			CGamer gw = GamerList.gamers[0];
			CGamer gb = GamerList.gamers[1];
			FormLogEngines.WriteHeader(gw, gb);
			FormLogEngines.AppendTimeText($"Pgn {CHistory.GetPgn()}\n", Color.Gray);
			ShowInfo($"Load pgn {CHistory.GetPgn()}", Color.Lime);
			ShowInfo(gw);
			ShowInfo(gb);

			moves = chess.GenerateValidMoves(out _);
			CData.gameState = CGameState.normal;
			SetUnranked();
			SetGameState(chess.GetGameState());
			SetBoardRotate();
			RenderBoard(true);
		}

		private void MoveToLvMoves(int halfMove, string move, string score)
		{
			bool white = (halfMove & 1) == 0;
			if (white || (lvMoves.Items.Count == 0))
			{
				var items = lvMoves.Items;
				bool last = items.Count <= 0 || items[items.Count - 1].Selected;
				int moveNumber = (halfMove >> 1) + 1;
				string wm = "";
				string ws = "";
				string bm = "";
				string bs = "";
				if (white)
				{
					wm = move;
					ws = score;
				}
				else
				{
					bm = move;
					bs = score;
				}
				ListViewItem lvItem = new ListViewItem(new[] { moveNumber.ToString(), wm, ws, bm, bs });
				lvMoves.Items.Add(lvItem);
				if (last)
				{
					lvItem.Selected = true;
					lvItem.EnsureVisible();
				}
			}
			else
			{
				lvMoves.Items[lvMoves.Items.Count - 1].SubItems[3].Text = move;
				lvMoves.Items[lvMoves.Items.Count - 1].SubItems[4].Text = score;
			}
		}

		void HistoryToLvMoves()
		{
			lvMoves.Items.Clear();
			lvMovesW.Items.Clear();
			lvMovesB.Items.Clear();
			for (int n = 0; n < CHistory.moveList.Count; n++)
			{
				CHisMove m = CHistory.moveList[n];
				MoveToLvMoves(n, m.GetPiece(), string.Empty);
			}
		}

		void LvMovesUpdateNotation()
		{
			int line = 0;
			for (int n = 0; n < CHistory.moveList.Count; n++)
			{
				CHisMove m = CHistory.moveList[n];
				if ((n & 1) == 0)
					lvMoves.Items[line].SubItems[1].Text = m.GetPiece();
				else
					lvMoves.Items[line++].SubItems[3].Text = m.GetPiece();
			}
		}

		bool TryMove(int s, int d)
		{
			if ((s < 0) || (d < 0) || (s > 63) || (d > 63))
				return false;
			string umo = CChess.IndexToSquare(s) + CChess.IndexToSquare(d);
			if (chess.IsValidMove(umo, out _))
			{
				MakeMove(umo);
				return true;
			}
			if (chess.IsValidMove(umo + "q", out _))
			{
				CPromotion.umo = umo;
				CPromotion.sou = s;
				CPromotion.des = d;
				CBoard.MakeMove(s, d);
				Board.RenderBoard();
				RenderBoard();
				tlpPromotion.Dock = boardRotate ^ chess.WhiteTurn ? DockStyle.Bottom : DockStyle.Top;
				tlpPromotion.BackColor = chess.WhiteTurn ? Color.Black : Color.White;
				Color color = chess.WhiteTurn ? Color.White : Color.Black;
				foreach (Control ctl in tlpPromotion.Controls)
					ctl.ForeColor = color;
				tlpPromotion.Show();
				return true;
			}
			return false;
		}

		bool IsValid(int i)
		{
			foreach (int c in moves)
				if ((c & 0xff) == i)
					return true;
			return false;
		}

		bool IsValid(int sou, int des)
		{
			if (sou == des)
				return true;
			int i = (des << 8) | sou;
			foreach (int c in moves)
				if ((c & 0xffff) == i)
					return true;
			return false;
		}

		void ShowValid()
		{
			foreach (int c in moves)
			{
				int sou = c & 0xff;
				CBoard.arrField[sou].color = Color.Yellow;
			}
		}

		void ShowValid(int index)
		{
			foreach (int c in moves)
				if ((c & 0xff) == index)
				{
					int des = (c >> 8) & 0xff;
					CBoard.arrField[des].color = Color.Yellow;
				}
		}

		void SetIndex(int i)
		{
			Board.ClearColors();
			if (i == -1)
			{
				ShowValid();
			}
			else
			{
				if (i == CDrag.lastDes)
					ShowValid(i);
			}
			CDrag.lastDes = i;
			CDrag.lastSou = -1;
		}

		void LinesResize(ListView lv)
		{
			int w = 100;
			for (int n = 0; n < lv.Columns.Count - 1; n++)
				lv.Columns[n].Width = w;
			lv.Columns[lv.Columns.Count - 1].Width = lv.Width - 32 - w * (lv.Columns.Count - 1);
		}

		#endregion

		#region mode game

		void SetingsToMode()
		{
			CModeGame.color = cbColor.Text;
			CModeGame.computer = cbComputer.Text;
			CModeGame.engine = cbEngine.Text;
			CModeGame.book = cbBook.Text;
			CModeGame.modeValue.SetLevel(cbMode.Text);
			CModeGame.modeValue.SetValue((int)nudValue.Value);
			CModeGame.SaveToIni();
		}

		void ModeToSetings()
		{
			cbColor.Text = CModeGame.color;
			cbComputer.Text = CModeGame.computer;
			cbEngine.Text = CModeGame.engine;
			cbBook.Text = CModeGame.book;
			cbMode.Text = CModeGame.modeValue.GetLevel();
			nudValue.Value = CModeGame.modeValue.GetValue();
			CData.HisToPoints(CPlayerList.humanPlayer.hisElo, chartGame.Series[0].Points);
			if (cbEngine.SelectedIndex < 0)
				cbEngine.SelectedIndex = 0;
		}

		void SetingsToGamers()
		{
			GamerList.Init();
			GamerList.gamers[0].SetPlayer(CPlayerList.humanPlayer);
			CPlayer pc = new CPlayer();
			if (cbComputer.Text == Global.human)
				pc = CPlayerList.humanPlayer;
			else if (cbComputer.Text == "Custom")
			{
				pc.Engine = cbEngine.Text;
				pc.Book = cbBook.Text;
				pc.modeValue.level = CModeGame.modeValue.level;
				pc.modeValue.value = CModeGame.modeValue.value;
			}
			else
			{
				pc = playerList.GetPlayerByElo(CPlayerList.humanPlayer.Elo);
				if (FormOptions.gameBook != Global.none)
					pc.Book = FormOptions.gameBook;
			}
			GamerList.gamers[1].SetPlayer(pc);
		}

		void GameStart()
		{
			ComClear();
			CModeGame.ranked = IsGameRanked();
			SetingsToMode();
			SetingsToGamers();
			if (!GamerList.Check(out string msg))
			{
				MessageBox.Show(msg);
				return;
			}
			if (ShowLastGame())
				CModeGame.rotate = !CModeGame.rotate;
			if ((CModeGame.rotate && (cbColor.Text == "Auto")) || (cbColor.Text == "Black"))
				GamerList.Rotate(0);
			SetBoardRotate();
			RenderBoard(true);
			ShowAutoElo();
			ComShow();
		}

		void GameShow()
		{
			ModeToSetings();
			GameStart();
		}

		void GameEnd(CPlayer pw, CPlayer pl, bool isDraw)
		{
			if (CModeGame.ranked && IsGameRanked())
			{
				int eloW = pw.Elo;
				int eloL = pl.Elo;
				CElo.EloRating(eloW, eloL, out int newW, out int newL, pw.hisElo.Count, pl.hisElo.Count, isDraw);
				pw.NewElo(newW);
				pl.NewElo(newL);
				CModeGame.SetFinished(true);
			}
			ModeToSetings();
		}

		#endregion

		#region mode match

		void MatchClear()
		{
			CModeMatch.Reset();
			MatchShow();
		}

		void MatchSet()
		{
			CModeMatch.engine1 = cbMatchEngine1.Text;
			CModeMatch.engine2 = cbMatchEngine2.Text;
			CModeMatch.book1 = cbMatchBook1.Text;
			CModeMatch.book2 = cbMatchBook2.Text;
			CModeMatch.modeValue1.SetLevel(cbMode1.Text);
			CModeMatch.modeValue2.SetLevel(cbMode2.Text);
			CModeMatch.modeValue1.SetValue((int)nudValue1.Value);
			CModeMatch.modeValue2.SetValue((int)nudValue2.Value);
		}

		void MatchGet()
		{
			cbMatchEngine1.Text = CModeMatch.engine1;
			cbMatchEngine2.Text = CModeMatch.engine2;
			cbMatchBook1.Text = CModeMatch.book1;
			cbMatchBook2.Text = CModeMatch.book2;
			cbMode1.Text = CModeMatch.modeValue1.GetLevel();
			cbMode2.Text = CModeMatch.modeValue2.GetLevel();
			nudValue1.Value = CModeMatch.modeValue1.GetValue();
			nudValue2.Value = CModeMatch.modeValue2.GetValue();
			if (cbMatchEngine1.SelectedIndex < 0)
				cbMatchEngine1.SelectedIndex = 0;
			if (cbMatchEngine2.SelectedIndex < 0)
				cbMatchEngine2.SelectedIndex = 0;
		}

		void MatchShow()
		{
			MatchGet();
			CModeMatch.his.MinMaxDel(out int min, out int max);
			double last = CModeMatch.his.Last();
			labMatchGames.Text = $"Games {CModeMatch.Games} result {last} ( max +{max} ) ( min -{min} )";
			labMatch11.Text = CModeMatch.win.ToString();
			labMatch12.Text = CModeMatch.loose.ToString();
			labMatch13.Text = CModeMatch.draw.ToString();
			labMatch14.Text = $"{Math.Round(CModeMatch.Result(false))}%";
			labMatch21.Text = CModeMatch.loose.ToString();
			labMatch22.Text = CModeMatch.win.ToString();
			labMatch23.Text = CModeMatch.draw.ToString();
			labMatch24.Text = $"{Math.Round(CModeMatch.Result(true))}%";
			CData.HisToPoints(CModeMatch.his, chartMatch.Series[0].Points);
			chartMatch.ChartAreas[0].RecalculateAxesScale();
		}

		void MatchStart()
		{
			ComClear();
			MatchSet();
			SetMode(CGameMode.match);
			CPlayer p1 = new CPlayer("Player 1");
			p1.Engine = CModeMatch.engine1;
			p1.Book = CModeMatch.book1;
			p1.modeValue.level = CModeMatch.modeValue1.level;
			p1.modeValue.value = CModeMatch.modeValue1.value;
			CPlayer p2 = new CPlayer("Player 2");
			p2.Engine = CModeMatch.engine2;
			p2.Book = CModeMatch.book2;
			p2.modeValue.level = CModeMatch.modeValue2.level;
			p2.modeValue.value = CModeMatch.modeValue2.value;
			GamerList.gamers[0].SetPlayer(p1);
			GamerList.gamers[1].SetPlayer(p2);
			if (!GamerList.Check(out string msg))
			{
				MessageBox.Show(msg);
				return;
			}
			p1.elo = GamerList.gamers[0].engine.elo;
			p2.elo = GamerList.gamers[1].engine.elo;
			if (CModeMatch.Rotate)
				GamerList.Rotate(0);
			CModeMatch.GameStart();
			moves = chess.GenerateValidMoves(out _);
			ComShow();
		}

		#endregion

		#region mode torunament B

		void TournamentBUpdate(CBook b)
		{
			if (b != null)
				foreach (ListViewItem lvi in lvTourBList.Items)
					if (lvi.Text == b.name)
					{
						lvi.SubItems[1].Text = b.elo;
						lvi.SubItems[2].Text = b.GetDeltaElo().ToString();
						lvi.BackColor = b.hisElo.GetColor();
					}
		}

		void TournamentBReset()
		{
			lvTourBList.Items.Clear();
			CModeTournamentB.ListFill();
			foreach (CBook b in CModeTournamentB.bookList)
			{
				ListViewItem lvi = new ListViewItem(new[] { b.name, b.elo, b.GetDeltaElo().ToString() });
				lvi.BackColor = b.hisElo.GetColor();
				lvTourBList.Items.Add(lvi);
			}
			ListViewItem item = lvTourBList.FindItemWithText(CModeTournamentB.first);
			if (item != null)
				item.Selected = true;
		}

		void TournamentBSelect()
		{
			int del = lvTourBList.TopItem.Bounds.Top;
			foreach (ListViewItem lvi in lvTourBList.Items)
				if (lvi.Text == CModeTournamentB.first)
				{
					int c = (lvTourBList.ClientRectangle.Height - del) / lvi.Bounds.Height;
					int top = lvi.Index - (c >> 1);
					if (top < 0)
						top = 0;
					lvi.Selected = true;
					lvTourBList.TopItem = lvTourBList.Items[top];
					lvTourBList.Sort();
					lvTourBList.Focus();
					TournamentBShowHistory();
					break;
				}
		}

		void TournamentBShowHistory()
		{
			if (lvTourBList.SelectedItems.Count == 0)
				return;
			ListViewItem top2 = null;
			string name = lvTourBList.SelectedItems[0].Text;
			CBookList bookList = CModeTournamentB.bookList;
			CBook book = bookList.GetBookByName(name);
			if (book == null)
				return;
			lvTourBSel.Items.Clear();
			bookList.SortElo();
			bookList.FillPosition();
			int countGames = 0;
			int opponents = 0;
			foreach (CBook b in bookList)
			{
				int count = CModeTournamentB.tourList.CountGames(name, b.name, out int gw, out int gl, out int gd);
				if (count > 0)
				{
					opponents++;
					int pro = (gw * 200 + gd * 100) / count - 100;
					int del = book.Elo - b.Elo;
					ListViewItem lvi = new ListViewItem(new[] { b.name, del.ToString(), count.ToString(), pro.ToString() });
					if (del > 0)
						lvi.BackColor = CBoard.colorListW;
					if (del < 0)
						lvi.BackColor = CBoard.colorListB;
					if (del == 0)
						lvi.BackColor = Color.White;
					lvTourBSel.Items.Add(lvi);
					int up = (lvTourBSel.ClientRectangle.Height / lvi.Bounds.Height) >> 1;
					del = book.position - b.position;
					if (del >= up)
						top2 = lvi;
				}
				countGames += count;
			}
			string rep = book.name == CModeTournamentB.first ? $"{CModeTournamentB.repetition}/{CModeTournamentB.games}" : book.tournament.ToString();
			labBook.BackColor = book.hisElo.GetColor();
			labBook.Text = $"{book.name} games {countGames} opponents {opponents}/{bookList.Count} repetitions {rep}";
			if (top2 != null)
				lvTourBSel.TopItem = top2;
			CData.HisToPoints(book.hisElo, chartTournamentB.Series[1].Points);
			CBook bb = bookList.NextTournament(book, false, true);
			if (bb != null)
				CData.HisToPoints(bb.hisElo, chartTournamentB.Series[0].Points);
			else
				chartTournamentB.Series[0].Points.Clear();
			CBook bn = bookList.NextTournament(book, false, false);
			if (bn != null)
				CData.HisToPoints(bn.hisElo, chartTournamentB.Series[2].Points);
			else
				chartTournamentB.Series[2].Points.Clear();
		}

		void TournamentBStart()
		{
			if (engineList.Count == 0)
			{
				MessageBox.Show("No engines");
				return;
			}
			if (bookList.Count == 0)
			{
				MessageBox.Show("No books");
				return;
			}
			ComClear();
			TournamentBUpdate(CModeTournamentB.bookWin);
			TournamentBUpdate(CModeTournamentB.bookLoose);
			CModeTournamentB.modeValue.SetLevel(FormOptions.tourBMode);
			CModeTournamentB.modeValue.SetValue(FormOptions.tourBValue);
			CModeTournamentB.engine = FormOptions.tourBEngine == Global.none ? engineList.GetEngineName() : FormOptions.tourBEngine;
			CModeTournamentB.SaveToIni();
			SetMode(CGameMode.tourB);
			CBook b1 = CModeTournamentB.SelectFirst();
			CBook b2 = CModeTournamentB.SelectSecond(b1);
			CPlayer p1 = new CPlayer(b1.name);
			CPlayer p2 = new CPlayer(b2.name);
			p1.Engine = CModeTournamentB.engine;
			p2.Engine = CModeTournamentB.engine;
			p1.elo = b1.elo;
			p2.elo = b2.elo;
			p1.Book = b1.name;
			p2.Book = b2.name;
			p1.modeValue.level = CModeTournamentB.modeValue.level;
			p1.modeValue.value = CModeTournamentB.modeValue.value;
			p2.modeValue.level = CModeTournamentB.modeValue.level;
			p2.modeValue.value = CModeTournamentB.modeValue.value;
			CModeTournamentB.SetRepeition(b1, b2);
			GamerList.gamers[CModeTournamentB.rotate ? 1 : 0].SetPlayer(p1);
			GamerList.gamers[CModeTournamentB.rotate ? 0 : 1].SetPlayer(p2);
			TournamentBSelect();
			ComShow();
		}

		void TournamentBEnd(CGamer gw, CGamer gl, bool isDraw)
		{
			CBookList bookList = CModeTournamentB.bookList;
			CBook bw = bookList.GetBookByName(gw.book.name);
			CBook bl = bookList.GetBookByName(gl.book.name);
			if ((bw == null) || (bl == null))
				return;
			CPlayer pw = GamerList.gamers[0].player;
			CPlayer pb = GamerList.gamers[1].player;
			CModeTournamentB.bookWin = bw;
			CModeTournamentB.bookLoose = bl;
			bookList.SortElo();
			bookList.FillPosition();
			int eloW = bw.Elo;
			int eloL = bl.Elo;
			bool f = CModeTournamentB.first == pw.Book;
			CElo.EloRating(eloW, eloL, out int newW, out int newL, bw.hisElo.Count, bl.hisElo.Count, isDraw);
			if (isDraw)
				CModeTournamentB.tourList.Write(pw.Book, pb.Book, "d", f);
			else
			{
				if (eloW <= eloL)
					CModeTournamentB.repetition++;
				string r = gw.player == pw ? "w" : "b";
				CModeTournamentB.tourList.Write(pw.Book, pb.Book, r, f);
			}
			bw.NewElo(newW);
			bl.NewElo(newL);
			formChartB.UpdateChart();
		}

		#endregion mode tournament B

		#region mode tournament E

		void TournamentEUpdate(CEngine e)
		{
			if (e != null)
				foreach (ListViewItem lvi in lvTourEList.Items)
					if (lvi.Text == e.name)
					{
						lvi.SubItems[1].Text = e.elo;
						lvi.SubItems[2].Text = e.GetDeltaElo().ToString();
						lvi.BackColor = e.hisElo.GetColor();
					}
		}

		void TournamentEReset()
		{
			lvTourEList.Items.Clear();
			CModeTournamentE.ListFill();
			foreach (CEngine e in CModeTournamentE.engineList)
			{
				ListViewItem lvi = new ListViewItem(new[] { e.name, e.elo, e.GetDeltaElo().ToString() });
				lvi.BackColor = e.hisElo.GetColor();
				lvTourEList.Items.Add(lvi);
			}
			ListViewItem item = lvTourEList.FindItemWithText(CModeTournamentE.first);
			if (item != null)
				item.Selected = true;
		}

		void TournamentEShowHistory()
		{
			if (lvTourEList.SelectedItems.Count == 0)
				return;
			ListViewItem top2 = null;
			string name = lvTourEList.SelectedItems[0].Text;
			CEngineList engineList = CModeTournamentE.engineList;
			CEngine engine = engineList.GetEngineByName(name);
			if (engine == null)
				return;
			lvTourESel.Items.Clear();
			engineList.SortElo();
			engineList.FillPosition();
			int countGames = 0;
			int opponents = 0;
			foreach (CEngine e in engineList)
			{
				int count = CModeTournamentE.tourList.CountGames(name, e.name, out int gw, out int gl, out int gd);
				if (count > 0)
				{
					opponents++;
					int pro = (gw * 200 + gd * 100) / count - 100;
					int del = engine.Elo - e.Elo;
					ListViewItem lvi = new ListViewItem(new[] { e.name, del.ToString(), count.ToString(), pro.ToString() });
					if (del > 0)
						lvi.BackColor = CBoard.colorListW;
					if (del < 0)
						lvi.BackColor = CBoard.colorListB;
					if (del == 0)
						lvi.BackColor = Color.White;
					lvTourESel.Items.Add(lvi);
					int up = (lvTourESel.ClientRectangle.Height / lvi.Bounds.Height) >> 1;
					del = engine.position - e.position;
					if (del >= up)
						top2 = lvi;
				}
				countGames += count;
			}
			string rep = engine.name == CModeTournamentE.first ? $"{CModeTournamentE.repetition}/{CModeTournamentE.games}" : engine.tournament.ToString();
			labEngine.BackColor = engine.hisElo.GetColor();
			labEngine.Text = $"{engine.name} games {countGames} opponents {opponents}/{engineList.Count} repetitions {rep}";
			if (top2 != null)
				lvTourESel.TopItem = top2;
			CData.HisToPoints(engine.hisElo, chartTournamentE.Series[1].Points);
			CEngine eb = engineList.NextTournament(engine, false, true);
			if (eb != null)
				CData.HisToPoints(eb.hisElo, chartTournamentE.Series[0].Points);
			else
				chartTournamentE.Series[0].Points.Clear();
			CEngine en = engineList.NextTournament(engine, false, false);
			if (en != null)
				CData.HisToPoints(en.hisElo, chartTournamentE.Series[2].Points);
			else
				chartTournamentE.Series[2].Points.Clear();
		}

		void TournamentESelect()
		{
			int del = lvTourEList.TopItem.Bounds.Top;
			foreach (ListViewItem lvi in lvTourEList.Items)
				if (lvi.Text == CModeTournamentE.first)
				{
					int c = (lvTourEList.ClientRectangle.Height - del) / lvi.Bounds.Height;
					int top = lvi.Index - (c >> 1);
					if (top < 0)
						top = 0;
					lvi.Selected = true;
					lvTourEList.TopItem = lvTourEList.Items[top];
					lvTourEList.Sort();
					lvTourEList.Focus();
					TournamentEShowHistory();
					break;
				}
		}

		void TournamentEStart()
		{
			if (engineList.Count == 0)
			{
				MessageBox.Show("No engines");
				return;
			}
			ComClear();
			TournamentEUpdate(CModeTournamentE.engWin);
			TournamentEUpdate(CModeTournamentE.engLoose);
			CModeTournamentE.modeValue.SetLevel(FormOptions.tourEMode);
			CModeTournamentE.modeValue.SetValue(FormOptions.tourEValue);
			CModeTournamentE.book = FormOptions.tourEBook;
			CModeTournamentE.SaveToIni();
			SetMode(CGameMode.tourE);
			CEngine e1 = CModeTournamentE.SelectFirst();
			CEngine e2 = CModeTournamentE.SelectSecond(e1);
			CPlayer p1 = new CPlayer(e1.name);
			CPlayer p2 = new CPlayer(e2.name);
			p1.Engine = e1.name;
			p2.Engine = e2.name;
			p1.elo = e1.elo;
			p2.elo = e2.elo;
			p1.Book = CModeTournamentE.book;
			p1.modeValue.level = CModeTournamentE.modeValue.level;
			p1.modeValue.value = CModeTournamentE.modeValue.value;
			p2.Book = CModeTournamentE.book;
			p2.modeValue.level = CModeTournamentE.modeValue.level;
			p2.modeValue.value = CModeTournamentE.modeValue.value;
			CModeTournamentE.SetRepeition(e1, e2);
			GamerList.gamers[CModeTournamentE.rotate ? 1 : 0].SetPlayer(p1);
			GamerList.gamers[CModeTournamentE.rotate ? 0 : 1].SetPlayer(p2);
			TournamentEReset();
			TournamentESelect();
			ComShow();
		}

		void TournamentEEnd(CGamer gw, CGamer gl, bool isDraw)
		{
			CEngineList engList = CModeTournamentE.engineList;
			CEngine ew = engList.GetEngineByName(gw.engine.name);
			CEngine el = engList.GetEngineByName(gl.engine.name);
			if ((ew == null) || (el == null))
				return;
			CPlayer pw = GamerList.gamers[0].player;
			CPlayer pb = GamerList.gamers[1].player;
			CModeTournamentE.engWin = ew;
			CModeTournamentE.engLoose = el;
			engList.SortElo();
			engList.FillPosition();
			int eloW = ew.Elo;
			int eloL = el.Elo;
			bool f = CModeTournamentE.first == pw.Engine;
			CElo.EloRating(eloW, eloL, out int newW, out int newL, ew.hisElo.Count, el.hisElo.Count, isDraw);
			if (isDraw)
				CModeTournamentE.tourList.Write(pw.Engine, pb.Engine, "d", f);
			else
			{
				if (eloW <= eloL)
					CModeTournamentE.repetition++;
				string r = gw.player == pw ? "w" : "b";
				CModeTournamentE.tourList.Write(pw.Engine, pb.Engine, r, f);
			}
			ew.NewElo(newW);
			el.NewElo(newL);
			formChartE.UpdateChart();
		}

		#endregion

		#region mode touurnament P

		void TournamentPUpdate(CPlayer p)
		{
			if (p != null)
				foreach (ListViewItem lvi in lvTourPList.Items)
					if (lvi.Text == p.name)
					{
						lvi.SubItems[1].Text = p.elo;
						lvi.SubItems[2].Text = p.GetDeltaElo().ToString();
						lvi.BackColor = p.hisElo.GetColor();
					}
		}
		void TournamentPReset()
		{
			lvTourPList.Items.Clear();
			CModeTournamentP.ListFill();
			foreach (CPlayer p in CModeTournamentP.playerList)
			{
				ListViewItem lvi = new ListViewItem(new[] { p.name, p.elo, p.GetDeltaElo().ToString() });
				lvi.BackColor = p.hisElo.GetColor();
				lvTourPList.Items.Add(lvi);
			}
			ListViewItem item = lvTourPList.FindItemWithText(CModeTournamentP.first);
			if (item != null)
				item.Selected = true;
		}

		void TournamentPShowHistory()
		{
			if (lvTourPList.SelectedItems.Count == 0)
				return;
			ListViewItem top2 = null;
			string name = lvTourPList.SelectedItems[0].Text;
			CPlayerList playerList = CModeTournamentP.playerList;
			CPlayer player = playerList.GetPlayerByName(name);
			if (player == null)
				return;
			lvTourPSel.Items.Clear();
			playerList.SortElo();
			playerList.FillPosition();
			int countGames = 0;
			int opponents = 0;
			foreach (CPlayer p in playerList)
				if (p.Engine != Global.none)
				{
					int count = CModeTournamentP.tourList.CountGames(name, p.name, out int gw, out int gl, out int gd);
					if (count > 0)
					{
						opponents++;
						int pro = (gw * 200 + gd * 100) / count - 100;
						int del = Convert.ToInt32(player.elo) - Convert.ToInt32(p.elo);
						ListViewItem lvi = new ListViewItem(new[] { p.name, del.ToString(), count.ToString(), pro.ToString() });
						if (del > 0)
							lvi.BackColor = CBoard.colorListW;
						if (del < 0)
							lvi.BackColor = CBoard.colorListB;
						if (del == 0)
							lvi.BackColor = Color.White;
						lvTourPSel.Items.Add(lvi);
						int up = (lvTourPSel.ClientRectangle.Height / lvi.Bounds.Height) >> 1;
						del = player.position - p.position;
						if (del >= up)
							top2 = lvi;
					}
					countGames += count;
				}
			string rep = player.name == CModeTournamentP.first ? $"{CModeTournamentP.repetition}/{CModeTournamentP.games}" : player.tournament.ToString();
			labPlayer.BackColor = player.hisElo.GetColor();
			labPlayer.Text = $"{player.name} games {countGames} opponents {opponents}/{playerList.Count} repetitions {rep}";
			if (top2 != null)
				lvTourPSel.TopItem = top2;
			CData.HisToPoints(player.hisElo, chartTournamentP.Series[1].Points);
			CPlayer pb = playerList.NextTournament(player, false, true);
			if (pb != null)
				CData.HisToPoints(pb.hisElo, chartTournamentP.Series[0].Points);
			else
				chartTournamentP.Series[0].Points.Clear();
			CPlayer pn = playerList.NextTournament(player, false, false);
			if (pn != null)
				CData.HisToPoints(pn.hisElo, chartTournamentP.Series[2].Points);
			else
				chartTournamentP.Series[2].Points.Clear();
		}

		void TournamentPSelect()
		{
			int del = lvTourEList.TopItem.Bounds.Top;
			foreach (ListViewItem lvi in lvTourPList.Items)
				if (lvi.Text == CModeTournamentP.first)
				{
					int c = (lvTourPList.ClientRectangle.Height - del) / lvi.Bounds.Height;
					int top = lvi.Index - (c >> 1);
					if (top < 0)
						top = 0;
					lvi.Selected = true;
					lvTourPList.TopItem = lvTourPList.Items[top];
					lvTourPList.Sort();
					lvTourPList.Focus();
					TournamentPShowHistory();
					break;
				}
		}

		void TournamentPStart()
		{
			if (engineList.Count == 0)
			{
				MessageBox.Show("No engines");
				return;
			}
			ComClear();
			TournamentPUpdate(CModeTournamentP.plaWin);
			TournamentPUpdate(CModeTournamentP.plaLoose);
			SetMode(CGameMode.tourP);
			CPlayer p1 = CModeTournamentP.SelectFirst();
			CPlayer p2 = CModeTournamentP.SelectSecond(p1);
			CModeTournamentP.SetRepeition(p1, p2);
			GamerList.gamers[CModeTournamentP.rotate ? 1 : 0].SetPlayer(p1);
			GamerList.gamers[CModeTournamentP.rotate ? 0 : 1].SetPlayer(p2);
			TournamentPSelect();
			ComShow();
		}

		void TournamentPEnd(CPlayer pw, CPlayer pl, bool isDraw)
		{
			CPlayerList plaList = CModeTournamentP.playerList;
			pw = plaList.GetPlayerByName(pw.name);
			pl = plaList.GetPlayerByName(pl.name);
			if ((pw == null) || (pl == null))
				return;
			CPlayer plw = GamerList.gamers[0].player;
			CPlayer plb = GamerList.gamers[1].player;
			CModeTournamentP.plaWin = pw;
			CModeTournamentP.plaLoose = pl;
			plaList.SortElo();
			plaList.FillPosition();
			int eloW = pw.Elo;
			int eloL = pl.Elo;
			bool f = CModeTournamentP.first == plw.name;
			CElo.EloRating(eloW, eloL, out int newW, out int newL, pw.hisElo.Count, pl.hisElo.Count, isDraw);
			if (isDraw)
				CModeTournamentP.tourList.Write(plw.name, plb.name, "d", f);
			else
			{
				if (eloW <= eloL)
					CModeTournamentP.repetition++;
				string r = pw == plw ? "w" : "b";
				CModeTournamentP.tourList.Write(plw.name, plb.name, r, f);
			}
			pw.NewElo(newW);
			pl.NewElo(newL);
			formChartP.UpdateChart();
		}

		#endregion

		#region mode training

		void TrainingClear()
		{
			CModeTraining.Reset();
			TrainingShow();
		}

		void TrainingShow()
		{
			cbTrainerEngine.SelectedIndex = cbTrainerEngine.FindStringExact(CModeTraining.trainer);
			cbTrainedEngine.SelectedIndex = cbTrainedEngine.FindStringExact(CModeTraining.trained);
			cbTrainerMode.SelectedIndex = cbTrainerMode.FindStringExact(CModeTraining.modeValueTrainer.GetLevel());
			cbTrainedMode.SelectedIndex = cbTrainedMode.FindStringExact(CModeTraining.modeValueTrained.GetLevel());
			cbTrainerBook.SelectedIndex = cbTrainerBook.FindStringExact(CModeTraining.trainerBook);
			cbTrainedBook.SelectedIndex = cbTrainedBook.FindStringExact(CModeTraining.trainedBook);
			nudTrained.Value = CModeTraining.modeValueTrained.GetValue();
			nudTrained.Increment = CModeTraining.modeValueTrained.GetValueIncrement();
			nudTrainer.Value = CModeTraining.modeValueTrainer.GetValue();
			nudTrainer.Increment = CModeTraining.modeValueTrainer.GetValueIncrement();
			TrainingUpdate();
			CData.HisToPoints(CModeTraining.his, chartTraining.Series[0].Points);
			chartTraining.ChartAreas[0].RecalculateAxesScale();
		}

		void TrainingUpdate()
		{
			labTrainingWin2.Text = CModeTraining.win.ToString();
			labTrainingLoose2.Text = CModeTraining.loose.ToString();
			labTrainingDraw2.Text = CModeTraining.draw.ToString();
			labTrainingPro2.Text = $"{CModeTraining.Result(false)}%";
			labTrainingWin1.Text = CModeTraining.loose.ToString();
			labTrainingLoose1.Text = CModeTraining.win.ToString();
			labTrainingDraw1.Text = CModeTraining.draw.ToString();
			labTrainingPro1.Text = $"{CModeTraining.Result(true)}%";
		}

		void TrainingStart()
		{
			if ((cbTrainerEngine.SelectedIndex == 0) || (cbTrainedEngine.SelectedIndex == 0))
			{
				MessageBox.Show("Please select engine");
				return;
			}
			ComClear();
			TrainingUpdate();
			CModeTraining.trainer = cbTrainerEngine.Text;
			CModeTraining.trained = cbTrainedEngine.Text;
			CModeTraining.modeValueTrainer.SetLevel(cbTrainerMode.Text);
			CModeTraining.modeValueTrained.SetLevel(cbTrainedMode.Text);
			CModeTraining.trainerBook = cbTrainerBook.Text;
			CModeTraining.trainedBook = cbTrainedBook.Text;
			CModeTraining.modeValueTrainer.SetValue((int)nudTrainer.Value);
			CModeTraining.modeValueTrained.SetValue((int)nudTrained.Value);
			SetMode(CGameMode.training);
			CPlayer pw = new CPlayer("Trained");
			pw.Engine = CModeTraining.trained;
			pw.Book = CModeTraining.trainedBook;
			pw.modeValue.level = CModeTraining.modeValueTrained.level;
			pw.modeValue.value = CModeTraining.modeValueTrained.value;
			CPlayer pb = new CPlayer("Trainer");
			pb.Engine = CModeTraining.trainer;
			pb.Book = CModeTraining.trainerBook;
			pb.modeValue.level = CModeTraining.modeValueTrainer.level;
			pb.modeValue.value = CModeTraining.modeValueTrainer.value;
			GamerList.gamers[0].SetPlayer(pw);
			GamerList.gamers[1].SetPlayer(pb);
			pw.elo = GamerList.gamers[0].engine.elo;
			pb.elo = GamerList.gamers[1].engine.elo;
			if (CModeTraining.rotate)
				GamerList.Rotate(0);
			CModeTraining.rotate = !CModeTraining.rotate;
			ComShow();
		}

		void TrainingEnd(CGamer gw, bool isDraw)
		{
			if (CModeTraining.his.Count == 0)
				CModeTraining.his.AddValue((int)nudTrainer.Value);
			bool up = true;
			CModeTraining.games++;
			if (!isDraw)
			{
				if (gw.player.name == "Trainer")
				{
					CModeTraining.win++;
					if (++CModeTraining.winInRow > FormOptions.winLimit)
					{
						CModeTraining.winInRow = 0;
						if (--CModeTraining.modeValueTrainer.value < 1)
							CModeTraining.modeValueTrainer.value = 1;
						decimal nv = nudTrainer.Value - nudTrainer.Increment;
						if (nv < nudTrainer.Minimum)
							nv = nudTrainer.Minimum;
						nudTrainer.Value = nv;
					}
					up = false;
				}
				else
				{
					CModeTraining.loose++;
					CModeTraining.winInRow = 0;
					CModeTraining.modeValueTrainer.value++;
				}
			}
			else
			{
				CModeTraining.draw++;
				CModeTraining.winInRow = 0;
				CModeTraining.modeValueTrainer.value++;
			}
			if (up)
				nudTrainer.Value += nudTrainer.Increment;
			CModeTraining.his.AddValue(Convert.ToInt32(nudTrainer.Value));
			CModeTraining.SaveToIni();
		}

		#endregion training

		#region mode edit

		void FenToInter(string fen = CChess.defFen)
		{
			PrepareFen(fen);
			List<RadioButton> list = gbToMove.Controls.OfType<RadioButton>().ToList();
			int i = chess.WhiteTurn ? 1 : 0;
			list[i].Select();
			int cr = chess.castleRighs;
			clbCastling.SetItemChecked(0, (chess.castleRighs & 1) > 0);
			clbCastling.SetItemChecked(1, (chess.castleRighs & 2) > 0);
			clbCastling.SetItemChecked(2, (chess.castleRighs & 4) > 0);
			clbCastling.SetItemChecked(3, (chess.castleRighs & 8) > 0);
			chess.castleRighs = cr;
			cbPassant.Text = chess.Passant;
			nudMove.Value = chess.MoveNumber;
			nudReversible.Value = chess.move50;
			EditGetFen();
			RenderBoard();
		}

		void EditGetFen()
		{
			tbFen.Text = chess.GetFen();
		}


		string EditSelected
		{
			get
			{
				foreach (Control c in tlpEdit.Controls)
				{
					Label l = c as Label;
					if (l.BackColor == Color.Yellow)
						return l.Text;
				}
				return String.Empty;
			}
			set
			{
				foreach (Control c in tlpEdit.Controls)
				{
					Label l = c as Label;
					if (l.Text == value)
						l.BackColor = Color.Yellow;
					else
						l.BackColor = Color.Silver;
				}
			}
		}

		#endregion

		#region show

		private void booksToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (formChartB.Visible)
				formChartB.Focus();
			else
				formChartB.Show(this);
		}

		private void enginesToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (formChartE.Visible)
				formChartE.Focus();
			else
				formChartE.Show(this);
		}

		private void playersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (formChartP.Visible)
				formChartP.Focus();
			else
				formChartP.Show(this);
		}

		private void programLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (formLogProgram.Visible)
				formLogProgram.Focus();
			else
				formLogProgram.Show(this);
		}

		private void gamesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (formLogGames.Visible)
				formLogGames.Focus();
			else
				formLogGames.Show(this);
		}

		private void enginesToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (formLogEngines.Visible)
				formLogEngines.Focus();
			else
				formLogEngines.Show(this);
		}

		private void lastGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowFormLastGame("game");
		}

		private void lastMatchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowFormLastGame("match");
		}

		private void lasstTournamentenginesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowFormLastGame("tournament-engines");
		}

		private void lastTournamentplayersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowFormLastGame("tournament-players");
		}

		private void lastTrainingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowFormLastGame("training");
		}

		private void lastErrorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			labError.Hide();
			ShowFormLastGame("error");
		}

		private void booksToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ShowFormBook();
		}

		private void playersToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			formPlayer.ShowDialog(this);
			Reset();
		}

		private void enginesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowFormEngine();
		}

		private void labError_Click(object sender, EventArgs e)
		{
			labError.Hide();
			ShowFormLastGame("error");
		}

		#endregion

		#region events

		private void FormChess_FormClosing(object sender, FormClosingEventArgs e)
		{
			IniSave();
			GamerList.Terminate();
			FormEditEngine.processOptions.Terminate();
			FormLogEngines.process.Terminate();
		}

		private void ButStart_Click(object sender, EventArgs e)
		{
			GameStart();
		}

		private void ButStop_Click(object sender, EventArgs e)
		{
			GamerList.GamerCur().EngineStop();
		}

		private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormOptions.page = Convert.ToInt32(tabControl1.SelectedTab.Tag);
			formOptions.ShowDialog(this);
			toolTip1.Active = FormOptions.showTips;
			CBoard.SetColor();
			CBoard.ClearAttack();
			CBoard.animated = true;
			Board.arrowCur.Clear();
			Board.arrowEco.Clear();
			ShowAutoElo();
			ShowEco();
			LvMovesUpdateNotation();
			BoardPrepare();
			RenderBoard();
		}

		private void bStartTraining_Click(object sender, EventArgs e)
		{
			CModeTraining.SaveToIni();
			TrainingStart();
		}

		private void bStartMatch_Click(object sender, EventArgs e)
		{

			CModeMatch.SaveToIni();
			MatchStart();
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			CDrag.mouseX = e.X;
			CDrag.mouseY = e.Y;
			Board.GetFieldXY(e.X, e.Y, out int x, out int y);
			if (boardRotate)
			{
				x = 7 - x;
				y = 7 - y;
			}
			CDrag.mouseIndex = y * 8 + x;
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (tlpPromotion.Visible)
				return;
			if (CData.gameMode == CGameMode.edit)
			{
				int i = CDrag.mouseIndex;
				if (e.Button == MouseButtons.Left)
					chess.board[i] = chess.CharToPiece(EditSelected[0]);
				else
					chess.board[i] = CChess.colorEmpty;
				Board.Fill();
				RenderBoard(true);
				EditGetFen();
			}
			if (CData.gameMode == (int)CGameMode.game)
			{
				if (e.Button == MouseButtons.Right)
				{
					CField f = CBoard.arrField[CDrag.mouseIndex];
					f.circle = !f.circle;
					return;
				}
				if (GamerList.GamerCur().engine != null)
					return;
				if (IsValid(CDrag.mouseIndex))
				{
					CDrag.last = CDrag.lastDes;
					CDrag.dragged = true;
					SetIndex(CDrag.mouseIndex);
				}
				else
					if (!IsValid(CDrag.lastDes))
					SetIndex(-1);
				if (!IsValid(CDrag.lastDes, CDrag.mouseIndex))
					SetIndex(-1);
			}
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			if (tlpPromotion.Visible)
				return;
			if (CData.gameMode == (int)CGameMode.game)
			{
				if (CDrag.lastDes == CDrag.mouseIndex)
					TryMove(CDrag.last, CDrag.mouseIndex);
				else
					TryMove(CDrag.lastDes, CDrag.mouseIndex);
				CDrag.dragged = false;
				CBoard.animated = true;
			}
		}

		private void butClearBoard_Click(object sender, EventArgs e)
		{
			for (int n = 0; n < 64; n++)
			{
				chess.board[n] = CChess.colorEmpty;
				CBoard.UpdateField(n);
			}
			RenderBoard(true);
		}

		private void rbColorChanged(object sender, EventArgs e)
		{
			var checkedButton = gbToMove.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
			List<RadioButton> list = gbToMove.Controls.OfType<RadioButton>().ToList();
			int wt = list.IndexOf(checkedButton) == 1 ? 0 : 1;
			chess.halfMove = ((chess.MoveNumber - 1) << 1) + wt;
			boardRotate = !chess.WhiteTurn;
			Board.Fill();
			RenderBoard(true);
			EditGetFen();
		}

		private void butContinueGame_Click(object sender, EventArgs e)
		{
			string fen = chess.GetFen();
			SetingsToMode();
			LoadFen(fen);
			ShowGamers();
		}

		private void clbCastling_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			switch (e.Index)
			{
				case 0:
					chess.castleRighs ^= 1;
					break;
				case 1:
					chess.castleRighs ^= 2;
					break;
				case 2:
					chess.castleRighs ^= 4;
					break;
				case 3:
					chess.castleRighs ^= 8;
					break;
			}
			EditGetFen();
		}

		private void butDefault_Click(object sender, EventArgs e)
		{
			FenToInter();
		}

		private void cbComputer_SelectedValueChanged(object sender, EventArgs e)
		{
			CModeGame.ranked = cbComputer.Text == "Auto";
			ShowAutoElo();
			butNewGame.Focus();
		}

		private void panBoard_Resize(object sender, EventArgs e)
		{
			panBoard.Invalidate();
			BoardPrepare();
		}

		private void lvLines_Resize(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			int w = 100;
			for (int n = 0; n < lv.Columns.Count - 1; n++)
				lv.Columns[n].Width = w;
			lv.Columns[lv.Columns.Count - 1].Width = lv.Width - w * (lv.Columns.Count - 1);
			ShowScrollBar(lv.Handle, 0, false);
		}

		private void lvMoves_Resize(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			int w = lv.Width - 32;
			w = Convert.ToInt32(w / 9);
			lv.Columns[0].Width = w;
			lv.Columns[1].Width = w * 2;
			lv.Columns[2].Width = w * 2;
			lv.Columns[3].Width = w * 2;
			lv.Columns[4].Width = w * 2;
			ShowScrollBar(lv.Handle, 0, false);
		}

		private void panBoard_Paint(object sender, PaintEventArgs e)
		{
			RenderBoard();
		}

		private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeGame.modeValue.SetLevel(cbMode.Text);
			nudValue.Increment = CModeGame.modeValue.GetValueIncrement();
			nudValue.Minimum = nudValue.Increment;
			nudValue.Value = CModeGame.modeValue.GetValue();
			toolTip1.SetToolTip(nudValue, CModeGame.modeValue.GetTip());
		}

		private void cbMode1_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeMatch.modeValue1.SetLevel(cbMode1.Text);
			nudValue1.Increment = CModeMatch.modeValue1.GetValueIncrement();
			nudValue1.Minimum = nudValue1.Increment;
			nudValue1.Value = CModeMatch.modeValue1.GetValue();
			toolTip1.SetToolTip(nudValue1, CModeMatch.modeValue1.GetTip());
		}

		private void cbMode2_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeMatch.modeValue2.SetLevel(cbMode2.Text);
			nudValue2.Increment = CModeMatch.modeValue2.GetValueIncrement();
			nudValue2.Minimum = nudValue2.Increment;
			nudValue2.Value = CModeMatch.modeValue2.GetValue();
			toolTip1.SetToolTip(nudValue2, CModeMatch.modeValue2.GetTip());
		}

		private void cbTrainedMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeTraining.modeValueTrained.SetLevel(cbTrainedMode.Text);
			nudTrained.Increment = CModeTraining.modeValueTrained.GetValueIncrement();
			nudTrained.Minimum = nudTrained.Increment;
			nudTrained.Value = CModeTraining.modeValueTrained.GetValue();
			toolTip1.SetToolTip(nudTrained, CModeTraining.modeValueTrained.GetTip());
		}

		private void cbTeacherMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeTraining.modeValueTrainer.SetLevel(cbTrainerMode.Text);
			nudTrainer.Increment = CModeTraining.modeValueTrainer.GetValueIncrement();
			nudTrainer.Minimum = nudTrainer.Increment;
			nudTrainer.Value = Math.Max(CModeTraining.modeValueTrainer.GetValue(), nudTrainer.Minimum);
			toolTip1.SetToolTip(nudTrainer, CModeTraining.modeValueTrainer.GetTip());
		}

		private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowAutoElo();
		}

		private void cbMainMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			mode = combMainMode.Text;
			CData.Clear();
			FormLogGames.This.textBox1.Text = String.Empty;
			tabControl1.SelectedIndex = combMainMode.SelectedIndex;
			Board.Fill();
			RenderBoard();
			SetMode((CGameMode)combMainMode.SelectedIndex);
		}

		private void butResignation_Click(object sender, EventArgs e)
		{
			if (!IsGameRanked() || !IsGameLong() || !IsGameProgress() || !IsGameComputer())
				CModeGame.ranked = false;
			SetGameState(CGameState.resignation);
		}

		private void butStartTournamentB_Click(object sender, EventArgs e)
		{
			CModeTournamentB.NewGame();
			TournamentBStart();
		}

		private void butStartTournamentE_Click(object sender, EventArgs e)
		{
			CModeTournamentE.NewGame();
			TournamentEStart();
		}

		private void butStartTournamentP_Click(object sender, EventArgs e)
		{
			CModeTournamentP.NewGame();
			TournamentPStart();
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetMode((CGameMode)tabControl1.SelectedIndex);
		}

		private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			ListView lv = sender as ListView;
			lv.Tag = lv.Tag == null ? new Object() : null;
			(sender as ListView).ListViewItemSorter = new ListViewComparer(e.Column, lv.Tag == null ? SortOrder.Ascending : SortOrder.Descending);
		}

		private void butForward_Click(object sender, EventArgs e)
		{
			SetUnranked();
			GamerList.Rotate(GamerList.curIndex);
			ShowGamers();
		}

		private void labPromoQ_Click(object sender, EventArgs e)
		{
			CBoard.MakeMove(CPromotion.des, CPromotion.sou);
			MakeMove(CPromotion.umo + (sender as Label).Text);
			tlpPromotion.Hide();
		}

		private void FormChess_Resize(object sender, EventArgs e)
		{
			lvMoves_Resize(lvMoves, null);
			LinesResize(lvMovesW);
			LinesResize(lvMovesB);
			SplitLoadFromIni();
			MakeBoardSquare();
		}

		private void lvEngine_Resize(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			int w = lv.Width - 32;
			w = Convert.ToInt32(w / 4);
			if (lv.Columns.Count > 0)
			{
				lv.Columns[0].Width = w * 2;
				lv.Columns[1].Width = w;
				lv.Columns[2].Width = w;
			}
		}

		private void lvEngineH_Resize(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			int w = lv.Width - 32;
			w = Convert.ToInt32(w / 6);
			if (lv.Columns.Count > 0)
			{
				lv.Columns[0].Width = w * 3;
				lv.Columns[1].Width = w;
				lv.Columns[2].Width = w;
				lv.Columns[3].Width = w;
			}
		}

		private void lvPlayer_SelectedIndexChanged(object sender, EventArgs e)
		{
			TournamentPShowHistory();
		}

		private void butEditStart_Click(object sender, EventArgs e)
		{
			LoadFen(chess.GetFen());
		}

		private void labEngine_Click(object sender, EventArgs e)
		{
			TournamentESelect();
		}

		private void labPlayer_Click(object sender, EventArgs e)
		{
			TournamentPSelect();
		}

		private void timerAnimation_Tick(object sender, EventArgs e)
		{
			GameLoop();
		}

		private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
		{
			UpdateEngineList();
		}

		private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
		{
			UpdateEngineList();
		}

		private void splitContainerBoard_Panel1_Resize(object sender, EventArgs e)
		{
			SquareBoard();
		}

		private void butBackward_Click(object sender, EventArgs e)
		{
			if (CHistory.Back(1))
				LoadFromHistory();
			ShowGamers();
		}

		private void lvMoves_Click(object sender, EventArgs e)
		{
			if ((CData.gameMode != CGameMode.game) || (lvMoves.SelectedItems.Count == 0))
				return;
			int index = lvMoves.SelectedItems[0].Index;
			if (CHistory.BackTo(index, GamerList.GamerHuman().isWhite))
				LoadFromHistory();
		}

		private void labBook_Click(object sender, EventArgs e)
		{
			TournamentBSelect();
		}

		private void cbTourBMode_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void lvEngine_SelectedIndexChanged(object sender, EventArgs e)
		{
			TournamentEShowHistory();
		}

		private void lvTourBList_SelectedIndexChanged(object sender, EventArgs e)
		{
			TournamentBShowHistory();
		}

		private void lastTournamentbooksToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowFormLastGame("tournament-books");
		}

		private void splitContainerMain_SplitterMoved(object sender, SplitterEventArgs e)
		{
			MakeBoardSquare();
		}

		private void FormChes_Shown(object sender, EventArgs e)
		{
			UpdateEngineList();
		}

		private void cbComputer_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool v = (sender as ComboBox).SelectedIndex == 1;
			nudValue.Visible = v;
			cbMode.Visible = v;
			cbBook.Visible = v;
			cbEngine.Visible = v;
			v = (sender as ComboBox).SelectedIndex != 2;
			butForward.Visible = v;
			butStop.Visible = v;
		}

		private void menuClipboardLoadFen_Click(object sender, EventArgs e)
		{
			string fen = Clipboard.GetText().Trim();
			if (CData.gameMode == CGameMode.edit)
				EditSelected = fen;
			else
				LoadFen(fen);
		}

		private void fenToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(chess.GetFen());
		}

		private void pgnToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			LoadPgn(Clipboard.GetText().Trim());
		}

		private void pgnToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(CHistory.GetPgn());
		}

		private void uciToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadPgn(Clipboard.GetText().Trim());
		}

		private void uciToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(CHistory.GetUci());
		}

		private void button2_Click(object sender, EventArgs e)
		{
			FenToInter(tbFen.Text);
		}

		private void nudMove_ValueChanged(object sender, EventArgs e)
		{
			int wt = chess.WhiteTurn ? 0 : 1;
			chess.halfMove = (((int)nudMove.Value - 1) << 1) + wt;
			EditGetFen();
		}

		private void nudReversible_ValueChanged(object sender, EventArgs e)
		{
			chess.move50 = (int)nudReversible.Value;
			EditGetFen();
		}

		private void cbPassant_SelectedIndexChanged(object sender, EventArgs e)
		{
			chess.Passant = cbPassant.Text;
			EditGetFen();
		}

		private void editLabel_Click(object sender, EventArgs e)
		{
			EditSelected = (sender as Label).Text;
		}
		private void BookClick(object sender, EventArgs e)
		{
			ShowFormBook((sender as Label).Text);
		}

		private void EngineClick(object sender, EventArgs e)
		{
			ShowFormEngine((sender as Label).Text);
		}

		private void PlayerClick(object sender, EventArgs e)
		{
			ShowFormPlayer((sender as Label).Text);
		}

		private void chartMatch_Click(object sender, EventArgs e)
		{
			MatchClear();
		}

		private void chartTraining_Click(object sender, EventArgs e)
		{
			TrainingClear();
		}

		private void enginesToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			formListE.ShowDialog(this);
		}

		private void booksToolStripMenuItem2_Click_1(object sender, EventArgs e)
		{
			formListB.ShowDialog(this);
		}

		private void playersToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			formListP.ShowDialog(this);
		}
	}
}

#endregion
