using System;
using System.IO;
using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormLastGame : Form
	{
		public static string lastName = String.Empty;

		public FormLastGame()
		{
			InitializeComponent();
			richTextBox1.AddContextMenu();
			FormOptions.SetFontSize(this);
		}

		private void FormLogLast_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void FormLogLast_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible == true)
			{
				Text = $"Last {lastName}";
				string path = $@"History\{lastName}.rtf";
				Text = $"Last {lastName}";
				if (File.Exists(path))
					richTextBox1.LoadFile(path);
				else
					richTextBox1.Clear();
			}
		}

		private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.LinkText);
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fn = $@"Saves\{lastName} {DateTime.Now:yyyy-MM-dd hh-mm-ss}.rtf";
			richTextBox1.SaveFile(fn);
			MessageBox.Show($"File {fn} has been saved");
		}
	}
}
