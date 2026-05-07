using RapIni;
using System;

namespace RapChessGui
{
    public class CModeGame
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
        public static string customEngine = CListEngine.def;
        public static string customBook = CListBook.def;
        public CHisElo history=new CHisElo();
        public static CLimitValue modeValue = new CLimitValue();

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
            if (accuracyS > 0)
                accuracy = Convert.ToInt32(accuracyC / accuracyS);
            return $"accuracy {accuracy}% blunder {blunder} mistake {mistake} inaccuracy {inaccuracy} avg {FormChess.game.history.EloAvg()}";
        }

        public void SaveToIni(CRapIni ini)
        {
            ini.Write("mode>game>finished", finished);
            ini.Write("mode>game>rotate", rotate);
            ini.Write("mode>game>color", color);
            ini.Write("mode>game>engine", customEngine);
            ini.Write("mode>game>book", customBook);
            ini.Write("mode>game>mode", modeValue.GetLimitType());
            ini.Write("mode>game>value", modeValue.baseVal);
            history.SaveToIni(ini, "mode>game>history");
            ini.Save();
        }

        public void LoadFromIni(CRapIni ini)
        {
            finished = ini.ReadBool("mode>game>finished", finished);
            rotate = ini.ReadBool("mode>game>rotate");
            color = ini.Read("mode>game>color", color);
            customEngine = ini.Read("mode>game>engine", customEngine);
            customBook = ini.Read("mode>game>book", customBook);
            modeValue.SetLimitType(ini.Read("mode>game>mode", modeValue.GetLimitType()));
            modeValue.baseVal = ini.ReadInt("mode>game>value", modeValue.baseVal);
            history.LoadFromIni(ini, "mode>game>history");
            if (history.Count == 0)
            {
                history.AddElo(1000);
            }
        }

    }
}
