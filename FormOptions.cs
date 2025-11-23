using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;

namespace RapChessGui
{
    public partial class FormOptions : Form
    {
        public static int fontSize = 10;
        public static int marginStandard = 0;
        public static int marginTime = 5000;
        public static int winLimit = 1;
        public static int tourBValue = 100;
        public static int userElo = 1000;
        public static string tourBMode = "Time";
        public static string tourEMode = "Time";
        public static ProcessPriorityClass priority = ProcessPriorityClass.Normal;
        public static Color color = Color.Yellow;


        [ComImport]
        [Guid("00021401-0000-0000-C000-000000000046")]
        internal class ShellLink
        {
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214F9-0000-0000-C000-000000000046")]
        internal interface IShellLink
        {
            void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out IntPtr pfd, int fFlags);
            void GetIDList(out IntPtr ppidl);
            void SetIDList(IntPtr pidl);
            void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
            void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
            void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
            void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
            void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
            void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
            void GetHotkey(out short pwHotkey);
            void SetHotkey(short wHotkey);
            void GetShowCmd(out int piShowCmd);
            void SetShowCmd(int iShowCmd);
            void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);
            void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
            void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
            void Resolve(IntPtr hwnd, int fFlags);
            void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
        }

        public FormOptions()
        {
            InitializeComponent();
            CreateLink();
        }

        void CreateLink()
        {
            IShellLink link = (IShellLink)new ShellLink();
            link.SetDescription("Chess program");
            link.SetPath(Application.ExecutablePath);
            link.SetWorkingDirectory(Path.GetDirectoryName(Application.ExecutablePath));
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fn = "RapChessGui.lnk";
            if (!File.Exists($@"{desktopPath}\{fn}"))
            {
                IPersistFile file = (IPersistFile)link;
                file.Save(Path.Combine(desktopPath, fn), false);
            }
        }

        bool IsLink()
        {
            return File.Exists(LinkPath());
        }

        void DeleteLink()
        {
            if (IsLink())
                File.Delete(LinkPath());
        }

        string LinkPath()
        {
            return $@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\RapChessGui.lnk";
        }

        public void SettingsToMatch()
        {
            CModeMatch.engine1 = cbMatchEngine1.Text;
            CModeMatch.engine2 = cbMatchEngine2.Text;
            CModeMatch.modeValue1.SetLimit(cbMatchMode1.Text);
            CModeMatch.modeValue2.SetLimit(cbMatchMode2.Text);
            CModeMatch.modeValue1.SetValue((int)nudMatchValue1.Value);
            CModeMatch.modeValue2.SetValue((int)nudMatchValue2.Value);
            CModeMatch.SaveToIni();
        }

        public void MatchToSettings()
        {
            cbMatchEngine1.Text = CModeMatch.engine1;
            cbMatchEngine2.Text = CModeMatch.engine2;
            cbMatchBook1.Text = CModeMatch.book1;
            cbMatchBook2.Text = CModeMatch.book2;
            cbMatchMode1.Text = CModeMatch.modeValue1.GetLimit();
            cbMatchMode2.Text = CModeMatch.modeValue2.GetLimit();
            ValueToNud(CModeMatch.modeValue1.GetValue(), nudMatchValue1);
            ValueToNud(CModeMatch.modeValue2.GetValue(), nudMatchValue2);
        }

        void ValueToNud(decimal value, NumericUpDown nud)
        {
            if (value > nud.Maximum)
                value = nud.Maximum;
            if (value < nud.Minimum)
                value = nud.Minimum;
            nud.Value = value;
        }

