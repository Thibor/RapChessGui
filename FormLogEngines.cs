using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace RapChessGui
{

	public partial class FormLogEngines : Form
	{
		public static FormLogEngines This;
		static readonly Stopwatch timer = new Stopwatch();

		public FormLogEngines()
		{
			This = this;
			InitializeComponent();
			richTextBox1.AddContextMenu();
			FormOptions.SetFontSize(this);
		}

		public static void AppendText(string txt, Color col)
		{
				This.richTextBox1.SelectionColor = col;
				This.richTextBox1.SelectedText = txt;
		}

		public static void AppendTimeText(string txt, Color col)
		{
				This.richTextBox1.SelectionColor = Color.Green;
				This.richTextBox1.SelectedText = GetTimeElapsed();
				AppendText(txt, col);
		}

		public static void AddFen(string fen)
		{
			AppendText($"{GetTimeElapsed()} fen {fen}\n", Color.Black);
		}

		public static void Save(string fn)
		{
			This.richTextBox1.SaveFile(fn);
		}

		public static void SetMessage(CGamer gamer, string msg)
		{
			string b = gamer.IsBookActive() ? "book " : String.Empty;
			Color col = gamer.IsWhite() ? Color.DimGray : Color.Black;
			AppendTimeText($"{b}{gamer.player.name}", col);
			AppendText($" > {msg}\n", Color.DarkBlue);
		}

		public static void WriteHeaderGamer(CGamer g)
		{
			Color color = g.IsWhite() ? Color.DimGray : Color.Black;
			string colorS = g.IsWhite() ? "White" : "Black";
			AppendTimeText($"{colorS}: {g.player.GetName()}\n", color);
			if (g.engine == null)
				return;
			AppendTimeText($"Engine: {g.player.EngineName}\n", color);
			AppendTimeText($"File: {g.engine.file}\n", color);
			string parameters = g.engine.arguments;
			if (parameters != string.Empty)
				AppendTimeText($"Parameters: {g.engine.arguments}\n", color);
		}

		public static void WriteHeader(CGamer gw, CGamer gb)
		{
				This.richTextBox1.Clear();
				timer.Restart();
				AppendTimeText($"Start {DateTime.Now:yyyy-MM-dd HH:mm}\n", Color.Olive);
				WriteHeaderGamer(gw);
				WriteHeaderGamer(gb);
		}

		public static string GetTime()
		{
			TimeSpan ts = timer.Elapsed;
			return ts.ToString(@"hh\:mm\:ss");
		}

		static string GetTimeElapsed()
		{
			TimeSpan ts = timer.Elapsed;
			return ts.ToString(@"hh\:mm\:ss\.fff\ ");
		}

		#region events

		private void FormLog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fn = $@"Saves\{FormChess.This.cbGameMode.Text} {DateTime.Now:yyyy-MM-dd hh-mm-ss}.rtf";
			richTextBox1.SaveFile(fn);
			MessageBox.Show($"File {fn} has been saved");
		}

		private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);
		}

	}

	#endregion

}

