using NSChess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace RapChessGui
{

    public class CGamerBook : CProcessBuf
    {
        public bool optionSended = false;
        /// <summary>
        /// Query was send to book
        /// <summary>
        public bool isBookStarted = false;
        /// <summary>
        /// Is no move int the open book.
        /// </summary>
        public bool isBookFail = false;

        public void Reset()
        {
            optionSended = false;
            isBookStarted = false;
            isBookFail = false;
        }

    }

    public class CGamerEngine : CProcessBuf
    {
        /// <summary>
        /// The engine is already running.
        /// </summary>
        public bool isEngRunning = false;
        /// <summary>
        /// Creation of the protocol header is complete.
        /// </summary>
        public bool isPreparedUci = false;
        /// <summary>
        /// The position of the chess pieces has been sent to the winboard chess engine.
        /// </summary>
        public bool isPositionXb = false;
        /// <summary>
        /// Phase of prepare uci engine.
        /// </summary>
        public int phaseUci = 0;

        public void Reset()
        {
            isEngRunning = false;
            isPreparedUci = false;
            isPositionXb = false;
            phaseUci = 0;
        }
    }

    public class CGamer
    {
        public bool uciOk = false;
        public bool readyOk = false;
        /// <summary>
        /// Engine send score mate
        /// </summary>
        public bool mate;
        /// <summary>
        /// Count moves maked by book.
        /// </summary>
        public int countMovesBook;
        /// <summary>
        /// Count moves maked by engine.
        /// </summary>
        public int countMovesEngine;
        public CColor colorPlayer = CColor.none;
        public Color arrowColor = Colors.Green;
        public int arrowShift = 0;
        public int depthTotal;
        public int depthCount;
        public int msgPriority = 0;
        public int scoreI;
        public ulong infMs;
        public ulong nodes;
        public ulong nps;
        public ulong npsTotal;
        public ulong npsCount;
        public string strScore;
        public int depth;
        public int seldepth;
        public int multipv;
        int hash;
        int phase;
        public string ponder;
        public string pv;
        public string lastMove;
        public double timerStart;
        public Stopwatch timer = new Stopwatch();
        public CGamerBook gamerBook = new CGamerBook();
        public CGamerEngine gamerEngine = new CGamerEngine();
        public CBook book = null;
        public CEngine engine = null;
        public CPlayer player = new CPlayer();


        public int Hash
        {
            get
            {
                return hash;
            }
            set
            {
                if (value < 0)
                    value = 0;
                if (value > 1000)
                    value = 1000;
                hash = value;
            }
        }

        public CGamer(CColor color)
        {
            colorPlayer = color;
            InitNewGame();
        }

        public double DepthAvg()
        {
            if (depthCount == 0)
                return 0;
            return (double)depthTotal / depthCount;
        }

        public Bitmap GetBitmap(int height, out int width)
        {
            Bitmap bmp = GetBitmap();
            double ratio = (double)bmp.Width / bmp.Height;
            width = Convert.ToInt32(height * ratio);
            return bmp;
        }


        public Bitmap GetBitmap()
        {
            Bitmap bmp = FormChess.This.Icon.ToBitmap();
            if (engine == null)
                return bmp;
            string path = engine.GetFileName();
            if (!File.Exists(path))
                return bmp;
            string dir = Path.GetDirectoryName(path);
            string name = Path.GetFileNameWithoutExtension(path);
            string p = $@"{dir}\{name}.bmp";
            try
            {
                if (File.Exists(p))
                    return new Bitmap(p);
                string[] an = engine.name.Split();
                if (an.Length > 0)
                {
                    p = $@"{dir}\{an[0]}.bmp";
                    if (File.Exists(p))
                        return new Bitmap(p);
                }
                string[] filePaths = Directory.GetFiles(dir, "*.bmp");
                if (filePaths.Length == 1)
                    return new Bitmap(filePaths[0]);
                filePaths = Directory.GetFiles(dir);
                foreach (string fp in filePaths)
                {
                    string ext = Path.GetExtension(fp);
                    if ((ext == ".bmp") || (ext == ".jpg") || (ext == ".jpeg") || (ext == ".png") || (ext == ".gif"))
                        return new Bitmap(Image.FromFile(fp));
                }
            }
            catch (Exception ex)
            {
                FormChess.log.Add(ex.Message);
            }
            return Icon.ExtractAssociatedIcon(path).ToBitmap();
        }

        public List<string> GetMessages()
        {
            if (IsBookActive())
                return gamerBook.GetMessages();
            List<string> messages = gamerEngine.GetMessages();
            foreach (string m in messages)
                if (m.Contains("bestmove"))
                {
                    timer.Stop();
                    break;
                }
            return messages;
        }

        public bool IsBookActive() { return phase == 1; }

        public bool IsEngineActive() { return phase == 2; }

        public bool IsBookMove() { return gamerBook.isBookStarted && !gamerBook.isBookFail; }

        /// <summary>
        /// Gamer color is white
        /// </summary>
        public bool IsWhite()
        {
            return colorPlayer == CColor.white;
        }
        /// <summary>
        /// Gamer color is black
        /// </summary>
        public bool IsBlack()
        {
            return colorPlayer == CColor.black;
        }

        public bool IsHuman()
        {
            return player.IsHuman();
        }

        public bool IsComputer()
        {
            return player.IsComputer();
        }

        public void OptionsToEngine()
        {
            if (player.humanElo)
            {
                SendMessageToEngine("setoption name UCI_LimitStrength value true");
                SendMessageToEngine($"setoption name UCI_Elo value {FormChess.game.history.Last()}");
            }
            else
                foreach (string op in engine.options)
                    SendMessageToEngine($"setoption {op}");
        }

        void OptionsToBook()
        {
            foreach (string op in book.options)
                SendMessageToBook($"book setoption {op}");
            if (book.options.Count > 0)
                SendMessageToBook("book optionend");
            gamerBook.optionSended = true;
        }

        public void NextPhaseUci()
        {
            switch (gamerEngine.phaseUci)
            {
                case 0:
                    gamerEngine.phaseUci++;
                    SendMessageToEngine("uci");
                    break;
                case 1:
                    if (uciOk)
                    {
                        gamerEngine.phaseUci++;
                        OptionsToEngine();
                        SendMessageToEngine("isready");
                    }
                    break;
                case 2:
                    if (readyOk)
                    {
                        readyOk = false;
                        gamerEngine.phaseUci++;
                        SendMessageToEngine("ucinewgame");
                        SendMessageToEngine("isready");
                    }
                    break;
                case 3:
                    gamerEngine.isPreparedUci = readyOk;
                    break;
            }
        }

        public void NextPahseXb()
        {
            if (!gamerEngine.isPreparedUci)
            {
                SendMessageToEngine("xboard");
                gamerEngine.isPreparedUci = true;
                XbGo();
            }
        }

        public void Restart()
        {
            gamerBook.Restart();
            gamerEngine.Restart();
        }

        public void EngineStop()
        {
            if (engine?.protocol == CProtocol.uci)
                SendMessageToEngine("stop");
            else
                SendMessageToEngine("?");
        }

        public void InitNewGame()
        {
            phase=0;
            mate = false;
            gamerBook.Reset();
            gamerEngine.Reset();
            hash = 0;
            infMs = 0;
            countMovesBook = 0;
            countMovesEngine = 0;
            nodes = 0;
            nps = 0;
            npsTotal = 0;
            npsCount = 0;
            depthTotal = 0;
            depthCount = 0;
            timerStart = 0;
            timer.Reset();
            InitNextMove();
        }

        public void InitNextMove()
        {
            multipv = 1;
            depth = 0;
            msgPriority = 0;
            seldepth = 0;
            scoreI = 0;
            lastMove = String.Empty;
            ponder = String.Empty;
            pv = String.Empty;
            strScore = String.Empty;
            gamerBook.isBookStarted = false;
            gamerBook.isBookFail = false;
            gamerEngine.isEngRunning = false;
        }

        public void MoveDone()
        {
            if (gamerBook.isBookStarted && !gamerBook.isBookFail)
                countMovesBook++;
            else
            {
                countMovesEngine++;
                if (!mate && (depth > 0) && (Math.Abs(scoreI) < 500))
                {
                    depthCount++;
                    depthTotal += depth;
                    engine.depth = (engine.depth * 99.0 + depth) / 100.0;
                }
                if (nps > 0)
                {
                    npsCount++;
                    npsTotal += nps;
                    engine.nps = (engine.nps * 99.0 + nps) / 100.0;
                    if ((npsTotal > (ulong.MaxValue >> 1)) && ((npsCount & 1) == 0))
                    {
                        npsTotal >>= 1;
                        npsCount >>= 1;
                    }
                }
            }
        }

        public string GetName()
        {
            if (player.name == String.Empty)
                return IsWhite() ? "White" : "Black";
            else
                return player.name;
        }

        public ulong GetNpsAvg()
        {
            return (npsTotal + nps) / (npsCount + 1);
        }

        public string GetEngineName()
        {
            return engine == null ? Global.none : engine.name;
        }

        /// <summary>
        /// Start or prepare engine or book.
        /// </summary>
        public void TryStart()
        {
            if (player.IsComputer())
                if ((book != null) && (!gamerBook.isBookFail))
                {
                    if (!gamerBook.optionSended)
                        OptionsToBook();
                    if (!gamerBook.isBookStarted)
                    {
                        SendMessageToBook(FormChess.history.GetPosition());
                        SendMessageToBook("go");
                        gamerBook.isBookStarted = true;
                    }
                }
                else if (engine != null)
                    if (!gamerEngine.isPreparedUci)
                        EngPrepare();
                    else if (gamerEngine.isPreparedUci && !gamerEngine.isEngRunning)
                        EngMakeMove();
        }

        public void TimerStart()
        {

            timer.Start();
            timerStart = timer.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Prepare engine.
        /// </summary>
        void EngPrepare()
        {
            lastMove = String.Empty;
            if (engine.protocol == CProtocol.uci)
                NextPhaseUci();
            else
                NextPahseXb();
        }

        public int GetRemainingMs()
        {
            int v = Convert.ToInt32(player.levelValue.GetUciValue());
            int t = Convert.ToInt32(v - timer.Elapsed.TotalMilliseconds);
            return t < 1 ? 1 : t;
        }

        public string GetTimeXB(long ms)
        {
            DateTime dt = new DateTime();
            dt = dt.AddMilliseconds(ms);
            return dt.ToString("mm:ss");
        }

        void UciGo()
        {
            SendMessageToEngine(FormChess.history.GetPosition());
            if (player.levelValue.limit == CLimit.standard)
            {
                CGamer gw = FormChess.gamers.GamerWhite();
                CGamer gb = FormChess.gamers.GamerBlack();
                SendMessageToEngine($"go wtime {gw.GetRemainingMs()} btime {gb.GetRemainingMs()} winc 0 binc 0");
            }
            else
                SendMessageToEngine(player.levelValue.GetUci());
            TimerStart();
        }

        void XbGoTournament()
        {
            int ms = GetRemainingMs();
            SendMessageToEngine($"level 0 {GetTimeXB(ms)} 0");
        }

        void XbGoStandard()
        {
            if (engine.modeStandard)
            {
                CGamer gs = FormChess.gamers.GamerSec();
                SendMessageToEngine($"time {GetRemainingMs() / 10}");
                SendMessageToEngine($"otim {gs.GetRemainingMs() / 10}");
            }
            else
                XbGoTournament();
        }

        void XbGoTime()
        {
            int ms = player.levelValue.GetUciValue();
            if (engine.modeTime)
                SendMessageToEngine($"st {ms / 1000}");
            else
                SendMessageToEngine($"level 0 0 {ms / 1000}");
        }

        void XbGoDepth()
        {
            int d = player.levelValue.GetUciValue();
            SendMessageToEngine($"sd {d}");
        }

        void XbGo()
        {
            switch (player.levelValue.limit)
            {
                case CLimit.standard:
                    XbGoStandard();
                    break;
                case CLimit.depth:
                    XbGoDepth();
                    break;
                case CLimit.time:
                    XbGoTime();
                    break;
            }
        }

        /// <summary>
        /// Prepare or start engine when is his turn.
        /// </summary>
        public void EngMakeMove()
        {
            FormLogEngines.AddFen(FormChess.chess.GetFen());
            if (engine.protocol == CProtocol.uci)
                UciGo();
            else
            {
                if (gamerEngine.isPositionXb)
                {
                    XbGo();
                    SendMessageToEngine(FormChess.history.LastUmo());
                }
                else
                {
                    SendMessageToEngine("new");
                    XbGo();
                    SendMessageToEngine("post");
                    if (FormChess.history.fen != CChess.defFen)
                    {
                        SendMessageToEngine($"setboard {FormChess.history.fen}");
                    }
                    SendMessageToEngine("force");
                    foreach (CHis m in FormChess.history)
                        SendMessageToEngine(m.umo);
                    if (FormChess.chess.WhiteTurn)
                        SendMessageToEngine("white");
                    else
                        SendMessageToEngine("black");
                    SendMessageToEngine("go");
                    gamerEngine.isPositionXb = true;
                }
                TimerStart();
            }
            gamerEngine.isEngRunning = true;
        }

        public void SendMessageToBook(string msg)
        {
            phase = 1;
            Color col = IsWhite() ? Color.DimGray : Color.Black;
            FormLogEngines.AppendTimeText($"book {player.name}", col);
            FormLogEngines.AppendText($" < {msg}\n", Color.Brown);
            gamerBook.WriteLine(msg);
        }

        public void SendMessageToEngine(string msg)
        {
            phase = 2;
            Color col = IsWhite() ? Color.DimGray : Color.Black;
            FormLogEngines.AppendTimeText($"{player.name}", col);
            FormLogEngines.AppendText($" < {msg}\n", Color.Brown);
            gamerEngine.WriteLine(msg);
        }

        public string GetBookName()
        {
            return book?.name ?? "Book";
        }

        public string GetMode()
        {
            return player?.levelValue.LongName() ?? "Mode";
        }

        public string GetProtocol()
        {
            if (engine == null)
                return "Protocol";
            return CData.ProtocolToStr(engine.protocol);
        }

        public Color GetScoreColor()
        {
            double dr = 1.0;
            double dg = 1.0;
            if (scoreI > 0)
                dr = 1.0 - scoreI / 500.0;
            if (scoreI < 0)
                dg = 1.0 + scoreI / 500.0;
            if (dr < 0)
                dr = 0;
            if (dg < 0)
                dg = 0;
            return Color.FromArgb(200, Convert.ToInt32(dr * 0xff), Convert.ToInt32(dg * 0xff), 0);
        }

        public string GetTime(out bool low)
        {
            low = false;
            TimeSpan ts = timer.Elapsed;
            double ms = ts.TotalMilliseconds;
            CLimit level = CLimit.standard;
            int value = 0;
            if (player != null)
            {
                level = player.levelValue.limit;
                value = player.levelValue.GetUciValue();
            }
            if (level == CLimit.standard)
            {
                double v = Convert.ToDouble(value);
                double t = v - ms;
                ts = TimeSpan.FromMilliseconds(t);
                if ((FormChess.gameMode != CGameMode.game) && (ts.TotalMilliseconds < -FormOptions.marginStandard) && (FormOptions.marginStandard >= 0) && timer.IsRunning)
                {
                    FormChess.This.SetGameState(CGameState.time);
                    return "Time out";
                }
                if (ts.TotalSeconds < 10)
                {
                    low = true;
                    return $"{ts.TotalSeconds:N2}";
                }
            }
            else if (level == CLimit.time)
            {
                double v = Convert.ToDouble(value);
                if ((FormChess.gameMode != CGameMode.game) && ((ms - timerStart) > (v + FormOptions.marginTime)) && (FormOptions.marginTime >= 0) && (value > 0) && timer.IsRunning)
                {
                    FormChess.This.SetGameState(CGameState.time);
                    return "Time out";
                }
                ts.Add(TimeSpan.FromMilliseconds(ms));
            }
            else
                ts.Add(TimeSpan.FromMilliseconds(ms));
            return ts.ToString(@"hh\:mm\:ss");
        }

        public string GetElo()
        {
                return $"Elo {player.Elo}";
        }

        public string GetPlayerName()
        {
            if (player.IsHuman())
                return Global.human;
            else
                return player.GetName();
        }

        public void SetPlayer(CPlayer p)
        {
            player = p;
            SetBook(p.BookName);
            SetEngine(p.EngineName);
        }

        void SetBook(string b)
        {
            book = FormChess.bookList.GetBookByName(b);
            if (book == null)
                gamerBook.Terminate();
            else
                gamerBook.SetProgram(book.GetPath(), book.arguments);
        }

        void SetEngine(string e)
        {
            engine = FormChess.engineList.GetEngineByName(e);
            if (engine == null)
                gamerEngine.Terminate();
            else
                gamerEngine.SetProgram(engine.GetPath(), engine.arguments);
        }

    }

    public class CGamers : List<CGamer>
    {
        /// <summary>
        /// Index of current gammer
        /// </summary>
        static int curIndex = 0;

        public bool WhiteTurn
        {
            get { return curIndex == 0; }
            set { curIndex = value ? 0 : 1; }
        }

        public CGamers()
        {
            Add(new CGamer(CColor.white));
            Add(new CGamer(CColor.black));
        }

        public bool Check(out string msg)
        {
            msg = String.Empty;
            foreach (CGamer g in this)
                if (!g.player.Check(out msg))
                    return false;
            return true;
        }

        public void Next()
        {
            CGamer cg = GamerCur();
            cg.timer.Stop();
            cg.gamerBook.isBookStarted = false;
            cg.gamerBook.isBookFail = false;
            cg.gamerEngine.isEngRunning = false;
            curIndex ^= 1;
            cg = GamerCur();
            cg.InitNextMove();
            if (cg.player.IsHuman())
                cg.TimerStart();
        }

        public void InitNewGame()
        {
            curIndex = 0;
            foreach (CGamer g in this)
                g.InitNewGame();
        }

        public void Rotate()
        {
            (this[1], this[0]) = (this[0], this[1]);
            this[0].colorPlayer = CColor.white;
            this[1].colorPlayer = CColor.black;
        }

        public int GetMsgPriority()
        {
            return Math.Max(this[0].msgPriority,this[1].msgPriority);
        }

        public CGamer GamerWhite()
        {
            return this[0];
        }

        public CGamer GamerBlack()
        {
            return this[1];
        }

        public CGamer GamerWinner()
        {
            CChess chess = new CChess();
            chess.SetFen(FormChess.history.Last()?.fen);
            return this[(chess.halfMove & 1) ^ 1];
        }

        public CGamer GamerLoser()
        {
            CChess chess = new CChess();
            chess.SetFen(FormChess.history.Last()?.fen);
            return this[chess.halfMove & 1];
        }

        public CGamer GamerHuman()
        {
            foreach (CGamer g in this)
                if (g.player.IsHuman())
                    return g;
            return null;
        }

        public CGamer GamerComputer()
        {
            foreach (CGamer g in this)
                if (g.player.IsComputer())
                    return g;
            return null;
        }

        public CGamer GamerCur()
        {
            return this[curIndex];
        }

        public CGamer GamerSec()
        {
            return this[curIndex ^ 1];
        }

        public void Restart()
        {
            foreach (CGamer g in this)
                g.Restart();
        }

        public void Terminate()
        {
            foreach (CGamer g in this)
            {
                g.timer.Stop();
                g.gamerEngine.Close();
                g.gamerBook.Close();
            }
        }

        public CPlayer GetHuman()
        {
            foreach (CGamer g in this)
                if (g.player.IsHuman())
                    return g.player;
            return null;
        }

        public void SetPlayers(CPlayer pw, CPlayer pb)
        {
            Terminate();
            InitNewGame();
            this[0].SetPlayer(pw);
            this[1].SetPlayer(pb);
            this[0].colorPlayer = CColor.white;
            this[1].colorPlayer = CColor.black;
            this[0].arrowColor = Colors.Green;
            this[1].arrowColor = Colors.Green;
            this[0].arrowShift = 0;
            this[1].arrowShift = 0;
            FormLogEngines.WriteHeader(GamerWhite(), GamerBlack());
        }

        public void StartAnalysis(string go,string moves)
        {
            this[0].arrowColor = Colors.Green;
            this[1].arrowColor = Colors.Yellow;
            this[0].arrowShift = -1;
            this[1].arrowShift = 1;
            foreach (CGamer g in this)
                if (g.player.IsComputer())
                {
                    g.SendMessageToEngine("uci");
                    g.OptionsToEngine();
                    if (CModeEdit.multiPV > 1)
                        g.SendMessageToEngine($"setoption name MultiPV value {CModeEdit.multiPV}");
                    g.SendMessageToEngine("ucinewgame");
                    g.SendMessageToEngine($"position fen {FormChess.chess.GetFen()}");
                    g.SendMessageToEngine($"{go}{moves}");
                }
        }

        public void Stop()
        {
            Terminate();
        }


    }
}