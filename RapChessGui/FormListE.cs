using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace RapChessGui
{
	public partial class FormListE : Form
	{
		readonly FormFolderE formFolderE = new FormFolderE();

		public FormListE()
		{
			InitializeComponent();
		}

		private void lvEngines_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			ListView lv = sender as ListView;
			lv.Tag = lv.Tag == null ? new Object() : null;
			(sender as ListView).ListViewItemSorter = new ListViewComparer(e.Column, lv.Tag == null ? SortOrder.Ascending : SortOrder.Descending);
			for (int n = 0; n < lv.Items.Count; n++)
				lv.Items[n].SubItems[0].Text = (n + 1).ToString();
		}

		private void FormListE_Shown(object sender, EventArgs e)
		{
			lvEngines.Items.Clear();
			FormChess.engineList.SortElo();
			int index = 0;
			foreach (CEngine engine in FormChess.engineList)
			{
				string protocol = CData.ProtocolToStr(engine.protocol);
				ListViewItem lvi = new ListViewItem(new[] { (++index).ToString(), engine.name, engine.Protocol,engine.StrElo, engine.hisElo.Trend().ToString(), engine.hisElo.Change().ToString(), engine.eMove.Errors().ToString("N2"), engine.eTime.Errors().ToString("N2") });
				lvEngines.Items.Add(lvi);
			}
		}

		private void foldersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			formFolderE.ShowDialog(this);
		}

	}
}
