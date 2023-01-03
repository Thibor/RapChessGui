using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormOptions : Form
	{
		public static bool autoElo = true;
		public static bool isSan = true;
		public static bool showArrow = true;
		public static bool showAttack = false;
		public static bool showPonder = true;
		public static bool showTips = true;
		public static bool spamOff = true;
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
		public static string gameBook = Global.none;
		public static string tourBEngine = Global.none;
		public static string tourBMode = "Time";
		public static string tourBSelected = Global.none;
		public static string tourESelected = Global.none;
		public static string tourPSelected = Global.none;
		public static string tourEBook = Global.none;
		public static string tourEMode = "Time";
		public static int page = 0;
		public static ProcessPriorityClass priority = ProcessPriorityClass.Normal;
		public static Color colorBoard;

		public FormOptions()
		{
			InitializeComponent();
			LoadFromIni();
			listBox1.SelectedIndex = 0;
		}

		public void LoadFromIni()
		{
			string color = ColorTranslator.ToHtml(Color.Yellow);
			gameBook = FormChess.iniFile.Read("options>mode>game>book", tourEBook);
			nudBreak.Value = FormChess.iniFile.ReadDecimal("options>mode>game>break", nudBreak.Value);
			tourBSelected = FormChess.iniFile.Read("options>mode>tourB>selected", tourBSelected);
			tourBEngine = FormChess.iniFile.Read("options>mode>tourB>engine", tourBEngine);
			cbTourBMode.Text = FormChess.iniFile.Read("options>mode>tourB>mode", tourBMode);
			nudTourB.Value = FormChess.iniFile.ReadDecimal("options>mode>tourB>value", tourBValue);
			tourESelected = FormChess.iniFile.Read("options>mode>tourE>selected", tourESelected);
			tourEBook = FormChess.iniFile.Read("options>mode>tourE>book", tourEBook);
			nudTourE.Value = FormChess.iniFile.ReadDecimal("options>mode>tourE>value", tourEValue);
			cbTourEMode.Text = FormChess.iniFile.Read("options>mode>tourE>mode", tourEMode);
			tourPSelected = FormChess.iniFile.Read("options>mode>tourP>selected", tourPSelected);
			color = FormChess.iniFile.Read("options>interface>color",color);
			rbSan.Checked = FormChess.iniFile.ReadBool("options>interface>san", rbSan.Checked);
			cbShowPonder.Checked = FormChess.iniFile.ReadBool("options>interface>showponder", cbShowPonder.Checked);
			cbRotateBoard.Checked = FormChess.iniFile.ReadBool("options>interface>rotate", cbRotateBoard.Checked);
			cbAttack.Checked = FormChess.iniFile.ReadBool("options>interface>attack", cbAttack.Checked);
			cbArrow.Checked = FormChess.iniFile.ReadBool("options>interface>arrow", cbArrow.Checked);
			cbTips.Checked = FormChess.iniFile.ReadBool("options>interface>tips", cbTips.Checked);
			cbSound.Checked = FormChess.iniFile.ReadBool("options>interface>sound", cbSound.Checked);
			cbSpam.Checked = FormChess.iniFile.ReadBool("options>interface>spam", cbSpam.Checked);
			nudTraining.Value = FormChess.iniFile.ReadDecimal("options>mode>training>strength", nudTraining.Value);
			nudHistory.Value = FormChess.iniFile.ReadDecimal("options>interface>history", nudHistory.Value);
			nudSpeed.Value = FormChess.iniFile.ReadDecimal("options>interface>speed", nudSpeed.Value);
			nudFontSize.Value = FormChess.iniFile.ReadDecimal("options>interface>font", nudFontSize.Value);
			cbGameAutoElo.Checked = FormChess.iniFile.ReadBool("options>game>autoelo", cbGameAutoElo.Checked);
			combModeStandard.SelectedIndex = FormChess.iniFile.ReadInt("options>margin>standard", 1);
			combModeTime.SelectedIndex = FormChess.iniFile.ReadInt("options>margin>time", 0);
			combPriority.SelectedIndex = FormChess.iniFile.ReadInt("options>priority", 2);
			colorDialog1.Color = ColorTranslator.FromHtml(color);
			colorBoard = colorDialog1.Color;
			if (!rbSan.Checked)
				rbUci.Checked = true;
		}

		public void SaveToIni()
		{
			string color = ColorTranslator.ToHtml(colorDialog1.Color);
			FormChess.iniFile.Write("options>mode>game>book", gameBook);
			FormChess.iniFile.Write("options>mode>game>break", nudBreak.Value);
			FormChess.iniFile.Write("options>mode>tourB>selected", tourBSelected);
			FormChess.iniFile.Write("options>mode>tourB>engine", tourBEngine);
			FormChess.iniFile.Write("options>mode>tourB>mode", cbTourBMode.Text);
			FormChess.iniFile.Write("options>mode>tourB>value", nudTourB.Value);
			FormChess.iniFile.Write("options>mode>tourE>selected", tourESelected);
			FormChess.iniFile.Write("options>mode>tourE>book", tourEBook);
			FormChess.iniFile.Write("options>mode>tourE>value", nudTourE.Value);
			FormChess.iniFile.Write("options>mode>tourE>mode", cbTourEMode.Text);
			FormChess.iniFile.Write("options>mode>tourP>selected", tourPSelected);
			FormChess.iniFile.Write("options>interface>color", color);
			FormChess.iniFile.Write("options>interface>san", rbSan.Checked);
			FormChess.iniFile.Write("options>interface>showponder", cbShowPonder.Checked);
			FormChess.iniFile.Write("options>interface>rotate", cbRotateBoard.Checked);
			FormChess.iniFile.Write("options>interface>attack", cbAttack.Checked);
			FormChess.iniFile.Write("options>interface>arrow", cbArrow.Checked);
			FormChess.iniFile.Write("options>interface>tips", cbTips.Checked);
			FormChess.iniFile.Write("options>interface>sound", cbSound.Checked);
			FormChess.iniFile.Write("options>interface>spam", cbSpam.Checked);
			FormChess.iniFile.Write("options>mode>training>strength", nudTraining.Value);
			FormChess.iniFile.Write("options>interface>history", nudHistory.Value);
			FormChess.iniFile.Write("options>interface>speed", nudSpeed.Value);
			FormChess.iniFile.Write("options>interface>font", nudFontSize.Value);
			FormChess.iniFile.Write("options>game>autoelo", cbGameAutoElo.Checked);
			FormChess.iniFile.Write("options>margin>standard", combModeStandard.SelectedIndex);
			FormChess.iniFile.Write("options>margin>time", combModeTime.SelectedIndex);
			FormChess.iniFile.Write("options>priority", combPriority.SelectedIndex);
		}

		void FormLoad()
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
			cbTourEBook.Items.Clear();
			cbGameBook.Sorted = true;
			cbTourBSelected.Sorted = true;
			cbTourEBook.Sorted = true;
			foreach (CBook b in FormChess.bookList)
			{
				cbGameBook.Items.Add(b.name);
				cbTourBSelected.Items.Add(b.name);
				cbTourEBook.Items.Add(b.name);
			}
			cbGameBook.Sorted = false;
			cbTourBSelected.Sorted = false;
			cbTourEBook.Sorted = false;
			cbGameBook.Items.Insert(0, Global.none);
			cbTourBSelected.Items.Insert(0, Global.none);
			cbTourEBook.Items.Insert(0,Global.none);
			cbGameBook.SelectedIndex = 0;
			cbTourBSelected.SelectedIndex = 0;
			cbTourEBook.SelectedIndex = 0;

			cbTourBEngine.Items.Clear();
			cbTourESelected.Items.Clear();
			cbTourBEngine.Sorted = true;
			cbTourESelected.Sorted = true;
			foreach (CEngine e in FormChess.engineList)
			{
				cbTourBEngine.Items.Add(e.name);
				cbTourESelected.Items.Add(e.name);
			}
			cbTourBEngine.Sorted = false;
			cbTourESelected.Sorted = false;
			cbTourBEngine.Items.Insert(0, Global.none);
			cbTourESelected.Items.Insert(0, Global.none);
			cbTourBEngine.SelectedIndex = 0;
			cbTourESelected.SelectedIndex = 0;

			cbTourPSelected.Items.Clear();
			cbTourPSelected.Sorted = true;
			foreach (CPlayer p in FormChess.playerList)
				cbTourPSelected.Items.Add(p.name);
			cbTourPSelected.Sorted = false;
			cbTourPSelected.Items.Insert(0, Global.none);
			cbTourPSelected.SelectedIndex = 0;

			LoadFromIni();

			CData.ComboSelect(cbGameBook, gameBook);
			CData.ComboSelect(cbTourBSelected, tourBSelected);
			CData.ComboSelect(cbTourESelected, tourESelected);
			CData.ComboSelect(cbTourBEngine, tourBEngine);
			CData.ComboSelect(cbTourEBook, tourEBook);
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
			labTourB.Text = $"Fill {(CModeTournamentB.tourList.list.Count * 100) / CModeTournamentB.records}%";
			labTourE.Text = $"Fill {(CModeTournamentE.tourList.list.Count * 100) / CModeTournamentE.records}%";
			labTourP.Text = $"Fill {(CModeTournamentP.tourList.list.Count * 100) / CModeTournamentP.records}%";
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
			CData.rotateBoard = cbRotateBoard.Checked;
		}

		private void butColor_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = colorBoard;
			if (colorDialog1.ShowDialog() != DialogResult.Cancel)
			{
				colorBoard = colorDialog1.Color;
				(Owner as FormChess).BoardPrepare();
			}
		}

		private void butDefault_Click(object sender, EventArgs e)
		{
			cbShowPonder.Checked = true;
			cbAttack.Checked = false;
			cbArrow.Checked = true;
			cbTips.Checked = true;
			cbGameAutoElo.Checked = true;
			cbRotateBoard.Checked = false;
			rbSan.Checked = true;
			combModeStandard.SelectedIndex = 1;
			combModeTime.SelectedIndex = 0;
			combPriority.SelectedIndex = 2;
			nudTourERec.Value = 10000;
			nudTourPRec.Value = 10000;
			nudSpeed.Value = 200;
			nudTourEAvg.Value = 3000;
			nudTourERange.Value = 0;
			nudTourPAvg.Value = 3000;
			nudTourPRange.Value = 0;
			nudHistory.Value = 100;
			colorDialog1.Color = Color.Yellow;
			colorBoard = colorDialog1.Color;
			(Owner as FormChess).BoardPrepare();
		}

		private void FormOptions_Shown(object sender, EventArgs e)
		{
			FormLoad();
			listBox1.SelectedIndex = page;
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
			tabControl1.SelectedIndex = listBox1.SelectedIndex;
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
			autoElo = cbGameAutoElo.Checked;
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
			tourEBook = cbTourEBook.Text;
		}

		private void cbTourEMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeTournamentE.modeValue.SetLevel((sender as ComboBox).Text);
			nudTourE.Increment = CModeTournamentE.modeValue.GetValueIncrement();
			nudTourE.Minimum = nudTourE.Increment;
			nudTourE.Value = Math.Max(CModeTournamentE.modeValue.GetValue(), nudTourE.Minimum);
			tourEMode = cbTourEMode.Text;
		}

		private void nudTourE_ValueChanged(object sender, EventArgs e)
		{
			tourEValue = (int)nudTourE.Value;
		}

		private void cbGameBook_SelectedIndexChanged(object sender, EventArgs e)
		{
			gameBook = cbGameBook.Text;
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
	}
}
