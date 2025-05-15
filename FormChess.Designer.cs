namespace RapChessGui
{
	partial class FormChess
	{
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		/// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kod generowany przez Projektanta formularzy systemu Windows

		/// <summary>
		/// Metoda wymagana do obsługi projektanta — nie należy modyfikować
		/// jej zawartości w edytorze kodu.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChess));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGame = new System.Windows.Forms.TabPage();
            this.panChartGame = new System.Windows.Forms.Panel();
            this.chartGame = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labResult = new System.Windows.Forms.Label();
            this.labAccuracy = new System.Windows.Forms.Label();
            this.butBackward = new System.Windows.Forms.Button();
            this.butForward = new System.Windows.Forms.Button();
            this.butResignation = new System.Windows.Forms.Button();
            this.butStop = new System.Windows.Forms.Button();
            this.butNewGame = new System.Windows.Forms.Button();
            this.tabPageMatch = new System.Windows.Forms.TabPage();
            this.chartMatch = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tlpMatch = new System.Windows.Forms.TableLayoutPanel();
            this.labMatch24 = new System.Windows.Forms.Label();
            this.labMatch23 = new System.Windows.Forms.Label();
            this.labMatch22 = new System.Windows.Forms.Label();
            this.labMatch21 = new System.Windows.Forms.Label();
            this.labMatchPlayer2 = new System.Windows.Forms.Label();
            this.labMatch14 = new System.Windows.Forms.Label();
            this.labMatch13 = new System.Windows.Forms.Label();
            this.labMatch12 = new System.Windows.Forms.Label();
            this.labMatch11 = new System.Windows.Forms.Label();
            this.labMatchRes = new System.Windows.Forms.Label();
            this.labMatchDraw = new System.Windows.Forms.Label();
            this.labMatchLost = new System.Windows.Forms.Label();
            this.labMatchWin = new System.Windows.Forms.Label();
            this.labMatchPlayer = new System.Windows.Forms.Label();
            this.labMatchPlayer1 = new System.Windows.Forms.Label();
            this.labMatchGames = new System.Windows.Forms.Label();
            this.butNewMatch = new System.Windows.Forms.Button();
            this.tabPageTourB = new System.Windows.Forms.TabPage();
            this.scTourB = new System.Windows.Forms.SplitContainer();
            this.scTourBList = new System.Windows.Forms.SplitContainer();
            this.lvTourBList = new System.Windows.Forms.ListView();
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTourBSel = new System.Windows.Forms.ListView();
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labBook = new System.Windows.Forms.Label();
            this.chartTournamentB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPageTourE = new System.Windows.Forms.TabPage();
            this.scTourE = new System.Windows.Forms.SplitContainer();
            this.scTourEList = new System.Windows.Forms.SplitContainer();
            this.lvTourEList = new System.Windows.Forms.ListView();
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTourESel = new System.Windows.Forms.ListView();
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labEngine = new System.Windows.Forms.Label();
            this.chartTournamentE = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.butTourEStart = new System.Windows.Forms.Button();
            this.tabPageTourP = new System.Windows.Forms.TabPage();
            this.scTourP = new System.Windows.Forms.SplitContainer();
            this.scTourPList = new System.Windows.Forms.SplitContainer();
            this.lvTourPList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTourPSel = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labPlayer = new System.Windows.Forms.Label();
            this.chartTournamentP = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.butStartTournament = new System.Windows.Forms.Button();
            this.tabPageTraining = new System.Windows.Forms.TabPage();
            this.chartTraining = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tlpTraining = new System.Windows.Forms.TableLayoutPanel();
            this.labTrainRes2 = new System.Windows.Forms.Label();
            this.labTrainDraw2 = new System.Windows.Forms.Label();
            this.labTrainLost2 = new System.Windows.Forms.Label();
            this.labTrainWin2 = new System.Windows.Forms.Label();
            this.labTrainTeacher = new System.Windows.Forms.Label();
            this.labTrainRes1 = new System.Windows.Forms.Label();
            this.labTrainDraw1 = new System.Windows.Forms.Label();
            this.labTrainLost1 = new System.Windows.Forms.Label();
            this.labTrainWin1 = new System.Windows.Forms.Label();
            this.labTrainResult = new System.Windows.Forms.Label();
            this.labDraw = new System.Windows.Forms.Label();
            this.labTrainLost = new System.Windows.Forms.Label();
            this.labTrainWin = new System.Windows.Forms.Label();
            this.labTrainPlayer = new System.Windows.Forms.Label();
            this.labTrainTrained = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nudTrainer = new System.Windows.Forms.NumericUpDown();
            this.cbTrainerMode = new System.Windows.Forms.ComboBox();
            this.cbTrainerBook = new System.Windows.Forms.ComboBox();
            this.cbTrainerEngine = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudTrained = new System.Windows.Forms.NumericUpDown();
            this.cbTrainedMode = new System.Windows.Forms.ComboBox();
            this.cbTrainedBook = new System.Windows.Forms.ComboBox();
            this.cbTrainedEngine = new System.Windows.Forms.ComboBox();
            this.butTraining = new System.Windows.Forms.Button();
            this.tabPagePuzzle = new System.Windows.Forms.TabPage();
            this.chartPuzzle = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labPuzzleInfo = new System.Windows.Forms.Label();
            this.labPuzzle = new System.Windows.Forms.Label();
            this.butHint = new System.Windows.Forms.Button();
            this.butPuzzleNext = new System.Windows.Forms.Button();
            this.tabPageEdit = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbEditMoves = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bAnalysis = new System.Windows.Forms.Button();
            this.nudMultiPV = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.butMove2 = new System.Windows.Forms.Button();
            this.cbEditEngine2 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butMove1 = new System.Windows.Forms.Button();
            this.cbEditEngine1 = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbApply = new System.Windows.Forms.ComboBox();
            this.bPlay = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.tbFen = new System.Windows.Forms.TextBox();
            this.butUpdate = new System.Windows.Forms.Button();
            this.panChessState = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.clbCastling = new System.Windows.Forms.CheckedListBox();
            this.gbToMove = new System.Windows.Forms.GroupBox();
            this.rbBlack = new System.Windows.Forms.RadioButton();
            this.rbWhite = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.nudMove = new System.Windows.Forms.NumericUpDown();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.nudReversible = new System.Windows.Forms.NumericUpDown();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.cbPassant = new System.Windows.Forms.ComboBox();
            this.tlpEdit = new System.Windows.Forms.TableLayoutPanel();
            this.lab_bk = new System.Windows.Forms.Label();
            this.lab_bq = new System.Windows.Forms.Label();
            this.lab_br = new System.Windows.Forms.Label();
            this.lab_bb = new System.Windows.Forms.Label();
            this.lab_bn = new System.Windows.Forms.Label();
            this.lab_bp = new System.Windows.Forms.Label();
            this.lab_K = new System.Windows.Forms.Label();
            this.lab_Q = new System.Windows.Forms.Label();
            this.lab_R = new System.Windows.Forms.Label();
            this.lab_B = new System.Windows.Forms.Label();
            this.lab_N = new System.Windows.Forms.Label();
            this.lab_P = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.butBoardRotate = new System.Windows.Forms.Button();
            this.butBoardClear = new System.Windows.Forms.Button();
            this.butBoardDefault = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clipboardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pgnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uciToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tournamentbooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tournamentenginesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tournamentplayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.errorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pgnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.matchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tournamentbooksToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tournamentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tournamentplayersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.errorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clipboardToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fenToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pgnToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.uciToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.puzzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booksToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.enginesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enginesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.lastGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastMatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastTournamentbooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lasstTournamentenginesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastTournamentplayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastTrainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastAutodetectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enginesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booksToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.enginesToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labGameTime = new System.Windows.Forms.Label();
            this.panMenu = new System.Windows.Forms.Panel();
            this.labEco = new System.Windows.Forms.Label();
            this.labError = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbGameMode = new System.Windows.Forms.ComboBox();
            this.labNpsW = new System.Windows.Forms.Label();
            this.labNodesW = new System.Windows.Forms.Label();
            this.labModeW = new System.Windows.Forms.Label();
            this.labProtocolW = new System.Windows.Forms.Label();
            this.labEngineW = new System.Windows.Forms.Label();
            this.labMemoryW = new System.Windows.Forms.Label();
            this.labDepthW = new System.Windows.Forms.Label();
            this.labBookCW = new System.Windows.Forms.Label();
            this.labWhite = new System.Windows.Forms.Label();
            this.labColW = new System.Windows.Forms.Label();
            this.labScoreW = new System.Windows.Forms.Label();
            this.labPlayerW = new System.Windows.Forms.Label();
            this.labBookNW = new System.Windows.Forms.Label();
            this.pbHashW = new System.Windows.Forms.ProgressBar();
            this.labBookCB = new System.Windows.Forms.Label();
            this.labNpsB = new System.Windows.Forms.Label();
            this.labNodesB = new System.Windows.Forms.Label();
            this.labDepthB = new System.Windows.Forms.Label();
            this.labScoreB = new System.Windows.Forms.Label();
            this.labColB = new System.Windows.Forms.Label();
            this.labModeB = new System.Windows.Forms.Label();
            this.labProtocolB = new System.Windows.Forms.Label();
            this.labMemoryB = new System.Windows.Forms.Label();
            this.labBookNB = new System.Windows.Forms.Label();
            this.labBlack = new System.Windows.Forms.Label();
            this.labPlayerB = new System.Windows.Forms.Label();
            this.labEngineB = new System.Windows.Forms.Label();
            this.pbHashB = new System.Windows.Forms.ProgressBar();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labPromoB = new System.Windows.Forms.Label();
            this.labPromoN = new System.Windows.Forms.Label();
            this.labPromoQ = new System.Windows.Forms.Label();
            this.labPromoR = new System.Windows.Forms.Label();
            this.labColorL = new System.Windows.Forms.Label();
            this.labColorH = new System.Windows.Forms.Label();
            this.labMaterialL = new System.Windows.Forms.Label();
            this.labTakenH = new System.Windows.Forms.Label();
            this.labMaterialH = new System.Windows.Forms.Label();
            this.labTakenL = new System.Windows.Forms.Label();
            this.labNameH = new System.Windows.Forms.Label();
            this.labTimeH = new System.Windows.Forms.Label();
            this.labEloH = new System.Windows.Forms.Label();
            this.labNameL = new System.Windows.Forms.Label();
            this.labTimeL = new System.Windows.Forms.Label();
            this.labEloL = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssMove = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.scBoard = new System.Windows.Forms.SplitContainer();
            this.panBoard = new System.Windows.Forms.Panel();
            this.tlpPromotion = new System.Windows.Forms.TableLayoutPanel();
            this.tlpL = new System.Windows.Forms.TableLayoutPanel();
            this.panBoardL = new System.Windows.Forms.Panel();
            this.tlpChartB = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBoardL = new System.Windows.Forms.TableLayoutPanel();
            this.tlpH = new System.Windows.Forms.TableLayoutPanel();
            this.panBoardH = new System.Windows.Forms.Panel();
            this.tlpChartW = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBoardH = new System.Windows.Forms.TableLayoutPanel();
            this.scMode = new System.Windows.Forms.SplitContainer();
            this.panGameMode = new System.Windows.Forms.Panel();
            this.scRight = new System.Windows.Forms.SplitContainer();
            this.lvMoves = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageGraph = new System.Windows.Forms.TabPage();
            this.panChartMain = new System.Windows.Forms.Panel();
            this.tabPageAnalysis = new System.Windows.Forms.TabPage();
            this.tcLast = new System.Windows.Forms.TabControl();
            this.tpFens = new System.Windows.Forms.TabPage();
            this.lvFen = new System.Windows.Forms.ListView();
            this.columnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFenFen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpGames = new System.Windows.Forms.TabPage();
            this.lvPgn = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPgnPv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpPuzzles = new System.Windows.Forms.TabPage();
            this.lvPuzzle = new System.Windows.Forms.ListView();
            this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPuzzleFen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPuzzlePv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butLastDelete = new System.Windows.Forms.Button();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerMoves = new System.Windows.Forms.SplitContainer();
            this.lvMovesW = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panWhite = new System.Windows.Forms.Panel();
            this.tlpWhite = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxW = new System.Windows.Forms.PictureBox();
            this.lvMovesB = new System.Windows.Forms.ListView();
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panBlack = new System.Windows.Forms.Panel();
            this.tlpBlack = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxB = new System.Windows.Forms.PictureBox();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPageGame.SuspendLayout();
            this.panChartGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGame)).BeginInit();
            this.tabPageMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMatch)).BeginInit();
            this.tlpMatch.SuspendLayout();
            this.tabPageTourB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTourB)).BeginInit();
            this.scTourB.Panel1.SuspendLayout();
            this.scTourB.Panel2.SuspendLayout();
            this.scTourB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTourBList)).BeginInit();
            this.scTourBList.Panel1.SuspendLayout();
            this.scTourBList.Panel2.SuspendLayout();
            this.scTourBList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTournamentB)).BeginInit();
            this.tabPageTourE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTourE)).BeginInit();
            this.scTourE.Panel1.SuspendLayout();
            this.scTourE.Panel2.SuspendLayout();
            this.scTourE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTourEList)).BeginInit();
            this.scTourEList.Panel1.SuspendLayout();
            this.scTourEList.Panel2.SuspendLayout();
            this.scTourEList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTournamentE)).BeginInit();
            this.tabPageTourP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTourP)).BeginInit();
            this.scTourP.Panel1.SuspendLayout();
            this.scTourP.Panel2.SuspendLayout();
            this.scTourP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTourPList)).BeginInit();
            this.scTourPList.Panel1.SuspendLayout();
            this.scTourPList.Panel2.SuspendLayout();
            this.scTourPList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTournamentP)).BeginInit();
            this.tabPageTraining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTraining)).BeginInit();
            this.tlpTraining.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTrainer)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTrained)).BeginInit();
            this.tabPagePuzzle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPuzzle)).BeginInit();
            this.tabPageEdit.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiPV)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.panChessState.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.gbToMove.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMove)).BeginInit();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReversible)).BeginInit();
            this.groupBox15.SuspendLayout();
            this.tlpEdit.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scBoard)).BeginInit();
            this.scBoard.Panel1.SuspendLayout();
            this.scBoard.Panel2.SuspendLayout();
            this.scBoard.SuspendLayout();
            this.panBoard.SuspendLayout();
            this.tlpPromotion.SuspendLayout();
            this.tlpL.SuspendLayout();
            this.panBoardL.SuspendLayout();
            this.tlpChartB.SuspendLayout();
            this.tlpBoardL.SuspendLayout();
            this.tlpH.SuspendLayout();
            this.panBoardH.SuspendLayout();
            this.tlpChartW.SuspendLayout();
            this.tlpBoardH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMode)).BeginInit();
            this.scMode.Panel1.SuspendLayout();
            this.scMode.Panel2.SuspendLayout();
            this.scMode.SuspendLayout();
            this.panGameMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scRight)).BeginInit();
            this.scRight.Panel1.SuspendLayout();
            this.scRight.Panel2.SuspendLayout();
            this.scRight.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageGraph.SuspendLayout();
            this.panChartMain.SuspendLayout();
            this.tabPageAnalysis.SuspendLayout();
            this.tcLast.SuspendLayout();
            this.tpFens.SuspendLayout();
            this.tpGames.SuspendLayout();
            this.tpPuzzles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMoves)).BeginInit();
            this.splitContainerMoves.Panel1.SuspendLayout();
            this.splitContainerMoves.Panel2.SuspendLayout();
            this.splitContainerMoves.SuspendLayout();
            this.panWhite.SuspendLayout();
            this.tlpWhite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxW)).BeginInit();
            this.panBlack.SuspendLayout();
            this.tlpBlack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPageGame);
            this.tabControl1.Controls.Add(this.tabPageMatch);
            this.tabControl1.Controls.Add(this.tabPageTourB);
            this.tabControl1.Controls.Add(this.tabPageTourE);
            this.tabControl1.Controls.Add(this.tabPageTourP);
            this.tabControl1.Controls.Add(this.tabPageTraining);
            this.tabControl1.Controls.Add(this.tabPagePuzzle);
            this.tabControl1.Controls.Add(this.tabPageEdit);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 498);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 9;
            // 
            // tabPageGame
            // 
            this.tabPageGame.Controls.Add(this.panChartGame);
            this.tabPageGame.Controls.Add(this.butBackward);
            this.tabPageGame.Controls.Add(this.butForward);
            this.tabPageGame.Controls.Add(this.butResignation);
            this.tabPageGame.Controls.Add(this.butStop);
            this.tabPageGame.Controls.Add(this.butNewGame);
            this.tabPageGame.Location = new System.Drawing.Point(4, 5);
            this.tabPageGame.Name = "tabPageGame";
            this.tabPageGame.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGame.Size = new System.Drawing.Size(367, 489);
            this.tabPageGame.TabIndex = 0;
            this.tabPageGame.Text = "Game";
            // 
            // panChartGame
            // 
            this.panChartGame.Controls.Add(this.chartGame);
            this.panChartGame.Controls.Add(this.labResult);
            this.panChartGame.Controls.Add(this.labAccuracy);
            this.panChartGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panChartGame.Location = new System.Drawing.Point(3, 118);
            this.panChartGame.Name = "panChartGame";
            this.panChartGame.Size = new System.Drawing.Size(361, 368);
            this.panChartGame.TabIndex = 30;
            this.panChartGame.SizeChanged += new System.EventHandler(this.panChartGame_SizeChanged);
            // 
            // chartGame
            // 
            this.chartGame.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chartGame.ChartAreas.Add(chartArea1);
            this.chartGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartGame.Location = new System.Drawing.Point(0, 34);
            this.chartGame.MinimumSize = new System.Drawing.Size(32, 32);
            this.chartGame.Name = "chartGame";
            this.chartGame.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartGame.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Olive};
            series1.BorderWidth = 4;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            this.chartGame.Series.Add(series1);
            this.chartGame.Size = new System.Drawing.Size(361, 321);
            this.chartGame.SuppressExceptions = true;
            this.chartGame.TabIndex = 29;
            this.chartGame.Text = "chart1";
            this.toolTip1.SetToolTip(this.chartGame, "User progress history");
            // 
            // labResult
            // 
            this.labResult.BackColor = System.Drawing.Color.Black;
            this.labResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.labResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labResult.Location = new System.Drawing.Point(0, 0);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(361, 34);
            this.labResult.TabIndex = 31;
            this.labResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labResult.Visible = false;
            // 
            // labAccuracy
            // 
            this.labAccuracy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labAccuracy.Location = new System.Drawing.Point(0, 355);
            this.labAccuracy.Name = "labAccuracy";
            this.labAccuracy.Size = new System.Drawing.Size(361, 13);
            this.labAccuracy.TabIndex = 30;
            this.labAccuracy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butBackward
            // 
            this.butBackward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butBackward.Dock = System.Windows.Forms.DockStyle.Top;
            this.butBackward.Location = new System.Drawing.Point(3, 95);
            this.butBackward.Name = "butBackward";
            this.butBackward.Size = new System.Drawing.Size(361, 23);
            this.butBackward.TabIndex = 27;
            this.butBackward.Text = "Back";
            this.toolTip1.SetToolTip(this.butBackward, "Resignation from further play");
            this.butBackward.UseVisualStyleBackColor = true;
            this.butBackward.Click += new System.EventHandler(this.butBackward_Click);
            // 
            // butForward
            // 
            this.butForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butForward.Dock = System.Windows.Forms.DockStyle.Top;
            this.butForward.Location = new System.Drawing.Point(3, 72);
            this.butForward.Name = "butForward";
            this.butForward.Size = new System.Drawing.Size(361, 23);
            this.butForward.TabIndex = 26;
            this.butForward.Text = "Move";
            this.toolTip1.SetToolTip(this.butForward, "Resignation from further play");
            this.butForward.UseVisualStyleBackColor = true;
            this.butForward.Click += new System.EventHandler(this.butForward_Click);
            // 
            // butResignation
            // 
            this.butResignation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butResignation.Dock = System.Windows.Forms.DockStyle.Top;
            this.butResignation.Location = new System.Drawing.Point(3, 49);
            this.butResignation.Name = "butResignation";
            this.butResignation.Size = new System.Drawing.Size(361, 23);
            this.butResignation.TabIndex = 25;
            this.butResignation.Text = "Resignation";
            this.toolTip1.SetToolTip(this.butResignation, "Resignation from further play");
            this.butResignation.UseVisualStyleBackColor = true;
            this.butResignation.Click += new System.EventHandler(this.butResignation_Click);
            // 
            // butStop
            // 
            this.butStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butStop.Dock = System.Windows.Forms.DockStyle.Top;
            this.butStop.Location = new System.Drawing.Point(3, 26);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(361, 23);
            this.butStop.TabIndex = 24;
            this.butStop.Text = "Stop";
            this.toolTip1.SetToolTip(this.butStop, "Engine stop calculating and makes a move immediately");
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.ButStop_Click);
            // 
            // butNewGame
            // 
            this.butNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butNewGame.Dock = System.Windows.Forms.DockStyle.Top;
            this.butNewGame.Location = new System.Drawing.Point(3, 3);
            this.butNewGame.Name = "butNewGame";
            this.butNewGame.Size = new System.Drawing.Size(361, 23);
            this.butNewGame.TabIndex = 20;
            this.butNewGame.Text = "Start";
            this.toolTip1.SetToolTip(this.butNewGame, "Start new game");
            this.butNewGame.UseVisualStyleBackColor = true;
            this.butNewGame.Click += new System.EventHandler(this.bStartGame_Click);
            // 
            // tabPageMatch
            // 
            this.tabPageMatch.Controls.Add(this.chartMatch);
            this.tabPageMatch.Controls.Add(this.tlpMatch);
            this.tabPageMatch.Controls.Add(this.labMatchGames);
            this.tabPageMatch.Controls.Add(this.butNewMatch);
            this.tabPageMatch.Location = new System.Drawing.Point(4, 5);
            this.tabPageMatch.Name = "tabPageMatch";
            this.tabPageMatch.Size = new System.Drawing.Size(367, 489);
            this.tabPageMatch.TabIndex = 2;
            this.tabPageMatch.Text = "Match";
            this.tabPageMatch.UseVisualStyleBackColor = true;
            // 
            // chartMatch
            // 
            this.chartMatch.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chartMatch.ChartAreas.Add(chartArea2);
            this.chartMatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chartMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartMatch.Location = new System.Drawing.Point(0, 83);
            this.chartMatch.MinimumSize = new System.Drawing.Size(32, 32);
            this.chartMatch.Name = "chartMatch";
            this.chartMatch.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartMatch.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Olive};
            series2.BorderWidth = 4;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsVisibleInLegend = false;
            series2.Name = "Series1";
            this.chartMatch.Series.Add(series2);
            this.chartMatch.Size = new System.Drawing.Size(367, 384);
            this.chartMatch.TabIndex = 29;
            this.chartMatch.Text = "chart1";
            this.toolTip1.SetToolTip(this.chartMatch, "User progress history");
            this.chartMatch.Click += new System.EventHandler(this.chartMatch_Click);
            // 
            // tlpMatch
            // 
            this.tlpMatch.BackColor = System.Drawing.Color.White;
            this.tlpMatch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMatch.ColumnCount = 5;
            this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMatch.Controls.Add(this.labMatch24, 4, 2);
            this.tlpMatch.Controls.Add(this.labMatch23, 3, 2);
            this.tlpMatch.Controls.Add(this.labMatch22, 2, 2);
            this.tlpMatch.Controls.Add(this.labMatch21, 1, 2);
            this.tlpMatch.Controls.Add(this.labMatchPlayer2, 0, 2);
            this.tlpMatch.Controls.Add(this.labMatch14, 4, 1);
            this.tlpMatch.Controls.Add(this.labMatch13, 3, 1);
            this.tlpMatch.Controls.Add(this.labMatch12, 2, 1);
            this.tlpMatch.Controls.Add(this.labMatch11, 1, 1);
            this.tlpMatch.Controls.Add(this.labMatchRes, 4, 0);
            this.tlpMatch.Controls.Add(this.labMatchDraw, 3, 0);
            this.tlpMatch.Controls.Add(this.labMatchLost, 2, 0);
            this.tlpMatch.Controls.Add(this.labMatchWin, 1, 0);
            this.tlpMatch.Controls.Add(this.labMatchPlayer, 0, 0);
            this.tlpMatch.Controls.Add(this.labMatchPlayer1, 0, 1);
            this.tlpMatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMatch.Location = new System.Drawing.Point(0, 23);
            this.tlpMatch.Name = "tlpMatch";
            this.tlpMatch.RowCount = 3;
            this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.31313F));
            this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.36364F));
            this.tlpMatch.Size = new System.Drawing.Size(367, 60);
            this.tlpMatch.TabIndex = 26;
            // 
            // labMatch24
            // 
            this.labMatch24.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatch24.BackColor = System.Drawing.Color.Transparent;
            this.labMatch24.Location = new System.Drawing.Point(296, 38);
            this.labMatch24.Name = "labMatch24";
            this.labMatch24.Size = new System.Drawing.Size(67, 21);
            this.labMatch24.TabIndex = 14;
            this.labMatch24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatch23
            // 
            this.labMatch23.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatch23.BackColor = System.Drawing.Color.Transparent;
            this.labMatch23.Location = new System.Drawing.Point(223, 38);
            this.labMatch23.Name = "labMatch23";
            this.labMatch23.Size = new System.Drawing.Size(66, 21);
            this.labMatch23.TabIndex = 13;
            this.labMatch23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatch22
            // 
            this.labMatch22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatch22.BackColor = System.Drawing.Color.Transparent;
            this.labMatch22.Location = new System.Drawing.Point(150, 38);
            this.labMatch22.Name = "labMatch22";
            this.labMatch22.Size = new System.Drawing.Size(66, 21);
            this.labMatch22.TabIndex = 12;
            this.labMatch22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatch21
            // 
            this.labMatch21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatch21.BackColor = System.Drawing.Color.Transparent;
            this.labMatch21.Location = new System.Drawing.Point(77, 38);
            this.labMatch21.Name = "labMatch21";
            this.labMatch21.Size = new System.Drawing.Size(66, 21);
            this.labMatch21.TabIndex = 11;
            this.labMatch21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatchPlayer2
            // 
            this.labMatchPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatchPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.labMatchPlayer2.Location = new System.Drawing.Point(4, 38);
            this.labMatchPlayer2.Name = "labMatchPlayer2";
            this.labMatchPlayer2.Size = new System.Drawing.Size(66, 21);
            this.labMatchPlayer2.TabIndex = 10;
            this.labMatchPlayer2.Text = "Player 2";
            this.labMatchPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatch14
            // 
            this.labMatch14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatch14.BackColor = System.Drawing.Color.Transparent;
            this.labMatch14.Location = new System.Drawing.Point(296, 20);
            this.labMatch14.Name = "labMatch14";
            this.labMatch14.Size = new System.Drawing.Size(67, 17);
            this.labMatch14.TabIndex = 9;
            this.labMatch14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatch13
            // 
            this.labMatch13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatch13.BackColor = System.Drawing.Color.Transparent;
            this.labMatch13.Location = new System.Drawing.Point(223, 20);
            this.labMatch13.Name = "labMatch13";
            this.labMatch13.Size = new System.Drawing.Size(66, 17);
            this.labMatch13.TabIndex = 8;
            this.labMatch13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatch12
            // 
            this.labMatch12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatch12.BackColor = System.Drawing.Color.Transparent;
            this.labMatch12.Location = new System.Drawing.Point(150, 20);
            this.labMatch12.Name = "labMatch12";
            this.labMatch12.Size = new System.Drawing.Size(66, 17);
            this.labMatch12.TabIndex = 7;
            this.labMatch12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatch11
            // 
            this.labMatch11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatch11.BackColor = System.Drawing.Color.Transparent;
            this.labMatch11.Location = new System.Drawing.Point(77, 20);
            this.labMatch11.Name = "labMatch11";
            this.labMatch11.Size = new System.Drawing.Size(66, 17);
            this.labMatch11.TabIndex = 6;
            this.labMatch11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatchRes
            // 
            this.labMatchRes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatchRes.BackColor = System.Drawing.Color.Transparent;
            this.labMatchRes.Location = new System.Drawing.Point(296, 1);
            this.labMatchRes.Name = "labMatchRes";
            this.labMatchRes.Size = new System.Drawing.Size(67, 18);
            this.labMatchRes.TabIndex = 4;
            this.labMatchRes.Text = "Result";
            this.labMatchRes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatchDraw
            // 
            this.labMatchDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatchDraw.BackColor = System.Drawing.Color.Transparent;
            this.labMatchDraw.Location = new System.Drawing.Point(223, 1);
            this.labMatchDraw.Name = "labMatchDraw";
            this.labMatchDraw.Size = new System.Drawing.Size(66, 18);
            this.labMatchDraw.TabIndex = 3;
            this.labMatchDraw.Text = "Draw";
            this.labMatchDraw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatchLost
            // 
            this.labMatchLost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatchLost.BackColor = System.Drawing.Color.Transparent;
            this.labMatchLost.Location = new System.Drawing.Point(150, 1);
            this.labMatchLost.Name = "labMatchLost";
            this.labMatchLost.Size = new System.Drawing.Size(66, 18);
            this.labMatchLost.TabIndex = 2;
            this.labMatchLost.Text = "Lost";
            this.labMatchLost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatchWin
            // 
            this.labMatchWin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatchWin.BackColor = System.Drawing.Color.Transparent;
            this.labMatchWin.Location = new System.Drawing.Point(77, 1);
            this.labMatchWin.Name = "labMatchWin";
            this.labMatchWin.Size = new System.Drawing.Size(66, 18);
            this.labMatchWin.TabIndex = 1;
            this.labMatchWin.Text = "Win";
            this.labMatchWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatchPlayer
            // 
            this.labMatchPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatchPlayer.BackColor = System.Drawing.Color.Transparent;
            this.labMatchPlayer.Location = new System.Drawing.Point(4, 1);
            this.labMatchPlayer.Name = "labMatchPlayer";
            this.labMatchPlayer.Size = new System.Drawing.Size(66, 18);
            this.labMatchPlayer.TabIndex = 0;
            this.labMatchPlayer.Text = "Player";
            this.labMatchPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatchPlayer1
            // 
            this.labMatchPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMatchPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.labMatchPlayer1.Location = new System.Drawing.Point(4, 20);
            this.labMatchPlayer1.Name = "labMatchPlayer1";
            this.labMatchPlayer1.Size = new System.Drawing.Size(66, 17);
            this.labMatchPlayer1.TabIndex = 5;
            this.labMatchPlayer1.Text = "Player 1";
            this.labMatchPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMatchGames
            // 
            this.labMatchGames.BackColor = System.Drawing.Color.Transparent;
            this.labMatchGames.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labMatchGames.Location = new System.Drawing.Point(0, 467);
            this.labMatchGames.Name = "labMatchGames";
            this.labMatchGames.Size = new System.Drawing.Size(367, 22);
            this.labMatchGames.TabIndex = 23;
            this.labMatchGames.Text = "Games";
            this.labMatchGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butNewMatch
            // 
            this.butNewMatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.butNewMatch.Location = new System.Drawing.Point(0, 0);
            this.butNewMatch.Name = "butNewMatch";
            this.butNewMatch.Size = new System.Drawing.Size(367, 23);
            this.butNewMatch.TabIndex = 22;
            this.butNewMatch.Text = "Start";
            this.toolTip1.SetToolTip(this.butNewMatch, "Clear old results and start new match");
            this.butNewMatch.UseVisualStyleBackColor = true;
            this.butNewMatch.Click += new System.EventHandler(this.bStartMatch_Click);
            // 
            // tabPageTourB
            // 
            this.tabPageTourB.Controls.Add(this.scTourB);
            this.tabPageTourB.Controls.Add(this.button1);
            this.tabPageTourB.Location = new System.Drawing.Point(4, 5);
            this.tabPageTourB.Name = "tabPageTourB";
            this.tabPageTourB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTourB.Size = new System.Drawing.Size(367, 489);
            this.tabPageTourB.TabIndex = 7;
            this.tabPageTourB.Tag = "";
            this.tabPageTourB.Text = "TourB";
            this.tabPageTourB.UseVisualStyleBackColor = true;
            // 
            // scTourB
            // 
            this.scTourB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scTourB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTourB.Location = new System.Drawing.Point(3, 26);
            this.scTourB.MinimumSize = new System.Drawing.Size(100, 100);
            this.scTourB.Name = "scTourB";
            this.scTourB.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scTourB.Panel1
            // 
            this.scTourB.Panel1.Controls.Add(this.scTourBList);
            this.scTourB.Panel1MinSize = 0;
            // 
            // scTourB.Panel2
            // 
            this.scTourB.Panel2.Controls.Add(this.chartTournamentB);
            this.scTourB.Panel2MinSize = 0;
            this.scTourB.Size = new System.Drawing.Size(361, 460);
            this.scTourB.SplitterDistance = 286;
            this.scTourB.TabIndex = 27;
            // 
            // scTourBList
            // 
            this.scTourBList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scTourBList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTourBList.Location = new System.Drawing.Point(0, 0);
            this.scTourBList.Name = "scTourBList";
            this.scTourBList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scTourBList.Panel1
            // 
            this.scTourBList.Panel1.Controls.Add(this.lvTourBList);
            this.scTourBList.Panel1MinSize = 0;
            // 
            // scTourBList.Panel2
            // 
            this.scTourBList.Panel2.Controls.Add(this.lvTourBSel);
            this.scTourBList.Panel2.Controls.Add(this.labBook);
            this.scTourBList.Panel2MinSize = 0;
            this.scTourBList.Size = new System.Drawing.Size(361, 286);
            this.scTourBList.SplitterDistance = 182;
            this.scTourBList.TabIndex = 24;
            this.scTourBList.SizeChanged += new System.EventHandler(this.splitContainer_SizeChanged);
            // 
            // lvTourBList
            // 
            this.lvTourBList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader32,
            this.columnHeader33,
            this.columnHeader34});
            this.lvTourBList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTourBList.FullRowSelect = true;
            this.lvTourBList.GridLines = true;
            this.lvTourBList.HideSelection = false;
            this.lvTourBList.Location = new System.Drawing.Point(0, 0);
            this.lvTourBList.MultiSelect = false;
            this.lvTourBList.Name = "lvTourBList";
            this.lvTourBList.ShowGroups = false;
            this.lvTourBList.Size = new System.Drawing.Size(357, 178);
            this.lvTourBList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvTourBList.TabIndex = 24;
            this.lvTourBList.UseCompatibleStateImageBehavior = false;
            this.lvTourBList.View = System.Windows.Forms.View.Details;
            this.lvTourBList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lvTourBList.SelectedIndexChanged += new System.EventHandler(this.lvTourBList_SelectedIndexChanged);
            this.lvTourBList.Resize += new System.EventHandler(this.lvEngine_Resize);
            // 
            // columnHeader32
            // 
            this.columnHeader32.Tag = "";
            this.columnHeader32.Text = "Book";
            this.columnHeader32.Width = 150;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Tag = "";
            this.columnHeader33.Text = "Elo";
            this.columnHeader33.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader33.Width = 80;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "Changes";
            this.columnHeader34.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lvTourBSel
            // 
            this.lvTourBSel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader35,
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader38});
            this.lvTourBSel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTourBSel.FullRowSelect = true;
            this.lvTourBSel.GridLines = true;
            this.lvTourBSel.HideSelection = false;
            this.lvTourBSel.Location = new System.Drawing.Point(0, 13);
            this.lvTourBSel.MultiSelect = false;
            this.lvTourBSel.Name = "lvTourBSel";
            this.lvTourBSel.ShowGroups = false;
            this.lvTourBSel.Size = new System.Drawing.Size(357, 83);
            this.lvTourBSel.TabIndex = 28;
            this.lvTourBSel.UseCompatibleStateImageBehavior = false;
            this.lvTourBSel.View = System.Windows.Forms.View.Details;
            this.lvTourBSel.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lvTourBSel.Resize += new System.EventHandler(this.lvEngineH_Resize);
            // 
            // columnHeader35
            // 
            this.columnHeader35.Tag = "";
            this.columnHeader35.Text = "Book";
            this.columnHeader35.Width = 140;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "Elo";
            this.columnHeader36.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader36.Width = 50;
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "Games";
            this.columnHeader37.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader37.Width = 50;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "Score";
            this.columnHeader38.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader38.Width = 50;
            // 
            // labBook
            // 
            this.labBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.labBook.Location = new System.Drawing.Point(0, 0);
            this.labBook.Name = "labBook";
            this.labBook.Size = new System.Drawing.Size(357, 13);
            this.labBook.TabIndex = 29;
            this.labBook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labBook, "Select current engine");
            this.labBook.Click += new System.EventHandler(this.labBook_Click);
            // 
            // chartTournamentB
            // 
            this.chartTournamentB.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea3.AxisX.LabelStyle.Enabled = false;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.MajorTickMark.Enabled = false;
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorTickMark.Enabled = false;
            chartArea3.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.Name = "ChartArea1";
            this.chartTournamentB.ChartAreas.Add(chartArea3);
            this.chartTournamentB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTournamentB.Location = new System.Drawing.Point(0, 0);
            this.chartTournamentB.MinimumSize = new System.Drawing.Size(50, 100);
            this.chartTournamentB.Name = "chartTournamentB";
            this.chartTournamentB.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartTournamentB.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Olive,
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))))};
            series3.BorderWidth = 4;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.IsVisibleInLegend = false;
            series3.Name = "Series1";
            series4.BorderWidth = 4;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.IsVisibleInLegend = false;
            series4.Name = "Series2";
            series5.BorderWidth = 4;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.IsVisibleInLegend = false;
            series5.Name = "Series3";
            this.chartTournamentB.Series.Add(series3);
            this.chartTournamentB.Series.Add(series4);
            this.chartTournamentB.Series.Add(series5);
            this.chartTournamentB.Size = new System.Drawing.Size(357, 166);
            this.chartTournamentB.SuppressExceptions = true;
            this.chartTournamentB.TabIndex = 30;
            this.toolTip1.SetToolTip(this.chartTournamentB, "Tournament history");
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(361, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Start";
            this.toolTip1.SetToolTip(this.button1, "Start tournament");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.butStartTournamentB_Click);
            // 
            // tabPageTourE
            // 
            this.tabPageTourE.Controls.Add(this.scTourE);
            this.tabPageTourE.Controls.Add(this.butTourEStart);
            this.tabPageTourE.Location = new System.Drawing.Point(4, 5);
            this.tabPageTourE.Name = "tabPageTourE";
            this.tabPageTourE.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTourE.Size = new System.Drawing.Size(367, 489);
            this.tabPageTourE.TabIndex = 5;
            this.tabPageTourE.Tag = "";
            this.tabPageTourE.Text = "TourE";
            this.tabPageTourE.UseVisualStyleBackColor = true;
            // 
            // scTourE
            // 
            this.scTourE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scTourE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTourE.Location = new System.Drawing.Point(3, 26);
            this.scTourE.Name = "scTourE";
            this.scTourE.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scTourE.Panel1
            // 
            this.scTourE.Panel1.Controls.Add(this.scTourEList);
            this.scTourE.Panel1MinSize = 0;
            // 
            // scTourE.Panel2
            // 
            this.scTourE.Panel2.Controls.Add(this.chartTournamentE);
            this.scTourE.Panel2MinSize = 0;
            this.scTourE.Size = new System.Drawing.Size(361, 460);
            this.scTourE.SplitterDistance = 286;
            this.scTourE.TabIndex = 27;
            // 
            // scTourEList
            // 
            this.scTourEList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scTourEList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTourEList.Location = new System.Drawing.Point(0, 0);
            this.scTourEList.MinimumSize = new System.Drawing.Size(100, 100);
            this.scTourEList.Name = "scTourEList";
            this.scTourEList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scTourEList.Panel1
            // 
            this.scTourEList.Panel1.Controls.Add(this.lvTourEList);
            this.scTourEList.Panel1MinSize = 0;
            // 
            // scTourEList.Panel2
            // 
            this.scTourEList.Panel2.Controls.Add(this.lvTourESel);
            this.scTourEList.Panel2.Controls.Add(this.labEngine);
            this.scTourEList.Panel2MinSize = 0;
            this.scTourEList.Size = new System.Drawing.Size(361, 286);
            this.scTourEList.SplitterDistance = 139;
            this.scTourEList.TabIndex = 24;
            this.scTourEList.SizeChanged += new System.EventHandler(this.splitContainer_SizeChanged);
            // 
            // lvTourEList
            // 
            this.lvTourEList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25});
            this.lvTourEList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTourEList.FullRowSelect = true;
            this.lvTourEList.GridLines = true;
            this.lvTourEList.HideSelection = false;
            this.lvTourEList.Location = new System.Drawing.Point(0, 0);
            this.lvTourEList.MultiSelect = false;
            this.lvTourEList.Name = "lvTourEList";
            this.lvTourEList.ShowGroups = false;
            this.lvTourEList.Size = new System.Drawing.Size(357, 135);
            this.lvTourEList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvTourEList.TabIndex = 24;
            this.lvTourEList.UseCompatibleStateImageBehavior = false;
            this.lvTourEList.View = System.Windows.Forms.View.Details;
            this.lvTourEList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lvTourEList.SelectedIndexChanged += new System.EventHandler(this.lvEngine_SelectedIndexChanged);
            this.lvTourEList.Resize += new System.EventHandler(this.lvEngine_Resize);
            // 
            // columnHeader23
            // 
            this.columnHeader23.Tag = "";
            this.columnHeader23.Text = "Engine";
            this.columnHeader23.Width = 150;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Tag = "";
            this.columnHeader24.Text = "Elo";
            this.columnHeader24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader24.Width = 80;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Games";
            this.columnHeader25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lvTourESel
            // 
            this.lvTourESel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29});
            this.lvTourESel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTourESel.FullRowSelect = true;
            this.lvTourESel.GridLines = true;
            this.lvTourESel.HideSelection = false;
            this.lvTourESel.Location = new System.Drawing.Point(0, 13);
            this.lvTourESel.MultiSelect = false;
            this.lvTourESel.Name = "lvTourESel";
            this.lvTourESel.ShowGroups = false;
            this.lvTourESel.Size = new System.Drawing.Size(357, 126);
            this.lvTourESel.TabIndex = 28;
            this.lvTourESel.UseCompatibleStateImageBehavior = false;
            this.lvTourESel.View = System.Windows.Forms.View.Details;
            this.lvTourESel.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lvTourESel.Resize += new System.EventHandler(this.lvEngineH_Resize);
            // 
            // columnHeader26
            // 
            this.columnHeader26.Tag = "";
            this.columnHeader26.Text = "Engine";
            this.columnHeader26.Width = 140;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Elo";
            this.columnHeader27.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader27.Width = 50;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Games";
            this.columnHeader28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader28.Width = 50;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "Score";
            this.columnHeader29.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader29.Width = 50;
            // 
            // labEngine
            // 
            this.labEngine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labEngine.Dock = System.Windows.Forms.DockStyle.Top;
            this.labEngine.Location = new System.Drawing.Point(0, 0);
            this.labEngine.Name = "labEngine";
            this.labEngine.Size = new System.Drawing.Size(357, 13);
            this.labEngine.TabIndex = 29;
            this.labEngine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labEngine, "Select current engine");
            this.labEngine.Click += new System.EventHandler(this.labEngine_Click);
            // 
            // chartTournamentE
            // 
            this.chartTournamentE.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea4.AxisX.LabelStyle.Enabled = false;
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.MajorTickMark.Enabled = false;
            chartArea4.AxisY.IsStartedFromZero = false;
            chartArea4.AxisY.MajorGrid.Enabled = false;
            chartArea4.AxisY.MajorTickMark.Enabled = false;
            chartArea4.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.Name = "ChartArea1";
            this.chartTournamentE.ChartAreas.Add(chartArea4);
            this.chartTournamentE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTournamentE.Location = new System.Drawing.Point(0, 0);
            this.chartTournamentE.MinimumSize = new System.Drawing.Size(50, 100);
            this.chartTournamentE.Name = "chartTournamentE";
            this.chartTournamentE.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartTournamentE.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Olive,
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))))};
            series6.BorderWidth = 4;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.IsVisibleInLegend = false;
            series6.Name = "Series1";
            series7.BorderWidth = 4;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.IsVisibleInLegend = false;
            series7.Name = "Series2";
            series8.BorderWidth = 4;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.IsVisibleInLegend = false;
            series8.Name = "Series3";
            this.chartTournamentE.Series.Add(series6);
            this.chartTournamentE.Series.Add(series7);
            this.chartTournamentE.Series.Add(series8);
            this.chartTournamentE.Size = new System.Drawing.Size(357, 166);
            this.chartTournamentE.SuppressExceptions = true;
            this.chartTournamentE.TabIndex = 30;
            this.toolTip1.SetToolTip(this.chartTournamentE, "Tournament history");
            // 
            // butTourEStart
            // 
            this.butTourEStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butTourEStart.Dock = System.Windows.Forms.DockStyle.Top;
            this.butTourEStart.Location = new System.Drawing.Point(3, 3);
            this.butTourEStart.Name = "butTourEStart";
            this.butTourEStart.Size = new System.Drawing.Size(361, 23);
            this.butTourEStart.TabIndex = 22;
            this.butTourEStart.Text = "Start";
            this.toolTip1.SetToolTip(this.butTourEStart, "Start tournament");
            this.butTourEStart.UseVisualStyleBackColor = true;
            this.butTourEStart.Click += new System.EventHandler(this.butStartTournamentE_Click);
            // 
            // tabPageTourP
            // 
            this.tabPageTourP.Controls.Add(this.scTourP);
            this.tabPageTourP.Controls.Add(this.butStartTournament);
            this.tabPageTourP.Location = new System.Drawing.Point(4, 5);
            this.tabPageTourP.Name = "tabPageTourP";
            this.tabPageTourP.Size = new System.Drawing.Size(367, 489);
            this.tabPageTourP.TabIndex = 3;
            this.tabPageTourP.Tag = "";
            this.tabPageTourP.Text = "TourP";
            this.tabPageTourP.UseVisualStyleBackColor = true;
            // 
            // scTourP
            // 
            this.scTourP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scTourP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTourP.Location = new System.Drawing.Point(0, 23);
            this.scTourP.Name = "scTourP";
            this.scTourP.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scTourP.Panel1
            // 
            this.scTourP.Panel1.Controls.Add(this.scTourPList);
            this.scTourP.Panel1MinSize = 0;
            // 
            // scTourP.Panel2
            // 
            this.scTourP.Panel2.Controls.Add(this.chartTournamentP);
            this.scTourP.Panel2MinSize = 0;
            this.scTourP.Size = new System.Drawing.Size(367, 466);
            this.scTourP.SplitterDistance = 304;
            this.scTourP.TabIndex = 26;
            // 
            // scTourPList
            // 
            this.scTourPList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scTourPList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTourPList.Location = new System.Drawing.Point(0, 0);
            this.scTourPList.MinimumSize = new System.Drawing.Size(100, 100);
            this.scTourPList.Name = "scTourPList";
            this.scTourPList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scTourPList.Panel1
            // 
            this.scTourPList.Panel1.Controls.Add(this.lvTourPList);
            this.scTourPList.Panel1MinSize = 0;
            // 
            // scTourPList.Panel2
            // 
            this.scTourPList.Panel2.Controls.Add(this.lvTourPSel);
            this.scTourPList.Panel2.Controls.Add(this.labPlayer);
            this.scTourPList.Panel2MinSize = 0;
            this.scTourPList.Size = new System.Drawing.Size(367, 304);
            this.scTourPList.SplitterDistance = 177;
            this.scTourPList.TabIndex = 24;
            this.scTourPList.SizeChanged += new System.EventHandler(this.splitContainer_SizeChanged);
            // 
            // lvTourPList
            // 
            this.lvTourPList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6});
            this.lvTourPList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTourPList.FullRowSelect = true;
            this.lvTourPList.GridLines = true;
            this.lvTourPList.HideSelection = false;
            this.lvTourPList.Location = new System.Drawing.Point(0, 0);
            this.lvTourPList.MultiSelect = false;
            this.lvTourPList.Name = "lvTourPList";
            this.lvTourPList.ShowGroups = false;
            this.lvTourPList.Size = new System.Drawing.Size(363, 173);
            this.lvTourPList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvTourPList.TabIndex = 24;
            this.lvTourPList.UseCompatibleStateImageBehavior = false;
            this.lvTourPList.View = System.Windows.Forms.View.Details;
            this.lvTourPList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lvTourPList.SelectedIndexChanged += new System.EventHandler(this.lvPlayer_SelectedIndexChanged);
            this.lvTourPList.Resize += new System.EventHandler(this.lvEngine_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "";
            this.columnHeader1.Text = "Player";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "";
            this.columnHeader2.Text = "Elo";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Changes";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lvTourPSel
            // 
            this.lvTourPSel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader8,
            this.columnHeader10});
            this.lvTourPSel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTourPSel.FullRowSelect = true;
            this.lvTourPSel.GridLines = true;
            this.lvTourPSel.HideSelection = false;
            this.lvTourPSel.Location = new System.Drawing.Point(0, 13);
            this.lvTourPSel.MultiSelect = false;
            this.lvTourPSel.Name = "lvTourPSel";
            this.lvTourPSel.ShowGroups = false;
            this.lvTourPSel.Size = new System.Drawing.Size(363, 106);
            this.lvTourPSel.TabIndex = 28;
            this.lvTourPSel.UseCompatibleStateImageBehavior = false;
            this.lvTourPSel.View = System.Windows.Forms.View.Details;
            this.lvTourPSel.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lvTourPSel.Resize += new System.EventHandler(this.lvEngineH_Resize);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Tag = "";
            this.columnHeader7.Text = "Player";
            this.columnHeader7.Width = 140;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Elo";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader9.Width = 50;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Games";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 50;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Score";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader10.Width = 50;
            // 
            // labPlayer
            // 
            this.labPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labPlayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.labPlayer.Location = new System.Drawing.Point(0, 0);
            this.labPlayer.Name = "labPlayer";
            this.labPlayer.Size = new System.Drawing.Size(363, 13);
            this.labPlayer.TabIndex = 27;
            this.labPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labPlayer, "Select current player");
            this.labPlayer.Click += new System.EventHandler(this.labPlayer_Click);
            // 
            // chartTournamentP
            // 
            this.chartTournamentP.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea5.AxisX.LabelStyle.Enabled = false;
            chartArea5.AxisX.MajorGrid.Enabled = false;
            chartArea5.AxisX.MajorTickMark.Enabled = false;
            chartArea5.AxisY.IsStartedFromZero = false;
            chartArea5.AxisY.MajorGrid.Enabled = false;
            chartArea5.AxisY.MajorTickMark.Enabled = false;
            chartArea5.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea5.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea5.Name = "ChartArea1";
            this.chartTournamentP.ChartAreas.Add(chartArea5);
            this.chartTournamentP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTournamentP.Location = new System.Drawing.Point(0, 0);
            this.chartTournamentP.MinimumSize = new System.Drawing.Size(50, 100);
            this.chartTournamentP.Name = "chartTournamentP";
            this.chartTournamentP.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartTournamentP.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Olive,
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))))};
            series9.BorderWidth = 4;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.IsVisibleInLegend = false;
            series9.Name = "Series1";
            series10.BorderWidth = 4;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.IsVisibleInLegend = false;
            series10.Name = "Series2";
            series11.BorderWidth = 4;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.IsVisibleInLegend = false;
            series11.Name = "Series3";
            this.chartTournamentP.Series.Add(series9);
            this.chartTournamentP.Series.Add(series10);
            this.chartTournamentP.Series.Add(series11);
            this.chartTournamentP.Size = new System.Drawing.Size(363, 154);
            this.chartTournamentP.SuppressExceptions = true;
            this.chartTournamentP.TabIndex = 31;
            this.chartTournamentP.Text = "chart1";
            this.toolTip1.SetToolTip(this.chartTournamentP, "Tournament history");
            // 
            // butStartTournament
            // 
            this.butStartTournament.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butStartTournament.Dock = System.Windows.Forms.DockStyle.Top;
            this.butStartTournament.Location = new System.Drawing.Point(0, 0);
            this.butStartTournament.Name = "butStartTournament";
            this.butStartTournament.Size = new System.Drawing.Size(367, 23);
            this.butStartTournament.TabIndex = 21;
            this.butStartTournament.Text = "Start";
            this.toolTip1.SetToolTip(this.butStartTournament, "Start tournament");
            this.butStartTournament.UseVisualStyleBackColor = true;
            this.butStartTournament.Click += new System.EventHandler(this.butStartTournamentP_Click);
            // 
            // tabPageTraining
            // 
            this.tabPageTraining.Controls.Add(this.chartTraining);
            this.tabPageTraining.Controls.Add(this.tlpTraining);
            this.tabPageTraining.Controls.Add(this.groupBox4);
            this.tabPageTraining.Controls.Add(this.groupBox3);
            this.tabPageTraining.Controls.Add(this.butTraining);
            this.tabPageTraining.Location = new System.Drawing.Point(4, 5);
            this.tabPageTraining.Name = "tabPageTraining";
            this.tabPageTraining.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTraining.Size = new System.Drawing.Size(367, 489);
            this.tabPageTraining.TabIndex = 1;
            this.tabPageTraining.Text = "Training";
            this.tabPageTraining.UseVisualStyleBackColor = true;
            // 
            // chartTraining
            // 
            this.chartTraining.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea6.AxisX.LabelStyle.Enabled = false;
            chartArea6.AxisX.MajorGrid.Enabled = false;
            chartArea6.AxisX.MajorTickMark.Enabled = false;
            chartArea6.AxisY.MajorGrid.Enabled = false;
            chartArea6.AxisY.MajorTickMark.Enabled = false;
            chartArea6.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea6.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea6.Name = "ChartArea1";
            this.chartTraining.ChartAreas.Add(chartArea6);
            this.chartTraining.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chartTraining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTraining.Location = new System.Drawing.Point(3, 296);
            this.chartTraining.MinimumSize = new System.Drawing.Size(32, 32);
            this.chartTraining.Name = "chartTraining";
            this.chartTraining.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartTraining.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Olive};
            series12.BorderWidth = 4;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.IsVisibleInLegend = false;
            series12.Name = "Series1";
            this.chartTraining.Series.Add(series12);
            this.chartTraining.Size = new System.Drawing.Size(361, 190);
            this.chartTraining.TabIndex = 29;
            this.chartTraining.Text = "chart1";
            this.toolTip1.SetToolTip(this.chartTraining, "Training history");
            this.chartTraining.Click += new System.EventHandler(this.chartTraining_Click);
            // 
            // tlpTraining
            // 
            this.tlpTraining.BackColor = System.Drawing.Color.White;
            this.tlpTraining.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpTraining.ColumnCount = 5;
            this.tlpTraining.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTraining.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTraining.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTraining.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTraining.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTraining.Controls.Add(this.labTrainRes2, 4, 2);
            this.tlpTraining.Controls.Add(this.labTrainDraw2, 3, 2);
            this.tlpTraining.Controls.Add(this.labTrainLost2, 2, 2);
            this.tlpTraining.Controls.Add(this.labTrainWin2, 1, 2);
            this.tlpTraining.Controls.Add(this.labTrainTeacher, 0, 2);
            this.tlpTraining.Controls.Add(this.labTrainRes1, 4, 1);
            this.tlpTraining.Controls.Add(this.labTrainDraw1, 3, 1);
            this.tlpTraining.Controls.Add(this.labTrainLost1, 2, 1);
            this.tlpTraining.Controls.Add(this.labTrainWin1, 1, 1);
            this.tlpTraining.Controls.Add(this.labTrainResult, 4, 0);
            this.tlpTraining.Controls.Add(this.labDraw, 3, 0);
            this.tlpTraining.Controls.Add(this.labTrainLost, 2, 0);
            this.tlpTraining.Controls.Add(this.labTrainWin, 1, 0);
            this.tlpTraining.Controls.Add(this.labTrainPlayer, 0, 0);
            this.tlpTraining.Controls.Add(this.labTrainTrained, 0, 1);
            this.tlpTraining.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTraining.Location = new System.Drawing.Point(3, 236);
            this.tlpTraining.Name = "tlpTraining";
            this.tlpTraining.RowCount = 3;
            this.tlpTraining.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTraining.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTraining.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTraining.Size = new System.Drawing.Size(361, 60);
            this.tlpTraining.TabIndex = 25;
            // 
            // labTrainRes2
            // 
            this.labTrainRes2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainRes2.Location = new System.Drawing.Point(292, 39);
            this.labTrainRes2.Name = "labTrainRes2";
            this.labTrainRes2.Size = new System.Drawing.Size(65, 20);
            this.labTrainRes2.TabIndex = 14;
            this.labTrainRes2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTrainDraw2
            // 
            this.labTrainDraw2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainDraw2.Location = new System.Drawing.Point(220, 39);
            this.labTrainDraw2.Name = "labTrainDraw2";
            this.labTrainDraw2.Size = new System.Drawing.Size(65, 20);
            this.labTrainDraw2.TabIndex = 13;
            this.labTrainDraw2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTrainLost2
            // 
            this.labTrainLost2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainLost2.Location = new System.Drawing.Point(148, 39);
            this.labTrainLost2.Name = "labTrainLost2";
            this.labTrainLost2.Size = new System.Drawing.Size(65, 20);
            this.labTrainLost2.TabIndex = 12;
            this.labTrainLost2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTrainWin2
            // 
            this.labTrainWin2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainWin2.Location = new System.Drawing.Point(76, 39);
            this.labTrainWin2.Name = "labTrainWin2";
            this.labTrainWin2.Size = new System.Drawing.Size(65, 20);
            this.labTrainWin2.TabIndex = 11;
            this.labTrainWin2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTrainTeacher
            // 
            this.labTrainTeacher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainTeacher.Location = new System.Drawing.Point(4, 39);
            this.labTrainTeacher.Name = "labTrainTeacher";
            this.labTrainTeacher.Size = new System.Drawing.Size(65, 20);
            this.labTrainTeacher.TabIndex = 10;
            this.labTrainTeacher.Text = "Teacher";
            this.labTrainTeacher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTrainRes1
            // 
            this.labTrainRes1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainRes1.Location = new System.Drawing.Point(292, 20);
            this.labTrainRes1.Name = "labTrainRes1";
            this.labTrainRes1.Size = new System.Drawing.Size(65, 18);
            this.labTrainRes1.TabIndex = 9;
            this.labTrainRes1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTrainDraw1
            // 
            this.labTrainDraw1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainDraw1.Location = new System.Drawing.Point(220, 20);
            this.labTrainDraw1.Name = "labTrainDraw1";
            this.labTrainDraw1.Size = new System.Drawing.Size(65, 18);
            this.labTrainDraw1.TabIndex = 8;
            this.labTrainDraw1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTrainLost1
            // 
            this.labTrainLost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainLost1.Location = new System.Drawing.Point(148, 20);
            this.labTrainLost1.Name = "labTrainLost1";
            this.labTrainLost1.Size = new System.Drawing.Size(65, 18);
            this.labTrainLost1.TabIndex = 7;
            this.labTrainLost1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTrainWin1
            // 
            this.labTrainWin1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainWin1.Location = new System.Drawing.Point(76, 20);
            this.labTrainWin1.Name = "labTrainWin1";
            this.labTrainWin1.Size = new System.Drawing.Size(65, 18);
            this.labTrainWin1.TabIndex = 6;
            this.labTrainWin1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTrainResult
            // 
            this.labTrainResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainResult.Location = new System.Drawing.Point(292, 1);
            this.labTrainResult.Name = "labTrainResult";
            this.labTrainResult.Size = new System.Drawing.Size(65, 18);
            this.labTrainResult.TabIndex = 4;
            this.labTrainResult.Text = "Result";
            this.labTrainResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labDraw
            // 
            this.labDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labDraw.Location = new System.Drawing.Point(220, 1);
            this.labDraw.Name = "labDraw";
            this.labDraw.Size = new System.Drawing.Size(65, 18);
            this.labDraw.TabIndex = 3;
            this.labDraw.Text = "Draw";
            this.labDraw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTrainLost
            // 
            this.labTrainLost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainLost.Location = new System.Drawing.Point(148, 1);
            this.labTrainLost.Name = "labTrainLost";
            this.labTrainLost.Size = new System.Drawing.Size(65, 18);
            this.labTrainLost.TabIndex = 2;
            this.labTrainLost.Text = "Lost";
            this.labTrainLost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTrainWin
            // 
            this.labTrainWin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainWin.Location = new System.Drawing.Point(76, 1);
            this.labTrainWin.Name = "labTrainWin";
            this.labTrainWin.Size = new System.Drawing.Size(65, 18);
            this.labTrainWin.TabIndex = 1;
            this.labTrainWin.Text = "Win";
            this.labTrainWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTrainPlayer
            // 
            this.labTrainPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainPlayer.Location = new System.Drawing.Point(4, 1);
            this.labTrainPlayer.Name = "labTrainPlayer";
            this.labTrainPlayer.Size = new System.Drawing.Size(65, 18);
            this.labTrainPlayer.TabIndex = 0;
            this.labTrainPlayer.Text = "Player";
            this.labTrainPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTrainTrained
            // 
            this.labTrainTrained.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTrainTrained.Location = new System.Drawing.Point(4, 20);
            this.labTrainTrained.Name = "labTrainTrained";
            this.labTrainTrained.Size = new System.Drawing.Size(65, 18);
            this.labTrainTrained.TabIndex = 5;
            this.labTrainTrained.Text = "Trained";
            this.labTrainTrained.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudTrainer);
            this.groupBox4.Controls.Add(this.cbTrainerMode);
            this.groupBox4.Controls.Add(this.cbTrainerBook);
            this.groupBox4.Controls.Add(this.cbTrainerEngine);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 131);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(361, 105);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trainer";
            // 
            // nudTrainer
            // 
            this.nudTrainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudTrainer.Location = new System.Drawing.Point(3, 79);
            this.nudTrainer.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudTrainer.Name = "nudTrainer";
            this.nudTrainer.Size = new System.Drawing.Size(355, 20);
            this.nudTrainer.TabIndex = 28;
            this.nudTrainer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTrainer.ThousandsSeparator = true;
            this.nudTrainer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbTrainerMode
            // 
            this.cbTrainerMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTrainerMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbTrainerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrainerMode.FormattingEnabled = true;
            this.cbTrainerMode.Items.AddRange(new object[] {
            "Depth",
            "Nodes",
            "Standard",
            "Time"});
            this.cbTrainerMode.Location = new System.Drawing.Point(3, 58);
            this.cbTrainerMode.Name = "cbTrainerMode";
            this.cbTrainerMode.Size = new System.Drawing.Size(355, 21);
            this.cbTrainerMode.Sorted = true;
            this.cbTrainerMode.TabIndex = 30;
            this.toolTip1.SetToolTip(this.cbTrainerMode, "Select mode");
            this.cbTrainerMode.SelectedIndexChanged += new System.EventHandler(this.cbTeacherMode_SelectedIndexChanged);
            // 
            // cbTrainerBook
            // 
            this.cbTrainerBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTrainerBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbTrainerBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrainerBook.FormattingEnabled = true;
            this.cbTrainerBook.Location = new System.Drawing.Point(3, 37);
            this.cbTrainerBook.Name = "cbTrainerBook";
            this.cbTrainerBook.Size = new System.Drawing.Size(355, 21);
            this.cbTrainerBook.Sorted = true;
            this.cbTrainerBook.TabIndex = 26;
            this.toolTip1.SetToolTip(this.cbTrainerBook, "Select chess opening book");
            // 
            // cbTrainerEngine
            // 
            this.cbTrainerEngine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTrainerEngine.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbTrainerEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrainerEngine.Location = new System.Drawing.Point(3, 16);
            this.cbTrainerEngine.Name = "cbTrainerEngine";
            this.cbTrainerEngine.Size = new System.Drawing.Size(355, 21);
            this.cbTrainerEngine.Sorted = true;
            this.cbTrainerEngine.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cbTrainerEngine, "Select engine");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudTrained);
            this.groupBox3.Controls.Add(this.cbTrainedMode);
            this.groupBox3.Controls.Add(this.cbTrainedBook);
            this.groupBox3.Controls.Add(this.cbTrainedEngine);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(361, 105);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trained";
            // 
            // nudTrained
            // 
            this.nudTrained.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudTrained.Location = new System.Drawing.Point(3, 79);
            this.nudTrained.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudTrained.Name = "nudTrained";
            this.nudTrained.Size = new System.Drawing.Size(355, 20);
            this.nudTrained.TabIndex = 27;
            this.nudTrained.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTrained.ThousandsSeparator = true;
            this.nudTrained.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbTrainedMode
            // 
            this.cbTrainedMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTrainedMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbTrainedMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrainedMode.FormattingEnabled = true;
            this.cbTrainedMode.Items.AddRange(new object[] {
            "Depth",
            "Nodes",
            "Standard",
            "Time"});
            this.cbTrainedMode.Location = new System.Drawing.Point(3, 58);
            this.cbTrainedMode.Name = "cbTrainedMode";
            this.cbTrainedMode.Size = new System.Drawing.Size(355, 21);
            this.cbTrainedMode.Sorted = true;
            this.cbTrainedMode.TabIndex = 30;
            this.toolTip1.SetToolTip(this.cbTrainedMode, "Select mode");
            this.cbTrainedMode.SelectedIndexChanged += new System.EventHandler(this.cbTrainedMode_SelectedIndexChanged);
            // 
            // cbTrainedBook
            // 
            this.cbTrainedBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTrainedBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbTrainedBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrainedBook.FormattingEnabled = true;
            this.cbTrainedBook.Location = new System.Drawing.Point(3, 37);
            this.cbTrainedBook.Name = "cbTrainedBook";
            this.cbTrainedBook.Size = new System.Drawing.Size(355, 21);
            this.cbTrainedBook.Sorted = true;
            this.cbTrainedBook.TabIndex = 29;
            this.toolTip1.SetToolTip(this.cbTrainedBook, "Select chess opening book");
            // 
            // cbTrainedEngine
            // 
            this.cbTrainedEngine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTrainedEngine.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbTrainedEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrainedEngine.Location = new System.Drawing.Point(3, 16);
            this.cbTrainedEngine.Name = "cbTrainedEngine";
            this.cbTrainedEngine.Size = new System.Drawing.Size(355, 21);
            this.cbTrainedEngine.Sorted = true;
            this.cbTrainedEngine.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cbTrainedEngine, "Select engine");
            // 
            // butTraining
            // 
            this.butTraining.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butTraining.Dock = System.Windows.Forms.DockStyle.Top;
            this.butTraining.Location = new System.Drawing.Point(3, 3);
            this.butTraining.Name = "butTraining";
            this.butTraining.Size = new System.Drawing.Size(361, 23);
            this.butTraining.TabIndex = 21;
            this.butTraining.Text = "Start";
            this.toolTip1.SetToolTip(this.butTraining, "Start training");
            this.butTraining.UseVisualStyleBackColor = true;
            this.butTraining.Click += new System.EventHandler(this.bStartTraining_Click);
            // 
            // tabPagePuzzle
            // 
            this.tabPagePuzzle.Controls.Add(this.chartPuzzle);
            this.tabPagePuzzle.Controls.Add(this.labPuzzleInfo);
            this.tabPagePuzzle.Controls.Add(this.labPuzzle);
            this.tabPagePuzzle.Controls.Add(this.butHint);
            this.tabPagePuzzle.Controls.Add(this.butPuzzleNext);
            this.tabPagePuzzle.Location = new System.Drawing.Point(4, 5);
            this.tabPagePuzzle.Name = "tabPagePuzzle";
            this.tabPagePuzzle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePuzzle.Size = new System.Drawing.Size(367, 489);
            this.tabPagePuzzle.TabIndex = 8;
            this.tabPagePuzzle.UseVisualStyleBackColor = true;
            // 
            // chartPuzzle
            // 
            this.chartPuzzle.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea7.AxisX.LabelStyle.Enabled = false;
            chartArea7.AxisX.MajorGrid.Enabled = false;
            chartArea7.AxisX.MajorTickMark.Enabled = false;
            chartArea7.AxisY.IsStartedFromZero = false;
            chartArea7.AxisY.MajorGrid.Enabled = false;
            chartArea7.AxisY.MajorTickMark.Enabled = false;
            chartArea7.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea7.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea7.Name = "ChartArea1";
            this.chartPuzzle.ChartAreas.Add(chartArea7);
            this.chartPuzzle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPuzzle.Location = new System.Drawing.Point(3, 82);
            this.chartPuzzle.MinimumSize = new System.Drawing.Size(32, 32);
            this.chartPuzzle.Name = "chartPuzzle";
            this.chartPuzzle.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartPuzzle.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Olive};
            series13.BorderWidth = 4;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.IsVisibleInLegend = false;
            series13.Name = "Series1";
            this.chartPuzzle.Series.Add(series13);
            this.chartPuzzle.Size = new System.Drawing.Size(361, 374);
            this.chartPuzzle.SuppressExceptions = true;
            this.chartPuzzle.TabIndex = 30;
            this.chartPuzzle.Text = "chart1";
            this.toolTip1.SetToolTip(this.chartPuzzle, "User progress history");
            // 
            // labPuzzleInfo
            // 
            this.labPuzzleInfo.BackColor = System.Drawing.Color.DarkRed;
            this.labPuzzleInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labPuzzleInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labPuzzleInfo.ForeColor = System.Drawing.Color.White;
            this.labPuzzleInfo.Location = new System.Drawing.Point(3, 456);
            this.labPuzzleInfo.Name = "labPuzzleInfo";
            this.labPuzzleInfo.Size = new System.Drawing.Size(361, 30);
            this.labPuzzleInfo.TabIndex = 3;
            this.labPuzzleInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labPuzzle
            // 
            this.labPuzzle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labPuzzle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labPuzzle.Location = new System.Drawing.Point(3, 49);
            this.labPuzzle.Name = "labPuzzle";
            this.labPuzzle.Size = new System.Drawing.Size(361, 33);
            this.labPuzzle.TabIndex = 1;
            this.labPuzzle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butHint
            // 
            this.butHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.butHint.Location = new System.Drawing.Point(3, 26);
            this.butHint.Name = "butHint";
            this.butHint.Size = new System.Drawing.Size(361, 23);
            this.butHint.TabIndex = 2;
            this.butHint.Text = "Hint";
            this.butHint.UseVisualStyleBackColor = true;
            this.butHint.Click += new System.EventHandler(this.butHint_Click);
            // 
            // butPuzzleNext
            // 
            this.butPuzzleNext.Dock = System.Windows.Forms.DockStyle.Top;
            this.butPuzzleNext.Location = new System.Drawing.Point(3, 3);
            this.butPuzzleNext.Name = "butPuzzleNext";
            this.butPuzzleNext.Size = new System.Drawing.Size(361, 23);
            this.butPuzzleNext.TabIndex = 0;
            this.butPuzzleNext.Text = "Next";
            this.butPuzzleNext.UseVisualStyleBackColor = true;
            this.butPuzzleNext.Click += new System.EventHandler(this.butPuzzleNext_Click);
            // 
            // tabPageEdit
            // 
            this.tabPageEdit.BackColor = System.Drawing.Color.Transparent;
            this.tabPageEdit.Controls.Add(this.groupBox6);
            this.tabPageEdit.Controls.Add(this.tableLayoutPanel1);
            this.tabPageEdit.Controls.Add(this.groupBox7);
            this.tabPageEdit.Controls.Add(this.groupBox12);
            this.tabPageEdit.Controls.Add(this.panChessState);
            this.tabPageEdit.Controls.Add(this.tlpEdit);
            this.tabPageEdit.Controls.Add(this.tableLayoutPanel3);
            this.tabPageEdit.Location = new System.Drawing.Point(4, 5);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Size = new System.Drawing.Size(367, 489);
            this.tabPageEdit.TabIndex = 4;
            this.tabPageEdit.Text = "Edit";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbEditMoves);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 328);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(367, 161);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Moves";
            // 
            // lbEditMoves
            // 
            this.lbEditMoves.ColumnWidth = 40;
            this.lbEditMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEditMoves.FormattingEnabled = true;
            this.lbEditMoves.Location = new System.Drawing.Point(3, 16);
            this.lbEditMoves.MultiColumn = true;
            this.lbEditMoves.Name = "lbEditMoves";
            this.lbEditMoves.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbEditMoves.Size = new System.Drawing.Size(361, 142);
            this.lbEditMoves.Sorted = true;
            this.lbEditMoves.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 251);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(367, 77);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bAnalysis);
            this.groupBox2.Controls.Add(this.nudMultiPV);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(247, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(117, 71);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MultiPV";
            // 
            // bAnalysis
            // 
            this.bAnalysis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bAnalysis.Location = new System.Drawing.Point(3, 42);
            this.bAnalysis.Name = "bAnalysis";
            this.bAnalysis.Size = new System.Drawing.Size(111, 26);
            this.bAnalysis.TabIndex = 32;
            this.bAnalysis.Tag = "0";
            this.bAnalysis.Text = "Analysis";
            this.bAnalysis.UseVisualStyleBackColor = true;
            this.bAnalysis.Click += new System.EventHandler(this.bAnalysis_Click);
            // 
            // nudMultiPV
            // 
            this.nudMultiPV.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudMultiPV.Location = new System.Drawing.Point(3, 16);
            this.nudMultiPV.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMultiPV.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMultiPV.Name = "nudMultiPV";
            this.nudMultiPV.Size = new System.Drawing.Size(111, 20);
            this.nudMultiPV.TabIndex = 9;
            this.nudMultiPV.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.butMove2);
            this.groupBox5.Controls.Add(this.cbEditEngine2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(125, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(116, 71);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Engine 2";
            // 
            // butMove2
            // 
            this.butMove2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.butMove2.Location = new System.Drawing.Point(3, 42);
            this.butMove2.Name = "butMove2";
            this.butMove2.Size = new System.Drawing.Size(110, 26);
            this.butMove2.TabIndex = 33;
            this.butMove2.Tag = "1";
            this.butMove2.Text = "Move";
            this.butMove2.UseVisualStyleBackColor = true;
            this.butMove2.Click += new System.EventHandler(this.butMove_Click);
            // 
            // cbEditEngine2
            // 
            this.cbEditEngine2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbEditEngine2.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbEditEngine2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditEngine2.Location = new System.Drawing.Point(3, 16);
            this.cbEditEngine2.Name = "cbEditEngine2";
            this.cbEditEngine2.Size = new System.Drawing.Size(110, 21);
            this.cbEditEngine2.Sorted = true;
            this.cbEditEngine2.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cbEditEngine2, "Select engine");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butMove1);
            this.groupBox1.Controls.Add(this.cbEditEngine1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(116, 71);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Engine 1";
            // 
            // butMove1
            // 
            this.butMove1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.butMove1.Location = new System.Drawing.Point(3, 42);
            this.butMove1.Name = "butMove1";
            this.butMove1.Size = new System.Drawing.Size(110, 26);
            this.butMove1.TabIndex = 33;
            this.butMove1.Tag = "0";
            this.butMove1.Text = "Move";
            this.butMove1.UseVisualStyleBackColor = true;
            this.butMove1.Click += new System.EventHandler(this.butMove_Click);
            // 
            // cbEditEngine1
            // 
            this.cbEditEngine1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbEditEngine1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbEditEngine1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditEngine1.Location = new System.Drawing.Point(3, 16);
            this.cbEditEngine1.Name = "cbEditEngine1";
            this.cbEditEngine1.Size = new System.Drawing.Size(110, 21);
            this.cbEditEngine1.Sorted = true;
            this.cbEditEngine1.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cbEditEngine1, "Select engine");
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbApply);
            this.groupBox7.Controls.Add(this.bPlay);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(0, 209);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox7.Size = new System.Drawing.Size(367, 42);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Apply";
            // 
            // cbApply
            // 
            this.cbApply.BackColor = System.Drawing.SystemColors.Window;
            this.cbApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbApply.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbApply.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbApply.Items.AddRange(new object[] {
            "None",
            "Game",
            "Match",
            "Tournament-books",
            "Tournament-engines",
            "Tournament-players",
            "Training"});
            this.cbApply.Location = new System.Drawing.Point(3, 16);
            this.cbApply.Name = "cbApply";
            this.cbApply.Size = new System.Drawing.Size(285, 24);
            this.cbApply.TabIndex = 12;
            this.toolTip1.SetToolTip(this.cbApply, "The mode in which to apply edited posiiton ");
            // 
            // bPlay
            // 
            this.bPlay.Dock = System.Windows.Forms.DockStyle.Right;
            this.bPlay.Location = new System.Drawing.Point(288, 16);
            this.bPlay.Name = "bPlay";
            this.bPlay.Size = new System.Drawing.Size(76, 23);
            this.bPlay.TabIndex = 13;
            this.bPlay.Text = "Play";
            this.bPlay.UseVisualStyleBackColor = true;
            this.bPlay.Click += new System.EventHandler(this.bPlay_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.tbFen);
            this.groupBox12.Controls.Add(this.butUpdate);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox12.Location = new System.Drawing.Point(0, 167);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(367, 42);
            this.groupBox12.TabIndex = 6;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Fen";
            // 
            // tbFen
            // 
            this.tbFen.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbFen.Location = new System.Drawing.Point(3, 16);
            this.tbFen.Name = "tbFen";
            this.tbFen.Size = new System.Drawing.Size(285, 20);
            this.tbFen.TabIndex = 0;
            // 
            // butUpdate
            // 
            this.butUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.butUpdate.Location = new System.Drawing.Point(288, 16);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(76, 23);
            this.butUpdate.TabIndex = 5;
            this.butUpdate.Text = "Show";
            this.toolTip1.SetToolTip(this.butUpdate, "Start new game from current position");
            this.butUpdate.UseVisualStyleBackColor = true;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            // 
            // panChessState
            // 
            this.panChessState.Controls.Add(this.groupBox8);
            this.panChessState.Controls.Add(this.gbToMove);
            this.panChessState.Controls.Add(this.tableLayoutPanel2);
            this.panChessState.Dock = System.Windows.Forms.DockStyle.Top;
            this.panChessState.Location = new System.Drawing.Point(0, 61);
            this.panChessState.Name = "panChessState";
            this.panChessState.Size = new System.Drawing.Size(367, 106);
            this.panChessState.TabIndex = 16;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.clbCastling);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(76, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(291, 55);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Castling possibilities";
            // 
            // clbCastling
            // 
            this.clbCastling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbCastling.FormattingEnabled = true;
            this.clbCastling.Items.AddRange(new object[] {
            "White king",
            "White queen",
            "Black king",
            "Black queen"});
            this.clbCastling.Location = new System.Drawing.Point(3, 16);
            this.clbCastling.MultiColumn = true;
            this.clbCastling.Name = "clbCastling";
            this.clbCastling.Size = new System.Drawing.Size(285, 36);
            this.clbCastling.TabIndex = 0;
            this.clbCastling.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCastling_ItemCheck);
            // 
            // gbToMove
            // 
            this.gbToMove.Controls.Add(this.rbBlack);
            this.gbToMove.Controls.Add(this.rbWhite);
            this.gbToMove.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbToMove.Location = new System.Drawing.Point(0, 0);
            this.gbToMove.Name = "gbToMove";
            this.gbToMove.Size = new System.Drawing.Size(76, 55);
            this.gbToMove.TabIndex = 5;
            this.gbToMove.TabStop = false;
            this.gbToMove.Text = "To move";
            // 
            // rbBlack
            // 
            this.rbBlack.AutoSize = true;
            this.rbBlack.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbBlack.Location = new System.Drawing.Point(3, 33);
            this.rbBlack.Name = "rbBlack";
            this.rbBlack.Size = new System.Drawing.Size(70, 17);
            this.rbBlack.TabIndex = 1;
            this.rbBlack.Text = "Black";
            this.rbBlack.UseVisualStyleBackColor = true;
            // 
            // rbWhite
            // 
            this.rbWhite.AutoSize = true;
            this.rbWhite.Checked = true;
            this.rbWhite.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbWhite.Location = new System.Drawing.Point(3, 16);
            this.rbWhite.Name = "rbWhite";
            this.rbWhite.Size = new System.Drawing.Size(70, 17);
            this.rbWhite.TabIndex = 0;
            this.rbWhite.TabStop = true;
            this.rbWhite.Text = "White";
            this.rbWhite.UseVisualStyleBackColor = true;
            this.rbWhite.CheckedChanged += new System.EventHandler(this.rbWhite_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox13, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox14, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox15, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 55);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(367, 51);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.nudMove);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox13.Location = new System.Drawing.Point(247, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox13.Size = new System.Drawing.Size(117, 45);
            this.groupBox13.TabIndex = 13;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Move";
            // 
            // nudMove
            // 
            this.nudMove.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudMove.Location = new System.Drawing.Point(3, 16);
            this.nudMove.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMove.Name = "nudMove";
            this.nudMove.Size = new System.Drawing.Size(111, 20);
            this.nudMove.TabIndex = 9;
            this.nudMove.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMove.ValueChanged += new System.EventHandler(this.nudMove_ValueChanged);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.nudReversible);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox14.Location = new System.Drawing.Point(125, 3);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox14.Size = new System.Drawing.Size(116, 45);
            this.groupBox14.TabIndex = 12;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Reversible half moves";
            // 
            // nudReversible
            // 
            this.nudReversible.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudReversible.Location = new System.Drawing.Point(3, 16);
            this.nudReversible.Name = "nudReversible";
            this.nudReversible.Size = new System.Drawing.Size(110, 20);
            this.nudReversible.TabIndex = 9;
            this.nudReversible.ValueChanged += new System.EventHandler(this.nudReversible_ValueChanged);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.cbPassant);
            this.groupBox15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox15.Location = new System.Drawing.Point(3, 3);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox15.Size = new System.Drawing.Size(116, 45);
            this.groupBox15.TabIndex = 11;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "En passant square";
            // 
            // cbPassant
            // 
            this.cbPassant.BackColor = System.Drawing.SystemColors.Window;
            this.cbPassant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPassant.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbPassant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPassant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbPassant.Items.AddRange(new object[] {
            "-",
            "a3",
            "a6",
            "b3",
            "b6",
            "c3",
            "c6",
            "d3",
            "d6",
            "e3",
            "e6",
            "f3",
            "f6",
            "g3",
            "g6",
            "h3",
            "h6"});
            this.cbPassant.Location = new System.Drawing.Point(3, 16);
            this.cbPassant.Name = "cbPassant";
            this.cbPassant.Size = new System.Drawing.Size(110, 24);
            this.cbPassant.TabIndex = 12;
            this.toolTip1.SetToolTip(this.cbPassant, "Select en passant square");
            this.cbPassant.SelectedIndexChanged += new System.EventHandler(this.cbPassant_SelectedIndexChanged);
            // 
            // tlpEdit
            // 
            this.tlpEdit.AutoSize = true;
            this.tlpEdit.BackColor = System.Drawing.Color.Transparent;
            this.tlpEdit.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tlpEdit.ColumnCount = 6;
            this.tlpEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpEdit.Controls.Add(this.lab_bk, 5, 1);
            this.tlpEdit.Controls.Add(this.lab_bq, 4, 1);
            this.tlpEdit.Controls.Add(this.lab_br, 3, 1);
            this.tlpEdit.Controls.Add(this.lab_bb, 2, 1);
            this.tlpEdit.Controls.Add(this.lab_bn, 1, 1);
            this.tlpEdit.Controls.Add(this.lab_bp, 0, 1);
            this.tlpEdit.Controls.Add(this.lab_K, 5, 0);
            this.tlpEdit.Controls.Add(this.lab_Q, 4, 0);
            this.tlpEdit.Controls.Add(this.lab_R, 3, 0);
            this.tlpEdit.Controls.Add(this.lab_B, 2, 0);
            this.tlpEdit.Controls.Add(this.lab_N, 1, 0);
            this.tlpEdit.Controls.Add(this.lab_P, 0, 0);
            this.tlpEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tlpEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpEdit.Location = new System.Drawing.Point(0, 26);
            this.tlpEdit.Name = "tlpEdit";
            this.tlpEdit.RowCount = 2;
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEdit.Size = new System.Drawing.Size(367, 35);
            this.tlpEdit.TabIndex = 12;
            // 
            // lab_bk
            // 
            this.lab_bk.AutoSize = true;
            this.lab_bk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_bk.Location = new System.Drawing.Point(306, 19);
            this.lab_bk.Name = "lab_bk";
            this.lab_bk.Size = new System.Drawing.Size(55, 13);
            this.lab_bk.TabIndex = 11;
            this.lab_bk.Text = "k";
            this.lab_bk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_bk.Click += new System.EventHandler(this.editLabel_Click);
            // 
            // lab_bq
            // 
            this.lab_bq.AutoSize = true;
            this.lab_bq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_bq.Location = new System.Drawing.Point(246, 19);
            this.lab_bq.Name = "lab_bq";
            this.lab_bq.Size = new System.Drawing.Size(51, 13);
            this.lab_bq.TabIndex = 10;
            this.lab_bq.Text = "q";
            this.lab_bq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_bq.Click += new System.EventHandler(this.editLabel_Click);
            // 
            // lab_br
            // 
            this.lab_br.AutoSize = true;
            this.lab_br.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_br.Location = new System.Drawing.Point(186, 19);
            this.lab_br.Name = "lab_br";
            this.lab_br.Size = new System.Drawing.Size(51, 13);
            this.lab_br.TabIndex = 9;
            this.lab_br.Text = "r";
            this.lab_br.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_br.Click += new System.EventHandler(this.editLabel_Click);
            // 
            // lab_bb
            // 
            this.lab_bb.AutoSize = true;
            this.lab_bb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_bb.Location = new System.Drawing.Point(126, 19);
            this.lab_bb.Name = "lab_bb";
            this.lab_bb.Size = new System.Drawing.Size(51, 13);
            this.lab_bb.TabIndex = 8;
            this.lab_bb.Text = "b";
            this.lab_bb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_bb.Click += new System.EventHandler(this.editLabel_Click);
            // 
            // lab_bn
            // 
            this.lab_bn.AutoSize = true;
            this.lab_bn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_bn.Location = new System.Drawing.Point(66, 19);
            this.lab_bn.Name = "lab_bn";
            this.lab_bn.Size = new System.Drawing.Size(51, 13);
            this.lab_bn.TabIndex = 7;
            this.lab_bn.Text = "n";
            this.lab_bn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_bn.Click += new System.EventHandler(this.editLabel_Click);
            // 
            // lab_bp
            // 
            this.lab_bp.AutoSize = true;
            this.lab_bp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_bp.Location = new System.Drawing.Point(6, 19);
            this.lab_bp.Name = "lab_bp";
            this.lab_bp.Size = new System.Drawing.Size(51, 13);
            this.lab_bp.TabIndex = 6;
            this.lab_bp.Text = "p";
            this.lab_bp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_bp.Click += new System.EventHandler(this.editLabel_Click);
            // 
            // lab_K
            // 
            this.lab_K.AutoSize = true;
            this.lab_K.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_K.Location = new System.Drawing.Point(306, 3);
            this.lab_K.Name = "lab_K";
            this.lab_K.Size = new System.Drawing.Size(55, 13);
            this.lab_K.TabIndex = 5;
            this.lab_K.Text = "K";
            this.lab_K.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_K.Click += new System.EventHandler(this.editLabel_Click);
            // 
            // lab_Q
            // 
            this.lab_Q.AutoSize = true;
            this.lab_Q.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_Q.Location = new System.Drawing.Point(246, 3);
            this.lab_Q.Name = "lab_Q";
            this.lab_Q.Size = new System.Drawing.Size(51, 13);
            this.lab_Q.TabIndex = 4;
            this.lab_Q.Text = "Q";
            this.lab_Q.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_Q.Click += new System.EventHandler(this.editLabel_Click);
            // 
            // lab_R
            // 
            this.lab_R.AutoSize = true;
            this.lab_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_R.Location = new System.Drawing.Point(186, 3);
            this.lab_R.Name = "lab_R";
            this.lab_R.Size = new System.Drawing.Size(51, 13);
            this.lab_R.TabIndex = 3;
            this.lab_R.Text = "R";
            this.lab_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_R.Click += new System.EventHandler(this.editLabel_Click);
            // 
            // lab_B
            // 
            this.lab_B.AutoSize = true;
            this.lab_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_B.Location = new System.Drawing.Point(126, 3);
            this.lab_B.Name = "lab_B";
            this.lab_B.Size = new System.Drawing.Size(51, 13);
            this.lab_B.TabIndex = 2;
            this.lab_B.Text = "B";
            this.lab_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_B.Click += new System.EventHandler(this.editLabel_Click);
            // 
            // lab_N
            // 
            this.lab_N.AutoSize = true;
            this.lab_N.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_N.Location = new System.Drawing.Point(66, 3);
            this.lab_N.Name = "lab_N";
            this.lab_N.Size = new System.Drawing.Size(51, 13);
            this.lab_N.TabIndex = 1;
            this.lab_N.Text = "N";
            this.lab_N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_N.Click += new System.EventHandler(this.editLabel_Click);
            // 
            // lab_P
            // 
            this.lab_P.AutoSize = true;
            this.lab_P.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_P.Location = new System.Drawing.Point(6, 3);
            this.lab_P.Name = "lab_P";
            this.lab_P.Size = new System.Drawing.Size(51, 13);
            this.lab_P.TabIndex = 0;
            this.lab_P.Text = "P";
            this.lab_P.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_P.Click += new System.EventHandler(this.editLabel_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.butBoardRotate, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.butBoardClear, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.butBoardDefault, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(367, 26);
            this.tableLayoutPanel3.TabIndex = 29;
            // 
            // butBoardRotate
            // 
            this.butBoardRotate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butBoardRotate.Location = new System.Drawing.Point(247, 3);
            this.butBoardRotate.Name = "butBoardRotate";
            this.butBoardRotate.Size = new System.Drawing.Size(117, 20);
            this.butBoardRotate.TabIndex = 6;
            this.butBoardRotate.Text = "Rotate";
            this.toolTip1.SetToolTip(this.butBoardRotate, "Remove all pieces");
            this.butBoardRotate.UseVisualStyleBackColor = true;
            this.butBoardRotate.Click += new System.EventHandler(this.butBoardRotate_Click);
            // 
            // butBoardClear
            // 
            this.butBoardClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butBoardClear.Location = new System.Drawing.Point(125, 3);
            this.butBoardClear.Name = "butBoardClear";
            this.butBoardClear.Size = new System.Drawing.Size(116, 20);
            this.butBoardClear.TabIndex = 5;
            this.butBoardClear.Text = "Clear";
            this.toolTip1.SetToolTip(this.butBoardClear, "Remove all pieces");
            this.butBoardClear.UseVisualStyleBackColor = true;
            this.butBoardClear.Click += new System.EventHandler(this.butClearBoard_Click);
            // 
            // butBoardDefault
            // 
            this.butBoardDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butBoardDefault.Location = new System.Drawing.Point(3, 3);
            this.butBoardDefault.Name = "butBoardDefault";
            this.butBoardDefault.Size = new System.Drawing.Size(116, 20);
            this.butBoardDefault.TabIndex = 4;
            this.butBoardDefault.Text = "Default";
            this.toolTip1.SetToolTip(this.butBoardDefault, "Put the chess pieces in the starting position");
            this.butBoardDefault.UseVisualStyleBackColor = true;
            this.butBoardDefault.Click += new System.EventHandler(this.butDefault_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.logToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.listsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(500, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.editToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.fileToolStripMenuItem.Text = "Position";
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.clipboardToolStripMenuItem1,
            this.lastToolStripMenuItem,
            this.pgnToolStripMenuItem1});
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.fileToolStripMenuItem1.Text = "File";
            this.fileToolStripMenuItem1.Click += new System.EventHandler(this.fileToolStripMenuItem1_Click);
            // 
            // clipboardToolStripMenuItem1
            // 
            this.clipboardToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fenToolStripMenuItem,
            this.pgnToolStripMenuItem,
            this.uciToolStripMenuItem2});
            this.clipboardToolStripMenuItem1.Name = "clipboardToolStripMenuItem1";
            this.clipboardToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.clipboardToolStripMenuItem1.Text = "Clipboard";
            // 
            // fenToolStripMenuItem
            // 
            this.fenToolStripMenuItem.Name = "fenToolStripMenuItem";
            this.fenToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.fenToolStripMenuItem.Text = "Fen";
            this.fenToolStripMenuItem.Click += new System.EventHandler(this.fenToolStripMenuItem_Click);
            // 
            // pgnToolStripMenuItem
            // 
            this.pgnToolStripMenuItem.Name = "pgnToolStripMenuItem";
            this.pgnToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.pgnToolStripMenuItem.Text = "Pgn";
            this.pgnToolStripMenuItem.Click += new System.EventHandler(this.pgnToolStripMenuItem_Click);
            // 
            // uciToolStripMenuItem2
            // 
            this.uciToolStripMenuItem2.Name = "uciToolStripMenuItem2";
            this.uciToolStripMenuItem2.Size = new System.Drawing.Size(95, 22);
            this.uciToolStripMenuItem2.Text = "Uci";
            this.uciToolStripMenuItem2.Click += new System.EventHandler(this.uciToolStripMenuItem2_Click);
            // 
            // lastToolStripMenuItem
            // 
            this.lastToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.matchToolStripMenuItem,
            this.tournamentbooksToolStripMenuItem,
            this.tournamentenginesToolStripMenuItem,
            this.tournamentplayersToolStripMenuItem,
            this.trainingToolStripMenuItem,
            this.toolStripMenuItem3,
            this.errorToolStripMenuItem});
            this.lastToolStripMenuItem.Name = "lastToolStripMenuItem";
            this.lastToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.lastToolStripMenuItem.Text = "Last";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.gameToolStripMenuItem.Text = "Game";
            this.gameToolStripMenuItem.Click += new System.EventHandler(this.lastHisLoad_Click);
            // 
            // matchToolStripMenuItem
            // 
            this.matchToolStripMenuItem.Name = "matchToolStripMenuItem";
            this.matchToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.matchToolStripMenuItem.Text = "Match";
            this.matchToolStripMenuItem.Click += new System.EventHandler(this.lastHisLoad_Click);
            // 
            // tournamentbooksToolStripMenuItem
            // 
            this.tournamentbooksToolStripMenuItem.Name = "tournamentbooksToolStripMenuItem";
            this.tournamentbooksToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.tournamentbooksToolStripMenuItem.Text = "Tournament-books";
            this.tournamentbooksToolStripMenuItem.Click += new System.EventHandler(this.lastHisLoad_Click);
            // 
            // tournamentenginesToolStripMenuItem
            // 
            this.tournamentenginesToolStripMenuItem.Name = "tournamentenginesToolStripMenuItem";
            this.tournamentenginesToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.tournamentenginesToolStripMenuItem.Text = "Tournament-engines";
            this.tournamentenginesToolStripMenuItem.Click += new System.EventHandler(this.lastHisLoad_Click);
            // 
            // tournamentplayersToolStripMenuItem
            // 
            this.tournamentplayersToolStripMenuItem.Name = "tournamentplayersToolStripMenuItem";
            this.tournamentplayersToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.tournamentplayersToolStripMenuItem.Text = "Tournament-players";
            this.tournamentplayersToolStripMenuItem.Click += new System.EventHandler(this.lastHisLoad_Click);
            // 
            // trainingToolStripMenuItem
            // 
            this.trainingToolStripMenuItem.Name = "trainingToolStripMenuItem";
            this.trainingToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.trainingToolStripMenuItem.Text = "Training";
            this.trainingToolStripMenuItem.Click += new System.EventHandler(this.lastHisLoad_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(182, 6);
            // 
            // errorToolStripMenuItem
            // 
            this.errorToolStripMenuItem.Name = "errorToolStripMenuItem";
            this.errorToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.errorToolStripMenuItem.Text = "Error";
            this.errorToolStripMenuItem.Click += new System.EventHandler(this.lastHisLoad_Click);
            // 
            // pgnToolStripMenuItem1
            // 
            this.pgnToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem1,
            this.matchToolStripMenuItem1,
            this.tournamentbooksToolStripMenuItem1,
            this.tournamentToolStripMenuItem,
            this.tournamentplayersToolStripMenuItem1,
            this.trainingToolStripMenuItem1,
            this.toolStripMenuItem4,
            this.errorToolStripMenuItem1});
            this.pgnToolStripMenuItem1.Name = "pgnToolStripMenuItem1";
            this.pgnToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.pgnToolStripMenuItem1.Text = "Pgn";
            // 
            // gameToolStripMenuItem1
            // 
            this.gameToolStripMenuItem1.Name = "gameToolStripMenuItem1";
            this.gameToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.gameToolStripMenuItem1.Text = "Game";
            this.gameToolStripMenuItem1.Click += new System.EventHandler(this.gameToolStripMenuItem1_Click);
            // 
            // matchToolStripMenuItem1
            // 
            this.matchToolStripMenuItem1.Name = "matchToolStripMenuItem1";
            this.matchToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.matchToolStripMenuItem1.Text = "Match";
            this.matchToolStripMenuItem1.Click += new System.EventHandler(this.gameToolStripMenuItem1_Click);
            // 
            // tournamentbooksToolStripMenuItem1
            // 
            this.tournamentbooksToolStripMenuItem1.Name = "tournamentbooksToolStripMenuItem1";
            this.tournamentbooksToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.tournamentbooksToolStripMenuItem1.Text = "Tournament-books";
            this.tournamentbooksToolStripMenuItem1.Click += new System.EventHandler(this.gameToolStripMenuItem1_Click);
            // 
            // tournamentToolStripMenuItem
            // 
            this.tournamentToolStripMenuItem.Name = "tournamentToolStripMenuItem";
            this.tournamentToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.tournamentToolStripMenuItem.Text = "Tournament-engines";
            this.tournamentToolStripMenuItem.Click += new System.EventHandler(this.gameToolStripMenuItem1_Click);
            // 
            // tournamentplayersToolStripMenuItem1
            // 
            this.tournamentplayersToolStripMenuItem1.Name = "tournamentplayersToolStripMenuItem1";
            this.tournamentplayersToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.tournamentplayersToolStripMenuItem1.Text = "Tournament-players";
            this.tournamentplayersToolStripMenuItem1.Click += new System.EventHandler(this.gameToolStripMenuItem1_Click);
            // 
            // trainingToolStripMenuItem1
            // 
            this.trainingToolStripMenuItem1.Name = "trainingToolStripMenuItem1";
            this.trainingToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.trainingToolStripMenuItem1.Text = "Training";
            this.trainingToolStripMenuItem1.Click += new System.EventHandler(this.gameToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(182, 6);
            // 
            // errorToolStripMenuItem1
            // 
            this.errorToolStripMenuItem1.Name = "errorToolStripMenuItem1";
            this.errorToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.errorToolStripMenuItem1.Text = "Error";
            this.errorToolStripMenuItem1.Click += new System.EventHandler(this.gameToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem2,
            this.clipboardToolStripMenuItem2,
            this.puzzleToolStripMenuItem});
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            // 
            // fileToolStripMenuItem2
            // 
            this.fileToolStripMenuItem2.Name = "fileToolStripMenuItem2";
            this.fileToolStripMenuItem2.Size = new System.Drawing.Size(126, 22);
            this.fileToolStripMenuItem2.Text = "File";
            this.fileToolStripMenuItem2.Click += new System.EventHandler(this.fileToolStripMenuItem2_Click);
            // 
            // clipboardToolStripMenuItem2
            // 
            this.clipboardToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fenToolStripMenuItem3,
            this.pgnToolStripMenuItem3,
            this.uciToolStripMenuItem3});
            this.clipboardToolStripMenuItem2.Name = "clipboardToolStripMenuItem2";
            this.clipboardToolStripMenuItem2.Size = new System.Drawing.Size(126, 22);
            this.clipboardToolStripMenuItem2.Text = "Clipboard";
            // 
            // fenToolStripMenuItem3
            // 
            this.fenToolStripMenuItem3.Name = "fenToolStripMenuItem3";
            this.fenToolStripMenuItem3.Size = new System.Drawing.Size(95, 22);
            this.fenToolStripMenuItem3.Text = "Fen";
            this.fenToolStripMenuItem3.Click += new System.EventHandler(this.fenToolStripMenuItem3_Click);
            // 
            // pgnToolStripMenuItem3
            // 
            this.pgnToolStripMenuItem3.Name = "pgnToolStripMenuItem3";
            this.pgnToolStripMenuItem3.Size = new System.Drawing.Size(95, 22);
            this.pgnToolStripMenuItem3.Text = "Pgn";
            this.pgnToolStripMenuItem3.Click += new System.EventHandler(this.pgnToolStripMenuItem3_Click);
            // 
            // uciToolStripMenuItem3
            // 
            this.uciToolStripMenuItem3.Name = "uciToolStripMenuItem3";
            this.uciToolStripMenuItem3.Size = new System.Drawing.Size(95, 22);
            this.uciToolStripMenuItem3.Text = "Uci";
            this.uciToolStripMenuItem3.Click += new System.EventHandler(this.uciToolStripMenuItem3_Click);
            // 
            // puzzleToolStripMenuItem
            // 
            this.puzzleToolStripMenuItem.Name = "puzzleToolStripMenuItem";
            this.puzzleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.puzzleToolStripMenuItem.Text = "Puzzle";
            this.puzzleToolStripMenuItem.Click += new System.EventHandler(this.puzzleToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.booksToolStripMenuItem1,
            this.enginesToolStripMenuItem,
            this.playersToolStripMenuItem1});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.manageToolStripMenuItem.Text = "Manager";
            // 
            // booksToolStripMenuItem1
            // 
            this.booksToolStripMenuItem1.Name = "booksToolStripMenuItem1";
            this.booksToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.booksToolStripMenuItem1.Text = "Books";
            this.booksToolStripMenuItem1.Click += new System.EventHandler(this.booksToolStripMenuItem1_Click);
            // 
            // enginesToolStripMenuItem
            // 
            this.enginesToolStripMenuItem.Name = "enginesToolStripMenuItem";
            this.enginesToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.enginesToolStripMenuItem.Text = "Engines";
            this.enginesToolStripMenuItem.Click += new System.EventHandler(this.enginesToolStripMenuItem_Click);
            // 
            // playersToolStripMenuItem1
            // 
            this.playersToolStripMenuItem1.Name = "playersToolStripMenuItem1";
            this.playersToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.playersToolStripMenuItem1.Text = "Players";
            this.playersToolStripMenuItem1.Click += new System.EventHandler(this.playersToolStripMenuItem1_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programLogToolStripMenuItem,
            this.gamesToolStripMenuItem,
            this.enginesToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.lastGameToolStripMenuItem,
            this.lastMatchToolStripMenuItem,
            this.lastTournamentbooksToolStripMenuItem,
            this.lasstTournamentenginesToolStripMenuItem,
            this.lastTournamentplayersToolStripMenuItem,
            this.lastTrainingToolStripMenuItem,
            this.lastErrorToolStripMenuItem,
            this.lastTimeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.autoToolStripMenuItem,
            this.lastAutodetectToolStripMenuItem});
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.logToolStripMenuItem.Text = "Logs";
            // 
            // programLogToolStripMenuItem
            // 
            this.programLogToolStripMenuItem.Name = "programLogToolStripMenuItem";
            this.programLogToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.programLogToolStripMenuItem.Text = "Application";
            this.programLogToolStripMenuItem.Click += new System.EventHandler(this.programLogToolStripMenuItem_Click);
            // 
            // gamesToolStripMenuItem
            // 
            this.gamesToolStripMenuItem.Name = "gamesToolStripMenuItem";
            this.gamesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.gamesToolStripMenuItem.Text = "Game";
            this.gamesToolStripMenuItem.Click += new System.EventHandler(this.gamesToolStripMenuItem_Click);
            // 
            // enginesToolStripMenuItem1
            // 
            this.enginesToolStripMenuItem1.Name = "enginesToolStripMenuItem1";
            this.enginesToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.enginesToolStripMenuItem1.Text = "Engines";
            this.enginesToolStripMenuItem1.Click += new System.EventHandler(this.enginesToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(209, 6);
            // 
            // lastGameToolStripMenuItem
            // 
            this.lastGameToolStripMenuItem.Name = "lastGameToolStripMenuItem";
            this.lastGameToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.lastGameToolStripMenuItem.Text = "Last game";
            this.lastGameToolStripMenuItem.Click += new System.EventHandler(this.lastGameToolStripMenuItem_Click);
            // 
            // lastMatchToolStripMenuItem
            // 
            this.lastMatchToolStripMenuItem.Name = "lastMatchToolStripMenuItem";
            this.lastMatchToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.lastMatchToolStripMenuItem.Text = "Last match";
            this.lastMatchToolStripMenuItem.Click += new System.EventHandler(this.lastMatchToolStripMenuItem_Click);
            // 
            // lastTournamentbooksToolStripMenuItem
            // 
            this.lastTournamentbooksToolStripMenuItem.Name = "lastTournamentbooksToolStripMenuItem";
            this.lastTournamentbooksToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.lastTournamentbooksToolStripMenuItem.Text = "Last tournament-books";
            this.lastTournamentbooksToolStripMenuItem.Click += new System.EventHandler(this.lastTournamentbooksToolStripMenuItem_Click);
            // 
            // lasstTournamentenginesToolStripMenuItem
            // 
            this.lasstTournamentenginesToolStripMenuItem.Name = "lasstTournamentenginesToolStripMenuItem";
            this.lasstTournamentenginesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.lasstTournamentenginesToolStripMenuItem.Text = "Lasst tournament-engines";
            this.lasstTournamentenginesToolStripMenuItem.Click += new System.EventHandler(this.lasstTournamentenginesToolStripMenuItem_Click);
            // 
            // lastTournamentplayersToolStripMenuItem
            // 
            this.lastTournamentplayersToolStripMenuItem.Name = "lastTournamentplayersToolStripMenuItem";
            this.lastTournamentplayersToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.lastTournamentplayersToolStripMenuItem.Text = "Last tournament-players";
            this.lastTournamentplayersToolStripMenuItem.Click += new System.EventHandler(this.lastTournamentplayersToolStripMenuItem_Click);
            // 
            // lastTrainingToolStripMenuItem
            // 
            this.lastTrainingToolStripMenuItem.Name = "lastTrainingToolStripMenuItem";
            this.lastTrainingToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.lastTrainingToolStripMenuItem.Text = "Last training";
            this.lastTrainingToolStripMenuItem.Click += new System.EventHandler(this.lastTrainingToolStripMenuItem_Click);
            // 
            // lastErrorToolStripMenuItem
            // 
            this.lastErrorToolStripMenuItem.Name = "lastErrorToolStripMenuItem";
            this.lastErrorToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.lastErrorToolStripMenuItem.Text = "Last error";
            this.lastErrorToolStripMenuItem.Click += new System.EventHandler(this.lastErrorToolStripMenuItem_Click);
            // 
            // lastTimeToolStripMenuItem
            // 
            this.lastTimeToolStripMenuItem.Name = "lastTimeToolStripMenuItem";
            this.lastTimeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.lastTimeToolStripMenuItem.Text = "Last time";
            this.lastTimeToolStripMenuItem.Click += new System.EventHandler(this.lastTimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(209, 6);
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.autoToolStripMenuItem.Text = "Accuracy";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // lastAutodetectToolStripMenuItem
            // 
            this.lastAutodetectToolStripMenuItem.Name = "lastAutodetectToolStripMenuItem";
            this.lastAutodetectToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.lastAutodetectToolStripMenuItem.Text = "Protocol";
            this.lastAutodetectToolStripMenuItem.Click += new System.EventHandler(this.lastAutodetectToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.booksToolStripMenuItem,
            this.enginesToolStripMenuItem2,
            this.playersToolStripMenuItem});
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.historyToolStripMenuItem.Text = "Charts";
            // 
            // booksToolStripMenuItem
            // 
            this.booksToolStripMenuItem.Name = "booksToolStripMenuItem";
            this.booksToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.booksToolStripMenuItem.Text = "Books";
            this.booksToolStripMenuItem.Click += new System.EventHandler(this.booksToolStripMenuItem2_Click);
            // 
            // enginesToolStripMenuItem2
            // 
            this.enginesToolStripMenuItem2.Name = "enginesToolStripMenuItem2";
            this.enginesToolStripMenuItem2.Size = new System.Drawing.Size(115, 22);
            this.enginesToolStripMenuItem2.Text = "Engines";
            this.enginesToolStripMenuItem2.Click += new System.EventHandler(this.enginesToolStripMenuItem2_Click);
            // 
            // playersToolStripMenuItem
            // 
            this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
            this.playersToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.playersToolStripMenuItem.Text = "Players";
            this.playersToolStripMenuItem.Click += new System.EventHandler(this.playersToolStripMenuItem_Click);
            // 
            // listsToolStripMenuItem
            // 
            this.listsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.booksToolStripMenuItem2,
            this.enginesToolStripMenuItem3,
            this.playersToolStripMenuItem2});
            this.listsToolStripMenuItem.Name = "listsToolStripMenuItem";
            this.listsToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.listsToolStripMenuItem.Text = "Lists";
            // 
            // booksToolStripMenuItem2
            // 
            this.booksToolStripMenuItem2.Name = "booksToolStripMenuItem2";
            this.booksToolStripMenuItem2.Size = new System.Drawing.Size(115, 22);
            this.booksToolStripMenuItem2.Text = "Books";
            this.booksToolStripMenuItem2.Click += new System.EventHandler(this.booksToolStripMenuItem2_Click_1);
            // 
            // enginesToolStripMenuItem3
            // 
            this.enginesToolStripMenuItem3.Name = "enginesToolStripMenuItem3";
            this.enginesToolStripMenuItem3.Size = new System.Drawing.Size(115, 22);
            this.enginesToolStripMenuItem3.Text = "Engines";
            this.enginesToolStripMenuItem3.Click += new System.EventHandler(this.enginesToolStripMenuItem3_Click);
            // 
            // playersToolStripMenuItem2
            // 
            this.playersToolStripMenuItem2.Name = "playersToolStripMenuItem2";
            this.playersToolStripMenuItem2.Size = new System.Drawing.Size(115, 22);
            this.playersToolStripMenuItem2.Text = "Players";
            this.playersToolStripMenuItem2.Click += new System.EventHandler(this.playersToolStripMenuItem2_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // labGameTime
            // 
            this.labGameTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.labGameTime.Location = new System.Drawing.Point(1043, 0);
            this.labGameTime.Name = "labGameTime";
            this.labGameTime.Size = new System.Drawing.Size(79, 22);
            this.labGameTime.TabIndex = 2;
            this.labGameTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labGameTime, "Game time");
            // 
            // panMenu
            // 
            this.panMenu.BackColor = System.Drawing.SystemColors.Control;
            this.panMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panMenu.Controls.Add(this.labEco);
            this.panMenu.Controls.Add(this.labGameTime);
            this.panMenu.Controls.Add(this.labError);
            this.panMenu.Controls.Add(this.menuStrip1);
            this.panMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panMenu.Location = new System.Drawing.Point(0, 0);
            this.panMenu.Name = "panMenu";
            this.panMenu.Size = new System.Drawing.Size(1184, 26);
            this.panMenu.TabIndex = 26;
            // 
            // labEco
            // 
            this.labEco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labEco.Cursor = System.Windows.Forms.Cursors.Default;
            this.labEco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labEco.Location = new System.Drawing.Point(443, 4);
            this.labEco.Name = "labEco";
            this.labEco.Size = new System.Drawing.Size(600, 22);
            this.labEco.TabIndex = 3;
            this.labEco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labEco, "Names of chess openings variations");
            // 
            // labError
            // 
            this.labError.BackColor = System.Drawing.Color.DarkRed;
            this.labError.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labError.Dock = System.Windows.Forms.DockStyle.Right;
            this.labError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labError.ForeColor = System.Drawing.Color.White;
            this.labError.Location = new System.Drawing.Point(1122, 0);
            this.labError.Name = "labError";
            this.labError.Size = new System.Drawing.Size(58, 22);
            this.labError.TabIndex = 4;
            this.labError.Text = "Error";
            this.labError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labError, "A new engine error has occurred");
            this.labError.Visible = false;
            this.labError.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labError_MouseDown);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.BackColor = System.Drawing.SystemColors.Window;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            // 
            // cbGameMode
            // 
            this.cbGameMode.BackColor = System.Drawing.SystemColors.Window;
            this.cbGameMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbGameMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbGameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGameMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbGameMode.Items.AddRange(new object[] {
            "Game",
            "Match",
            "Tournament-books",
            "Tournament-engines",
            "Tournament-players",
            "Training",
            "Puzzle",
            "Edit"});
            this.cbGameMode.Location = new System.Drawing.Point(8, 8);
            this.cbGameMode.Name = "cbGameMode";
            this.cbGameMode.Size = new System.Drawing.Size(359, 24);
            this.cbGameMode.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cbGameMode, "Select game mode");
            this.cbGameMode.SelectedIndexChanged += new System.EventHandler(this.cbMainMode_SelectedIndexChanged);
            // 
            // labNpsW
            // 
            this.labNpsW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labNpsW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labNpsW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labNpsW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labNpsW.ForeColor = System.Drawing.Color.Black;
            this.labNpsW.Location = new System.Drawing.Point(552, 20);
            this.labNpsW.Margin = new System.Windows.Forms.Padding(0);
            this.labNpsW.Name = "labNpsW";
            this.labNpsW.Size = new System.Drawing.Size(176, 20);
            this.labNpsW.TabIndex = 24;
            this.labNpsW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labNpsW, "Average searched nodes per second");
            // 
            // labNodesW
            // 
            this.labNodesW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labNodesW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labNodesW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labNodesW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labNodesW.ForeColor = System.Drawing.Color.Black;
            this.labNodesW.Location = new System.Drawing.Point(376, 20);
            this.labNodesW.Margin = new System.Windows.Forms.Padding(0);
            this.labNodesW.Name = "labNodesW";
            this.labNodesW.Size = new System.Drawing.Size(176, 20);
            this.labNodesW.TabIndex = 26;
            this.labNodesW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labNodesW, "Searched nodes");
            // 
            // labModeW
            // 
            this.labModeW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labModeW.BackColor = System.Drawing.Color.Olive;
            this.labModeW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labModeW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labModeW.ForeColor = System.Drawing.Color.White;
            this.labModeW.Location = new System.Drawing.Point(552, 0);
            this.labModeW.Margin = new System.Windows.Forms.Padding(0);
            this.labModeW.Name = "labModeW";
            this.labModeW.Size = new System.Drawing.Size(176, 20);
            this.labModeW.TabIndex = 17;
            this.labModeW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labModeW, "Control time");
            // 
            // labProtocolW
            // 
            this.labProtocolW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labProtocolW.BackColor = System.Drawing.Color.Olive;
            this.labProtocolW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labProtocolW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labProtocolW.ForeColor = System.Drawing.Color.White;
            this.labProtocolW.Location = new System.Drawing.Point(376, 0);
            this.labProtocolW.Margin = new System.Windows.Forms.Padding(0);
            this.labProtocolW.Name = "labProtocolW";
            this.labProtocolW.Size = new System.Drawing.Size(176, 20);
            this.labProtocolW.TabIndex = 16;
            this.labProtocolW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labProtocolW, "Chess engine protocol");
            // 
            // labEngineW
            // 
            this.labEngineW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labEngineW.BackColor = System.Drawing.Color.Olive;
            this.labEngineW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labEngineW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labEngineW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labEngineW.ForeColor = System.Drawing.Color.White;
            this.labEngineW.Location = new System.Drawing.Point(200, 0);
            this.labEngineW.Margin = new System.Windows.Forms.Padding(0);
            this.labEngineW.Name = "labEngineW";
            this.labEngineW.Size = new System.Drawing.Size(176, 20);
            this.labEngineW.TabIndex = 13;
            this.labEngineW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labEngineW, "Chess engine name");
            this.labEngineW.Click += new System.EventHandler(this.EngineClick);
            // 
            // labMemoryW
            // 
            this.labMemoryW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMemoryW.BackColor = System.Drawing.Color.Olive;
            this.labMemoryW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labMemoryW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labMemoryW.ForeColor = System.Drawing.Color.White;
            this.labMemoryW.Location = new System.Drawing.Point(904, 0);
            this.labMemoryW.Margin = new System.Windows.Forms.Padding(0);
            this.labMemoryW.Name = "labMemoryW";
            this.labMemoryW.Size = new System.Drawing.Size(176, 20);
            this.labMemoryW.TabIndex = 19;
            this.labMemoryW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labMemoryW, "Engine memory usage");
            // 
            // labDepthW
            // 
            this.labDepthW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labDepthW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labDepthW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labDepthW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labDepthW.ForeColor = System.Drawing.Color.Black;
            this.labDepthW.Location = new System.Drawing.Point(200, 20);
            this.labDepthW.Margin = new System.Windows.Forms.Padding(0);
            this.labDepthW.Name = "labDepthW";
            this.labDepthW.Size = new System.Drawing.Size(176, 20);
            this.labDepthW.TabIndex = 22;
            this.labDepthW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labDepthW, "Search depth in plies");
            // 
            // labBookCW
            // 
            this.labBookCW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labBookCW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labBookCW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labBookCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labBookCW.ForeColor = System.Drawing.Color.Black;
            this.labBookCW.Location = new System.Drawing.Point(728, 20);
            this.labBookCW.Margin = new System.Windows.Forms.Padding(0);
            this.labBookCW.Name = "labBookCW";
            this.labBookCW.Size = new System.Drawing.Size(176, 20);
            this.labBookCW.TabIndex = 25;
            this.labBookCW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labBookCW, "Number of moves read from the opening book");
            // 
            // labWhite
            // 
            this.labWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labWhite.BackColor = System.Drawing.Color.White;
            this.labWhite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labWhite.ForeColor = System.Drawing.Color.Black;
            this.labWhite.Location = new System.Drawing.Point(0, 0);
            this.labWhite.Margin = new System.Windows.Forms.Padding(0);
            this.labWhite.Name = "labWhite";
            this.labWhite.Size = new System.Drawing.Size(24, 20);
            this.labWhite.TabIndex = 14;
            this.labWhite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labWhite, "Player color");
            // 
            // labColW
            // 
            this.labColW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labColW.BackColor = System.Drawing.Color.DarkGray;
            this.labColW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labColW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labColW.ForeColor = System.Drawing.Color.Black;
            this.labColW.Location = new System.Drawing.Point(0, 20);
            this.labColW.Margin = new System.Windows.Forms.Padding(0);
            this.labColW.Name = "labColW";
            this.labColW.Size = new System.Drawing.Size(24, 20);
            this.labColW.TabIndex = 20;
            this.labColW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labColW, "Score color");
            // 
            // labScoreW
            // 
            this.labScoreW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labScoreW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labScoreW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labScoreW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labScoreW.ForeColor = System.Drawing.Color.Black;
            this.labScoreW.Location = new System.Drawing.Point(24, 20);
            this.labScoreW.Margin = new System.Windows.Forms.Padding(0);
            this.labScoreW.Name = "labScoreW";
            this.labScoreW.Size = new System.Drawing.Size(176, 20);
            this.labScoreW.TabIndex = 21;
            this.labScoreW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labScoreW, "The score from the engine\'s point of view in centipawns");
            // 
            // labPlayerW
            // 
            this.labPlayerW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labPlayerW.BackColor = System.Drawing.Color.Olive;
            this.labPlayerW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labPlayerW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labPlayerW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labPlayerW.ForeColor = System.Drawing.Color.White;
            this.labPlayerW.Location = new System.Drawing.Point(24, 0);
            this.labPlayerW.Margin = new System.Windows.Forms.Padding(0);
            this.labPlayerW.Name = "labPlayerW";
            this.labPlayerW.Size = new System.Drawing.Size(176, 20);
            this.labPlayerW.TabIndex = 18;
            this.labPlayerW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labPlayerW, "Player name");
            this.labPlayerW.Click += new System.EventHandler(this.PlayerClick);
            // 
            // labBookNW
            // 
            this.labBookNW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labBookNW.BackColor = System.Drawing.Color.Olive;
            this.labBookNW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labBookNW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labBookNW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labBookNW.ForeColor = System.Drawing.Color.White;
            this.labBookNW.Location = new System.Drawing.Point(728, 0);
            this.labBookNW.Margin = new System.Windows.Forms.Padding(0);
            this.labBookNW.Name = "labBookNW";
            this.labBookNW.Size = new System.Drawing.Size(176, 20);
            this.labBookNW.TabIndex = 15;
            this.labBookNW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labBookNW, "Chess opening book name");
            this.labBookNW.Click += new System.EventHandler(this.BookClick);
            // 
            // pbHashW
            // 
            this.pbHashW.BackColor = System.Drawing.SystemColors.Control;
            this.pbHashW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbHashW.Location = new System.Drawing.Point(907, 23);
            this.pbHashW.MarqueeAnimationSpeed = 0;
            this.pbHashW.Maximum = 1000;
            this.pbHashW.Name = "pbHashW";
            this.pbHashW.Size = new System.Drawing.Size(170, 14);
            this.pbHashW.Step = 1;
            this.pbHashW.TabIndex = 27;
            this.toolTip1.SetToolTip(this.pbHashW, "Use of transposition table");
            // 
            // labBookCB
            // 
            this.labBookCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labBookCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labBookCB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labBookCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labBookCB.ForeColor = System.Drawing.Color.Black;
            this.labBookCB.Location = new System.Drawing.Point(728, 20);
            this.labBookCB.Margin = new System.Windows.Forms.Padding(0);
            this.labBookCB.Name = "labBookCB";
            this.labBookCB.Size = new System.Drawing.Size(176, 20);
            this.labBookCB.TabIndex = 26;
            this.labBookCB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labBookCB, "Number of moves read from the opening book");
            // 
            // labNpsB
            // 
            this.labNpsB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labNpsB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labNpsB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labNpsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labNpsB.ForeColor = System.Drawing.Color.Black;
            this.labNpsB.Location = new System.Drawing.Point(552, 20);
            this.labNpsB.Margin = new System.Windows.Forms.Padding(0);
            this.labNpsB.Name = "labNpsB";
            this.labNpsB.Size = new System.Drawing.Size(176, 20);
            this.labNpsB.TabIndex = 25;
            this.labNpsB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labNpsB, "Average searched nodes per second");
            // 
            // labNodesB
            // 
            this.labNodesB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labNodesB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labNodesB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labNodesB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labNodesB.ForeColor = System.Drawing.Color.Black;
            this.labNodesB.Location = new System.Drawing.Point(376, 20);
            this.labNodesB.Margin = new System.Windows.Forms.Padding(0);
            this.labNodesB.Name = "labNodesB";
            this.labNodesB.Size = new System.Drawing.Size(176, 20);
            this.labNodesB.TabIndex = 24;
            this.labNodesB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labNodesB, "Searched nodes");
            // 
            // labDepthB
            // 
            this.labDepthB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labDepthB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labDepthB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labDepthB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labDepthB.ForeColor = System.Drawing.Color.Black;
            this.labDepthB.Location = new System.Drawing.Point(200, 20);
            this.labDepthB.Margin = new System.Windows.Forms.Padding(0);
            this.labDepthB.Name = "labDepthB";
            this.labDepthB.Size = new System.Drawing.Size(176, 20);
            this.labDepthB.TabIndex = 23;
            this.labDepthB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labDepthB, "Search depth in plies");
            // 
            // labScoreB
            // 
            this.labScoreB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labScoreB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labScoreB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labScoreB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labScoreB.ForeColor = System.Drawing.Color.Black;
            this.labScoreB.Location = new System.Drawing.Point(24, 20);
            this.labScoreB.Margin = new System.Windows.Forms.Padding(0);
            this.labScoreB.Name = "labScoreB";
            this.labScoreB.Size = new System.Drawing.Size(176, 20);
            this.labScoreB.TabIndex = 22;
            this.labScoreB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labScoreB, "The score from the engine\'s point of view in centipawns");
            // 
            // labColB
            // 
            this.labColB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labColB.BackColor = System.Drawing.Color.DarkGray;
            this.labColB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labColB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labColB.ForeColor = System.Drawing.Color.Black;
            this.labColB.Location = new System.Drawing.Point(0, 20);
            this.labColB.Margin = new System.Windows.Forms.Padding(0);
            this.labColB.Name = "labColB";
            this.labColB.Size = new System.Drawing.Size(24, 20);
            this.labColB.TabIndex = 21;
            this.labColB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labColB, "Score color");
            // 
            // labModeB
            // 
            this.labModeB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labModeB.BackColor = System.Drawing.Color.Olive;
            this.labModeB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labModeB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labModeB.ForeColor = System.Drawing.Color.White;
            this.labModeB.Location = new System.Drawing.Point(552, 0);
            this.labModeB.Margin = new System.Windows.Forms.Padding(0);
            this.labModeB.Name = "labModeB";
            this.labModeB.Size = new System.Drawing.Size(176, 20);
            this.labModeB.TabIndex = 17;
            this.labModeB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labModeB, "Control time");
            // 
            // labProtocolB
            // 
            this.labProtocolB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labProtocolB.BackColor = System.Drawing.Color.Olive;
            this.labProtocolB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labProtocolB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labProtocolB.ForeColor = System.Drawing.Color.White;
            this.labProtocolB.Location = new System.Drawing.Point(376, 0);
            this.labProtocolB.Margin = new System.Windows.Forms.Padding(0);
            this.labProtocolB.Name = "labProtocolB";
            this.labProtocolB.Size = new System.Drawing.Size(176, 20);
            this.labProtocolB.TabIndex = 16;
            this.labProtocolB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labProtocolB, "Chess engine protocol");
            // 
            // labMemoryB
            // 
            this.labMemoryB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMemoryB.BackColor = System.Drawing.Color.Olive;
            this.labMemoryB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labMemoryB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labMemoryB.ForeColor = System.Drawing.Color.White;
            this.labMemoryB.Location = new System.Drawing.Point(904, 0);
            this.labMemoryB.Margin = new System.Windows.Forms.Padding(0);
            this.labMemoryB.Name = "labMemoryB";
            this.labMemoryB.Size = new System.Drawing.Size(176, 20);
            this.labMemoryB.TabIndex = 19;
            this.labMemoryB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labMemoryB, "Engine memory usage");
            // 
            // labBookNB
            // 
            this.labBookNB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labBookNB.BackColor = System.Drawing.Color.Olive;
            this.labBookNB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labBookNB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labBookNB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labBookNB.ForeColor = System.Drawing.Color.White;
            this.labBookNB.Location = new System.Drawing.Point(728, 0);
            this.labBookNB.Margin = new System.Windows.Forms.Padding(0);
            this.labBookNB.Name = "labBookNB";
            this.labBookNB.Size = new System.Drawing.Size(176, 20);
            this.labBookNB.TabIndex = 15;
            this.labBookNB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labBookNB, "Chess opening book name");
            this.labBookNB.Click += new System.EventHandler(this.BookClick);
            // 
            // labBlack
            // 
            this.labBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labBlack.BackColor = System.Drawing.Color.Black;
            this.labBlack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labBlack.ForeColor = System.Drawing.Color.Black;
            this.labBlack.Location = new System.Drawing.Point(0, 0);
            this.labBlack.Margin = new System.Windows.Forms.Padding(0);
            this.labBlack.Name = "labBlack";
            this.labBlack.Size = new System.Drawing.Size(24, 20);
            this.labBlack.TabIndex = 14;
            this.labBlack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labBlack, "Player color");
            // 
            // labPlayerB
            // 
            this.labPlayerB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labPlayerB.BackColor = System.Drawing.Color.Olive;
            this.labPlayerB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labPlayerB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labPlayerB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labPlayerB.ForeColor = System.Drawing.Color.White;
            this.labPlayerB.Location = new System.Drawing.Point(24, 0);
            this.labPlayerB.Margin = new System.Windows.Forms.Padding(0);
            this.labPlayerB.Name = "labPlayerB";
            this.labPlayerB.Size = new System.Drawing.Size(176, 20);
            this.labPlayerB.TabIndex = 18;
            this.labPlayerB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labPlayerB, "Player name");
            this.labPlayerB.Click += new System.EventHandler(this.PlayerClick);
            // 
            // labEngineB
            // 
            this.labEngineB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labEngineB.BackColor = System.Drawing.Color.Olive;
            this.labEngineB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labEngineB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labEngineB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labEngineB.ForeColor = System.Drawing.Color.White;
            this.labEngineB.Location = new System.Drawing.Point(200, 0);
            this.labEngineB.Margin = new System.Windows.Forms.Padding(0);
            this.labEngineB.Name = "labEngineB";
            this.labEngineB.Size = new System.Drawing.Size(176, 20);
            this.labEngineB.TabIndex = 13;
            this.labEngineB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labEngineB, "Chess engine name");
            this.labEngineB.Click += new System.EventHandler(this.EngineClick);
            // 
            // pbHashB
            // 
            this.pbHashB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbHashB.Location = new System.Drawing.Point(907, 23);
            this.pbHashB.MarqueeAnimationSpeed = 0;
            this.pbHashB.Maximum = 1000;
            this.pbHashB.Name = "pbHashB";
            this.pbHashB.Size = new System.Drawing.Size(170, 14);
            this.pbHashB.Step = 1;
            this.pbHashB.TabIndex = 27;
            this.toolTip1.SetToolTip(this.pbHashB, "Use of transposition table");
            // 
            // chartMain
            // 
            this.chartMain.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea8.AxisX.IsLabelAutoFit = false;
            chartArea8.AxisX.MajorGrid.Enabled = false;
            chartArea8.AxisX.MajorTickMark.Enabled = false;
            chartArea8.AxisY.IsLabelAutoFit = false;
            chartArea8.AxisY.MajorGrid.Interval = 5D;
            chartArea8.AxisY.MajorTickMark.Enabled = false;
            chartArea8.AxisY.Maximum = 5D;
            chartArea8.AxisY.Minimum = -5D;
            chartArea8.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea8.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea8.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea8);
            this.chartMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartMain.Location = new System.Drawing.Point(0, 0);
            this.chartMain.MinimumSize = new System.Drawing.Size(32, 32);
            this.chartMain.Name = "chartMain";
            this.chartMain.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartMain.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Olive};
            series14.ChartArea = "ChartArea1";
            series14.CustomProperties = "PointWidth=1";
            series14.IsVisibleInLegend = false;
            series14.Name = "Series1";
            series15.ChartArea = "ChartArea1";
            series15.CustomProperties = "PointWidth=1";
            series15.Name = "Series2";
            this.chartMain.Series.Add(series14);
            this.chartMain.Series.Add(series15);
            this.chartMain.Size = new System.Drawing.Size(365, 234);
            this.chartMain.SuppressExceptions = true;
            this.chartMain.TabIndex = 6;
            this.chartMain.Text = "chart1";
            this.toolTip1.SetToolTip(this.chartMain, "Graphic representation of the game scores white player is  represent by light bar" +
        "s black player is represent by dark bars");
            // 
            // labPromoB
            // 
            this.labPromoB.BackColor = System.Drawing.Color.Transparent;
            this.labPromoB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labPromoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labPromoB.ForeColor = System.Drawing.Color.Black;
            this.labPromoB.Location = new System.Drawing.Point(204, 0);
            this.labPromoB.Margin = new System.Windows.Forms.Padding(0);
            this.labPromoB.Name = "labPromoB";
            this.labPromoB.Size = new System.Drawing.Size(102, 52);
            this.labPromoB.TabIndex = 23;
            this.labPromoB.Text = "b";
            this.labPromoB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labPromoB, "Promotion bishop");
            this.labPromoB.Click += new System.EventHandler(this.labPromoQ_Click);
            // 
            // labPromoN
            // 
            this.labPromoN.BackColor = System.Drawing.Color.Transparent;
            this.labPromoN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labPromoN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labPromoN.ForeColor = System.Drawing.Color.Black;
            this.labPromoN.Location = new System.Drawing.Point(306, 0);
            this.labPromoN.Margin = new System.Windows.Forms.Padding(0);
            this.labPromoN.Name = "labPromoN";
            this.labPromoN.Size = new System.Drawing.Size(104, 52);
            this.labPromoN.TabIndex = 22;
            this.labPromoN.Text = "n";
            this.labPromoN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labPromoN, "Promotion kinght");
            this.labPromoN.Click += new System.EventHandler(this.labPromoQ_Click);
            // 
            // labPromoQ
            // 
            this.labPromoQ.BackColor = System.Drawing.Color.Transparent;
            this.labPromoQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labPromoQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labPromoQ.ForeColor = System.Drawing.Color.Black;
            this.labPromoQ.Location = new System.Drawing.Point(0, 0);
            this.labPromoQ.Margin = new System.Windows.Forms.Padding(0);
            this.labPromoQ.Name = "labPromoQ";
            this.labPromoQ.Size = new System.Drawing.Size(102, 52);
            this.labPromoQ.TabIndex = 21;
            this.labPromoQ.Text = "q";
            this.labPromoQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labPromoQ, "Promotion queen");
            this.labPromoQ.Click += new System.EventHandler(this.labPromoQ_Click);
            // 
            // labPromoR
            // 
            this.labPromoR.BackColor = System.Drawing.Color.Transparent;
            this.labPromoR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labPromoR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labPromoR.ForeColor = System.Drawing.Color.Black;
            this.labPromoR.Location = new System.Drawing.Point(102, 0);
            this.labPromoR.Margin = new System.Windows.Forms.Padding(0);
            this.labPromoR.Name = "labPromoR";
            this.labPromoR.Size = new System.Drawing.Size(102, 52);
            this.labPromoR.TabIndex = 20;
            this.labPromoR.Text = "r";
            this.labPromoR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labPromoR, "Promotion rook");
            this.labPromoR.Click += new System.EventHandler(this.labPromoQ_Click);
            // 
            // labColorL
            // 
            this.labColorL.BackColor = System.Drawing.Color.LightGray;
            this.labColorL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labColorL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labColorL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labColorL.ForeColor = System.Drawing.Color.Black;
            this.labColorL.Location = new System.Drawing.Point(0, 0);
            this.labColorL.Margin = new System.Windows.Forms.Padding(0);
            this.labColorL.Name = "labColorL";
            this.labColorL.Size = new System.Drawing.Size(56, 56);
            this.labColorL.TabIndex = 22;
            this.labColorL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labColorL, "Player color");
            // 
            // labColorH
            // 
            this.labColorH.BackColor = System.Drawing.Color.LightGray;
            this.labColorH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labColorH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labColorH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labColorH.ForeColor = System.Drawing.Color.Black;
            this.labColorH.Location = new System.Drawing.Point(0, 0);
            this.labColorH.Margin = new System.Windows.Forms.Padding(0);
            this.labColorH.Name = "labColorH";
            this.labColorH.Size = new System.Drawing.Size(56, 56);
            this.labColorH.TabIndex = 22;
            this.labColorH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labColorH, "Player color");
            // 
            // labMaterialL
            // 
            this.labMaterialL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMaterialL.BackColor = System.Drawing.Color.DarkGray;
            this.labMaterialL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labMaterialL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labMaterialL.ForeColor = System.Drawing.Color.White;
            this.labMaterialL.Location = new System.Drawing.Point(261, 0);
            this.labMaterialL.Margin = new System.Windows.Forms.Padding(0);
            this.labMaterialL.Name = "labMaterialL";
            this.labMaterialL.Size = new System.Drawing.Size(87, 28);
            this.labMaterialL.TabIndex = 24;
            this.labMaterialL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labMaterialL, "Difference of pieces material between players");
            // 
            // labTakenH
            // 
            this.labTakenH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTakenH.BackColor = System.Drawing.Color.DarkGray;
            this.labTakenH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labTakenH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labTakenH.ForeColor = System.Drawing.Color.White;
            this.labTakenH.Location = new System.Drawing.Point(0, 0);
            this.labTakenH.Margin = new System.Windows.Forms.Padding(0);
            this.labTakenH.Name = "labTakenH";
            this.labTakenH.Size = new System.Drawing.Size(261, 28);
            this.labTakenH.TabIndex = 15;
            this.labTakenH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labTakenH, "Taken pieces");
            // 
            // labMaterialH
            // 
            this.labMaterialH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMaterialH.BackColor = System.Drawing.Color.DarkGray;
            this.labMaterialH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labMaterialH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labMaterialH.ForeColor = System.Drawing.Color.Black;
            this.labMaterialH.Location = new System.Drawing.Point(261, 0);
            this.labMaterialH.Margin = new System.Windows.Forms.Padding(0);
            this.labMaterialH.Name = "labMaterialH";
            this.labMaterialH.Size = new System.Drawing.Size(87, 28);
            this.labMaterialH.TabIndex = 24;
            this.labMaterialH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labMaterialH, "Difference of pieces material between players");
            // 
            // labTakenL
            // 
            this.labTakenL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTakenL.BackColor = System.Drawing.Color.DarkGray;
            this.labTakenL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labTakenL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labTakenL.ForeColor = System.Drawing.Color.Black;
            this.labTakenL.Location = new System.Drawing.Point(0, 0);
            this.labTakenL.Margin = new System.Windows.Forms.Padding(0);
            this.labTakenL.Name = "labTakenL";
            this.labTakenL.Size = new System.Drawing.Size(261, 28);
            this.labTakenL.TabIndex = 15;
            this.labTakenL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labTakenL, "Taken pieces");
            // 
            // labNameH
            // 
            this.labNameH.BackColor = System.Drawing.Color.LightGray;
            this.labNameH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labNameH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labNameH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labNameH.ForeColor = System.Drawing.Color.Black;
            this.labNameH.Location = new System.Drawing.Point(0, 0);
            this.labNameH.Margin = new System.Windows.Forms.Padding(0);
            this.labNameH.Name = "labNameH";
            this.labNameH.Size = new System.Drawing.Size(174, 24);
            this.labNameH.TabIndex = 23;
            this.labNameH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labNameH, "Player color");
            // 
            // labTimeH
            // 
            this.labTimeH.BackColor = System.Drawing.Color.LightGray;
            this.labTimeH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labTimeH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTimeH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labTimeH.ForeColor = System.Drawing.Color.Black;
            this.labTimeH.Location = new System.Drawing.Point(174, 0);
            this.labTimeH.Margin = new System.Windows.Forms.Padding(0);
            this.labTimeH.Name = "labTimeH";
            this.labTimeH.Size = new System.Drawing.Size(87, 24);
            this.labTimeH.TabIndex = 24;
            this.labTimeH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labTimeH, "Player color");
            // 
            // labEloH
            // 
            this.labEloH.BackColor = System.Drawing.Color.LightGray;
            this.labEloH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labEloH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labEloH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labEloH.ForeColor = System.Drawing.Color.Black;
            this.labEloH.Location = new System.Drawing.Point(261, 0);
            this.labEloH.Margin = new System.Windows.Forms.Padding(0);
            this.labEloH.Name = "labEloH";
            this.labEloH.Size = new System.Drawing.Size(87, 24);
            this.labEloH.TabIndex = 25;
            this.labEloH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labEloH, "Player color");
            // 
            // labNameL
            // 
            this.labNameL.BackColor = System.Drawing.Color.LightGray;
            this.labNameL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labNameL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labNameL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labNameL.ForeColor = System.Drawing.Color.Black;
            this.labNameL.Location = new System.Drawing.Point(0, 0);
            this.labNameL.Margin = new System.Windows.Forms.Padding(0);
            this.labNameL.Name = "labNameL";
            this.labNameL.Size = new System.Drawing.Size(174, 24);
            this.labNameL.TabIndex = 23;
            this.labNameL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labNameL, "Player color");
            // 
            // labTimeL
            // 
            this.labTimeL.BackColor = System.Drawing.Color.LightGray;
            this.labTimeL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labTimeL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTimeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labTimeL.ForeColor = System.Drawing.Color.Black;
            this.labTimeL.Location = new System.Drawing.Point(174, 0);
            this.labTimeL.Margin = new System.Windows.Forms.Padding(0);
            this.labTimeL.Name = "labTimeL";
            this.labTimeL.Size = new System.Drawing.Size(87, 24);
            this.labTimeL.TabIndex = 24;
            this.labTimeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labTimeL, "Player color");
            // 
            // labEloL
            // 
            this.labEloL.BackColor = System.Drawing.Color.LightGray;
            this.labEloL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labEloL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labEloL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labEloL.ForeColor = System.Drawing.Color.Black;
            this.labEloL.Location = new System.Drawing.Point(261, 0);
            this.labEloL.Margin = new System.Windows.Forms.Padding(0);
            this.labEloL.Name = "labEloL";
            this.labEloL.Size = new System.Drawing.Size(87, 24);
            this.labEloL.TabIndex = 25;
            this.labEloL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labEloL, "Player color");
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Black;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssMove,
            this.tssInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 836);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 26);
            this.statusStrip1.TabIndex = 33;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssMove
            // 
            this.tssMove.AutoSize = false;
            this.tssMove.ForeColor = System.Drawing.Color.Gainsboro;
            this.tssMove.Name = "tssMove";
            this.tssMove.Size = new System.Drawing.Size(128, 21);
            // 
            // tssInfo
            // 
            this.tssInfo.ForeColor = System.Drawing.Color.Gainsboro;
            this.tssInfo.Name = "tssInfo";
            this.tssInfo.Size = new System.Drawing.Size(0, 21);
            this.tssInfo.Tag = "";
            // 
            // scBoard
            // 
            this.scBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scBoard.IsSplitterFixed = true;
            this.scBoard.Location = new System.Drawing.Point(0, 0);
            this.scBoard.MinimumSize = new System.Drawing.Size(200, 200);
            this.scBoard.Name = "scBoard";
            // 
            // scBoard.Panel1
            // 
            this.scBoard.Panel1.AutoScroll = true;
            this.scBoard.Panel1.Controls.Add(this.panBoard);
            this.scBoard.Panel1.Controls.Add(this.tlpL);
            this.scBoard.Panel1.Controls.Add(this.tlpH);
            this.scBoard.Panel1MinSize = 100;
            // 
            // scBoard.Panel2
            // 
            this.scBoard.Panel2.Controls.Add(this.scMode);
            this.scBoard.Panel2MinSize = 100;
            this.scBoard.Size = new System.Drawing.Size(1184, 541);
            this.scBoard.SplitterDistance = 414;
            this.scBoard.TabIndex = 37;
            this.scBoard.SizeChanged += new System.EventHandler(this.splitContainer_SizeChanged);
            // 
            // panBoard
            // 
            this.panBoard.BackColor = System.Drawing.Color.Transparent;
            this.panBoard.Controls.Add(this.tlpPromotion);
            this.panBoard.Cursor = System.Windows.Forms.Cursors.Default;
            this.panBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBoard.Location = new System.Drawing.Point(0, 56);
            this.panBoard.MinimumSize = new System.Drawing.Size(200, 200);
            this.panBoard.Name = "panBoard";
            this.panBoard.Size = new System.Drawing.Size(410, 425);
            this.panBoard.TabIndex = 2;
            this.panBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panBoard_Paint);
            this.panBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panBoard_MouseDown);
            this.panBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panBoard_MouseMove);
            this.panBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panBoard_MouseUp);
            this.panBoard.Resize += new System.EventHandler(this.panBoard_Resize);
            // 
            // tlpPromotion
            // 
            this.tlpPromotion.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.tlpPromotion.ColumnCount = 4;
            this.tlpPromotion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPromotion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPromotion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPromotion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPromotion.Controls.Add(this.labPromoB, 0, 0);
            this.tlpPromotion.Controls.Add(this.labPromoN, 0, 0);
            this.tlpPromotion.Controls.Add(this.labPromoQ, 0, 0);
            this.tlpPromotion.Controls.Add(this.labPromoR, 0, 0);
            this.tlpPromotion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tlpPromotion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpPromotion.Location = new System.Drawing.Point(0, 373);
            this.tlpPromotion.Name = "tlpPromotion";
            this.tlpPromotion.RowCount = 1;
            this.tlpPromotion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPromotion.Size = new System.Drawing.Size(410, 52);
            this.tlpPromotion.TabIndex = 34;
            this.tlpPromotion.Visible = false;
            // 
            // tlpL
            // 
            this.tlpL.ColumnCount = 2;
            this.tlpL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpL.Controls.Add(this.labColorL, 0, 0);
            this.tlpL.Controls.Add(this.panBoardL, 1, 0);
            this.tlpL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpL.Location = new System.Drawing.Point(0, 481);
            this.tlpL.Name = "tlpL";
            this.tlpL.RowCount = 1;
            this.tlpL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpL.Size = new System.Drawing.Size(410, 56);
            this.tlpL.TabIndex = 37;
            // 
            // panBoardL
            // 
            this.panBoardL.Controls.Add(this.tlpChartB);
            this.panBoardL.Controls.Add(this.tlpBoardL);
            this.panBoardL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBoardL.Location = new System.Drawing.Point(59, 3);
            this.panBoardL.Name = "panBoardL";
            this.panBoardL.Size = new System.Drawing.Size(348, 50);
            this.panBoardL.TabIndex = 23;
            // 
            // tlpChartB
            // 
            this.tlpChartB.ColumnCount = 2;
            this.tlpChartB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpChartB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpChartB.Controls.Add(this.labMaterialH, 0, 0);
            this.tlpChartB.Controls.Add(this.labTakenL, 0, 0);
            this.tlpChartB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpChartB.Location = new System.Drawing.Point(0, -2);
            this.tlpChartB.Margin = new System.Windows.Forms.Padding(0);
            this.tlpChartB.Name = "tlpChartB";
            this.tlpChartB.RowCount = 1;
            this.tlpChartB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChartB.Size = new System.Drawing.Size(348, 28);
            this.tlpChartB.TabIndex = 36;
            // 
            // tlpBoardL
            // 
            this.tlpBoardL.ColumnCount = 3;
            this.tlpBoardL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBoardL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBoardL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBoardL.Controls.Add(this.labEloL, 2, 0);
            this.tlpBoardL.Controls.Add(this.labTimeL, 1, 0);
            this.tlpBoardL.Controls.Add(this.labNameL, 0, 0);
            this.tlpBoardL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpBoardL.Location = new System.Drawing.Point(0, 26);
            this.tlpBoardL.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBoardL.Name = "tlpBoardL";
            this.tlpBoardL.RowCount = 1;
            this.tlpBoardL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBoardL.Size = new System.Drawing.Size(348, 24);
            this.tlpBoardL.TabIndex = 2;
            // 
            // tlpH
            // 
            this.tlpH.ColumnCount = 2;
            this.tlpH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpH.Controls.Add(this.labColorH, 0, 0);
            this.tlpH.Controls.Add(this.panBoardH, 1, 0);
            this.tlpH.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpH.Location = new System.Drawing.Point(0, 0);
            this.tlpH.Name = "tlpH";
            this.tlpH.RowCount = 1;
            this.tlpH.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpH.Size = new System.Drawing.Size(410, 56);
            this.tlpH.TabIndex = 36;
            // 
            // panBoardH
            // 
            this.panBoardH.Controls.Add(this.tlpChartW);
            this.panBoardH.Controls.Add(this.tlpBoardH);
            this.panBoardH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBoardH.Location = new System.Drawing.Point(59, 3);
            this.panBoardH.Name = "panBoardH";
            this.panBoardH.Size = new System.Drawing.Size(348, 50);
            this.panBoardH.TabIndex = 23;
            // 
            // tlpChartW
            // 
            this.tlpChartW.ColumnCount = 2;
            this.tlpChartW.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpChartW.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpChartW.Controls.Add(this.labMaterialL, 0, 0);
            this.tlpChartW.Controls.Add(this.labTakenH, 0, 0);
            this.tlpChartW.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpChartW.Location = new System.Drawing.Point(0, 24);
            this.tlpChartW.Margin = new System.Windows.Forms.Padding(0);
            this.tlpChartW.Name = "tlpChartW";
            this.tlpChartW.RowCount = 1;
            this.tlpChartW.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChartW.Size = new System.Drawing.Size(348, 28);
            this.tlpChartW.TabIndex = 35;
            // 
            // tlpBoardH
            // 
            this.tlpBoardH.ColumnCount = 3;
            this.tlpBoardH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBoardH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBoardH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBoardH.Controls.Add(this.labEloH, 2, 0);
            this.tlpBoardH.Controls.Add(this.labTimeH, 1, 0);
            this.tlpBoardH.Controls.Add(this.labNameH, 0, 0);
            this.tlpBoardH.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpBoardH.Location = new System.Drawing.Point(0, 0);
            this.tlpBoardH.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBoardH.Name = "tlpBoardH";
            this.tlpBoardH.RowCount = 1;
            this.tlpBoardH.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBoardH.Size = new System.Drawing.Size(348, 24);
            this.tlpBoardH.TabIndex = 1;
            // 
            // scMode
            // 
            this.scMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMode.Location = new System.Drawing.Point(0, 0);
            this.scMode.MinimumSize = new System.Drawing.Size(100, 100);
            this.scMode.Name = "scMode";
            // 
            // scMode.Panel1
            // 
            this.scMode.Panel1.Controls.Add(this.tabControl1);
            this.scMode.Panel1.Controls.Add(this.panGameMode);
            this.scMode.Panel1MinSize = 0;
            // 
            // scMode.Panel2
            // 
            this.scMode.Panel2.Controls.Add(this.scRight);
            this.scMode.Panel2MinSize = 0;
            this.scMode.Size = new System.Drawing.Size(762, 537);
            this.scMode.SplitterDistance = 375;
            this.scMode.TabIndex = 14;
            this.scMode.SizeChanged += new System.EventHandler(this.splitContainer_SizeChanged);
            // 
            // panGameMode
            // 
            this.panGameMode.Controls.Add(this.cbGameMode);
            this.panGameMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.panGameMode.Location = new System.Drawing.Point(0, 0);
            this.panGameMode.Name = "panGameMode";
            this.panGameMode.Padding = new System.Windows.Forms.Padding(8);
            this.panGameMode.Size = new System.Drawing.Size(375, 39);
            this.panGameMode.TabIndex = 11;
            // 
            // scRight
            // 
            this.scRight.BackColor = System.Drawing.Color.Transparent;
            this.scRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scRight.Location = new System.Drawing.Point(0, 0);
            this.scRight.MinimumSize = new System.Drawing.Size(100, 100);
            this.scRight.Name = "scRight";
            this.scRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scRight.Panel1
            // 
            this.scRight.Panel1.Controls.Add(this.lvMoves);
            this.scRight.Panel1MinSize = 0;
            // 
            // scRight.Panel2
            // 
            this.scRight.Panel2.Controls.Add(this.tabControl2);
            this.scRight.Panel2MinSize = 0;
            this.scRight.Size = new System.Drawing.Size(383, 537);
            this.scRight.SplitterDistance = 280;
            this.scRight.TabIndex = 27;
            // 
            // lvMoves
            // 
            this.lvMoves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader30});
            this.lvMoves.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvMoves.FullRowSelect = true;
            this.lvMoves.GridLines = true;
            this.lvMoves.HideSelection = false;
            this.lvMoves.Location = new System.Drawing.Point(0, 0);
            this.lvMoves.MultiSelect = false;
            this.lvMoves.Name = "lvMoves";
            this.lvMoves.ShowGroups = false;
            this.lvMoves.Size = new System.Drawing.Size(379, 276);
            this.lvMoves.TabIndex = 27;
            this.lvMoves.UseCompatibleStateImageBehavior = false;
            this.lvMoves.View = System.Windows.Forms.View.Details;
            this.lvMoves.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvMoves_ItemSelectionChanged);
            this.lvMoves.DoubleClick += new System.EventHandler(this.lvMoves_DoubleClick);
            this.lvMoves.Resize += new System.EventHandler(this.lvMoves_Resize);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Move";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Score";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Principal Variation";
            // 
            // tabControl2
            // 
            this.tabControl2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl2.Controls.Add(this.tabPageGraph);
            this.tabControl2.Controls.Add(this.tabPageAnalysis);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(379, 249);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 2;
            // 
            // tabPageGraph
            // 
            this.tabPageGraph.Controls.Add(this.panChartMain);
            this.tabPageGraph.Location = new System.Drawing.Point(4, 5);
            this.tabPageGraph.Name = "tabPageGraph";
            this.tabPageGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGraph.Size = new System.Drawing.Size(371, 240);
            this.tabPageGraph.TabIndex = 0;
            this.tabPageGraph.UseVisualStyleBackColor = true;
            // 
            // panChartMain
            // 
            this.panChartMain.Controls.Add(this.chartMain);
            this.panChartMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panChartMain.Location = new System.Drawing.Point(3, 3);
            this.panChartMain.Name = "panChartMain";
            this.panChartMain.Size = new System.Drawing.Size(365, 234);
            this.panChartMain.TabIndex = 34;
            this.panChartMain.Resize += new System.EventHandler(this.panChartMain_Resize);
            // 
            // tabPageAnalysis
            // 
            this.tabPageAnalysis.Controls.Add(this.tcLast);
            this.tabPageAnalysis.Controls.Add(this.butLastDelete);
            this.tabPageAnalysis.Location = new System.Drawing.Point(4, 5);
            this.tabPageAnalysis.Name = "tabPageAnalysis";
            this.tabPageAnalysis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnalysis.Size = new System.Drawing.Size(371, 240);
            this.tabPageAnalysis.TabIndex = 1;
            this.tabPageAnalysis.UseVisualStyleBackColor = true;
            // 
            // tcLast
            // 
            this.tcLast.Controls.Add(this.tpFens);
            this.tcLast.Controls.Add(this.tpGames);
            this.tcLast.Controls.Add(this.tpPuzzles);
            this.tcLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcLast.Location = new System.Drawing.Point(3, 3);
            this.tcLast.Name = "tcLast";
            this.tcLast.SelectedIndex = 0;
            this.tcLast.Size = new System.Drawing.Size(365, 211);
            this.tcLast.TabIndex = 26;
            // 
            // tpFens
            // 
            this.tpFens.Controls.Add(this.lvFen);
            this.tpFens.Location = new System.Drawing.Point(4, 22);
            this.tpFens.Name = "tpFens";
            this.tpFens.Padding = new System.Windows.Forms.Padding(3);
            this.tpFens.Size = new System.Drawing.Size(357, 185);
            this.tpFens.TabIndex = 0;
            this.tpFens.Text = "Fens";
            this.tpFens.UseVisualStyleBackColor = true;
            // 
            // lvFen
            // 
            this.lvFen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader42,
            this.chFenFen});
            this.lvFen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvFen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvFen.FullRowSelect = true;
            this.lvFen.GridLines = true;
            this.lvFen.HideSelection = false;
            this.lvFen.Location = new System.Drawing.Point(3, 3);
            this.lvFen.MultiSelect = false;
            this.lvFen.Name = "lvFen";
            this.lvFen.ShowGroups = false;
            this.lvFen.Size = new System.Drawing.Size(351, 179);
            this.lvFen.TabIndex = 30;
            this.lvFen.UseCompatibleStateImageBehavior = false;
            this.lvFen.View = System.Windows.Forms.View.Details;
            this.lvFen.SelectedIndexChanged += new System.EventHandler(this.lvFen_SelectedIndexChanged);
            this.lvFen.SizeChanged += new System.EventHandler(this.lvFen_SizeChanged);
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "Number";
            // 
            // chFenFen
            // 
            this.chFenFen.Text = "Fen";
            this.chFenFen.Width = 120;
            // 
            // tpGames
            // 
            this.tpGames.Controls.Add(this.lvPgn);
            this.tpGames.Location = new System.Drawing.Point(4, 22);
            this.tpGames.Name = "tpGames";
            this.tpGames.Padding = new System.Windows.Forms.Padding(3);
            this.tpGames.Size = new System.Drawing.Size(357, 185);
            this.tpGames.TabIndex = 1;
            this.tpGames.Text = "Games";
            this.tpGames.UseVisualStyleBackColor = true;
            // 
            // lvPgn
            // 
            this.lvPgn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader31,
            this.columnHeader39,
            this.chPgnPv});
            this.lvPgn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvPgn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvPgn.FullRowSelect = true;
            this.lvPgn.GridLines = true;
            this.lvPgn.HideSelection = false;
            this.lvPgn.Location = new System.Drawing.Point(3, 3);
            this.lvPgn.MultiSelect = false;
            this.lvPgn.Name = "lvPgn";
            this.lvPgn.ShowGroups = false;
            this.lvPgn.Size = new System.Drawing.Size(351, 179);
            this.lvPgn.TabIndex = 29;
            this.lvPgn.UseCompatibleStateImageBehavior = false;
            this.lvPgn.View = System.Windows.Forms.View.Details;
            this.lvPgn.SelectedIndexChanged += new System.EventHandler(this.lvPgn_SelectedIndexChanged);
            this.lvPgn.SizeChanged += new System.EventHandler(this.lvPgn_SizeChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Number";
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "White";
            this.columnHeader31.Width = 80;
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "Black";
            this.columnHeader39.Width = 80;
            // 
            // chPgnPv
            // 
            this.chPgnPv.Text = "Moves";
            // 
            // tpPuzzles
            // 
            this.tpPuzzles.Controls.Add(this.lvPuzzle);
            this.tpPuzzles.Location = new System.Drawing.Point(4, 22);
            this.tpPuzzles.Name = "tpPuzzles";
            this.tpPuzzles.Padding = new System.Windows.Forms.Padding(3);
            this.tpPuzzles.Size = new System.Drawing.Size(357, 185);
            this.tpPuzzles.TabIndex = 2;
            this.tpPuzzles.Text = "Puzzles";
            this.tpPuzzles.UseVisualStyleBackColor = true;
            // 
            // lvPuzzle
            // 
            this.lvPuzzle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader40,
            this.chPuzzleFen,
            this.chPuzzlePv});
            this.lvPuzzle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvPuzzle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPuzzle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvPuzzle.FullRowSelect = true;
            this.lvPuzzle.GridLines = true;
            this.lvPuzzle.HideSelection = false;
            this.lvPuzzle.Location = new System.Drawing.Point(3, 3);
            this.lvPuzzle.MultiSelect = false;
            this.lvPuzzle.Name = "lvPuzzle";
            this.lvPuzzle.ShowGroups = false;
            this.lvPuzzle.Size = new System.Drawing.Size(351, 179);
            this.lvPuzzle.TabIndex = 30;
            this.lvPuzzle.UseCompatibleStateImageBehavior = false;
            this.lvPuzzle.View = System.Windows.Forms.View.Details;
            this.lvPuzzle.SelectedIndexChanged += new System.EventHandler(this.lvPuzzle_SelectedIndexChanged);
            this.lvPuzzle.SizeChanged += new System.EventHandler(this.lvPuzzle_SizeChanged);
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "Number";
            // 
            // chPuzzleFen
            // 
            this.chPuzzleFen.Text = "Fen";
            this.chPuzzleFen.Width = 120;
            // 
            // chPuzzlePv
            // 
            this.chPuzzlePv.Text = "Moves";
            // 
            // butLastDelete
            // 
            this.butLastDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.butLastDelete.Location = new System.Drawing.Point(3, 214);
            this.butLastDelete.Name = "butLastDelete";
            this.butLastDelete.Size = new System.Drawing.Size(365, 23);
            this.butLastDelete.TabIndex = 33;
            this.butLastDelete.Text = "Delete";
            this.butLastDelete.UseVisualStyleBackColor = true;
            this.butLastDelete.Click += new System.EventHandler(this.butLastDelete_Click);
            // 
            // scMain
            // 
            this.scMain.BackColor = System.Drawing.Color.Transparent;
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 26);
            this.scMain.MinimumSize = new System.Drawing.Size(200, 200);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.scBoard);
            this.scMain.Panel1MinSize = 200;
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.splitContainerMoves);
            this.scMain.Panel2MinSize = 64;
            this.scMain.Size = new System.Drawing.Size(1184, 810);
            this.scMain.SplitterDistance = 541;
            this.scMain.TabIndex = 38;
            // 
            // splitContainerMoves
            // 
            this.splitContainerMoves.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMoves.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMoves.Name = "splitContainerMoves";
            this.splitContainerMoves.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMoves.Panel1
            // 
            this.splitContainerMoves.Panel1.Controls.Add(this.lvMovesW);
            this.splitContainerMoves.Panel1.Controls.Add(this.panWhite);
            // 
            // splitContainerMoves.Panel2
            // 
            this.splitContainerMoves.Panel2.Controls.Add(this.lvMovesB);
            this.splitContainerMoves.Panel2.Controls.Add(this.panBlack);
            this.splitContainerMoves.Size = new System.Drawing.Size(1184, 265);
            this.splitContainerMoves.SplitterDistance = 131;
            this.splitContainerMoves.TabIndex = 33;
            // 
            // lvMovesW
            // 
            this.lvMovesW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.lvMovesW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvMovesW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMovesW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvMovesW.FullRowSelect = true;
            this.lvMovesW.GridLines = true;
            this.lvMovesW.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvMovesW.HideSelection = false;
            this.lvMovesW.Location = new System.Drawing.Point(0, 40);
            this.lvMovesW.MultiSelect = false;
            this.lvMovesW.Name = "lvMovesW";
            this.lvMovesW.ShowGroups = false;
            this.lvMovesW.Size = new System.Drawing.Size(1180, 87);
            this.lvMovesW.TabIndex = 32;
            this.lvMovesW.Tag = "";
            this.lvMovesW.UseCompatibleStateImageBehavior = false;
            this.lvMovesW.View = System.Windows.Forms.View.Details;
            this.lvMovesW.DoubleClick += new System.EventHandler(this.lvPV_DoubleClick);
            this.lvMovesW.Resize += new System.EventHandler(this.lvLines_Resize);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Time";
            this.columnHeader11.Width = 70;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Score";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Depth";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Nodes";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader14.Width = 92;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "NPS";
            this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Principal Variation";
            this.columnHeader16.Width = 100;
            // 
            // panWhite
            // 
            this.panWhite.Controls.Add(this.tlpWhite);
            this.panWhite.Controls.Add(this.pictureBoxW);
            this.panWhite.Dock = System.Windows.Forms.DockStyle.Top;
            this.panWhite.Location = new System.Drawing.Point(0, 0);
            this.panWhite.Name = "panWhite";
            this.panWhite.Size = new System.Drawing.Size(1180, 40);
            this.panWhite.TabIndex = 35;
            // 
            // tlpWhite
            // 
            this.tlpWhite.ColumnCount = 7;
            this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpWhite.Controls.Add(this.labNpsW, 4, 1);
            this.tlpWhite.Controls.Add(this.labNodesW, 3, 1);
            this.tlpWhite.Controls.Add(this.labModeW, 4, 0);
            this.tlpWhite.Controls.Add(this.labProtocolW, 3, 0);
            this.tlpWhite.Controls.Add(this.labEngineW, 2, 0);
            this.tlpWhite.Controls.Add(this.labMemoryW, 6, 0);
            this.tlpWhite.Controls.Add(this.labDepthW, 2, 1);
            this.tlpWhite.Controls.Add(this.labBookCW, 5, 1);
            this.tlpWhite.Controls.Add(this.labWhite, 0, 0);
            this.tlpWhite.Controls.Add(this.labColW, 0, 1);
            this.tlpWhite.Controls.Add(this.labScoreW, 1, 1);
            this.tlpWhite.Controls.Add(this.labPlayerW, 1, 0);
            this.tlpWhite.Controls.Add(this.labBookNW, 5, 0);
            this.tlpWhite.Controls.Add(this.pbHashW, 6, 1);
            this.tlpWhite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpWhite.Location = new System.Drawing.Point(100, 0);
            this.tlpWhite.Name = "tlpWhite";
            this.tlpWhite.RowCount = 2;
            this.tlpWhite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpWhite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpWhite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpWhite.Size = new System.Drawing.Size(1080, 40);
            this.tlpWhite.TabIndex = 35;
            // 
            // pictureBoxW
            // 
            this.pictureBoxW.BackColor = System.Drawing.Color.White;
            this.pictureBoxW.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxW.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxW.Name = "pictureBoxW";
            this.pictureBoxW.Size = new System.Drawing.Size(100, 40);
            this.pictureBoxW.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxW.TabIndex = 0;
            this.pictureBoxW.TabStop = false;
            // 
            // lvMovesB
            // 
            this.lvMovesB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22});
            this.lvMovesB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvMovesB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMovesB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvMovesB.FullRowSelect = true;
            this.lvMovesB.GridLines = true;
            this.lvMovesB.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvMovesB.HideSelection = false;
            this.lvMovesB.Location = new System.Drawing.Point(0, 40);
            this.lvMovesB.MultiSelect = false;
            this.lvMovesB.Name = "lvMovesB";
            this.lvMovesB.ShowGroups = false;
            this.lvMovesB.Size = new System.Drawing.Size(1180, 86);
            this.lvMovesB.TabIndex = 32;
            this.lvMovesB.UseCompatibleStateImageBehavior = false;
            this.lvMovesB.View = System.Windows.Forms.View.Details;
            this.lvMovesB.DoubleClick += new System.EventHandler(this.lvPV_DoubleClick);
            this.lvMovesB.Resize += new System.EventHandler(this.lvLines_Resize);
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Time";
            this.columnHeader17.Width = 70;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Score";
            this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader18.Width = 100;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Depth";
            this.columnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader19.Width = 100;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Nodes";
            this.columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader20.Width = 92;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "NPS";
            this.columnHeader21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Principal Variation";
            this.columnHeader22.Width = 100;
            // 
            // panBlack
            // 
            this.panBlack.Controls.Add(this.tlpBlack);
            this.panBlack.Controls.Add(this.pictureBoxB);
            this.panBlack.Dock = System.Windows.Forms.DockStyle.Top;
            this.panBlack.Location = new System.Drawing.Point(0, 0);
            this.panBlack.Name = "panBlack";
            this.panBlack.Size = new System.Drawing.Size(1180, 40);
            this.panBlack.TabIndex = 33;
            // 
            // tlpBlack
            // 
            this.tlpBlack.ColumnCount = 7;
            this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpBlack.Controls.Add(this.labBookCB, 5, 1);
            this.tlpBlack.Controls.Add(this.labNpsB, 4, 1);
            this.tlpBlack.Controls.Add(this.labNodesB, 3, 1);
            this.tlpBlack.Controls.Add(this.labDepthB, 2, 1);
            this.tlpBlack.Controls.Add(this.labScoreB, 1, 1);
            this.tlpBlack.Controls.Add(this.labColB, 0, 1);
            this.tlpBlack.Controls.Add(this.labModeB, 4, 0);
            this.tlpBlack.Controls.Add(this.labProtocolB, 3, 0);
            this.tlpBlack.Controls.Add(this.labMemoryB, 6, 0);
            this.tlpBlack.Controls.Add(this.labBookNB, 5, 0);
            this.tlpBlack.Controls.Add(this.labBlack, 0, 0);
            this.tlpBlack.Controls.Add(this.labPlayerB, 1, 0);
            this.tlpBlack.Controls.Add(this.labEngineB, 2, 0);
            this.tlpBlack.Controls.Add(this.pbHashB, 6, 1);
            this.tlpBlack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBlack.Location = new System.Drawing.Point(100, 0);
            this.tlpBlack.Name = "tlpBlack";
            this.tlpBlack.RowCount = 2;
            this.tlpBlack.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBlack.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBlack.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBlack.Size = new System.Drawing.Size(1080, 40);
            this.tlpBlack.TabIndex = 36;
            // 
            // pictureBoxB
            // 
            this.pictureBoxB.BackColor = System.Drawing.Color.White;
            this.pictureBoxB.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxB.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxB.Name = "pictureBoxB";
            this.pictureBoxB.Size = new System.Drawing.Size(100, 40);
            this.pictureBoxB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxB.TabIndex = 0;
            this.pictureBoxB.TabStop = false;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 1;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.IncludeSubdirectories = true;
            this.fileSystemWatcher.Path = "Engines";
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_Renamed);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "fen";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Fen|*.fen|Pgn|*.pgn|Uci|*.uci|His|*.his";
            this.openFileDialog1.Title = "Load position";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "fen";
            this.saveFileDialog1.Filter = "Fen|*.fen|Pgn|*.pgn|Uci|*.uci|His|*.his";
            this.saveFileDialog1.Title = "Save position";
            // 
            // FormChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 862);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormChess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RapChessGui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChess_FormClosing);
            this.Load += new System.EventHandler(this.FormChess_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageGame.ResumeLayout(false);
            this.panChartGame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartGame)).EndInit();
            this.tabPageMatch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMatch)).EndInit();
            this.tlpMatch.ResumeLayout(false);
            this.tabPageTourB.ResumeLayout(false);
            this.scTourB.Panel1.ResumeLayout(false);
            this.scTourB.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTourB)).EndInit();
            this.scTourB.ResumeLayout(false);
            this.scTourBList.Panel1.ResumeLayout(false);
            this.scTourBList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTourBList)).EndInit();
            this.scTourBList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTournamentB)).EndInit();
            this.tabPageTourE.ResumeLayout(false);
            this.scTourE.Panel1.ResumeLayout(false);
            this.scTourE.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTourE)).EndInit();
            this.scTourE.ResumeLayout(false);
            this.scTourEList.Panel1.ResumeLayout(false);
            this.scTourEList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTourEList)).EndInit();
            this.scTourEList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTournamentE)).EndInit();
            this.tabPageTourP.ResumeLayout(false);
            this.scTourP.Panel1.ResumeLayout(false);
            this.scTourP.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTourP)).EndInit();
            this.scTourP.ResumeLayout(false);
            this.scTourPList.Panel1.ResumeLayout(false);
            this.scTourPList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTourPList)).EndInit();
            this.scTourPList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTournamentP)).EndInit();
            this.tabPageTraining.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTraining)).EndInit();
            this.tlpTraining.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTrainer)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTrained)).EndInit();
            this.tabPagePuzzle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPuzzle)).EndInit();
            this.tabPageEdit.ResumeLayout(false);
            this.tabPageEdit.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiPV)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.panChessState.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.gbToMove.ResumeLayout(false);
            this.gbToMove.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMove)).EndInit();
            this.groupBox14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudReversible)).EndInit();
            this.groupBox15.ResumeLayout(false);
            this.tlpEdit.ResumeLayout(false);
            this.tlpEdit.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panMenu.ResumeLayout(false);
            this.panMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.scBoard.Panel1.ResumeLayout(false);
            this.scBoard.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scBoard)).EndInit();
            this.scBoard.ResumeLayout(false);
            this.panBoard.ResumeLayout(false);
            this.tlpPromotion.ResumeLayout(false);
            this.tlpL.ResumeLayout(false);
            this.panBoardL.ResumeLayout(false);
            this.tlpChartB.ResumeLayout(false);
            this.tlpBoardL.ResumeLayout(false);
            this.tlpH.ResumeLayout(false);
            this.panBoardH.ResumeLayout(false);
            this.tlpChartW.ResumeLayout(false);
            this.tlpBoardH.ResumeLayout(false);
            this.scMode.Panel1.ResumeLayout(false);
            this.scMode.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMode)).EndInit();
            this.scMode.ResumeLayout(false);
            this.panGameMode.ResumeLayout(false);
            this.scRight.Panel1.ResumeLayout(false);
            this.scRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scRight)).EndInit();
            this.scRight.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPageGraph.ResumeLayout(false);
            this.panChartMain.ResumeLayout(false);
            this.tabPageAnalysis.ResumeLayout(false);
            this.tcLast.ResumeLayout(false);
            this.tpFens.ResumeLayout(false);
            this.tpGames.ResumeLayout(false);
            this.tpPuzzles.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.splitContainerMoves.Panel1.ResumeLayout(false);
            this.splitContainerMoves.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMoves)).EndInit();
            this.splitContainerMoves.ResumeLayout(false);
            this.panWhite.ResumeLayout(false);
            this.tlpWhite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxW)).EndInit();
            this.panBlack.ResumeLayout(false);
            this.tlpBlack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageGame;
		private System.Windows.Forms.TabPage tabPageTraining;
		private System.Windows.Forms.Button butNewGame;
		private System.Windows.Forms.Button butTraining;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cbTrainerEngine;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox cbTrainedEngine;
		private System.Windows.Forms.TableLayoutPanel tlpTraining;
		private System.Windows.Forms.Label labTrainRes2;
		private System.Windows.Forms.Label labTrainDraw2;
		private System.Windows.Forms.Label labTrainLost2;
		private System.Windows.Forms.Label labTrainWin2;
		private System.Windows.Forms.Label labTrainTeacher;
		private System.Windows.Forms.Label labTrainRes1;
		private System.Windows.Forms.Label labTrainDraw1;
		private System.Windows.Forms.Label labTrainLost1;
		private System.Windows.Forms.Label labTrainWin1;
		private System.Windows.Forms.Label labTrainResult;
		private System.Windows.Forms.Label labDraw;
		private System.Windows.Forms.Label labTrainLost;
		private System.Windows.Forms.Label labTrainWin;
		private System.Windows.Forms.Label labTrainPlayer;
		private System.Windows.Forms.Label labTrainTrained;
		private System.Windows.Forms.TabPage tabPageMatch;
		private System.Windows.Forms.TableLayoutPanel tlpMatch;
		private System.Windows.Forms.Label labMatch24;
		private System.Windows.Forms.Label labMatch23;
		private System.Windows.Forms.Label labMatch22;
		private System.Windows.Forms.Label labMatch21;
		private System.Windows.Forms.Label labMatchPlayer2;
		private System.Windows.Forms.Label labMatch14;
		private System.Windows.Forms.Label labMatch13;
		private System.Windows.Forms.Label labMatch12;
		private System.Windows.Forms.Label labMatch11;
		private System.Windows.Forms.Label labMatchRes;
		private System.Windows.Forms.Label labMatchDraw;
		private System.Windows.Forms.Label labMatchLost;
		private System.Windows.Forms.Label labMatchWin;
		private System.Windows.Forms.Label labMatchPlayer;
		private System.Windows.Forms.Label labMatchPlayer1;
		private System.Windows.Forms.Label labMatchGames;
		private System.Windows.Forms.Button butNewMatch;
		private System.Windows.Forms.NumericUpDown nudTrained;
		private System.Windows.Forms.NumericUpDown nudTrainer;
		private System.Windows.Forms.ComboBox cbTrainerBook;
		private System.Windows.Forms.TabPage tabPageTourP;
		private System.Windows.Forms.Button butStartTournament;
		private System.Windows.Forms.TabPage tabPageEdit;
		private System.Windows.Forms.Button butStop;
		private System.Windows.Forms.ComboBox cbTrainedBook;
		private System.Windows.Forms.ComboBox cbTrainerMode;
		private System.Windows.Forms.ComboBox cbTrainedMode;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem booksToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem enginesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
		private System.Windows.Forms.Label labGameTime;
		private System.Windows.Forms.Panel panMenu;
		private System.Windows.Forms.Label labEco;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tssMove;
		private System.Windows.Forms.ToolStripStatusLabel tssInfo;
		private System.Windows.Forms.SplitContainer scBoard;
		private System.Windows.Forms.Panel panBoard;
		private System.Windows.Forms.SplitContainer scMain;
		private System.Windows.Forms.SplitContainer splitContainerMoves;
		private System.Windows.Forms.ListView lvMovesW;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ListView lvMovesB;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.ColumnHeader columnHeader19;
		private System.Windows.Forms.ColumnHeader columnHeader20;
		private System.Windows.Forms.ColumnHeader columnHeader21;
		private System.Windows.Forms.ColumnHeader columnHeader22;
		private System.Windows.Forms.SplitContainer scTourP;
		private System.Windows.Forms.SplitContainer scMode;
		private System.Windows.Forms.SplitContainer scRight;
		private System.Windows.Forms.ListView lvMoves;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Panel panGameMode;
		private System.Windows.Forms.Button butResignation;
		private System.Windows.Forms.TabPage tabPageTourE;
		private System.Windows.Forms.SplitContainer scTourE;
		private System.Windows.Forms.Button butTourEStart;
		private System.Windows.Forms.Button butBackward;
		private System.Windows.Forms.Button butForward;
		private System.Windows.Forms.ToolStripMenuItem enginesToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem gamesToolStripMenuItem;
		public System.Windows.Forms.DataVisualization.Charting.Chart chartTraining;
		private System.Windows.Forms.SplitContainer scTourEList;
		private System.Windows.Forms.ListView lvTourEList;
		private System.Windows.Forms.ColumnHeader columnHeader23;
		private System.Windows.Forms.ColumnHeader columnHeader24;
		private System.Windows.Forms.ColumnHeader columnHeader25;
		private System.Windows.Forms.ListView lvTourESel;
		private System.Windows.Forms.ColumnHeader columnHeader26;
		private System.Windows.Forms.ColumnHeader columnHeader27;
		private System.Windows.Forms.ColumnHeader columnHeader28;
		private System.Windows.Forms.ColumnHeader columnHeader29;
		private System.Windows.Forms.Label labEngine;
		public System.Windows.Forms.DataVisualization.Charting.Chart chartTournamentE;
		private System.Windows.Forms.SplitContainer scTourPList;
		private System.Windows.Forms.ListView lvTourPList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Label labPlayer;
		private System.Windows.Forms.ListView lvTourPSel;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		public System.Windows.Forms.DataVisualization.Charting.Chart chartTournamentP;
		private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem enginesToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem programLogToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem lastGameToolStripMenuItem;
		private System.Windows.Forms.Label labError;
		private System.Windows.Forms.ToolStripMenuItem lastErrorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lastMatchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lasstTournamentenginesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lastTournamentplayersToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartMatch;
		private System.Windows.Forms.ToolStripMenuItem lastTrainingToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader30;
		private System.Windows.Forms.Timer timerAnimation;
		private System.IO.FileSystemWatcher fileSystemWatcher;
		private System.Windows.Forms.TabPage tabPageTourB;
		private System.Windows.Forms.SplitContainer scTourB;
		private System.Windows.Forms.SplitContainer scTourBList;
		private System.Windows.Forms.ListView lvTourBList;
		private System.Windows.Forms.ColumnHeader columnHeader32;
		private System.Windows.Forms.ColumnHeader columnHeader33;
		private System.Windows.Forms.ColumnHeader columnHeader34;
		private System.Windows.Forms.ListView lvTourBSel;
		private System.Windows.Forms.ColumnHeader columnHeader35;
		private System.Windows.Forms.ColumnHeader columnHeader36;
		private System.Windows.Forms.ColumnHeader columnHeader37;
		private System.Windows.Forms.ColumnHeader columnHeader38;
		private System.Windows.Forms.Label labBook;
		public System.Windows.Forms.DataVisualization.Charting.Chart chartTournamentB;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ToolStripMenuItem lastTournamentbooksToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem booksToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.TextBox tbFen;
		private System.Windows.Forms.Button butUpdate;
		private System.Windows.Forms.TableLayoutPanel tlpEdit;
		private System.Windows.Forms.Label lab_bk;
		private System.Windows.Forms.Label lab_bq;
		private System.Windows.Forms.Label lab_br;
		private System.Windows.Forms.Label lab_bb;
		private System.Windows.Forms.Label lab_bn;
		private System.Windows.Forms.Label lab_bp;
		private System.Windows.Forms.Label lab_K;
		private System.Windows.Forms.Label lab_Q;
		private System.Windows.Forms.Label lab_R;
		private System.Windows.Forms.Label lab_B;
		private System.Windows.Forms.Label lab_N;
		private System.Windows.Forms.Label lab_P;
		private System.Windows.Forms.ToolStripMenuItem listsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem enginesToolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem booksToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem lastAutodetectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Panel panWhite;
		private System.Windows.Forms.TableLayoutPanel tlpWhite;
		private System.Windows.Forms.Label labNpsW;
		private System.Windows.Forms.Label labNodesW;
		private System.Windows.Forms.Label labModeW;
		private System.Windows.Forms.Label labProtocolW;
		private System.Windows.Forms.Label labEngineW;
		private System.Windows.Forms.Label labMemoryW;
		private System.Windows.Forms.Label labDepthW;
		private System.Windows.Forms.Label labBookCW;
		private System.Windows.Forms.Label labWhite;
		private System.Windows.Forms.Label labColW;
		private System.Windows.Forms.Label labScoreW;
		private System.Windows.Forms.Label labPlayerW;
		private System.Windows.Forms.Label labBookNW;
		private System.Windows.Forms.ProgressBar pbHashW;
		private System.Windows.Forms.PictureBox pictureBoxW;
		private System.Windows.Forms.Panel panBlack;
		private System.Windows.Forms.TableLayoutPanel tlpBlack;
		private System.Windows.Forms.Label labBookCB;
		private System.Windows.Forms.Label labNpsB;
		private System.Windows.Forms.Label labNodesB;
		private System.Windows.Forms.Label labDepthB;
		private System.Windows.Forms.Label labScoreB;
		private System.Windows.Forms.Label labColB;
		private System.Windows.Forms.Label labModeB;
		private System.Windows.Forms.Label labProtocolB;
		private System.Windows.Forms.Label labMemoryB;
		private System.Windows.Forms.Label labBookNB;
		private System.Windows.Forms.Label labBlack;
		private System.Windows.Forms.Label labPlayerB;
		private System.Windows.Forms.Label labEngineB;
		private System.Windows.Forms.ProgressBar pbHashB;
		private System.Windows.Forms.PictureBox pictureBoxB;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.ComboBox cbApply;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPageGraph;
        private System.Windows.Forms.TabPage tabPageAnalysis;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button bPlay;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clipboardToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pgnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uciToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clipboardToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem fenToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem pgnToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem uciToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem lastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tournamentbooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tournamentenginesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tournamentplayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem errorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pgnToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem matchToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tournamentbooksToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tournamentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tournamentplayersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trainingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem errorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem puzzleToolStripMenuItem;
        private System.Windows.Forms.Panel panChartGame;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartGame;
        private System.Windows.Forms.Panel panChartMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        private System.Windows.Forms.Label labAccuracy;
        private System.Windows.Forms.Label labResult;
        public System.Windows.Forms.ComboBox cbGameMode;
        private System.Windows.Forms.TabPage tabPagePuzzle;
        private System.Windows.Forms.Button butPuzzleNext;
        private System.Windows.Forms.Label labPuzzle;
        private System.Windows.Forms.Button butHint;
        private System.Windows.Forms.Panel panChessState;
        private System.Windows.Forms.GroupBox gbToMove;
        private System.Windows.Forms.RadioButton rbBlack;
        private System.Windows.Forms.RadioButton rbWhite;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckedListBox clbCastling;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox lbEditMoves;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbEditEngine1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.NumericUpDown nudMultiPV;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbEditEngine2;
        private System.Windows.Forms.Label labPuzzleInfo;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartPuzzle;
        private System.Windows.Forms.Button bAnalysis;
        private System.Windows.Forms.Button butMove2;
        private System.Windows.Forms.Button butMove1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.NumericUpDown nudReversible;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.ComboBox cbPassant;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.NumericUpDown nudMove;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button butBoardClear;
        private System.Windows.Forms.Button butBoardDefault;
        private System.Windows.Forms.Button butBoardRotate;
        private System.Windows.Forms.TableLayoutPanel tlpPromotion;
        private System.Windows.Forms.Label labPromoB;
        private System.Windows.Forms.Label labPromoN;
        private System.Windows.Forms.Label labPromoQ;
        private System.Windows.Forms.Label labPromoR;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpL;
        private System.Windows.Forms.Label labColorL;
        private System.Windows.Forms.Panel panBoardL;
        private System.Windows.Forms.TableLayoutPanel tlpChartB;
        private System.Windows.Forms.Label labMaterialH;
        private System.Windows.Forms.Label labTakenL;
        private System.Windows.Forms.TableLayoutPanel tlpBoardL;
        private System.Windows.Forms.TableLayoutPanel tlpH;
        private System.Windows.Forms.Label labColorH;
        private System.Windows.Forms.Panel panBoardH;
        private System.Windows.Forms.TableLayoutPanel tlpChartW;
        private System.Windows.Forms.Label labMaterialL;
        private System.Windows.Forms.Label labTakenH;
        private System.Windows.Forms.TableLayoutPanel tlpBoardH;
        private System.Windows.Forms.Label labEloL;
        private System.Windows.Forms.Label labTimeL;
        private System.Windows.Forms.Label labNameL;
        private System.Windows.Forms.Label labEloH;
        private System.Windows.Forms.Label labTimeH;
        private System.Windows.Forms.Label labNameH;
        private System.Windows.Forms.TabControl tcLast;
        private System.Windows.Forms.TabPage tpFens;
        private System.Windows.Forms.TabPage tpGames;
        private System.Windows.Forms.TabPage tpPuzzles;
        private System.Windows.Forms.ListView lvFen;
        private System.Windows.Forms.ColumnHeader columnHeader42;
        private System.Windows.Forms.ColumnHeader chFenFen;
        private System.Windows.Forms.ListView lvPgn;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader39;
        private System.Windows.Forms.ColumnHeader chPgnPv;
        private System.Windows.Forms.ListView lvPuzzle;
        private System.Windows.Forms.ColumnHeader columnHeader40;
        private System.Windows.Forms.ColumnHeader chPuzzleFen;
        private System.Windows.Forms.ColumnHeader chPuzzlePv;
        private System.Windows.Forms.Button butLastDelete;
        private System.Windows.Forms.ToolStripMenuItem lastTimeToolStripMenuItem;
    }
}

