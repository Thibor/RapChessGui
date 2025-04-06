using System.Collections.Generic;
using NSChess;
using System.IO;
using NSUci;
using System;
using System.Drawing;

namespace RapChessGui
{
    public class CHis
    {
        public int piece;
        public int emo;
        public string umo = string.Empty;
        public string san = string.Empty;
        public string fen = string.Empty;
        public string score = string.Empty;
        public string pv = string.Empty;
        public string pvCur = string.Empty;
        public string pvBst = string.Empty;

        public CHis(CHis h)
        {
            Assign(h);
        }

        public CHis(string fen, int piece, int emo, string umo, string san, string score, string pv)
        {
            this.piece = piece;
            this.emo = emo;
            this.umo = umo;
            this.san = san;
            this.fen = fen;
            this.score = score;
            this.pv = pv;
        }

        public void Assign(CHis h)
        {
            piece = h.piece;
            emo = h.emo;
            umo = h.umo;
            san = h.san;
            fen = h.fen;
            score = h.score;
            pv = h.pv;
            pvCur = h.pvCur;
            pvBst = h.pvBst;
        }

        public int GetHalfMove()
        {
            CChess chess = new CChess();
            chess.SetFen(fen);
            return chess.halfMove;
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
        public string fen = CChess.defFen;

        public void Assign(CHistory hl, int count)
        {
            Clear();
            fen = hl.fen;
            for(int n = 0; n < hl.Count; n++)
            {
                if (n >= count)
                    return;
                Add(new CHis(hl[n]));
            }
        }

        public CHis AddMove(string fen, int piece, int emo, string umo, string san, string score, string pv)
        {
            CHis hm = new CHis(fen, piece, emo, umo, san, score, pv);
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

        public void SetFen(string f = CChess.defFen)
        {
            Clear();
            fen = f;
        }

        public int GetFenIndex(string f)
        {
            if(fen==f)
                return 0;
            for(int n=0;n<Count;n++)
                if (this[n].fen==f)
                    return n + 1;
            return -1;
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
                    AddMove(chess.GetFen(), pieceType, emo, umo, san, words[1], words[2].Trim());
                }
            }

        }

        public void AddMoves(string moves, string pv)
        {
            CChess chess = new CChess();
            string[] ml = moves.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            chess.SetFen(fen);
            chess.MakeMoves(GetMovesUci());
            foreach (string move in ml)
            {
                if (Char.IsDigit(move, 0))
                    continue;
                if (!chess.IsValidMove(move, out string umo, out string san, out int emo))
                    continue;
                int piece = chess.GetPieceType(emo);
                chess.MakeMove(emo);
                AddMove(chess.GetFen(), piece, emo, umo, san, string.Empty, pv);
            }
        }

    }
}
