using System;

namespace RapChessGui
{
	static class CModeTraining
	{
		public static bool rotate = false;
		public static int games;
		public static int win;
		public static int draw;
		public static int loose;
		public static int winInRow = 0;
		public static string trainer = String.Empty;
		public static string trained = String.Empty;
		public static string trainerBook = CListBook.def;
		public static string trainedBook = CListBook.def;
		public static CLimitValue modeValueTrainer = new CLimitValue();
		public static CLimitValue modeValueTrained = new CLimitValue();
		public static CHisElo his = new CHisElo();

		public static void Reset()
		{
			rotate = false;
			games = 0;
			win = 0;
			draw = 0;
			loose = 0;
			winInRow = 0;
			his.Clear();
			SaveToIni();
		}

		public static int Total()
		{
			return win + draw + loose;
		}

		public static int Result(bool rev)
		{
			int t = Total();
			if (t == 0)
				return 50;
			if (rev)
				return ((loose * 2 + draw) * 100) / (t * 2);
			else
				return ((win * 2 + draw) * 100) / (t * 2);
		}

		public static void SaveToIni()
		{
			FormChess.ini.Write("mode>training>win", win);
			FormChess.ini.Write("mode>training>draw", draw);
			FormChess.ini.Write("mode>training>loose", loose);
			FormChess.ini.Write("mode>training>trainer", trainer);
			FormChess.ini.Write("mode>training>trained", trained);
			FormChess.ini.Write("mode>training>trainerBook", trainerBook);
			FormChess.ini.Write("mode>training>trainedBook", trainedBook);
			FormChess.ini.Write("mode>training>trainerValue", modeValueTrainer.baseVal);
			FormChess.ini.Write("mode>training>trainedValue", modeValueTrained.baseVal);
			FormChess.ini.Write("mode>training>trainerMode", modeValueTrainer.GetLimit());
			FormChess.ini.Write("mode>training>trainedMode", modeValueTrained.GetLimit());
			FormChess.ini.Write("mode>training>his", his," ");
		}

		public static void LoadFromIni()
		{
			win = FormChess.ini.ReadInt("mode>training>win");
			draw = FormChess.ini.ReadInt("mode>training>draw");
			loose = FormChess.ini.ReadInt("mode>training>loose");
			trainer = FormChess.ini.Read("mode>training>trainer", CListEngine.def);
			trained = FormChess.ini.Read("mode>training>trained", CListEngine.def);
			trainerBook = FormChess.ini.Read("mode>training>trainerBook", trainerBook);
			trainedBook = FormChess.ini.Read("mode>training>trainedBook", trainedBook);
			modeValueTrainer.baseVal = FormChess.ini.ReadInt("mode>training>trainerValue", modeValueTrainer.baseVal);
			modeValueTrained.baseVal = FormChess.ini.ReadInt("mode>training>trainedValue", modeValueTrained.baseVal);
			modeValueTrainer.SetLimit(FormChess.ini.Read("mode>training>trainerMode", modeValueTrainer.GetLimit()));
			modeValueTrained.SetLimit(FormChess.ini.Read("mode>training>trainedMode", modeValueTrained.GetLimit()));
			his.FromStr(FormChess.ini.Read("mode>training>his", string.Empty));
		}

	}
}
