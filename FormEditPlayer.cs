using System;
using System.Drawing;
using System.Windows.Forms;
using RapIni;

namespace RapChessGui
{
	public partial class FormEditPlayer : Form
	{
		int indexFirst = -1;
		int tournament = -1;
		CPlayer player = null;
		public static string playerName = String.Empty;
		readonly CLimitValue modeValue = new CLimitValue();

		public FormEditPlayer()
		{
			InitializeComponent();
			FormOptions.SetFontSize(this);
		}

		void ClickSave()
		{
			modeValue.SetLimit(combMode.Text);
			modeValue.SetValue((int)nudValue.Value);
			if (player == null)
				return;
			CListPlayer.iniFile.DeleteKey($"player>{player.name}");
			SaveToIni(player);
			MessageBox.Show($"Player {player.name} has been modified");
		}

		void SelectPlayer(string name)
		{
			player = FormChess.playerList.GetPlayerByName(name);
			playerName = String.Empty;
			if (player == null)
				return;
			SelectPlayer(player);
		}

		void SelectPlayer(CPlayer p)
		{
			player = p;
			playerName = p.name;
			SelectPlayer();
		}

		void SelectPlayer()
		{
			tbPlayerName.Text = player.name;
			cbEngineList.Text = player.EngineName;
			cbBookList.Text = player.BookName;
			nudTournament.Value = player.tournament;
			nudElo.Value = player.Elo;
			nudValue.Value = player.levelValue.GetValue();
			modeValue.kind = player.levelValue.kind;
			modeValue.baseVal = player.levelValue.baseVal;
			combMode.SelectedIndex = combMode.FindStringExact(modeValue.GetLimit());
		}

		void SelectPlayers(int first, int last, bool t)
		{
			int f = first < last ? first : last;
			int l = first < last ? last : first;
			bool r = false;
			for (int n = f; n <= l; n++)
			{
				var item = listBoxPlayers.Items[n];
				string name = item.ToString();
				CPlayer pla = FormChess.playerList.GetPlayerByName(name);
				if (pla.SetTournament(t))
					r = true;
			}
			if (r)
			{
				listBoxPlayers.Refresh();
				SelectPlayer();
			}
		}

		void UpdateListBox()
		{
			listBoxPlayers.Items.Clear();
			foreach (CPlayer u in FormChess.playerList)
				listBoxPlayers.Items.Add(u.name);
			gbPlayers.Text = $"Players {listBoxPlayers.Items.Count}";
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectPlayer(listBoxPlayers.SelectedItem.ToString());
		}

		void UpdatePlayer(CPlayer p)
		{
			p.name = tbPlayerName.Text;
			p.EngineName = cbEngineList.Text;
			p.BookName = cbBookList.Text;
			p.SetTournament((int)nudTournament.Value);
			p.Elo = (int)nudElo.Value;
			p.levelValue.kind = modeValue.kind;
			p.levelValue.baseVal = modeValue.baseVal;
		}

		void SaveToIni(CPlayer p)
		{
			UpdatePlayer(p);
			p.SaveToIni();
			UpdateListBox();
			int index = listBoxPlayers.FindString(p.name);
			if (index == -1) return;
			listBoxPlayers.SetSelected(index, true);
		}

		private void ButUpdate_Click(object sender, EventArgs e)
		{
			ClickSave();
		}

		private void ButCreate_Click(object sender, EventArgs e)
		{
			string name = tbPlayerName.Text;
			if (FormChess.playerList.GetPlayerByName(name) != null)
			{
				MessageBox.Show("This name already exists");
				return;
			}
			modeValue.SetLimit(combMode.Text);
			modeValue.SetValue((int)nudValue.Value);
			CPlayer player = new CPlayer(name);
			FormChess.playerList.Add(player);
			SaveToIni(player);
			MessageBox.Show($"Player {player.name} has been created");
		}

		private void ButDelete_Click(object sender, EventArgs e)
		{
			string name = tbPlayerName.Text;
			DialogResult dr = MessageBox.Show($"Are you sure to delete player {name}?", "Confirm Delete", MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				FormChess.playerList.DeletePlayer(name);
				UpdateListBox();
			}
		}

