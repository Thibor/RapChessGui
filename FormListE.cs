using System;
using System.IO;
using System.Windows.Forms;

namespace RapChessGui
{
    public partial class FormListE : Form
    {
        readonly FormFolderE formFolderE = new FormFolderE();

        int lastColumn = -1;

        public FormListE()
        {
            InitializeComponent();
        }

        private void lvEngines_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv = sender as ListView;
            lv.Columns[e.Column].Tag = lv.Columns[e.Column].Tag == null ? new Object() : null;
            bool des = (lv.Columns[e.Column].Tag != null);
            if ((lastColumn >= 0) && (lastColumn != e.Column))
                lv.Columns[lastColumn].Tag = null;
            (sender as ListView).ListViewItemSorter = new ListViewComparer(e.Column, des ? SortOrder.Descending : SortOrder.Ascending);
            lastColumn = e.Column;
            for (int n = 0; n < lv.Items.Count; n++)
                lv.Items[n].SubItems[0].Text = (n + 1).ToString();
        }

        int GetEloAccuracy(double v)
        {
            return Convert.ToInt32((v * CElo.eloMax) / 100);
        }

        public void FillEloOpt()
        {
            CTourList tourList = new CTourList("engines");
            foreach (CEngine ef in FormChess.engineList) {
                double sumElo = 0;
                double sumGames = 0;
                foreach (CEngine es in FormChess.engineList)
                    if (ef != es)
                    {
                        tourList.CountGames(ef.name, es.name, out int gw, out int gl, out int gd);
                        int games= gw + gl + gd;
                        sumGames += games;
                        sumElo += CElo.EloOpt(ef.Elo, es.Elo, gw, gl, gd) * games;
                    }
                ef.eloOpt = Convert.ToInt32(sumGames == 0 ? 0 : sumElo / sumGames);
            }
        }

        private void FormListE_Shown(object sender, EventArgs e)
        {
            FillEloOpt();
            lvEngines.Items.Clear();
            FormChess.engineList.SortElo();
            int index = 0;
            foreach (CEngine engine in FormChess.engineList)
            {
                string path = engine.GetPath();
                DateTime dt = File.GetLastWriteTime(path);
                int elo = engine.Elo;
                int size = engine.GetFileSize();
                int accuracy = GetEloAccuracy(engine.accuracy);
                int features = engine.Features();
                int sizeAccuracy = 0;
                if (accuracy > 0)
                    sizeAccuracy = size / accuracy;
                ListViewItem lvi = new ListViewItem(new[] { (++index).ToString(), engine.name, elo.ToString(), engine.eloOpt.ToString(),accuracy.ToString(), GetEloAccuracy(engine.test).ToString(), engine.Protocol, engine.depth.ToString("N2"), engine.nps.ToString("N0"), engine.eMove.Errors().ToString("N2"), engine.ePv.Errors().ToString("N2"), engine.eTime.Errors().ToString("N2"), dt.ToString("yyyy-MM-dd"), size.ToString("N0"),sizeAccuracy.ToString(),features.ToString() });
                lvEngines.Items.Add(lvi);
            }
        }

        private void foldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFolderE.ShowDialog(this);
        }

    }
}
