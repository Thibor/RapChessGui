using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using NSChess;
using NSRapColor;

namespace RapChessGui
{
	class CPiece
	{
		public int desImage = -1;
		public int image = -1;
		public Point curXY = new Point();
		public Point souXY = new Point();
		public Point desXY = new Point();
		readonly Stopwatch timer = new Stopwatch();

		public bool UpdatePosition()
		{
			if ((curXY.X == desXY.X) && (curXY.Y == desXY.Y))
				return false;
			double dif = timer.Elapsed.TotalMilliseconds / FormOptions.animationSpeed;
			if (dif >= 1)
			{
				curXY.X = desXY.X;
				curXY.Y = desXY.Y;
				desImage = -1;
			}
			else
			{
				curXY.X = Convert.ToInt32(souXY.X * (1 - dif) + desXY.X * dif);
				curXY.Y = Convert.ToInt32(souXY.Y * (1 - dif) + desXY.Y * dif);
			}
			return true;
		}

		public void SetImage(int index)
		{
			desImage = -1;
			int f = FormChess.chess.board[index];
			image = (f & 7) - 1;
			if ((f & CChess.colorBlack) > 0)
				image += 6;
		}

		public void SetPositionAni(int x, int y)
		{
			if ((desXY.X != x) || (desXY.Y != y))
			{
				desXY.X = x;
				desXY.Y = y;
				souXY.X = curXY.X;
				souXY.Y = curXY.Y;
				timer.Restart();
			}
		}

		public void SetPositionSta(int x, int y)
		{
			curXY.X = x;
			curXY.Y = y;
			desXY.X = x;
			desXY.Y = y;
		}


	}

	class CField
	{
		public bool attacked = false;
		public bool circle = false;
		public int x;
		public int y;
		public Color color = Color.Empty;
		public CPiece piece = null;

		public Rectangle GetRect()
		{
			Rectangle rec = new Rectangle();
			rec.X = x;
			rec.Y = y;
			rec.Width = CBackground.fieldSize;
			rec.Height = CBackground.fieldSize;
			return rec;
		}

	}

	class CBackground
	{
		bool rotate = false;
		int width = 10;
		int height = 10;
		public static int fieldSize = 10;
		public int frameSize = 10;
		public int bmpX = 0;
		public int bmpY = 0;
		Bitmap board = new Bitmap(10,10);

		void RenderBoard(int w, int h, bool r)
		{
			width = w;
			height = h;
			rotate = r;
			if (w < 0xf) w = 0xf;
			if (h < 0xf) h = 0xf;
			int min = Math.Min(w, h);
			fieldSize = min / 9;
			frameSize = fieldSize >> 1;
			int bmpSize = 8 * fieldSize + 2 * frameSize;
			bmpX = (w - bmpSize) >> 1;
			bmpY = (h - bmpSize) >> 1;
			string abc = "ABCDEFGH";
			Rectangle rec = new Rectangle();
			board = new Bitmap(bmpSize, bmpSize);
			using (Graphics graphics = Graphics.FromImage(board))
			{
				SolidBrush brush1 = new SolidBrush(CBoard.colorLabelB);
				SolidBrush brush2 = new SolidBrush(Color.FromArgb(0x60, 0x00, 0x00, 0x00));
				SolidBrush brush3 = new SolidBrush(Color.FromArgb(0x60, 0xff, 0xff, 0xff));
				Font font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
				GraphicsPath gp = new GraphicsPath();
				StringFormat sf = new StringFormat();
				Brush foreBrush = new SolidBrush(Color.White);
				Pen outline = new Pen(Color.Black, 4);
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.FillRectangle(brush1, 0, 0, bmpSize, bmpSize);
				for (int y = 0; y < 8; y++)
				{
					int y2 = frameSize + y * fieldSize;
					for (int x = 0; x < 8; x++)
					{
						int x2 = frameSize + x * fieldSize;
						bool bgColor = ((y ^ x) & 1) == 1;
						if (bgColor)
						{
							graphics.FillRectangle(brush2, x2, y2, fieldSize, fieldSize);
						}
						else
						{
							graphics.FillRectangle(brush3, x2, y2, fieldSize, fieldSize);
						}
					}
				}
				for (int n = 0; n < 8; n++)
				{
					int xr = rotate ? 7 - n : n;
					int yr = rotate ? 7 - n : n;
					int x2 = frameSize + xr * fieldSize;
					int y2 = frameSize + yr * fieldSize;
					rec.X = 0;
					rec.Y = y2;
					rec.Width = frameSize;
					rec.Height = fieldSize;
					string letter = (8 - n).ToString();
					gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
					rec.X = board.Width - frameSize;
					gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
					rec.X = x2;
					rec.Y = 0;
					rec.Width = fieldSize;
					rec.Height = frameSize;
					letter = abc[n].ToString();
					gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
					rec.Y = board.Height - frameSize;
					gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
				}
				graphics.DrawPath(outline, gp);
				graphics.FillPath(foreBrush, gp);
				brush1.Dispose();
				brush2.Dispose();
				brush3.Dispose();
				gp.Dispose();
				sf.Dispose();
				font.Dispose();
				foreBrush.Dispose();
				outline.Dispose();
			}
		}

