﻿namespace RapChessGui
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
			this.cbSound = new System.Windows.Forms.CheckBox();
			this.butColor = new System.Windows.Forms.Button();
			this.cbTips = new System.Windows.Forms.CheckBox();
			this.cbArrow = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nudSpeed = new System.Windows.Forms.NumericUpDown();
			this.cbAttack = new System.Windows.Forms.CheckBox();
			this.cbShowPonder = new System.Windows.Forms.CheckBox();
			this.gbGame = new System.Windows.Forms.GroupBox();
			this.cbRotateBoard = new System.Windows.Forms.CheckBox();
			this.cbGameAutoElo = new System.Windows.Forms.CheckBox();
			this.gbTournamentP = new System.Windows.Forms.GroupBox();
			this.labTourP = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.nudTourP = new System.Windows.Forms.NumericUpDown();
			this.gbTimeMargin = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.combModeTime = new System.Windows.Forms.ComboBox();
			this.combModeStandard = new System.Windows.Forms.ComboBox();
			this.gbTournamentE = new System.Windows.Forms.GroupBox();
			this.labTourE = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.nudTourE = new System.Windows.Forms.NumericUpDown();
			this.gbNotation = new System.Windows.Forms.GroupBox();
			this.rbUci = new System.Windows.Forms.RadioButton();
			this.rbSan = new System.Windows.Forms.RadioButton();
			this.gbPriority = new System.Windows.Forms.GroupBox();
			this.combPriority = new System.Windows.Forms.ComboBox();
			this.gbMatch = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.nudBreak = new System.Windows.Forms.NumericUpDown();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageInterface = new System.Windows.Forms.TabPage();
			this.tabPageModes = new System.Windows.Forms.TabPage();
			this.nudMaxEloP = new System.Windows.Forms.NumericUpDown();
			this.nudMinEloP = new System.Windows.Forms.NumericUpDown();
			this.nudMaxEloE = new System.Windows.Forms.NumericUpDown();
			this.nudMinEloE = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.gbInterface.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
			this.gbGame.SuspendLayout();
			this.gbTournamentP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourP)).BeginInit();
			this.gbTimeMargin.SuspendLayout();
			this.gbTournamentE.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourE)).BeginInit();
			this.gbNotation.SuspendLayout();
			this.gbPriority.SuspendLayout();
			this.gbMatch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudBreak)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPageInterface.SuspendLayout();
			this.tabPageModes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxEloP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMinEloP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxEloE)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMinEloE)).BeginInit();
			this.SuspendLayout();
			// 
			// butDefault
			// 
			this.butDefault.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.butDefault.Location = new System.Drawing.Point(0, 370);
			this.butDefault.Name = "butDefault";
			this.butDefault.Size = new System.Drawing.Size(491, 24);
			this.butDefault.TabIndex = 2;
			this.butDefault.Text = "Default";
			this.butDefault.UseVisualStyleBackColor = true;
			this.butDefault.Click += new System.EventHandler(this.butDefault_Click);
			// 
			// gbInterface
			// 
			this.gbInterface.Controls.Add(this.cbSound);
			this.gbInterface.Controls.Add(this.butColor);
			this.gbInterface.Controls.Add(this.cbTips);
			this.gbInterface.Controls.Add(this.cbArrow);
			this.gbInterface.Controls.Add(this.label1);
			this.gbInterface.Controls.Add(this.nudSpeed);
			this.gbInterface.Controls.Add(this.cbAttack);
			this.gbInterface.Controls.Add(this.cbShowPonder);
			this.gbInterface.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbInterface.Location = new System.Drawing.Point(3, 3);
			this.gbInterface.Name = "gbInterface";
			this.gbInterface.Size = new System.Drawing.Size(359, 158);
			this.gbInterface.TabIndex = 4;
			this.gbInterface.TabStop = false;
			this.gbInterface.Text = "Interface";
			// 
			// cbSound
			// 
			this.cbSound.AutoSize = true;
			this.cbSound.Checked = true;
			this.cbSound.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSound.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbSound.Location = new System.Drawing.Point(3, 84);
			this.cbSound.Name = "cbSound";
			this.cbSound.Size = new System.Drawing.Size(353, 17);
			this.cbSound.TabIndex = 13;
			this.cbSound.Text = "Play sound";
			this.cbSound.UseVisualStyleBackColor = true;
			// 
			// butColor
			// 
			this.butColor.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.butColor.Location = new System.Drawing.Point(3, 131);
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
			this.cbTips.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTips.Location = new System.Drawing.Point(3, 67);
			this.cbTips.Name = "cbTips";
			this.cbTips.Size = new System.Drawing.Size(353, 17);
			this.cbTips.TabIndex = 12;
			this.cbTips.Text = "Show tips";
			this.cbTips.UseVisualStyleBackColor = true;
			// 
			// cbArrow
			// 
			this.cbArrow.AutoSize = true;
			this.cbArrow.Checked = true;
			this.cbArrow.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbArrow.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbArrow.Location = new System.Drawing.Point(3, 50);
			this.cbArrow.Name = "cbArrow";
			this.cbArrow.Size = new System.Drawing.Size(353, 17);
			this.cbArrow.TabIndex = 10;
			this.cbArrow.Text = "Show arrow";
			this.cbArrow.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(168, 109);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Animation speed";
			// 
			// nudSpeed
			// 
			this.nudSpeed.Location = new System.Drawing.Point(3, 107);
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
			this.nudSpeed.TabIndex = 8;
			this.nudSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudSpeed.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			// 
			// cbAttack
			// 
			this.cbAttack.AutoSize = true;
			this.cbAttack.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbAttack.Location = new System.Drawing.Point(3, 33);
			this.cbAttack.Name = "cbAttack";
			this.cbAttack.Size = new System.Drawing.Size(353, 17);
			this.cbAttack.TabIndex = 7;
			this.cbAttack.Text = "Show attack";
			this.cbAttack.UseVisualStyleBackColor = true;
			// 
			// cbShowPonder
			// 
			this.cbShowPonder.AutoSize = true;
			this.cbShowPonder.Checked = true;
			this.cbShowPonder.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbShowPonder.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbShowPonder.Location = new System.Drawing.Point(3, 16);
			this.cbShowPonder.Name = "cbShowPonder";
			this.cbShowPonder.Size = new System.Drawing.Size(353, 17);
			this.cbShowPonder.TabIndex = 6;
			this.cbShowPonder.Text = "Show ponder";
			this.cbShowPonder.UseVisualStyleBackColor = true;
			// 
			// gbGame
			// 
			this.gbGame.Controls.Add(this.cbRotateBoard);
			this.gbGame.Controls.Add(this.cbGameAutoElo);
			this.gbGame.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbGame.Location = new System.Drawing.Point(3, 3);
			this.gbGame.Name = "gbGame";
			this.gbGame.Size = new System.Drawing.Size(359, 52);
			this.gbGame.TabIndex = 6;
			this.gbGame.TabStop = false;
			this.gbGame.Text = "Game";
			// 
			// cbRotateBoard
			// 
			this.cbRotateBoard.AutoSize = true;
			this.cbRotateBoard.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbRotateBoard.Location = new System.Drawing.Point(3, 33);
			this.cbRotateBoard.Name = "cbRotateBoard";
			this.cbRotateBoard.Size = new System.Drawing.Size(353, 17);
			this.cbRotateBoard.TabIndex = 6;
			this.cbRotateBoard.Text = "Rotate board";
			this.cbRotateBoard.UseVisualStyleBackColor = true;
			this.cbRotateBoard.CheckedChanged += new System.EventHandler(this.CbRotateBoard_CheckedChanged);
			// 
			// cbGameAutoElo
			// 
			this.cbGameAutoElo.AutoSize = true;
			this.cbGameAutoElo.Checked = true;
			this.cbGameAutoElo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbGameAutoElo.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbGameAutoElo.Location = new System.Drawing.Point(3, 16);
			this.cbGameAutoElo.Name = "cbGameAutoElo";
			this.cbGameAutoElo.Size = new System.Drawing.Size(353, 17);
			this.cbGameAutoElo.TabIndex = 5;
			this.cbGameAutoElo.Text = "Auto elo";
			this.cbGameAutoElo.UseVisualStyleBackColor = true;
			// 
			// gbTournamentP
			// 
			this.gbTournamentP.Controls.Add(this.label10);
			this.gbTournamentP.Controls.Add(this.label9);
			this.gbTournamentP.Controls.Add(this.nudMinEloP);
			this.gbTournamentP.Controls.Add(this.nudMaxEloP);
			this.gbTournamentP.Controls.Add(this.labTourP);
			this.gbTournamentP.Controls.Add(this.label2);
			this.gbTournamentP.Controls.Add(this.nudTourP);
			this.gbTournamentP.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbTournamentP.Location = new System.Drawing.Point(3, 202);
			this.gbTournamentP.Name = "gbTournamentP";
			this.gbTournamentP.Size = new System.Drawing.Size(359, 96);
			this.gbTournamentP.TabIndex = 7;
			this.gbTournamentP.TabStop = false;
			this.gbTournamentP.Text = "Tournament-players";
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
			// nudTourP
			// 
			this.nudTourP.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourP.Location = new System.Drawing.Point(6, 19);
			this.nudTourP.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudTourP.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourP.Name = "nudTourP";
			this.nudTourP.Size = new System.Drawing.Size(156, 20);
			this.nudTourP.TabIndex = 9;
			this.nudTourP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourP.ThousandsSeparator = true;
			this.nudTourP.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			// 
			// gbTimeMargin
			// 
			this.gbTimeMargin.Controls.Add(this.label4);
			this.gbTimeMargin.Controls.Add(this.label3);
			this.gbTimeMargin.Controls.Add(this.combModeTime);
			this.gbTimeMargin.Controls.Add(this.combModeStandard);
			this.gbTimeMargin.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbTimeMargin.Location = new System.Drawing.Point(3, 214);
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
            "5 sec"});
			this.combModeTime.Location = new System.Drawing.Point(6, 46);
			this.combModeTime.Name = "combModeTime";
			this.combModeTime.Size = new System.Drawing.Size(153, 21);
			this.combModeTime.TabIndex = 4;
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
            "5 sec"});
			this.combModeStandard.Location = new System.Drawing.Point(6, 19);
			this.combModeStandard.Name = "combModeStandard";
			this.combModeStandard.Size = new System.Drawing.Size(153, 21);
			this.combModeStandard.TabIndex = 3;
			// 
			// gbTournamentE
			// 
			this.gbTournamentE.Controls.Add(this.label8);
			this.gbTournamentE.Controls.Add(this.label5);
			this.gbTournamentE.Controls.Add(this.nudMinEloE);
			this.gbTournamentE.Controls.Add(this.nudMaxEloE);
			this.gbTournamentE.Controls.Add(this.labTourE);
			this.gbTournamentE.Controls.Add(this.label6);
			this.gbTournamentE.Controls.Add(this.nudTourE);
			this.gbTournamentE.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbTournamentE.Location = new System.Drawing.Point(3, 103);
			this.gbTournamentE.Name = "gbTournamentE";
			this.gbTournamentE.Size = new System.Drawing.Size(359, 99);
			this.gbTournamentE.TabIndex = 9;
			this.gbTournamentE.TabStop = false;
			this.gbTournamentE.Text = "Tournament-engines";
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
			// nudTourE
			// 
			this.nudTourE.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourE.Location = new System.Drawing.Point(6, 19);
			this.nudTourE.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudTourE.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourE.Name = "nudTourE";
			this.nudTourE.Size = new System.Drawing.Size(156, 20);
			this.nudTourE.TabIndex = 9;
			this.nudTourE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourE.ThousandsSeparator = true;
			this.nudTourE.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			// 
			// gbNotation
			// 
			this.gbNotation.Controls.Add(this.rbUci);
			this.gbNotation.Controls.Add(this.rbSan);
			this.gbNotation.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbNotation.Location = new System.Drawing.Point(3, 161);
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
			// 
			// gbPriority
			// 
			this.gbPriority.Controls.Add(this.combPriority);
			this.gbPriority.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbPriority.Location = new System.Drawing.Point(3, 292);
			this.gbPriority.Name = "gbPriority";
			this.gbPriority.Size = new System.Drawing.Size(359, 50);
			this.gbPriority.TabIndex = 11;
			this.gbPriority.TabStop = false;
			this.gbPriority.Text = "Engine priority";
			// 
			// combPriority
			// 
			this.combPriority.Dock = System.Windows.Forms.DockStyle.Top;
			this.combPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combPriority.FormattingEnabled = true;
			this.combPriority.Items.AddRange(new object[] {
            "Idle",
            "Below normal",
            "Normal",
            "Above normal",
            "High"});
			this.combPriority.Location = new System.Drawing.Point(3, 16);
			this.combPriority.Name = "combPriority";
			this.combPriority.Size = new System.Drawing.Size(353, 21);
			this.combPriority.TabIndex = 49;
			this.combPriority.SelectedIndexChanged += new System.EventHandler(this.cbPriority_SelectedIndexChanged);
			// 
			// gbMatch
			// 
			this.gbMatch.Controls.Add(this.label7);
			this.gbMatch.Controls.Add(this.nudBreak);
			this.gbMatch.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbMatch.Location = new System.Drawing.Point(3, 55);
			this.gbMatch.Name = "gbMatch";
			this.gbMatch.Size = new System.Drawing.Size(359, 48);
			this.gbMatch.TabIndex = 12;
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
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Items.AddRange(new object[] {
            "Interface",
            "Modes"});
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(118, 370);
			this.listBox1.TabIndex = 13;
			this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageInterface);
			this.tabControl1.Controls.Add(this.tabPageModes);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
			this.tabControl1.Location = new System.Drawing.Point(118, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(373, 370);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 14;
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
			this.tabPageInterface.Size = new System.Drawing.Size(365, 361);
			this.tabPageInterface.TabIndex = 0;
			this.tabPageInterface.Text = "Interface";
			this.tabPageInterface.UseVisualStyleBackColor = true;
			// 
			// tabPageModes
			// 
			this.tabPageModes.Controls.Add(this.gbTournamentP);
			this.tabPageModes.Controls.Add(this.gbTournamentE);
			this.tabPageModes.Controls.Add(this.gbMatch);
			this.tabPageModes.Controls.Add(this.gbGame);
			this.tabPageModes.ForeColor = System.Drawing.Color.Black;
			this.tabPageModes.Location = new System.Drawing.Point(4, 5);
			this.tabPageModes.Name = "tabPageModes";
			this.tabPageModes.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageModes.Size = new System.Drawing.Size(365, 361);
			this.tabPageModes.TabIndex = 1;
			this.tabPageModes.Text = "Modes";
			this.tabPageModes.UseVisualStyleBackColor = true;
			// 
			// nudMaxEloP
			// 
			this.nudMaxEloP.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudMaxEloP.Location = new System.Drawing.Point(6, 45);
			this.nudMaxEloP.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			this.nudMaxEloP.Name = "nudMaxEloP";
			this.nudMaxEloP.Size = new System.Drawing.Size(156, 20);
			this.nudMaxEloP.TabIndex = 12;
			this.nudMaxEloP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudMaxEloP.ThousandsSeparator = true;
			this.nudMaxEloP.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			// 
			// nudMinEloP
			// 
			this.nudMinEloP.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudMinEloP.Location = new System.Drawing.Point(6, 69);
			this.nudMinEloP.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			this.nudMinEloP.Name = "nudMinEloP";
			this.nudMinEloP.Size = new System.Drawing.Size(156, 20);
			this.nudMinEloP.TabIndex = 13;
			this.nudMinEloP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudMinEloP.ThousandsSeparator = true;
			// 
			// nudMaxEloE
			// 
			this.nudMaxEloE.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudMaxEloE.Location = new System.Drawing.Point(6, 45);
			this.nudMaxEloE.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			this.nudMaxEloE.Name = "nudMaxEloE";
			this.nudMaxEloE.Size = new System.Drawing.Size(156, 20);
			this.nudMaxEloE.TabIndex = 12;
			this.nudMaxEloE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudMaxEloE.ThousandsSeparator = true;
			this.nudMaxEloE.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			// 
			// nudMinEloE
			// 
			this.nudMinEloE.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudMinEloE.Location = new System.Drawing.Point(6, 71);
			this.nudMinEloE.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			this.nudMinEloE.Name = "nudMinEloE";
			this.nudMinEloE.Size = new System.Drawing.Size(156, 20);
			this.nudMinEloE.TabIndex = 13;
			this.nudMinEloE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudMinEloE.ThousandsSeparator = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(168, 52);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Max elo";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(168, 78);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(41, 13);
			this.label8.TabIndex = 15;
			this.label8.Text = "Min elo";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(168, 52);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(44, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "Max elo";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(168, 76);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(41, 13);
			this.label10.TabIndex = 15;
			this.label10.Text = "Min elo";
			// 
			// FormOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(491, 394);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.butDefault);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormOptions";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOptions_FormClosing);
			this.Shown += new System.EventHandler(this.FormOptions_Shown);
			this.gbInterface.ResumeLayout(false);
			this.gbInterface.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
			this.gbGame.ResumeLayout(false);
			this.gbGame.PerformLayout();
			this.gbTournamentP.ResumeLayout(false);
			this.gbTournamentP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourP)).EndInit();
			this.gbTimeMargin.ResumeLayout(false);
			this.gbTimeMargin.PerformLayout();
			this.gbTournamentE.ResumeLayout(false);
			this.gbTournamentE.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourE)).EndInit();
			this.gbNotation.ResumeLayout(false);
			this.gbNotation.PerformLayout();
			this.gbPriority.ResumeLayout(false);
			this.gbMatch.ResumeLayout(false);
			this.gbMatch.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudBreak)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPageInterface.ResumeLayout(false);
			this.tabPageModes.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudMaxEloP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMinEloP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxEloE)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMinEloE)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button butDefault;
		private System.Windows.Forms.GroupBox gbInterface;
		private System.Windows.Forms.Button butColor;
		public System.Windows.Forms.CheckBox cbShowPonder;
		private System.Windows.Forms.GroupBox gbGame;
		public System.Windows.Forms.CheckBox cbGameAutoElo;
		public System.Windows.Forms.CheckBox cbAttack;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.NumericUpDown nudSpeed;
		private System.Windows.Forms.GroupBox gbTournamentP;
		private System.Windows.Forms.Label labTourP;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.NumericUpDown nudTourP;
		public System.Windows.Forms.CheckBox cbArrow;
		public System.Windows.Forms.CheckBox cbTips;
		private System.Windows.Forms.GroupBox gbTimeMargin;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox combModeTime;
		private System.Windows.Forms.ComboBox combModeStandard;
		private System.Windows.Forms.GroupBox gbTournamentE;
		private System.Windows.Forms.Label labTourE;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.NumericUpDown nudTourE;
		private System.Windows.Forms.GroupBox gbNotation;
		private System.Windows.Forms.RadioButton rbUci;
		public System.Windows.Forms.RadioButton rbSan;
		public System.Windows.Forms.CheckBox cbRotateBoard;
		private System.Windows.Forms.GroupBox gbPriority;
		private System.Windows.Forms.ComboBox combPriority;
		private System.Windows.Forms.GroupBox gbMatch;
		private System.Windows.Forms.Label label7;
		public System.Windows.Forms.NumericUpDown nudBreak;
		public System.Windows.Forms.CheckBox cbSound;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageInterface;
		private System.Windows.Forms.TabPage tabPageModes;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		public System.Windows.Forms.NumericUpDown nudMinEloP;
		public System.Windows.Forms.NumericUpDown nudMaxEloP;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.NumericUpDown nudMinEloE;
		public System.Windows.Forms.NumericUpDown nudMaxEloE;
	}
}