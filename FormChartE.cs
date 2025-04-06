using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RapChessGui
{
	public partial class FormChartE : Form
	{
		Series lastSeries = null;

		public FormChartE()
		{
			InitializeComponent();
		}

		public void UpdateChart()
		{
			if (Visible == true)
			{
				chart1.Series.Clear();
				CModeTournamentE.engineList.SortElo();
				foreach (CEngine engine in CModeTournamentE.engineList)
				{
					string en = engine.name;
					chart1.Series.Add(en);
					chart1.Series[en].ChartType = SeriesChartType.Line;
					chart1.Series[en].BorderWidth = 2;
					FormChess.HisToPoints(engine.history, chart1.Series[en].Points);
				}
			}
		}

		private void FormHisE_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void FormHisE_VisibleChanged(object sender, EventArgs e)
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
