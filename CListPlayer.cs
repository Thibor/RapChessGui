using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{

	public class CPlayer : CElement
	{
		public bool humanElo = false;
		public CBook book = null;
		public CEngine engine = null;
		public int tournament = 1;
		public CLimitValue levelValue = new CLimitValue();

		public string BookName
		{
			get
			{
				if (book == null)
					return Global.none;
				return book.name;
			}
			set
			{
				book = FormChess.bookList.GetBookByName(value);
			}
		}

		public string EngineName
		{
			get
			{
				if (engine == null)
					return Global.none;
				return engine.name;
			}
			set
			{
				engine = FormChess.engineList.GetEngineByName(value);
			}
		}

		public CPlayer()
		{
            levelValue.limit = CLimit.infinite;
        }

		public CPlayer(string n)
		{
			name = n;
		}

		public void AddElo(int e)
		{
			history.AddElo(e);
			if (IsComputer())
				SaveToIni();
		}

		public int GetEloLess()
		{
			int result = Convert.ToInt32(Math.Round(Elo / 50.0)) * 50 - 50;
			if (result < CElo.eloMin)
				result = CElo.eloMin;
			return result;
		}

		public int GetEloMore()
		{
			int result = Convert.ToInt32(Math.Round(Elo / 50.0)) * 50 + 50;
			if (result > CElo.eloMax)
				result = CElo.eloMax;
			return result;
		}

		public string Check()
		{
			if (name == Global.human)
				return string.Empty;
			if (engine == null)
				return $"Please select {name} engine";
			if (!engine.FileExists())
				return $"Engine file {engine.file} not exists";
			if (!engine.IsPlayableProtocol())
				return $"Please setup engine {engine.name} protocol";
			if (book == null)
				return String.Empty;
			if (!book.FileExists())
				return $"Book file {book.fileReader} not exists";
			return string.Empty;
		}

		public bool Check(out string msg)
		{
			msg = Check();
			return msg == String.Empty;
		}

		public int GetDeltaElo()
		{
			return Elo - history.EloAvg();
		}

		public void SetTournament(int t)
		{
			tournament = IsHuman() ? 0 : t;
		}

		public bool SetTournament(bool tb)
		{
			tb = IsComputer() & tb;
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

		public bool IsComputer()
		{
			return engine != null;
		}

		public bool IsHuman()
		{
			return engine == null;
		}

		public bool IsPuzzle()
		{
			return name == Global.puzzle;
		}

		public bool IsPlayable()
		{
			if (engine == null)
				return false;
			if (!engine.IsPlayable(levelValue.limit))
				return false;
			if ((book != null) && !book.IsPlayable())
				return false;
			return true;
		}

		public void SetPlayer(string name)
		{
			CPlayer p = FormChess.playerList.GetPlayerByName(name);
			if (p != null)
			{
				tournament = p.tournament;
				EngineName = p.EngineName;
				BookName = p.BookName;
				Elo = p.Elo;
				levelValue.limit = p.levelValue.limit;
				levelValue.baseVal = p.levelValue.baseVal;
				history.Assign(p.history);
			}
		}

		public void LoadFromIni()
		{
			tournament = CListPlayer.iniFile.ReadInt($"player>{name}>tournament", tournament);
			EngineName = CListPlayer.iniFile.Read($"player>{name}>engine", Global.none);
			levelValue.SetLimit(CListPlayer.iniFile.Read($"player>{name}>mode", levelValue.GetLimit()));
			levelValue.baseVal = CListPlayer.iniFile.ReadInt($"player>{name}>value", levelValue.baseVal);
			BookName = CListPlayer.iniFile.Read($"player>{name}>book", Global.none);
			history.FromStr(CListPlayer.iniFile.Read($"player>{name}>history"));
		}

		public void SaveToIni()
		{
			if (history.Count == 0)
				history.Add(Global.elo);
			name = GetName();
			CListPlayer.iniFile.Write($"player>{name}>tournament", tournament);
			CListPlayer.iniFile.Write($"player>{name}>engine", EngineName);
			CListPlayer.iniFile.Write($"player>{name}>mode", levelValue.GetLimit());
			CListPlayer.iniFile.Write($"player>{name}>value", levelValue.baseVal);
			CListPlayer.iniFile.Write($"player>{name}>book", BookName);
			CListPlayer.iniFile.Write($"player>{name}>history", history, " ");
		}

		public string CreateName()
		{
			string n = Global.human;
			string b = string.Empty;
			string m = string.Empty;
			if (engine != null)
			{
				n = EngineName;
				m = levelValue.ShortName();
			}
			if (book != null)
				b = $" {CData.MakeShort(BookName)}";
			return $"{n}{b}{m}";
		}

		public string GetName()
		{
			if (name == string.Empty)
				name = CreateName();
			return name;
		}

	}

	public class CListPlayer : List<CPlayer>
	{
		public static CRapIni iniFile = new CRapIni(@"Ini\players.ini");

		public void AddPlayer(CPlayer p)
		{
			p.name = p.GetName();
			int index = GetIndex(p.name);
			if (index >= 0)
				this[index] = p;
			else
				Add(p);
		}

		public int GetIndex(string name)
		{
			for (int n = 0; n < Count; n++)
			{
				CPlayer user = this[n];
				if (user.name == name)
					return n;
			}
			return -1;
		}

		public CPlayer GetPlayerByName(string name)
		{
			foreach (CPlayer p in this)
				if (p.name.ToLower() == name.ToLower())
					return p;
			return null;
		}

		public CPlayer GetPlayerComputer()
		{
			SortElo();
			foreach (CPlayer p in this)
				if (p.IsComputer())
					return p;
			return null;
		}

		public CPlayer GetPlayerByElo(int elo)
		{
			CPlayer p = new CPlayer();
			int bstDel = 10000;
			foreach (CPlayer cp in this)
			{
				if(!cp.IsPlayable())
					continue;
				int curE = cp.Elo;
				int curDel = Math.Abs(elo - curE);
				if (bstDel > curDel)
				{
					bstDel = curDel;
					p = cp;
				}
			}
			return p;
		}

        public int Position(int elo)
        {
            int result = 1;
            foreach (CPlayer p in this)
                if (p.Elo > elo)
                    result++;
            return result;
        }

        public void SortElo()
		{
			Sort(delegate (CPlayer p1, CPlayer p2)
			{
				int result = p2.Elo - p1.Elo;
				if (result == 0)
					result = p2.history.EloAvg() - p1.history.EloAvg();
				return result;
			});
		}

		public void SortPosition(CPlayer player)
		{
			SortElo();
			FillPosition();
			int position = player.position;
			foreach (CPlayer p in this)
				p.position = Math.Abs(position - p.position);
			Sort(delegate (CPlayer p1, CPlayer p2)
			{
				return p1.position - p2.position;
			});
		}

		void CreateIni()
		{
			foreach (CEngine e in FormChess.engineList)
			{
				CPlayer p = new CPlayer();
				p.EngineName = e.name;
				p.Elo = e.Elo;
				p.BookName = CListBook.def;
				AddPlayer(p);
			}
			SaveToIni();
		}

		public int LoadFromIni()
		{
			Clear();
			List<string> pl = iniFile.ReadKeyList("player");
			foreach (string name in pl)
			{
				CPlayer p = new CPlayer(name);
				p.LoadFromIni();
				if (p.EngineName != Global.none)
					Add(p);
			}
			if (Count == 0)
				CreateIni();
			return Count;
		}

		public void DeletePlayer(string name)
		{
			iniFile.DeleteKey($"player>{name}");
			int i = GetIndex(name);
			if (i >= 0)
				RemoveAt(i);
		}

		public void SaveToIni()
		{
			iniFile.DeleteKey("player");
			for (int n = Count - 1; n >= 0; n--)
			{
				CPlayer p = this[n];
				if ((p.engine == null) || !p.engine.Exists())
					RemoveAt(n);
				else
					p.SaveToIni();
			}
			iniFile.Save();
		}

		public void SaveToIni(CBook book)
		{
			foreach (CPlayer p in this)
				if (p.book == book)
					p.SaveToIni();
		}

		public void SaveToIni(CEngine engine)
		{
			foreach (CPlayer p in this)
				if (p.engine == engine)
					p.SaveToIni();
		}

		public CPlayer NextTournament(CPlayer p, bool rotate = true, bool back = false)
		{
			SortElo();
			int i = GetIndex(p.name);
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
				p = this[i];
				if (p.tournament > 0)
					break;
			}
			return p;
		}

		public void SetEloDistance(CPlayer player)
		{
			SortElo();
			int elo = player.Elo;
			for (int n = 0; n < Count; n++)
				this[n].position = Math.Abs(elo - this[n].Elo);
			Sort(delegate (CPlayer p1, CPlayer p2)
			{
				return p1.position - p2.position;
			});
			FillPosition();
		}

		public void FillPosition()
		{
			for (int n = 0; n < Count; n++)
				this[n].position = n;
		}

		public string GetName(string name)
		{
			if (GetPlayerByName(name) == null)
				return name;
			int i = 1;
			while (true)
			{
				string name2 = $"{name} ({++i})";
				if (GetPlayerByName(name2) == null)
					return name2;
			}
		}

	}
}
