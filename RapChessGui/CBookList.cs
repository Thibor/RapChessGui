
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
		public string file = String.Empty;
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
			if (file == Global.none)
				return true;
			return File.Exists($@"Books\{file}");
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
			return $@"{AppDomain.CurrentDomain.BaseDirectory}Books\{file}";
		}

		public void LoadFromIni()
		{
			file = CBookList.iniFile.Read($"book>{name}>exe");
			arguments = CBookList.iniFile.Read($"book>{name}>parameters");
			options = CBookList.iniFile.ReadList($"book>{name}>options");
			elo = CBookList.iniFile.ReadInt($"book>{name}>elo", elo);
			hisElo.LoadFromStr(CBookList.iniFile.Read($"book>{name}>history"));
			tournament = CBookList.iniFile.ReadInt($"book>{name}>tournament", tournament);
		}

		public void SaveToIni()
		{
			name = GetName();
			CBookList.iniFile.Write($"book>{name}>exe", file);
			CBookList.iniFile.Write($"book>{name}>parameters", arguments);
			CBookList.iniFile.Write($"book>{name}>options", options);
			CBookList.iniFile.Write($"book>{name}>elo", elo);
			CBookList.iniFile.Write($"book>{name}>history", hisElo.SaveToStr());
			CBookList.iniFile.Write($"book>{name}>tournament", tournament);
		}


		public int GetDeltaElo()
		{
			return elo - hisElo.EloAvg(elo);
		}

		public void NewElo(int e)
		{
			hisElo.AddValue(e);
			elo = e;
			SaveToIni();
		}

		public bool GetBFFromOption(out string bf)
		{
			bf = string.Empty;
			foreach (string o in options)
				if (o.IndexOf("name book_file value ") == 0)
				{
					bf = o.Substring(21);
					return true;
				}
			return false;
		}

		public string CreateName()
		{
			string n = CData.MakeShort(Path.GetFileNameWithoutExtension(file));
			if (GetBFFromOption(out string bf))
			{
				TextInfo ti = new CultureInfo("en-US", false).TextInfo;
				bf = Path.GetFileNameWithoutExtension(bf);
				return $"{n} {ti.ToTitleCase(bf)}";
			}
			return n;
		}

		public string GetName()
		{
			if (name == string.Empty)
				return CreateName();
			return name;
		}

	}

	public class CBookList : List<CBook>
	{
		public static string def = "BRM Bigmem";
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

		public int GetOptElo(double index)
		{
			int min = CModeTournamentB.eloRange;
			int max = CModeTournamentB.eloAvg;
			if (index < 0)
				index = 0;
			if (index >= Count)
				index = Count - 1;
			int range = max - min;
			index = Count - index;
			return min + Convert.ToInt32((range * (index + 1)) / (Count + 2));
		}

		public int LoadFromIni()
		{
			Clear();
			List<string> bl = CBookList.iniFile.ReadKeyList("book");
			foreach (string name in bl)
			{
				CBook br = new CBook(name);
				br.LoadFromIni();
				Add(br);
			}
			return bl.Count;
		}

		public CBook GetBookByName(string name)
		{
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
				int result = b2.elo - b1.elo;
				if (result != 0)
					return result;
				result = b2.hisElo.EloAvg() - b1.hisElo.EloAvg();
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
			b.file = bf;
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
