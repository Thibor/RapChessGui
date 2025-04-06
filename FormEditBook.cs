using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace RapChessGui
{
	public partial class FormEditBook : Form
	{
		public static FormEditBook This;
		int indexFirst = -1;
		int tournament = -1;
		public static CBook book = null;
		readonly FormLogBook formLogBook = new FormLogBook();
		public static string bookName = String.Empty;
		public static CProcess processOptions = null;
		readonly static COptionList optionList = new COptionList();

		public FormEditBook()
		{
			This = this;
			InitializeComponent();
			processOptions = new CProcess(OnDataReceivedOptions);
			FormOptions.SetFontSize(this);
		}


		delegate void DeleMessageOptions(string message);

		readonly static DeleMessageOptions deleMessageOptions = new DeleMessageOptions(NewMessageOptions);

		private void OnDataReceivedOptions(object sender, DataReceivedEventArgs e)
		{
			try
			{
				if (!String.IsNullOrEmpty(e.Data))
				{
					Invoke(deleMessageOptions, new object[] { e.Data.Trim() });
				}
			}
			catch { }
		}

		public static void NewMessageOptions(string msg)
		{
			if (msg == "optionend")
				This.OptionFinish();
			else
				optionList.Add(msg);
		}

		void StartTestOptions()
		{
			if (processOptions.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Books\{book.fileReader}", book.arguments) > 0)
			{
				processOptions.WriteLine("book getoption");
				processOptions.WriteLine("quit");
			}
		}

		public void OptionFinish()
		{
			int y = 8;
			panOptions.Controls.Clear();
			optionList.SortTypeName();
			Label lab;
			for (int n = 0; n < optionList.Count; n++)
			{
				string name = $"optionN{n}";
				string oName = name;
				string lName = name;
				COption o = optionList[n];
				switch (o.Type)
				{
					case "spin":
						var nud = new NumericUpDown();
						nud.Name = oName;
						nud.Minimum = Convert.ToInt32(o.Min);
						nud.Maximum = Convert.ToInt32(o.Max);
						nud.Value = Convert.ToInt32(book.GetOption(o.Name, o.Default));
						nud.Location = new Point(3, y);
						nud.TextAlign = HorizontalAlignment.Right;
						panOptions.Controls.Add(nud);
						lab = new Label();
						lab.Name = lName;
						lab.Text = o.Text();
						lab.Location = new Point(128, y);
						lab.Size = new Size(panOptions.Width - 160, lab.Height);
						panOptions.Controls.Add(lab);
						y += 24;
						break;
					case "check":
						CheckBox check = new CheckBox();
						check.Name = oName;
						check.Text = o.Text();
						check.Checked = Convert.ToBoolean(book.GetOption(o.Name, o.Default));
						check.Location = new Point(3, y);
						check.Size = new Size(panOptions.Width - 32, check.Height);
						panOptions.Controls.Add(check);
						y += 24;
						break;
					case "string":
						lab = new Label();
						lab.Name = lName;
						lab.Text = o.Text();
						lab.TextAlign = ContentAlignment.MiddleLeft;
						lab.Location = new Point(3, y);
						lab.Size = new Size(panOptions.Width - 32, lab.Height);
						panOptions.Controls.Add(lab);
						y += 24;
						TextBox box = new TextBox();
						box.Name = oName;
						box.Text = book.GetOption(o.Name, o.Default);
						box.Location = new Point(3, y);
						box.Size = new Size(panOptions.Width - 32, box.Height);
						panOptions.Controls.Add(box);
						y += 24;
						break;
				}
			}
		}

		void ClickSave()
		{
			if (book == null)
				return;
			CListBook.iniFile.DeleteKey($"book>{book.name}");
			SaveToIni(book);
			MessageBox.Show($"Reader {book.name} has been modified");
		}

		void SelectBook(string name)
		{
			book = FormChess.bookList.GetBookByName(name);
			bookName = String.Empty;
			if (book == null)
				return;
			SelectBook(book);
		}

		void SelectBook(CBook b)
		{
			book = b;
			bookName = book.name;
			SelectBook();
		}

		void SelectBook()
		{
			optionList.Clear();
			OptionFinish();
			BookToSetings();
			StartTestOptions();
		}

		void SelectBooks(int first, int last, bool t)
		{
			int f = first < last ? first : last;
			int l = first < last ? last : first;
			bool r = false;
			for (int n = f; n <= l; n++)
			{
				var item = listBoxBooks.Items[n];
				string name = item.ToString();
				CBook eb = FormChess.bookList.GetBookByName(name);
				if (eb.SetTournament(t))
					r = true;
			}
			if (r)
			{
				listBoxBooks.Refresh();
				SelectBook();
			}
		}

		void BookToSetings()
		{
			tbBookName.Text = book.name;
			cbBookreaderList.Text = book.fileReader;
			tbParameters.Text = book.arguments;
			nudElo.Value = book.Elo;
			nudTournament.Value = book.tournament;
		}

		void UpdateListBox()
		{
			listBoxBooks.Items.Clear();
			foreach (CBook b in FormChess.bookList)
				listBoxBooks.Items.Add(b.name);
			gbBooks.Text = $"Books {listBoxBooks.Items.Count}";
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectBook(listBoxBooks.SelectedItem.ToString());
		}

		void FormToBook(CBook b)
		{
			b.name = tbBookName.Text;
			b.fileReader = cbBookreaderList.Text;
			b.arguments = tbParameters.Text;
			b.Elo = (int)nudElo.Value;
			b.tournament = (int)nudTournament.Value;
			b.options = GetOptions();
		}

		List<string> GetOptions()
		{
			List<string> list = new List<string>();
			for (int n = 0; n < optionList.Count; n++)
			{
				string oName = $"optionN{n}";
				var c = panOptions.Controls.Find(oName, false);
				if (c.Length == 0)
					continue;
				COption o = optionList[n];
				string value;
				switch (o.Type)
				{
					case "spin":
						NumericUpDown nud = c[0] as NumericUpDown;
						value = nud.Value.ToString();
						if (o.Default != value)
							list.Add($"name {o.Name} value {value}");
						break;
					case "check":
						CheckBox check = c[0] as CheckBox;
						value = check.Checked ? "true" : "false";
						if (o.Default != value)
							list.Add($"name {o.Name} value {value}");
						break;
					case "string":
						TextBox tb = c[1] as TextBox;
						value = tb.Text;
						if (o.Default != value)
							list.Add($"name {o.Name} value {value}");
						break;
				}
			}
			return list;
		}

		void SaveToIni(CBook b)
		{
			FormToBook(b);
			b.SaveToIni();
			UpdateListBox();
			int index = listBoxBooks.FindString(b.name);
			if (index == -1) return;
			listBoxBooks.SetSelected(index, true);
		}

		private void ButUpdate_Click(object sender, EventArgs e)
		{
			ClickSave();
		}

		private void ButCreate_Click(object sender, EventArgs e)
		{
			string name = tbBookName.Text;
			if (FormChess.bookList.GetBookByName(name) != null)
			{
				MessageBox.Show("This name already exists");
				return;
			}
			CBook reader = new CBook(name);
			reader.fileReader = cbBookreaderList.Text;
			FormChess.bookList.Add(reader);
			SaveToIni(reader);
			MessageBox.Show($"Book reader {reader.name} has been created");
		}

		private void ButDelete_Click(object sender, EventArgs e)
		{
			string name = tbBookName.Text;
			var dr = MessageBox.Show($"Are you sure that you would like to delete {name}?", "Delete engine", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
				FormChess.bookList.DeleteBook(name);
				UpdateListBox();
				MessageBox.Show($"Book {name} has been removed");
			}
		}

		private void FormBook_Shown(object sender, EventArgs e)
		{
			cbBookreaderList.Items.Clear();
			cbBookreaderList.Sorted = true;
			foreach (string book in CData.fileBookReader)
				cbBookreaderList.Items.Add(book);
			cbBookreaderList.Sorted = false;
			cbBookreaderList.Items.Insert(0, Global.none);
			cbBookreaderList.SelectedIndex = 0;
			UpdateListBox();
			listBoxBooks.SelectedIndex = listBoxBooks.FindString(bookName);
			if ((listBoxBooks.SelectedIndex < 0) && (listBoxBooks.Items.Count > 0))
				listBoxBooks.SelectedIndex = 0;
		}

		private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
				return;
			string name = listBoxBooks.Items[e.Index].ToString();
			CBook book = FormChess.bookList.GetBookByName(name);
			bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
			Brush b = Brushes.Black;
			if (selected)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, Colors.message, Colors.chartD);
				b = Brushes.White;
			}
			else if (!book.FileExists())
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.Black, Color.FromArgb(0xff, 0xc0, 0xc0));
			}
			else if (book.tournament > 0)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.Black, Colors.message);
			}
			e.DrawBackground();
			e.Graphics.DrawString(name, e.Font, b, e.Bounds, StringFormat.GenericDefault);
			e.DrawFocusRectangle();
		}

		private void ButReaname_Click(object sender, EventArgs e)
		{
			CBook b = new CBook();
			FormToBook(b);
			string name = b.CreateName();
			if (name != b.name)
				name = FormChess.bookList.GetName(name);
			tbBookName.Text = name;
			ClickSave();
		}

		private void FormEditBook_FormClosing(object sender, FormClosingEventArgs e)
		{
            processOptions?.Terminate();
			CListBook.iniFile.Save();
		}

		private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string bn = book.GetOption("book_file");
			string arg = string.IsNullOrEmpty(bn) ? book.arguments : $@"{bn} -info";
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = book.GetPath();
			psi.Arguments = arg;
			psi.WorkingDirectory = Path.GetDirectoryName(psi.FileName);
			Process.Start(psi);
        }

		private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (formLogBook.Visible)
				formLogBook.Focus();
			else
				formLogBook.Show(this);
		}

		private void clearTournamentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (book != null)
			{
				book.history.Clear();
				book.SaveToIni();
				int count = CModeTournamentB.tourList.DeletePlayer(book.name);
				MessageBox.Show($"{count} records have been deleted");
			}
		}

		private void listBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				indexFirst = -1;
				tournament = -1;
				listBoxBooks.Capture = true;
				int index = listBoxBooks.IndexFromPoint(e.Location);
				if ((index >= 0) && (index < listBoxBooks.Items.Count))
				{
					var item = listBoxBooks.Items[index];
					string name = item.ToString();
					CBook ce = FormChess.bookList.GetBookByName(name);
					indexFirst = index;
					tournament = ce.tournament > 0 ? 0 : 1;
					if (ce.SetTournament(tournament == 1))
					{
						listBoxBooks.Refresh();
						if (book == ce)
							SelectBook();
					}

				}
			}
		}

		private void listBoxBooks_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				int index = listBoxBooks.IndexFromPoint(e.Location);
				if ((index >= 0) && (index < listBoxBooks.Items.Count) && (tournament >= 0))
					SelectBooks(indexFirst, index, tournament > 0);
			}
		}

		private void listBoxBooks_MouseUp(object sender, MouseEventArgs e)
		{
			tournament = -1;
			listBoxBooks.Capture = false;
		}

		private void allToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int n = 0; n < FormChess.bookList.Count; n++)
				if (FormChess.bookList[n].tournament == 0)
					FormChess.bookList[n].tournament = 1;
			FormChess.bookList.SaveToIni();
			listBoxBooks.Refresh();
		}

		private void nToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int n = 0; n < FormChess.bookList.Count; n++)
				FormChess.bookList[n].tournament = 0;
			FormChess.bookList.SaveToIni();
			listBoxBooks.Refresh();
		}
	}
}
