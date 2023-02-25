namespace RapChessGui
{
	partial class FormAbout
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.labVersion = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.labName = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.labVersion);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.labName);
			this.panel2.Controls.Add(this.pictureBox);
			this.panel2.Location = new System.Drawing.Point(12, 12);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(347, 128);
			this.panel2.TabIndex = 5;
			// 
			// labVersion
			// 
			this.labVersion.Dock = System.Windows.Forms.DockStyle.Top;
			this.labVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labVersion.Location = new System.Drawing.Point(128, 77);
			this.labVersion.Name = "labVersion";
			this.labVersion.Size = new System.Drawing.Size(219, 30);
			this.labVersion.TabIndex = 8;
			this.labVersion.Text = "2023-02-25";
			this.labVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(128, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(219, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Current version";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labName
			// 
			this.labName.Dock = System.Windows.Forms.DockStyle.Top;
			this.labName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labName.Location = new System.Drawing.Point(128, 0);
			this.labName.Name = "labName";
			this.labName.Size = new System.Drawing.Size(219, 64);
			this.labName.TabIndex = 6;
			this.labName.Text = "RapChessGui";
			this.labName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox
			// 
			this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox.Dock = System.Windows.Forms.DockStyle.Left;
			this.pictureBox.Location = new System.Drawing.Point(0, 0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(128, 128);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox.TabIndex = 5;
			this.pictureBox.TabStop = false;
			// 
			// FormAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(370, 150);
			this.Controls.Add(this.panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAbout";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.Shown += new System.EventHandler(this.FormAbout_Shown);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label labVersion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labName;
		private System.Windows.Forms.PictureBox pictureBox;
	}
}