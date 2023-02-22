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
	public partial class FormListB : Form
	{
		public FormListB()
		{
			InitializeComponent();
		}

		private void FormListB_VisibleChanged(object sender, EventArgs e)
		{
			lvBooks.Items.Clear();
			FormChess.bookList.SortElo();
			int index = 0;
			foreach (CBook book in FormChess.bookList)
			{
				ListViewItem lvi = new ListViewItem(new[] { (++index).ToString(), book.name, book.Elo, book.hisElo.Trend().ToString(), book.hisElo.Change().ToString() });
				lvBooks.Items.Add(lvi);
			}
		}

		private void lvBooks_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			ListView lv = sender as ListView;
			lv.Tag = lv.Tag == null ? new Object() : null;
			(sender as ListView).ListViewItemSorter = new ListViewComparer(e.Column, lv.Tag == null ? SortOrder.Ascending : SortOrder.Descending);
			for (int n = 0; n < lv.Items.Count; n++)
				lv.Items[n].SubItems[0].Text = (n + 1).ToString();
		}
	}
}
