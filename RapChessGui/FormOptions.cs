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
		public static bool autoElo = true;
		public static bool isSan = true;
		public static bool rotateBoard = false;
		public static bool showArrow = true;
		public static bool showAttack = false;
		public static bool showPonder = true;
		public static bool showTips = true;
		public static volatile bool spamOff = true;
		public static bool soundOn = true;
		public static int animationSpeed = 200;
		public static int fontSize = 10;
		public static int gameBreak = 8;
		public static int historyLength = 100;
		public static int marginStandard = 0;
		public static int marginTime = 5000;
		public static int winLimit = 1;
		public static int tourBValue = 100;
		public static int tourEValue = 100;
		public static string gameBook = CBookList.def;
		public static string gameEngine = CEngineList.def;
		public static string tourBEngine = Global.none;
		public static string tourBMode = "Time";
		public static string tourBSelected = Global.none;
		public static string tourESelected = Global.none;
		public static string tourPSelected = Global.none;
		public static string tourEBookF = Global.none;
		public static string tourEBookS = Global.none;
		public static string tourEMode = "Time";
		public static ProcessPriorityClass priority = ProcessPriorityClass.Normal;
		public static Color color = Color.Yellow;

		public static CLevel TourELevel
		{
			get
			{
				return CLevelValue.StrToLevel(tourEMode);
			}
		}

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
			IPersistFile file = (IPersistFile)link;
			string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			file.Save(Path.Combine(desktopPath, "RapChessGui.lnk"), false);
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

		public void LoadFromIni(bool def = false)
		{
			gameBook = FormChess.ini.Read("options>mode>game>book", gameBook,def);
			gameEngine = FormChess.ini.Read("options>mode>game>engine", gameEngine,def);
			nudBreak.Value = FormChess.ini.ReadDecimal("options>mode>game>break",8,def);
			tourBSelected = FormChess.ini.Read("options>mode>tourB>selected", tourBSelected,def);
			tourBEngine = FormChess.ini.Read("options>mode>tourB>engine", tourBEngine,def);
			cbTourBMode.Text = FormChess.ini.Read("options>mode>tourB>mode", tourBMode,def);
			nudTourB.Value = FormChess.ini.ReadDecimal("options>mode>tourB>value", tourBValue,def);
			tourESelected = FormChess.ini.Read("options>mode>tourE>selected", tourESelected,def);
			tourEBookF = FormChess.ini.Read("options>mode>tourE>bookF", tourEBookF,def);
			tourEBookS = FormChess.ini.Read("options>mode>tourE>bookS", tourEBookS, def);
			cbTourEMode.Text = FormChess.ini.Read("options>mode>tourE>mode", tourEMode, def);
			nudTourE.Value = FormChess.ini.ReadDecimal("options>mode>tourE>value", tourEValue);
			tourPSelected = FormChess.ini.Read("options>mode>tourP>selected", tourPSelected,def);
			color = ColorTranslator.FromHtml(FormChess.ini.Read("options>interface>color", ColorTranslator.ToHtml(Color.Yellow), def));
			rbSan.Checked = FormChess.ini.ReadBool("options>interface>san", rbSan.Checked);
			cbShowPonder.Checked = FormChess.ini.ReadBool("options>interface>showponder", true,def);
			cbRotateBoard.Checked = FormChess.ini.ReadBool("options>interface>rotate", false,def);
			cbAttack.Checked = FormChess.ini.ReadBool("options>interface>attack", false,def);
			cbArrow.Checked = FormChess.ini.ReadBool("options>interface>arrow", true,def);
			cbTips.Checked = FormChess.ini.ReadBool("options>interface>tips", true,def);
			cbSound.Checked = FormChess.ini.ReadBool("options>interface>sound", true,def);
			cbSpam.Checked = FormChess.ini.ReadBool("options>interface>spam", true,def);
			nudTraining.Value = FormChess.ini.ReadDecimal("options>mode>training>strength", 1,def);
			nudHistory.Value = FormChess.ini.ReadDecimal("options>interface>history", 100,def);
			nudSpeed.Value = FormChess.ini.ReadDecimal("options>interface>speed", 200,def);
			nudFontSize.Value = FormChess.ini.ReadDecimal("options>interface>font", 10,def);
			cbGameRanked.Checked = FormChess.ini.ReadBool("options>game>ranked", true,def);
			combModeStandard.SelectedIndex = FormChess.ini.ReadInt("options>margin>standard", 1,def);
			combModeTime.SelectedIndex = FormChess.ini.ReadInt("options>margin>time", 0,def);
			combPriority.SelectedIndex = FormChess.ini.ReadInt("options>priority", 2,def);
			cbLink.Checked = IsLink();
			if (!rbSan.Checked)
				rbUci.Checked = true;
			Colors.SetColor();
		}

		public void SaveToIni()
		{
			FormChess.ini.Write("options>mode>game>book", gameBook);
			FormChess.ini.Write("options>mode>game>engine", gameEngine);
			FormChess.ini.Write("options>mode>game>break", nudBreak.Value);
			FormChess.ini.Write("options>mode>tourB>selected", tourBSelected);
			FormChess.ini.Write("options>mode>tourB>engine", tourBEngine);
			FormChess.ini.Write("options>mode>tourB>mode", cbTourBMode.Text);
			FormChess.ini.Write("options>mode>tourB>value", nudTourB.Value);
			FormChess.ini.Write("options>mode>tourE>selected", tourESelected);
			FormChess.ini.Write("options>mode>tourE>bookF", tourEBookF);
			FormChess.ini.Write("options>mode>tourE>bookS", tourEBookS);
			FormChess.ini.Write("options>mode>tourE>mode", cbTourEMode.Text);
			FormChess.ini.Write("options>mode>tourE>value", nudTourE.Value);
			FormChess.ini.Write("options>mode>tourP>selected", tourPSelected);
			FormChess.ini.Write("options>interface>color", ColorTranslator.ToHtml(color));
			FormChess.ini.Write("options>interface>san", rbSan.Checked);
			FormChess.ini.Write("options>interface>showponder", cbShowPonder.Checked);
			FormChess.ini.Write("options>interface>rotate", cbRotateBoard.Checked);
			FormChess.ini.Write("options>interface>attack", cbAttack.Checked);
			FormChess.ini.Write("options>interface>arrow", cbArrow.Checked);
			FormChess.ini.Write("options>interface>tips", cbTips.Checked);
			FormChess.ini.Write("options>interface>sound", cbSound.Checked);
			FormChess.ini.Write("options>interface>spam", cbSpam.Checked);
			FormChess.ini.Write("options>mode>training>strength", nudTraining.Value);
			FormChess.ini.Write("options>interface>history", nudHistory.Value);
			FormChess.ini.Write("options>interface>speed", nudSpeed.Value);
			FormChess.ini.Write("options>interface>font", nudFontSize.Value);
			FormChess.ini.Write("options>game>ranked", cbGameRanked.Checked);
			FormChess.ini.Write("options>margin>standard", combModeStandard.SelectedIndex);
			FormChess.ini.Write("options>margin>time", combModeTime.SelectedIndex);
			FormChess.ini.Write("options>priority", combPriority.SelectedIndex);
		}

		public void FormLoad()
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
			cbGameBook.Items.Clear();
			cbTourBSelected.Items.Clear();
			cbTourEBookF.Items.Clear();
			cbTourEBookS.Items.Clear();
			cbGameBook.Sorted = true;
			cbTourBSelected.Sorted = true;
			cbTourEBookF.Sorted = true;
			cbTourEBookS.Sorted = true;
			foreach (CBook b in FormChess.bookList)
			{
				cbGameBook.Items.Add(b.name);
				cbTourBSelected.Items.Add(b.name);
				cbTourEBookF.Items.Add(b.name);
				cbTourEBookS.Items.Add(b.name);
			}
			cbGameBook.Sorted = false;
			cbTourBSelected.Sorted = false;
			cbTourEBookF.Sorted = false;
			cbTourEBookS.Sorted = false;
			cbGameBook.Items.Insert(0, Global.none);
			cbTourBSelected.Items.Insert(0, Global.none);
			cbTourEBookF.Items.Insert(0,Global.none);
			cbTourEBookS.Items.Insert(0, Global.none);

			cbGameEngine.Items.Clear();
			cbTourBEngine.Items.Clear();
			cbTourESelected.Items.Clear();
			cbGameEngine.Sorted = true;
			cbTourBEngine.Sorted = true;
			cbTourESelected.Sorted = true;
			foreach (CEngine e in FormChess.engineList)
			{
				cbTourBEngine.Items.Add(e.name);
				cbTourESelected.Items.Add(e.name);
				if (e.modeElo)
					cbGameEngine.Items.Add(e.name);
			}
			cbGameEngine.Sorted = false;
			cbTourBEngine.Sorted = false;
			cbTourESelected.Sorted = false;
			cbGameEngine.Items.Insert(0, Global.none);
			cbTourBEngine.Items.Insert(0, Global.none);
			cbTourESelected.Items.Insert(0, Global.none);

			cbTourPSelected.Items.Clear();
			cbTourPSelected.Sorted = true;
			foreach (CPlayer p in FormChess.playerList)
				cbTourPSelected.Items.Add(p.name);
			cbTourPSelected.Sorted = false;
			cbTourPSelected.Items.Insert(0, Global.none);
			cbTourPSelected.SelectedIndex = 0;

			LoadFromIni();

			CData.ComboSelect(cbGameEngine, gameEngine);
			CData.ComboSelect(cbGameBook, gameBook);
			CData.ComboSelect(cbTourBSelected, tourBSelected);
			CData.ComboSelect(cbTourESelected, tourESelected);
			CData.ComboSelect(cbTourBEngine, tourBEngine);
			CData.ComboSelect(cbTourEBookF, tourEBookF);
			CData.ComboSelect(cbTourEBookS, tourEBookS);
			CData.ComboSelect(cbTourPSelected, tourPSelected);
			nudTourBRec.Value = CModeTournamentB.records;
			nudTourBAvg.Value = CModeTournamentB.eloAvg;
			nudTourBRange.Value = CModeTournamentB.eloRange;
			nudTourERec.Value = CModeTournamentE.records;
			nudTourEAvg.Value = CModeTournamentE.eloAvg;
			nudTourERange.Value = CModeTournamentE.eloRange;
			nudTourPRec.Value = CModeTournamentP.records;
			nudTourPAvg.Value = CModeTournamentP.eloAvg;
			nudTourPRange.Value = CModeTournamentP.eloRange;
			labTourB.Text = $"Fill {(CModeTournamentB.tourList.Count * 100) / CModeTournamentB.records}%";
			labTourE.Text = $"Fill {(CModeTournamentE.tourList.Count * 100) / CModeTournamentE.records}%";
			labTourP.Text = $"Fill {(CModeTournamentP.tourList.Count * 100) / CModeTournamentP.records}%";
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
			CModeTournamentB.records = (int)nudTourBRec.Value;
			CModeTournamentB.eloAvg = (int)nudTourBAvg.Value;
			CModeTournamentB.eloRange = (int)nudTourBRange.Value;
			CModeTournamentE.records = (int)nudTourERec.Value;
			CModeTournamentE.eloAvg = (int)nudTourEAvg.Value;
			CModeTournamentE.eloRange = (int)nudTourERange.Value;
			CModeTournamentP.records = (int)nudTourPRec.Value;
			CModeTournamentP.eloAvg = (int)nudTourPAvg.Value;
			CModeTournamentP.eloRange = (int)nudTourPRange.Value;
			CModeTournamentB.SaveToIni();
			CModeTournamentE.SaveToIni();
			CModeTournamentP.SaveToIni();
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

		private void CbRotateBoard_CheckedChanged(object sender, EventArgs e)
		{
			rotateBoard = cbRotateBoard.Checked;
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
		}

		private void cbBookReader_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvBooks.SelectedItems.Count > 0)
			{
				lvBooks.SelectedItems[0].SubItems[1].Text = cbBookReader.Text;
				CData.reset = true;
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

		private void rbSan_CheckedChanged(object sender, EventArgs e)
		{
			isSan = rbSan.Checked;
		}

		private void cbShowPonder_CheckedChanged(object sender, EventArgs e)
		{
			showPonder = cbShowPonder.Checked;
		}

		private void cbSpam_CheckedChanged(object sender, EventArgs e)
		{
			spamOff = cbSpam.Checked;
		}

		private void cbArrow_CheckedChanged(object sender, EventArgs e)
		{
			showArrow = cbArrow.Checked;
		}

		private void cbSound_CheckedChanged(object sender, EventArgs e)
		{
			soundOn = cbSound.Checked;
		}

		private void cbAttack_CheckedChanged(object sender, EventArgs e)
		{
			showAttack = cbAttack.Checked;
		}

		private void cbTips_CheckedChanged(object sender, EventArgs e)
		{
			showTips = cbTips.Checked;
		}

		private void nudSpeed_ValueChanged(object sender, EventArgs e)
		{
			animationSpeed = (int)nudSpeed.Value;
		}

		private void nudHistory_ValueChanged(object sender, EventArgs e)
		{
			historyLength = (int)nudHistory.Value;
		}

		private void cbGameAutoElo_CheckedChanged(object sender, EventArgs e)
		{
			autoElo = cbGameRanked.Checked;
		}

		private void nudMatch_ValueChanged(object sender, EventArgs e)
		{
			gameBreak = (int)nudBreak.Value;
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

		private void cbTourESelected_SelectedIndexChanged(object sender, EventArgs e)
		{
			tourESelected = cbTourESelected.Text;
		}

		private void cbTourBSelected_SelectedIndexChanged(object sender, EventArgs e)
		{
			tourBSelected = cbTourBSelected.Text;
		}

		private void cbTourPSelected_SelectedIndexChanged(object sender, EventArgs e)
		{
			tourPSelected = cbTourPSelected.Text;
		}

		private void cbTourEBook_SelectedIndexChanged(object sender, EventArgs e)
		{
			tourEBookF = cbTourEBookF.Text;
		}

		private void cbTourEMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CLevelValue modeValue = new CLevelValue();
			modeValue.SetLevel(tourEMode);
			modeValue.SetValue(tourEValue);
			modeValue.SetLevel((sender as ComboBox).Text);
			nudTourE.Increment = modeValue.GetValueIncrement();
			nudTourE.Minimum = nudTourE.Increment;
			nudTourE.Value = Math.Max(modeValue.GetValue(), nudTourE.Minimum);
			tourEMode = cbTourEMode.Text;
		}

		private void nudTourE_ValueChanged(object sender, EventArgs e)
		{
			tourEValue = (int)nudTourE.Value;
		}

		private void cbTourBMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeTournamentB.modeValue.SetLevel((sender as ComboBox).Text);
			nudTourB.Increment = CModeTournamentB.modeValue.GetValueIncrement();
			nudTourB.Minimum = nudTourB.Increment;
			nudTourB.Value = Math.Max(CModeTournamentB.modeValue.GetValue(), nudTourB.Minimum);
			tourBMode = cbTourBMode.Text;
		}

		private void cbTourBEngine_SelectedIndexChanged(object sender, EventArgs e)
		{
			tourBEngine = cbTourBEngine.Text;
		}

		private void nudTourB_ValueChanged(object sender, EventArgs e)
		{
			tourBValue = (int)nudTourB.Value;
		}

		private void cbGameBook_SelectedIndexChanged(object sender, EventArgs e)
		{
			gameBook = cbGameBook.Text;
		}

		private void cbGameEngine_SelectedIndexChanged(object sender, EventArgs e)
		{
			gameEngine = cbGameEngine.Text;
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

		private void cbTourEBookS_SelectedIndexChanged(object sender, EventArgs e)
		{
			tourEBookS = cbTourEBookS.Text;
		}

	}
}
