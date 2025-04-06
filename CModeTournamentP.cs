using System;

namespace RapChessGui
{
	public class CModeTournamentP:CModeTournament
	{
		public static CTourList tourList = new CTourList("players");
		public static CListPlayer playerList = new CListPlayer();
		public static CPlayer plaWin = null;
		public static CPlayer plaLoose = null;

		public static CPlayer ChooseOpponent(CPlayer player, CPlayer player1, CPlayer player2)
		{
			tourList.CountGames(player.name, player1.name, out int rw1, out int rl1, out int rd1);
			tourList.CountGames(player.name, player2.name, out int rw2, out int rl2, out int rd2);
			if ((player.Elo > player1.Elo) != (rw1 > rl1))
				return player1;
			if ((player.Elo > player2.Elo) != (rw2 > rl2))
				return player2;
			int count1 = (rw1 + rl1 + rd1);
			int count2 = (rw2 + rl2 + rd2);
			if (count1 * 1.1 <= count2 << 1)
				return player1;
			if (count2 * 1.1 <= count1 >> 1)
				return player2;
			return null;
		}

		public static CPlayer SelectLast()
		{
			int count = 0;
			CPlayer result = null;
			foreach (CPlayer p in playerList)
			{
				int c = tourList.LastGame(p.name);
				if (count <= c)
				{
					count = c;
					result = p;
				}
			}
			return result;
		}

		public void ListFill()
		{
			CPlayer player = FormChess.playerList.GetPlayerByName(FormChess.formOptions.cbTourPSelected.Text);
			int avg = player == null ? (int)FormChess.formOptions.nudTourPAvg.Value : player.Elo;
			int range = (int)FormChess.formOptions.nudTourELimit.Value;
			int eloMin = range == 0 ? 0 : avg - range;
			int eloMax = range == 0 ? CElo.eloTotal : avg + range;
			playerList.Clear();
			foreach (CPlayer p in FormChess.playerList)
				if (p.IsPlayable() && (p.tournament > 0))
					if ((p.Elo >= eloMin) && (p.Elo <= eloMax))
						playerList.AddPlayer(p);
		}

		public CPlayer SelectFirst()
		{
			ListFill();
			CPlayer player = playerList.GetPlayerByName(FormChess.formOptions.cbTourPSelected.Text);
			if ((player != null) && (FormChess.formOptions.nudTourPRange.Value == 0))
				return player;
			player = playerList.GetPlayerByName(first);
			if ((player == null) || ((left < 1) && (reps > 0)))
			{
				player = SelectLast();
				reps = 0;
			}
			return player;
		}

		public CPlayer SelectSecond(CPlayer player)
		{
			if (player == null)
				return null;
			first =opponent= player.name;
			if (playerList.Count < 2)
				return player;
			playerList.SetEloDistance(player);
			double bstScore = double.MinValue;
			CPlayer bstPlayer = player;
			foreach (CPlayer p in playerList)
				if (p != player)
				{
					double curScore = player.EvaluateOpponent(p, playerList.Count, tourList);
					if (bstScore < curScore)
					{
						bstScore = curScore;
						bstPlayer = p;
					}

				}
			opponent = bstPlayer.name;
			return bstPlayer;
		}

		public void SetRepeition(CPlayer p, CPlayer o)
		{
			if ((first != p.name) || (opponent != o.name))
			{
				first = p.name;
				opponent = o.name;
				int cg = tourList.CountGames(p.name, o.name, out int rw, out int rl, out _);
				if (reps == 0)
				{
					left = p.tournament;
					if (cg == 0)
						left++;
					if ((p.Elo > o.Elo) != (rw > rl))
						left++;
					if (p.history.Count < o.history.Count)
						left += 2;
					rotate = true;
				}
			}
			reps++;
			if (left > 0)
				left--;
			rotate ^= true;
		}
	}

}
