using NSChess;
using RapIni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{
    static class CModeEdit
    {
        public static string fen = Global.none;
        public static string engine1=Global.none;
        public static string engine2=Global.none;

        public static void LoadFromIni(CRapIni ini)
        {
            fen = ini.Read("mode>edit>fen", CChess.defFen);
            engine1 = ini.Read("mode>edit>engine1", Global.none);
            engine2 = ini.Read("mode>edit>engine2", Global.none);
        }

        public static void SaveToIni(CRapIni ini)
        {
            ini.Write("mode>edit>fen", fen);
            ini.Write("mode>edit>engine1",engine1);
            ini.Write("mode>edit>engine2", engine2);
        }

    }
}
