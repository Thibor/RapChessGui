using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using NSUci;
using RapIni;

namespace RapChessGui
{
	public class CEngine : CElement
	{
		public bool modeStandard = true;
		public bool modeTime = true;
		public bool modeDepth = true;
		public bool modeTournament = true;
		public bool modeNodes = true;
		public int position = 0;
		public int tournament = 1;
		public string name = String.Empty;
		public string file = String.Empty;
		public string parameters = String.Empty;
		public List<string> options = new List<string>();
		public CProtocol protocol = CProtocol.uci;
		public CHisElo hisElo = new CHisElo();

		public CEngine()
		{

		}

		public CEngine(string n)
		{
			name = n;
		}

		public void LoadFromIni()
		{
			tournament = CEngineList.iniFile.ReadInt($"engine>{name}>tournament", tournament);
			modeStandard = CEngineList.iniFile.ReadBool($"engine>{name}>modeStandard", modeStandard);
			modeTime = CEngineList.iniFile.ReadBool($"engine>{name}>modeTime", modeTime);
			modeDepth = CEngineList.iniFile.ReadBool($"engine>{name}>modeDepth", modeDepth);
			modeTournament = CEngineList.iniFile.ReadBool($"engine>{name}>modeTournament", modeTournament);
			modeNodes = CEngineList.iniFile.ReadBool($"engine>{name}>modeTournament", modeNodes);
			file = CEngineList.iniFile.Read($"engine>{name}>file", Global.none);
			protocol = CData.StrToProtocol(CEngineList.iniFile.Read($"engine>{name}>protocol", "Uci"));
			parameters = CEngineList.iniFile.Read($"engine>{name}>parameters");
			options = CEngineList.iniFile.ReadList($"engine>{name}>options");
			elo = CEngineList.iniFile.Read($"engine>{name}>elo", elo);
			hisElo.LoadFromStr(CEngineList.iniFile.Read($"engine>{name}>history"));
		}

		public void SaveToIni()
		{
			name = GetName();
			if (hisElo.Count == 0)
			{
				hisElo.AddValue(Elo);
				hisElo.AddValue(Elo);
			}
			CEngineList.iniFile.Write($"engine>{name}>tournament", tournament);
			CEngineList.iniFile.Write($"engine>{name}>modeStandard", modeStandard);
			CEngineList.iniFile.Write($"engine>{name}>modeTime", modeTime);
			CEngineList.iniFile.Write($"engine>{name}>modeDepth", modeDepth);
			CEngineList.iniFile.Write($"engine>{name}>modeTournament", modeTournament);
			CEngineList.iniFile.Write($"engine>{name}>modeNodes", modeNodes);
			CEngineList.iniFile.Write($"engine>{name}>file", file);
			CEngineList.iniFile.Write($"engine>{name}>protocol", CData.ProtocolToStr(protocol));
			CEngineList.iniFile.Write($"engine>{name}>parameters", parameters);
			CEngineList.iniFile.Write($"engine>{name}>options", options);
			CEngineList.iniFile.Write($"engine>{name}>elo", elo);
			CEngineList.iniFile.Write($"engine>{name}>history", hisElo.SaveToStr());
		}

		public void NewElo(int e)
		{
			hisElo.AddValue(e);
			elo = e.ToString();
			SaveToIni();
		}

		public bool SupportLevel(CLevel l)
		{
			if ((protocol != CProtocol.uci) && (protocol != CProtocol.winboard))
				return false;
			switch (l)
			{
				case CLevel.standard:
					return modeStandard;
				case CLevel.depth:
					return modeDepth;
				default:
					{
						if (protocol == CProtocol.winboard)
							if (modeTime || modeTournament)
								return true;
						return modeTime;
					}
			}
		}

		public bool IsPlayable()
		{
			if (!FileExists())
				return false;
			return SupportProtocol();
		}

		public bool IsPlayable(CLevel l)
		{
			if (!IsPlayable())
				return false;
			return SupportLevel(l);
		}

		public bool SupportProtocol()
		{
			if ((protocol != CProtocol.uci) && (protocol != CProtocol.winboard))
				return false;
			return true;
		}

		public string CreateName()
		{
			TextInfo ti = new CultureInfo("en-US", false).TextInfo;
			string p = Path.GetFileNameWithoutExtension(file);
			return ti.ToTitleCase(p);
		}

		public string GetOption(string name, string def)
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

