using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{
	static class CModeMatch
	{
		public static int win = 0;
		public static int draw = 0;
		public static int loose = 0;
		public static string engine1 = CEngineList.def;
		public static string engine2 = CEngineList.def;
		public static string book1 = CBookList.def;
		public static string book2 = CBookList.def;
		public static CModeValue modeValue1 = new CModeValue();
		public static CModeValue modeValue2 = new CModeValue();
		public static CHisElo his = new CHisElo();
		static CColor color;

		public static bool Rotate
		{
			get { return (Games & 1) > 0; }
		}

		public static int Games
		{
			get { return win + loose + draw; }
		}

		public static void Reset()
		{
			win = 0;
			draw = 0;
			loose = 0;
			his.Clear();
			SaveToIni();
		}

		public static void GameStart()
		{
			color = Rotate ? CColor.black : CColor.white;
		}

		public static void GameEnd(CColor winColor)
		{
			if (his.Count == 0)
				his.AddValue(0);
			if (winColor == CColor.none)
				draw++;
			else if (winColor == color)
				win++;
			else
				loose++;
			his.AddValue(win - loose);
			SaveToIni();
		}

		public static double Result(bool rev)
		{
			int t = Games;
			if (t == 0)
				return 50;
			if (rev)
				return ((loose * 2 + draw) * 100.0) / (t * 2);
			else
				return ((win * 2 + draw) * 100.0) / (t * 2);
		}

		public static void LoadFromIni()
		{
			win = FormChess.ini.ReadInt("mode>match>win");
			draw = FormChess.ini.ReadInt("mode>match>draw");
			loose = FormChess.ini.ReadInt("mode>match>loose");
			book1 = FormChess.ini.Read("mode>match>book1", book1);
			book2 = FormChess.ini.Read("mode>match>book2", book2);
			engine1 = FormChess.ini.Read("mode>match>engine1", engine1);
			engine2 = FormChess.ini.Read("mode>match>engine2", engine2);
			modeValue1.SetLevel(FormChess.ini.Read("mode>match>mode1", modeValue1.GetLevel()));
			modeValue2.SetLevel(FormChess.ini.Read("mode>match>mode2", modeValue2.GetLevel()));
			modeValue1.value = FormChess.ini.ReadInt("mode>match>value1", modeValue1.value);
			modeValue2.value = FormChess.ini.ReadInt("mode>match>value2", modeValue2.value);
			his.LoadFromStr(FormChess.ini.Read("mode>match>his", string.Empty));
		}

		public static void SaveToIni()
		{
			FormChess.ini.Write("mode>match>win", win);
			FormChess.ini.Write("mode>match>draw", draw);
			FormChess.ini.Write("mode>match>loose", loose);
			FormChess.ini.Write("mode>match>book1", book1);
			FormChess.ini.Write("mode>match>book2", book2);
			FormChess.ini.Write("mode>match>engine1", engine1);
			FormChess.ini.Write("mode>match>engine2", engine2);
			FormChess.ini.Write("mode>match>mode1", modeValue1.GetLevel());
			FormChess.ini.Write("mode>match>mode2", modeValue2.GetLevel());
			FormChess.ini.Write("mode>match>value1", modeValue1.value);
			FormChess.ini.Write("mode>match>value2", modeValue2.value);
			FormChess.ini.Write("mode>match>his", his.SaveToStr());
		}

	}
}
