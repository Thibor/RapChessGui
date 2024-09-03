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
		public static string engine = CListEngine.def;
		public static string book = CListBook.def;
		public static CLevelValue modeValue = new CLevelValue();
		readonly static CRapIni ini = new CRapIni(@"Ini\game.ini");

		public static void SaveToIni()
		{
			CPlayer humanPlayer = CListPlayer.humanPlayer;
			if (humanPlayer.hisElo.Count == 0)
			{
				humanPlayer.hisElo.AddValue(1000);
				humanPlayer.hisElo.AddValue(1000);
			}
			ini.Write("finished", finished);
			ini.Write("rotate", rotate);
			ini.Write("color", color);
			ini.Write("computer",computer);
			ini.Write("engine", engine);
			ini.Write("book", book);
			ini.Write("mode", modeValue.GetLevel());
			ini.Write("value", modeValue.baseVal);
			ini.Write("history", humanPlayer.hisElo, " ");
			ini.Save();
		}

		public static void LoadFromIni()
		{
			CPlayer humanPlayer = CListPlayer.humanPlayer;
			finished = ini.ReadBool("finished",finished);
			rotate = ini.ReadBool("rotate");
			color = ini.Read("color", color);
			computer = ini.Read("computer", computer);
			engine = ini.Read("engine", engine);
			book = ini.Read("book", book);
			modeValue.SetLevel(ini.Read("mode",modeValue.GetLevel()));
			modeValue.baseVal = ini.ReadInt("value", modeValue.baseVal);
			humanPlayer.hisElo.LoadFromStr(ini.Read("history"));
			humanPlayer.elo = humanPlayer.hisElo.Last();
			humanPlayer.name = Global.human;
			humanPlayer.levelValue.level = CLevel.infinite;
		}

	}
}
