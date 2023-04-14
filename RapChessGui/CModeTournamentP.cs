using System;

namespace RapChessGui
{
	class CModeTournamentP
	{
		public static bool rotate = false;
		public static int reps = 0;
		public static int left = 0;
		public static int records = 10000;
		public static int eloAvg = 3000;
		public static int eloRange = 0;
		public static string first = String.Empty;
		public static string opponent = String.Empty;
		public static CTourList tourList = new CTourList("Tour-players");
		public static CListPlayer playerList = new CListPlayer();
		public static CPlayer plaWin = null;
		public static CPlayer plaLoose = null;

		public static void SaveToIni()
		{
			FormChess.ini.Write("mode>tournamentP>player", first);
			FormChess.ini.Write("mode>tournamentP>records", records);
			FormChess.ini.Write("mode>tournamentP>eloAvg", eloAvg);
			FormChess.ini.Write("mode>tournamentP>eloRange", eloRange);
		}

		public static void LoadFromIni()
		{
			first = FormChess.ini.Read("mode>tournamentP>player", first);
			records = FormChess.ini.ReadInt("mode>tournamentP>records", records);
			eloAvg = FormChess.ini.ReadInt("mode>tournamentP>eloAvg", eloAvg);
			eloRange = FormChess.ini.ReadInt("mode>tournamentP>eloRange", eloRange);
			tourList.SetLimit(records);
		}

		public static void NewGame()
		{
			rotate = true;
			reps = 0;
			left = 0;
			opponent = String.Empty;
		}

		public static CPlayer ChooseOpponent(CPlayer player, CPlayer player1, CPlayer player2)
		{
			tourList.CountGames(player.name, player1.name, out int rw1, out int rl1, out int rd1);
			tourList.CountGames(player.name, player2.name, out int rw2, out int rl2, out int rd2);
			if ((player.elo > player1.elo) != (rw1 > rl1))
				return player1;
			if ((player.elo > player2.elo) != (rw2 > rl2))
				return player2;
			int count1 = (rw1 + rl1 + rd1);
			int count2 = (rw2 + rl2 + rd2);
			if (count1 * 1.1 <= count2 << 1)
				return player1;
			if (count2 * 1.1 <= count1 >> 1)
				return player2;
			return null;
		}

		public static void ListFill()
		{
			int avg = eloAvg;
			CPlayer player = FormChess.playerList.GetPlayerByName(FormOptions.tourPSelected);
			if (player != null)
				avg = player.elo;
			int eloMin = avg - eloRange;
			int eloMax = avg + eloRange;
			if ((eloRange == 0) || (eloAvg == 0))
				if (eloAvg > 0)
				{
					eloMin = avg - eloAvg;
					eloMax = avg + eloAvg;
				}
				else
				{
					eloMin = 0;
					eloMax = 3000;
				}
			playerList.Clear();
			foreach (CPlayer p in FormChess.playerList)
				if (p.IsPlayable() && (p.tournament > 0))
					if ((p.elo >= eloMin) && (p.elo <= eloMax))
						playerList.AddPlayer(p);
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

		public static CPlayer SelectFirst()
		{
			ListFill();
			CPlayer p = playerList.GetPlayerByName(FormOptions.tourPSelected);
			if ((p != null) && (eloRange == 0))
				return p;
			p = playerList.GetPlayerByName(first);
			if ((p == null) || ((left < 1) && (reps > 0)))
			{
				p = SelectLast();
				reps = 0;
			}
			return p;
		}

		public static CPlayer SelectSecond(CPlayer player)
		{
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
			return bstPlayer;
		}

		public static void SetRepeition(CPlayer p, CPlayer o)
		{
			if ((first != p.name) || (opponent != o.name))
			{
				first = p.name;
				opponent = o.name;
				SaveToIni();
				int cg = tourList.CountGames(p.name, o.name, out int rw, out int rl, out _);
				if (reps == 0)
				{
					left = p.tournament;
					if (cg == 0)
						left++;
					if ((p.elo > o.elo) != (rw > rl))
						left++;
					if (p.hisElo.Count < o.hisElo.Count)
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
