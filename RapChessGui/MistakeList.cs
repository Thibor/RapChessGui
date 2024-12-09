using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{
    class CMistakeE
    {
        public string move=string.Empty;
        public int score =0;
    }

    class CMistake:List<CMistakeE>
    {
        public string epd=string.Empty;
        public int depth = 0;

        void Reset()
        {
            epd = String.Empty;
            Clear();
        }

        public void AddMS(string m,int s)
        {
            Add(new CMistakeE { move=m,score=s});
        }
        
        public string SaveToStr()
        {
            string result = $"{epd} acd {depth}";
            foreach (CMistakeE me in this)
                result += $" bm {me.move} ce {me.score}";
            return result;
        }

        public bool LoadFromStr(string line)
        {
            Reset();
            string[] tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length < 4)
                return false;
            List<string> sl = new List<string>(tokens);
            string last = String.Empty;
            string move = String.Empty;
            for (int n = 0; n < sl.Count; n++)
            {
                string s = sl[n];
                if ((s == "bm") || (s == "ce") || (s == "acd"))
                {
                    last = s;
                    continue;
                }
                if (n < 4)
                {
                    epd += ' ' + s;
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
                            CMistakeE me = new CMistakeE { move = move, score = Convert.ToInt32(s) };
                            Add(me);
                        }
                        break;
                }
            }
            epd = epd.Trim();
            return true;
        }

    }

    internal class MistakeList:List<CMistake>
    {
        readonly string fileName = @"history\mistakes.epd";

        public MistakeList()
        {
            LoadFromEpd();
        }

        public void AddEpd(string epd,int depth,string move,int cp,int mate)
        {
            int score = cp;
            if (mate > 0)
                score = 0xffff - mate;
            if (mate < 0)
                score = -0xffff - mate;
            CMistake m = new CMistake() { epd=epd,depth=depth};
            m.AddMS(move,score);
            Insert(0,m);
            SaveToEpd();
        }

        public void SaveToEpd()
        {
            using (FileStream fs = File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                int c = 0;
                foreach (CMistake m in this)
                {
                    sw.WriteLine(m.SaveToStr());
                    if (++c >= 1000)
                        break;
                }
            }
        }

        public bool LoadFromEpd()
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
                    CMistake m = new CMistake();
                    if (m.LoadFromStr(line))
                        Add(m);
                }
            }
            return Count > 0;
        }

        void SortEpd()
        {
            Sort(delegate (CMistake m1, CMistake m2)
            {
                return String.Compare(m1.epd, m2.epd, StringComparison.Ordinal);
            });
        }

    }

}
