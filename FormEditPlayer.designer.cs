namespace RapChessGui
{
	partial class FormEditPlayer
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bDelete = new System.Windows.Forms.Button();
            this.bCreate = new System.Windows.Forms.Button();
            this.butRename = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.nudTournament = new System.Windows.Forms.NumericUpDown();
            this.gbElo = new System.Windows.Forms.GroupBox();
            this.nudElo = new System.Windows.Forms.NumericUpDown();
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.nudValue = new System.Windows.Forms.NumericUpDown();
            this.combMode = new System.Windows.Forms.ComboBox();
            this.gbBook = new System.Windows.Forms.GroupBox();
            this.cbBookList = new System.Windows.Forms.ComboBox();
            this.gbEngine = new System.Windows.Forms.GroupBox();
            this.cbEngineList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPlayerName = new System.Windows.Forms.TextBox();
            this.gbPlayers = new System.Windows.Forms.GroupBox();
            this.listBoxPlayers = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tournamentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTournamentHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTournament)).BeginInit();
            this.gbElo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudElo)).BeginInit();
            this.gbMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
            this.gbBook.SuspendLayout();
            this.gbEngine.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbPlayers.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bDelete);
            this.panel1.Controls.Add(this.bCreate);
            this.panel1.Controls.Add(this.butRename);
            this.panel1.Controls.Add(this.bUpdate);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.gbElo);
            this.panel1.Controls.Add(this.gbMode);
            this.panel1.Controls.Add(this.gbBook);
            this.panel1.Controls.Add(this.gbEngine);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(489, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 567);
            this.panel1.TabIndex = 0;
            // 
            // bDelete
            // 
            this.bDelete.AutoSize = true;
            this.bDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.bDelete.Location = new System.Drawing.Point(0, 329);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(311, 24);
            this.bDelete.TabIndex = 27;
            this.bDelete.Text = "Delete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.ButDelete_Click);
            // 
            // bCreate
            // 
            this.bCreate.AutoSize = true;
            this.bCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCreate.Location = new System.Drawing.Point(0, 305);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(311, 24);
            this.bCreate.TabIndex = 26;
            this.bCreate.Text = "Create";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.ButCreate_Click);
            // 
            // butRename
            // 
            this.butRename.AutoSize = true;
            this.butRename.Dock = System.Windows.Forms.DockStyle.Top;
            this.butRename.Location = new System.Drawing.Point(0, 281);
            this.butRename.Name = "butRename";
            this.butRename.Size = new System.Drawing.Size(311, 24);
            this.butRename.TabIndex = 35;
            this.butRename.Text = "Rename";
            this.butRename.UseVisualStyleBackColor = true;
            this.butRename.Click += new System.EventHandler(this.ButRename_Click);
            // 
            // bUpdate
            // 
            this.bUpdate.AutoSize = true;
            this.bUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.bUpdate.Location = new System.Drawing.Point(0, 257);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(311, 24);
            this.bUpdate.TabIndex = 25;
            this.bUpdate.Text = "Save";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.ButUpdate_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.Controls.Add(this.nudTournament);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 218);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(311, 39);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tournament priority";
            // 
            // nudTournament
            // 
            this.nudTournament.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudTournament.Location = new System.Drawing.Point(3, 16);
            this.nudTournament.Name = "nudTournament";
            this.nudTournament.Size = new System.Drawing.Size(305, 20);
            this.nudTournament.TabIndex = 0;
            this.nudTournament.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTournament.ThousandsSeparator = true;
            this.nudTournament.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gbElo
            // 
            this.gbElo.AutoSize = true;
            this.gbElo.Controls.Add(this.nudElo);
            this.gbElo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbElo.Location = new System.Drawing.Point(0, 179);
            this.gbElo.Name = "gbElo";
            this.gbElo.Size = new System.Drawing.Size(311, 39);
            this.gbElo.TabIndex = 24;
            this.gbElo.TabStop = false;
            this.gbElo.Text = "Elo";
            // 
            // nudElo
            // 
            this.nudElo.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudElo.Location = new System.Drawing.Point(3, 16);
            this.nudElo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudElo.Name = "nudElo";
            this.nudElo.Size = new System.Drawing.Size(305, 20);
            this.nudElo.TabIndex = 0;
            this.nudElo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudElo.ThousandsSeparator = true;
            this.nudElo.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // gbMode
            // 
            this.gbMode.AutoSize = true;
            this.gbMode.Controls.Add(this.nudValue);
            this.gbMode.Controls.Add(this.combMode);
            this.gbMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMode.Location = new System.Drawing.Point(0, 119);
            this.gbMode.Name = "gbMode";
            this.gbMode.Size = new System.Drawing.Size(311, 60);
            this.gbMode.TabIndex = 16;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "Mode";
            // 
            // nudValue
            // 
            this.nudValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudValue.Location = new System.Drawing.Point(3, 37);
            this.nudValue.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudValue.Name = "nudValue";
            this.nudValue.Size = new System.Drawing.Size(305, 20);
            this.nudValue.TabIndex = 51;
            this.nudValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudValue.ThousandsSeparator = true;
            this.nudValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // combMode
            // 
            this.combMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.combMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combMode.FormattingEnabled = true;
            this.combMode.Items.AddRange(new object[] {
            "Depth",
            "Infinite",
            "Nodes",
            "Standard",
            "Time"});
            this.combMode.Location = new System.Drawing.Point(3, 16);
            this.combMode.Name = "combMode";
            this.combMode.Size = new System.Drawing.Size(305, 21);
            this.combMode.Sorted = true;
            this.combMode.TabIndex = 48;
            this.combMode.SelectedIndexChanged += new System.EventHandler(this.combMode_SelectedIndexChanged);
            // 
            // gbBook
            // 
            this.gbBook.AutoSize = true;
            this.gbBook.Controls.Add(this.cbBookList);
            this.gbBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBook.Location = new System.Drawing.Point(0, 79);
            this.gbBook.Name = "gbBook";
            this.gbBook.Size = new System.Drawing.Size(311, 40);
            this.gbBook.TabIndex = 20;
            this.gbBook.TabStop = false;
            this.gbBook.Text = "Book";
            // 
            // cbBookList
            // 
            this.cbBookList.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbBookList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBookList.FormattingEnabled = true;
            this.cbBookList.Location = new System.Drawing.Point(3, 16);
            this.cbBookList.Name = "cbBookList";
            this.cbBookList.Size = new System.Drawing.Size(305, 21);
            this.cbBookList.TabIndex = 2;
            // 
            // gbEngine
            // 
            this.gbEngine.AutoSize = true;
            this.gbEngine.Controls.Add(this.cbEngineList);
            this.gbEngine.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbEngine.Location = new System.Drawing.Point(0, 39);
            this.gbEngine.Name = "gbEngine";
            this.gbEngine.Size = new System.Drawing.Size(311, 40);
            this.gbEngine.TabIndex = 11;
            this.gbEngine.TabStop = false;
            this.gbEngine.Text = "Engine";
            // 
            // cbEngineList
            // 
            this.cbEngineList.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbEngineList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEngineList.FormattingEnabled = true;
            this.cbEngineList.Location = new System.Drawing.Point(3, 16);
            this.cbEngineList.Name = "cbEngineList";
            this.cbEngineList.Size = new System.Drawing.Size(305, 21);
            this.cbEngineList.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tbPlayerName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 39);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // tbPlayerName
            // 
            this.tbPlayerName.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbPlayerName.Location = new System.Drawing.Point(3, 16);
            this.tbPlayerName.Name = "tbPlayerName";
            this.tbPlayerName.Size = new System.Drawing.Size(305, 20);
            this.tbPlayerName.TabIndex = 0;
            // 
            // gbPlayers
            // 
            this.gbPlayers.AutoSize = true;
            this.gbPlayers.Controls.Add(this.listBoxPlayers);
            this.gbPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPlayers.Location = new System.Drawing.Point(0, 24);
            this.gbPlayers.Name = "gbPlayers";
            this.gbPlayers.Size = new System.Drawing.Size(489, 567);
            this.gbPlayers.TabIndex = 5;
            this.gbPlayers.TabStop = false;
            this.gbPlayers.Text = "Players List";
            // 
            // listBoxPlayers
            // 
            this.listBoxPlayers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBoxPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPlayers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxPlayers.FormattingEnabled = true;
            this.listBoxPlayers.ItemHeight = 18;
            this.listBoxPlayers.Location = new System.Drawing.Point(3, 16);
            this.listBoxPlayers.Name = "listBoxPlayers";
            this.listBoxPlayers.Size = new System.Drawing.Size(483, 548);
            this.listBoxPlayers.Sorted = true;
            this.listBoxPlayers.TabIndex = 1;
            this.listBoxPlayers.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBoxPlayers.SelectedValueChanged += new System.EventHandler(this.ListBox1_SelectedValueChanged);
            this.listBoxPlayers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            this.listBoxPlayers.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
            this.listBoxPlayers.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tournamentToolStripMenuItem,
            this.actionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tournamentToolStripMenuItem
            // 
            this.tournamentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.noneToolStripMenuItem});
            this.tournamentToolStripMenuItem.Name = "tournamentToolStripMenuItem";
            this.tournamentToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.tournamentToolStripMenuItem.Text = "Tournament";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearTournamentHistoryToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // clearTournamentHistoryToolStripMenuItem
            // 
            this.clearTournamentHistoryToolStripMenuItem.Name = "clearTournamentHistoryToolStripMenuItem";
            this.clearTournamentHistoryToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.clearTournamentHistoryToolStripMenuItem.Text = "Clear tournament history";
            this.clearTournamentHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearTournamentHistoryToolStripMenuItem_Click);
            // 
            // FormEditPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 591);
            this.Controls.Add(this.gbPlayers);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "FormEditPlayer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Players";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditPlayer_FormClosing);
            this.Shown += new System.EventHandler(this.FormPlayer_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTournament)).EndInit();
            this.gbElo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudElo)).EndInit();
            this.gbMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
            this.gbBook.ResumeLayout(false);
            this.gbEngine.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPlayers.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbPlayerName;
		private System.Windows.Forms.GroupBox gbPlayers;
		public System.Windows.Forms.ListBox listBoxPlayers;
		private System.Windows.Forms.GroupBox gbEngine;
		private System.Windows.Forms.ComboBox cbEngineList;
		private System.Windows.Forms.GroupBox gbMode;
		private System.Windows.Forms.GroupBox gbBook;
		public System.Windows.Forms.ComboBox cbBookList;
		private System.Windows.Forms.Button bDelete;
		private System.Windows.Forms.Button bCreate;
		private System.Windows.Forms.Button bUpdate;
		private System.Windows.Forms.GroupBox gbElo;
		private System.Windows.Forms.NumericUpDown nudElo;
		private System.Windows.Forms.ComboBox combMode;
		private System.Windows.Forms.NumericUpDown nudValue;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.NumericUpDown nudTournament;
		private System.Windows.Forms.Button butRename;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearTournamentHistoryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tournamentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
	}
}