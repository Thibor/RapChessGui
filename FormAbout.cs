using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormAbout : Form
	{

		public FormAbout()
		{
			InitializeComponent();
		}


		private void FormAbout_Shown(object sender, EventArgs e)
		{
			pictureBox.Image = FormChess.This.Icon.ToBitmap();
		}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process browserProcess = new Process();
            browserProcess.StartInfo.UseShellExecute = true;
            browserProcess.StartInfo.FileName = "https://github.com/Thibor/RapChessGui";
            browserProcess.Start();
        }
    }
}
