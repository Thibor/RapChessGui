using System;

namespace RapChessGui
{
    public class CModeTournamentE : CModeTournament
    {
        public static CTourList tourList = new CTourList("engines");
        public static CListEngine engineList = new CListEngine();
        public static CEngine engWin = null;
        public static CEngine engLoose = null;
        public CLimitValue limit = new CLimitValue();

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
            int elo = eng == null ? (int)FormChess.formOptions.nudTourEAvg.Value : eng.Elo;
            int limit = (int)FormChess.formOptions.nudTourELimit.Value;

            if (elo == 0)
                FormChess.engineList.SortSize();
            else
                FormChess.engineList.SortEloDistance(elo);

            CLimitKind level = CLimitValue.StrToLimit(FormOptions.tourEMode);
            engineList.Clear();
            foreach (CEngine e in FormChess.engineList)
                if (e.IsPlayable(level) && (e.tournament > 0))
                {
                    engineList.AddEngine(e);
                    if ((limit > 0) && (engineList.Count >= limit))
                        break;
                }
        }

        public CEngine SelectFirst()
        {
            ListFill();
            CEngine eng = engineList.GetEngineByName(FormChess.formOptions.cbTourESelected.Text);
            if ((eng != null) && (FormChess.formOptions.nudTourELimit.Value == 0))
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
            if (engine == null)
                return null;
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
                    if ((e.Elo > o.Elo) != (rw > rl))
                        left++;
                    if (e.history.Count < o.history.Count)
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
