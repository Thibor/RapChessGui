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

        /*int EloOpt(CEngine e1, CEngine e2)
        {
            CModeTournamentE.tourList.CountGames(e1.name, e2.name, out int gw, out int gl, out _);
            return gw - gl;
        }

        bool EloOpt(int index)
        {
            CEngine e1 = FormChess.engineList[index];
            CEngine e2;
            int down = index;
            int up = index;
            for (int n = index + 1; n < FormChess.engineList.Count; n++)
            {
                e2 = FormChess.engineList[n];
                int r = EloOpt(e1, e2);
                if (r == 0)
                    continue;
                if (r < 0)
                    down = n;
                if (r > 0)
                    break;
            }
            for (int n = index - 1; n >= 0; n--)
            {
                e2 = FormChess.engineList[n];
                int r = EloOpt(e1, e2);
                if (r == 0)
                    continue;
                if (r > 0)
                    up = n;
                if (r < 0)
                    break;
            }
            if ((down == up) || ((down != index) && (up != index)))
                return false;
            e2 = down == index ? FormChess.engineList[up] : FormChess.engineList[down];
            (e1.eloOpt, e2.eloOpt) = (e2.eloOpt, e1.eloOpt);
            return true;
        }

        void UpdateEloOpt()
        {
            for (int n = 0; n < FormChess.engineList.Count; n++)
                EloOpt(n);
        }

        void FillEloOpt()
        {
            if (FormChess.engineList.Count == 0)
                return;
            FormChess.engineList.SortElo();
            int dis = (CElo.eloMax - CElo.eloMin) / (FormChess.engineList.Count);
            for (int n = 0; n < FormChess.engineList.Count; n++)
                FormChess.engineList[n].eloOpt = CElo.eloMin + (FormChess.engineList.Count - n) * dis;
            UpdateEloOpt();
        }*/

        string GetElo(double v)
        {
            return Convert.ToInt32((v * CElo.eloMax) / 100).ToString();
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
                ListViewItem lvi = new ListViewItem(new[] { (++index).ToString(), engine.name, engine.Elo.ToString(), engine.eloOpt.ToString(), GetElo(engine.accuracy), GetElo(engine.test), engine.Protocol, engine.depth.ToString("N2"), engine.nps.ToString("N0"), engine.eMove.Errors().ToString("N2"), engine.eTime.Errors().ToString("N2"), dt.ToString("yyyy-MM-dd"), engine.GetFileSize().ToString("N0") });
                lvEngines.Items.Add(lvi);
            }
        }

        private void foldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFolderE.ShowDialog(this);
        }

    }
}