        public void LoadFromIni(bool def = false)
        {
            for (int i = 0; i < clbPuzzle.Items.Count; i++)
                clbPuzzle.SetItemChecked(i, FormChess.ini.ReadBool($"options>mode>puzzle>{i}", true, def));
            nudPuzzleRepetition.Value = FormChess.ini.ReadDecimal("options>mode>puzzle>repetition", nudPuzzleRepetition.Value, def);

            cbEditLimitT.Text = FormChess.ini.Read("options>mode>edit>limit", Global.limit, def);
            nudEditLimitV.Value = FormChess.ini.ReadDecimal("options>mode>edit>value", Global.value, def);

            cbGameBook.Text = FormChess.ini.Read("options>mode>game>book", CListBook.def, def);
            cbGameEngine.Text = FormChess.ini.Read("options>mode>game>engine", CListEngine.def, def);
            cbGameOpponent.Text = FormChess.ini.Read("options>mode>game>opponent", "Auto", def);
            cbGameTeacher.Text = FormChess.ini.Read("options>mode>game>teacher>name", Global.none, def);
            nudTeacherDepth.Value = FormChess.ini.ReadDecimal("options>mode>game>teacher>depth", 15, def);
            cbBottomPlayer.SelectedIndex = FormChess.ini.ReadInt("options>mode>game>bottom", 0, def);
            nudBreak.Value = FormChess.ini.ReadDecimal("options>mode>game>break", 8, def);

            CModeMatch.LoadFromIni();
            MatchToSettings();

            cbTourBSelected.Text = FormChess.ini.Read("options>mode>tourB>selected", Global.none, def);
            cbTourBEngine.Text = FormChess.ini.Read("options>mode>tourB>engine", Global.none, def);
            cbTourBMode.Text = FormChess.ini.Read("options>mode>tourB>mode", tourBMode, def);
            nudTourB.Value = FormChess.ini.ReadDecimal("options>mode>tourB>value", tourBValue, def);
            nudTourBRec.Value = FormChess.ini.ReadDecimal("options>mode>tourB>records", 10000, def);
            nudTourBAvg.Value = FormChess.ini.ReadDecimal("options>mode>tourB>avg", 0, def);
            nudTourBRange.Value = FormChess.ini.ReadDecimal("options>mode>tourB>range", 0, def);

            cbTourESelected.Text = FormChess.ini.Read("options>mode>tourE>selected", Global.none, def);
            cbTourEBookF.Text = FormChess.ini.Read("options>mode>tourE>bookF", Global.none, def);
            cbTourEBookS.Text = FormChess.ini.Read("options>mode>tourE>bookS", Global.none, def);
            cbTourEMode.Text = FormChess.ini.Read("options>mode>tourE>mode", tourEMode, def);
            nudTourE.Value = FormChess.ini.ReadDecimal("options>mode>tourE>value",100,def);
            nudTourEInc.Value = FormChess.ini.ReadDecimal("options>mode>tourE>inc", 0, def);
            nudTourERec.Value = FormChess.ini.ReadDecimal("options>mode>tourE>records", 10000, def);
            nudTourEAvg.Value = FormChess.ini.ReadDecimal("options>mode>tourE>avg", 0, def);
            nudTourELimit.Value = FormChess.ini.ReadDecimal("options>mode>tourE>range", 0, def);

            cbTourPSelected.Text = FormChess.ini.Read("options>mode>tourP>selected", Global.none, def);
            nudTourPRec.Value = FormChess.ini.ReadDecimal("options>mode>tourP>records", 10000, def);
            nudTourPAvg.Value = FormChess.ini.ReadDecimal("options>mode>tourP>avg", 0, def);
            nudTourPRange.Value = FormChess.ini.ReadDecimal("options>mode>tourP>range", 0, def);

            color = ColorTranslator.FromHtml(FormChess.ini.Read("options>interface>color", ColorTranslator.ToHtml(Color.Yellow), def));
            rbSan.Checked = FormChess.ini.ReadBool("options>interface>san", rbSan.Checked);
            cbAttack.Checked = FormChess.ini.ReadBool("options>interface>attack", false, def);
            cbArrow.Checked = FormChess.ini.ReadBool("options>interface>arrow", true, def);
            cbTips.Checked = FormChess.ini.ReadBool("options>interface>tips", true, def);
            cbSound.Checked = FormChess.ini.ReadBool("options>interface>sound", true, def);
            nudTraining.Value = FormChess.ini.ReadDecimal("options>mode>training>strength", 1, def);
            nudHistory.Value = FormChess.ini.ReadDecimal("options>interface>history", 100, def);
            nudSpeed.Value = FormChess.ini.ReadDecimal("options>interface>speed", 200, def);
            nudFontSize.Value = FormChess.ini.ReadDecimal("options>interface>font", 10, def);
            cbGameRanked.Checked = FormChess.ini.ReadBool("options>game>ranked", true, def);
            combModeStandard.SelectedIndex = FormChess.ini.ReadInt("options>margin>standard", 1, def);
            combModeTime.SelectedIndex = FormChess.ini.ReadInt("options>margin>time", 0, def);
            combPriority.SelectedIndex = FormChess.ini.ReadInt("options>priority", 2, def);
            nudUserElo.Value = FormChess.ini.ReadInt("options>game>userElo", userElo, def);
            cbLink.Checked = IsLink();
            if (!rbSan.Checked)
                rbUci.Checked = true;
            Colors.SetColor();
        }

