using NSChess;
using NSUci;
using RapIni;
using RapLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Management;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RapChessGui
{


    public partial class FormChess : Form
    {
        #region variable

        bool analysis = false;

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        [DllImport("user32")]
        private static extern bool ShowScrollBar(IntPtr hwnd, int wBar, [MarshalAs(UnmanagedType.Bool)] bool bShow);

        public const int WM_GAME_NEXT = 1024;
        public static IntPtr handle;
        public static FormChess This;
        public static string mode = "Game";
        public static CRapIni ini = new CRapIni(@"Ini\rapchessgui.ini");
        public static CReaderList readerList = new CReaderList();
        public CBoard board = new CBoard();
        readonly CEcoList ecoList = new CEcoList();
        readonly CUci uci = new CUci();
        public static CChess chess = new CChess();
        readonly SoundPlayer audioMove = new SoundPlayer(Properties.Resources.Move);
        readonly SoundPlayer audioCapture = new SoundPlayer(Properties.Resources.Capture);
        readonly SoundPlayer audioCastling = new SoundPlayer(Properties.Resources.Castling);
        readonly SoundPlayer audioCheck = new SoundPlayer(Properties.Resources.Check);
        public static CRapLog log = new CRapLog(@"Log\RapChessGui.log");
        public static PrivateFontCollection pfc = new PrivateFontCollection();
        public static CListBook bookList = new CListBook();
        public static CListEngine engineList = new CListEngine();
        public static CListPlayer playerList = new CListPlayer();
        public static CModeTournamentB tourB = new CModeTournamentB();
        public static CModeTournamentE tourE = new CModeTournamentE();
        public static CModeTournamentP tourP = new CModeTournamentP();
        public static readonly CHistory history = new CHistory();
        readonly FormAbout formAbout = new FormAbout();
        readonly static FormLog formLog = new FormLog();
        readonly FormLogGames formLogGames = new FormLogGames();
        readonly FormLogEngines formLogEngines = new FormLogEngines();
        readonly FormLastGame formLastGame = new FormLastGame();
        readonly public static FormOptions formOptions = new FormOptions();
        readonly FormChartB formChartB = new FormChartB();
        readonly FormChartP formChartP = new FormChartP();
        readonly FormChartE formChartE = new FormChartE();
        readonly FormListB formListB = new FormListB();
        readonly FormListE formListE = new FormListE();
        readonly FormListP formListP = new FormListP();
        public readonly FormEditEngine formEditEngine = new FormEditEngine();
        readonly FormEditBook formBook = new FormEditBook();
        readonly FormEditPlayer formPlayer = new FormEditPlayer();
        public static CGamers gamers = new CGamers();
        readonly CEloAcc eloAcc = new CEloAcc();
        readonly CTeacher teacher = new CTeacher();
        readonly MistakeList mistakeList = new MistakeList();

        #endregion variable

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
            CreateDir(@"Engines\Auto");
            CreateDir("History");
            CreateDir("Ini");
            CreateDir("Log");
            CreateDir("Saves");
            CData.UpdateBookReader();
            CData.UpdateFolderEngine();
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
            Reset();
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
            cbApply.SelectedIndex = 0;
            cbGameMode.SelectedIndex = 0;
            timerAnimation.Enabled = true;
            EditSelected = "P";
        }

        private void KillChildrens(int id)
        {
            ManagementObjectSearcher processSearcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + id);
            ManagementObjectCollection processCollection = processSearcher.Get();
            if (processCollection != null)
            {
                foreach (ManagementObject mo in processCollection.Cast<ManagementObject>())
                {
                    try
                    {
                        id = Convert.ToInt32(mo["ProcessID"]);
                        Process proc = Process.GetProcessById(id);
                        if (!proc.HasExited)
                        {
                            proc.Kill();
                            KillChildrens(id);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Add(ex.Message);
                    }
                }
            }
        }

        void CreateDir(string dir)
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        void IniSave()
        {
            bool maximized = WindowState == FormWindowState.Maximized;
            int width = maximized ? RestoreBounds.Width : Width;
            int height = maximized ? RestoreBounds.Height : Height;
            int x = maximized ? RestoreBounds.X : Location.X;
            int y = maximized ? RestoreBounds.Y : Location.Y;
            ini.Write("position>maximized", maximized);
            ini.Write("position>width", width);
            ini.Write("position>height", height);
            ini.Write("position>x", x);
            ini.Write("position>y", y);
            ini.Write("openDialog", openFileDialog1.FilterIndex);
            ini.Write("saveDialog", saveFileDialog1.FilterIndex);
            SplitSaveToIni();
            CListBook.iniFile.Save();
            CListEngine.iniFile.Save();
            CListPlayer.iniFile.Save();
            CReaderList.iniFile.Save();
            CModeEdit.SaveToIni(ini);
            CModeGame.SaveToIni(ini);
            CModeMatch.SaveToIni();
            ini.Save();
        }

        void IniLoad()
        {
            Width = ini.ReadInt("position>width", Width);
            Height = ini.ReadInt("position>height", Height);
            if (Width < 600)
                Width = 600;
            if (Height < 600)
                Height = 600;
            int x = ini.ReadInt("position>x", Location.X);
            int y = ini.ReadInt("position>y", Location.Y);
            if (x < 0)
                x = 0;
            if (y < 0)
                y = 0;
            Location = new Point(x, y);
            if (ini.ReadBool("position>maximized", false))
                WindowState = FormWindowState.Maximized;
            openFileDialog1.FilterIndex = ini.ReadInt("openDialog", 1);
            saveFileDialog1.FilterIndex = ini.ReadInt("saveDialog", 1);
            SplitLoadFromIni();
            readerList.LoadFromIni();
            bookList.LoadFromIni();
            bookList.Update();
            engineList.LoadFromIni();
            playerList.LoadFromIni();
            ResetEngines();
            ResetBooks();
            formOptions.LoadFromIni();
            CModeEdit.LoadFromIni(ini);
            CModeGame.LoadFromIni(ini);
            CModeMatch.LoadFromIni();
            CModeTraining.LoadFromIni();
        }

        void SplitSaveToIni(SplitContainer sc)
        {
            int size = sc.Orientation == Orientation.Horizontal ? sc.Size.Height : sc.Size.Width;
            double p = (double)sc.SplitterDistance / size;
            ini.Write($"position>split>{sc.Name}", p);
        }

        void SplitLoadFromIni(SplitContainer sc)
        {
            int size = sc.Orientation == Orientation.Horizontal ? sc.Size.Height : sc.Size.Width;
            double o = (double)sc.SplitterDistance / size;
            double p = ini.ReadDouble($"position>split>{sc.Name}", o);
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

        void SetFen(string fen)
        {
            if (!chess.SetFen(fen))
            {
                chess.SetFen();
                MessageBox.Show("Wrong fen");
            }
            cbGameMode.SelectedIndex = (int)CGameMode.edit;
            CModeEdit.fen = fen;
            EditShow();
        }

        void SetPgn(string pgn)
        {
            cbGameMode.SelectedIndex = (int)CGameMode.edit;
            string[] ml = pgn.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            chess.SetFen();
            history.SetFen();
            foreach (string san in ml)
            {
                if (Char.IsDigit(san, 0))
                    continue;
                string umo2 = chess.SanToUmo(san);
                string san2 = chess.UmoToSan(umo2);
                if (chess.MakeMove(umo2, out int emo, out int piece))
                    history.AddMove(chess.GetFen(), piece, emo, umo2, san2, string.Empty, string.Empty);
                else break;
            }
            CChess.UmoToSD(history.LastUmo(), out CDrag.lastSou, out CDrag.lastDes);
            board.ClearArrows();
            board.Fill();
            HistoryToLvMovesExt();
        }

        void LoadPgn(string fileName)
        {
            cbGameMode.SelectedIndex = (int)CGameMode.edit;
            int number = 0;
            string[] lines = File.ReadAllLines(fileName);
            string w = "white";
            string b = "black";
            string pv = string.Empty;
            lvPgn.Items.Clear();
            foreach (string line in lines)
            {
                string[] words = line.Split();
                if (words.Length < 2)
                    continue;
                string word = words[0].ToLower();
                if (word == "[white")
                    w = words[1].Trim(new Char[] { '"', ']' });
                if (word == "[black")
                    b = words[1].Trim(new Char[] { '"', ']' });
                if (word == "1.")
                {
                    ListViewItem lvItem = new ListViewItem(new[] { (++number).ToString(), w, b, line });
                    lvPgn.Items.Add(lvItem);
                    w = "white";
                    b = "black";
                }
            }
        }

        private void LoadFen(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line = reader.ReadToEnd();
                SetFen(line);
            }
        }

        private void LoadUci(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line = reader.ReadToEnd();
                SetFen(line);
            }
        }

        void SetHistory()
        {
            HistoryToChess();
            HistoryToLvMovesExt();
            board.ClearArrows();
            board.Fill();
            board.StartAnimation();
            RenderBoard(true);
        }

        private void LoadHis(string fileName)
        {
            cbGameMode.SelectedIndex = (int)CGameMode.edit;
            history.LoadFromFile(fileName);
            SetHistory();
        }

        void ShowFormBook(string bookName = "")
        {
            FormEditBook.bookName = bookName;
            formBook.ShowDialog(this);
            Reset();
        }

        void ShowFormEngine(string engineName = "")
        {
            FormEditEngine.engineName = engineName;
            formEditEngine.ShowDialog(this);
            Reset();
        }

        void ShowFormPlayer(string playerName = "")
        {
            FormEditPlayer.playerName = playerName;
            formPlayer.ShowDialog(this);
            Reset();
        }

        public static void ShowFormLog(string text, string path, Form form)
        {
            FormLog.text = text;
            FormLog.path = path;
            formLog.ShowDialog(form);
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
            foreach (CGamer gamer in gamers)
            {
                List<string> messages = gamer.GetMessages();
                int index = messages.Count - 32;
                if (index < 0 || CData.gameMode == CGameMode.edit)
                    index = 0;
                for (int n = index; n < messages.Count; n++)
                {
                    string msg = messages[n];
                    FormLogEngines.SetMessage(gamer, msg);
                    if (gamer.IsBookActive() || (gamer.engine.protocol == CProtocol.uci))
                        ExecuteMessageUci(gamer, msg);
                    else
                        ExecuteMessageXb(gamer, msg);
                }
            }
            if (board.animated || CDrag.dragged)
                RenderBoard();
            else if (CData.gameState == CGameState.normal)
            {
                if (CData.gameMode != CGameMode.edit)
                    gamers.GamerCur().TryStart();
                ShowInfo(gamers.GamerCur());
                ShowInfo(gamers.GamerSec());
            }
            if (CData.gameMode == CGameMode.game)
                if (teacher.IsStarted())
                {
                    CDataT dt = teacher.GetTData();
                    if (dt.done)
                    {
                        CHis h = history[teacher.index];
                        dt.started = false;
                        teacher.SetTData(dt);
                        if (teacher.firstPhase)
                        {
                            h.pvBst = dt.pv;
                            teacher.move = dt.move;
                            teacher.cp = dt.cp;
                            teacher.mate = dt.mate;
                            if (h.umo == dt.move)
                                h.pv = "perfect";
                            else
                                teacher.Start(h.umo);
                        }
                        else
                        {
                            double wc1 = CEloAcc.WiningChances(teacher.cp, teacher.mate);
                            double wc2 = CEloAcc.WiningChances(dt.cp, dt.mate);
                            double loss = wc1 - wc2;
                            if (loss >= 30)
                            {
                                h.pv = "blunder";
                                CModeGame.blunder++;
                            }
                            else if (loss >= 20)
                            {
                                CModeGame.mistake++;
                                h.pv = "mistake";
                            }
                            else if (loss >= 10)
                            {
                                CModeGame.inaccuracy++;
                                h.pv = "inaccuracy";
                            }
                            else if (loss >= 1)
                                h.pv = "good";
                            else if (loss > 0)
                                h.pv = "very good";
                            else h.pv = "perfect";
                            h.pvCur = dt.pv;
                            if (loss >= 20)
                                mistakeList.AddEpd(teacher.fen, teacher.depth, teacher.move, teacher.cp, teacher.mate);
                            CModeGame.accuracyC++;
                            CModeGame.accuracyS += CEloAcc.GetAccuracy(wc1, wc2);
                            labAccuracy.Text = CModeGame.Info();
                        }
                        if (dt.mate > 0)
                            h.score = $"+{dt.mate}M";
                        else if (dt.mate < 0)
                            h.score = $"{dt.mate}M";
                        else
                            h.score = dt.cp.ToString();
                        HistoryToLvMoves();
                    }
                }
                else
                {
                    for (int n = 0; n < history.Count; n++)
                    {
                        CHis h = history[n];
                        string fen = n > 0 ? history[n - 1].fen : history.fen;
                        if (string.IsNullOrEmpty(h.score) && string.IsNullOrEmpty(h.pv))
                        {
                            teacher.index = n;
                            teacher.Start(fen, (int)formOptions.nudTeacherDepth.Value);
                            break;
                        }
                    }
                }
        }

        void ComClear()
        {
            Text = CGames.Text;
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
            if (CData.gameMode != CGameMode.edit)
                lvMoves.Items.Clear();
            lvMovesW.Items.Clear();
            lvMovesB.Items.Clear();
            string fen = (cbGameMode.Text == cbApply.Text) || (CData.gameMode == CGameMode.edit) ? CModeEdit.fen : CChess.defFen;
            PrepareFen(fen);
            gamers.InitNewGame();
            gamers.Terminate();
            AnalysisStop();
        }

        void ComShow(bool wait = false)
        {
            CGamer gw = gamers.GamerWhite();
            CGamer gb = gamers.GamerBlack();
            ShowGamers();
            ShowInfo(gw);
            ShowInfo(gb);
            SetBoardRotate();
            SetGameState(wait ? CGameState.wait : CGameState.normal);
            RenderTaken();
        }

        public void SetColor()
        {
            labPlayerW.BackColor = Colors.labelB;
            labPlayerB.BackColor = Colors.labelB;
            labEngineW.BackColor = Colors.labelB;
            labEngineB.BackColor = Colors.labelB;
            labBookNW.BackColor = Colors.labelB;
            labBookNB.BackColor = Colors.labelB;
            labModeW.BackColor = Colors.labelB;
            labModeB.BackColor = Colors.labelB;
            labProtocolW.BackColor = Colors.labelB;
            labProtocolB.BackColor = Colors.labelB;
            labMemoryW.BackColor = Colors.labelB;
            labMemoryB.BackColor = Colors.labelB;
            labScoreW.BackColor = Colors.labelW;
            labScoreB.BackColor = Colors.labelW;
            labDepthW.BackColor = Colors.labelW;
            labDepthB.BackColor = Colors.labelW;
            labNodesW.BackColor = Colors.labelW;
            labNodesB.BackColor = Colors.labelW;
            labNpsW.BackColor = Colors.labelW;
            labNpsB.BackColor = Colors.labelW;
            labBookCW.BackColor = Colors.labelW;
            labBookCB.BackColor = Colors.labelW;
            chartMain.PaletteCustomColors[0] = Colors.chartM;
            chartMain.PaletteCustomColors[1] = Colors.chartD;
            chartGame.PaletteCustomColors[0] = Colors.chartD;
            chartMatch.PaletteCustomColors[0] = Colors.chartD;
            chartTournamentB.PaletteCustomColors[0] = Colors.chartM;
            chartTournamentB.PaletteCustomColors[1] = Colors.chartD;
            chartTournamentB.PaletteCustomColors[2] = Colors.chartL;
            chartTournamentE.PaletteCustomColors[0] = Colors.chartM;
            chartTournamentE.PaletteCustomColors[1] = Colors.chartD;
            chartTournamentE.PaletteCustomColors[2] = Colors.chartL;
            chartTournamentP.PaletteCustomColors[0] = Colors.chartM;
            chartTournamentP.PaletteCustomColors[1] = Colors.chartD;
            chartTournamentP.PaletteCustomColors[2] = Colors.chartL;
            BackColor = Colors.chartD;
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
            history.SetFen(chess.GetFen());
            board.ClearArrows();
            board.ClearColors();
            board.Fill();
        }

        void ShowGamers()
        {
            CGamer gw = gamers.GamerWhite();
            CGamer gb = gamers.GamerBlack();
            labPlayerW.Text = gw.GetPlayerName();
            labPlayerB.Text = gb.GetPlayerName();
            labEngineW.Text = gw.GetEngineName();
            labEngineB.Text = gb.GetEngineName();
            labBookNW.Text = gw.GetBookName();
            labBookNB.Text = gb.GetBookName();
            labModeW.Text = gw.GetMode();
            labModeB.Text = gb.GetMode();
            labProtocolW.Text = gw.GetProtocol();
            labProtocolB.Text = gb.GetProtocol();
            labMemoryW.Text = gw.gamerEngine.GetMemory();
            labMemoryB.Text = gb.gamerEngine.GetMemory();
            splitContainerMoves.Panel1Collapsed = gw.player.IsHuman();
            splitContainerMoves.Panel2Collapsed = gb.player.IsHuman();
            Bitmap bmpW = gw.GetBitmap(panWhite.Height, out int ww);
            Bitmap bmpB = gb.GetBitmap(panBlack.Height, out int wb);
            pictureBoxW.Width = ww;
            pictureBoxB.Width = wb;
            pictureBoxW.Image = bmpW;
            pictureBoxB.Image = bmpB;
            if (CData.gameMode == CGameMode.edit)
            {
                Color cw = gw.arrowColor;
                Color cb = gb.arrowColor;
                labWhite.BackColor = Color.FromArgb(255, cw.R, cw.G, cw.B);
                labBlack.BackColor = Color.FromArgb(255, cb.R, cb.G, cb.B);
            }
            else
            {
                labWhite.BackColor = Color.White;
                labBlack.BackColor = Color.Black;
            }
        }

        void ShowInfo(CGamer g)
        {
            if (g.IsWhite())
            {
                labScoreW.Text = $"Score {g.strScore}";
                labDepthW.Text = $"Depth {g.DepthAvg():N2}";
                labNodesW.Text = $"Nodes {g.nodes:N0}";
                labNpsW.Text = $"Nps {g.GetNpsAvg():N0}";
                labBookCW.Text = $"Book {g.countMovesBook}";
                labColW.BackColor = g.GetScoreColor();
                labProtocolW.Text = g.eval == 0 ? g.GetProtocol() : $"Evaluation {g.eval}";
                pbHashW.Value = g.Hash;
            }
            else
            {
                labScoreB.Text = $"Score {g.strScore}";
                labDepthB.Text = $"Depth {g.DepthAvg():N2}";
                labNodesB.Text = $"Nodes {g.nodes:N0}";
                labNpsB.Text = $"Nps {g.GetNpsAvg():N0}";
                labBookCB.Text = $"Book {g.countMovesBook}";
                labColB.BackColor = g.GetScoreColor();
                labProtocolB.Text = g.eval == 0 ? g.GetProtocol() : $"Evaluation {g.eval}";
                pbHashB.Value = g.Hash;
            }
            if (board.rotate ^ g.IsWhite())
            {
                if (CData.gameState == CGameState.normal)
                {
                    labTimeD.Text = g.GetTime(out bool low);
                    if ((g.timer.IsRunning) || (CData.gameState != CGameState.normal))
                    {
                        labTimeD.BackColor = low ? Colors.red : Colors.labelB;
                        labTimeD.ForeColor = Colors.message;
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
                        labTimeT.BackColor = low ? Colors.red : Colors.labelB;
                        labTimeT.ForeColor = Colors.message;
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
            if ((gs == CGameState.wait) || (gs == CGameState.normal))
            {
                CData.gameState = gs;
                return;
            }
            if (CData.gameState != CGameState.normal)
                return;
            CData.gameState = gs;
            CGamer gw = gamers.GamerWinner();
            CGamer gl = gamers.GamerLoser();
            if (gamer == gw)
            {
                gw = gl;
                gl = gamer;
            }
            CPlayer pw = gw.player;
            CPlayer pl = gl.player;
            CColor winColor = gw.IsWhite() ? CColor.white : CColor.black;
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
                    CGames.time++;
                    infoMsg = $"{pl.name} time out";
                    infoCol = Color.Red;
                    log.Add($"Time out {pl.name} {chess.GetFen()}");
                    FormLogEngines.AppendText($"Time out {pl.name}\n", Color.Red);
                    break;
                case CGameState.error:
                    CGames.error++;
                    labError.Show();
                    infoMsg = $"{pl.name} make wrong move";
                    infoCol = Color.Red;
                    log.Add($"Wrong move {pl.name} ({umo}) {chess.GetFen()}");
                    FormLogEngines.AppendText($"Wrong move: ({umo})\n", Color.Red);
                    FormLogEngines.AppendText($"Fen: {chess.GetFen()}\n", Color.Black);
                    break;
            }
            CGamer gWhi = gamers.GamerWhite();
            CGamer gBla = gamers.GamerBlack();
            FormLogEngines.AppendTimeText($" Fen {chess.GetFen()}\n", Color.Olive);
            FormLogEngines.AppendTimeText($" White: {gWhi.player.name}\n", Color.DimGray);
            FormLogEngines.AppendTimeText($" Engine: {gWhi.GetEngineName()}\n", Color.DimGray);
            FormLogEngines.AppendTimeText($" Clock: {gWhi.GetTime(out _)} Book: {gWhi.countMovesBook} Engine: {gWhi.countMovesEngine}\n", Color.DimGray);
            FormLogEngines.AppendTimeText($" Black: {gBla.player.name}\n", Color.Black);
            FormLogEngines.AppendTimeText($" Engine: {gBla.GetEngineName()}\n", Color.Black);
            FormLogEngines.AppendTimeText($" Clock: {gBla.GetTime(out _)} Book: {gBla.countMovesBook} Engine: {gBla.countMovesEngine}\n", Color.Black);
            FormLogEngines.AppendTimeText($" Finish {infoMsg}\n", Color.Olive);
            if (winColor == CColor.none)
                CGames.draw++;
            CGames.played++;
            CreateRtf();
            CreatePgn();
            CreateHis();
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
            CPlayer hu = gamers.GetHuman();
            if ((hu != null) && (CModeGame.ranked))
            {
                string elo = hu.hisElo.Change().ToString("+#;-#;0");
                elo = $"elo {hu.StrElo} ({elo})";
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
            if (gw.IsComputer())
                gw.player.engine.AddGame(false, false);
            if (gl.IsComputer())
                gl.player.engine.AddGame(CData.gameState == CGameState.error, CData.gameState == CGameState.time);
        }

        public void BoardPrepare()
        {
            SetColor();
            SetBoardRotate();
            board.Resize(panBoard.Width, panBoard.Height);
            RenderBoard();
        }

        void AddLines(CGamer g)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(g.infMs);
            ListViewItem lvi = new ListViewItem(new[] { ts.ToString(@"mm\:ss\.ff"), g.strScore, $"{g.depth}/{g.seldepth}", g.nodes.ToString("N0"), g.nps.ToString("N0"), g.pv });
            ListView lv = g.IsWhite() ? lvMovesW : lvMovesB;
            if ((lv.Items.Count & 1) > 0)
                lvi.BackColor = Colors.message;
            lv.Items.Insert(0, lvi);
        }

        void AddLinesMulti(CGamer g)
        {
            int multi = g.multipv;
            if (multi < 1)
                multi = 1;
            ListView lv = g.IsWhite() ? lvMovesW : lvMovesB;
            if (multi > lv.Items.Count + 1)
                multi = lv.Items.Count + 1;
            if (multi > lv.Items.Count)
            {
                ListViewItem lvi = new ListViewItem(new[] { $"{multi}.", g.strScore, $"{g.depth}/{g.seldepth}", g.nodes.ToString("N0"), g.nps.ToString("N0"), g.pv });
                if ((multi & 1) > 0)
                    lvi.BackColor = Colors.message;
                lv.Items.Add(lvi);
            }
            else
            {
                lv.Items[multi - 1].SubItems[1].Text = g.strScore;
                lv.Items[multi - 1].SubItems[2].Text = $"{g.depth}/{g.seldepth}";
                lv.Items[multi - 1].SubItems[3].Text = g.nodes.ToString("N0");
                lv.Items[multi - 1].SubItems[4].Text = g.nps.ToString("N0");
                lv.Items[multi - 1].SubItems[5].Text = g.pv;
            }

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
                    if ((moves.Count == 0) && (g.multipv < 2))
                    {
                        g.lastMove = umo;
                        board.arrows.AddMoves(umo, g.arrowColor,g.arrowShift);
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
            ShowInfo(pv, Color.Gainsboro, 0, g);
            if (CData.gameMode == CGameMode.edit && (nudMultiPV.Value > 1))
                AddLinesMulti(g);
            else
                AddLines(g);
        }

        public void ExecuteMessageUci(CGamer g, string msg)
        {
            string s;
            uci.SetMsg(msg);
            switch (uci.command)
            {
                case "uciok":
                    g.uciOk = true;
                    break;
                case "readyok":
                    g.readyOk = true;
                    break;
                case "eval":
                    if (uci.GetValue("eval", out s))
                        int.TryParse(s, out g.eval);
                    break;
                case "enginemove":
                    g.gamerBook.isBookFail = true;
                    break;
                case "bestmove":
                    g.timer.Stop();
                    if (gamers.GamerCur() == g)
                    {
                        uci.GetValue("bestmove", out string umo);
                        uci.GetValue("ponder", out g.ponder);
                        if (g.IsBookMove())
                        {
                            g.pv = "book";
                            ShowInfo($"book {umo}", Color.Aquamarine, 0, g);
                            if ((g.engine != null) && (g.engine.protocol == CProtocol.winboard))
                                g.gamerEngine.isPositionXb = false;
                        }
                        if (CData.gameMode != CGameMode.edit)
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
                    ulong nps = 0;
                    if (uci.GetValue("hashfull", out s))
                    {
                        int hash = Int32.Parse(s);
                        if ((hash < 0) || (hash > 1000))
                            log.Add($"{g.player.name} ({g.player.EngineName}) wrong hashfull");
                        g.Hash = hash;
                    }
                    if (uci.GetValue("cp", out s))
                    {
                        g.strScore = s;
                        int.TryParse(s, out g.scoreI);
                    }
                    if (uci.GetValue("mate", out s))
                    {
                        if (g.IsEngineActive())
                            g.mate = true;
                        int.TryParse(s, out int ip);
                        if (ip > 0)
                        {
                            g.strScore = $"+{s}M";
                            g.scoreI = 0xfffd - ip;
                        }
                        else if (ip < 0)
                        {
                            g.strScore = $"{s}M";
                            g.scoreI = -0xfffd + ip;
                        }
                    }
                    if (uci.GetValue("depth", out s))
                        int.TryParse(s, out g.depth);
                    if (uci.GetValue("multipv", out s))
                        int.TryParse(s, out g.multipv);
                    if (uci.GetValue("nodes", out s))
                    {
                        ulong.TryParse(s, out g.nodes);
                    }
                    if (uci.GetValue("nps", out s))
                    {
                        ulong.TryParse(s, out g.nps);
                        nps = g.nps;
                    }
                    if (uci.GetValue("time", out s))
                        if (ulong.TryParse(s, out g.infMs))
                            if ((nps == 0) && (g.infMs > 0))
                                nps = g.infMs > 0 ? (g.nodes * 1000) / g.infMs : 0;
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

        public void ExecuteMessageXb(CGamer g, string msg)
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
                        else if (GetMoveXb(uci.Last(), out umo))
                            MakeMove(umo);
                    }
                    else if (s.Contains("resign") || s.Contains("illegal"))
                        SetGameState(CGameState.resignation, g);
                    else if (g.gamerEngine.isPreparedUci && Char.IsDigit(uci.tokens[0][0]) && (uci.tokens.Length > 4))
                    {
                        try
                        {
                            if (!int.TryParse(uci.tokens[0], out g.depth))
                                break;
                            g.strScore = uci.tokens[1];
                            int.TryParse(uci.tokens[1], out g.scoreI);
                            if (!double.TryParse(uci.tokens[2], out double time))
                                break;
                            g.infMs = (ulong)Convert.ToInt64(time * 10);
                            if (!ulong.TryParse(uci.tokens[3], out g.nodes))
                                break;
                            ulong nps = g.infMs > 0 ? (g.nodes * 1000) / g.infMs : 0;
                            if (nps > 0)
                                g.nps = nps;
                            SetPv(4, g);
                        }
                        catch
                        {
                            log.Add($"{g.player.name} ({g.player.EngineName}) ({msg})");
                        }
                    }
                    break;
            }
        }

        void CreateRtf(string fn)
        {
            FormLogEngines.Save($"History\\{fn}.rtf");
        }

        void CreateRtf()
        {
            CreateRtf(cbGameMode.Text);
            if (CData.gameState == CGameState.time)
                CreateRtf("Time");
            if (CData.gameState == CGameState.error)
                CreateRtf("Error");
        }

        void CreateHis()
        {
            history.SaveToFile($@"History\{cbGameMode.Text}.his");
        }

        void CreatePgn(string fn, List<string> sl = null)
        {
            if (sl == null)
                File.WriteAllText($@"History\{fn}.pgn", formLogGames.textBox.Text);
            else
                File.WriteAllLines($@"History\{fn}.pgn", sl);
        }

        void CreatePgn()
        {
            List<string> list = new List<string>();
            string result = "1/2-1/2";
            if ((CData.gameState == CGameState.mate) || (CData.gameState == CGameState.time) || (CData.gameState == CGameState.error) || (CData.gameState == CGameState.resignation))
                if ((history.Count & 1) > 0)
                    result = "1-0";
                else
                    result = "0-1";
            list.Add("");
            list.Add("[Site \"RapChessGui\"]");
            list.Add($"[Event \"{cbGameMode.Text}\"]");
            list.Add($"[Date \"{DateTime.Now:yyyy.MM.dd}\"]");
            list.Add($"[Round \"{CGames.played}\"]");
            list.Add($"[White \"{gamers.GamerWhite().player.name}\"]");
            list.Add($"[Black \"{gamers.GamerBlack().player.name}\"]");
            list.Add($"[WhiteElo \"{gamers.GamerWhite().player.StrElo}\"]");
            list.Add($"[BlackElo \"{gamers.GamerBlack().player.StrElo}\"]");
            list.Add($"[Result \"{result}\"]");
            list.Add("");
            list.Add($"{history.GetPgn()} {result}");
            foreach (String s in list)
                formLogGames.textBox.Text += $"{s}\r\n";
            formLogGames.textBox.Select(0, 0);
            CreatePgn(cbGameMode.Text);
            if (CData.gameState == CGameState.time)
                CreatePgn("Time");
            if (CData.gameState == CGameState.error)
                CreatePgn("Error", list);
        }

        void SetMode(CGameMode mode)
        {
            ComClear();
            CData.gameMode = mode;
            tabControl2.SelectedIndex = mode == CGameMode.edit ? 1 : 0;
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
                case CGameMode.tourP:
                    break;
                case CGameMode.training:
                    TrainingShow();
                    break;
                case CGameMode.edit:
                    EditShow();
                    break;
            }
            ComShow(mode != CGameMode.game);
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
            return gamers.GamerComputer() != null;
        }

        bool IsGameRanked()
        {
            return (formOptions.cbGameOpponent.Text == "Auto") && FormOptions.autoElo && (CData.gameMode == CGameMode.game);
        }

        void SetUnranked()
        {
            if (CModeGame.ranked == true)
            {
                CModeGame.ranked = false;
                CListPlayer.humanPlayer.elo = CListPlayer.humanPlayer.hisElo.Last();
                CModeGame.SaveToIni(ini);
            }
            ShowAutoElo();
        }

        void ShowInfo(string info, Color color, int ip = 0, CGamer g = null)
        {
            if (ip >= gamers.GetMsgPriority())
            {
                tssInfo.Text = info;
                tssInfo.ForeColor = color;
                if (g != null)
                    g.msgPriority = ip;
            }
        }

        CGamer GamerD()
        {
            return board.rotate ? gamers.GamerBlack() : gamers.GamerWhite();
        }

        CGamer GamerT()
        {
            return board.rotate ? gamers.GamerWhite() : gamers.GamerBlack();
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
                    labEloD.BackColor = Colors.labelB;
                    labEloD.ForeColor = Colors.message;
                }
                if (GamerT().player.IsHuman())
                {
                    labEloT.BackColor = Colors.labelB;
                    labEloT.ForeColor = Colors.message;
                }
            }
        }

        bool ShowLastGame()
        {
            if (CModeGame.finished)
                return false;
            CPlayer hu = CListPlayer.humanPlayer;
            hu.NewElo(hu.GetEloLess());
            int oe = hu.hisElo.Penultimate();
            int ne = hu.hisElo.Last();
            ShowInfo($"Yours new elo is {ne} ({ne - oe})", Color.Red);
            CModeGame.finished = true;
            CModeGame.rotate = !CModeGame.rotate;
            CModeGame.SaveToIni(ini);
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
            if (!formEditEngine.formAutodetect.Visible)
            {
                engineList.AutoUpdate();
                if (engineList.GetEngineAuto() != null)
                    ShowFormEngine();
            }
        }

        void ResetEngines()
        {
            cbTrainerEngine.Items.Clear();
            cbTrainedEngine.Items.Clear();
            cbEditEngine1.Items.Clear();
            cbEditEngine2.Items.Clear();
            cbTrainerEngine.Sorted = true;
            cbTrainedEngine.Sorted = true;
            cbEditEngine1.Sorted = true;
            cbEditEngine2.Sorted = true;
            foreach (CEngine e in engineList)
                if (e.FileExists())
                {
                    cbTrainerEngine.Items.Add(e.name);
                    cbTrainedEngine.Items.Add(e.name);
                    if (e.modeInfinite && e.modeFen && (e.protocol == CProtocol.uci))
                    {
                        cbEditEngine1.Items.Add(e.name);
                        cbEditEngine2.Items.Add(e.name);
                    }
                }
            cbTrainerEngine.Sorted = false;
            cbTrainedEngine.Sorted = false;
            cbEditEngine1.Sorted = false;
            cbEditEngine2.Sorted = false;
            cbTrainerEngine.Items.Insert(0, Global.none);
            cbTrainedEngine.Items.Insert(0, Global.none);
            cbEditEngine1.Items.Insert(0, Global.none);
            cbEditEngine2.Items.Insert(0, Global.none);
            cbTrainerEngine.Text = Global.none;
            cbTrainedEngine.Text = Global.none;
            cbEditEngine1.Text = Global.none;
            cbEditEngine2.Text = Global.none;
        }

        void ResetBooks()
        {
            cbTrainerBook.Items.Clear();
            cbTrainedBook.Items.Clear();
            cbTrainerBook.Sorted = true;
            cbTrainedBook.Sorted = true;
            foreach (CBook b in bookList)
                if (b.FileExists())
                {
                    cbTrainerBook.Items.Add(b.name);
                    cbTrainedBook.Items.Add(b.name);
                }
            cbTrainerBook.Sorted = false;
            cbTrainedBook.Sorted = false;
            cbTrainerBook.Items.Insert(0, Global.none);
            cbTrainedBook.Items.Insert(0, Global.none);
            cbTrainerBook.Text = Global.none;
            cbTrainedBook.Text = Global.none;
        }

        void Reset()
        {
            BackColor = Colors.chartD;
            ResetEngines();
            ResetBooks();
            formOptions.Reset();
            formOptions.LoadFromIni();
            playerList.SaveToIni();
            TournamentBReset();
            TournamentEReset();
            TournamentPReset();
            lvTourBList.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
            lvTourEList.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
            lvTourPList.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
            GameModeToSettings();
            switch (CData.gameMode)
            {
                case CGameMode.match:
                    MatchShow();
                    break;
                case CGameMode.training:
                    TrainingShow();
                    break;
            }
            eloAcc.Start();
        }

        void ShowEco()
        {
            labEco.Text = $"{CData.eco} - {history.GetMovesNotation(4)}";
        }

        void ShowMoveNumber()
        {
            tssMove.Text = $"Move {chess.MoveNumber} {chess.move50} {chess.GenerateLegalMoves(out _).Count}";
        }

        public bool MakeMove(string move)
        {
            move = move.Trim('\0').ToLower();
            if (CData.gameState != CGameState.normal)
                return false;
            board.arrows.Clear();
            CGamer gc = gamers.GamerCur();
            gc.timer.Stop();
            double m = gamers.WhiteTurn ? 0.01 : -0.01;
            chartMain.Series[gamers.WhiteTurn ? 0 : 1].Points.Add(gc.scoreI * m);
            if (gc.IsHuman())
            {
                if (IsGameRanked() && CModeGame.ranked && ((chess.halfMove >> 1) == 4))
                {
                    CModeGame.finished = false;
                    CModeGame.SaveToIni(ini);
                }
            }
            if (!chess.IsValidMove(move, out string umo, out string san, out int emo))
            {
                SetGameState(CGameState.error, gc, move);
                return false;
            }
            PlaySound(chess.MoveIsCapture(emo), chess.MoveIsCastling(emo), chess.IsCheck(emo));
            gc.MoveDone();
            CChess.UmoToSD(umo, out CDrag.lastSou, out CDrag.lastDes);
            int pieceType = chess.GetPieceType(emo);
            CEco ecoOld = ecoList.EpdToEco(chess.GetEpd());
            string continuations = ecoOld == null ? String.Empty : ecoOld.continuations;
            board.MakeMove(emo);
            chess.MakeMove(emo);
            CHis hm = history.AddMove(chess.GetFen(), pieceType, emo, umo, san, string.Empty, gc.pv);
            CEco eco = ecoList.EpdToEco(chess.GetEpd());
            if (gc.player.IsHuman())
            {
                tssInfo.Text = String.Empty;
                board.ClearArrows();
                if (eco != null)
                {
                    ShowInfo(eco.name, Color.Lime);
                    hm.pv = eco.name;
                }
                else if (!string.IsNullOrEmpty(continuations))
                    if (continuations.Contains(umo))
                        hm.pv = "book";
                    else
                    {
                        gc.gamerBook.isBookFail = true;
                        hm.pv = "inaccuracy";
                        hm.pvBst = continuations;
                    }
            }
            else
                hm.score = gc.strScore;
            HistoryToLvMoves(history.Last());
            if (gc.IsWhite())
                labMemoryW.Text = gc.gamerEngine.GetMemory();
            else
                labMemoryB.Text = gc.gamerEngine.GetMemory();
            if (eco != null)
            {
                labEco.ForeColor = Color.Brown;
                CData.eco = eco.name;
                ShowEco();
            }
            else
                labEco.ForeColor = Color.Black;
            SetGameState(chess.GetGameState());
            if (CData.gameState == CGameState.normal)
            {
                gamers.WhiteTurn = !chess.WhiteTurn;
                gamers.Next();
                if (gamers.GamerCur().IsWhite())
                    lvMovesW.Items.Clear();
                else
                    lvMovesB.Items.Clear();
            }
            if (formOptions.cbGameRotate.Checked)
                SetBoardRotate();
            board.StartAnimation();
            return true;
        }

        void SetBoardRotate()
        {
            board.rotate = false;
            if (CData.gameMode == CGameMode.game)
            {
                CGamer gc = gamers.GamerCur();
                CGamer gs = gamers.GamerSec();
                CGamer gh = gc.IsHuman() ? gc : gs;
                board.rotate = gh.IsBlack();
                if (formOptions.cbBottomPlayer.SelectedIndex == 1)
                    board.rotate = false;
                if (formOptions.cbBottomPlayer.SelectedIndex == 2)
                    board.rotate = true;
            }
        }

        public void RenderBoard(bool forced = false)
        {
            CGamer gt, gd;
            if (board.rotate)
            {
                gt = gamers.GamerWhite();
                gd = gamers.GamerBlack();
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
                gt = gamers.GamerBlack();
                gd = gamers.GamerWhite();
                labNameT.Text = gt.player.name;
                labNameD.Text = gd.player.name;
                labColorT.BackColor = Color.Black;
                labColorD.BackColor = Color.White;
                labTakenT.ForeColor = Color.Black;
                labTakenD.ForeColor = Color.White;
                labMaterialT.ForeColor = Color.Black;
                labMaterialD.ForeColor = Color.White;
            }
            if (board.animated)
                board.done = false;
            if (board.animated)
                board.Animate();
            if (board.animated || CDrag.dragged || forced)
                board.Render();
            if (!board.animated && !board.done)
            {
                board.done = true;
                if (!tlpPromotion.Visible)
                {
                    board.Fill();
                    RenderTaken();
                }
            }
            Graphics pg = panBoard.CreateGraphics();
            board.RenderArrows(pg);
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
                    int piece = chess.board[y * 8 + x];
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
            string w = String.Empty;
            string b = String.Empty;
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
            if (board.rotate)
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

        void LoadFromHistory()
        {
            labEloD.BackColor = Color.LightGray;
            labEloD.ForeColor = Color.Black;
            labEloT.BackColor = Color.LightGray;
            labEloT.ForeColor = Color.Black;
            labEco.Text = String.Empty;
            labResult.Hide();
            chess.SetFen(history.fen);
            foreach (CHis m in history)
                chess.MakeMove(m.emo);
            chess.SetFen(chess.GetFen());
            CChess.UmoToSD(history.LastUmo(), out CDrag.lastSou, out CDrag.lastDes);
            board.ClearArrows();
            board.Fill();
            HistoryToLvMovesExt();
            GameModeToGamers();
            gamers.InitNewGame();
            gamers.WhiteTurn = chess.WhiteTurn;
            if (gamers.GamerCur().player.IsComputer())
                gamers.Rotate();
            CData.gameState = CGameState.normal;
            SetGameState(chess.GetGameState());
            SetBoardRotate();
            SetUnranked();
            board.StartAnimation();
            RenderBoard(true);
        }

        private void MoveToLvMoves(int halfMove, string move, string score, string pv)
        {
            bool white = (halfMove & 1) == 0;
            int moveNumber = (halfMove >> 1) + 1;
            string number = white ? $"{moveNumber}." : " ";
            ListViewItem lvItem = new ListViewItem(new[] { $"{number}{move}", score, pv });
            var items = lvMoves.Items;
            bool last = items.Count <= 0 || items[items.Count - 1].Selected;
            lvMoves.Items.Add(lvItem);
            if (last)
            {
                lvItem.Selected = true;
                lvItem.EnsureVisible();
            }
        }

        void HistoryToLvMoves()
        {
            lvMoves.Items.Clear();
            lvMoves.ItemSelectionChanged -= lvMoves_ItemSelectionChanged;
            foreach (CHis hm in history)
                HistoryToLvMoves(hm);
            lvMoves.ItemSelectionChanged += lvMoves_ItemSelectionChanged;
        }

        void HistoryToLvMovesExt()
        {
            lvMovesW.Items.Clear();
            lvMovesB.Items.Clear();
            HistoryToLvMoves();
        }

        void HistoryToLvMoves(CHis hm)
        {
            MoveToLvMoves(hm.GetHalfMove() - 1, hm.GetPiece(), hm.score, hm.pv);
        }

        void HistoryToChess()
        {
            chess.SetFen(history.fen);
            chess.MakeMoves(history.GetMovesUci());
        }

        bool TryMoveHuman(int s, int d)
        {
            if ((s < 0) || (d < 0) || (s > 63) || (d > 63))
                return false;
            string umo = CChess.IndexToSquare(s) + CChess.IndexToSquare(d);
            if (chess.IsValidMove(umo, out _))
            {
                if (lvMoves.SelectedItems.Count > 0)
                {
                    int index = lvMoves.SelectedItems[0].Index;
                    if (index < lvMoves.Items.Count - 1)
                    {
                        history.SetLength(index + 1);
                        HistoryToLvMovesExt();
                        HistoryToChess();
                        SetUnranked();
                    }
                }
                CData.gameState = CGameState.normal;
                MakeMove(umo);
                return true;
            }
            if (chess.IsValidMove(umo + "q", out _))
            {
                CPromotion.umo = umo;
                CPromotion.sou = s;
                CPromotion.des = d;
                board.MakeMove(s, d);
                RenderBoard();
                tlpPromotion.Dock = board.rotate ^ chess.WhiteTurn ? DockStyle.Bottom : DockStyle.Top;
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
            List<int> moves = chess.GenerateLegalMoves(out _);
            foreach (int c in moves)
                if ((c & 0xff) == i)
                    return true;
            return false;
        }

        bool IsValid(int sou, int des)
        {
            List<int> moves = chess.GenerateLegalMoves(out _);
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
            board.ClearColors();
            List<int> moves = chess.GenerateLegalMoves(out _);
            foreach (int c in moves)
            {
                int sou = c & 0xff;
                board.arrField[sou].color = CBoard.Yellow;
            }
        }

        void ShowValid(int index)
        {
            board.ClearColors();
            List<int> moves = chess.GenerateLegalMoves(out _);
            foreach (int c in moves)
                if ((c & 0xff) == index)
                {
                    int des = (c >> 8) & 0xff;
                    board.arrField[des].color =  CBoard.Yellow;
                }
        }

        void SetIndex(int i)
        {
            if (i == -1)
            {
                ShowValid();
            }
            else
            {
                if (i == CDrag.lastDes)
                {
                    ShowValid(i);
                }
            }
            CDrag.lastDes = i;
            CDrag.lastSou = -1;
            RenderBoard(true);
        }

        void LinesResize(System.Windows.Forms.ListView lv)
        {
            int w = 100;
            for (int n = 0; n < lv.Columns.Count - 1; n++)
                lv.Columns[n].Width = w;
            lv.Columns[lv.Columns.Count - 1].Width = lv.Width - 32 - w * (lv.Columns.Count - 1);
        }

        #endregion

        #region mode game

        void SettingsToGameMode()
        {
            CModeGame.color = formOptions.cbGameColor.Text;
            CModeGame.engine = formOptions.cbCustomEngine.Text;
            CModeGame.book = formOptions.cbCustomBook.Text;
            CModeGame.modeValue.SetLevel(formOptions.cbCustomMode.Text);
            CModeGame.modeValue.SetValue((int)formOptions.nudCustomValue.Value);
            CModeGame.ranked = IsGameRanked();
            if (CModeGame.color == "White")
                CModeGame.rotate = false;
            if (CModeGame.color == "Black")
                CModeGame.rotate = true;
            CModeGame.SaveToIni(ini);
        }

        void GameModeToSettings()
        {
            formOptions.cbGameColor.Text = CModeGame.color;
            formOptions.cbCustomEngine.Text = CModeGame.engine;
            formOptions.cbCustomBook.Text = CModeGame.book;
            formOptions.cbCustomMode.Text = CModeGame.modeValue.GetLevel();
            formOptions.nudCustomValue.Value = CModeGame.modeValue.GetValue();
            CData.HisToPoints(CListPlayer.humanPlayer.hisElo, chartGame.Series[0].Points);
            if (formOptions.cbCustomEngine.SelectedIndex < 0)
                formOptions.cbCustomEngine.SelectedIndex = 0;
        }

        void GameModeToGamers()
        {
            CListPlayer.humanPlayer.elo = CModeGame.ranked ? CListPlayer.humanPlayer.hisElo.Last() : FormOptions.userElo;
            CPlayer pc = new CPlayer();
            if (formOptions.cbGameOpponent.Text == Global.human)
                pc = CListPlayer.humanPlayer;
            else if (formOptions.cbGameOpponent.Text == "Custom")
            {
                pc.EngineName = formOptions.cbCustomEngine.Text;
                pc.BookName = formOptions.cbCustomBook.Text;
                pc.levelValue.level = CModeGame.modeValue.level;
                pc.levelValue.baseVal = CModeGame.modeValue.baseVal;
                pc.elo = CListPlayer.humanPlayer.elo;
            }
            else
                if (formOptions.cbGameEngine.Text != Global.none)
            {
                pc.EngineName = formOptions.cbGameEngine.Text;
                pc.BookName = formOptions.cbGameBook.Text;
                pc.levelValue.level = CLevel.time;
                pc.levelValue.baseVal = 10;
                pc.elo = CListPlayer.humanPlayer.elo;
                pc.humanElo = true;
            }
            else
            {
                pc = playerList.GetPlayerByElo(CListPlayer.humanPlayer.elo);
                if (formOptions.cbGameBook.Text != Global.none)
                    pc.BookName = formOptions.cbGameBook.Text;
            }
            gamers.SetPlayers(CListPlayer.humanPlayer, pc);
            if (CModeGame.rotate)
                gamers.Rotate();
        }

        void GameStart()
        {
            CModeGame.NewGame();
            labAccuracy.Text = CModeGame.Info();
            ComClear();
            SettingsToGameMode();
            GameModeToGamers();
            if (!gamers.Check(out string msg))
            {
                MessageBox.Show(msg);
                return;
            }
            SetBoardRotate();
            board.StartAnimation();
            RenderBoard(true);
            ShowAutoElo();
            ComShow();
            CEngine e = engineList.GetEngineByName(formOptions.cbGameTeacher.Text);
            if (e != null)
                teacher.SetTeacher(e.GetPath(), e.arguments);
        }

        void GameShow()
        {
            ShowLastGame();
            GameModeToSettings();
            GameStart();
        }

        void GameEnd(CPlayer pw, CPlayer pl, bool isDraw)
        {
            if (!CModeGame.ranked || !IsGameRanked())
                return;
            if (pw.IsHuman())
                if (isDraw)
                    pw.NewElo();
                else
                    pw.NewElo(pw.GetEloMore());
            if (pl.IsHuman())
                if (isDraw)
                    pl.NewElo();
                else
                    pl.NewElo(pl.GetEloLess());
            CModeGame.finished = true;
            CModeGame.rotate = !CModeGame.rotate;
            CModeGame.SaveToIni(ini);
            GameModeToSettings();
        }

        #endregion

        #region mode match

        void MatchClear()
        {
            formOptions.SettingsToMatch();
            CGames.NewSession();
            CModeMatch.Reset();
            MatchShow();
        }

        void MatchUpdate()
        {
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
        }

        void MatchShow()
        {
            Text = CGames.Text;
            formOptions.MatchToSettings();
            MatchUpdate();
            CData.HisToPoints(CModeMatch.his, chartMatch.Series[0].Points);
            chartMatch.ChartAreas[0].RecalculateAxesScale();
        }

        void MatchStart()
        {
            ComClear();
            formOptions.SettingsToMatch();
            SetMode(CGameMode.match);
            CPlayer p1 = new CPlayer("Player 1");
            p1.EngineName = CModeMatch.engine1;
            p1.BookName = formOptions.cbMatchBook1.Text;
            p1.levelValue.level = CModeMatch.modeValue1.level;
            p1.levelValue.baseVal = CModeMatch.modeValue1.baseVal;
            CPlayer p2 = new CPlayer("Player 2");
            p2.EngineName = CModeMatch.engine2;
            p2.BookName = formOptions.cbMatchBook2.Text;
            p2.levelValue.level = CModeMatch.modeValue2.level;
            p2.levelValue.baseVal = CModeMatch.modeValue2.baseVal;
            gamers.GamerWhite().SetPlayer(p1);
            gamers.GamerBlack().SetPlayer(p2);
            if (!gamers.Check(out string msg))
            {
                MessageBox.Show(msg);
                return;
            }
            p1.elo = p1.engine.elo;
            p2.elo = p2.engine.elo;
            gamers.SetPlayers(p1, p2);
            if (CModeMatch.Rotate)
                gamers.Rotate();
            CModeMatch.GameStart();
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
                        lvi.SubItems[1].Text = b.StrElo;
                        lvi.SubItems[2].Text = b.GetDeltaElo().ToString();
                        lvi.BackColor = b.hisElo.GetColor();
                    }
        }

        void TournamentBReset()
        {
            lvTourBList.Items.Clear();
            tourB.ListFill();
            foreach (CBook b in CModeTournamentB.bookList)
            {
                ListViewItem lvi = new ListViewItem(new[] { b.name, b.StrElo, b.GetDeltaElo().ToString() });
                lvi.BackColor = b.hisElo.GetColor();
                lvTourBList.Items.Add(lvi);
            }
            ListViewItem item = lvTourBList.FindItemWithText(tourB.first);
            if (item != null)
                item.Selected = true;
        }

        void TournamentBSelect()
        {
            int del = lvTourBList.TopItem.Bounds.Top;
            foreach (ListViewItem lvi in lvTourBList.Items)
                if (lvi.Text == tourB.first)
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
            CListBook bookList = CModeTournamentB.bookList;
            CBook book = bookList.GetBookByName(name);
            if (book == null)
                return;
            lvTourBSel.Items.Clear();
            bookList.SortElo();
            bookList.FillPosition();
            int countGames = 0;
            foreach (CBook b in bookList)
            {
                int count = CModeTournamentB.tourList.CountGames(name, b.name, out int gw, out int gl, out int gd);
                if (count > 0)
                {
                    int pro = (gw * 200 + gd * 100) / count - 100;
                    int del = book.elo - b.elo;
                    ListViewItem lvi = new ListViewItem(new[] { b.name, del.ToString(), count.ToString(), pro.ToString() });
                    if (del > 0)
                        lvi.BackColor = Colors.listW;
                    if (del < 0)
                        lvi.BackColor = Colors.listB;
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
            int reps = book.name == tourB.first ? tourB.reps : 0;
            int left = book.name == tourB.first ? tourB.left : book.tournament;
            labBook.BackColor = book.hisElo.GetColor();
            labBook.Text = $"{book.name} games {countGames} players {bookList.Count} reps {reps} left {left}";
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
            SetMode(CGameMode.tourB);
            CBook b1 = tourB.SelectFirst();
            if (b1 == null)
                return;
            CBook b2 = tourB.SelectSecond(b1);
            CPlayer p1 = new CPlayer(b1.name);
            CPlayer p2 = new CPlayer(b2.name);
            p1.EngineName = p2.EngineName = formOptions.cbTourBEngine.Text == Global.none ? engineList.GetEngineName() : formOptions.cbTourBEngine.Text;
            p1.elo = b1.elo;
            p2.elo = b2.elo;
            p1.BookName = b1.name;
            p2.BookName = b2.name;
            p1.levelValue.SetLevel(FormOptions.tourBMode);
            p1.levelValue.SetValue(FormOptions.tourBValue);
            p2.levelValue.SetLevel(FormOptions.tourBMode);
            p2.levelValue.SetValue(FormOptions.tourBValue);
            tourB.SetRepeition(b1, b2);
            gamers.SetPlayers(p1, p2);
            if (tourB.rotate)
                gamers.Rotate();
            TournamentBReset();
            TournamentBSelect();
            ComShow();
        }

        void TournamentBEnd(CGamer gw, CGamer gl, bool isDraw)
        {
            CListBook bookList = CModeTournamentB.bookList;
            CBook bw = bookList.GetBookByName(gw.book.name);
            CBook bl = bookList.GetBookByName(gl.book.name);
            if ((bw == null) || (bl == null))
                return;
            CPlayer pw = gamers.GamerWhite().player;
            CPlayer pb = gamers.GamerBlack().player;
            CModeTournamentB.bookWin = bw;
            CModeTournamentB.bookLoose = bl;
            bookList.SortElo();
            bookList.FillPosition();
            int eloW = bw.elo;
            int eloL = bl.elo;
            bool f = tourB.first == pw.BookName;
            CElo.EloRating(eloW, eloL, out int newW, out int newL, bw.hisElo.Count, bl.hisElo.Count, isDraw);
            if (isDraw)
                CModeTournamentB.tourList.Write(pw.BookName, pb.BookName, "d", f);
            else
            {
                if (eloW <= eloL)
                    tourB.left++;
                string r = gw.player == pw ? "w" : "b";
                CModeTournamentB.tourList.Write(pw.BookName, pb.BookName, r, f);
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
                        lvi.SubItems[1].Text = e.StrElo;
                        lvi.SubItems[2].Text = e.GetDeltaElo().ToString();
                        lvi.BackColor = e.hisElo.GetColor();
                    }
        }

        void TournamentEReset()
        {
            lvTourEList.Items.Clear();
            tourE.ListFill();
            foreach (CEngine e in CModeTournamentE.engineList)
            {
                ListViewItem lvi = new ListViewItem(new[] { e.name, e.StrElo, e.GetDeltaElo().ToString() });
                lvi.BackColor = e.hisElo.GetColor();
                lvTourEList.Items.Add(lvi);
            }
            ListViewItem item = lvTourEList.FindItemWithText(tourE.first);
            if (item != null)
                item.Selected = true;
        }

        void TournamentEShowHistory()
        {
            if (lvTourEList.SelectedItems.Count == 0)
                return;
            ListViewItem top2 = null;
            string name = lvTourEList.SelectedItems[0].Text;
            CListEngine engineList = CModeTournamentE.engineList;
            CEngine engine = engineList.GetEngineByName(name);
            if (engine == null)
                return;
            lvTourESel.Items.Clear();
            engineList.SortElo();
            engineList.FillPosition();
            int countGames = 0;
            foreach (CEngine e in engineList)
            {
                int count = CModeTournamentE.tourList.CountGames(name, e.name, out int gw, out int gl, out int gd);
                if (count > 0)
                {
                    int pro = (gw * 200 + gd * 100) / count - 100;
                    int del = engine.elo - e.elo;
                    ListViewItem lvi = new ListViewItem(new[] { e.name, del.ToString(), count.ToString(), pro.ToString() });
                    if (del > 0)
                        lvi.BackColor = Colors.listW;
                    if (del < 0)
                        lvi.BackColor = Colors.listB;
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
            int reps = engine.name == tourE.first ? tourE.reps : 0;
            int left = engine.name == tourE.first ? tourE.left : engine.tournament;
            labEngine.BackColor = engine.hisElo.GetColor();
            labEngine.Text = $"{engine.name} #{engineList.Position(engine.elo)}/{engineList.Count} games {countGames} reps {reps} left {left}";
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
                if (lvi.Text == tourE.first)
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
            SetMode(CGameMode.tourE);
            CEngine e1 = tourE.SelectFirst();
            if (e1 == null)
                return;
            CEngine e2 = tourE.SelectSecond(e1);
            CPlayer p1 = new CPlayer(e1.name);
            CPlayer p2 = new CPlayer(e2.name);
            p1.EngineName = e1.name;
            p2.EngineName = e2.name;
            p1.elo = e1.elo;
            p2.elo = e2.elo;
            p1.BookName = formOptions.cbTourEBookF.Text;
            p1.levelValue.SetLevel(FormOptions.tourEMode);
            p1.levelValue.SetValue(FormOptions.tourEValue);
            p2.BookName = formOptions.cbTourEBookS.Text;
            p2.levelValue.SetLevel(FormOptions.tourEMode);
            p2.levelValue.SetValue(FormOptions.tourEValue);
            if ((CGames.played & 2) > 0)
                (p1.BookName, p2.BookName) = (p2.BookName, p1.BookName);
            tourE.SetRepeition(e1, e2);
            gamers.SetPlayers(p1, p2);
            if (tourE.rotate)
                gamers.Rotate();
            TournamentEReset();
            TournamentESelect();
            ComShow();
        }

        void TournamentEEnd(CGamer gw, CGamer gl, bool isDraw)
        {
            CListEngine engList = CModeTournamentE.engineList;
            CEngine ew = engList.GetEngineByName(gw.engine.name);
            CEngine el = engList.GetEngineByName(gl.engine.name);
            if ((ew == null) || (el == null))
                return;
            CPlayer pw = gamers.GamerWhite().player;
            CPlayer pb = gamers.GamerBlack().player;
            CModeTournamentE.engWin = ew;
            CModeTournamentE.engLoose = el;
            engList.SortElo();
            engList.FillPosition();
            int eloW = ew.elo;
            int eloL = el.elo;
            bool f = tourE.first == pw.EngineName;
            CElo.EloRating(eloW, eloL, out int newW, out int newL, ew.hisElo.Count, el.hisElo.Count, isDraw);
            if (isDraw)
                CModeTournamentE.tourList.Write(pw.EngineName, pb.EngineName, "d", f);
            else
            {
                if (eloW <= eloL)
                    tourE.left++;
                string r = gw.player == pw ? "w" : "b";
                CModeTournamentE.tourList.Write(pw.EngineName, pb.EngineName, r, f);
            }
            ew.AddElo(newW);
            el.AddElo(newL);
            formChartE.UpdateChart();
        }

        #endregion mode tournament E

        #region mode touurnament P

        void TournamentPUpdate(CPlayer p)
        {
            if (p != null)
                foreach (ListViewItem lvi in lvTourPList.Items)
                    if (lvi.Text == p.name)
                    {
                        lvi.SubItems[1].Text = p.StrElo;
                        lvi.SubItems[2].Text = p.GetDeltaElo().ToString();
                        lvi.BackColor = p.hisElo.GetColor();
                    }
        }

        void TournamentPReset()
        {
            lvTourPList.Items.Clear();
            tourP.ListFill();
            foreach (CPlayer p in CModeTournamentP.playerList)
            {
                ListViewItem lvi = new ListViewItem(new[] { p.name, p.StrElo, p.GetDeltaElo().ToString() });
                lvi.BackColor = p.hisElo.GetColor();
                lvTourPList.Items.Add(lvi);
            }
            ListViewItem item = lvTourPList.FindItemWithText(tourP.first);
            if (item != null)
                item.Selected = true;
        }

        void TournamentPShowHistory()
        {
            if (lvTourPList.SelectedItems.Count == 0)
                return;
            ListViewItem top2 = null;
            string name = lvTourPList.SelectedItems[0].Text;
            CListPlayer playerList = CModeTournamentP.playerList;
            CPlayer player = playerList.GetPlayerByName(name);
            if (player == null)
                return;
            lvTourPSel.Items.Clear();
            playerList.SortElo();
            playerList.FillPosition();
            int countGames = 0;
            foreach (CPlayer p in playerList)
                if (p.EngineName != Global.none)
                {
                    int count = CModeTournamentP.tourList.CountGames(name, p.name, out int gw, out int gl, out int gd);
                    if (count > 0)
                    {
                        int pro = (gw * 200 + gd * 100) / count - 100;
                        int del = Convert.ToInt32(player.StrElo) - Convert.ToInt32(p.StrElo);
                        ListViewItem lvi = new ListViewItem(new[] { p.name, del.ToString(), count.ToString(), pro.ToString() });
                        if (del > 0)
                            lvi.BackColor = Colors.listW;
                        if (del < 0)
                            lvi.BackColor = Colors.listB;
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
            int reps = player.name == tourP.first ? FormChess.tourP.reps : 0;
            int left = player.name == tourP.first ? FormChess.tourP.left : player.tournament;
            labPlayer.BackColor = player.hisElo.GetColor();
            labPlayer.Text = $"{player.name} games {countGames} players {playerList.Count} reps {reps} left {left}";
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
                if (lvi.Text == tourP.first)
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
            if (playerList.Count == 0)
            {
                MessageBox.Show("No players");
                return;
            }
            ComClear();
            TournamentPUpdate(CModeTournamentP.plaWin);
            TournamentPUpdate(CModeTournamentP.plaLoose);
            SetMode(CGameMode.tourP);
            CPlayer p1 = tourP.SelectFirst();
            if (p1 == null)
                return;
            CPlayer p2 = tourP.SelectSecond(p1);
            tourP.SetRepeition(p1, p2);
            gamers.SetPlayers(p1, p2);
            if (tourP.rotate)
                gamers.Rotate();
            TournamentPSelect();
            ComShow();
        }

        void TournamentPEnd(CPlayer pw, CPlayer pl, bool isDraw)
        {
            CListPlayer plaList = CModeTournamentP.playerList;
            pw = plaList.GetPlayerByName(pw.name);
            pl = plaList.GetPlayerByName(pl.name);
            if ((pw == null) || (pl == null))
                return;
            CPlayer plw = gamers.GamerWhite().player;
            CPlayer plb = gamers.GamerBlack().player;
            CModeTournamentP.plaWin = pw;
            CModeTournamentP.plaLoose = pl;
            plaList.SortElo();
            plaList.FillPosition();
            int eloW = pw.elo;
            int eloL = pl.elo;
            bool f = tourP.first == plw.name;
            CElo.EloRating(eloW, eloL, out int newW, out int newL, pw.hisElo.Count, pl.hisElo.Count, isDraw);
            if (isDraw)
                CModeTournamentP.tourList.Write(plw.name, plb.name, "d", f);
            else
            {
                if (eloW <= eloL)
                    tourP.left++;
                string r = pw == plw ? "w" : "b";
                CModeTournamentP.tourList.Write(plw.name, plb.name, r, f);
            }
            pw.NewElo(newW);
            pl.NewElo(newL);
            formChartP.UpdateChart();
        }

        #endregion mode tournamentP

        #region mode training

        void TrainingClear()
        {
            SettingsToTraining();
            CGames.NewSession();
            CModeTraining.Reset();
            TrainingShow();
        }

        void TrainingShow()
        {
            Text = CGames.Text;
            TrainingToSettings();
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

        void SettingsToTraining()
        {
            CModeTraining.trainer = cbTrainerEngine.Text;
            CModeTraining.trained = cbTrainedEngine.Text;
            CModeTraining.modeValueTrainer.SetLevel(cbTrainerMode.Text);
            CModeTraining.modeValueTrained.SetLevel(cbTrainedMode.Text);
            CModeTraining.trainerBook = cbTrainerBook.Text;
            CModeTraining.trainedBook = cbTrainedBook.Text;
            CModeTraining.modeValueTrainer.SetValue((int)nudTrainer.Value);
            CModeTraining.modeValueTrained.SetValue((int)nudTrained.Value);
            CModeTraining.SaveToIni();
        }

        void TrainingToSettings()
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
            SettingsToTraining();
            SetMode(CGameMode.training);
            CPlayer pw = new CPlayer("Trained");
            pw.EngineName = CModeTraining.trained;
            pw.BookName = CModeTraining.trainedBook;
            pw.levelValue.level = CModeTraining.modeValueTrained.level;
            pw.levelValue.baseVal = CModeTraining.modeValueTrained.baseVal;
            pw.elo = pw.engine.elo;
            CPlayer pb = new CPlayer("Trainer");
            pb.EngineName = CModeTraining.trainer;
            pb.BookName = CModeTraining.trainerBook;
            pb.levelValue.level = CModeTraining.modeValueTrainer.level;
            pb.levelValue.baseVal = CModeTraining.modeValueTrainer.baseVal;
            pb.elo = pb.engine.elo;
            gamers.SetPlayers(pw, pb);
            if (CModeTraining.rotate)
                gamers.Rotate();
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
                        if (--CModeTraining.modeValueTrainer.baseVal < 1)
                            CModeTraining.modeValueTrainer.baseVal = 1;
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
                    CModeTraining.modeValueTrainer.baseVal++;
                }
            }
            else
            {
                CModeTraining.draw++;
                CModeTraining.winInRow = 0;
                CModeTraining.modeValueTrainer.baseVal++;
            }
            if (up)
                nudTrainer.Value += nudTrainer.Increment;
            CModeTraining.his.AddValue(Convert.ToInt32(nudTrainer.Value));
            CModeTraining.rotate = !CModeTraining.rotate;
            CModeTraining.SaveToIni();
        }

        #endregion training

        #region mode edit

        void AnalysisStart()
        {
            analysis = true;
            bAnalysis.BackColor = Color.LightGreen;
            lvMovesW.Items.Clear();
            lvMovesB.Items.Clear();
            CModeEdit.fen = chess.GetFen();
            EditStart();
        }

        void AnalysisStop()
        {
            analysis = false;
            bAnalysis.BackColor = SystemColors.Control;
            gamers.Stop();
        }

        void AnalysisSwitch()
        {
            if (analysis)
                AnalysisStop();
            else
                AnalysisStart();
        }

        void ValueToNUD(decimal value, ref NumericUpDown nud)
        {
            if (value < nud.Minimum)
                value = nud.Minimum;
            if (value > nud.Maximum)
                value = nud.Maximum;
            nud.Value = value;
        }

        void SelectedToMEdit()
        {
            CModeEdit.multiPV = (int)nudMultiPV.Value;
            CModeEdit.engine1 = cbEditEngine1.Text;
            CModeEdit.engine2 = cbEditEngine2.Text;
            CModeEdit.fen = chess.GetFen();
        }

        void MEditToSelected()
        {
            ValueToNUD(CModeEdit.multiPV, ref nudMultiPV);
            cbEditEngine1.Text = CModeEdit.engine1;
            cbEditEngine2.Text = CModeEdit.engine2;
            chess.SetFen(CModeEdit.fen);
        }


        void EditShow()
        {
            MEditToSelected();
            PrepareFen(CModeEdit.fen);
            ChessToEdit();
            EditChessToFen();
            SetBoardRotate();
            board.StartAnimation();
            RenderBoard();
            if (analysis)
                AnalysisStart();
        }

        void EditChessToFen()
        {
            tbFen.Text = CModeEdit.fen = chess.GetFen();
        }

        void ChessToEdit()
        {
            List<int> moves = chess.GenerateLegalMoves(out _);
            lbGameMoves.Items.Clear();
            foreach (int move in moves)
            {
                lbGameMoves.Items.Add(chess.EmoToUmo(move));
                lbGameMoves.SetSelected(lbGameMoves.Items.Count - 1, true);
            }
            List<RadioButton> list = gbToMove.Controls.OfType<RadioButton>().ToList();
            list[chess.WhiteTurn ? 1 : 0].Select();
            for (int n = 0; n < 4; n++)
                clbCastling.SetItemChecked(n, chess.castleRights.Get(n));
            cbPassant.Text = chess.Passant;
            nudMove.Value = chess.MoveNumber;
            nudReversible.Value = chess.move50;
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

        string EditGetMoves()
        {
            string result = string.Empty;
            if (lbGameMoves.Items.Count == lbGameMoves.SelectedItems.Count)
                return result;
            foreach (var e in lbGameMoves.SelectedItems)
                result += $" {e}";
            return " searchmoves " + result.Trim();
        }

        void EditStart()
        {
            SelectedToMEdit();
            CPlayer p1 = new CPlayer(CModeEdit.engine1);
            p1.EngineName = CModeEdit.engine1;
            p1.levelValue.level = CLevel.infinite;
            CPlayer p2 = new CPlayer(CModeEdit.engine2);
            p2.EngineName = CModeEdit.engine2;
            p2.levelValue.level = CLevel.infinite;
            gamers.SetPlayers(p1, p2);
            gamers.StartAnalysis(EditGetMoves());
            ComShow();
        }

        #endregion mode edit

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
            ShowFormLog("Application log", log.path, this);
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

        #endregion

        #region events

        private void FormChess_FormClosing(object sender, FormClosingEventArgs e)
        {
            IniSave();
            KillChildrens(Process.GetCurrentProcess().Id);
        }

        private void ButStop_Click(object sender, EventArgs e)
        {
            gamers.GamerCur().EngineStop();
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (CData.gameMode)
            {
                case CGameMode.game:
                    formOptions.listBox.SelectedIndex = formOptions.listBox.FindString("Game");
                    break;
                case CGameMode.match:
                    formOptions.listBox.SelectedIndex = formOptions.listBox.FindString("Match");
                    break;
                case CGameMode.tourB:
                    formOptions.listBox.SelectedIndex = formOptions.listBox.FindString("Tournament-books");
                    break;
                case CGameMode.tourE:
                    formOptions.listBox.SelectedIndex = formOptions.listBox.FindString("Tournament-engines");
                    break;
                case CGameMode.tourP:
                    formOptions.listBox.SelectedIndex = formOptions.listBox.FindString("Tournament-players");
                    break;
                case CGameMode.training:
                    formOptions.listBox.SelectedIndex = formOptions.listBox.FindString("Training");
                    break;
                case CGameMode.edit:
                    formOptions.listBox.SelectedIndex = formOptions.listBox.FindString("Interface");
                    break;
            }
            formOptions.ShowDialog(this);
            toolTip1.Active = FormOptions.showTips;
            board.animated = true;
            board.arrows.Clear();
            board.ClearColors();
            ShowAutoElo();
            ShowEco();
            HistoryToLvMovesExt();
            BoardPrepare();
            RenderBoard();
        }

        private void butClearBoard_Click(object sender, EventArgs e)
        {
            for (int n = 0; n < 64; n++)
            {
                chess.board[n] = CChess.colorEmpty;
                board.UpdateField(n);
            }
            RenderBoard(true);
        }

        private void rbColorChanged(object sender, EventArgs e)
        {
            var checkedButton = gbToMove.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            List<RadioButton> list = gbToMove.Controls.OfType<RadioButton>().ToList();
            int wt = list.IndexOf(checkedButton) == 1 ? 0 : 1;
            chess.halfMove = ((chess.MoveNumber - 1) << 1) + wt;
            EditChessToFen();
        }

        private void butDefault_Click(object sender, EventArgs e)
        {
            SetFen(CChess.defFen);
        }

        private void panBoard_Resize(object sender, EventArgs e)
        {
            panBoard.Invalidate();
            BoardPrepare();
        }

        private void lvLines_Resize(object sender, EventArgs e)
        {
            System.Windows.Forms.ListView lv = (System.Windows.Forms.ListView)sender;
            int w = 100;
            for (int n = 0; n < lv.Columns.Count - 1; n++)
                lv.Columns[n].Width = w;
            lv.Columns[lv.Columns.Count - 1].Width = lv.Width - w * (lv.Columns.Count - 1);
            ShowScrollBar(lv.Handle, 0, false);
        }

        private void lvMoves_Resize(object sender, EventArgs e)
        {
            System.Windows.Forms.ListView lv = (System.Windows.Forms.ListView)sender;
            int w = lv.Width - 32;
            lv.Columns[2].Width = w - 160;
            ShowScrollBar(lv.Handle, 0, false);
        }

        private void panBoard_Paint(object sender, PaintEventArgs e)
        {
            RenderBoard();
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

        private void cbMainMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = cbGameMode.Text;
            CGames.NewSession();
            formLogGames.textBox.Text = String.Empty;
            tabControl1.SelectedIndex = cbGameMode.SelectedIndex;
            SetMode((CGameMode)cbGameMode.SelectedIndex);
        }

        private void butResignation_Click(object sender, EventArgs e)
        {
            if (!IsGameRanked() || !IsGameLong() || !IsGameProgress() || !IsGameComputer())
                CModeGame.ranked = false;
            SetGameState(CGameState.resignation);
        }

        private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            System.Windows.Forms.ListView lv = sender as System.Windows.Forms.ListView;
            lv.Tag = lv.Tag == null ? new Object() : null;
            (sender as System.Windows.Forms.ListView).ListViewItemSorter = new ListViewComparer(e.Column, lv.Tag == null ? SortOrder.Ascending : SortOrder.Descending);
        }

        private void butForward_Click(object sender, EventArgs e)
        {
            SetUnranked();
            gamers.Rotate();
            ShowGamers();
        }

        private void labPromoQ_Click(object sender, EventArgs e)
        {
            board.MakeMove(CPromotion.des, CPromotion.sou);
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
            System.Windows.Forms.ListView lv = (System.Windows.Forms.ListView)sender;
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
            System.Windows.Forms.ListView lv = (System.Windows.Forms.ListView)sender;
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
            if (history.Back(1))
                LoadFromHistory();
            ShowGamers();
        }

        private void labBook_Click(object sender, EventArgs e)
        {
            TournamentBSelect();
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

        private void button2_Click(object sender, EventArgs e)
        {
            SetFen(tbFen.Text);
        }

        private void nudMove_ValueChanged(object sender, EventArgs e)
        {
            int wt = chess.WhiteTurn ? 0 : 1;
            chess.halfMove = (((int)nudMove.Value - 1) << 1) + wt;
            EditChessToFen();
        }

        private void nudReversible_ValueChanged(object sender, EventArgs e)
        {
            chess.move50 = (int)nudReversible.Value;
            EditChessToFen();
        }

        private void cbPassant_SelectedIndexChanged(object sender, EventArgs e)
        {
            chess.Passant = cbPassant.Text;
            EditChessToFen();
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

        private void lastAutodetectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormLog("Autodetection engines", FormAutodetect.pathAutoEng, this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAbout.ShowDialog(this);
        }

        private void bStartGame_Click(object sender, EventArgs e)
        {
            SettingsToGameMode();
            GameShow();
        }

        private void bStartMatch_Click(object sender, EventArgs e)
        {
            formOptions.SettingsToMatch();
            MatchStart();
        }

        private void bStartTraining_Click(object sender, EventArgs e)
        {
            SettingsToTraining();
            TrainingStart();
        }

        private void butStartTournamentB_Click(object sender, EventArgs e)
        {
            tourB.NewGame();
            TournamentBStart();
        }

        private void butStartTournamentE_Click(object sender, EventArgs e)
        {
            tourE.NewGame();
            TournamentEStart();
        }

        private void butStartTournamentP_Click(object sender, EventArgs e)
        {
            tourP.NewGame();
            TournamentPStart();
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormLog("Autodetection elo", FormAutodetect.pathAutoElo, this);
        }

        private void lvMoves_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (((CData.gameMode != CGameMode.game) && (CData.gameMode != CGameMode.edit)) || (lvMoves.SelectedItems.Count == 0))
                return;
            int index = lvMoves.SelectedItems[0].Index;
            CHis his = history[index];
            tbFen.Text = his.fen;
            if (his.fen != chess.GetFen())
            {
                CChess.UmoToSD(his.umo, out CDrag.lastSou, out CDrag.lastDes);
                chess.SetFen(his.fen);
                board.ClearArrows();
                board.arrows.AddMoves(his.pvCur, CBoard.Red, -1);
                board.arrows.AddMoves(his.pvBst, CBoard.Green, 1);
                board.Fill();
                board.StartAnimation();
                RenderBoard();
            }
            if (analysis)
                AnalysisStart();
        }

        private void bPlay_Click(object sender, EventArgs e)
        {
            if (cbApply.SelectedIndex < 1)
                cbApply.SelectedIndex = 1;
            cbGameMode.SelectedIndex = cbApply.SelectedIndex - 1;
        }

        private void clbCastling_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            chess.castleRights.Switch(e.Index, e.CurrentValue != CheckState.Checked);
            EditChessToFen();
        }

        private void labError_MouseDown(object sender, MouseEventArgs e)
        {
            labError.Hide();
            if (e.Button == MouseButtons.Left)
                ShowFormLastGame("error");
        }

        private void bAnalysis_Click(object sender, EventArgs e)
        {
            AnalysisSwitch();
        }

        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            chPgnPv.Width = lvPgn.Width - 250;
        }

        private void lvPgn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPgn.SelectedItems.Count < 1)
                return;
            SetPgn(lvPgn.SelectedItems[0].SubItems[3].Text);
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = $@"{AppDomain.CurrentDomain.BaseDirectory}Saves";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                switch (Path.GetExtension(openFileDialog1.FileName).ToLower())
                {
                    case ".fen":
                        LoadFen(openFileDialog1.FileName);
                        break;
                    case ".pgn":
                        LoadPgn(openFileDialog1.FileName);
                        break;
                    case ".uci":
                        LoadUci(openFileDialog1.FileName);
                        break;
                    case ".his":
                        LoadHis(openFileDialog1.FileName);
                        break;
                }
            }
        }

        private void fileToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = $@"{AppDomain.CurrentDomain.BaseDirectory}Saves";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(saveFileDialog1.FileName).ToLower();
                if (ext == ".his")
                    history.SaveToFile(saveFileDialog1.FileName);
                else
                    using (StreamWriter outputFile = new StreamWriter(saveFileDialog1.FileName))
                    {
                        switch (ext)
                        {
                            case ".fen":
                                outputFile.WriteLine(chess.GetFen());
                                break;
                            case ".pgn":
                                outputFile.WriteLine(history.GetPgn());
                                break;
                            case ".uci":
                                outputFile.WriteLine(history.GetMovesUci());
                                break;
                        }
                    }
            }
        }

        private void fenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFen(Clipboard.GetText());
        }

        private void pgnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPgn(Clipboard.GetText().Trim());
        }

        private void uciToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SetPgn(Clipboard.GetText().Trim());
        }

        private void fenToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(chess.GetFen());
        }

        private void pgnToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(history.GetPgn());
        }

        private void uciToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(history.GetMovesUci());
        }

        private void lvMoves_DoubleClick(object sender, EventArgs e)
        {
            if (lvMoves.SelectedItems.Count < 1)
                return;
            CHistory hl = new CHistory();
            int index = lvMoves.SelectedItems[0].Index;
            hl.Assign(history, index);
            hl.AddMoves(lvMoves.Items[index].SubItems[2].Text, "pv");
            cbGameMode.SelectedIndex = (int)CGameMode.edit;
            history.Assign(hl, hl.Count);
            SetHistory();
        }

        private void lvMovesW_DoubleClick(object sender, EventArgs e)
        {
            ListView lv = (sender as ListView);
            if ((lv.SelectedItems.Count < 1) || (CData.gameMode != CGameMode.edit))
                return;
            CHistory hl = new CHistory();
            int index;
            hl.fen = chess.GetFen();
            if (lvMoves.SelectedItems.Count > 0)
            {
                index = lvMoves.SelectedItems[0].Index;
                hl.Assign(history, index);
            }
            index = lv.SelectedItems[0].Index;
            hl.AddMoves(lv.Items[index].SubItems[5].Text, "pv");
            history.Assign(hl, hl.Count);
            SetHistory();
        }

        private void lastHisLoad_Click(object sender, EventArgs e)
        {
            string name = (sender as ToolStripMenuItem).Text;
            string path = $@"History\{name}.his";
            if (File.Exists(path))
                LoadHis(path);
            else MessageBox.Show($"File {name}.his not exists");
        }

        private void gameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string name = (sender as ToolStripMenuItem).Text;
            string path = $@"History\{name}.pgn";
            if (File.Exists(path))
                LoadPgn(path);
            else MessageBox.Show($"File {name}.pgn not exists");
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            CDrag.mouseX = e.X;
            CDrag.mouseY = e.Y;
            board.GetFieldXY(e.X, e.Y, out int x, out int y);
            if (board.rotate)
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
                else if (chess.board[i] != CChess.colorEmpty)
                {
                    EditSelected = chess.PieceToStr(chess.board[i]);
                    chess.board[i] = CChess.colorEmpty;
                }
                board.Fill();
                RenderBoard(true);
                EditChessToFen();
                if (analysis)
                    AnalysisStart();
            }
            if (CData.gameMode == CGameMode.game)
            {
                CDrag.last = CDrag.mouseIndex;
                CGamer g = chess.WhiteTurn ? gamers.GamerWhite() : gamers.GamerBlack();
                if (g.IsComputer())
                    return;
                if (e.Button == MouseButtons.Left)
                {
                    if (IsValid(CDrag.mouseIndex))
                    {
                        CDrag.lastSelected = CDrag.mouseIndex;
                        CDrag.dragged = true;
                        SetIndex(CDrag.mouseIndex);
                    }
                    else if (!IsValid(CDrag.lastDes))
                        SetIndex(-1);
                    if (!IsValid(CDrag.lastDes, CDrag.mouseIndex))
                        SetIndex(-1);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (tlpPromotion.Visible)
                return;
            if ((CData.gameMode == CGameMode.game))
            {
                if (e.Button == MouseButtons.Left)
                {
                    TryMoveHuman(CDrag.lastSelected, CDrag.mouseIndex);
                }
                else
                {
                    if (CDrag.last == CDrag.mouseIndex)
                    {
                        CField f = board.arrField[CDrag.mouseIndex];
                        f.circle = !f.circle;
                        board.arrows.Clear();
                    }
                    else board.arrows.Add(CDrag.last,CDrag.mouseIndex,CBoard.Blue,0);
                }
                CDrag.dragged = false;
            }
            board.StartAnimation();
        }

    }
}

#endregion
