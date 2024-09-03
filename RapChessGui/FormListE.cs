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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Security.Cryptography;
using System.Management;

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

        private void FormListE_Shown(object sender, EventArgs e)
        {
            lvEngines.Items.Clear();
            FormChess.engineList.SortElo();
            int index = 0;
            foreach (CEngine engine in FormChess.engineList)
            {
                string protocol = CData.ProtocolToStr(engine.protocol);
                int eloOpt = engine.elo;
                int totalEngines = 0;
                int totalGames = 0;
                int totalW = 0;
                int totalL = 0;
                int totalD = 0;
                double totalElo = 0;
                foreach (CEngine engine2 in FormChess.engineList)
                {
                    int games = CModeTournamentE.tourList.CountGames(engine.name, engine2.name, out int gw, out int gl, out int gd);
                    if (games == 0)
                        continue;
                    totalEngines++;
                    totalGames += games;
                    totalW += gw * games;
                    totalL += gl * games;
                    totalD += gd * games;
                    totalElo += engine2.elo * games;
                }
                totalElo /= totalGames;
                if (totalGames > 0)
                    eloOpt = Convert.ToInt32(CElo.EloOpt(eloOpt, totalElo, totalW, totalL, totalD));
                int delta = eloOpt - engine.elo;
                ListViewItem lvi = new ListViewItem(new[] { (++index).ToString(), engine.name, engine.StrElo, engine.eloAcc.ToString(), eloOpt.ToString(), delta.ToString(), engine.Protocol, engine.hisElo.Trend().ToString(), engine.hisElo.Change().ToString(), engine.eMove.Errors().ToString("N2"), engine.eTime.Errors().ToString("N2") });
                lvEngines.Items.Add(lvi);
            }
        }

        private void foldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFolderE.ShowDialog(this);
        }

    }
}
