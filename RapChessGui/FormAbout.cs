﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
	}
}
