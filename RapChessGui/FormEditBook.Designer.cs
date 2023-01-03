namespace RapChessGui
{
	partial class FormEditBook
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
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			this.bLog = new System.Windows.Forms.Button();
			this.bConsole = new System.Windows.Forms.Button();
			this.bDelete = new System.Windows.Forms.Button();
			this.bCreate = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.bUpdate = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.nudTournament = new System.Windows.Forms.NumericUpDown();
			this.gbElo = new System.Windows.Forms.GroupBox();
			this.nudElo = new System.Windows.Forms.NumericUpDown();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tbParameters = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbBookreaderList = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbBookName = new System.Windows.Forms.TextBox();
			this.gbBooks = new System.Windows.Forms.GroupBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTournament)).BeginInit();
			this.gbElo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudElo)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gbBooks.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.bLog);
			this.panel1.Controls.Add(this.bConsole);
			this.panel1.Controls.Add(this.bDelete);
			this.panel1.Controls.Add(this.bCreate);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.bUpdate);
			this.panel1.Controls.Add(this.groupBox5);
			this.panel1.Controls.Add(this.gbElo);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.groupBox4);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(489, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(311, 591);
			this.panel1.TabIndex = 0;
			// 
			// bLog
			// 
			this.bLog.AutoSize = true;
			this.bLog.Dock = System.Windows.Forms.DockStyle.Top;
			this.bLog.Location = new System.Drawing.Point(0, 316);
			this.bLog.Name = "bLog";
			this.bLog.Size = new System.Drawing.Size(311, 24);
			this.bLog.TabIndex = 37;
			this.bLog.Text = "Log";
			this.bLog.UseVisualStyleBackColor = true;
			this.bLog.Click += new System.EventHandler(this.bLog_Click);
			// 
			// bConsole
			// 
			this.bConsole.AutoSize = true;
			this.bConsole.Dock = System.Windows.Forms.DockStyle.Top;
			this.bConsole.Location = new System.Drawing.Point(0, 292);
			this.bConsole.Name = "bConsole";
			this.bConsole.Size = new System.Drawing.Size(311, 24);
			this.bConsole.TabIndex = 36;
			this.bConsole.Text = "Console";
			this.bConsole.UseVisualStyleBackColor = true;
			this.bConsole.Click += new System.EventHandler(this.bConsole_Click);
			// 
			// bDelete
			// 
			this.bDelete.AutoSize = true;
			this.bDelete.Dock = System.Windows.Forms.DockStyle.Top;
			this.bDelete.Location = new System.Drawing.Point(0, 268);
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
			this.bCreate.Location = new System.Drawing.Point(0, 244);
			this.bCreate.Name = "bCreate";
			this.bCreate.Size = new System.Drawing.Size(311, 24);
			this.bCreate.TabIndex = 26;
			this.bCreate.Text = "Create";
			this.bCreate.UseVisualStyleBackColor = true;
			this.bCreate.Click += new System.EventHandler(this.ButCreate_Click);
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.Dock = System.Windows.Forms.DockStyle.Top;
			this.button1.Location = new System.Drawing.Point(0, 220);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(311, 24);
			this.button1.TabIndex = 35;
			this.button1.Text = "Rename";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.ButReaname_Click);
			// 
			// bUpdate
			// 
			this.bUpdate.AutoSize = true;
			this.bUpdate.Dock = System.Windows.Forms.DockStyle.Top;
			this.bUpdate.Location = new System.Drawing.Point(0, 196);
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
			this.groupBox5.Location = new System.Drawing.Point(0, 157);
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
			this.gbElo.Location = new System.Drawing.Point(0, 118);
			this.gbElo.Name = "gbElo";
			this.gbElo.Size = new System.Drawing.Size(311, 39);
			this.gbElo.TabIndex = 31;
			this.gbElo.TabStop = false;
			this.gbElo.Text = "Elo";
			// 
			// nudElo
			// 
			this.nudElo.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudElo.Location = new System.Drawing.Point(3, 16);
			this.nudElo.Maximum = new decimal(new int[] {
            15000,
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
			// groupBox3
			// 
			this.groupBox3.AutoSize = true;
			this.groupBox3.Controls.Add(this.tbParameters);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(0, 79);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(311, 39);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Parameters";
			// 
			// tbParameters
			// 
			this.tbParameters.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbParameters.Location = new System.Drawing.Point(3, 16);
			this.tbParameters.Name = "tbParameters";
			this.tbParameters.Size = new System.Drawing.Size(305, 20);
			this.tbParameters.TabIndex = 0;
			// 
			// groupBox4
			// 
			this.groupBox4.AutoSize = true;
			this.groupBox4.Controls.Add(this.cbBookreaderList);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox4.Location = new System.Drawing.Point(0, 39);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(311, 40);
			this.groupBox4.TabIndex = 11;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "BookReader";
			// 
			// cbBookreaderList
			// 
			this.cbBookreaderList.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbBookreaderList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBookreaderList.FormattingEnabled = true;
			this.cbBookreaderList.Location = new System.Drawing.Point(3, 16);
			this.cbBookreaderList.Name = "cbBookreaderList";
			this.cbBookreaderList.Size = new System.Drawing.Size(305, 21);
			this.cbBookreaderList.Sorted = true;
			this.cbBookreaderList.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.AutoSize = true;
			this.groupBox1.Controls.Add(this.tbBookName);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(311, 39);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Name";
			// 
			// tbBookName
			// 
			this.tbBookName.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbBookName.Location = new System.Drawing.Point(3, 16);
			this.tbBookName.Name = "tbBookName";
			this.tbBookName.Size = new System.Drawing.Size(305, 20);
			this.tbBookName.TabIndex = 0;
			// 
			// gbBooks
			// 
			this.gbBooks.AutoSize = true;
			this.gbBooks.Controls.Add(this.listBox1);
			this.gbBooks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbBooks.Location = new System.Drawing.Point(0, 0);
			this.gbBooks.Name = "gbBooks";
			this.gbBooks.Size = new System.Drawing.Size(489, 591);
			this.gbBooks.TabIndex = 5;
			this.gbBooks.TabStop = false;
			this.gbBooks.Text = "Books List";
			// 
			// listBox1
			// 
			this.listBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(3, 16);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(483, 572);
			this.listBox1.Sorted = true;
			this.listBox1.TabIndex = 1;
			this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
			this.listBox1.SelectedValueChanged += new System.EventHandler(this.ListBox1_SelectedValueChanged);
			// 
			// FormEditBook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(800, 591);
			this.Controls.Add(this.gbBooks);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MinimizeBox = false;
			this.Name = "FormEditBook";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Books";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditBook_FormClosing);
			this.Shown += new System.EventHandler(this.FormBook_Shown);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudTournament)).EndInit();
			this.gbElo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudElo)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gbBooks.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbBookName;
		private System.Windows.Forms.GroupBox gbBooks;
		public System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cbBookreaderList;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox tbParameters;
		private System.Windows.Forms.Button bDelete;
		private System.Windows.Forms.Button bCreate;
		private System.Windows.Forms.Button bUpdate;
		private System.Windows.Forms.GroupBox gbElo;
		private System.Windows.Forms.NumericUpDown nudElo;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.NumericUpDown nudTournament;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button bConsole;
		private System.Windows.Forms.Button bLog;
	}
}