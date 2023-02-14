using System.Collections.Generic;
using System.Drawing;
using NSChess;

namespace RapChessGui
{

	public class CArrow
	{
		public Point a;
		public Point b;
		public Color color;

		public void SetAB(int ax, int ay, int bx, int by)
		{
			a.X = ax;
			a.Y = ay;
			b.X = bx;
			b.Y = by;
		}

		public void SetAB(int a, int b)
		{
			int ax = a & 7;
			int ay = a >> 3;
			int bx = b & 7;
			int by = b >> 3;
			SetAB(ax, ay, bx, by);
		}

	}

	public class CArrowList
	{
		readonly Color color;
		public List<CArrow> list = new List<CArrow>();

		public CArrowList(Color c)
		{
			color = c;
		}

		public void Clear()
		{
			list.Clear();
		}

		public void Add(string umo)
		{
			CArrow arrow = new CArrow();
			arrow.color = color;
			CChess.UmoToSD(umo, out int sou, out int des);
			arrow.SetAB(sou, des);
			list.Add(arrow);
		}

		public void AddMoves(string moves)
		{
			Clear();
			string[] arrMoves = moves.Split(' ');
			foreach (string m in arrMoves)
				Add(m);
		}

	}
}
