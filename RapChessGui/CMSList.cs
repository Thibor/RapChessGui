using NSChess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace RapChessGui
{

    class CMSRec
    {
        public string move;
        public int score;

        public CMSRec(CMSRec rec)
        {
            move = rec.move;
            score = rec.score;
        }

        public CMSRec(string m, int s)
        {
            move = m;
            score = s;
        }
    }

    internal class CMSLine : List<CMSRec>
    {
        public bool fail = false;
        public string fen = String.Empty;
        public int depth = 0;
        readonly public static int blunder = 300;

        public static double WiningChances(int centipawns)
        {
            return 50 + 50 * (2 / (1 + Math.Exp(-0.00368208 * centipawns)) - 1);
        }

        public bool IsTest()
        {
            if (Count < 2)
                return false;
            int margin = 20;
            double wc1 = WiningChances(this[0].score);
            double wc2 = WiningChances(this[1].score);
            if (wc1 - wc2>margin)
                return true;
            return false;
        }

        public void Assign(CMSLine line)
        {
            Clear();
            fen = line.fen;
            depth = line.depth;
            foreach (CMSRec rec in line)
                Add(new CMSRec(rec));
        }

        public void DeleteMove(string move)
        {
            for (int n = Count - 1; n >= 0; n--)
                if (this[n].move == move)
                    RemoveAt(n);
        }

        public void AddRec(CMSRec rec)
        {
            DeleteMove(rec.move);
            Add(rec);
            SortScore();
        }

        public void SortScore()
        {
            Sort(delegate (CMSRec r1, CMSRec r2)
            {
                return r2.score - r1.score;
            });
        }

        public CMSRec First()
        {
            if (Count > 0)
                return this[0];
            return null;
        }

        public CMSRec Last()
        {
            if (Count > 0)
                return this[Count - 1];
            return null;
        }

        public int GetLoss()
        {
            CMSRec f = First();
            CMSRec l = Last();
            if ((f == null) || (l == null))
                return 0;
            return First().score - Last().score;
        }

        public bool MoveExists(string move)
        {
            foreach (CMSRec rec in this)
                if (rec.move == move)
                    return true;
            return false;
        }

        void Reset()
        {
            fen = String.Empty;
            depth = 0;
            Clear();
        }

        string GetMoves()
        {
            string moves = String.Empty;
            foreach (CMSRec rec in this)
            {
                moves = $"{moves} bm {rec.move} ce {rec.score}";
            }
            return moves.Trim();
        }

        public int GetScore(string move)
        {
            foreach (CMSRec rec in this)
                if (rec.move == move)
                    return rec.score;
            return Last().score;
        }

        public string SaveToStr()
        {
            string moves = GetMoves();
            return $"{fen} acd {depth} {moves}".Trim();
        }

        public bool LoadFromStr(string line)
        {
            Reset();
            string[] tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length < 6)
                return false;
            List<string> sl = new List<string>(tokens);
            string last = String.Empty;
            string move = String.Empty;
            for (int n = 0; n < sl.Count; n++)
            {
                string s = sl[n];
                if ((s == "bm") || (s == "ce") || (s == "acd") || (s == "loss"))
                {
                    last = s;
                    continue;
                }
                if (n < 6)
                {
                    fen += ' ' + s;
                    continue;
                }
                switch (last)
                {
                    case "acd":
                        depth = Convert.ToInt32(s);
                        break;
                    case "bm":
                        move = s;
                        break;
                    case "ce":
                        if (!String.IsNullOrEmpty(move))
                        {
                            CMSRec rec = new CMSRec(move, Convert.ToInt32(s));
                            AddRec(rec);
                        }
                        break;
                }
            }
            fen = fen.Trim();
            return true;
        }

    }

    class CMSList : List<CMSLine>
    {
        readonly static int blunder = 300;
        readonly static int minDepth = 16;
        static string accuracyEpd = string.Empty;
        readonly static Random rnd = new Random();

        public void GetDepth(out int min, out int max)
        {
            min = int.MaxValue;
            max = 0;
            foreach (CMSLine msl in this)
            {
                if (min > msl.depth)
                    min = msl.depth;
                if (max < msl.depth)
                    max = msl.depth;
            }
            if (min > max)
                min = 0;
        }

        public void GetMoves(out int min, out int max)
        {
            min = int.MaxValue;
            max = 0;
            foreach (CMSLine msl in this)
            {
                if (min > msl.Count)
                    min = msl.Count;
                if (max < msl.Count)
                    max = msl.Count;
            }
            if (min > max)
                min = 0;
        }

        public int CountMoves(out int min)
        {
            int result = 0;
            min = int.MaxValue;
            foreach (CMSLine msl in this)
            {
                if (min > msl.Count)
                {
                    min = msl.Count;
                    result = 1;
                }
                else if (min == msl.Count)
                    result++;
            }
            return result;
        }

        public void Check()
        {
            SortFen();
            CMSLine last = null;
            for (int n = 0; n < this.Count; n++)
            {
                CMSLine msl = this[n];
                if (((msl.Count > 0) && msl.GetLoss() < blunder))
                    msl.fail = true;
                if ((n > 0) && (msl.fen == last.fen))
                    if (msl.depth < last.depth)
                        msl.fail = true;
                    else
                        last.fail = true;
                last = msl;
            }
        }

        public int CountFail()
        {
            int result = 0;
            foreach (CMSLine msl in this)
                if (msl.fail)
                    result++;
            return result;
        }

        public int DeleteFail()
        {
            int result = 0;
            for (int n = Count - 1; n >= 0; n--)
            {
                CMSLine msl = this[n];
                if (msl.fail)
                {
                    result++;
                    RemoveAt(n);
                }
            }
            if (result > 0)
                SaveToEpd();
            return result;
        }

        public void DeleteFen(string fen)
        {
            for (int n = Count - 1; n >= 0; n--)
                if (this[n].fen == fen)
                    RemoveAt(n);
        }

        public int DeleteMoves(int moves)
        {
            int result = 0;
            for (int n = Count - 1; n >= 0; n--)
                if (this[n].Count == moves)
                {
                    result++;
                    RemoveAt(n);
                }
            if (result > 0)
                SaveToEpd();
            return result;
        }

        public void SaveToEpd()
        {
            string last = String.Empty;
            SortFen();
            using (FileStream fs = File.Open(accuracyEpd, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (CMSLine msl in this)
                {
                    string l = msl.SaveToStr();
                    string[] tokens = l.Split(' ');
                    if (last == tokens[0])
                        continue;
                    last = tokens[0];
                    sw.WriteLine(l);
                }
            }
        }

        public bool LoadFromEpd(string fn)
        {
            accuracyEpd = fn;
            Clear();
            if (!File.Exists(accuracyEpd))
                return false;
            using (FileStream fs = File.Open(accuracyEpd, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (StreamReader reader = new StreamReader(fs))
            {
                string line = String.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    CMSLine msl = new CMSLine();
                    if (msl.LoadFromStr(line))
                        Add(msl);
                }
            }
            return Count > 0;
        }

        void SortFen()
        {
            Sort(delegate (CMSLine l1, CMSLine l2)
            {
                return String.Compare(l1.fen, l2.fen, StringComparison.Ordinal);
            });
        }

        public void SortDepth()
        {
            Sort(delegate (CMSLine l1, CMSLine l2)
            {
                int d1 = l1.depth;
                int d2 = l2.depth;
                return d1 - d2;
            });
        }

        public void SortRandom()
        {
            for (int n = 0; n < Count; n++)
            {
                int r = rnd.Next(Count);
                (this[n], this[r]) = (this[r], this[n]);
            }
        }

        public int GetFenIndex(string fen)
        {
            for (int n = 0; n < Count; n++)
                if (this[n].fen == fen)
                    return n;
            return -1;
        }

        public bool AddLine(CMSLine line)
        {
            int index = GetFenIndex(line.fen);
            if (index < 0)
                Add(line);
            return index < 0;
        }

        public bool AddLine(string line)
        {
            CMSLine msl = new CMSLine();
            if (msl.LoadFromStr(line))
                return AddLine(msl);
            return false;
        }

        public void ReplaceLine(CMSLine line)
        {
            int index = GetFenIndex(line.fen);
            if (index >= 0)
                this[index].Assign(line);
            else
                Add(line);
        }
        public int CountShallowLine()
        {
            int result = 0;
            foreach (CMSLine line in this)
                if (line.depth < minDepth)
                    result++;
            return result;
        }

        public CMSLine GetShallowLine()
        {
            if (Count == 0)
                return null;
            CMSLine bst = this[0];
            foreach (CMSLine line in this)
                if (bst.depth > line.depth)
                    bst = line;
            return bst.depth < minDepth ? bst : null;
        }

        public CMSLine GetRandomLine()
        {
            if (Count == 0)
                return null;
            int index = rnd.Next(Count);
            return this[index];
        }

    }

}
