using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RapChessGui
{
	public partial class FormChartB : Form
	{
		Series lastSeries = null;

		public FormChartB()
		{
			InitializeComponent();
		}

		public void UpdateChart()
		{
			if (Visible == true)
			{
				chart1.Series.Clear();
				CModeTournamentB.bookList.SortElo();
				foreach (CBook book in CModeTournamentB.bookList)
				{
					string bn = book.name;
					chart1.Series.Add(bn);
					chart1.Series[bn].ChartType = SeriesChartType.Line;
					chart1.Series[bn].BorderWidth = 2;
					FormChess.HisToPoints(book.history, chart1.Series[bn].Points);
				}
			}
		}

		private void FormHisB_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void FormHisB_VisibleChanged(object sender, EventArgs e)
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
