using NSUci;
using RapIni;
using System;
using System.Collections.Generic;
using System.IO;

namespace RapChessGui
{
	public class CEngine : CElement
	{
		public bool modeStandard = true;
		public bool modeTime = true;
		public bool modeDepth = true;
		public bool modeTournament = true;
		public bool modeNodes = true;
		public bool modeInfinite = true;
		public bool modeElo = true;
		public int tournament = 1;
		public string file = Global.none;
		public string folder = Global.none;
		public string arguments = String.Empty;
		public List<string> options = new List<string>();
		public CProtocol protocol = CProtocol.auto;
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
			modeElo = CEngineList.iniFile.ReadBool($"engine>{name}>modeElo", modeElo);
			modeStandard = CEngineList.iniFile.ReadBool($"engine>{name}>modeStandard", modeStandard);
			modeTime = CEngineList.iniFile.ReadBool($"engine>{name}>modeTime", modeTime);
			modeDepth = CEngineList.iniFile.ReadBool($"engine>{name}>modeDepth", modeDepth);
			modeTournament = CEngineList.iniFile.ReadBool($"engine>{name}>modeTournament", modeTournament);
			modeNodes = CEngineList.iniFile.ReadBool($"engine>{name}>modeNodes", modeNodes);
			modeInfinite = CEngineList.iniFile.ReadBool($"engine>{name}>modeInfinite", modeInfinite);
			file = CEngineList.iniFile.Read($"engine>{name}>file", file);
			folder = CEngineList.iniFile.Read($"engine>{name}>folder", folder);
			protocol = CData.StrToProtocol(CEngineList.iniFile.Read($"engine>{name}>protocol", "Uci"));
			arguments = CEngineList.iniFile.Read($"engine>{name}>parameters");
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
			CEngineList.iniFile.Write($"engine>{name}>modeElo", modeElo);
			CEngineList.iniFile.Write($"engine>{name}>modeStandard", modeStandard);
			CEngineList.iniFile.Write($"engine>{name}>modeTime", modeTime);
			CEngineList.iniFile.Write($"engine>{name}>modeDepth", modeDepth);
			CEngineList.iniFile.Write($"engine>{name}>modeTournament", modeTournament);
			CEngineList.iniFile.Write($"engine>{name}>modeNodes", modeNodes);
			CEngineList.iniFile.Write($"engine>{name}>modeInfinite", modeInfinite);
			CEngineList.iniFile.Write($"engine>{name}>file", file);
			CEngineList.iniFile.Write($"engine>{name}>folder", folder);
			CEngineList.iniFile.Write($"engine>{name}>protocol", CData.ProtocolToStr(protocol));
			CEngineList.iniFile.Write($"engine>{name}>parameters", arguments);
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
			return IsPlayableProtocol();
		}

		public bool IsPlayable(CLevel l)
		{
			if (!IsPlayable())
				return false;
			return SupportLevel(l);
		}

		public bool IsPlayableMode()
		{
			return modeDepth || modeStandard || modeTime || modeTournament;
		}

		public bool IsPlayableProtocol()
		{
			return (protocol == CProtocol.uci) || (protocol == CProtocol.winboard);
		}

		public string CreateName()
		{
			return CData.TextBeauty(Path.GetFileNameWithoutExtension(file));
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
			return folder == "Auto";
		}

		public bool Exists()
		{
			return FormChess.engineList.GetEngineByName(name) != null;
		}

		public bool FileExists()
		{
			if (file == Global.none)
				return true;
			return File.Exists(GetFileName());
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
			if (folder == Global.none)
				return $@"Engines\{file}";
			else
				return $@"Engines\{folder}\{file}";
		}

		public string GetPath()
		{
			return $@"{AppDomain.CurrentDomain.BaseDirectory}{GetFileName()}";
		}

		public string GetName()
		{
			if (!FormChess.engineList.IsUniqueName(this,name))
				return FormChess.engineList.CreateUniqueName(this);
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

		public int CountAuto()
		{
			int result = 0;
			foreach (CEngine e in this)
				if (e.protocol == CProtocol.auto)
					result++;
			return result;
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
			return engine == null ? Global.none : engine.name;
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

		public CEngine GetEngineAuto()
		{
			foreach (CEngine e in this)
				if (e.protocol == CProtocol.auto)
					return e;
			return null;
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
			List<string> list = CData.ListExe(@"Engines\Auto");
			foreach (string file in list)
			{
				CEngine engine = GetEngineByFile(file);
				if (engine == null)
				{
					engine = new CEngine();
					Add(engine);
					engine.file = file;
					engine.folder = "Auto";
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
				CEngine e;
				e = GetEngineByName(CEngineList.def);
				if (e != null)
				{
					e.protocol = CProtocol.uci;
					e.elo = "2000";
					e.SaveToIni();
				}
				e = GetEngineByName("RapSimpleCs");
				if (e != null)
				{
					e.protocol = CProtocol.uci;
					e.modeElo = false;
					e.SaveToIni();
				}
				e = GetEngineByName("RapShortCs");
				if (e != null)
				{
					e.protocol = CProtocol.uci;
					e.elo = "1000";
					e.modeElo = false;
					e.SaveToIni();
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
				if (string.IsNullOrEmpty(engine.name))
				{
					engine.name = CreateUniqueName(engine);
					engine.SaveToIni();
				}
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


		public bool IsUniqueName(CEngine engine,string name)
		{
			if (string.IsNullOrEmpty(name))
				return true;
			foreach (CEngine e in this)
				if ((e != engine) && (e.name == name))
					return false;
			return true;
		}

		public string CreateUniqueName(CEngine engine)
		{
			string name = engine.CreateName();
			string result = name;
			int i = 1;
			while (!IsUniqueName(engine,result))
				result = $"{name} ({++i})";
			return result;
		}

	}

}
