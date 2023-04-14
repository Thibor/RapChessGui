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
	public partial class FormFolderE : Form
	{
		public FormFolderE()
		{
			InitializeComponent();
		}

		private void FormFolderE_Shown(object sender, EventArgs e)
		{
			lvFolders.Items.Clear();
			foreach (string folder in CData.folderEngine)
			{
				int count = FormChess.engineList.CountFolder(folder);
				ListViewItem lvi = new ListViewItem(new[] {folder,count.ToString() });
				lvFolders.Items.Add(lvi);
			}
		}

		private void lvFolders_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			ListView lv = sender as ListView;
			lv.Tag = lv.Tag == null ? new Object() : null;
			(sender as ListView).ListViewItemSorter = new ListViewComparer(e.Column, lv.Tag == null ? SortOrder.Ascending : SortOrder.Descending);
		}
	}
}
