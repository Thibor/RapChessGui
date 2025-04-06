
using NSUci;
using RapIni;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace RapChessGui
{

    public class CBook : CElement
    {
        public int tournament = 1;
        public string fileReader = String.Empty;
        public string arguments = String.Empty;
        public List<string> options = new List<string>();

        public CBook()
        {
        }

        public CBook(string n)
        {
            name = n;
        }

        public bool FileExists()
        {
            if (fileReader == Global.none)
                return false;
            return File.Exists($@"Books\{fileReader}");
        }

        public string GetOption(string name, string def = "")
        {
            CUci uci = new CUci();
            foreach (string o in options)
            {
                uci.SetMsg(o);
                if (o.IndexOf($"name {name} value ") == 0)
                    return uci.GetValue("value");
            }
            return def;
        }

        public bool IsPlayable()
        {
            return FileExists();
        }

        public bool ParametersExists()
        {
            string[] tokens = arguments.Split(' ');
            return File.Exists($@"Books\{tokens[0]}");
        }

        public bool ContainBP(string book)
        {
            foreach (string o in options)
                if (o.Contains(book))
                    return true;
            return arguments.Contains(book);
        }

        public string GetPath()
        {
            return $@"{AppDomain.CurrentDomain.BaseDirectory}Books\{fileReader}";
        }

        public void LoadFromIni()
        {
            fileReader = CListBook.iniFile.Read($"book>{name}>exe");
            arguments = CListBook.iniFile.Read($"book>{name}>parameters");
            options = CListBook.iniFile.ReadListStr($"book>{name}>options");
            history.FromStr(CListBook.iniFile.Read($"book>{name}>history"));
            tournament = CListBook.iniFile.ReadInt($"book>{name}>tournament", tournament);
        }

        public void SaveToIni()
        {
            if (history.Count == 0)
                history.Add(Global.elo);
            name = GetName();
            CListBook.iniFile.Write($"book>{name}>exe", fileReader);
            CListBook.iniFile.Write($"book>{name}>parameters", arguments);
            CListBook.iniFile.Write($"book>{name}>options", options);
            CListBook.iniFile.Write($"book>{name}>history", history, " ");
            CListBook.iniFile.Write($"book>{name}>tournament", tournament);
        }


        public int GetDeltaElo()
        {
            return Elo - history.EloAvg();
        }

        public void AddElo(int e)
        {
            history.AddElo(e);
            SaveToIni();
        }

        public bool GetBFFromOption(out string bf)
        {
            bf = string.Empty;
            foreach (string o in options)
                if (o.IndexOf("name book_file value ") == 0)
                {
                    bf = o.Substring(21);
                    break;
                }
            return !string.IsNullOrEmpty(bf);
        }

        public string CreateName()
        {
            string fn,ext;
            TextInfo ti = new CultureInfo("en-US", false).TextInfo;
            if (GetBFFromOption(out string bf))
            {
                fn = Path.GetFileNameWithoutExtension(bf);
                ext = Path.GetExtension(bf).Trim('.').ToUpper();
                return $"{ext} {ti.ToTitleCase(fn)}".Trim();
            }
            fn = Path.GetFileNameWithoutExtension(fileReader);
            if(fn.Length>10)
                return fn.Substring(10).ToUpper();
            return ti.ToTitleCase(fn);
        }

        public string GetName()
        {
            if (name == string.Empty)
                return CreateName();
            return name;
        }

        public bool SetTournament(bool tb)
        {
            int t = tb ? 1 : 0;
            if (tb && (tournament > 0))
                t = tournament;
            if (tournament != t)
            {
                tournament = t;
                SaveToIni();
                return true;
            }
            return false;
        }

    }

    public class CListBook : List<CBook>
    {
        public static string def = "BRM Bigmem";
        readonly static Random rnd = new Random();
        public static CRapIni iniFile = new CRapIni(@"Ini\books.ini");

        public void AddBook(CBook b)
        {
            b.name = b.GetName();
            int index = GetIndex(b.name);
            if (index >= 0)
                this[index] = b;
            else
                Add(b);
        }

        public void DeleteBook(string name)
        {
            iniFile.DeleteKey($"book>{name}");
            int i = GetIndex(name);
            if (i >= 0)
                RemoveAt(i);
        }

        public void FillPosition()
        {
            for (int n = 0; n < Count; n++)
                this[n].position = n;
        }

        public int GetIndex(string name)
        {
            for (int n = 0; n < Count; n++)
            {
                CBook br = this[n];
                if (br.name == name)
                    return n;
            }
            return -1;
        }

        public int LoadFromIni()
        {
            Clear();
            List<string> bl = CListBook.iniFile.ReadKeyList("book");
            foreach (string name in bl)
            {
                CBook br = new CBook(name);
                br.LoadFromIni();
                Add(br);
            }
            return bl.Count;
        }

        public List<CBook> GetTour()
        {
            List<CBook> bl = new List<CBook>();
            foreach (CBook b in this)
                if ((b.IsPlayable()) && (b.tournament > 0))
                    bl.Add(b);
            return bl;
        }

        public CBook GetBookRnd()
        {
            List<CBook> bl = GetTour();
            if (bl.Count == 0)
                return null;
            return bl[rnd.Next(bl.Count)];
        }

        public CBook GetBookByName(string name)
        {
            if (Count == 0)
                return null;
            if (name == "Random")
                return GetBookRnd();
            foreach (CBook br in this)
                if (br.name.ToLower() == name.ToLower())
                    return br;
            return null;
        }

        public void SaveToIni()
        {
            iniFile.DeleteKey("book");
            foreach (CBook b in this)
                b.SaveToIni();
            iniFile.Save();
        }

        public CBook NextTournament(CBook b, bool rotate = true, bool back = false)
        {
            SortElo();
            int i = GetIndex(b.name);
            for (int n = 0; n < Count - 1; n++)
            {
                if (back)
                    i--;
                else
                    i++;
                if (rotate)
                    i = (i + Count) % Count;
                else
                    if ((i < 0) || (i >= Count))
                    return null;
                b = this[i];
                if (b.tournament > 0)
                    break;
            }
            return b;
        }

        bool ContainBF(string bp)
        {
            foreach (CBook b in this)
                if (b.ContainBP(bp))
                    return true;
            return false;
        }

        public void SortPosition(CBook book)
        {
            SortElo();
            FillPosition();
            int position = book.position;
            foreach (CBook b in this)
                b.position = Math.Abs(position - b.position);
            Sort(delegate (CBook b1, CBook b2)
            {
                return b1.position - b2.position;
            });
        }

        public void SortElo()
        {
            Sort(delegate (CBook b1, CBook b2)
            {
                int result = b2.Elo - b1.Elo;
                if (result != 0)
                    return result;
                result = b2.history.EloAvg() - b1.history.EloAvg();
                if (result != 0)
                    return result;
                return String.Compare(b1.name, b2.name, comparisonType: StringComparison.OrdinalIgnoreCase);
            });
        }

        void TryAdd(string bf, string dir, string fn)
        {
            string bp = $@"{dir}\{fn}";
            FileInfo fi = new FileInfo(bp);
            if (string.IsNullOrEmpty(bf))
                return;
            if (ContainBF(bp))
                return;
            if (!string.Equals(fi.Extension, $".{dir}", StringComparison.OrdinalIgnoreCase))
                return;
            string option = $@"name book_file value {bp}";
            CBook b = new CBook();
            b.fileReader = bf;
            b.options.Add(option);
            b.name = b.GetName();
            DeleteBook(b.name);
            Add(b);
        }

        void TryDel(string dir)
        {
            for (int n = Count - 1; n >= 0; n--)
            {
                CBook book = this[n];
                if (book.arguments.IndexOf(dir) == 0)
                    if (!book.FileExists() || !book.ParametersExists())
                        RemoveAt(n);
            }
        }

        void Update(string dir, string br)
        {
            TryDel(dir);
            string path = $@"Books\{dir}";
            string[] arrBooks = Directory.GetFiles(path);
            foreach (string b in arrBooks)
                TryAdd(br, dir, Path.GetFileName(b));
        }

        public void Update()
        {
            foreach (CReader db in FormChess.readerList)
                Update(db.dir, db.bookReader);
            SaveToIni();
        }

        public string GetName(string name)
        {
            if (GetBookByName(name) == null)
                return name;
            int i = 1;
            while (true)
            {
                string name2 = $"{name} ({++i})";
                if (GetBookByName(name2) == null)
                    return name2;
            }
        }

    }

}
