namespace RapChessGui
{
	partial class FormFolderE
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
			this.lvFolders = new System.Windows.Forms.ListView();
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// lvFolders
			// 
			this.lvFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader3});
			this.lvFolders.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lvFolders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lvFolders.FullRowSelect = true;
			this.lvFolders.GridLines = true;
			this.lvFolders.HideSelection = false;
			this.lvFolders.Location = new System.Drawing.Point(0, 0);
			this.lvFolders.MultiSelect = false;
			this.lvFolders.Name = "lvFolders";
			this.lvFolders.ShowGroups = false;
			this.lvFolders.Size = new System.Drawing.Size(800, 450);
			this.lvFolders.TabIndex = 29;
			this.lvFolders.UseCompatibleStateImageBehavior = false;
			this.lvFolders.View = System.Windows.Forms.View.Details;
			this.lvFolders.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvFolders_ColumnClick);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Folder";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader5.Width = 200;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Engine";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader3.Width = 100;
			// 
			// FormFolderE
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lvFolders);
			this.MinimizeBox = false;
			this.Name = "FormFolderE";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Engines folders";
			this.Shown += new System.EventHandler(this.FormFolderE_Shown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lvFolders;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader3;
	}
}