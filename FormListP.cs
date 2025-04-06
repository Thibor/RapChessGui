using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormListP : Form
	{
		public FormListP()
		{
			InitializeComponent();
		}

		private void FormListP_VisibleChanged(object sender, EventArgs e)
		{
			lvPlayers.Items.Clear();
			FormChess.playerList.SortElo();
			int index = 0;
			foreach (CPlayer player in FormChess.playerList)
			{
				ListViewItem lvi = new ListViewItem(new[] { (++index).ToString(), player.name, player.Elo.ToString(), player.history.Trend().ToString(), player.history.Change().ToString() });
				lvPlayers.Items.Add(lvi);
			}
		}

		private void lvPlayers_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			ListView lv = sender as ListView;
			lv.Tag = lv.Tag == null ? new Object() : null;
			(sender as ListView).ListViewItemSorter = new ListViewComparer(e.Column, lv.Tag == null ? SortOrder.Ascending : SortOrder.Descending);
			for (int n = 0; n < lv.Items.Count; n++)
				lv.Items[n].SubItems[0].Text = (n + 1).ToString();
		}
	}
}
