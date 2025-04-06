using System;
using System.Collections.Generic;
using System.IO;

namespace RapChessGui
{
    class EMistake
    {
        public string fen = string.Empty;
        public string moves = string.Empty;
        public int rep = 2;

        public string SaveToStr()
        {
            return $"{fen},{moves},{rep}";
        }

        public bool LoadFromStr(string str)
        {
            string[] strArr = str.Split(',');
            if (strArr.Length < 3)
                return false;
            fen = strArr[0];
            moves = strArr[1];
            int.TryParse(strArr[2], out rep);
            return true;
        }

        public string GetMove(int i)
        {
            string[] arrs = moves.Split();
            if (i >= arrs.Length)
                return string.Empty;
            return arrs[i];
        }

    }

    internal class MistakeList : List<EMistake>
    {
        readonly string fileName = @"Data\mistakes.csv";

        public void Add(string fen, string moves)
        {
            EMistake em = new EMistake() { fen = fen, moves = moves};
            Insert(0, em);
            SaveToFile();
        }

        public bool Delete(string fen)
        {
            for(int n=Count-1;n>=0 ;n--)
                if (this[n].fen==fen)
                {
                    RemoveAt(n);
                    return true;
                }
            return false;
        }

        public void SaveToFile()
        {
            using (FileStream fs = File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                int c = 0;
                foreach (EMistake em in this)
                    if (em.rep > 0)
                    {
                        sw.WriteLine(em.SaveToStr());
                        if (++c >= 16)
                            break;
                    }
            }
        }

        public bool LoadFromFile()
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
                    EMistake em = new EMistake();
                    if (em.LoadFromStr(line))
                        Add(em);
                }
            }
            return Count > 0;
        }

        public void Success(bool fail)
        {
            EMistake em = this[0];
            if (fail)
                em.rep = 2;
            else
                em.rep--;
            RemoveAt(0);
                Add(em);
            SaveToFile();
        }

        void SortEpd()
        {
            Sort(delegate (EMistake m1, EMistake m2)
            {
                return String.Compare(m1.fen, m2.fen, StringComparison.Ordinal);
            });
        }

    }

}