        public void SaveToIni()
        {
            for (int i = 0; i < clbPuzzle.Items.Count; i++)
                FormChess.ini.Write($"options>mode>puzzle>{i}", clbPuzzle.GetItemChecked(i));
            FormChess.ini.Write("options>mode>puzzle>repetition", nudPuzzleRepetition.Value);

            FormChess.ini.Write("options>mode>edit>limit", cbEditLimitT.Text);
            FormChess.ini.Write("options>mode>edit>value", nudEditLimitV.Value);

            FormChess.ini.Write("options>mode>game>book", cbGameBook.Text);
            FormChess.ini.Write("options>mode>game>engine", cbGameEngine.Text);
            FormChess.ini.Write("options>mode>game>opponent", cbGameOpponent.Text);
            FormChess.ini.Write("options>mode>game>teacher>name", cbGameTeacher.Text);
            FormChess.ini.Write("options>mode>game>teacher>depth", nudTeacherDepth.Value);
            FormChess.ini.Write("options>mode>game>bottom", cbBottomPlayer.SelectedIndex);
            FormChess.ini.Write("options>mode>game>break", nudBreak.Value);

            CModeMatch.book1 = cbMatchBook1.Text;
            CModeMatch.book2 = cbMatchBook2.Text;
            CModeMatch.engine1 = cbMatchEngine1.Text;
            CModeMatch.engine2 = cbMatchEngine2.Text;
            CModeMatch.modeValue1.SetLimit(cbMatchMode1.Text);
            CModeMatch.modeValue2.SetLimit(cbMatchMode2.Text);
            CModeMatch.modeValue1.SetValue((int)nudMatchValue1.Value);
            CModeMatch.modeValue2.SetValue((int)nudMatchValue2.Value);
            CModeMatch.SaveToIni();

            FormChess.ini.Write("options>mode>tourB>selected", cbTourBSelected.Text);
            FormChess.ini.Write("options>mode>tourB>engine", cbTourBEngine.Text);
            FormChess.ini.Write("options>mode>tourB>mode", cbTourBMode.Text);
            FormChess.ini.Write("options>mode>tourB>value", nudTourB.Value);
            FormChess.ini.Write("options>mode>tourB>records", nudTourBRec.Value);
            FormChess.ini.Write("options>mode>tourB>avg", nudTourBAvg.Value);
            FormChess.ini.Write("options>mode>tourB>range", nudTourBRange.Value);

            FormChess.ini.Write("options>mode>tourE>selected", cbTourESelected.Text);
            FormChess.ini.Write("options>mode>tourE>bookF", cbTourEBookF.Text);
            FormChess.ini.Write("options>mode>tourE>bookS", cbTourEBookS.Text);
            FormChess.ini.Write("options>mode>tourE>mode", cbTourEMode.Text);
            FormChess.ini.Write("options>mode>tourE>value", nudTourE.Value);
            FormChess.ini.Write("options>mode>tourE>inc", nudTourEInc.Value);
            FormChess.ini.Write("options>mode>tourE>records", nudTourERec.Value);
            FormChess.ini.Write("options>mode>tourE>avg", nudTourEAvg.Value);
            FormChess.ini.Write("options>mode>tourE>range", nudTourELimit.Value);

            FormChess.ini.Write("options>mode>tourP>selected", cbTourPSelected.Text);
            FormChess.ini.Write("options>mode>tourP>records", nudTourPRec.Value);
            FormChess.ini.Write("options>mode>tourP>avg", nudTourPAvg.Value);
            FormChess.ini.Write("options>mode>tourP>range", nudTourPRange.Value);

            FormChess.ini.Write("options>interface>color", ColorTranslator.ToHtml(color));
            FormChess.ini.Write("options>interface>san", rbSan.Checked);
            FormChess.ini.Write("options>interface>attack", cbAttack.Checked);
            FormChess.ini.Write("options>interface>arrow", cbArrow.Checked);
            FormChess.ini.Write("options>interface>tips", cbTips.Checked);
            FormChess.ini.Write("options>interface>sound", cbSound.Checked);
            FormChess.ini.Write("options>mode>training>strength", nudTraining.Value);
            FormChess.ini.Write("options>interface>history", nudHistory.Value);
            FormChess.ini.Write("options>interface>speed", nudSpeed.Value);
            FormChess.ini.Write("options>interface>font", nudFontSize.Value);
            FormChess.ini.Write("options>game>ranked", cbGameRanked.Checked);
            FormChess.ini.Write("options>margin>standard", combModeStandard.SelectedIndex);
            FormChess.ini.Write("options>margin>time", combModeTime.SelectedIndex);
            FormChess.ini.Write("options>priority", combPriority.SelectedIndex);
            FormChess.ini.Write("options>game>userElo", nudUserElo.Value);
        }