		private void FormPlayer_Shown(object sender, EventArgs e)
		{
			cbEngineList.Items.Clear();
			cbEngineList.Sorted = true;
			foreach (CEngine engine in FormChess.engineList)
				cbEngineList.Items.Add(engine.name);
			cbEngineList.Sorted = false;
			cbEngineList.Items.Insert(0, Global.none);
			cbEngineList.SelectedIndex = 0;
			cbBookList.Items.Clear();
			cbBookList.Sorted = true;
			foreach (CBook book in FormChess.bookList)
				cbBookList.Items.Add(book.name);
			cbBookList.Sorted = false;
			cbBookList.Items.Insert(0, Global.none);
			cbBookList.SelectedIndex = 0;
			UpdateListBox();
			listBoxPlayers.SelectedIndex = listBoxPlayers.FindString(playerName);
			if ((listBoxPlayers.SelectedIndex < 0) && (listBoxPlayers.Items.Count > 0))
				listBoxPlayers.SelectedIndex = 0;
		}

		private void combMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			modeValue.SetLimit(combMode.Text);
			nudValue.Increment = modeValue.GetIncrement();
			nudValue.Value = modeValue.GetValue();
			toolTip1.SetToolTip(nudValue, modeValue.GetTip());
		}

		private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
				return;
			string name = listBoxPlayers.Items[e.Index].ToString();
			CPlayer pla = FormChess.playerList.GetPlayerByName(name);
			bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
			Brush b = Brushes.Black;
			if (selected)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, Colors.message, Colors.chartD);
				b = Brushes.White;
			}
			else if (pla.EngineName == Global.none)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.Black, Color.FromArgb(0xff, 0xc0, 0xc0));
			}
			else if (pla.tournament > 0)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.Black, Colors.message);
			}
			e.DrawBackground();
			e.Graphics.DrawString(name, e.Font, b, e.Bounds, StringFormat.GenericDefault);
			e.DrawFocusRectangle();
		}

		private void listBox1_MouseUp(object sender, MouseEventArgs e)
		{
			tournament = -1;
			listBoxPlayers.Capture = false;
		}

		private void listBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				indexFirst = -1;
				tournament = -1;
				listBoxPlayers.Capture = true;
				int index = listBoxPlayers.IndexFromPoint(e.Location);
				if ((index >= 0) && (index < listBoxPlayers.Items.Count))
				{
					var item = listBoxPlayers.Items[index];
					string name = item.ToString();
					CPlayer pla = FormChess.playerList.GetPlayerByName(name);
					indexFirst = index;
					tournament = pla.tournament > 0 ? 0 : 1;
					if (pla.SetTournament(tournament == 1))
					{
						listBoxPlayers.Refresh();
						if (player == pla)
							SelectPlayer();
					}

				}
			}
		}

		private void listBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				int index = listBoxPlayers.IndexFromPoint(e.Location);
				if ((index >= 0) && (index < listBoxPlayers.Items.Count) && (tournament >= 0))
					SelectPlayers(indexFirst, index, tournament > 0);
			}
		}

		private void ButRename_Click(object sender, EventArgs e)
		{
			CPlayer p = new CPlayer();
			UpdatePlayer(p);
			string name = p.CreateName();
			if(name != p.name)
				name = FormChess.playerList.GetName(name);
			tbPlayerName.Text = name;
			ClickSave();
		}

		private void FormEditPlayer_FormClosing(object sender, FormClosingEventArgs e)
		{
			CListPlayer.iniFile.Save();
		}

		private void clearTournamentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (player != null)
			{
				player.history.Clear();
				player.SaveToIni();
				int count = CModeTournamentP.tourList.DeletePlayer(player.name);
				MessageBox.Show($"{count} records have been deleted");
			}
		}

		private void allToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int n = 0; n < FormChess.playerList.Count; n++)
				if (FormChess.playerList[n].tournament == 0)
					FormChess.playerList[n].tournament = 1;
			FormChess.playerList.SaveToIni();
			listBoxPlayers.Refresh();
		}

		private void noneToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int n = 0; n < FormChess.playerList.Count; n++)
					FormChess.playerList[n].tournament = 0;
			FormChess.playerList.SaveToIni();
			listBoxPlayers.Refresh();
		}
	}
}
