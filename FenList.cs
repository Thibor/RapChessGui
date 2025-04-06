using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RapChessGui
{
    internal class FenList:List<string>
    {
        public void LoadFromFile(string fileName)
        {
            string line = string.Empty;
            using (StreamReader reader = new StreamReader(fileName))
                while ((line = reader.ReadLine()) != null)
                    if (!string.IsNullOrEmpty(line))
                        Add(line);
        }

        public void SaveToFile(string fileName,int limit=0)
        {
            using (FileStream fs = File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                int c = 0;
                foreach (string f in this)
                {
                    sw.WriteLine(f);
                    if ((limit > 0) && (++c >= limit))
                        break;
                }
            }
        }

        public void DeleteFen(string fen)
        {
            string fd = fen.Split()[0];
            for(int n = Count-1;n>=0;n--)
            {
                string fc=this[n].Split()[0];
                if(fc==fd)
                    RemoveAt(n);
            }
        }

        public void AddFen(string fen) {
            DeleteFen(fen);
            Insert(0, fen);
        }

    }
}