        public void ResetBooks()
        {
            cbGameBook.Items.Clear();
            cbCustomBook.Items.Clear();
            cbMatchBook1.Items.Clear();
            cbMatchBook2.Items.Clear();
            cbTourBSelected.Items.Clear();
            cbTourEBookF.Items.Clear();
            cbTourEBookS.Items.Clear();
            cbGameBook.Sorted = true;
            cbCustomBook.Sorted = true;
            cbMatchBook1.Sorted = true;
            cbMatchBook2.Sorted = true;
            cbTourBSelected.Sorted = true;
            cbTourEBookF.Sorted = true;
            cbTourEBookS.Sorted = true;
            foreach (CBook b in FormChess.bookList)
                if (b.FileExists())
                {
                    cbGameBook.Items.Add(b.name);
                    cbCustomBook.Items.Add(b.name);
                    cbMatchBook1.Items.Add(b.name);
                    cbMatchBook2.Items.Add(b.name);
                    cbTourBSelected.Items.Add(b.name);
                    cbTourEBookF.Items.Add(b.name);
                    cbTourEBookS.Items.Add(b.name);
                }
            cbGameBook.Sorted = false;
            cbCustomBook.Sorted = false;
            cbMatchBook1.Sorted = false;
            cbMatchBook2.Sorted = false;
            cbTourBSelected.Sorted = false;
            cbTourEBookF.Sorted = false;
            cbTourEBookS.Sorted = false;
            cbGameBook.Items.Insert(0, Global.none);
            cbCustomBook.Items.Insert(0, Global.none);
            cbMatchBook1.Items.Insert(0, Global.none);
            cbMatchBook2.Items.Insert(0, Global.none);
            cbTourBSelected.Items.Insert(0, Global.none);
            cbTourEBookF.Items.Insert(0, Global.none);
            cbTourEBookS.Items.Insert(0, Global.none);
            cbMatchBook1.Items.Insert(1, "Random");
            cbMatchBook2.Items.Insert(1, "Random");
            cbTourEBookF.Items.Insert(1, "Random");
            cbTourEBookS.Items.Insert(1, "Random");
            cbGameBook.Text = Global.none;
            cbCustomBook.Text = Global.none;
            cbMatchBook1.Text = Global.none;
            cbMatchBook2.Text = Global.none;
            cbTourBSelected.Text = Global.none;
            cbTourEBookF.Text = Global.none;
            cbTourEBookS.Text = Global.none;
        }

        public void ResetEngines()
        {
            cbGameEngine.Items.Clear();
            cbGameTeacher.Items.Clear();
            cbCustomEngine.Items.Clear();
            cbMatchEngine1.Items.Clear();
            cbMatchEngine2.Items.Clear();
            cbTourBEngine.Items.Clear();
            cbTourESelected.Items.Clear();
            cbGameEngine.Sorted = true;
            cbGameTeacher.Sorted = true;
            cbCustomEngine.Sorted = true;
            cbMatchEngine1.Sorted = true;
            cbMatchEngine2.Sorted = true;
            cbTourBEngine.Sorted = true;
            cbTourESelected.Sorted = true;
            foreach (CEngine e in FormChess.engineList)
                if (e.FileExists())
                {
                    if (e.modeElo)
                        cbGameEngine.Items.Add(e.name);
                    if (e.modeDepth && e.modeFen && e.modeSearchmoves && (e.protocol == CProtocol.uci))
                        cbGameTeacher.Items.Add(e.name);
                    cbCustomEngine.Items.Add(e.name);
                    cbMatchEngine1.Items.Add(e.name);
                    cbMatchEngine2.Items.Add(e.name);
                    cbTourBEngine.Items.Add(e.name);
                    cbTourESelected.Items.Add(e.name);
                }
            cbGameEngine.Sorted = false;
            cbGameTeacher.Sorted = false;
            cbCustomEngine.Sorted = false;
            cbMatchEngine1.Sorted = false;
            cbMatchEngine2.Sorted = false;
            cbTourBEngine.Sorted = false;
            cbTourESelected.Sorted = false;
            cbGameEngine.Items.Insert(0, Global.none);
            cbGameTeacher.Items.Insert(0, Global.none);
            cbCustomEngine.Items.Insert(0, Global.none);
            cbMatchEngine1.Items.Insert(0, Global.none);
            cbMatchEngine2.Items.Insert(0, Global.none);
            cbTourBEngine.Items.Insert(0, Global.none);
            cbTourESelected.Items.Insert(0, Global.none);
            cbGameEngine.Text = Global.none;
            cbGameTeacher.Text = Global.none;
            cbCustomEngine.Text = Global.none;
            cbMatchEngine1.Text = Global.none;
            cbMatchEngine2.Text = Global.none;
            cbTourBEngine.Text = Global.none;
            cbTourESelected.Text = Global.none;
        }

