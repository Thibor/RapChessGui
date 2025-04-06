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
        public static string engine = CListEngine.def;
        public static string book = CListBook.def;
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
            return $"accuracy {accuracy}% blunder {blunder} mistake {mistake} inaccuracy {inaccuracy}";
        }

        public void SaveToIni(CRapIni ini)
        {
            ini.Write("mode>game>finished", finished);
            ini.Write("mode>game>rotate", rotate);
            ini.Write("mode>game>color", color);
            ini.Write("mode>game>engine", engine);
            ini.Write("mode>game>book", book);
            ini.Write("mode>game>mode", modeValue.GetLimit());
            ini.Write("mode>game>value", modeValue.baseVal);
            history.SaveToIni(ini, "mode>game>history");
            ini.Save();
        }

        public void LoadFromIni(CRapIni ini)
        {
            finished = ini.ReadBool("mode>game>finished", finished);
            rotate = ini.ReadBool("mode>game>rotate");
            color = ini.Read("mode>game>color", color);
            engine = ini.Read("mode>game>engine", engine);
            book = ini.Read("mode>game>book", book);
            modeValue.SetLimit(ini.Read("mode>game>mode", modeValue.GetLimit()));
            modeValue.baseVal = ini.ReadInt("mode>game>value", modeValue.baseVal);
            history.LoadFromIni(ini, "mode>game>history");
        }

    }
}
