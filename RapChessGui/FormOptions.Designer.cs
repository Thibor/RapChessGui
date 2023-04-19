namespace RapChessGui
{
	partial class FormOptions
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.butDefault = new System.Windows.Forms.Button();
			this.gbInterface = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label17 = new System.Windows.Forms.Label();
			this.nudFontSize = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.nudHistory = new System.Windows.Forms.NumericUpDown();
			this.label18 = new System.Windows.Forms.Label();
			this.nudSpeed = new System.Windows.Forms.NumericUpDown();
			this.cbRotateBoard = new System.Windows.Forms.CheckBox();
			this.cbSound = new System.Windows.Forms.CheckBox();
			this.butColor = new System.Windows.Forms.Button();
			this.cbTips = new System.Windows.Forms.CheckBox();
			this.cbArrow = new System.Windows.Forms.CheckBox();
			this.cbAttack = new System.Windows.Forms.CheckBox();
			this.cbLink = new System.Windows.Forms.CheckBox();
			this.gbTimeMargin = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.combModeTime = new System.Windows.Forms.ComboBox();
			this.combModeStandard = new System.Windows.Forms.ComboBox();
			this.gbNotation = new System.Windows.Forms.GroupBox();
			this.rbUci = new System.Windows.Forms.RadioButton();
			this.rbSan = new System.Windows.Forms.RadioButton();
			this.gbPriority = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.cbSpam = new System.Windows.Forms.CheckBox();
			this.combPriority = new System.Windows.Forms.ComboBox();
			this.listBox = new System.Windows.Forms.ListBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageBooks = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lvBooks = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cbBookReader = new System.Windows.Forms.ComboBox();
			this.tabPageGame = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.cbGameBook = new System.Windows.Forms.ComboBox();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.cbGameEngine = new System.Windows.Forms.ComboBox();
			this.gbGame = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nudUserElo = new System.Windows.Forms.NumericUpDown();
			this.cbGameRanked = new System.Windows.Forms.CheckBox();
			this.tabPageInterface = new System.Windows.Forms.TabPage();
			this.tabPageMatch = new System.Windows.Forms.TabPage();
			this.gbMatch = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.nudBreak = new System.Windows.Forms.NumericUpDown();
			this.tabPageTourB = new System.Windows.Forms.TabPage();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.nudTourB = new System.Windows.Forms.NumericUpDown();
			this.cbTourBMode = new System.Windows.Forms.ComboBox();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.cbTourBEngine = new System.Windows.Forms.ComboBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.cbTourBSelected = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.nudTourBRange = new System.Windows.Forms.NumericUpDown();
			this.nudTourBAvg = new System.Windows.Forms.NumericUpDown();
			this.labTourB = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.nudTourBRec = new System.Windows.Forms.NumericUpDown();
			this.tabPageTourE = new System.Windows.Forms.TabPage();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.nudTourE = new System.Windows.Forms.NumericUpDown();
			this.cbTourEMode = new System.Windows.Forms.ComboBox();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.cbTourEBookS = new System.Windows.Forms.ComboBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.cbTourEBookF = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbTourESelected = new System.Windows.Forms.ComboBox();
			this.gbTournamentE = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.nudTourERange = new System.Windows.Forms.NumericUpDown();
			this.nudTourEAvg = new System.Windows.Forms.NumericUpDown();
			this.labTourE = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.nudTourERec = new System.Windows.Forms.NumericUpDown();
			this.tabPageTourP = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.cbTourPSelected = new System.Windows.Forms.ComboBox();
			this.gbTournamentP = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.nudTourPRange = new System.Windows.Forms.NumericUpDown();
			this.nudTourPAvg = new System.Windows.Forms.NumericUpDown();
			this.labTourP = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.nudTourPRec = new System.Windows.Forms.NumericUpDown();
			this.tabPageTraining = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.nudTraining = new System.Windows.Forms.NumericUpDown();
			this.gbInterface.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudHistory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
			this.gbTimeMargin.SuspendLayout();
			this.gbNotation.SuspendLayout();
			this.gbPriority.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPageBooks.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPageGame.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.gbGame.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudUserElo)).BeginInit();
			this.tabPageInterface.SuspendLayout();
			this.tabPageMatch.SuspendLayout();
			this.gbMatch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudBreak)).BeginInit();
			this.tabPageTourB.SuspendLayout();
			this.groupBox11.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourB)).BeginInit();
			this.groupBox10.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourBRange)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTourBAvg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTourBRec)).BeginInit();
			this.tabPageTourE.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourE)).BeginInit();
			this.groupBox13.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.gbTournamentE.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourERange)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTourEAvg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTourERec)).BeginInit();
			this.tabPageTourP.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.gbTournamentP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourPRange)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTourPAvg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTourPRec)).BeginInit();
			this.tabPageTraining.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTraining)).BeginInit();
			this.SuspendLayout();
			// 
			// butDefault
			// 
			this.butDefault.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.butDefault.Location = new System.Drawing.Point(0, 437);
			this.butDefault.Name = "butDefault";
			this.butDefault.Size = new System.Drawing.Size(491, 24);
			this.butDefault.TabIndex = 2;
			this.butDefault.Text = "Default";
			this.butDefault.UseVisualStyleBackColor = true;
			this.butDefault.Click += new System.EventHandler(this.butDefault_Click);
			// 
			// gbInterface
			// 
			this.gbInterface.Controls.Add(this.panel1);
			this.gbInterface.Controls.Add(this.cbRotateBoard);
			this.gbInterface.Controls.Add(this.cbSound);
			this.gbInterface.Controls.Add(this.butColor);
			this.gbInterface.Controls.Add(this.cbTips);
			this.gbInterface.Controls.Add(this.cbArrow);
			this.gbInterface.Controls.Add(this.cbAttack);
			this.gbInterface.Controls.Add(this.cbLink);
			this.gbInterface.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbInterface.Location = new System.Drawing.Point(3, 3);
			this.gbInterface.Name = "gbInterface";
			this.gbInterface.Size = new System.Drawing.Size(359, 211);
			this.gbInterface.TabIndex = 4;
			this.gbInterface.TabStop = false;
			this.gbInterface.Text = "Interface";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label17);
			this.panel1.Controls.Add(this.nudFontSize);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.nudHistory);
			this.panel1.Controls.Add(this.label18);
			this.panel1.Controls.Add(this.nudSpeed);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(3, 87);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(353, 97);
			this.panel1.TabIndex = 19;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(189, 75);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(49, 13);
			this.label17.TabIndex = 18;
			this.label17.Text = "Font size";
			// 
			// nudFontSize
			// 
			this.nudFontSize.Location = new System.Drawing.Point(9, 68);
			this.nudFontSize.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.nudFontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.nudFontSize.Name = "nudFontSize";
			this.nudFontSize.Size = new System.Drawing.Size(153, 20);
			this.nudFontSize.TabIndex = 17;
			this.nudFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudFontSize.ValueChanged += new System.EventHandler(this.nudFontSize_ValueChanged);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(189, 46);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(71, 13);
			this.label11.TabIndex = 16;
			this.label11.Text = "History length";
			// 
			// nudHistory
			// 
			this.nudHistory.Location = new System.Drawing.Point(9, 39);
			this.nudHistory.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.nudHistory.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudHistory.Name = "nudHistory";
			this.nudHistory.Size = new System.Drawing.Size(153, 20);
			this.nudHistory.TabIndex = 15;
			this.nudHistory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudHistory.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudHistory.ValueChanged += new System.EventHandler(this.nudHistory_ValueChanged);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(189, 17);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(85, 13);
			this.label18.TabIndex = 10;
			this.label18.Text = "Animation speed";
			// 
			// nudSpeed
			// 
			this.nudSpeed.Location = new System.Drawing.Point(9, 10);
			this.nudSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudSpeed.Name = "nudSpeed";
			this.nudSpeed.Size = new System.Drawing.Size(153, 20);
			this.nudSpeed.TabIndex = 9;
			this.nudSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudSpeed.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.nudSpeed.ValueChanged += new System.EventHandler(this.nudSpeed_ValueChanged);
			// 
			// cbRotateBoard
			// 
			this.cbRotateBoard.AutoSize = true;
			this.cbRotateBoard.Location = new System.Drawing.Point(12, 65);
			this.cbRotateBoard.Name = "cbRotateBoard";
			this.cbRotateBoard.Size = new System.Drawing.Size(88, 17);
			this.cbRotateBoard.TabIndex = 20;
			this.cbRotateBoard.Text = "Rotate board";
			this.cbRotateBoard.UseVisualStyleBackColor = true;
			this.cbRotateBoard.CheckedChanged += new System.EventHandler(this.CbRotateBoard_CheckedChanged);
			// 
			// cbSound
			// 
			this.cbSound.AutoSize = true;
			this.cbSound.Checked = true;
			this.cbSound.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSound.Location = new System.Drawing.Point(12, 42);
			this.cbSound.Name = "cbSound";
			this.cbSound.Size = new System.Drawing.Size(78, 17);
			this.cbSound.TabIndex = 13;
			this.cbSound.Text = "Play sound";
			this.cbSound.UseVisualStyleBackColor = true;
			this.cbSound.CheckedChanged += new System.EventHandler(this.cbSound_CheckedChanged);
			// 
			// butColor
			// 
			this.butColor.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.butColor.Location = new System.Drawing.Point(3, 184);
			this.butColor.Name = "butColor";
			this.butColor.Size = new System.Drawing.Size(353, 24);
			this.butColor.TabIndex = 4;
			this.butColor.Text = "Board color";
			this.butColor.UseVisualStyleBackColor = true;
			this.butColor.Click += new System.EventHandler(this.butColor_Click);
			// 
			// cbTips
			// 
			this.cbTips.AutoSize = true;
			this.cbTips.Checked = true;
			this.cbTips.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbTips.Location = new System.Drawing.Point(211, 65);
			this.cbTips.Name = "cbTips";
			this.cbTips.Size = new System.Drawing.Size(72, 17);
			this.cbTips.TabIndex = 12;
			this.cbTips.Text = "Show tips";
			this.cbTips.UseVisualStyleBackColor = true;
			this.cbTips.CheckedChanged += new System.EventHandler(this.cbTips_CheckedChanged);
			// 
			// cbArrow
			// 
			this.cbArrow.AutoSize = true;
			this.cbArrow.Checked = true;
			this.cbArrow.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbArrow.Location = new System.Drawing.Point(211, 19);
			this.cbArrow.Name = "cbArrow";
			this.cbArrow.Size = new System.Drawing.Size(82, 17);
			this.cbArrow.TabIndex = 10;
			this.cbArrow.Text = "Show arrow";
			this.cbArrow.UseVisualStyleBackColor = true;
			this.cbArrow.CheckedChanged += new System.EventHandler(this.cbArrow_CheckedChanged);
			// 
			// cbAttack
			// 
			this.cbAttack.AutoSize = true;
			this.cbAttack.Location = new System.Drawing.Point(211, 42);
			this.cbAttack.Name = "cbAttack";
			this.cbAttack.Size = new System.Drawing.Size(86, 17);
			this.cbAttack.TabIndex = 7;
			this.cbAttack.Text = "Show attack";
			this.cbAttack.UseVisualStyleBackColor = true;
			this.cbAttack.CheckedChanged += new System.EventHandler(this.cbAttack_CheckedChanged);
			// 
			// cbLink
			// 
			this.cbLink.AutoSize = true;
			this.cbLink.Location = new System.Drawing.Point(12, 19);
			this.cbLink.Name = "cbLink";
			this.cbLink.Size = new System.Drawing.Size(107, 17);
			this.cbLink.TabIndex = 18;
			this.cbLink.Text = "Desktop shortcut";
			this.cbLink.UseVisualStyleBackColor = true;
			this.cbLink.CheckedChanged += new System.EventHandler(this.cbLink_CheckedChanged);
			// 
			// gbTimeMargin
			// 
			this.gbTimeMargin.Controls.Add(this.label4);
			this.gbTimeMargin.Controls.Add(this.label3);
			this.gbTimeMargin.Controls.Add(this.combModeTime);
			this.gbTimeMargin.Controls.Add(this.combModeStandard);
			this.gbTimeMargin.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbTimeMargin.Location = new System.Drawing.Point(3, 267);
			this.gbTimeMargin.Name = "gbTimeMargin";
			this.gbTimeMargin.Size = new System.Drawing.Size(359, 78);
			this.gbTimeMargin.TabIndex = 8;
			this.gbTimeMargin.TabStop = false;
			this.gbTimeMargin.Text = "Time margin";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(168, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Mode time";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(168, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Mode standard";
			// 
			// combModeTime
			// 
			this.combModeTime.AutoCompleteCustomSource.AddRange(new string[] {
            "White",
            "Black"});
			this.combModeTime.Cursor = System.Windows.Forms.Cursors.Hand;
			this.combModeTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combModeTime.Items.AddRange(new object[] {
            "Off",
            "0 sec",
            "1 sec",
            "2 sec",
            "5 sec",
            "10 sec"});
			this.combModeTime.Location = new System.Drawing.Point(6, 46);
			this.combModeTime.Name = "combModeTime";
			this.combModeTime.Size = new System.Drawing.Size(153, 21);
			this.combModeTime.TabIndex = 4;
			this.combModeTime.SelectedIndexChanged += new System.EventHandler(this.combModeTime_SelectedIndexChanged);
			// 
			// combModeStandard
			// 
			this.combModeStandard.AutoCompleteCustomSource.AddRange(new string[] {
            "White",
            "Black"});
			this.combModeStandard.Cursor = System.Windows.Forms.Cursors.Hand;
			this.combModeStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combModeStandard.Items.AddRange(new object[] {
            "Off",
            "0 sec",
            "1 sec",
            "2 sec",
            "5 sec",
            "10 sec"});
			this.combModeStandard.Location = new System.Drawing.Point(6, 19);
			this.combModeStandard.Name = "combModeStandard";
			this.combModeStandard.Size = new System.Drawing.Size(153, 21);
			this.combModeStandard.TabIndex = 3;
			this.combModeStandard.SelectedIndexChanged += new System.EventHandler(this.combModeStandard_SelectedIndexChanged);
			// 
			// gbNotation
			// 
			this.gbNotation.Controls.Add(this.rbUci);
			this.gbNotation.Controls.Add(this.rbSan);
			this.gbNotation.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbNotation.Location = new System.Drawing.Point(3, 214);
			this.gbNotation.Name = "gbNotation";
			this.gbNotation.Size = new System.Drawing.Size(359, 53);
			this.gbNotation.TabIndex = 10;
			this.gbNotation.TabStop = false;
			this.gbNotation.Text = "Notation";
			// 
			// rbUci
			// 
			this.rbUci.AutoSize = true;
			this.rbUci.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbUci.Location = new System.Drawing.Point(3, 33);
			this.rbUci.Name = "rbUci";
			this.rbUci.Size = new System.Drawing.Size(353, 17);
			this.rbUci.TabIndex = 1;
			this.rbUci.Text = "Uci";
			this.rbUci.UseVisualStyleBackColor = true;
			// 
			// rbSan
			// 
			this.rbSan.AutoSize = true;
			this.rbSan.Checked = true;
			this.rbSan.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbSan.Location = new System.Drawing.Point(3, 16);
			this.rbSan.Name = "rbSan";
			this.rbSan.Size = new System.Drawing.Size(353, 17);
			this.rbSan.TabIndex = 0;
			this.rbSan.TabStop = true;
			this.rbSan.Text = "San";
			this.rbSan.UseVisualStyleBackColor = true;
			this.rbSan.CheckedChanged += new System.EventHandler(this.rbSan_CheckedChanged);
			// 
			// gbPriority
			// 
			this.gbPriority.Controls.Add(this.label15);
			this.gbPriority.Controls.Add(this.cbSpam);
			this.gbPriority.Controls.Add(this.combPriority);
			this.gbPriority.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbPriority.Location = new System.Drawing.Point(3, 345);
			this.gbPriority.Name = "gbPriority";
			this.gbPriority.Size = new System.Drawing.Size(359, 72);
			this.gbPriority.TabIndex = 11;
			this.gbPriority.TabStop = false;
			this.gbPriority.Text = "Engines";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(168, 42);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(78, 13);
			this.label15.TabIndex = 51;
			this.label15.Text = "Process priority";
			// 
			// cbSpam
			// 
			this.cbSpam.AutoSize = true;
			this.cbSpam.Checked = true;
			this.cbSpam.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSpam.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbSpam.Location = new System.Drawing.Point(3, 16);
			this.cbSpam.Name = "cbSpam";
			this.cbSpam.Size = new System.Drawing.Size(353, 17);
			this.cbSpam.TabIndex = 50;
			this.cbSpam.Text = "Ignore spam messages";
			this.cbSpam.UseVisualStyleBackColor = true;
			this.cbSpam.CheckedChanged += new System.EventHandler(this.cbSpam_CheckedChanged);
			// 
			// combPriority
			// 
			this.combPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combPriority.FormattingEnabled = true;
			this.combPriority.Items.AddRange(new object[] {
            "Idle",
            "Below normal",
            "Normal",
            "Above normal",
            "High"});
			this.combPriority.Location = new System.Drawing.Point(6, 39);
			this.combPriority.Name = "combPriority";
			this.combPriority.Size = new System.Drawing.Size(153, 21);
			this.combPriority.TabIndex = 49;
			this.combPriority.SelectedIndexChanged += new System.EventHandler(this.cbPriority_SelectedIndexChanged);
			// 
			// listBox
			// 
			this.listBox.Dock = System.Windows.Forms.DockStyle.Left;
			this.listBox.FormattingEnabled = true;
			this.listBox.Items.AddRange(new object[] {
            "Books",
            "Game",
            "Interface",
            "Match",
            "Tournament books",
            "Tournament engines",
            "Tournament players",
            "Training"});
			this.listBox.Location = new System.Drawing.Point(0, 0);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(118, 437);
			this.listBox.Sorted = true;
			this.listBox.TabIndex = 13;
			this.listBox.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageBooks);
			this.tabControl1.Controls.Add(this.tabPageGame);
			this.tabControl1.Controls.Add(this.tabPageInterface);
			this.tabControl1.Controls.Add(this.tabPageMatch);
			this.tabControl1.Controls.Add(this.tabPageTourB);
			this.tabControl1.Controls.Add(this.tabPageTourE);
			this.tabControl1.Controls.Add(this.tabPageTourP);
			this.tabControl1.Controls.Add(this.tabPageTraining);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
			this.tabControl1.Location = new System.Drawing.Point(118, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(373, 437);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 14;
			// 
			// tabPageBooks
			// 
			this.tabPageBooks.Controls.Add(this.groupBox1);
			this.tabPageBooks.Location = new System.Drawing.Point(4, 5);
			this.tabPageBooks.Name = "tabPageBooks";
			this.tabPageBooks.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageBooks.Size = new System.Drawing.Size(365, 428);
			this.tabPageBooks.TabIndex = 2;
			this.tabPageBooks.Text = "tabPage1";
			this.tabPageBooks.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lvBooks);
			this.groupBox1.Controls.Add(this.cbBookReader);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(359, 422);
			this.groupBox1.TabIndex = 51;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Autocreate";
			// 
			// lvBooks
			// 
			this.lvBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.lvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvBooks.FullRowSelect = true;
			this.lvBooks.GridLines = true;
			this.lvBooks.HideSelection = false;
			this.lvBooks.Location = new System.Drawing.Point(3, 16);
			this.lvBooks.MultiSelect = false;
			this.lvBooks.Name = "lvBooks";
			this.lvBooks.Size = new System.Drawing.Size(353, 382);
			this.lvBooks.TabIndex = 52;
			this.lvBooks.UseCompatibleStateImageBehavior = false;
			this.lvBooks.View = System.Windows.Forms.View.Details;
			this.lvBooks.SelectedIndexChanged += new System.EventHandler(this.lvBooks_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Directory";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Book Reader";
			this.columnHeader2.Width = 160;
			// 
			// cbBookReader
			// 
			this.cbBookReader.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.cbBookReader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBookReader.FormattingEnabled = true;
			this.cbBookReader.Location = new System.Drawing.Point(3, 398);
			this.cbBookReader.Name = "cbBookReader";
			this.cbBookReader.Size = new System.Drawing.Size(353, 21);
			this.cbBookReader.TabIndex = 51;
			this.cbBookReader.SelectedIndexChanged += new System.EventHandler(this.cbBookReader_SelectedIndexChanged);
			// 
			// tabPageGame
			// 
			this.tabPageGame.Controls.Add(this.groupBox5);
			this.tabPageGame.Controls.Add(this.groupBox12);
			this.tabPageGame.Controls.Add(this.gbGame);
			this.tabPageGame.Location = new System.Drawing.Point(4, 5);
			this.tabPageGame.Name = "tabPageGame";
			this.tabPageGame.Size = new System.Drawing.Size(365, 428);
			this.tabPageGame.TabIndex = 3;
			this.tabPageGame.Text = "Game";
			this.tabPageGame.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.cbGameBook);
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox5.Location = new System.Drawing.Point(0, 124);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(365, 44);
			this.groupBox5.TabIndex = 32;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Book";
			// 
			// cbGameBook
			// 
			this.cbGameBook.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbGameBook.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbGameBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbGameBook.FormattingEnabled = true;
			this.cbGameBook.Location = new System.Drawing.Point(3, 16);
			this.cbGameBook.Name = "cbGameBook";
			this.cbGameBook.Size = new System.Drawing.Size(359, 21);
			this.cbGameBook.TabIndex = 51;
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.cbGameEngine);
			this.groupBox12.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox12.Location = new System.Drawing.Point(0, 70);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(365, 54);
			this.groupBox12.TabIndex = 33;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Engine";
			// 
			// cbGameEngine
			// 
			this.cbGameEngine.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbGameEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbGameEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbGameEngine.FormattingEnabled = true;
			this.cbGameEngine.Location = new System.Drawing.Point(3, 16);
			this.cbGameEngine.Name = "cbGameEngine";
			this.cbGameEngine.Size = new System.Drawing.Size(359, 21);
			this.cbGameEngine.TabIndex = 51;
			// 
			// gbGame
			// 
			this.gbGame.Controls.Add(this.label1);
			this.gbGame.Controls.Add(this.nudUserElo);
			this.gbGame.Controls.Add(this.cbGameRanked);
			this.gbGame.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbGame.Location = new System.Drawing.Point(0, 0);
			this.gbGame.Name = "gbGame";
			this.gbGame.Size = new System.Drawing.Size(365, 70);
			this.gbGame.TabIndex = 7;
			this.gbGame.TabStop = false;
			this.gbGame.Text = "Game";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(144, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "User elo";
			// 
			// nudUserElo
			// 
			this.nudUserElo.Enabled = false;
			this.nudUserElo.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.nudUserElo.Location = new System.Drawing.Point(6, 39);
			this.nudUserElo.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			this.nudUserElo.Name = "nudUserElo";
			this.nudUserElo.Size = new System.Drawing.Size(120, 20);
			this.nudUserElo.TabIndex = 8;
			this.nudUserElo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudUserElo.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudUserElo.ValueChanged += new System.EventHandler(this.nudUserElo_ValueChanged);
			// 
			// cbGameRanked
			// 
			this.cbGameRanked.AutoSize = true;
			this.cbGameRanked.Checked = true;
			this.cbGameRanked.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbGameRanked.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbGameRanked.Location = new System.Drawing.Point(3, 16);
			this.cbGameRanked.Name = "cbGameRanked";
			this.cbGameRanked.Size = new System.Drawing.Size(359, 17);
			this.cbGameRanked.TabIndex = 5;
			this.cbGameRanked.Text = "Game ranked";
			this.cbGameRanked.UseVisualStyleBackColor = true;
			this.cbGameRanked.CheckedChanged += new System.EventHandler(this.cbGameAutoElo_CheckedChanged);
			// 
			// tabPageInterface
			// 
			this.tabPageInterface.Controls.Add(this.gbPriority);
			this.tabPageInterface.Controls.Add(this.gbTimeMargin);
			this.tabPageInterface.Controls.Add(this.gbNotation);
			this.tabPageInterface.Controls.Add(this.gbInterface);
			this.tabPageInterface.Location = new System.Drawing.Point(4, 5);
			this.tabPageInterface.Name = "tabPageInterface";
			this.tabPageInterface.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageInterface.Size = new System.Drawing.Size(365, 428);
			this.tabPageInterface.TabIndex = 0;
			this.tabPageInterface.Text = "Interface";
			this.tabPageInterface.UseVisualStyleBackColor = true;
			// 
			// tabPageMatch
			// 
			this.tabPageMatch.Controls.Add(this.gbMatch);
			this.tabPageMatch.Location = new System.Drawing.Point(4, 5);
			this.tabPageMatch.Name = "tabPageMatch";
			this.tabPageMatch.Size = new System.Drawing.Size(365, 428);
			this.tabPageMatch.TabIndex = 6;
			this.tabPageMatch.Text = "tabPage1";
			this.tabPageMatch.UseVisualStyleBackColor = true;
			// 
			// gbMatch
			// 
			this.gbMatch.Controls.Add(this.label7);
			this.gbMatch.Controls.Add(this.nudBreak);
			this.gbMatch.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbMatch.Location = new System.Drawing.Point(0, 0);
			this.gbMatch.Name = "gbMatch";
			this.gbMatch.Size = new System.Drawing.Size(365, 48);
			this.gbMatch.TabIndex = 16;
			this.gbMatch.TabStop = false;
			this.gbMatch.Text = "Match";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(168, 21);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(115, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "Break after each game";
			// 
			// nudBreak
			// 
			this.nudBreak.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudBreak.Location = new System.Drawing.Point(6, 19);
			this.nudBreak.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.nudBreak.Name = "nudBreak";
			this.nudBreak.Size = new System.Drawing.Size(156, 20);
			this.nudBreak.TabIndex = 9;
			this.nudBreak.TabStop = false;
			this.nudBreak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudBreak.ThousandsSeparator = true;
			this.nudBreak.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.nudBreak.ValueChanged += new System.EventHandler(this.nudMatch_ValueChanged);
			// 
			// tabPageTourB
			// 
			this.tabPageTourB.Controls.Add(this.groupBox11);
			this.tabPageTourB.Controls.Add(this.groupBox10);
			this.tabPageTourB.Controls.Add(this.groupBox7);
			this.tabPageTourB.Controls.Add(this.groupBox3);
			this.tabPageTourB.ForeColor = System.Drawing.Color.Black;
			this.tabPageTourB.Location = new System.Drawing.Point(4, 5);
			this.tabPageTourB.Name = "tabPageTourB";
			this.tabPageTourB.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTourB.Size = new System.Drawing.Size(365, 428);
			this.tabPageTourB.TabIndex = 1;
			this.tabPageTourB.Text = "Tournament books";
			this.tabPageTourB.UseVisualStyleBackColor = true;
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.nudTourB);
			this.groupBox11.Controls.Add(this.cbTourBMode);
			this.groupBox11.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox11.Location = new System.Drawing.Point(3, 185);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(359, 61);
			this.groupBox11.TabIndex = 33;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Time control";
			// 
			// nudTourB
			// 
			this.nudTourB.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudTourB.Location = new System.Drawing.Point(3, 37);
			this.nudTourB.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.nudTourB.Name = "nudTourB";
			this.nudTourB.Size = new System.Drawing.Size(353, 20);
			this.nudTourB.TabIndex = 51;
			this.nudTourB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourB.ThousandsSeparator = true;
			this.nudTourB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudTourB.ValueChanged += new System.EventHandler(this.nudTourB_ValueChanged);
			// 
			// cbTourBMode
			// 
			this.cbTourBMode.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTourBMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTourBMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTourBMode.FormattingEnabled = true;
			this.cbTourBMode.Items.AddRange(new object[] {
            "Depth",
            "Nodes",
            "Standard",
            "Time"});
			this.cbTourBMode.Location = new System.Drawing.Point(3, 16);
			this.cbTourBMode.Name = "cbTourBMode";
			this.cbTourBMode.Size = new System.Drawing.Size(353, 21);
			this.cbTourBMode.Sorted = true;
			this.cbTourBMode.TabIndex = 29;
			this.cbTourBMode.SelectedIndexChanged += new System.EventHandler(this.cbTourBMode_SelectedIndexChanged);
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.cbTourBEngine);
			this.groupBox10.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox10.Location = new System.Drawing.Point(3, 141);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(359, 44);
			this.groupBox10.TabIndex = 32;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Engine";
			// 
			// cbTourBEngine
			// 
			this.cbTourBEngine.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTourBEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTourBEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTourBEngine.FormattingEnabled = true;
			this.cbTourBEngine.Location = new System.Drawing.Point(3, 16);
			this.cbTourBEngine.Name = "cbTourBEngine";
			this.cbTourBEngine.Size = new System.Drawing.Size(353, 21);
			this.cbTourBEngine.Sorted = true;
			this.cbTourBEngine.TabIndex = 32;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.cbTourBSelected);
			this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox7.Location = new System.Drawing.Point(3, 97);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(359, 44);
			this.groupBox7.TabIndex = 31;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Selected book";
			// 
			// cbTourBSelected
			// 
			this.cbTourBSelected.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTourBSelected.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTourBSelected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTourBSelected.FormattingEnabled = true;
			this.cbTourBSelected.Location = new System.Drawing.Point(3, 16);
			this.cbTourBSelected.Name = "cbTourBSelected";
			this.cbTourBSelected.Size = new System.Drawing.Size(353, 21);
			this.cbTourBSelected.TabIndex = 51;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.nudTourBRange);
			this.groupBox3.Controls.Add(this.nudTourBAvg);
			this.groupBox3.Controls.Add(this.labTourB);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.nudTourBRec);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(3, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(359, 94);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Tournament-books";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(168, 76);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(39, 13);
			this.label13.TabIndex = 15;
			this.label13.Text = "Range";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(168, 52);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 13);
			this.label14.TabIndex = 14;
			this.label14.Text = "Average elo";
			// 
			// nudTourBRange
			// 
			this.nudTourBRange.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudTourBRange.Location = new System.Drawing.Point(6, 71);
			this.nudTourBRange.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			this.nudTourBRange.Name = "nudTourBRange";
			this.nudTourBRange.Size = new System.Drawing.Size(156, 20);
			this.nudTourBRange.TabIndex = 13;
			this.nudTourBRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourBRange.ThousandsSeparator = true;
			// 
			// nudTourBAvg
			// 
			this.nudTourBAvg.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudTourBAvg.Location = new System.Drawing.Point(6, 45);
			this.nudTourBAvg.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			this.nudTourBAvg.Name = "nudTourBAvg";
			this.nudTourBAvg.Size = new System.Drawing.Size(156, 20);
			this.nudTourBAvg.TabIndex = 12;
			this.nudTourBAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourBAvg.ThousandsSeparator = true;
			// 
			// labTourB
			// 
			this.labTourB.AutoSize = true;
			this.labTourB.Location = new System.Drawing.Point(168, 29);
			this.labTourB.Name = "labTourB";
			this.labTourB.Size = new System.Drawing.Size(19, 13);
			this.labTourB.TabIndex = 11;
			this.labTourB.Text = "Fill";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(168, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(98, 13);
			this.label16.TabIndex = 10;
			this.label16.Text = "Max history records";
			// 
			// nudTourBRec
			// 
			this.nudTourBRec.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourBRec.Location = new System.Drawing.Point(6, 19);
			this.nudTourBRec.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudTourBRec.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourBRec.Name = "nudTourBRec";
			this.nudTourBRec.Size = new System.Drawing.Size(156, 20);
			this.nudTourBRec.TabIndex = 9;
			this.nudTourBRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourBRec.ThousandsSeparator = true;
			this.nudTourBRec.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			// 
			// tabPageTourE
			// 
			this.tabPageTourE.Controls.Add(this.groupBox8);
			this.tabPageTourE.Controls.Add(this.groupBox13);
			this.tabPageTourE.Controls.Add(this.groupBox9);
			this.tabPageTourE.Controls.Add(this.groupBox4);
			this.tabPageTourE.Controls.Add(this.gbTournamentE);
			this.tabPageTourE.Location = new System.Drawing.Point(4, 5);
			this.tabPageTourE.Name = "tabPageTourE";
			this.tabPageTourE.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTourE.Size = new System.Drawing.Size(365, 428);
			this.tabPageTourE.TabIndex = 4;
			this.tabPageTourE.Text = "Tournament engines";
			this.tabPageTourE.UseVisualStyleBackColor = true;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.nudTourE);
			this.groupBox8.Controls.Add(this.cbTourEMode);
			this.groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox8.Location = new System.Drawing.Point(3, 229);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(359, 61);
			this.groupBox8.TabIndex = 31;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Time control";
			// 
			// nudTourE
			// 
			this.nudTourE.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudTourE.Location = new System.Drawing.Point(3, 37);
			this.nudTourE.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.nudTourE.Name = "nudTourE";
			this.nudTourE.Size = new System.Drawing.Size(353, 20);
			this.nudTourE.TabIndex = 51;
			this.nudTourE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourE.ThousandsSeparator = true;
			this.nudTourE.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudTourE.ValueChanged += new System.EventHandler(this.nudTourE_ValueChanged);
			// 
			// cbTourEMode
			// 
			this.cbTourEMode.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTourEMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTourEMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTourEMode.FormattingEnabled = true;
			this.cbTourEMode.Items.AddRange(new object[] {
            "Depth",
            "Nodes",
            "Standard",
            "Time"});
			this.cbTourEMode.Location = new System.Drawing.Point(3, 16);
			this.cbTourEMode.Name = "cbTourEMode";
			this.cbTourEMode.Size = new System.Drawing.Size(353, 21);
			this.cbTourEMode.Sorted = true;
			this.cbTourEMode.TabIndex = 29;
			this.cbTourEMode.SelectedIndexChanged += new System.EventHandler(this.cbTourEMode_SelectedIndexChanged);
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.cbTourEBookS);
			this.groupBox13.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox13.Location = new System.Drawing.Point(3, 185);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(359, 44);
			this.groupBox13.TabIndex = 32;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Second book";
			// 
			// cbTourEBookS
			// 
			this.cbTourEBookS.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTourEBookS.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTourEBookS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTourEBookS.FormattingEnabled = true;
			this.cbTourEBookS.Location = new System.Drawing.Point(3, 16);
			this.cbTourEBookS.Name = "cbTourEBookS";
			this.cbTourEBookS.Size = new System.Drawing.Size(353, 21);
			this.cbTourEBookS.Sorted = true;
			this.cbTourEBookS.TabIndex = 32;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.cbTourEBookF);
			this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox9.Location = new System.Drawing.Point(3, 141);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(359, 44);
			this.groupBox9.TabIndex = 29;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "First book";
			// 
			// cbTourEBookF
			// 
			this.cbTourEBookF.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTourEBookF.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTourEBookF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTourEBookF.FormattingEnabled = true;
			this.cbTourEBookF.Location = new System.Drawing.Point(3, 16);
			this.cbTourEBookF.Name = "cbTourEBookF";
			this.cbTourEBookF.Size = new System.Drawing.Size(353, 21);
			this.cbTourEBookF.Sorted = true;
			this.cbTourEBookF.TabIndex = 32;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cbTourESelected);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox4.Location = new System.Drawing.Point(3, 97);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(359, 44);
			this.groupBox4.TabIndex = 30;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Selected engine";
			// 
			// cbTourESelected
			// 
			this.cbTourESelected.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTourESelected.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTourESelected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTourESelected.FormattingEnabled = true;
			this.cbTourESelected.Location = new System.Drawing.Point(3, 16);
			this.cbTourESelected.Name = "cbTourESelected";
			this.cbTourESelected.Size = new System.Drawing.Size(353, 21);
			this.cbTourESelected.TabIndex = 51;
			// 
			// gbTournamentE
			// 
			this.gbTournamentE.Controls.Add(this.label8);
			this.gbTournamentE.Controls.Add(this.label5);
			this.gbTournamentE.Controls.Add(this.nudTourERange);
			this.gbTournamentE.Controls.Add(this.nudTourEAvg);
			this.gbTournamentE.Controls.Add(this.labTourE);
			this.gbTournamentE.Controls.Add(this.label6);
			this.gbTournamentE.Controls.Add(this.nudTourERec);
			this.gbTournamentE.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbTournamentE.Location = new System.Drawing.Point(3, 3);
			this.gbTournamentE.Name = "gbTournamentE";
			this.gbTournamentE.Size = new System.Drawing.Size(359, 94);
			this.gbTournamentE.TabIndex = 10;
			this.gbTournamentE.TabStop = false;
			this.gbTournamentE.Text = "Tournament-engines";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(168, 76);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(39, 13);
			this.label8.TabIndex = 15;
			this.label8.Text = "Range";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(168, 52);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Average elo";
			// 
			// nudTourERange
			// 
			this.nudTourERange.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudTourERange.Location = new System.Drawing.Point(6, 71);
			this.nudTourERange.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			this.nudTourERange.Name = "nudTourERange";
			this.nudTourERange.Size = new System.Drawing.Size(156, 20);
			this.nudTourERange.TabIndex = 13;
			this.nudTourERange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourERange.ThousandsSeparator = true;
			// 
			// nudTourEAvg
			// 
			this.nudTourEAvg.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudTourEAvg.Location = new System.Drawing.Point(6, 45);
			this.nudTourEAvg.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			this.nudTourEAvg.Name = "nudTourEAvg";
			this.nudTourEAvg.Size = new System.Drawing.Size(156, 20);
			this.nudTourEAvg.TabIndex = 12;
			this.nudTourEAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourEAvg.ThousandsSeparator = true;
			// 
			// labTourE
			// 
			this.labTourE.AutoSize = true;
			this.labTourE.Location = new System.Drawing.Point(168, 29);
			this.labTourE.Name = "labTourE";
			this.labTourE.Size = new System.Drawing.Size(19, 13);
			this.labTourE.TabIndex = 11;
			this.labTourE.Text = "Fill";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(168, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(98, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Max history records";
			// 
			// nudTourERec
			// 
			this.nudTourERec.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourERec.Location = new System.Drawing.Point(6, 19);
			this.nudTourERec.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudTourERec.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourERec.Name = "nudTourERec";
			this.nudTourERec.Size = new System.Drawing.Size(156, 20);
			this.nudTourERec.TabIndex = 9;
			this.nudTourERec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourERec.ThousandsSeparator = true;
			this.nudTourERec.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			// 
			// tabPageTourP
			// 
			this.tabPageTourP.Controls.Add(this.groupBox6);
			this.tabPageTourP.Controls.Add(this.gbTournamentP);
			this.tabPageTourP.Location = new System.Drawing.Point(4, 5);
			this.tabPageTourP.Name = "tabPageTourP";
			this.tabPageTourP.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTourP.Size = new System.Drawing.Size(365, 428);
			this.tabPageTourP.TabIndex = 5;
			this.tabPageTourP.Text = "Tournament players";
			this.tabPageTourP.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.cbTourPSelected);
			this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox6.Location = new System.Drawing.Point(3, 97);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(359, 44);
			this.groupBox6.TabIndex = 31;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Selected player";
			// 
			// cbTourPSelected
			// 
			this.cbTourPSelected.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTourPSelected.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTourPSelected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTourPSelected.FormattingEnabled = true;
			this.cbTourPSelected.Location = new System.Drawing.Point(3, 16);
			this.cbTourPSelected.Name = "cbTourPSelected";
			this.cbTourPSelected.Size = new System.Drawing.Size(353, 21);
			this.cbTourPSelected.TabIndex = 51;
			// 
			// gbTournamentP
			// 
			this.gbTournamentP.Controls.Add(this.label10);
			this.gbTournamentP.Controls.Add(this.label9);
			this.gbTournamentP.Controls.Add(this.nudTourPRange);
			this.gbTournamentP.Controls.Add(this.nudTourPAvg);
			this.gbTournamentP.Controls.Add(this.labTourP);
			this.gbTournamentP.Controls.Add(this.label2);
			this.gbTournamentP.Controls.Add(this.nudTourPRec);
			this.gbTournamentP.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbTournamentP.Location = new System.Drawing.Point(3, 3);
			this.gbTournamentP.Name = "gbTournamentP";
			this.gbTournamentP.Size = new System.Drawing.Size(359, 94);
			this.gbTournamentP.TabIndex = 8;
			this.gbTournamentP.TabStop = false;
			this.gbTournamentP.Text = "Tournament-players";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(168, 76);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(39, 13);
			this.label10.TabIndex = 15;
			this.label10.Text = "Range";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(168, 52);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "Average elo";
			// 
			// nudTourPRange
			// 
			this.nudTourPRange.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudTourPRange.Location = new System.Drawing.Point(6, 71);
			this.nudTourPRange.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			this.nudTourPRange.Name = "nudTourPRange";
			this.nudTourPRange.Size = new System.Drawing.Size(156, 20);
			this.nudTourPRange.TabIndex = 13;
			this.nudTourPRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourPRange.ThousandsSeparator = true;
			// 
			// nudTourPAvg
			// 
			this.nudTourPAvg.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudTourPAvg.Location = new System.Drawing.Point(6, 45);
			this.nudTourPAvg.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			this.nudTourPAvg.Name = "nudTourPAvg";
			this.nudTourPAvg.Size = new System.Drawing.Size(156, 20);
			this.nudTourPAvg.TabIndex = 12;
			this.nudTourPAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourPAvg.ThousandsSeparator = true;
			// 
			// labTourP
			// 
			this.labTourP.AutoSize = true;
			this.labTourP.Location = new System.Drawing.Point(168, 29);
			this.labTourP.Name = "labTourP";
			this.labTourP.Size = new System.Drawing.Size(19, 13);
			this.labTourP.TabIndex = 11;
			this.labTourP.Text = "Fill";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(168, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Max history records";
			// 
			// nudTourPRec
			// 
			this.nudTourPRec.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourPRec.Location = new System.Drawing.Point(6, 19);
			this.nudTourPRec.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudTourPRec.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourPRec.Name = "nudTourPRec";
			this.nudTourPRec.Size = new System.Drawing.Size(156, 20);
			this.nudTourPRec.TabIndex = 9;
			this.nudTourPRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourPRec.ThousandsSeparator = true;
			this.nudTourPRec.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			// 
			// tabPageTraining
			// 
			this.tabPageTraining.Controls.Add(this.groupBox2);
			this.tabPageTraining.Location = new System.Drawing.Point(4, 5);
			this.tabPageTraining.Name = "tabPageTraining";
			this.tabPageTraining.Size = new System.Drawing.Size(365, 428);
			this.tabPageTraining.TabIndex = 7;
			this.tabPageTraining.Text = "tabPage2";
			this.tabPageTraining.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.nudTraining);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(365, 48);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Training";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(168, 21);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(81, 13);
			this.label12.TabIndex = 10;
			this.label12.Text = "Trainer strength";
			// 
			// nudTraining
			// 
			this.nudTraining.Location = new System.Drawing.Point(6, 19);
			this.nudTraining.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.nudTraining.Name = "nudTraining";
			this.nudTraining.Size = new System.Drawing.Size(156, 20);
			this.nudTraining.TabIndex = 9;
			this.nudTraining.TabStop = false;
			this.nudTraining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTraining.ThousandsSeparator = true;
			this.nudTraining.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudTraining.ValueChanged += new System.EventHandler(this.nudTraining_ValueChanged);
			// 
			// FormOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(491, 461);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.listBox);
			this.Controls.Add(this.butDefault);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormOptions";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOptions_FormClosing);
			this.Load += new System.EventHandler(this.FormOptions_Load);
			this.Shown += new System.EventHandler(this.FormOptions_Shown);
			this.gbInterface.ResumeLayout(false);
			this.gbInterface.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudHistory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
			this.gbTimeMargin.ResumeLayout(false);
			this.gbTimeMargin.PerformLayout();
			this.gbNotation.ResumeLayout(false);
			this.gbNotation.PerformLayout();
			this.gbPriority.ResumeLayout(false);
			this.gbPriority.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPageBooks.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPageGame.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.gbGame.ResumeLayout(false);
			this.gbGame.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudUserElo)).EndInit();
			this.tabPageInterface.ResumeLayout(false);
			this.tabPageMatch.ResumeLayout(false);
			this.gbMatch.ResumeLayout(false);
			this.gbMatch.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudBreak)).EndInit();
			this.tabPageTourB.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudTourB)).EndInit();
			this.groupBox10.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourBRange)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTourBAvg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTourBRec)).EndInit();
			this.tabPageTourE.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudTourE)).EndInit();
			this.groupBox13.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.gbTournamentE.ResumeLayout(false);
			this.gbTournamentE.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourERange)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTourEAvg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTourERec)).EndInit();
			this.tabPageTourP.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.gbTournamentP.ResumeLayout(false);
			this.gbTournamentP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourPRange)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTourPAvg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTourPRec)).EndInit();
			this.tabPageTraining.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTraining)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button butDefault;
		private System.Windows.Forms.GroupBox gbInterface;
		private System.Windows.Forms.Button butColor;
		public System.Windows.Forms.CheckBox cbAttack;
		public System.Windows.Forms.CheckBox cbArrow;
		public System.Windows.Forms.CheckBox cbTips;
		private System.Windows.Forms.GroupBox gbTimeMargin;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox combModeTime;
		private System.Windows.Forms.ComboBox combModeStandard;
		private System.Windows.Forms.GroupBox gbNotation;
		private System.Windows.Forms.RadioButton rbUci;
		public System.Windows.Forms.RadioButton rbSan;
		private System.Windows.Forms.GroupBox gbPriority;
		private System.Windows.Forms.ComboBox combPriority;
		public System.Windows.Forms.CheckBox cbSound;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageInterface;
		private System.Windows.Forms.TabPage tabPageTourB;
		private System.Windows.Forms.TabPage tabPageBooks;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListView lvBooks;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ComboBox cbBookReader;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		public System.Windows.Forms.NumericUpDown nudTourBRange;
		public System.Windows.Forms.NumericUpDown nudTourBAvg;
		private System.Windows.Forms.Label labTourB;
		private System.Windows.Forms.Label label16;
		public System.Windows.Forms.NumericUpDown nudTourBRec;
		private System.Windows.Forms.Label label15;
		public System.Windows.Forms.CheckBox cbSpam;
		private System.Windows.Forms.TabPage tabPageGame;
		private System.Windows.Forms.GroupBox gbGame;
		public System.Windows.Forms.CheckBox cbGameRanked;
		private System.Windows.Forms.TabPage tabPageTourE;
		private System.Windows.Forms.TabPage tabPageTourP;
		private System.Windows.Forms.GroupBox gbTournamentE;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.NumericUpDown nudTourERange;
		public System.Windows.Forms.NumericUpDown nudTourEAvg;
		private System.Windows.Forms.Label labTourE;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.NumericUpDown nudTourERec;
		private System.Windows.Forms.GroupBox gbTournamentP;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		public System.Windows.Forms.NumericUpDown nudTourPRange;
		public System.Windows.Forms.NumericUpDown nudTourPAvg;
		private System.Windows.Forms.Label labTourP;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.NumericUpDown nudTourPRec;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.NumericUpDown nudTourE;
		private System.Windows.Forms.ComboBox cbTourEMode;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.NumericUpDown nudTourB;
		private System.Windows.Forms.ComboBox cbTourBMode;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label17;
		public System.Windows.Forms.NumericUpDown nudFontSize;
		private System.Windows.Forms.Label label11;
		public System.Windows.Forms.NumericUpDown nudHistory;
		private System.Windows.Forms.Label label18;
		public System.Windows.Forms.NumericUpDown nudSpeed;
		public System.Windows.Forms.CheckBox cbLink;
		private System.Windows.Forms.TabPage tabPageMatch;
		private System.Windows.Forms.TabPage tabPageTraining;
		private System.Windows.Forms.GroupBox gbMatch;
		private System.Windows.Forms.Label label7;
		public System.Windows.Forms.NumericUpDown nudBreak;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label12;
		public System.Windows.Forms.NumericUpDown nudTraining;
		public System.Windows.Forms.ListBox listBox;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.NumericUpDown nudUserElo;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.CheckBox cbRotateBoard;
		public System.Windows.Forms.ComboBox cbTourPSelected;
		public System.Windows.Forms.ComboBox cbTourBSelected;
		public System.Windows.Forms.ComboBox cbTourESelected;
		public System.Windows.Forms.ComboBox cbTourEBookF;
		public System.Windows.Forms.ComboBox cbTourEBookS;
		public System.Windows.Forms.ComboBox cbTourBEngine;
		public System.Windows.Forms.ComboBox cbGameEngine;
		public System.Windows.Forms.ComboBox cbGameBook;
	}
}