		public void Resize(int w,int h,bool rotateBoard)
		{
			if (w < 0xf) w = 0xf;
			if (h < 0xf) h = 0xf;
			width = w;
			height = h;
			rotate = rotateBoard;
			int min = Math.Min(w, h);
			fieldSize = min / 9;
			frameSize = fieldSize >> 1;
			int bmpSize = 8 * fieldSize + 2 * frameSize;
			bmpX = (w - bmpSize) >> 1;
			bmpY = (h - bmpSize) >> 1;
			RenderBoard(width, height, rotate);
		}

		public Bitmap GetBitmap(bool rotateBoard)
		{
			if (rotate != rotateBoard)
				RenderBoard(width, height, rotateBoard);
			return board;
		}

	}

	class CBoard
	{
		public static Color colorRed = Color.FromArgb(0x80, 0x00, 0x00);
		public static Color colorChartM;
		public static Color colorChartD;
		public static Color colorChartL;
		public static Color colorMessage;
		public static Color colorListW;
		public static Color colorListB;
		public static Color colorLabelW;
		public static Color colorLabelB;
		public bool animated = false;
		public bool finished = true;
		public bool rotateBoard = false;
		public CField[] arrField = new CField[64];
		public Bitmap boardBmp;
		public CArrowList arrowCur = new CArrowList(Color.FromArgb(0x90, 0x10, 0xff, 0x10));
		public CArrowList arrowEco = new CArrowList(Color.FromArgb(0x90, 0xff, 0x10, 0x10));
		readonly CBackground background = new CBackground();

		public CBoard()
		{
			for (int n = 0; n < 64; n++)
				arrField[n] = new CField();
		}

		public void ClearArrows()
		{
			arrowCur.Clear();
			arrowEco.Clear();
			ClearCircles();
		}

		public void ClearAttack()
		{
			foreach (CField f in arrField)
				f.attacked = false;
		}

		public void ClearCircles()
		{
			foreach (CField f in arrField)
				f.circle = false;
		}

		public void ClearColors()
		{
			foreach (CField f in arrField)
				f.color = Color.Empty;
		}

		void DrawArrow(Graphics g, CArrow arrow)
		{
			using (Pen pen = new Pen(arrow.color, 8))
			{
				pen.StartCap = LineCap.RoundAnchor;
				pen.EndCap = LineCap.ArrowAnchor;
				g.DrawLine(pen, GetMiddle(arrow.a), GetMiddle(arrow.b));
			}
		}

		public void DrawArrows(Graphics g, CArrowList al)
		{
			foreach (CArrow a in al.list)
				DrawArrow(g, a);
		}

		void DrawCircle(Graphics g, Rectangle rec)
		{
			using (Pen pen = new Pen(Brushes.ForestGreen, 4))
			{
				g.DrawEllipse(pen, rec);
			}
		}

		public void DrawCircles(Graphics g)
		{
			foreach (CField f in arrField)
				if (f.circle)
					DrawCircle(g, f.GetRect());
		}


		public Point GetMiddle(int x, int y)
		{
			int xr = rotateBoard ? 7 - x : x;
			int yr = rotateBoard ? 7 - y : y;
			x = background.frameSize + xr * CBackground.fieldSize + (CBackground.fieldSize >> 1);
			y = background.frameSize + yr * CBackground.fieldSize + (CBackground.fieldSize >> 1);
			return new Point(x, y);
		}

