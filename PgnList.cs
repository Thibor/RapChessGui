using System;
using System.Collections.Generic;
using System.IO;

namespace RapChessGui
{
    class HPgn
    {
        public string name = string.Empty;
        public string value = string.Empty;

        public bool FromStr(string s)
        {
            if(string.IsNullOrEmpty(s))
                return false;
            s = s.Trim(new Char[] { ' ','[', ']','"' });
            string[] arr=s.Split('"');
            if(arr.Length <1 )
                return false;
            name = arr[0].Trim();
            value = arr[1].Trim();
            return true;
        }

        public string ToStr()
        {
            return $"[{name} \"{value}\"]";
        }

    }

    class HPgnList : List<HPgn>
    {
        public void Add(string line)
        {
            HPgn hp= new HPgn();
            if (hp.FromStr(line))
                Add(hp);
        }

        public string GetValue(string name)
        {
            string result = "???";
            foreach(HPgn hp in this)
                if (hp.name == name)
                    return hp.value;
            return result;
        }

    }

    class EPgn
    {
        public HPgnList header= new HPgnList();
        public string moves=string.Empty;

        public EPgn() { 
        }

        public EPgn(EPgn ep)
        {
            Assign(ep);
        }

        public void Assign(EPgn ep)
        {
            header.Clear();
            foreach(HPgn hp in ep.header)
                header.Add(hp);
            moves = ep.moves;
        }

        public bool AddLine(string line)
        {
            if(string.IsNullOrEmpty(line))
                return false;
            if(line.Length<4)
                return false;
            if (line[0] == '[')
                header.Add(line);
            if (line[0] == '1')
            {
                moves = line;
                return true;
            }
            return false;
        }

        public void SaveToStream(StreamWriter sw)
        {
            sw.WriteLine("");
            foreach(HPgn hp in header)
                sw.WriteLine(hp.ToStr());
            sw.WriteLine("");
            sw.WriteLine(moves);
        }

    }

    internal class PgnList:List<EPgn>
    {

        public void Add()
        {
            Add(new EPgn());
        }

        public EPgn Last()
        {
            return this[Count-1];
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
                EPgn ep = new EPgn();
                while ((line = reader.ReadLine()) != null)
                {
                    if (ep.AddLine(line))
                    {
                        Add(new EPgn(ep));
                        ep.header.Clear();
                    }
                }
            }
            return Count > 0;
        }

        public void SaveToFile(string fileName,int limit=0)
        {
            using (FileStream fs = File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                int c = 0;
                foreach (EPgn ep in this)
                {
                    ep.SaveToStream(sw);
                    if((limit>0) && (++c>=limit))
                        break;
                }
            }
        }

    }
}
