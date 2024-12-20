﻿using RapIni;
using System;

namespace RapChessGui
{
    static class CModeGame
    {
        public static bool ranked = false;
        public static bool rotate = false;
        public static bool finished = true;
        public static int blunder = 0;
        public static int mistake = 0;
        public static int inaccuracy = 0;
        public static int accuracyC = 0;
        public static double accuracyS = 0;
        public static string color = "Auto";
        public static string engine = CListEngine.def;
        public static string book = CListBook.def;
        public static CLevelValue modeValue = new CLevelValue();

        public static void NewGame()
        {
            blunder = 0;
            mistake = 0;
            inaccuracy = 0;
            accuracyC = 0;
            accuracyS = 0;
        }

        public static string Info()
        {
            int accuracy = 100;
            if (accuracyC > 0)
                accuracy = Convert.ToInt32(accuracyS / accuracyC);
            return $"accuracy {accuracy}% blunder {blunder} mistake {mistake} inaccuracy {inaccuracy}";
        }

        public static void SaveToIni(CRapIni ini)
        {
            CPlayer humanPlayer = CListPlayer.humanPlayer;
            if (humanPlayer.hisElo.Count == 0)
            {
                humanPlayer.hisElo.AddValue(1000);
                humanPlayer.hisElo.AddValue(1000);
            }
            ini.Write("mode>game>finished", finished);
            ini.Write("mode>game>rotate", rotate);
            ini.Write("mode>game>color", color);
            ini.Write("mode>game>engine", engine);
            ini.Write("mode>game>book", book);
            ini.Write("mode>game>mode", modeValue.GetLevel());
            ini.Write("mode>game>value", modeValue.baseVal);
            ini.Write("mode>game>history", humanPlayer.hisElo, " ");
            ini.Save();
        }

        public static void LoadFromIni(CRapIni ini)
        {
            CPlayer humanPlayer = CListPlayer.humanPlayer;
            finished = ini.ReadBool("mode>game>finished", finished);
            rotate = ini.ReadBool("mode>game>rotate");
            color = ini.Read("mode>game>color", color);
            engine = ini.Read("mode>game>engine", engine);
            book = ini.Read("mode>game>book", book);
            modeValue.SetLevel(ini.Read("mode>game>mode", modeValue.GetLevel()));
            modeValue.baseVal = ini.ReadInt("mode>game>value", modeValue.baseVal);
            humanPlayer.hisElo.LoadFromStr(ini.Read("mode>game>history"));
            humanPlayer.elo = humanPlayer.hisElo.Last();
            humanPlayer.name = Global.human;
            humanPlayer.levelValue.level = CLevel.infinite;
        }

    }
}
