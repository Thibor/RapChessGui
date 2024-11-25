using System.Collections.Generic;
using NSChess;
using System.IO;
using NSUci;
using System;

namespace RapChessGui
{
    public class CHis
    {
        public int halfMove;
        public int piece;
        public int emo;
        public string umo=string.Empty;
        public string san=string.Empty;
        public string fen = string.Empty;
        public string score = string.Empty;
        public string pv = string.Empty;
        public string pvCur = string.Empty;
        public string bstMoves = string.Empty;

        public CHis(string fen, int halfMove, int piece, int emo, string umo, string san, string score, string pv)
        {
            this.halfMove = halfMove;
            this.piece = piece;
            this.emo = emo;
            this.umo = umo;
            this.san = san;
            this.fen = fen;
            this.score = score;
            this.pv = pv;
        }

        public string GetNotation()
        {
            if (FormOptions.isSan)
                return san;
            else
                return umo;
        }

        public string GetPiece()
        {
            string[] p = { "", "\u2659", "\u2658", "\u2657", "\u2656", "\u2655", "\u2654", "", "", "\u265F", "\u265E", "\u265D", "\u265C", "\u265B", "\u265A", "" };
            return p[piece] + GetNotation();
        }

        public string ToStr()
        {
            return $"{san.Trim()},{score.Trim()},{pv.Trim()}";
        }

    }

    public class CHistory : List<CHis>
    {
        public int moveNumber = 0;
        public string fen = CChess.defFen;

        public CHis GetHis(string fen)
        {
            foreach (CHis h in this)
                if (h.fen == fen)
                    return h;
            return null;
        }

        public CHis AddMove(string fen, int halfMove, int piece, int emo, string umo, string san, string score, string pv)
        {
            CHis hm = new CHis(fen, halfMove, piece, emo, umo, san, score, pv);
            Add(hm);
            return hm;
        }

        public bool Back(int c)
        {
            if ((c > 0) && (c <= Count))
            {
                RemoveRange(Count - c, c);
                return true;
            }
            return false;
        }

        public bool BackTo(int mn, bool white)
        {
            int c = Count - (mn << 1) - 1;
            if (white)
                c--;
            return Back(c);
        }

        public CHis Last()
        {
            if (Count == 0)
                return null;
            return this[Count - 1];
        }

        public string LastPiece()
        {
            if (Count == 0)
                return string.Empty;
            return Last().GetPiece();
        }

        public string LastUmo()
        {
            if (Count == 0)
                return string.Empty;
            return Last().umo;
        }

        public bool LastWhite()
        {
            return ((moveNumber + Count) & 1) == 1;
        }

        public void SetFen(string f = CChess.defFen, int mn = 0)
        {
            fen = f;
            moveNumber = mn;
            Clear();
        }

        public void SetLength(int l)
        {
            if (l <= 0)
                Clear();
            else if (l >= Count)
                return;
            else
                RemoveRange(l, Count - l);
        }

        public string GetMovesUci()
        {
            string result = string.Empty;
            foreach (CHis m in this)
                result += $" {m.umo}";
            return result.Trim();
        }

        public string GetMovesNotation(int maxCount)
        {
            string result = string.Empty;
            foreach (CHis hm in this)
            {
                if (maxCount-- <= 0)
                    return result;
                result += $" {hm.GetNotation()}";
            }
            return result.Trim();
        }

        public string GetPgn()
        {
            string result = string.Empty;
            int c = 0;
            for (int n = 0; n < Count; n++)
            {
                if ((++c & 1) > 0)
                    result += $" {(c >> 1) + 1}.";
                CHis hm = this[n];
                result += $" {hm.san}";
            }
            return result.Trim();
        }

        public string GetPosition()
        {
            string result = "position ";
            result += (fen == CChess.defFen) ? "startpos" : "fen " + fen;
            if (Count > 0)
                return result + " moves " + GetMovesUci();
            else
                return result;
        }

        public void SaveToFile(string fileName)
        {
            List<string> sl = new List<string>
            {
                fen
            };
            foreach (CHis his in this)
                sl.Add(his.ToStr());
            File.WriteAllLines(fileName, sl);
        }

        public void LoadFromFile(string fileName)
        {
            string[] list = File.ReadAllLines(fileName);
            if (list.Length < 2)
                return;
            Clear();
            CChess chess = new CChess();
            chess.SetFen(list[0]);
            SetFen(chess.GetFen());
            for (int n = 1; n < list.Length; n++)
            {
                string[] words = list[n].Split(',');
                if (chess.IsValidMove(words[0], out string umo, out string san, out int emo))
                {
                    int pieceType = chess.GetPieceType(emo);
                    chess.MakeMove(umo, out _);
                    AddMove(chess.GetFen(), chess.halfMove - 1, pieceType, emo, umo, san, words[1], words[2].Trim());
                }
            }

        }

    }
}
