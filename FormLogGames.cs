using System.IO;
using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormLogGames : Form
	{

		public FormLogGames()
		{
			InitializeComponent();
		}

		public void UpdateLog()
		{
			FormOptions.SetFontSize(this);
			string name = FormChess.This.cbGameMode.Text;
			string path = $@"History/{name}.pgn";
			Text = $"Log {name}";
			if (File.Exists(path))
			{
				textBox.Text = File.ReadAllText(path);
				textBox.Select(0, 0);
			}
		}

		private void FormPgn_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void FormLogGames_VisibleChanged(object sender, System.EventArgs e)
		{
			if ((Visible == true) && (textBox.Text == string.Empty))
				UpdateLog();
		}
	}
}
