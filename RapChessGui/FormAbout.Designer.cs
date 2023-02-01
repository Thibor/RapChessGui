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
			this.labName = new System.Windows.Forms.Label();
			this.labVersion = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labName
			// 
			this.labName.Dock = System.Windows.Forms.DockStyle.Top;
			this.labName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labName.Location = new System.Drawing.Point(0, 0);
			this.labName.Name = "labName";
			this.labName.Size = new System.Drawing.Size(370, 30);
			this.labName.TabIndex = 0;
			this.labName.Text = "RapChessGui";
			this.labName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labVersion
			// 
			this.labVersion.Dock = System.Windows.Forms.DockStyle.Top;
			this.labVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labVersion.Location = new System.Drawing.Point(0, 43);
			this.labVersion.Name = "labVersion";
			this.labVersion.Size = new System.Drawing.Size(370, 30);
			this.labVersion.TabIndex = 1;
			this.labVersion.Text = "2023-01-27";
			this.labVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(370, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Current version";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FormAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(370, 79);
			this.Controls.Add(this.labVersion);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAbout";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labName;
		private System.Windows.Forms.Label labVersion;
		private System.Windows.Forms.Label label1;
	}
}