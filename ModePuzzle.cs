using RapIni;
using System;

namespace RapChessGui
{
    internal class ModePuzzle
    {
        public bool fail = false;
        public int puzIndex = -1;
        public int puzNumber = 0;
        public int countMoves = 0;
        public int repetition = 0;
        public string fen = string.Empty;
        public string moves = string.Empty;
        public string hint = string.Empty;
        public PuzzleList puzzleList = new PuzzleList();
        public MistakeList mistakeList = new MistakeList();
        static readonly Random rnd = new Random();
        public static CRapIni ini = new CRapIni(@"Ini\puzzle.ini");
        public CHisElo history = new CHisElo();

        public ModePuzzle()
        {
            string fn = @"Data\lichess.puz";
            puzzleList.LoadFromFile(fn);
            //puzzleList.SortElo();
            //puzzleList.SaveToFile("sort.puz");
            ini.Load();
            LoadFromIni();
        }

        public void LoadFromIni()
        {
            history.LoadFromIni(ini, "history");
        }

        public void SaveToIni()
        {
            history.SaveToIni(ini, "history");
            ini.Save();
        }

        public void Start()
        {
            fail = false;
            puzIndex = -1;
            puzNumber = 0;
            countMoves = 0;
            hint = string.Empty;
            mistakeList.LoadFromFile();
            repetition = mistakeList.Count;
        }

        public bool IsLast(int i)
        {
            return i >= countMoves;
        }

        public void Next()
        {
            fail = false;
            hint = string.Empty;
        }

        public void Success()
        {
            if (IsRepetitionTurn())
            {
                repetition--;
                mistakeList.Success(fail);
            }
            else
            {
                puzIndex++;
                if (fail)
                    history.Lost();
                else
                    history.Win();
                SaveToIni();
            }
        }

        public void Fail()
        {
            if (!fail && IsPuzzleTurn())
            {
                EPuzzle ep = GetPuzzle();
                mistakeList.Add(ep.fen, ep.moves);
            }
            fail = true;
        }

        public bool IsPuzzleTurn()
        {
            return !IsRepetitionTurn();
        }

        public bool IsRepetitionTurn()
        {
            return FormChess.formOptions.clbPuzzle.GetItemChecked(2) && (repetition > 0);
        }

        public EPuzzle GetPuzzle()
        {
            if (puzIndex >= puzzleList.Count)
                return null;
            return puzzleList[puzIndex];
        }

        public EMistake GetMistake()
        {
            if (mistakeList.Count < 1)
                return null;
            return mistakeList[0];
        }

        public bool PuzzleDelete()
        {
            if (puzIndex < 0)
                return false;
            if (puzIndex >= puzzleList.Count)
                return false;
            puzzleList.RemoveAt(puzIndex);
            return true;
        }

        public bool NextPuzlle()
        {
            if (puzzleList.Count == 0)
                return false;
            double pro = history.LastPro() - .05;
            if (pro < 0)
                pro = 0;
            if (pro > .9)
                pro = .9;
            int l1 = Convert.ToInt32(pro * puzzleList.Count);
            int l2 = l1 + puzzleList.Count / 10;
            puzIndex = rnd.Next(l1, l2);
            return true;
        }

        public bool NextMistake()
        {
            if (mistakeList.Count == 0)
                return false;
            return true;
        }

        public string GetMove(int i)
        {
            string[] arrs = moves.Split();
            if (i >= arrs.Length)
                return string.Empty;
            return arrs[i];
        }

        public bool SetMoves(string f, string m)
        {
            fen = f;
            moves = m;
            countMoves = m.Split().Length;
            if (countMoves < 2)
                return false;
            if ((countMoves & 1) == 1)
            {
                countMoves--;
                return false;
            }
            return true;
        }

    }
}
