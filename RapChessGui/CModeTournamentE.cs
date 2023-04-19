using System;

namespace RapChessGui
{
	public class CModeTournamentE : CModeTournament
	{
		public static CTourList tourList = new CTourList("Tour-engines");
		public static CListEngine engineList = new CListEngine();
		public static CEngine engWin = null;
		public static CEngine engLoose = null;

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

		public void ListFill()
		{
			CEngine eng = FormChess.engineList.GetEngineByName(FormChess.formOptions.cbTourESelected.Text);
			int avg = eng == null ? (int)FormChess.formOptions.nudTourEAvg.Value : eng.elo;
			int range = (int)FormChess.formOptions.nudTourERange.Value;
			int eloMin = range == 0 ? 0 : avg - range;
			int eloMax = range == 0 ? CElo.eloTotal : avg + range;
			CLevel level = CLevelValue.StrToLevel(FormOptions.tourEMode);
			engineList.Clear();
			foreach (CEngine e in FormChess.engineList)
				if (e.IsPlayable(level) && (e.tournament > 0))
					if ((e.elo >= eloMin) && (e.elo <= eloMax))
						engineList.AddEngine(e);
		}

		public CEngine SelectFirst()
		{
			ListFill();
			CEngine eng = engineList.GetEngineByName(FormChess.formOptions.cbTourESelected.Text);
			if ((eng != null) && (FormChess.formOptions.nudTourBRange.Value == 0))
				return eng;
			eng = engineList.GetEngineByName(first);
			if ((eng == null) || ((left < 1) && (reps > 0)))
			{
				eng = SelectLast();
				reps = 0;
			}
			return eng;
		}

		public CEngine SelectSecond(CEngine engine)
		{
			first = opponent = engine.name;
			if (engineList.Count < 2)
				return engine;
			engineList.SetEloDistance(engine);
			double bstScore = double.MinValue;
			CEngine bstEngine = engine;
			foreach (CEngine e in engineList)
				if (e != engine)
				{
					double curScore = engine.EvaluateOpponent(e, engineList.Count, tourList);
					if (bstScore < curScore)
					{
						bstScore = curScore;
						bstEngine = e;
					}
				}
			opponent = bstEngine.name;
			return bstEngine;
		}

		public void SetRepeition(CEngine e, CEngine o)
		{
			if ((first != e.name) || (opponent != o.name))
			{
				first = e.name;
				opponent = o.name;
				int cg = tourList.CountGames(e.name, o.name, out int rw, out int rl, out _);
				if (reps == 0)
				{
					left = e.tournament;
					if (cg == 0)
						left++;
					if ((e.elo > o.elo) != (rw > rl))
						left++;
					if (e.hisElo.Count < o.hisElo.Count)
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
