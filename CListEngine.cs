﻿using NSUci;
using RapIni;
using System;
using System.Collections.Generic;
using System.IO;

namespace RapChessGui
{
    public class CEngine : CElement
    {
        public bool modeStandard = false;
        public bool modeTime = false;
        public bool modeDepth = false;
        public bool modeTournament = false;
        public bool modeNodes = false;
        public bool modeInfinite = false;
        public bool modeSearchmoves = false;
        public bool modeElo = false;
        public bool modeFen = false;
        public int tournament = 1;
        public int eloMax = 0;
        public int eloOpt = 0;
        public double depth = 0;
        public double nps = 0;
        public string file = Global.none;
        public string folder = Global.none;
        public string arguments = String.Empty;
        public CProtocol protocol = CProtocol.auto;
        public double accuracy = 0;
        public double test = 0;
        public DateTime DTAccuracy = new DateTime(0);
        public DateTime DT = DateTime.Now;
        public List<string> options = new List<string>();
        public CError eMove = new CError();
        public CError eTime = new CError();

        public string Protocol
        {
            get
            {
                return CData.ProtocolToStr(protocol);
            }
            set
            {
                protocol = CData.StrToProtocol(value);
            }
        }

        public CEngine()
        {

        }

        public CEngine(string n)
        {
            name = n;
        }

        public void LoadFromIni()
        {
            eloMax = CListEngine.iniFile.ReadInt($"engine>{name}>eloMax", eloMax);
            tournament = CListEngine.iniFile.ReadInt($"engine>{name}>tournament", tournament);
            modeElo = CListEngine.iniFile.ReadBool($"engine>{name}>modeElo", modeElo);
            modeFen = CListEngine.iniFile.ReadBool($"engine>{name}>modeFen", modeFen);
            modeStandard = CListEngine.iniFile.ReadBool($"engine>{name}>modeStandard", modeStandard);
            modeTime = CListEngine.iniFile.ReadBool($"engine>{name}>modeTime", modeTime);
            modeDepth = CListEngine.iniFile.ReadBool($"engine>{name}>modeDepth", modeDepth);
            modeTournament = CListEngine.iniFile.ReadBool($"engine>{name}>modeTournament", modeTournament);
            modeNodes = CListEngine.iniFile.ReadBool($"engine>{name}>modeNodes", modeNodes);
            modeInfinite = CListEngine.iniFile.ReadBool($"engine>{name}>modeInfinite", modeInfinite);
            modeSearchmoves = CListEngine.iniFile.ReadBool($"engine>{name}>modeSearchmoves", modeSearchmoves);
            file = CListEngine.iniFile.Read($"engine>{name}>file", file);
            folder = CListEngine.iniFile.Read($"engine>{name}>folder", folder);
            Protocol = CListEngine.iniFile.Read($"engine>{name}>protocol", Protocol);
            arguments = CListEngine.iniFile.Read($"engine>{name}>parameters");
            options = CListEngine.iniFile.ReadListStr($"engine>{name}>options");
            accuracy = CListEngine.iniFile.ReadDouble($"engine>{name}>accuracy", accuracy);
            test = CListEngine.iniFile.ReadDouble($"engine>{name}>test", test);
            depth = CListEngine.iniFile.ReadDouble($"engine>{name}>depth", depth);
            nps = CListEngine.iniFile.ReadDouble($"engine>{name}>nps", nps);
            DT = CListEngine.iniFile.ReadDateTime($"engine>{name}>DT", DT);
            DTAccuracy = CListEngine.iniFile.ReadDateTime($"engine>{name}>eloAccDT", DTAccuracy);
            history.FromStr(CListEngine.iniFile.Read($"engine>{name}>history"));
            eMove.LoadFromStr(CListEngine.iniFile.Read($"engine>{name}>eMove"));
            eTime.LoadFromStr(CListEngine.iniFile.Read($"engine>{name}>eTime"));
        }

