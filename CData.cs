using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace RapChessGui
{
    public enum CGameMode { game, match, tourB, tourE, tourP, training, puzzle, edit, none }
    public enum CProtocol { uci, xb, auto, unknow }
    public enum CLimitKind { standard, time, depth, nodes, infinite }
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
            if (((Sum() % 100) == 0) || (Count > FormChess.formOptions.nudHistory.Value))
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
                case CProtocol.xb:
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
                    return CProtocol.xb;
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
        public static CLimitKind defKind = CLimitKind.standard;
        public static int defValue = 10;
        public CLimitKind kind = defKind;
        public int baseVal = defValue;
        public int baseInc = 0;

        public static CLimitKind StrToLimit(string kind)
        {
            switch (kind)
            {
                case "Standard":
                    return CLimitKind.standard;
                case "Time":
                    return CLimitKind.time;
                case "Depth":
                    return CLimitKind.depth;
                case "Nodes":
                    return CLimitKind.nodes;
                default:
                    return CLimitKind.infinite;
            }
        }

        public static string LimitToStr(CLimitKind kind)
        {
            switch (kind)
            {
                case CLimitKind.standard:
                    return "Standard";
                case CLimitKind.depth:
                    return "Depth";
                case CLimitKind.nodes:
                    return "Nodes";
                case CLimitKind.time:
                    return "Time";
                default:
                    return "Infinite";
            }
        }

        public static int GetIncrement(CLimitKind kind)
        {
            switch (kind)
            {
                case CLimitKind.standard:
                    return 15;
                case CLimitKind.depth:
                    return 1;
                case CLimitKind.nodes:
                    return 100000;
                case CLimitKind.infinite:
                    return 0;
                default:
                    return 100;
            }
        }

        public void SetLimit(string str)
        {
            kind = StrToLimit(str);
        }

        public string GetLimit()
        {
            return LimitToStr(kind);
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

        public int GetBaseInc()
        {
            if (kind == CLimitKind.standard)
                return baseInc;
            return 0;
        }

        public int GetUciValue()
        {
            int result = baseVal * GetIncrement();
            if (result < 0)
                result = 1;
            if (kind == CLimitKind.standard)
                result *= 1000;
            return result;
        }

        public int GetIncrement()
        {
            return GetIncrement(kind);
        }

        public string GetUci()
        {
            int v = GetValue();
            switch (kind)
            {
                case CLimitKind.standard:
                    return $"go wtime {v} btime {v} winc 0 binc 0";
                case CLimitKind.depth:
                    return $"go depth {v}";
                case CLimitKind.nodes:
                    return $"nodes {v}";
                case CLimitKind.infinite:
                    return "infinite";
                default:
                    return $"go movetime {v}";
            }
        }

        public string GetTip()
        {
            switch (kind)
            {
                case CLimitKind.standard:
                    return "Base for whole game in seconds";
                case CLimitKind.depth:
                    return "Depth in half-moves";
                case CLimitKind.nodes:
                    return "Maximum nodes per move";
                case CLimitKind.infinite:
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
            int inc = GetIncrement();
            int bVal = baseVal * inc;
            int bInc = baseInc;
            string mode = GetLimit();
            if (mode == "Standard")
            {
                int i1 = bVal / 60;
                int i2 = (bVal % 60) / 15;
                int i3 = bInc / 1000;
                int i4 = (bInc % 1000) / 250;

                string[] q = new string[4] { "", "¼", "½", "¾" };
                int t = bVal + (bInc * 60) / 1000;
                int m = bVal / 4;
                string tim = $"{i1}{q[i2]}+{i3}{q[i4]}";
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

        public virtual int ClearHistory()
        {
            int elo = Elo;
            history.Clear();
            Elo = elo;
            return CModeTournamentE.tourList.DeletePlayer(name);
        }

        public double EvaluateOpponent3(CElement second, double listCount, CTourList tourList)
        {
            double sElo = second.Elo;
            double allGames = tourList.CountGames(name);
            int curGames = tourList.CountGames(second.name, name, out int gw, out int gl, out int gd) + 1;
            int sPro = (gw * 200 + gd * 100) / curGames - 100;
            double r = curGames == 0 ? 0 : (gw - gl) / curGames;
            double nElo = sElo + r * Math.Abs(Elo - sElo);
            double ratioElo = (Math.Abs(sElo - nElo) / CElo.eloRange);
            double maxCount = Math.Sqrt(allGames * 2) + 1;
            double maxRange = Math.Min(listCount + 1, maxCount);
            double avgCount = allGames / maxRange;
            double delCount = (avgCount * 2) / maxRange;
            double optCount = maxCount - second.position * delCount + 1;
            double ratioCount = allGames == 0 ? 0 : (optCount - curGames) / maxCount;
            double ratioDistance = (listCount - second.position) / listCount;
            double ratioOrder = allGames == 0 ? 0 : (sPro > 0) == (sElo < Elo) ? 1.0 : (sPro == 0) ? 0.8 : (sElo == Elo) ? 0.2 : 0;
            return ratioCount + ratioDistance + ratioElo + ratioOrder * 2;
        }

        public double EvaluateOpponent(CElement second, double listCount, CTourList tourList)
        {
            double sElo = second.Elo;
            double allGames = tourList.CountGames(name);
            double curGames = tourList.CountGames(second.name, name, out int gw, out int gl, out int gd);
            double sPro = curGames == 0 ? 0 : (gw - gl) / curGames;
            double maxCount = Math.Sqrt(allGames * 2) + 1;
            double optCount = maxCount * (listCount - second.position) / listCount;
            double ratioCount = allGames == 0 ? 0 : (optCount - curGames) / maxCount;
            double ratioOrder = curGames == 0 ? 0 : (sPro > 0) == (Elo > sElo) ? 1.0 : (sPro == 0) ? 0.8 : (sElo == Elo) ? 0.2 : 0;
            //FormChess.log.Add($"Opponent {second.name} Optimal {optCount:0.00} Count {ratioCount:0.00} Order {ratioOrder:0.00} Total {ratioCount+ ratioOrder:0.00}");
            return ratioCount + ratioOrder;
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
