using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace RapChessGui
{

	public partial class FormLogEngines : Form
	{
		public static FormLogEngines This;
		static bool locked = false;
		static readonly Stopwatch timer = new Stopwatch();
		public static CProcess process = null;

		public FormLogEngines()
		{
			This = this;
			InitializeComponent();
			richTextBox1.AddContextMenu();
			process = new CProcess(OnDataReceived);
			FormOptions.SetFontSize(this);
		}

		delegate void DeleMessage(string message);

		readonly static DeleMessage deleMessage = new DeleMessage(NewMessage);

		private void OnDataReceived(object sender, DataReceivedEventArgs e)
		{
			try
			{
				if (!String.IsNullOrEmpty(e.Data))
				{
					Invoke(deleMessage, new object[] { e.Data.Trim() });
				}
			}
			catch { }
		}

		public static void NewMessage(string msg)
		{
			AppendText($"{msg}\n", Color.Black, true);
		}

		public static void AppendText(string txt, Color col, bool forced = false)
		{
			if (!locked || forced)
			{
				This.richTextBox1.SelectionColor = col;
				This.richTextBox1.SelectedText = txt;
			}
		}

		public static void AppendTimeText(string txt, Color col, bool forced = false)
		{
			if (!locked || forced)
			{
				This.richTextBox1.SelectionColor = Color.Green;
				This.richTextBox1.SelectedText = GetTimeElapsed();
				AppendText(txt, col);
			}
		}

		public static void AddMove(int move)
		{
			AppendText($"{GetTimeElapsed()} move {move}\n",Color.Black);
		}

		public static void Save(string fn)
		{
			This.richTextBox1.SaveFile(fn);
		}

		public static void SetMessage(CGamer gamer, string protocol, string msg)
		{
			string book = protocol == "Book" ? "book " : String.Empty;
			Color col = gamer.isWhite ? Color.DimGray : Color.Black;
			AppendTimeText($"{book}{gamer.player.name}", col);
			AppendText($" > {msg}\n", Color.DarkBlue);
		}

		public static void WriteHeaderGamer(CGamer g)
		{
			Color color = g.isWhite ? Color.DimGray : Color.Black;
			string colorS = g.isWhite ? "White" : "Black";
			AppendTimeText($"{colorS}: {g.player.GetName()}\n", color);
			if (g.engine == null)
				return;
			AppendTimeText($"Engine: {g.player.Engine}\n", color);
			AppendTimeText($"File: {g.engine.file}\n", color);
			string parameters = g.engine.parameters;
			if (parameters != "")
				AppendTimeText($"Parameters: {g.engine.parameters}\n", color);
		}

		public static void WriteHeader(CGamer gw, CGamer gb)
		{
			if (!locked)
			{
				This.richTextBox1.Clear();
				timer.Restart();
				AppendTimeText($"Start {DateTime.Now:yyyy-MM-dd HH:mm}\n", Color.Olive);
				WriteHeaderGamer(gw);
				WriteHeaderGamer(gb);
			}
		}

		public static string GetTime()
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(timer.Elapsed.TotalMilliseconds);
			return dt.ToString("HH:mm:ss");
		}

		static string GetTimeElapsed()
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(timer.Elapsed.TotalMilliseconds);
			return dt.ToString("HH:mm:ss.fff ");
		}

		#region events

		private void FormLog_FormClosing(object sender, FormClosingEventArgs e)
		{
			locked = false;
			process.Terminate();
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fn = $"{FormChess.mode} {DateTime.Now:yyyy-MM-dd hh-mm-ss}.rtf";
			richTextBox1.SaveFile(fn);
			MessageBox.Show($"File {fn} has been saved");
		}

		private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			process.Quit();
		}

		private void restartToolStripMenuItem_Click(object sender, EventArgs e)
		{
			process.Restart();
		}

		private void stopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			process.Stop();
		}

		private void terminateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			process.Terminate();
		}

		#endregion

		private void cbEngineList_SelectedIndexChanged(object sender, EventArgs e)
		{
			CEngine engine = FormChess.engineList.GetEngineByName(cbEngineList.Text);
			if (engine != null)
			{
				locked = true;
				richTextBox1.Clear();
				process.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{engine.file}", engine.parameters);
			}
		}

		private void FormLogEngines_Shown(object sender, EventArgs e)
		{
			cbEngineList.Items.Clear();
			foreach (CEngine eng in FormChess.engineList)
				cbEngineList.Items.Add(eng.name);
		}

		private void butSend_Click(object sender, EventArgs e)
		{
			locked = true;
			richTextBox1.Clear();
			foreach (string c in rtbCommand.Lines)
				process.WriteLine(c);
		}

		private void butClear_Click(object sender, EventArgs e)
		{
			locked = false;
			richTextBox1.Clear();
		}
	}
}