		public void GetFieldXY(int x, int y, out int ox, out int oy)
		{
			ox = (x - background.frameSize - background.bmpX) / CBackground.fieldSize;
			oy = (y - background.frameSize - background.bmpY) / CBackground.fieldSize;
			if (ox < 0)
				ox = 0;
			if (oy < 0)
				oy = 0;
			if (ox > 7)
				ox = 7;
			if (oy > 7)
				oy = 7;
		}

		Point GetMiddle(Point p)
		{
			return GetMiddle(p.X, p.Y);
		}

		public void RenderArrows(Graphics g)
		{
			Bitmap bmp = new Bitmap(boardBmp);
			Graphics gb = Graphics.FromImage(bmp);
			DrawCircles(gb);
			if (FormOptions.showArrow)
			{
				DrawArrows(gb, arrowCur);
				DrawArrows(gb, arrowEco);

			}
			g.DrawImage(bmp, background.bmpX, background.bmpY);
		}


		public void UpdateField(int index)
		{
			int rank = FormChess.chess.board[index] &7;
			if (rank == 0)
				arrField[index].piece = null;
			else
			{
				CPiece piece = new CPiece();
				arrField[index].piece = piece;
				piece.SetImage(index);
			}
		}

		public void Fill()
		{
			for (int n = 0; n < 64; n++)
				UpdateField(n);
			SetPosition();
			ShowAttack(FormOptions.showAttack);
			RenderBoard();
		}

		public void Resize(int w, int h)
		{
			background.Resize(w,h,rotateBoard);
			SetPosition();
			RenderBoard();
		}

		public void RenderBoard()
		{
			boardBmp = new Bitmap(background.GetBitmap(rotateBoard));
			using (Graphics g = Graphics.FromImage(boardBmp))
			using (Brush brushRed = new SolidBrush(Color.FromArgb(0x80, 0xff, 0x00, 0x00)))
			using (Brush brushYellow = new SolidBrush(Color.FromArgb(0xa0, 0xff, 0xff, 0xff)))
			using (Brush brushWhite = new SolidBrush(Color.White))
			using (Brush brushBlack = new SolidBrush(Color.Black))
			using (Font fontPiece = new Font(FormChess.pfc.Families[0], CBackground.fieldSize))
			using (Pen penW = new Pen(Color.Black, 4))
			using (Pen penB = new Pen(Color.White, 4))
			using (GraphicsPath gpW = new GraphicsPath())
			using (GraphicsPath gpB = new GraphicsPath())
			using (StringFormat sf = new StringFormat())
			{
				Rectangle rec = new Rectangle();
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;
				g.SmoothingMode = SmoothingMode.HighQuality;
				for (int y = 0; y < 8; y++)
				{
					int yr = rotateBoard ? 7 - y : y;
					int y2 = background.frameSize + yr * CBackground.fieldSize;
					for (int x = 0; x < 8; x++)
					{
						int i = y * 8 + x;
						int xr = rotateBoard ? 7 - x : x;
						int x2 = background.frameSize + xr * CBackground.fieldSize;
						rec.X = x2;
						rec.Y = y2;
						rec.Width = CBackground.fieldSize;
						rec.Height = CBackground.fieldSize;
						if ((i == CDrag.lastSou) || (i == CDrag.lastDes) || (arrField[i].color != Color.Empty))
							g.FillRectangle(brushYellow, rec);
						else if (arrField[i].attacked && (CData.gameMode != CGameMode.edit))
							g.FillRectangle(brushRed, rec);
						CPiece piece = arrField[i].piece;
						if (piece == null)
							continue;
						if (piece.image < 0)
							continue;
						GraphicsPath gp1;
						int image;
						if (piece.desImage >= 0)
						{
							gp1 = piece.desImage > 5 ? gpB : gpW;
							image = piece.desImage % 6;
							gp1.AddString("pnbrqk"[image].ToString(), fontPiece.FontFamily, (int)fontPiece.Style, fontPiece.Size, rec, sf);
						}
						arrField[i].x = x2;
						arrField[i].y = y2;
						piece.SetPositionAni(x2, y2);
						if ((i == CDrag.lastDes) && CDrag.dragged)
							piece.SetPositionSta(CDrag.mouseX - background.frameSize - background.bmpX, CDrag.mouseY - background.frameSize - background.bmpY);
						rec.X = piece.curXY.X;
						rec.Y = piece.curXY.Y;
						gp1 = piece.image > 5 ? gpB : gpW;
						image = piece.image % 6;
						gp1.AddString("pnbrqk"[image].ToString(), fontPiece.FontFamily, (int)fontPiece.Style, fontPiece.Size, rec, sf);
					}
				}
				if (FormChess.chess.WhiteTurn)
				{
					g.DrawPath(penB, gpB);
					g.FillPath(brushBlack, gpB);
					g.DrawPath(penW, gpW);
					g.FillPath(brushWhite, gpW);

				}
				else
				{
					g.DrawPath(penW, gpW);
					g.FillPath(brushWhite, gpW);
					g.DrawPath(penB, gpB);
					g.FillPath(brushBlack, gpB);

				}
			}
		}

