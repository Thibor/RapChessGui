namespace RapChessGui
{
	partial class FormAutodetect
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
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.testTimer = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lName = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.sslTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbConsole
            // 
            this.tbConsole.BackColor = System.Drawing.Color.Black;
            this.tbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbConsole.ForeColor = System.Drawing.Color.White;
            this.tbConsole.Location = new System.Drawing.Point(0, 43);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConsole.Size = new System.Drawing.Size(800, 407);
            this.tbConsole.TabIndex = 0;
            this.tbConsole.WordWrap = false;
            // 
            // testTimer
            // 
            this.testTimer.Tick += new System.EventHandler(this.testTimer_Tick);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Location = new System.Drawing.Point(0, 20);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(800, 23);
            this.progressBar.TabIndex = 1;
            // 
            // lName
            // 
            this.lName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lName.Location = new System.Drawing.Point(0, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(800, 20);
            this.lName.TabIndex = 2;
            this.lName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslTime,
            this.sslLeft});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // sslTime
            // 
            this.sslTime.Name = "sslTime";
            this.sslTime.Size = new System.Drawing.Size(0, 17);
            // 
            // sslLeft
            // 
            this.sslLeft.Name = "sslLeft";
            this.sslLeft.Size = new System.Drawing.Size(0, 17);
            // 
            // FormAutodetect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tbConsole);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAutodetect";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Autodetect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAutodetect_FormClosing);
            this.Shown += new System.EventHandler(this.FormAutodetect_Shown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbConsole;
		private System.Windows.Forms.Timer testTimer;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label lName;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel sslTime;
		private System.Windows.Forms.ToolStripStatusLabel sslLeft;
	}
}