        public void Reset()
        {
            lvBooks.Items.Clear();
            foreach (CReader db in FormChess.readerList)
            {
                ListViewItem lvi = new ListViewItem(new[] { db.dir, db.bookReader });
                lvBooks.Items.Add(lvi);
            }
            cbBookReader.Items.Clear();
            cbBookReader.Items.Add(Global.none);
            foreach (string book in CData.fileBookReader)
                cbBookReader.Items.Add(book);
            cbBookReader.SelectedIndex = 0;

            ResetBooks();
            ResetEngines();

            cbTourPSelected.Items.Clear();
            cbTourPSelected.Sorted = true;
            foreach (CPlayer p in FormChess.playerList)
                cbTourPSelected.Items.Add(p.name);
            cbTourPSelected.Sorted = false;
            cbTourPSelected.Items.Insert(0, Global.none);
            cbTourPSelected.SelectedIndex = 0;
        }

        public void FormLoad()
        {
            Reset();
            LoadFromIni();
        }

        void FormSave()
        {
            FormChess.readerList.Clear();
            foreach (ListViewItem lvi in lvBooks.Items)
            {
                CReader db = new CReader();
                db.dir = lvi.SubItems[0].Text;
                db.bookReader = lvi.SubItems[1].Text;
                FormChess.readerList.Add(db);
            }
            FormChess.readerList.SaveToIni();
            SaveToIni();
        }

        public static void SetFontSize(Form form)
        {
            foreach (Control ctrl in form.Controls)
                ctrl.Font = new Font(ctrl.Font.Name, fontSize, ctrl.Font.Style, ctrl.Font.Unit);
        }

        int CbToMargin(int i)
        {
            return new int[] { -1, 0, 1000, 2000, 5000, 10000 }[i];
        }

