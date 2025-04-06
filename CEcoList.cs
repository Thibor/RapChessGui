using System;
using System.IO;
using System.Collections.Generic;

namespace RapChessGui
{
    public class CEco
    {
        public string name;
        public string moves;
        public string fen;
        public string continuations;

        public bool LoadFromStr(string str)
        {
            string[] strArr = str.Split(',');
            if (strArr.Length < 4)
                return false;
            name = strArr[0];
            moves = strArr[1];
            fen = strArr[2];
            continuations = strArr[3];
            return true;
        }

    }

    class CEcoList : List<CEco>
    {
        const string path = @"Data\eco.csv";

        public CEcoList()
        {
            LoadFromFile(path);
        }

        void LoadFromFile(string path)
        {
            Clear();
            if (File.Exists(path))
            {
                String[] content = File.ReadAllLines(path);
                foreach (string s in content)
                {
                    CEco eco = new CEco();
                    if (eco.LoadFromStr(s))
                        Add(eco);
                }
            }
        }

        public CEco EpdToEco(string fen)
        {
            foreach (CEco e in this)
                if (e.fen == fen)
                    return e;
            return null;
        }

        public CEco MovesToEco(string moves)
        {
            foreach (CEco e in this)
                if (e.moves.IndexOf(moves) == 0)
                    return e;
            return null;
        }

        public void SaveToUci()
        {
            string path = $@"Books\eco.uci";
            List<string> moves = new List<string>();
            foreach (CEco eco in this)
                moves.Add(eco.moves);
            File.WriteAllLines(path, moves);
        }

        public void SaveToFile(string path)
        {
            List<string> moves = new List<string>();
            foreach (CEco eco in this)
                moves.Add($"{eco.name},{eco.moves},{eco.fen},{eco.continuations}");
            File.WriteAllLines(path, moves);
        }

    }
}
