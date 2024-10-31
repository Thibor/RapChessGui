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

	public class CArrowList: List<CArrow>
	{ 

        public void Clear(Color color)
        {
			for(int n=Count-1;n>=0;n--)
				if (this[n].color==color)
					RemoveAt(n);
        }

        public void Add(string umo,Color color)
		{
			CArrow arrow = new CArrow();
			arrow.color = color;
			CChess.UmoToSD(umo, out int sou, out int des);
			arrow.SetAB(sou, des);
			Add(arrow);
		}

		public void AddMoves(string moves,Color color)
		{
			Clear(color);
			string[] arrMoves = moves.Split(' ');
			foreach (string m in arrMoves)
				Add(m,color);
		}

	}
}
