using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace RapChessGui
{

	public partial class FormEditEngine : Form
	{
		public static FormEditEngine This;
		int indexFirst = -1;
		int tournament = -1;
		static CEngine engine = null;
		public static string engineName = String.Empty;
		public static CProcess processOptions = null;
		readonly static COptionList optionList = new COptionList();
		readonly FormAutodetect formAutodetect = new FormAutodetect();

		public FormEditEngine()
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


		void ClickSave()
		{
			if (engine == null)
				return;
			CEngineList.iniFile.DeleteKey($"engine>{engine.name}");
			SaveToIni(engine);
			MessageBox.Show($"Chess {engine.name} has been modified");
			CData.reset = true;
		}

		public void OptionFinish()
		{
			int y = 8;
			panOptions.Controls.Clear();
			optionList.Sort();
			Label lab;
			for (int n = 0; n < optionList.list.Count; n++)
			{
				string name = $"optionN{n}";
				string oName = name;
				string lName = name;
				COption o = optionList.list[n];
				switch (o.type)
				{
					case "spin":
						var nud = new NumericUpDown();
						nud.Name = oName;
						nud.Minimum = Convert.ToInt32(o.min);
						nud.Maximum = Convert.ToInt32(o.max);
						nud.Value = Convert.ToInt32(engine.GetOption(o.name, o.def));
						nud.Location = new Point(3, y);
						nud.TextAlign = HorizontalAlignment.Right;
						panOptions.Controls.Add(nud);
						lab = new Label();
						lab.Name = lName;
						lab.Text = o.name;
						lab.Location = new Point(128, y);
						lab.Size = new Size(panOptions.Width - 160, lab.Height);
						panOptions.Controls.Add(lab);
						y += 24;
						break;
					case "check":
						CheckBox check = new CheckBox();
						check.Name = oName;
						check.Text = o.name;
						check.Checked = Convert.ToBoolean(engine.GetOption(o.name, o.def));
						check.Location = new Point(3, y);
						check.Size = new Size(panOptions.Width - 32, check.Height);
						panOptions.Controls.Add(check);
						y += 24;
						break;
					case "string":
						lab = new Label();
						lab.Name = lName;
						lab.Text = o.name;
						lab.TextAlign = ContentAlignment.MiddleLeft;
						lab.Location = new Point(3, y);
						lab.Size = new Size(panOptions.Width - 32, lab.Height);
						panOptions.Controls.Add(lab);
						y += 24;
						TextBox box = new TextBox();
						box.Name = oName;
						box.Text = o.def;
						box.Location = new Point(3,y);
						box.Size = new Size(panOptions.Width-32,box.Height);
						panOptions.Controls.Add(box);
						y += 24;
						break;
				}
			}
		}

		public static void NewMessageOptions(string msg)
		{
			if (msg == "uciok")
				This.OptionFinish();
			else
				optionList.Add(msg);
		}

		void ClickRename()
		{
			CEngine e = new CEngine();
			SetingsToEngine(e);
			string name = e.CreateName();
			if (name != e.name)
				name = FormChess.engineList.GetName(name);
			tbEngineName.Text = name;
			ClickSave();
		}

		void StartTestOptions()
		{
			if (processOptions.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{engine.file}", engine.parameters) > 0)
			{
				processOptions.WriteLine("uci",true);
				processOptions.WriteLine("quit");
			}
		}

		void EngineToSetings()
		{
			tbEngineName.Text = engine.name;
			tbParameters.Text = engine.parameters;
			cbFileList.Text = engine.GetFile();
			cbProtocol.Text = CData.ProtocolToStr(engine.protocol);
			cbModeStandard.Checked = engine.modeStandard;
			cbModeTime.Checked = engine.modeTime;
			cbModeDepth.Checked = engine.modeDepth;
			cbModeTournament.Checked = engine.modeTournament;
			cbModeNodes.Checked = engine.modeNodes;
			nudElo.Value = Convert.ToInt32(engine.elo);
			nudTournament.Value = engine.tournament;
		}



		void SelectEngine(string name)
		{
			engine = FormChess.engineList.GetEngineByName(name);
			engineName = String.Empty;
			if (engine == null)
				return;
			SelectEngine(engine);
		}

		void SelectEngine(CEngine e)
		{
			engine = e;
			engineName = e.name;
			SelectEngine();
		}

		void SelectEngine()
		{
			optionList.list.Clear();
			OptionFinish();
			EngineToSetings();
			StartTestOptions();
		}

		void SelectEngines(int first, int last, bool t)
		{
			int f = first < last ? first : last;
			int l = first < last ? last : first;
			bool r = false;
			for (int n = f; n <= l; n++)
			{
				var item = listBox1.Items[n];
				string name = item.ToString();
				CEngine eng = FormChess.engineList.GetEngineByName(name);
				if (eng.SetTournament(t))
					r = true;
			}
			if (r)
			{
				listBox1.Refresh();
				SelectEngine();
			}
		}

		void UpdateListBox()
		{
			listBox1.Items.Clear();
			foreach (CEngine e in FormChess.engineList)
				listBox1.Items.Add(e.name);
			gbEngines.Text = $"Engines {listBox1.Items.Count}";
		}

		void ShowAutodetect(string engineName)
		{
			FormAutodetect.engineName = engineName;
			formAutodetect.ShowDialog(this);
		}

		void SetingsToEngine(CEngine e)
		{
			e.name = tbEngineName.Text;
			e.file = cbFileList.Text;
			e.protocol = CData.StrToProtocol(cbProtocol.Text);
			e.parameters = tbParameters.Text;
			e.modeStandard = cbModeStandard.Checked;
			e.modeTime = cbModeTime.Checked;
			e.modeDepth = cbModeDepth.Checked;
			e.modeTournament = cbModeTournament.Checked;
			e.modeNodes = cbModeNodes.Checked;
			e.elo = nudElo.Value.ToString();
			e.tournament = (int)nudTournament.Value;
			e.options = GetOptions();
		}

		void SaveToIni(CEngine e)
		{
			SetingsToEngine(e);
			e.SaveToIni();
			UpdateListBox();
			int index = listBox1.FindString(e.name);
			if (index == -1) return;
			listBox1.SetSelected(index, true);
		}

		List<string> GetOptions()
		{
			List<string> list = new List<string>();
			for (int n = 0; n < optionList.list.Count; n++)
			{
				string oName = $"optionN{n}";
				var c = panOptions.Controls.Find(oName, false);
				if (c.Length == 0)
					continue;
				COption o = optionList.list[n];
				string value;
				switch (o.type)
				{
					case "spin":
						NumericUpDown nud = c[0] as NumericUpDown;
						value = nud.Value.ToString();
						if (o.def != value)
							list.Add($"name {o.name} value {value}");
						break;
					case "check":
						CheckBox check = c[0] as CheckBox;
						value = check.Checked ? "true" : "false";
						if (o.def != value)
							list.Add($"name {o.name} value {value}");
						break;
					case "string":
						TextBox tb = c[1] as TextBox;
						value = tb.Text;
						if (o.def != value)
							list.Add($"name {o.name} value {value}");
						break;
				}
			}
			return list;
		}

		private void bCreate_Click(object sender, EventArgs e)
		{
			string name = tbEngineName.Text;
			if (FormChess.engineList.GetEngineByName(name) != null)
			{
				MessageBox.Show("This name already exists");
				return;
			}
			CEngine engine = new CEngine(name);
			FormChess.engineList.Add(engine);
			SaveToIni(engine);
			MessageBox.Show($"Chess {engine.name} has been created");
			CData.reset = true;
		}

		private void bSave_Click(object sender, EventArgs e)
		{
			ClickSave();
		}

		private void bDelete_Click(object sender, EventArgs e)
		{
			string name = tbEngineName.Text;
			var dr = MessageBox.Show($"Are you sure that you would like to delete {name}?","Delete engine",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
				FormChess.engineList.DeleteEngine(name);
				UpdateListBox();
				CData.reset = true;
			}
		}

		private void FormEngine_Shown(object sender, EventArgs e)
		{
			CData.UpdateFileEngine();
			cbFileList.Items.Clear();
			cbFileList.Sorted = true;
			foreach (string engine in CData.fileEngine)
				cbFileList.Items.Add(engine);
			foreach (string engine in CData.fileEngineAuto)
				cbFileList.Items.Add($@"Auto\{engine}");
			cbFileList.Sorted = false;
			cbFileList.Items.Insert(0, "None");
			cbFileList.SelectedIndex = 0;
			UpdateListBox();
			listBox1.SelectedIndex = listBox1.FindString(engineName);
			if ((listBox1.SelectedIndex < 0) && (listBox1.Items.Count > 0))
				listBox1.SelectedIndex = 0;
		}

		private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
				return;
			string name = listBox1.Items[e.Index].ToString();
			CEngine eng = FormChess.engineList.GetEngineByName(name);
			bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
			Brush b = Brushes.Black;
			if (selected)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, CBoard.colorMessage, CBoard.colorChartD);
				b = Brushes.White;
			}
			else if (!eng.FileExists())
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.White, CBoard.colorRed);
				b = Brushes.White;
			}
			else if (eng.tournament > 0)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.Black, CBoard.colorMessage);
			}
			e.DrawBackground();
			e.Graphics.DrawString(name, e.Font, b, e.Bounds, StringFormat.GenericDefault);
			e.DrawFocusRectangle();
		}

		private void listBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				indexFirst = -1;
				tournament = -1;
				listBox1.Capture = true;
				int index = listBox1.IndexFromPoint(e.Location);
				if ((index >= 0) && (index < listBox1.Items.Count))
				{
					var item = listBox1.Items[index];
					string name = item.ToString();
					CEngine eng = FormChess.engineList.GetEngineByName(name);
					indexFirst = index;
					tournament = eng.tournament > 0 ? 0 : 1;
					if (eng.SetTournament(tournament == 1))
					{
						listBox1.Refresh();
						if (engine == eng)
							SelectEngine();
					}

				}
			}
		}

		private void listBox1_MouseUp(object sender, MouseEventArgs e)
		{
			tournament = -1;
			listBox1.Capture = false;
		}

		private void listBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				int index = listBox1.IndexFromPoint(e.Location);
				if ((index >= 0) && (index < listBox1.Items.Count) && (tournament >= 0))
					SelectEngines(indexFirst, index, tournament > 0);
			}
		}

		private void FormEngine_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (processOptions != null)
				processOptions.Terminate();
			CEngineList.iniFile.Save();
		}

		private void bRename_Click(object sender, EventArgs e)
		{
			ClickRename();
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectEngine(listBox1.SelectedItem.ToString());
		}

		private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = engine.GetFileName();
			psi.Arguments = engine.parameters;
			psi.WorkingDirectory = Path.GetDirectoryName(psi.FileName);
			Process.Start(psi);
		}

		private void autodetectEngineProtocolToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowAutodetect(engineName);
			EngineToSetings();
		}

		private void resetEngineOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			engine.options.Clear();
			engine.SaveToIni();
			OptionFinish();
		}

		private void clearTournamentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (engine != null)
			{
				engine.hisElo.Clear();
				engine.SaveToIni();
				int count = CModeTournamentE.tourList.DeletePlayer(engine.name);
				MessageBox.Show($"{count} records have been deleted");
			}
		}
	}
}