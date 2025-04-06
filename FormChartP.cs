using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RapChessGui
{
	public partial class FormChartP : Form
	{
		Series lastSeries = null;

		public FormChartP()
		{
			InitializeComponent();
		}

		public void UpdateChart()
		{
			if (Visible == true)
			{
				chart1.Series.Clear();
				CModeTournamentP.playerList.SortElo();
				foreach (CPlayer player in CModeTournamentP.playerList)
				{
					string pn = player.name;
					chart1.Series.Add(pn);
					chart1.Series[pn].ChartType = SeriesChartType.Line;
					chart1.Series[pn].BorderWidth = 2;
					FormChess.HisToPoints(player.history, chart1.Series[pn].Points);
				}
			}
		}

		private void FormHisP_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void FormHisP_VisibleChanged(object sender, EventArgs e)
		{
			UpdateChart();
		}

		private void chart1_MouseDown(object sender, MouseEventArgs e)
		{
			if (lastSeries != null)
			{
				lastSeries.BorderWidth = 2;
				lastSeries = null;
			}
			Chart plot = sender as Chart;
			HitTestResult result = plot.HitTest(e.X, e.Y);
			if (result != null && result.Object != null && result.ChartElementType == ChartElementType.LegendItem)
			{
				string name = result.Series.Name;
				lastSeries = plot.Series[name];
				lastSeries.BorderWidth = 4;
			}
		}
	}
}
