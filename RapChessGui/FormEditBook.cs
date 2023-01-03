using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace RapChessGui
{
	public partial class FormEditBook : Form
	{
		readonly FormLogBook formLogBook = new FormLogBook();
		public static string bookName = String.Empty;
		public static CBook book = null;

		public FormEditBook()
		{
			InitializeComponent();
			FormOptions.SetFontSize(this);
		}

		void ClickSave()
		{
			if (book == null)
				return;
			CBookList.iniFile.DeleteKey($"book>{book.name}");
			SaveToIni(book);
			MessageBox.Show($"Reader {book.name} has been modified");
			CData.reset = true;
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
			tbBookName.Text = book.name;
			cbBookreaderList.Text = book.file;
			tbParameters.Text = book.parameters;
			nudElo.Value = Convert.ToInt32(book.elo);
			nudTournament.Value = book.tournament;
		}

		void UpdateListBox()
		{
			listBox1.Items.Clear();
			foreach (CBook b in FormChess.bookList)
				listBox1.Items.Add(b.name);
			gbBooks.Text = $"Books {listBox1.Items.Count}";
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectBook(listBox1.SelectedItem.ToString());
		}

		void UpdateBook(CBook b)
		{
			b.name = tbBookName.Text;
			b.file = cbBookreaderList.Text;
			b.parameters = tbParameters.Text;
			b.elo = nudElo.Value.ToString();
			b.tournament = (int)nudTournament.Value;
		}

		void SaveToIni(CBook b)
		{
			UpdateBook(b);
			b.SaveToIni();
			UpdateListBox();
			int index = listBox1.FindString(b.name);
			if (index == -1) return;
			listBox1.SetSelected(index, true);
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
			reader.file = cbBookreaderList.Text;
			FormChess.bookList.Add(reader);
			SaveToIni(reader);
			MessageBox.Show($"Book reader {reader.name} has been created");
			CData.reset = true;
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
				CData.reset = true;
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
			listBox1.SelectedIndex = listBox1.FindString(bookName);
			if ((listBox1.SelectedIndex < 0) && (listBox1.Items.Count > 0))
				listBox1.SelectedIndex = 0;
		}

		private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
				return;
			string name = listBox1.Items[e.Index].ToString();
			CBook book = FormChess.bookList.GetBookByName(name);
			bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
			Brush b = Brushes.Black;
			if (selected)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, CBoard.colorMessage, CBoard.colorChartD);
				b = Brushes.White;
			}
			else if (!book.FileExists())
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.White, CBoard.colorRed);
				b = Brushes.White;
			}else if (book.tournament > 0)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.Black, CBoard.colorMessage);
			}
			e.DrawBackground();
			e.Graphics.DrawString(name, e.Font, b, e.Bounds, StringFormat.GenericDefault);
			e.DrawFocusRectangle();
		}

		private void ButReaname_Click(object sender, EventArgs e)
		{
			CBook b = new CBook();
			UpdateBook(b);
			string name = b.CreateName();
			if (name != b.name)
				name = FormChess.bookList.GetName(name);
			tbBookName.Text = name;
			ClickSave();
		}

		private void bConsole_Click(object sender, EventArgs e)
		{
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = book.GetFileName();
			psi.Arguments = book.GetParameters();
			psi.WorkingDirectory = Path.GetDirectoryName(psi.FileName);
			Process.Start(psi);
		}

		private void bLog_Click(object sender, EventArgs e)
		{
			if (formLogBook.Visible)
				formLogBook.Focus();
			else
				formLogBook.Show(this);
		}

		private void FormEditBook_FormClosing(object sender, FormClosingEventArgs e)
		{
			CBookList.iniFile.Save();
		}
	}
}
