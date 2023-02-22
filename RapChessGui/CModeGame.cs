using RapIni;

namespace RapChessGui
{
	static class CModeGame
	{
		public static bool ranked = false;
		public static bool rotate = false;
		public static bool finished = true;
		public static string color = "Auto";
		public static string computer = "Auto";
		public static string engine = CEngineList.def;
		public static string book = CBookList.def;
		public static CLevelValue modeValue = new CLevelValue();

		public static void SaveToIni()
		{
			CPlayer humanPlayer = CPlayerList.humanPlayer;
			if (humanPlayer.hisElo.Count == 0)
			{
				humanPlayer.hisElo.AddValue(humanPlayer.elo);
				humanPlayer.hisElo.AddValue(humanPlayer.elo);
			}
			FormChess.ini.Write("mode>game>finished", finished);
			FormChess.ini.Write("mode>game>rotate", rotate);
			FormChess.ini.Write("mode>game>color", color);
			FormChess.ini.Write("mode>game>computer",computer);
			FormChess.ini.Write("mode>game>engine", engine);
			FormChess.ini.Write("mode>game>book", book);
			FormChess.ini.Write("mode>game>mode", modeValue.GetLevel());
			FormChess.ini.Write("mode>game>value", modeValue.baseVal);
			FormChess.ini.Write("mode>game>player>elo", humanPlayer.elo);
			FormChess.ini.Write("mode>game>player>history", humanPlayer.hisElo.SaveToStr());
		}

		public static void LoadFromIni()
		{
			CPlayer humanPlayer = CPlayerList.humanPlayer;
			finished = FormChess.ini.ReadBool("mode>game>finished",finished);
			rotate = FormChess.ini.ReadBool("mode>game>rotate");
			color = FormChess.ini.Read("mode>game>color", color);
			computer = FormChess.ini.Read("mode>game>computer", computer);
			engine = FormChess.ini.Read("mode>game>engine", engine);
			book = FormChess.ini.Read("mode>game>book", book);
			modeValue.SetLevel(FormChess.ini.Read("mode>game>mode",modeValue.GetLevel()));
			modeValue.baseVal = FormChess.ini.ReadInt("mode>game>value", modeValue.baseVal);
			humanPlayer.elo = FormChess.ini.ReadInt("mode>game>player>elo",600);
			humanPlayer.hisElo.LoadFromStr(FormChess.ini.Read("mode>game>player>history"));
			humanPlayer.name = Global.human;
			humanPlayer.levelValue.level = CLevel.infinite;
		}

	}
}