		public bool IsAuto()
		{
			return file.Contains(@"\");
		}

		public bool Exists()
		{
			return FormChess.engineList.GetEngineByName(name) != null;
		}

		public bool FileExists()
		{
			if (file == Global.none)
				return true;
			return File.Exists($@"Engines\{file}");
		}

		public int GetDeltaElo()
		{
			return Elo - hisElo.EloAvg(Elo);
		}

		public string GetFile()
		{
			if (FileExists())
				return file;
			return Global.none;
		}

		public string GetFileName()
		{
			return $@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{file}";
		}

		public string GetName()
		{
			if (name == "")
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

	public class CEngineList : List<CEngine>
	{
		public const string def = "RapChessCs";
		public static CRapIni iniFile = new CRapIni(@"Ini\engines.ini");

		public void AddEngine(CEngine e)
		{
			e.name = e.GetName();
			int index = GetIndex(e.name);
			if (index >= 0)
				this[index] = e;
			else
				Add(e);
		}

		public void DeleteEngine(string name)
		{
			iniFile.DeleteKey($"engine>{name}");
			int i = GetIndex(name);
			if (i >= 0)
				RemoveAt(i);
		}

		public string GetName(string name)
		{
			if (GetEngineByName(name) == null)
				return name;
			int i = 1;
			while (true)
			{
				string name2 = $"{name} ({++i})";
				if (GetEngineByName(name2) == null)
					return name2;
			}
		}

		public string GetEngineName()
		{
			CEngine engine = GetEngineByName(def);
			if (engine == null)
			{
				SortElo();
				engine = GetEngineByIndex(0);
			}
			return engine == null ? Global.none:engine.name;
		}

		public CEngine GetEngineByName(string name)
		{
			foreach (CEngine e in this)
				if (e.name.ToLower() == name.ToLower())
					return e;
			return null;
		}

		public CEngine GetEngineByFile(string file)
		{
			foreach (CEngine e in this)
				if (e.file.ToLower() == file.ToLower())
					return e;
			return null;
		}

		public CEngine GetEngineByIndex(int index)
		{
			if ((index < 0) || (index >= Count))
				return null;
			return this[index];
		}

		public int GetIndex(string name)
		{
			for (int n = 0; n < Count; n++)
			{
				CEngine engine = this[n];
				if (engine.name == name)
					return n;
			}
			return -1;
		}

		public void AutoUpdate()
		{
			bool reset = Count == 0;
			foreach (string fn in CData.fileEngineAuto)
			{
				string name = Path.GetFileNameWithoutExtension(fn);
				string file = $@"Auto\{fn}";
				CEngine engine = GetEngineByFile(file);
				if (engine == null)
				{
					engine = GetEngineByName(name);
					if (engine == null)
					{
						engine = new CEngine(name);
						Add(engine);
					}
					engine.file = file;
					engine.name = engine.GetName();
					engine.SaveToIni();
				}
			}
			for (int n = Count - 1; n >= 0; n--)
			{
				CEngine e = this[n];
				if (e.IsAuto() && !e.FileExists())
					DeleteEngine(e.name);
			}
			if (reset)
			{
				CEngine e = GetEngineByName(CEngineList.def);
				if (e != null)
				{
					e.elo = "2000";
					e.SaveToIni();
					if (e != null)
						for (int i = 1; i < 10; i++)
						{
							int n = i * 10;
							CEngine engine = new CEngine($"{CEngineList.def} {n}");
							engine.file = e.file;
							engine.elo = (n * 20).ToString();
							engine.options.Add($"name SkillLevel value {n}");
							engine.SaveToIni();
							Add(engine);
						}
				}
			}
		}

		public int LoadFromIni()
		{
			Clear();
			List<string> en = iniFile.ReadKeyList("engine");
			foreach (string name in en)
			{
				CEngine engine = new CEngine(name);
				engine.LoadFromIni();
				Add(engine);
			}
			AutoUpdate();
			return en.Count;
		}

		public CEngine NextTournament(CEngine e, bool rotate = true, bool back = false)
		{
			SortElo();
			int i = GetIndex(e.name);
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
				e = this[i];
				if (e.tournament > 0)
					break;
			}
			return e;
		}

		public void SaveToIni()
		{
			iniFile.DeleteKey("engine");
			foreach (CEngine e in this)
				e.SaveToIni();
			iniFile.Save();
		}

		public void SortElo()
		{
			Sort(delegate (CEngine e1, CEngine e2)
			{
				int result = e2.Elo - e1.Elo;
				if (result == 0)
					result = e2.hisElo.EloAvg() - e1.hisElo.EloAvg();
				return result;
			});
		}

		public void SetEloDistance(CEngine engine)
		{
			SortElo();
			for (int n = 0; n < Count; n++)
				this[n].position = Math.Abs(engine.Elo - this[n].Elo);
			Sort(delegate (CEngine e1, CEngine e2)
			{
				return e1.position - e2.position;
			});
			FillPosition();
		}

		public void FillPosition()
		{
			for (int n = 0; n < Count; n++)
				this[n].position = n;
		}

	}

}