        public void SaveToIni()
        {
            if (history.Count == 0)
                history.Add(Global.elo);
            SetUniqueName();
            CListEngine.iniFile.Write($"engine>{name}>eloMax", eloMax);
            CListEngine.iniFile.Write($"engine>{name}>tournament", tournament);
            CListEngine.iniFile.Write($"engine>{name}>modeElo", modeElo);
            CListEngine.iniFile.Write($"engine>{name}>modeFen", modeFen);
            CListEngine.iniFile.Write($"engine>{name}>modeStandard", modeStandard);
            CListEngine.iniFile.Write($"engine>{name}>modeTime", modeTime);
            CListEngine.iniFile.Write($"engine>{name}>modeDepth", modeDepth);
            CListEngine.iniFile.Write($"engine>{name}>modeTournament", modeTournament);
            CListEngine.iniFile.Write($"engine>{name}>modeNodes", modeNodes);
            CListEngine.iniFile.Write($"engine>{name}>modeInfinite", modeInfinite);
            CListEngine.iniFile.Write($"engine>{name}>modeSearchmoves", modeSearchmoves);
            CListEngine.iniFile.Write($"engine>{name}>file", file);
            CListEngine.iniFile.Write($"engine>{name}>folder", folder);
            CListEngine.iniFile.Write($"engine>{name}>protocol", Protocol);
            CListEngine.iniFile.Write($"engine>{name}>parameters", arguments);
            CListEngine.iniFile.Write($"engine>{name}>options", options);
            CListEngine.iniFile.Write($"engine>{name}>accuracy", accuracy);
            CListEngine.iniFile.Write($"engine>{name}>test", test);
            CListEngine.iniFile.Write($"engine>{name}>depth", depth);
            CListEngine.iniFile.Write($"engine>{name}>nps", nps);
            CListEngine.iniFile.Write($"engine>{name}>DT", DT);
            CListEngine.iniFile.Write($"engine>{name}>eloAccDT", DTAccuracy);
            CListEngine.iniFile.Write($"engine>{name}>history", history, " ");
            CListEngine.iniFile.Write($"engine>{name}>eMove", eMove, " ");
            CListEngine.iniFile.Write($"engine>{name}>eTime", eTime, " ");
        }

        public void AddElo(int e)
        {
            history.AddElo(e);
            SaveToIni();
        }

        public void AddGame(bool em, bool et)
        {
            eMove.AddGame(em);
            eTime.AddGame(et);
            SaveToIni();
        }

        public int GetFileSize() {
            string path = GetPath();
            return File.Exists(path) ? (int)new FileInfo(path).Length : 0; 
        }

        public bool SupportLevel(CLimit l)
        {
            if ((protocol != CProtocol.uci) && (protocol != CProtocol.winboard))
                return false;
            switch (l)
            {
                case CLimit.standard:
                    if (protocol == CProtocol.winboard)
                        return modeStandard || modeTournament;
                    else
                        return modeStandard;
                case CLimit.depth:
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

        public bool IsPlayable(CLimit l)
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
            return Elo - history.EloAvg();
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

        public void SetUniqueName()
        {
            if (FormChess.engineList.NameExists(this, name) || string.IsNullOrEmpty(name))
                name = FormChess.engineList.CreateUniqueName(this);
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

    public class CListEngine : List<CEngine>
    {
        public const string def = "RapChessCs";
        public static CRapIni iniFile = new CRapIni(@"Ini\engines.ini");

        public void AddEngine(CEngine e)
        {
            e.SetUniqueName();
            int index = GetIndex(e.name);
            if (index >= 0)
                this[index] = e;
            else
                Add(e);
        }

        public int CountFolder(string folder)
        {
            int result = 0;
            foreach (CEngine e in this)
                if (e.folder == folder)
                    result++;
            return result;
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

        public CEngine GetEngineByDir(string dir)
        {
            foreach (CEngine e in this)
                if (e.folder.ToLower() == dir.ToLower())
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
                e = GetEngineByName(CListEngine.def);
                if (e != null)
                {
                    e.protocol = CProtocol.uci;
                    e.Elo = 2000;
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
                    e.Elo = 1000;
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
                    result = e2.history.EloAvg() - e1.history.EloAvg();
                return result;
            });
        }

        public void SortDT()
        {
            Sort(delegate (CEngine e1, CEngine e2)
            {
                if (e1.DTAccuracy == e2.DTAccuracy)
                    return 0;
                return e1.DTAccuracy > e2.DTAccuracy ? 1 : -1;
            });
        }

        public void SortEloDistance(int elo)
        {
            Sort(delegate (CEngine e1, CEngine e2)
            {
                return Math.Abs(elo-e1.Elo) - Math.Abs(elo-e2.Elo);
            });
        }

        public void SortSize()
        {
            Sort(delegate (CEngine e1, CEngine e2)
            {
                return e1.GetFileSize() - e2.GetFileSize();
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

        public int Position(int elo)
        {
            int result = 1;
            foreach (CEngine e in this)
                if (e.Elo > elo)
                    result++;
            return result;
        }

        public bool NameExists(CEngine engine, string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            foreach (CEngine e in this)
                if ((e != engine) && (e.name == name))
                    return true;
            return false;
        }

        public string CreateUniqueName(CEngine engine)
        {
            string name = engine.CreateName();
            string result = name;
            int i = 1;
            while (NameExists(engine, result))
                result = $"{name} ({++i})";
            return result;
        }

        public void DeleteUnaplayable()
        {
            for (int n = Count - 1; n >= 0; n--)
            {
                CEngine e = this[n];
                if (!e.IsPlayable())
                    RemoveAt(n);
            }
            SaveToIni();
        }


    }

}
