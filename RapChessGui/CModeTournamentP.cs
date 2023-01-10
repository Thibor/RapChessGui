using System;
using System.Collections.Generic;

namespace RapChessGui
{
	static class CModeTournamentP
	{
		public static bool rotate = false;
		public static int games = 0;
		public static int repetition = 0;
		public static int records = 10000;
		public static int eloAvg = 3000;
		public static int eloRange = 0;
		public static string first = String.Empty;
		public static string opponent = String.Empty;
		public static CTourList tourList = new CTourList("Tour-players");
		public static CPlayerList playerList = new CPlayerList();
		public static CPlayer plaWin = null;
		public static CPlayer plaLoose = null;

		public static void SaveToIni()
		{
			FormChess.iniFile.Write("mode>tournamentP>player", first);
			FormChess.iniFile.Write("mode>tournamentP>records", records);
			FormChess.iniFile.Write("mode>tournamentP>eloAvg", eloAvg);
			FormChess.iniFile.Write("mode>tournamentP>eloRange", eloRange);
		}

		public static void LoadFromIni()
		{
			first = FormChess.iniFile.Read("mode>tournamentP>player", first);
			records = FormChess.iniFile.ReadInt("mode>tournamentP>records", records);
			eloAvg = FormChess.iniFile.ReadInt("mode>tournamentP>eloAvg", eloAvg);
			eloRange = FormChess.iniFile.ReadInt("mode>tournamentP>eloRange", eloRange);
			tourList.SetLimit(records);
		}

		public static void NewGame()
		{
			rotate = true;
			games = 0;
			repetition = 0;
			opponent = String.Empty;
		}

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

		public static void ListFill()
		{
			int avg = eloAvg;
			CPlayer player = FormChess.playerList.GetPlayerByName(FormOptions.tourPSelected);
			if (player != null)
				avg = player.Elo;
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
					if ((p.Elo >= eloMin) && (p.Elo <= eloMax))
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
			if ((p == null) || ((games >= repetition) && (games > 0)))
			{
				p = SelectLast();
				games = 0;
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
					double curScore = EvaluateOpponent(playerList.Count, player, p);
					if (bstScore < curScore)
					{
						bstScore = curScore;
						bstPlayer = p;
					}

				}
			return bstPlayer;
		}

		public static double EvaluateOpponent(double listCount, CPlayer first, CPlayer second)
		{
			double fElo = first.Elo;
			double sElo = second.Elo;
			int allGames = tourList.CountGames(first.name);
			int curGames = tourList.CountGames(second.name, first.name, out int rw, out int rl, out int rd);
			double r = curGames == 0 ? 0 : (rw * 2.0 + rd - curGames) / curGames;
			double eloDif = (CElo.eloRange - Math.Abs(fElo - sElo)) / CElo.eloRange;
			double nElo = sElo;
			if (r < 0)
				nElo += r * sElo * eloDif;
			if (r > 0)
				nElo += r * (CElo.eloMax - sElo) * eloDif;
			double ratioElo = (Math.Abs(sElo - nElo) / CElo.eloRange);
			double avgCount = allGames / listCount;
			double delCount = (avgCount * 2) / listCount + 1;
			double maxCount = Math.Sqrt(allGames * 2) + 1;
			double optCount = maxCount - second.position * delCount + 1;
			double ratioCount = allGames == 0 ? 0 : (optCount - curGames) / allGames;
			double ratioDistance = (listCount - second.position) / (double)listCount;
			double ratioOrder = allGames == 0 ? 0 : (rw == rl) ? 0.2 : (sElo == fElo) ? 0.5 : (rw > rl) == (sElo < fElo) ? 1 : 0;
			return ratioCount + ratioDistance + ratioElo + ratioOrder;
		}

		public static void SetRepeition(CPlayer p, CPlayer o)
		{
			if ((first != p.name) || (opponent != o.name))
			{
				first = p.name;
				opponent = o.name;
				SaveToIni();
				int cg = tourList.CountGames(p.name, o.name, out int rw, out int rl, out _);
				if (games == 0)
				{
					repetition = p.tournament;
					if (cg == 0)
						repetition++;
					if ((p.Elo > o.Elo) != (rw > rl))
						repetition++;
					if (p.hisElo.Count < o.hisElo.Count)
						repetition += 2;
					rotate = true;
				}
			}
			games++;
			rotate ^= true;
		}
	}

}
