using System.Collections.Generic;
using NSChess;

namespace RapChessGui
{
	public class CHisMove
	{
		public int halfMove;
		public int piece;
		public int emo;
		public string umo;
		public string san;
		public string score = string.Empty;

		public CHisMove(int halfMove, int piece, int emo, string umo, string san, string score)
		{
			this.halfMove = halfMove;
			this.piece = piece;
			this.emo = emo;
			this.umo = umo;
			this.san = san;
			this.score = score;
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

	}

	public static class CHistory
	{
		public static int moveNumber = 0;
		public static string fen = CChess.defFen;
		public static List<CHisMove> moveList = new List<CHisMove>();

		public static CHisMove AddMove(int halfMove, int piece, int emo, string umo, string san, string score)
		{
			CHisMove hm = new CHisMove(halfMove, piece, emo, umo, san, score);
			moveList.Add(hm);
			return hm;
		}

		public static bool Back(int c)
		{
			if ((c > 0) && (c <= moveList.Count))
			{
				moveList.RemoveRange(moveList.Count - c, c);
				return true;
			}
			return false;
		}

		public static bool BackTo(int mn, bool white)
		{
			int c = moveList.Count - (mn << 1) - 1;
			if (white)
				c--;
			return Back(c);
		}

		public static CHisMove Last()
		{
			if (moveList.Count == 0)
				return null;
			return moveList[moveList.Count - 1];
		}

		public static string LastPiece()
		{
			if (moveList.Count == 0)
				return string.Empty;
			return moveList[moveList.Count - 1].GetPiece();
		}

		public static string LastUmo()
		{
			if (moveList.Count == 0)
				return "";
			return moveList[moveList.Count - 1].umo;
		}

		public static bool LastWhite()
		{
			return ((moveNumber + moveList.Count) & 1) == 1;
		}
		public static void SetFen(string f = CChess.defFen, int mn = 0)
		{
			fen = f;
			moveNumber = mn;
			moveList.Clear();
		}

		public static string GetUci()
		{
			string result = string.Empty;
			foreach (CHisMove m in moveList)
				result += $" {m.umo}";
			return result.Trim();
		}

		public static string GetMovesNotation(int maxCount)
		{
			string result = string.Empty;
			foreach (CHisMove hm in moveList)
			{
				if (maxCount-- <= 0)
					return result;
				result += $" {hm.GetNotation()}";
			}
			return result.Trim();
		}

		public static string GetPgn()
		{
			string result = string.Empty;
			int c = 0;
			for (int n = 0; n < moveList.Count; n++)
			{
				if ((++c & 1) > 0)
					result += $" {(c >> 1) + 1}.";
				CHisMove hm = moveList[n];
				result += $" {hm.san}";
			}
			return result.Trim();
		}

		public static string GetPosition()
		{
			string result = "position ";
			result += (fen == CChess.defFen) ? "startpos" : "fen " + fen;
			if (moveList.Count > 0)
				return result + " moves " + GetUci();
			else
				return result;
		}

	}
}
