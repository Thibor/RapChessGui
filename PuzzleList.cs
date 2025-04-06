using System;
using System.Collections.Generic;
using System.IO;

namespace RapChessGui
{
    class EPuzzle
    {
        public string fen = string.Empty;
        public string moves = string.Empty;
        public int elo = 0;

        public bool Check(out string msg) {
            string[] am = moves.Split();
            if (am.Length < 2)
            {
                msg = "Too few moves";
                return false;
            }
            if(am.Length > 20)
            {
                msg = "Too many moves";
                return false;
            }
            if((am.Length & 1) > 0)
            {
                msg = "The number of moves cannot be odd";
                return false;
            }
            msg = "Puzzle saved";
            return true;
        }

        public bool LoadFromStr(string str)
        {
            string[] strArr = str.Split(',');
            if (strArr.Length < 2)
                return false;
            fen = strArr[0];
            moves = strArr[1];
            if(strArr.Length>2)
                int.TryParse(strArr[2], out elo);
            return true;
        }

        public string SaveToStr()
        {
            return $"{fen},{moves},{elo}";
        }

        public string GetMove(int i)
        {
            string[] arrs = moves.Split();
            if (i >= arrs.Length)
                return string.Empty;
            return arrs[i];
        }

    }

    internal class PuzzleList : List<EPuzzle>
    {
        public void Add(string f,string m)
        {
            Add(new EPuzzle { fen = f, moves = m });
        }

        public bool Delete(string fen)
        {
            for (int n = Count - 1; n >= 0; n--)
                if (this[n].fen == fen)
                {
                    RemoveAt(n);
                    return true;
                }
            return false;
        }

        public void SaveToFile(string fileName,int limit=0)
        {
            using (FileStream fs = File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                int c = 0;
                foreach (EPuzzle ep in this)
                {
                    sw.WriteLine(ep.SaveToStr());
                    if ((limit > 0) && (++c >= limit))
                        break;
                }
            }
        }

        public bool LoadFromFile(string fileName)
        {
            Clear();
            if (!File.Exists(fileName))
                return false;
            using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            using (StreamReader reader = new StreamReader(fs))
            {
                string line = String.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    EPuzzle ep = new EPuzzle();
                    if (ep.LoadFromStr(line))
                        Add(ep);
                }
            }
            return Count > 0;
        }

        public void SortElo()
        {
            Sort(delegate (EPuzzle ep1, EPuzzle ep2)
            {
                return ep1.elo - ep2.elo;
            });
        }


    }

}