		public void MakeMove(int sou, int des)
		{
			arrField[des].piece = arrField[sou].piece;
			arrField[sou].piece = null;
		}

		public void MakeMove(int gm)
		{
			animated = true;
			int flags = gm & 0xFF0000;
			int sou = gm & 0xFF;
			int des = (gm >> 8) & 0xFF;
			int xs = sou & 7;
			int ys = sou >> 3;
			int xd = des & 7;
			int yd = des >> 3;
			sou = ys * 8 + xs;
			des = yd * 8 + xd;
			CPiece pd = arrField[des].piece;
			if (pd != null)
				arrField[sou].piece.desImage = pd.image;
			MakeMove(sou, des);
			if ((flags & CChess.moveflagCastleKing) > 0)
			{
				MakeMove(sou + 3, sou + 1);
			}
			if ((flags & CChess.moveflagCastleQueen) > 0)
			{
				MakeMove(sou - 4, sou - 1);
			}
			ClearColors();
		}

		public void SetColor()
		{
			CRapColor.SetColor(FormOptions.colorBoard);
			colorLabelB = CRapColor.GetColor(CRapColor.H, 0.4, 0.2);
			colorLabelW = CRapColor.GetColor(CRapColor.H, 0.4, 0.8);
			colorListB = CRapColor.GetColor(CRapColor.H, 0.2, 0.8);
			colorListW = CRapColor.GetColor(CRapColor.H, 0.2, 0.9);
			colorMessage = CRapColor.GetColor(CRapColor.H, 0.3, 0.9);
			colorChartD = CRapColor.GetColor(CRapColor.H, 0.8, 0.3);
			colorChartM = CRapColor.GetColor(CRapColor.H, 0.8, 0.4);
			colorChartL = CRapColor.GetColor(CRapColor.H, 0.8, 0.5);
		}

		public void UpdatePosition()
		{
			animated = false;
			foreach (CField f in arrField)
			{
				CPiece p = f.piece;
				if (p != null)
					if (p.UpdatePosition())
						animated = true;
			}
		}

		public void SetPosition()
		{
			for (int y = 0; y < 8; y++)
			{
				int yr = rotateBoard ? 7 - y : y;
				int y2 = background.frameSize + yr * CBackground.fieldSize;
				for (int x = 0; x < 8; x++)
				{
					int i = y * 8 + x;
					int xr = rotateBoard ? 7 - x : x;
					int x2 = background.frameSize + xr * CBackground.fieldSize;
					arrField[i].x = x2;
					arrField[i].y = y2;
					CPiece piece = arrField[i].piece;
					if (piece == null)
						continue;
					piece.SetPositionSta(x2, y2);
				}
			}
		}

		public void SetImage()
		{
			for (int n = 0; n < 64; n++)
			{
				int rank = FormChess.chess.board[n] &7;
				if (rank==0)
					arrField[n].piece = null;
				else
					arrField[n].piece.SetImage(n);
			}
		}

		public void ShowAttack(bool show, bool white)
		{
			List<int> ml = FormChess.chess.GenerateAllMoves(white, false);
			foreach (int m in ml)
			{
				int d = (m >> 8) & 0xff;
				int r = FormChess.chess.board[d] & 7;
				if (r > 0)
					if (show || (r == CChess.pieceKing))
						arrField[d].attacked = true;
			}
		}

		public void ShowAttack(bool show)
		{
			ClearAttack();
			if (show)
				ShowAttack(show, FormChess.chess.WhiteTurn);
			ShowAttack(show, !FormChess.chess.WhiteTurn);
		}

	}

}
