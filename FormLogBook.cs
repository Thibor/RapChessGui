using System;
using System.IO;
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
	public partial class FormLogBook : Form
	{
		public static FormLogBook This;

		public FormLogBook()
		{
			This = this;
			InitializeComponent();
			FormOptions.SetFontSize(this);
		}

		private void FormLogBook_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void FormLogBook_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible == true)
			{
				string name = Path.GetFileNameWithoutExtension(FormEditBook.book.fileReader);
				string path = new FileInfo($@"Books/{name}.log").FullName.ToString();
				if (File.Exists(path))
				{
					textBox1.Text = File.ReadAllText(path);
					textBox1.Select(0, 0);
				}
				else
					textBox1.Clear();
			}
		}
	}
}
