using NSChess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace RapChessGui
{
	public enum CGameMode { game, match, tourB, tourE, tourP, training, edit }
	public enum CProtocol { uci, winboard, auto, unknow }
	public enum CLevel { standard, time, depth, nodes, infinite }
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
		public static int lastSou = -1;
		public static int lastDes = -1;
		public static int mouseX = 0;
		public static int mouseY = 0;
		public static int mouseIndex = 0;
	}

	public static class Global
	{
		public static string none = "None";
		public static string human = "Human";
		public static string elo = "1500";
	}

	public static class CGames
	{
		public static int played = 0;
		public static int draw = 0;
		public static int time = 0;
		public static int error = 0;

		public static void Reset()
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

	public static class CData
	{
		public static bool reset = true;
		public static string eco = String.Empty;
		public static CGameState gameState = CGameState.normal;
		public static CGameMode gameMode = CGameMode.game;
		public static List<string> fileBookReader = new List<string>();
		public static List<string> folderEngine = new List<string>();

		public static string ProtocolToStr(CProtocol p)
		{
			switch (p)
			{
				case CProtocol.uci:
					return "Uci";
				case CProtocol.winboard:
					return "Winboard";
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
				case "Uci":
					return CProtocol.uci;
				case "Winboard":
					return CProtocol.winboard;
				case "Auto":
					return CProtocol.auto;
				default:
					return CProtocol.unknow;
			}
		}

		public static void HisToPoints(CHisElo he, DataPointCollection po)
		{
			po.Clear();
			int x = 100 - he.Count;
			foreach (double v in he)
				po.AddXY(x++, v);
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


		public static void FillComboBox(ComboBox cb,List<string> list)
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
		public static int eloMax = 2950;
		public static int eloMin = 50;
		public static int eloRange = eloMax - eloMin;

		static double Probability(double rating1, double rating2)
		{
			return 1.0 / (1.0 + Math.Pow(10.0, (rating1 - rating2) / 400.0));
		}

		public static void EloRating(double oldEloWin, double oldEloLoose, out double newEloWin, out double newEloLoose, int Ga, int Gb, bool draw)
		{
			double Kmin = 0xf;
			double Kmax = 0x80;
			double Ka = Ga / FormOptions.historyLength;
			double Kb = Gb / FormOptions.historyLength;
			Ka = (Ka * Kmin) + ((1 - Ka) * Kmax);
			Kb = (Kb * Kmin) + ((1 - Kb) * Kmax);
			double Pb = Probability(oldEloWin, oldEloLoose);
			double Pa = Probability(oldEloLoose, oldEloWin);
			if (draw)
			{
				newEloWin = oldEloWin + Ka * (0.5 - Pa);
				newEloLoose = oldEloLoose + Kb * (0.5 - Pb);
			}
			else
			{
				newEloWin = oldEloWin + Ka * (1 - Pa);
				newEloLoose = oldEloLoose + Kb * (0 - Pb);
				double dif = oldEloWin - oldEloLoose;
				if (oldEloWin > oldEloLoose)
					if (dif > 300)
					{
						newEloWin = oldEloWin;
						newEloLoose = oldEloLoose;
					}
					else
					{
						newEloWin = oldEloWin + ((newEloWin - oldEloWin) * (300 - dif)) / 300;
						newEloLoose = oldEloLoose + ((newEloLoose - oldEloLoose) * (300 - dif)) / 300;
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

	}

	public class CModeValue
	{
		public CLevel level = CLevel.time;
		public int value = 10;
		public int increment = 100;
		public int inc = 0;

		public static CLevel StrToLevel(string l)
		{
			switch (l)
			{
				case "Standard":
					return CLevel.standard;
				case "Time":
					return CLevel.time;
				case "Depth":
					return CLevel.depth;
				case "Nodes":
					return CLevel.nodes;
				default:
					return CLevel.infinite;
			}
		}

		public string LevelToStr(CLevel l)
		{
			switch (l)
			{
				case CLevel.standard:
					return "Standard";
				case CLevel.depth:
					return "Depth";
				case CLevel.nodes:
					return "Nodes";
				case CLevel.time:
					return "Time";
				default:
					return "Infinite";
			}
		}

		public void SetLevel(string l)
		{
			level = StrToLevel(l);
		}

		public string GetLevel()
		{
			return LevelToStr(level);
		}

		public void SetValue(int v)
		{
			int inc = GetValueIncrement();
			if (inc > 0)
				value = v / inc;
			else
				value = 0;
		}

		public int GetValue()
		{
			int inc = GetValueIncrement();
			return value > 0 ? value * inc : inc;
		}

		public int GetUciValue()
		{
			int result = value * GetValueIncrement();
			if (result < 0)
				result = 1;
			if (level == CLevel.standard)
				result *= 1000;
			return result;
		}

		public int GetValueIncrement()
		{
			switch (level)
			{
				case CLevel.standard:
					return 15;
				case CLevel.depth:
					return 1;
				case CLevel.nodes:
					return 100000;
				case CLevel.infinite:
					return 0;
				default:
					return 100;
			}
		}

		public string GetUci()
		{
			switch (level)
			{
				case CLevel.standard:
					return "standard";
				case CLevel.depth:
					return "depth";
				case CLevel.nodes:
					return "nodes";
				case CLevel.infinite:
					return "infinite";
				default:
					return "movetime";
			}
		}

		public string GetTip()
		{
			switch (level)
			{
				case CLevel.standard:
					return "Base for whole game in seconds";
				case CLevel.depth:
					return "Depth in half-moves";
				case CLevel.nodes:
					return "Maximum nodes per move";
				case CLevel.infinite:
					return "Infinite mode until click stop";
				default:
					return "Time per move in miliseconds";
			}
		}

		public string ShortName()
		{
			string mode = GetLevel();
			string result = mode[0].ToString();
			if (mode != "Infinite")
				result = $"{result}{value}";
			return $" {result}";
		}

		public string LongName()
		{
			string mode = GetLevel();
			if (mode == "Standard")
			{
				int t = value * 15 + inc * 60;
				int m = value / 4;
				string min = m > 0 ? m.ToString() : "";
				string sec = new string[4] { "", "¼", "½", "¾" }[value % 4];
				string tim = $"{min}{sec}+{inc}";
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
				return $"{mode} {value}";
			return mode;
		}

	}

	public class CElement
	{
		public int position = 0;
		public string name = string.Empty;
		public string elo = Global.elo;

		public int Elo
		{
			get
			{
				return Convert.ToInt32(elo);
			}
			set
			{
				elo = value.ToString();
			}
		}

		public double EvaluateOpponent(CElement second,double listCount, CTourList tourList)
		{
			double sElo = second.Elo;
			double allGames = tourList.CountGames(name);
			double curGames = tourList.CountGames(second.name, name, out int rw, out int rl, out int rd);
			double r = curGames == 0 ? 0 : (rw * 2.0 + rd - curGames) / curGames;
			double eloDif = (CElo.eloRange - Math.Abs(Elo - sElo)) / CElo.eloRange;
			double nElo = sElo;
			if (r < 0)
			{
				nElo += r * sElo * eloDif;
				if (nElo < sElo)
					nElo = sElo;
			}
			else if (r > 0)
			{
				nElo += r * (CElo.eloMax - sElo) * eloDif;
				if (nElo > sElo)
					nElo = sElo;
			}
			else
				nElo += Elo;
			double ratioElo = (Math.Abs(sElo - nElo) / CElo.eloRange);
			double maxCount = Math.Sqrt(allGames * 2) + 1;
			double maxRange = Math.Min(listCount + 1, maxCount);
			double avgCount = allGames / maxRange;
			double delCount = (avgCount * 2) / maxRange;
			double optCount = maxCount - second.position * delCount + 1;
			double ratioCount = allGames == 0 ? 0 : (optCount - curGames) / maxCount;
			double ratioDistance = (listCount - second.position) / listCount;
			double ratioOrder = allGames == 0 ? 0 : (rw == rl) ? 0.2 : (sElo == Elo) ? 0.5 : (rw > rl) == (sElo < Elo) ? 1 : 0;
			return ratioCount + ratioDistance + ratioElo + ratioOrder;
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
