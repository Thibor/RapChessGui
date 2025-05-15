using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
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
        public readonly FormAutodetect formAutodetect = new FormAutodetect();
        readonly FormSandbox formSandbox = new FormSandbox();

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

        CEngine EngineSave(CEngine e = null)
        {
            if (FormChess.engineList.NameExists(e, tbEngineName.Text))
            {
                MessageBox.Show("This name already exists");
                return null;
            }
            if (e == null)
                e = new CEngine();
            else
                FormChess.engineList.DeleteEngine(e.name);
            SettingsToEngine(e);
            if (string.IsNullOrEmpty(e.name))
                e.name = FormChess.engineList.CreateUniqueName(e);
            FormChess.engineList.AddEngine(e);
            if (e.protocol == CProtocol.auto)
                formAutodetect.ShowDialog(this);
            EngineToSettings(e);
            e.DTModification = DateTime.Now;
            e.SaveToIni();
            UpdateListBox();
            int index = listBoxEngines.FindString(e.name);
            if (index >= 0)
                listBoxEngines.SetSelected(index, true);
            return e;
        }

        void ClickResetAllProtocols()
        {
            foreach (CEngine engine in FormChess.engineList)
                engine.protocol = CProtocol.auto;
            formAutodetect.ShowDialog(this);
            EngineToSettings(engine);
        }

        void ClickClear()
        {
            listBoxEngines.SelectedIndex = -1;
            engine = new CEngine();
            EngineToSettings(engine);
            optionList.Clear();
            panOptions.Controls.Clear();
        }

        void ClickCreate()
        {
            engine = EngineSave();
            if (engine == null)
                return;
            MessageBox.Show($"Chess {engine.name} has been created");
        }

        void ClickDelete()
        {
            if (engine == null)
                return;
            string name = engine.name;
            var dr = MessageBox.Show($"Are you sure that you would like to delete {name}?", "Delete engine", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;
            FormChess.engineList.DeleteEngine(name);
            UpdateListBox();
            ClickClear();
        }

        void ClickDeleteUnplayable()
        {
            FormChess.engineList.DeleteUnaplayable();
            UpdateListBox();
            ClickClear();
        }

        void ClickFindEngines()
        {
            string[] directories = Directory.GetDirectories("Engines");
            foreach (string d in directories)
            {
                string dir = Path.GetFileName(d);
                if (FormChess.engineList.GetEngineByDir(dir) != null)
                    continue;
                string[] filePaths = Directory.GetFiles(d, "*.exe");
                if (filePaths.Length == 0)
                    continue;
                string file = filePaths[0];
                engine = new CEngine();
                FormChess.engineList.Add(engine);
                engine.file = Path.GetFileName(file);
                engine.folder = Path.GetFileName(d);
                engine.SaveToIni();
            }
            formAutodetect.ShowDialog(this);
            UpdateListBox();
            EngineToSettings(engine);
        }

        void ClickSave()
        {
            engine = EngineSave(engine);
            if (engine == null)
                return;
            MessageBox.Show($"Chess {engine.name} has been modified");
        }

        void ClickRename()
        {
            SettingsToEngine(engine);
            tbEngineName.Text = FormChess.engineList.CreateUniqueName(engine);
            ClickSave();
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
                        nud.Value = Convert.ToInt32(engine.GetOption(o.Name, o.Default));
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
                        check.Checked = Convert.ToBoolean(engine.GetOption(o.Name, o.Default));
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
                        box.Text = engine.GetOption(o.Name, o.Default);
                        box.Location = new Point(3, y);
                        box.Size = new Size(panOptions.Width - 32, box.Height);
                        panOptions.Controls.Add(box);
                        y += 24;
                        break;
                    case "combo":
                        lab = new Label();
                        lab.Name = lName;
                        lab.Text = o.Text();
                        lab.TextAlign = ContentAlignment.MiddleLeft;
                        lab.Location = new Point(3, y);
                        lab.Size = new Size(panOptions.Width - 32, lab.Height);
                        panOptions.Controls.Add(lab);
                        y += 24;
                        ComboBox cb = new ComboBox();
                        cb.Name = oName;
                        cb.DropDownStyle = ComboBoxStyle.DropDownList;
                        foreach (string s in o.Combo)
                            cb.Items.Add(s);
                        cb.Text = engine.GetOption(o.Name, o.Default);
                        cb.Location = new Point(3, y);
                        cb.Size = new Size(panOptions.Width - 32, cb.Height);
                        panOptions.Controls.Add(cb);
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

        void StartTestOptions()
        {
            if (processOptions.SetProgram(engine.GetPath(), engine.arguments) > 0)
            {
                processOptions.WriteLine("uci", 1000);
                processOptions.WriteLine("quit");
            }
        }

        public int GetBitmapWidth(Bitmap bmp, int height)
        {
            double ratio = (double)bmp.Width / bmp.Height;
            return Convert.ToInt32(height * ratio);
        }

        void EngineToSettings(CEngine engine)
        {
            if (engine == null)
            {
                EngineToSettings(new CEngine());
                return;
            }
            cbFolderList.SelectedIndex = 0;
            cbFileList.SelectedIndex = 0;
            tbEngineName.Text = engine.name;
            tbParameters.Text = engine.arguments;
            cbFolderList.Text = engine.folder;
            cbFileList.Text = engine.file;
            cbProtocol.Text = CData.ProtocolToStr(engine.protocol);
            cbModeElo.Checked = engine.modeElo;
            cbModeFen.Checked = engine.modeFen;
            cbModeStandard.Checked = engine.modeStandard;
            cbModeTime.Checked = engine.modeTime;
            cbModeDepth.Checked = engine.modeDepth;
            cbModeTournament.Checked = engine.modeTournament;
            cbModeNodes.Checked = engine.modeNodes;
            cbModeInfinite.Checked = engine.modeInfinite;
            cbModeSearchmoves.Checked = engine.modeSearchmoves;
            nudElo.Value = engine.Elo;
            nudTournament.Value = engine.tournament;
            Bitmap bmp = engine.GetBitmap();
            pictureBox.Width = GetBitmapWidth(bmp,pictureBox.Height);
            pictureBox.Image = bmp;
        }


        void SelectEngine(string name)
        {
            engine = null;
            engineName = String.Empty;
            SelectEngine(FormChess.engineList.GetEngineByName(name));
        }

        void SelectEngine(CEngine e)
        {
            if (e == null)
            {
                EngineToSettings(new CEngine());
                return;
            }
            engine = e;
            engineName = e.name;
            SelectEngine();
        }

        void SelectEngine()
        {
            optionList.Clear();
            OptionFinish();
            EngineToSettings(engine);
            StartTestOptions();
        }

        void SelectEngines(int first, int last, bool t)
        {
            int f = first < last ? first : last;
            int l = first < last ? last : first;
            bool r = false;
            for (int n = f; n <= l; n++)
            {
                var item = listBoxEngines.Items[n];
                string name = item.ToString();
                CEngine eng = FormChess.engineList.GetEngineByName(name);
                if (eng.SetTournament(t))
                    r = true;
            }
            if (r)
            {
                listBoxEngines.Refresh();
                SelectEngine();
            }
        }

        void UpdateListBox()
        {
            listBoxEngines.Items.Clear();
            foreach (CEngine e in FormChess.engineList)
                listBoxEngines.Items.Add(e.name);
            gbEngines.Text = $"Engines {listBoxEngines.Items.Count}";
        }

        void SettingsToEngine(CEngine e)
        {
            e.name = tbEngineName.Text.Trim();
            e.folder = cbFolderList.Text;
            e.file = cbFileList.Text;
            e.protocol = CData.StrToProtocol(cbProtocol.Text);
            e.arguments = tbParameters.Text;
            e.modeElo = cbModeElo.Checked;
            e.modeFen = cbModeFen.Checked;
            e.modeStandard = cbModeStandard.Checked;
            e.modeTime = cbModeTime.Checked;
            e.modeDepth = cbModeDepth.Checked;
            e.modeTournament = cbModeTournament.Checked;
            e.modeNodes = cbModeNodes.Checked;
            e.modeInfinite = cbModeInfinite.Checked;
            e.modeSearchmoves = cbModeSearchmoves.Checked;
            e.Elo = (int)nudElo.Value;
            e.tournament = (int)nudTournament.Value;
            e.options = GetOptions();
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
                    case "combo":
                        ComboBox cb = c[1] as ComboBox;
                        value = cb.Text;
                        if (o.Default != value)
                            list.Add($"name {o.Name} value {value}");
                        break;
                }
            }
            return list;
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            ClickCreate();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (engine == null)
                ClickCreate();
            else
                ClickSave();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            ClickDelete();
        }

        private void FormEngine_Shown(object sender, EventArgs e)
        {
            CData.UpdateFolderEngine();
            cbFolderList.Items.Clear();
            cbFolderList.Sorted = true;
            foreach (string folder in CData.folderEngine)
                cbFolderList.Items.Add(folder);
            cbFolderList.Sorted = false;
            cbFolderList.Items.Insert(0, Global.none);
            cbFolderList.SelectedIndex = 0;
            if (FormChess.engineList.GetEngineAuto() != null)
                formAutodetect.ShowDialog(this);
            UpdateListBox();
            listBoxEngines.SelectedIndex = listBoxEngines.FindString(engineName);
            if ((listBoxEngines.SelectedIndex < 0) && (listBoxEngines.Items.Count > 0))
                listBoxEngines.SelectedIndex = 0;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            string name = listBoxEngines.Items[e.Index].ToString();
            CEngine eng = FormChess.engineList.GetEngineByName(name);
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Brush b = Brushes.Black;
            if (selected)
            {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, Colors.message, Colors.chartD);
                b = Brushes.White;
            }
            else if (!eng.IsPlayable())
            {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.Black, Color.FromArgb(0xff, 0xc0, 0xc0));
            }
            else if (eng.tournament > 0)
            {
                if (eng.modeStandard && eng.modeTime && eng.modeFen)
                    e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.Black, Colors.message);
                else
                    e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.Black, Color.FromArgb(0xff, 0xff, 0xc0));
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
                listBoxEngines.Capture = true;
                int index = listBoxEngines.IndexFromPoint(e.Location);
                if ((index >= 0) && (index < listBoxEngines.Items.Count))
                {
                    var item = listBoxEngines.Items[index];
                    string name = item.ToString();
                    CEngine eng = FormChess.engineList.GetEngineByName(name);
                    indexFirst = index;
                    tournament = eng.tournament > 0 ? 0 : 1;
                    if (eng.SetTournament(tournament == 1))
                    {
                        listBoxEngines.Refresh();
                        if (engine == eng)
                            SelectEngine();
                    }

                }
            }
        }

        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            tournament = -1;
            listBoxEngines.Capture = false;
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listBoxEngines.IndexFromPoint(e.Location);
                if ((index >= 0) && (index < listBoxEngines.Items.Count) && (tournament >= 0))
                    SelectEngines(indexFirst, index, tournament > 0);
            }
        }

        private void FormEngine_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (processOptions != null)
                processOptions.Terminate();
            CListEngine.iniFile.Save();
        }

        private void bRename_Click(object sender, EventArgs e)
        {
            ClickRename();
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = engine.GetPath();
            psi.Arguments = engine.arguments;
            psi.WorkingDirectory = Path.GetDirectoryName(psi.FileName);
            Process.Start(psi);
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
                engine.ClearHistory();
                engine.eMove.Clear();
                engine.eTime.Clear();
                engine.SaveToIni();
                int count = CModeTournamentE.tourList.DeletePlayer(engine.name);
                MessageBox.Show($"{count} records have been deleted");
            }
        }

        private void cbFolderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> list = CData.ListExe($@"Engines\{cbFolderList.Text}");
            CData.FillComboBox(cbFileList, list);
            cbFileList.SelectedIndex = cbFileList.Items.Count - 1;
        }

        private void autodetectEngineProtocolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            engine.protocol = CProtocol.auto;
            formAutodetect.ShowDialog(this);
            EngineToSettings(engine);
        }

        private void autodetectAllEnginesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show($"Reset all protocols?", "Reset protocols", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;
            ClickResetAllProtocols();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            ClickClear();
        }

        private void findEnginesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickFindEngines();
        }

        private void deleteNotExistsEnginesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickDeleteUnplayable();
        }

        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxEngines.SelectedItem != null)
                SelectEngine(listBoxEngines.SelectedItem.ToString());
        }

        private void Log_Click(object sender, EventArgs e)
        {
            FormChess.ShowFormLog("Engine autodetection", FormAutodetect.pathAutoEng, this);
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int n = 0; n < FormChess.engineList.Count; n++)
                if (FormChess.engineList[n].tournament == 0)
                    FormChess.engineList[n].tournament = 1;
            FormChess.engineList.SaveToIni();
            listBoxEngines.Refresh();
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int n = 0; n < FormChess.engineList.Count; n++)
                FormChess.engineList[n].tournament = 0;
            FormChess.engineList.SaveToIni();
            listBoxEngines.Refresh();
        }

        private void clearEngineEloAccToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (engine != null)
            {
                engine.accuracy = 0;
                engine.DTAccuracy = new DateTime(0);
                engine.SaveToIni();
            }
        }

        private void ResetAllAccuracy_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show($"Reset all accuracy?", "Reset accuracy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;
            foreach (CEngine engine in FormChess.engineList)
            {
                engine.accuracy = 0;
                engine.DTAccuracy = new DateTime(0);
            }
            FormChess.engineList.SaveToIni();
        }

        private void sandboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formSandbox.ShowDialog(this);
        }
    }
}