using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RapChessGui
{
    public enum CGameMode { game, match, tourB, tourE, tourP, training, puzzle, edit, none }
    public enum CProtocol { uci, winboard, auto, unknow }
    public enum CLimit { standard, time, depth, nodes, infinite }
    public enum CColor { none, white, black }

    public static class CWinMessage
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private readonly static object locker = new object();
        public static IntPtr winHandle;

        public static int Message(int msg)
        {
            lock (locker)
            {
                return SendMessage(winHandle, msg, IntPtr.Zero, IntPtr.Zero);
            }
        }

    }

    public static class CPromotion
    {
        public static string umo;
        public static int sou;
        public static int des;
    }

    public static class CDrag
    {
        public static bool dragged = false;
        public static int last = -1;
        public static int lastSelected = -1;
        public static int lastSou = -1;
        public static int lastDes = -1;
        public static int mouseX = 0;
        public static int mouseY = 0;
        public static int mouseIndex = -1;
    }

    public static class Global
    {
        public static int elo = 1500;
        public static decimal value = 60;
        public static string none = "None";
        public static string human = "Human";
        public static string puzzle = "Puzzle";
        public static string limit = "Standard";
    }

    public static class CGames
    {
        public static int played = 0;
        public static int draw = 0;
        public static int time = 0;
        public static int error = 0;

        public static void NewSession()
        {
            played = 0;
            draw = 0;
            time = 0;
            error = 0;
        }

        public static string Text
        {
            get
            {
                return $"RapChessGui Games {played} Draws {draw} Time out {time} Errors {error}";
            }
        }

    }

    public class CError : List<int>
    {

        int Sum()
        {
            int result = 0;
            foreach (int i in this)
                result += (i + 1);
            return result;
        }

        public double Errors()
        {
            int s = Sum();
            if (s == 0)
                return 0;
            return ((Count - 1) * 100.0) / s;
        }

        public void AddGame(bool error)
        {
            if (Count == 0)
                Add(0);
            if (error)
                Add(0);
            else if (this[Count - 1] < int.MaxValue)
                this[Count - 1]++;
            if (((Sum() % 100) == 0) || (Count > FormOptions.historyLength))
                RemoveRange(0, 1);
        }

        public void LoadFromStr(string str)
        {
            Clear();
            string[] arr = str.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string e in arr)
                Add(Convert.ToInt32(e));
        }

    }

    public static class CData
    {
        public static List<string> fileBookReader = new List<string>();
        public static List<string> folderEngine = new List<string>();

        public static string ProtocolToStr(CProtocol p)
        {
            switch (p)
            {
                case CProtocol.uci:
                    return "UCI";
                case CProtocol.winboard:
                    return "XB";
                case CProtocol.auto:
                    return "Auto";
                default:
                    return "Unknown";

            }
        }

        public static string TextBeauty(string text)
        {
            TextInfo ti = new CultureInfo("en-US", false).TextInfo;
            string p = text.Replace('_', ' ').Trim();
            return ti.ToTitleCase(p);
        }

        public static void ComboSelect(ComboBox cb, string n)
        {
            int i = cb.FindStringExact(n);
            if (i < 0)
                i = 0;
            cb.SelectedIndex = i;
        }


        public static CProtocol StrToProtocol(string p)
        {
            switch (p)
            {
                case "UCI":
                    return CProtocol.uci;
                case "XB":
                    return CProtocol.winboard;
                case "Auto":
                    return CProtocol.auto;
                default:
                    return CProtocol.unknow;
            }
        }

        public static string MakeShort(string name)
        {
            int f = 0;
            string result = string.Empty;
            for (int n = 0; n < name.Length; n++)
            {
                char c = name[n];
                if ((f == 0) || Char.IsUpper(c) || Char.IsNumber(c))
                    result += Char.ToUpper(c);
                f++;
                if (c == ' ')
                    f = 0;
            }
            return result;
        }

        public static void UpdateBookReader()
        {
            fileBookReader.Clear();
            string[] arrBooks = Directory.GetFiles("Books", "*.exe");
            for (int n = 0; n < arrBooks.Length; n++)
            {
                string fn = Path.GetFileName(arrBooks[n]);
                fileBookReader.Add(fn);
            }
        }

        public static List<string> ListExe(string path)
        {
            List<string> list = new List<string>();
            if (Directory.Exists(path))
            {
                string[] filePaths = Directory.GetFiles(path, "*.exe");
                for (int n = 0; n < filePaths.Length; n++)
                {
                    string fn = Path.GetFileName(filePaths[n]);
                    list.Add(fn);
                }
            }
            return list;
        }


        public static void FillComboBox(ComboBox cb, List<string> list)
        {
            cb.Items.Clear();
            cb.Sorted = true;
            foreach (string s in list)
                cb.Items.Add(s);
            cb.Sorted = false;
            cb.Items.Insert(0, Global.none);
            cb.SelectedIndex = 0;
        }

        public static void UpdateFolderEngine()
        {
            folderEngine.Clear();
            string[] arr = Directory.GetDirectories("Engines");
            for (int n = 0; n < arr.Length; n++)
            {
                string fn = Path.GetFileName(arr[n]);
                folderEngine.Add(fn);
            }
        }

    }

    public static class CElo
    {
        public static int eloTotal = 4000;
        public static int eloMin = 50;
        public static int eloMax = eloTotal - eloMin;
        public static int eloRange = eloMax - eloMin;

        static double Probability(double rating1, double rating2)
        {
            return 1.0 / (1.0 + Math.Pow(10.0, (rating2 - rating1) / 400.0));
        }

        public static void EloRating(double oldEloWin, double oldEloLoose, out double newEloWin, out double newEloLoose, int gw, int gl, bool draw)
        {
            int Kmin = 0xf;
            int Kmax = 0xf0;
            if (gw < Kmin) gw = Kmin;
            if (gw > Kmax) gw = Kmax;
            if (gl < Kmin) gl = Kmin;
            if (gl > Kmax) gl = Kmax;
            double fw = (double)gw / 0xff;
            double fl = (double)gl / 0xff;
            fw = (1.0 - fw) * 32.0;
            fl = (1.0 - fl) * 32.0;
            double pro = Probability(oldEloWin, oldEloLoose);
            if (draw)
            {
                newEloWin = oldEloWin + fw * (0.5 - pro);
                newEloLoose = oldEloLoose + fl * (pro - 0.5);
            }
            else
            {
                newEloWin = oldEloWin + fw * (1 - pro);
                newEloLoose = oldEloLoose - fl * (1 - pro);
                if (oldEloWin - oldEloLoose > 300)
                {
                    newEloWin = oldEloWin;
                    newEloLoose = oldEloLoose;
                }
            }
            if (newEloWin > eloMax)
                newEloWin = eloMax;
            if (newEloLoose > eloMax)
                newEloLoose = eloMax;
            if (newEloWin < eloMin)
                newEloWin = eloMin;
            if (newEloLoose < eloMin)
                newEloLoose = eloMin;
        }

        public static void EloRating(double oldEloWin, double oldEloLoose, out int newEloWin, out int newEloLoose, int Ga, int Gb, bool draw)
        {
            EloRating(oldEloWin, oldEloLoose, out double dNewEloA, out double dNewEloB, Ga, Gb, draw);
            newEloWin = Convert.ToInt32(dNewEloA);
            newEloLoose = Convert.ToInt32(dNewEloB);
        }

        public static double EloOpt(double ratingPlayer1, double ratingPlayer2, double gw, double gl, double gd)
        {
            double Kmin = 0xf;
            double Kmax = 0xf0;
            double games = gw + gl + gd;
            if (games < Kmin)
                games = Kmin;
            if (games > Kmax)
                games = Kmax;
            double factor = (1.0 - games / 0xff) * 32.0;
            double probabilityWinPlayer1 = Probability(ratingPlayer1, ratingPlayer2);
            ratingPlayer1 += gw * factor * (1.0 - probabilityWinPlayer1);
            ratingPlayer1 += gl * factor * -probabilityWinPlayer1;
            ratingPlayer1 += gd * factor * (0.5 - probabilityWinPlayer1);
            if (ratingPlayer1 < eloMin)
                ratingPlayer1 = eloMin;
            if (ratingPlayer1 > eloMax)
                ratingPlayer1 = eloMax;
            return ratingPlayer1;
        }

    }

    public class CModeTournament
    {
        public bool rotate = true;
        public int reps = 0;
        public int left = 0;
        public string first = String.Empty;
        public string opponent = String.Empty;
        public string clicked = String.Empty;

        public void NewGame()
        {
            rotate = true;
            reps = 0;
            left = 0;
            opponent = String.Empty;
            CGames.NewSession();
        }

    }

    public class CLimitValue
    {
        public static CLimit defLimit = CLimit.standard;
        public static int defValue = 10;
        public CLimit limit = defLimit;
        public int baseVal = defValue;
        public int baseInc = 0;

        public string ToStr()
        {
            return $"{LimitToStr(limit)} {baseVal}";
        }

        public void FromStr(string s)
        {
            string[] arr = s.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length < 2)
            {
                limit = defLimit;
                baseVal = defValue;
                return;
            }
            limit = StrToLimit(arr[0]);
            baseVal = Convert.ToInt32(arr[1]);
        }

        public static CLimit StrToLimit(string str)
        {
            switch (str)
            {
                case "Standard":
                    return CLimit.standard;
                case "Time":
                    return CLimit.time;
                case "Depth":
                    return CLimit.depth;
                case "Nodes":
                    return CLimit.nodes;
                default:
                    return CLimit.infinite;
            }
        }

        public static string LimitToStr(CLimit level)
        {
            switch (level)
            {
                case CLimit.standard:
                    return "Standard";
                case CLimit.depth:
                    return "Depth";
                case CLimit.nodes:
                    return "Nodes";
                case CLimit.time:
                    return "Time";
                default:
                    return "Infinite";
            }
        }

        public static int GetIncrement(CLimit level)
        {
            switch (level)
            {
                case CLimit.standard:
                    return 15;
                case CLimit.depth:
                    return 1;
                case CLimit.nodes:
                    return 100000;
                case CLimit.infinite:
                    return 0;
                default:
                    return 100;
            }
        }

        public void SetLimit(string str)
        {
            limit = StrToLimit(str);
        }

        public string GetLimit()
        {
            return LimitToStr(limit);
        }

        public void SetValue(int v)
        {
            int inc = GetIncrement();
            if (inc > 0)
                baseVal = v / inc;
            else
                baseVal = 0;
        }

        public int GetValue()
        {
            int inc = GetIncrement();
            return baseVal > 0 ? baseVal * inc : inc;
        }

        public int GetUciValue()
        {
            int result = baseVal * GetIncrement();
            if (result < 0)
                result = 1;
            if (limit == CLimit.standard)
                result *= 1000;
            return result;
        }

        public int GetIncrement()
        {
            return GetIncrement(limit);
        }

        public string GetUci()
        {
            int v = GetValue();
            switch (limit)
            {
                case CLimit.standard:
                    return $"go wtime {v} btime {v} winc 0 binc 0";
                case CLimit.depth:
                    return $"go depth {v}";
                case CLimit.nodes:
                    return $"nodes {v}";
                case CLimit.infinite:
                    return "infinite";
                default:
                    return $"go movetime {v}";
            }
        }

        public string GetTip()
        {
            switch (limit)
            {
                case CLimit.standard:
                    return "Base for whole game in seconds";
                case CLimit.depth:
                    return "Depth in half-moves";
                case CLimit.nodes:
                    return "Maximum nodes per move";
                case CLimit.infinite:
                    return "Infinite mode until click stop";
                default:
                    return "Time per move in miliseconds";
            }
        }

        public string ShortName()
        {
            string mode = GetLimit();
            string result = mode[0].ToString();
            if (mode != "Infinite")
                result = $"{result}{baseVal}";
            return $" {result}";
        }

        public string LongName()
        {
            string mode = GetLimit();
            if (mode == "Standard")
            {
                int t = baseVal * 15 + baseInc * 60;
                int m = baseVal / 4;
                string min = m > 0 ? m.ToString() : String.Empty;
                string sec = new string[4] { "", "¼", "½", "¾" }[baseVal % 4];
                string tim = $"{min}{sec}+{baseInc}";
                if (t > 21600)
                    return $"Mail {tim}";
                if (t > 1800)
                    return $"Classical {tim}";
                if (t > 600)
                    return $"Rapid {tim}";
                if (t > 180)
                    return $"Blitz {tim}";
                if (t > 30)
                    return $"Bullet {tim}";
                return $"UltraBullet {tim}";
            }
            if (mode != "Infinite")
                return $"{mode} {baseVal}";
            return mode;
        }

    }

    public class CElement
    {
        public int position = 0;
        public string name = string.Empty;
        public CHisElo history = new CHisElo();

        public int Elo
        {
            get
            {
                return history.Last();
            }
            set
            {
                if (history.Count == 0)
                    history.Add(value);
                else
                    history[history.Count - 1] = value;
            }
        }

        public int ClearHistory()
        {
            int elo = Elo;
            history.Clear();
            Elo = elo;
            return CModeTournamentE.tourList.DeletePlayer(name);
        }

        public double EvaluateOpponent(CElement second, double listCount, CTourList tourList)
        {
            double sElo = second.Elo;
            double allGames = tourList.CountGames(name);
            double curGames = tourList.CountGames(second.name, name, out int rw, out int rl, out int rd);
            double r = curGames == 0 ? 0 : (rw - rl) / curGames;
            double nElo = sElo + r * Math.Abs(Elo - sElo);
            double ratioElo = (Math.Abs(sElo - nElo) / CElo.eloRange);
            double maxCount = Math.Sqrt(allGames * 2) + 1;
            double maxRange = Math.Min(listCount + 1, maxCount);
            double avgCount = allGames / maxRange;
            double delCount = (avgCount * 2) / maxRange;
            double optCount = maxCount - second.position * delCount + 1;
            double ratioCount = allGames == 0 ? 0 : (optCount - curGames) / maxCount;
            double ratioDistance = (listCount - second.position) / listCount;
            double ratioOrder = allGames == 0 ? 0 : (rw > rl) == (sElo < Elo) ? 1 : (rw == rl) ? 0.5 : (sElo == Elo) ? 0.2 : 0;
            return ratioCount + ratioDistance + ratioElo + ratioOrder * 2;
        }

        public void SetElo(string e)
        {
            if (int.TryParse(e, out int elo))
                Elo = elo;
        }

    }

    public class ListViewComparer : System.Collections.IComparer
    {
        readonly private int ColumnNumber;
        readonly private SortOrder SortOrder;

        public ListViewComparer(int column_number,
            SortOrder sort_order)
        {
            ColumnNumber = column_number;
            SortOrder = sort_order;
        }

        public int Compare(object object_x, object object_y)
        {
            ListViewItem item_x = object_x as ListViewItem;
            ListViewItem item_y = object_y as ListViewItem;
            string string_x;
            if (item_x.SubItems.Count <= ColumnNumber)
            {
                string_x = String.Empty;
            }
            else
            {
                string_x = item_x.SubItems[ColumnNumber].Text;
            }

            string string_y;
            if (item_y.SubItems.Count <= ColumnNumber)
            {
                string_y = String.Empty;
            }
            else
            {
                string_y = item_y.SubItems[ColumnNumber].Text;
            }
            int result;
            if (double.TryParse(string_x, out double double_x) && double.TryParse(string_y, out double double_y))
            {
                result = double_x.CompareTo(double_y);
            }
            else
            {
                if (DateTime.TryParse(string_x, out DateTime date_x) &&
                    DateTime.TryParse(string_y, out DateTime date_y))
                {
                    result = date_x.CompareTo(date_y);
                }
                else
                {
                    result = string_x.CompareTo(string_y);
                }
            }
            if (SortOrder == SortOrder.Ascending)
            {
                return result;
            }
            else
            {
                return -result;
            }
        }
    }
}
