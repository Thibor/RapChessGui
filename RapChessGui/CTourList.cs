using System;
using System.IO;
using System.Collections.Generic;

namespace RapChessGui
{
	public class CTour
	{
		public string w;
		public string b;
		public string r = "d";
		public bool first;

		public CTour(string tw, string tb, string tr, bool tf)
		{
			w = tw;
			b = tb;
			r = tr;
			first = tf;
		}

		public CTour(string s)
		{
			LoadFromString(s);
		}

		public void LoadFromString(string s)
		{
			string[] a = s.Split('#');
			w = a[0];
			b = a[1];
			if (a.Length > 2)
				r = a[2];
			if (a.Length > 3)
				first = a[3] == "f";
		}

		public string SaveToString()
		{
			string sf = first ? "f" : "s";
			return $"{w}#{b}#{r}#{sf}";
		}

	}

	public class CTourList : List<CTour>
	{
		readonly string path;

		public CTourList(string name)
		{
			path = $"{AppDomain.CurrentDomain.BaseDirectory}History\\{name}.tour";
			LoadFromFile();
		}

		public int CountGames(string p)
		{
			int result = 0;
			foreach (CTour t in this)
				if ((t.w == p) || (t.b == p))
					result++;
			return result;
		}

		public int LastGame(string p)
		{
			int f = Count;
			int s = Count;
			int c = 0;
			for (int n = Count - 1; n >= 0; n--)
			{
				c++;
				CTour t = this[n];
				if (t.w == p)
				{
					if (t.first)
					{
						if (f == Count)
						{
							f = c;
							if (s == Count)
								s = c;
						}
					}
					else if (s == Count)
						s = c;
				}
				if (t.b == p)
				{
					if (t.first)
					{
						if (s == Count)
							s = c;
					}
					else if (f == Count)
					{
						f = c;
						if (s == Count)
							s = c;
					}
				}
				if ((f < Count) && (s < Count))
					break;
			}
			return f + s >> 1;
		}

		public int CountGames(string p1, string p2, out int gw, out int gl, out int gd)
		{
			gw = 0;
			gl = 0;
			gd = 0;
			foreach (CTour t in this)
			{
				if ((t.w == p1) && (t.b == p2))
				{
					if (t.r == "d")
						gd++;
					if (t.r == "w")
						gw++;
					if (t.r == "b")
						gl++;
				}
				if ((t.w == p2) && (t.b == p1))
				{
					if (t.r == "d")
						gd++;
					if (t.r == "b")
						gw++;
					if (t.r == "w")
						gl++;
				}
			}
			return gw + gl + gd;
		}

		public int DeletePlayer(string p)
		{
			int c = Count;
			for (int n = Count - 1; n >= 0; n--)
			{
				CTour t = this[n];
				if ((t.w == p) || (t.b == p))
					RemoveAt(n);
			}
			SaveToFile();
			return c - Count;
		}

		public void LoadFromFile()
		{
			Clear();
			if (File.Exists(path))
				using (StreamReader file = new StreamReader(path))
				{
					string line;
					while ((line = file.ReadLine()) != null)
					{
						CTour t = new CTour(line);
						Add(t);
					}
				}
		}

		public void SetLimit(int limit)
		{
			if (Count > limit)
			{
				int remove = Math.Max(0, Count - limit);
				RemoveRange(0, remove);
				SaveToFile();
			}
		}

		public void SaveToFile()
		{
			using (StreamWriter file = new StreamWriter(path))
			{
				foreach (CTour t in this)
					file.WriteLine(t.SaveToString());
			}
		}

		public CEngine LastEngine()
		{
			string n = String.Empty;
			if (Count > 0)
				n = this[Count - 1].w;
			return FormChess.engineList.GetEngineByName(n);
		}

		public CPlayer LastPlayer()
		{
			string n = String.Empty;
			if (Count > 0)
				n = this[Count - 1].w;
			return FormChess.playerList.GetPlayerByName(n);
		}

		public void Write(string w, string b, string r, bool f)
		{
			if (w == b)
				return;
			CTour t = new CTour(w, b, r, f);
			Add(t);
			using (StreamWriter file = new StreamWriter(path, true))
				file.WriteLine(t.SaveToString());
		}

	}

}
