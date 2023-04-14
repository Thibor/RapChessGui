namespace RapChessGui
{
	partial class FormListE
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
			this.lvEngines = new System.Windows.Forms.ListView();
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.foldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvEngines
			// 
			this.lvEngines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader3,
            this.columnHeader8,
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6,
            this.columnHeader7});
			this.lvEngines.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lvEngines.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvEngines.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lvEngines.FullRowSelect = true;
			this.lvEngines.GridLines = true;
			this.lvEngines.HideSelection = false;
			this.lvEngines.Location = new System.Drawing.Point(0, 24);
			this.lvEngines.MultiSelect = false;
			this.lvEngines.Name = "lvEngines";
			this.lvEngines.ShowGroups = false;
			this.lvEngines.Size = new System.Drawing.Size(899, 426);
			this.lvEngines.TabIndex = 28;
			this.lvEngines.UseCompatibleStateImageBehavior = false;
			this.lvEngines.View = System.Windows.Forms.View.Details;
			this.lvEngines.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvEngines_ColumnClick);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Index";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Engine";
			this.columnHeader3.Width = 200;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Protocol";
			this.columnHeader8.Width = 80;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Elo";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader4.Width = 100;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Trend";
			this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader1.Width = 100;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Change";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Width = 100;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "E Move %";
			this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader6.Width = 100;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "E Tme %";
			this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader7.Width = 100;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.foldersToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(899, 24);
			this.menuStrip1.TabIndex = 29;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// foldersToolStripMenuItem
			// 
			this.foldersToolStripMenuItem.Name = "foldersToolStripMenuItem";
			this.foldersToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.foldersToolStripMenuItem.Text = "Folders";
			this.foldersToolStripMenuItem.Click += new System.EventHandler(this.foldersToolStripMenuItem_Click);
			// 
			// FormListE
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(899, 450);
			this.Controls.Add(this.lvEngines);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimizeBox = false;
			this.Name = "FormListE";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Engines";
			this.Shown += new System.EventHandler(this.FormListE_Shown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lvEngines;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem foldersToolStripMenuItem;
	}
}