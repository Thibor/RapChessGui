using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormLog : Form
	{

		public static string path = string.Empty;
		public static string text = string.Empty;

		public FormLog()
		{
			InitializeComponent();	
		}

		private void FormLog_Shown(object sender, EventArgs e)
		{
			Text = text;
			FormOptions.SetFontSize(this);
			if (File.Exists(path))
			{
				textBox.Text = File.ReadAllText(path);
				textBox.Select(0, 0);
			}
			else textBox.Clear();
		}
	}
}
