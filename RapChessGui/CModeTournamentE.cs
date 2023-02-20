using System;
using System.Collections.Generic;

namespace RapChessGui
{
	static class CModeTournamentE
	{
		public static bool rotate = true;
		public static int reps = 0;
		public static int left = 0;
		public static int records = 10000;
		public static int eloAvg = 0;
		public static int eloRange = 0;
		public static string first = String.Empty;
		public static string opponent = String.Empty;
		public static CTourList tourList = new CTourList("Tour-engines");
		public static CEngineList engineList = new CEngineList();
		public static CEngine engWin = null;
		public static CEngine engLoose = null;

		public static void SaveToIni()
		{
			FormChess.ini.Write("mode>tournamentE>engine", first);
			FormChess.ini.Write("mode>tournamentE>records", records);
			FormChess.ini.Write("mode>tournamentE>eloAvg", eloAvg);
			FormChess.ini.Write("mode>tournamentE>eloRange", eloRange);
		}

		public static void LoadFromIni()
		{
			first = FormChess.ini.Read("mode>tournamentE>engine", first);
			records = FormChess.ini.ReadInt("mode>tournamentE>records", records);
			eloAvg = FormChess.ini.ReadInt("mode>tournamentE>eloAvg", eloAvg);
			eloRange = FormChess.ini.ReadInt("mode>tournamentE>eloRange", eloRange);
			tourList.SetLimit(records);
		}

		public static void NewGame()
		{
			rotate = true;
			reps = 0;
			left = 0;
			opponent = String.Empty;
		}

		public static void ListFill()
		{
			int avg = eloAvg;
			CEngine eng = FormChess.engineList.GetEngineByName(FormOptions.tourESelected);
			if (eng != null)
				avg = eng.Elo;
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
			CLevel level =  CLevelValue.StrToLevel(FormOptions.tourEMode);
			engineList.Clear();
			foreach (CEngine e in FormChess.engineList)
				if (e.IsPlayable(level) && (e.tournament > 0))
					if ((e.Elo >= eloMin) && (e.Elo <= eloMax))
						engineList.AddEngine(e);
		}

		public static CEngine SelectLast()
		{
			int count = 0;
			CEngine result = null;
			foreach (CEngine e in engineList)
			{
				int c = tourList.LastGame(e.name);
				if (count <= c)
				{
					count = c;
					result = e;
				}
			}
			return result;
		}

		public static CEngine SelectFirst()
		{
			ListFill();
			CEngine e = engineList.GetEngineByName(FormOptions.tourESelected);
			if ((e != null) && (eloRange == 0))
				return e;
			e = engineList.GetEngineByName(first);
			if ((e == null) || ((left < 1) && (reps > 0)))
			{
				e = SelectLast();
				reps = 0;
			}
			return e;
		}

		public static CEngine SelectSecond(CEngine engine)
		{
			if (engineList.Count < 2)
				return engine;
			engineList.SetEloDistance(engine);
			double bstScore = double.MinValue;
			CEngine bstEngine = engine;
			foreach (CEngine e in engineList)
				if (e != engine)
				{
					double curScore = engine.EvaluateOpponent(e,engineList.Count,tourList);
					if (bstScore < curScore)
					{
						bstScore = curScore;
						bstEngine = e;
					}

				}
			return bstEngine;
		}

		public static void SetRepeition(CEngine e, CEngine o)
		{
			if ((first != e.name) || (opponent != o.name))
			{
				first = e.name;
				opponent = o.name;
				SaveToIni();
				int cg = tourList.CountGames(e.name, o.name, out int rw, out int rl, out _);
				if (reps == 0)
				{
					left = e.tournament;
					if (cg == 0)
						left++;
					if ((e.Elo > o.Elo) != (rw > rl))
						left++;
					if (e.hisElo.Count < o.hisElo.Count)
						left += 2;
					rotate = true;
				}
			}
			reps++;
			left--;
			rotate ^= true;
		}

	}

}