        private void butColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = color;
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                color = colorDialog1.Color;
                Colors.SetColor();
                (Owner as FormChess).board.background.Render();
                (Owner as FormChess).BoardPrepare();
            }
        }

        private void butDefault_Click(object sender, EventArgs e)
        {
            LoadFromIni(true);
            (Owner as FormChess).board.background.Render();
            (Owner as FormChess).BoardPrepare();
        }

        private void cbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (combPriority.Text)
            {
                case "Idle":
                    priority = ProcessPriorityClass.Idle;
                    break;
                case "Below normal":
                    priority = ProcessPriorityClass.BelowNormal;
                    break;
                case "Normal":
                    priority = ProcessPriorityClass.Normal;
                    break;
                case "Above normal":
                    priority = ProcessPriorityClass.AboveNormal;
                    break;
                case "High":
                    priority = ProcessPriorityClass.High;
                    break;
            }
        }

        private void FormOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormSave();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = listBox.SelectedIndex;
            labTitle.Text = listBox.Text;
        }

        private void cbBookReader_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBooks.SelectedItems.Count > 0)
            {
                lvBooks.SelectedItems[0].SubItems[1].Text = cbBookReader.Text;
            }
        }

        private void lvBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBooks.SelectedItems.Count > 0)
                cbBookReader.Text = lvBooks.SelectedItems[0].SubItems[1].Text;
        }

        private void nudTraining_ValueChanged(object sender, EventArgs e)
        {
            winLimit = (int)nudTraining.Value;
        }

        private void cbGameAutoElo_CheckedChanged(object sender, EventArgs e)
        {
            nudUserElo.Enabled = !cbGameRanked.Checked;
        }

        private void combModeStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            marginStandard = CbToMargin(combModeStandard.SelectedIndex);
        }

        private void combModeTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            marginTime = CbToMargin(combModeTime.SelectedIndex);
        }

        private void nudFontSize_ValueChanged(object sender, EventArgs e)
        {
            fontSize = (int)nudFontSize.Value;
        }

        private void cbTourBMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CLimitValue modeValue = new CLimitValue();
            modeValue.SetLimit(tourBMode);
            modeValue.SetValue(tourBValue);
            modeValue.SetLimit((sender as System.Windows.Forms.ComboBox).Text);
            nudTourB.Increment = modeValue.GetIncrement();
            nudTourB.Minimum = nudTourB.Increment;
            nudTourB.Value = Math.Max(modeValue.GetValue(), nudTourB.Minimum);
            tourBMode = cbTourBMode.Text;
        }

        private void cbTourEMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            CLimitValue modeValue = new CLimitValue();
            nudTourEInc.Visible = cb.SelectedIndex == 2;
            modeValue.SetLimit(tourEMode);
            //modeValue.SetValue(tourEValue);
            modeValue.SetLimit(cb.Text);
            nudTourE.Increment = modeValue.GetIncrement();
            nudTourE.Minimum = nudTourE.Increment;
            nudTourE.Value = Math.Max(modeValue.GetValue(), nudTourE.Minimum);
            tourEMode = cbTourEMode.Text;
        }

        private void nudTourB_ValueChanged(object sender, EventArgs e)
        {
            tourBValue = (int)nudTourB.Value;
        }

        private void nudTourE_ValueChanged(object sender, EventArgs e)
        {
            //tourEValue = (int)nudTourE.Value;
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

        private void cbLink_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLink.Checked)
                CreateLink();
            else
                DeleteLink();
        }

        private void nudUserElo_ValueChanged(object sender, EventArgs e)
        {
            userElo = (int)nudUserElo.Value;
        }

        private void FormOptions_Shown(object sender, EventArgs e)
        {
            labTitle.BackColor = Colors.labelD;
            CModeTournamentB.tourList.SetLimit((int)nudTourBRec.Value);
            CModeTournamentE.tourList.SetLimit((int)nudTourERec.Value);
            CModeTournamentP.tourList.SetLimit((int)nudTourPRec.Value);
            labTourB.Text = $"Fill {(CModeTournamentB.tourList.Count * 100) / nudTourBRec.Value}%";
            labTourE.Text = $"Fill {(CModeTournamentE.tourList.Count * 100) / nudTourERec.Value}%";
            labTourP.Text = $"Fill {(CModeTournamentP.tourList.Count * 100) / nudTourPRec.Value}%";
        }

        private void cbMatchMode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CModeMatch.modeValue1.SetLimit(cbMatchMode1.Text);
            nudMatchValue1.Increment = CModeMatch.modeValue1.GetIncrement();
            nudMatchValue1.Minimum = nudMatchValue1.Increment;
            nudMatchValue1.Value = CModeMatch.modeValue1.GetValue();
        }

        private void cbMatchMode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CModeMatch.modeValue2.SetLimit(cbMatchMode2.Text);
            nudMatchValue2.Increment = CModeMatch.modeValue1.GetIncrement();
            nudMatchValue2.Minimum = nudMatchValue2.Increment;
            nudMatchValue2.Value = CModeMatch.modeValue1.GetValue();
        }

        private void cbCustomMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CModeGame.modeValue.SetLimit(cbCustomMode.Text);
            nudCustomValue.Increment = CModeGame.modeValue.GetIncrement();
            nudCustomValue.Minimum = nudCustomValue.Increment;
            nudCustomValue.Value = CModeGame.modeValue.GetValue();
        }

        private void cbEditLimitT_SelectedIndexChanged(object sender, EventArgs e)
        {
            CModeEdit.modeValue.SetLimit(cbEditLimitT.Text);
            nudEditLimitV.Increment = CModeEdit.modeValue.GetIncrement();
            nudEditLimitV.Minimum = nudEditLimitV.Increment;
            nudEditLimitV.Value = CModeEdit.modeValue.GetValue();
        }
    }
}
