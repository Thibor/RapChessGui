﻿using System;
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
			int speed = Convert.ToInt32(FormOptions.This.nudSpeed.Value);
			double dif = timer.Elapsed.TotalMilliseconds / speed;
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
			int i = CChess.arrField[index];
			int f = FormChess.Chess.g_board[i];
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
		public int x;
		public int y;
		public Color color = Color.Empty;
		public CPiece piece = null;
	}

	class CBoard
	{
		public static Color colorBoard;
		public static Color colorDefault = Color.FromArgb(0xff, 0xff, 0x80);
		public static Color colorRed = Color.FromArgb(0x80, 0x00, 0x00);
		public static Color colorChartM;
		public static Color colorChartD;
		public static Color colorChartL;
		public static Color colorMessage;
		public static Color colorListW;
		public static Color colorListB;
		public static Color colorLabelW;
		public static Color colorLabelB;
		public static bool animated = false;
		public static bool finished = true;
		public static CField[] list = new CField[64];
		int bmpX = 0;
		int bmpY = 0;
		int bmpSize = 64 * 8 + 32 * 2;
		int frame = 32;
		int field = 64;
		public static Bitmap[] background = new Bitmap[2];
		public Bitmap bmpBoard;
		public CArrowList arrowCur = new CArrowList(Color.FromArgb(0x90, 0x10, 0xff, 0x10));
		public CArrowList arrowEco = new CArrowList(Color.FromArgb(0x90, 0xff, 0x10, 0x10));

		public CBoard()
		{
			for (int n = 0; n < 64; n++)
				list[n] = new CField();
		}

		public void ClearArrows()
		{
			arrowCur.Clear();
			arrowEco.Clear();
		}

		public void ClearColors()
		{
			for (int n = 0; n < 64; n++)
				list[n].color = Color.Empty;
		}

		public Point GetMiddle(int x, int y)
		{
			int xr = FormChess.boardRotate ? 7 - x : x;
			int yr = FormChess.boardRotate ? 7 - y : y;
			x = frame + xr * field + (field >> 1);
			y = frame + yr * field + (field >> 1);
			return new Point(x, y);
		}

		public void GetFieldXY(int x, int y, out int ox, out int oy)
		{
			ox = (x - frame - bmpX) / field;
			oy = (y - frame - bmpY) / field;
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

		void RenderArrow(Graphics g, CArrow arrow)
		{
			Pen pen = new Pen(arrow.color, 8);
			pen.StartCap = LineCap.RoundAnchor;
			pen.EndCap = LineCap.ArrowAnchor;
			g.DrawLine(pen, GetMiddle(arrow.a), GetMiddle(arrow.b));
		}

		public void RenderArrow(Graphics g, CArrowList al)
		{
			foreach (CArrow a in al.list)
				RenderArrow(g, a);
		}

		public void RenderArrow(Graphics g, bool show)
		{
			if (show)
			{
				Bitmap bmpArrow = new Bitmap(bmpBoard);
				Graphics ga = Graphics.FromImage(bmpArrow);
				RenderArrow(ga, arrowCur);
				RenderArrow(ga, arrowEco);
				g.DrawImage(bmpArrow, bmpX, bmpY);
			}
			else
				g.DrawImage(bmpBoard, bmpX, bmpY);
		}


		public static void UpdateField(int index)
		{
			int i = CChess.arrField[index];
			int f = FormChess.Chess.g_board[i];
			if ((f & CChess.colorEmpty) > 0)
				list[index].piece = null;
			else
			{
				CPiece piece = new CPiece();
				list[index].piece = piece;
				piece.SetImage(index);
			}
		}

		public void Fill()
		{
			for (int n = 0; n < 64; n++)
				UpdateField(n);
			SetPosition();
			ShowAttack(FormOptions.This.cbAttack.Checked);
			RenderBoard();
		}

		public void CreateBackground(int index)
		{
			int size = field * 8 + frame * 2;
			string abc = "ABCDEFGH";
			Rectangle rec = new Rectangle();
			Bitmap bmp = new Bitmap(size, size);
			Graphics g = Graphics.FromImage(bmp);
			SolidBrush brush1 = new SolidBrush(colorLabelB);
			SolidBrush brush2 = new SolidBrush(Color.FromArgb(0x60, 0x00, 0x00, 0x00));
			SolidBrush brush3 = new SolidBrush(Color.FromArgb(0x60, 0xff, 0xff, 0xff));
			Font font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
			GraphicsPath gp = new GraphicsPath();
			StringFormat sf = new StringFormat();
			Brush foreBrush = new SolidBrush(Color.White);
			Pen outline = new Pen(Color.Black, 4);
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.FillRectangle(brush1, 0, 0, size, size);
			for (int y = 0; y < 8; y++)
			{
				int y2 = frame + y * field;
				for (int x = 0; x < 8; x++)
				{
					int x2 = frame + x * field;
					bool bgColor = ((y ^ x) & 1) == 1;
					if (bgColor)
					{
						g.FillRectangle(brush2, x2, y2, field, field);
					}
					else
					{
						g.FillRectangle(brush3, x2, y2, field, field);
					}
				}
			}
			for (int n = 0; n < 8; n++)
			{
				int xr = index == 1 ? 7 - n : n;
				int yr = index == 1 ? 7 - n : n;
				int x2 = frame + xr * field;
				int y2 = frame + yr * field;
				rec.X = 0;
				rec.Y = y2;
				rec.Width = frame;
				rec.Height = field;
				string letter = (8 - n).ToString();
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
				rec.X = bmp.Width - frame;
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
				rec.X = x2;
				rec.Y = 0;
				rec.Width = field;
				rec.Height = frame;
				letter = abc[n].ToString();
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
				rec.Y = bmp.Height - frame;
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
			}
			g.DrawPath(outline, gp);
			g.FillPath(foreBrush, gp);
			background[index] = new Bitmap(bmp);
			brush1.Dispose();
			brush2.Dispose();
			brush3.Dispose();
			bmp.Dispose();
			g.Dispose();
			gp.Dispose();
			sf.Dispose();
			font.Dispose();
			foreBrush.Dispose();
			outline.Dispose();
		}

		public void Resize(int w, int h)
		{
			if (w < 0xf) w = 0xf;
			if (h < 0xf) h = 0xf;
			int min = Math.Min(w, h);
			field = min / 9;
			frame = field >> 1;
			bmpSize = 8 * field + 2 * frame;
			bmpX = (w - bmpSize) >> 1;
			bmpY = (h - bmpSize) >> 1;
			CreateBackground(0);
			CreateBackground(1);
			SetPosition();
			RenderBoard();
		}

		public void RenderBoard()
		{
			bmpBoard = new Bitmap(background[FormChess.boardRotate ? 1 : 0]);
			Graphics g = Graphics.FromImage(bmpBoard);
			Brush brushRed = new SolidBrush(Color.FromArgb(0x80, 0xff, 0x00, 0x00));
			Brush brushYellow = new SolidBrush(Color.FromArgb(0xa0, 0xff, 0xff, 0xff));
			Brush brushWhite = new SolidBrush(Color.White);
			Brush brushBlack = new SolidBrush(Color.Black);
			Font fontPiece = new Font(FormChess.pfc.Families[0], field);
			Pen penW = new Pen(Color.Black, 4);
			Pen penB = new Pen(Color.White, 4);
			GraphicsPath gpW = new GraphicsPath();
			GraphicsPath gpB = new GraphicsPath();
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
			g.SmoothingMode = SmoothingMode.HighQuality;
			Rectangle rec = new Rectangle();
			for (int y = 0; y < 8; y++)
			{
				int yr = FormChess.boardRotate ? 7 - y : y;
				int y2 = frame + yr * field;
				for (int x = 0; x < 8; x++)
				{
					int i = y * 8 + x;
					int xr = FormChess.boardRotate ? 7 - x : x;
					int x2 = frame + xr * field;
					rec.X = x2;
					rec.Y = y2;
					rec.Width = field;
					rec.Height = field;
					if ((i == CDrag.lastSou) || (i == CDrag.lastDes) || (list[i].color != Color.Empty))
						g.FillRectangle(brushYellow, rec);
					else if (list[i].attacked && (CData.gameMode != CGameMode.edit))
						g.FillRectangle(brushRed, rec);
					CPiece piece = list[i].piece;
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
					list[i].x = x2;
					list[i].y = y2;
					piece.SetPositionAni(x2, y2);
					if ((i == CDrag.lastDes) && CDrag.dragged)
						piece.SetPositionSta(CDrag.mouseX - frame - bmpX, CDrag.mouseY - frame - bmpY);
					rec.X = piece.curXY.X;
					rec.Y = piece.curXY.Y;
					gp1 = piece.image > 5 ? gpB : gpW;
					image = piece.image % 6;
					gp1.AddString("pnbrqk"[image].ToString(), fontPiece.FontFamily, (int)fontPiece.Style, fontPiece.Size, rec, sf);
				}
			}
			if (FormChess.Chess.whiteTurn)
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
			sf.Dispose();
			penW.Dispose();
			penB.Dispose();
			brushRed.Dispose();
			brushYellow.Dispose();
			brushWhite.Dispose();
			brushBlack.Dispose();
			fontPiece.Dispose();
			g.Dispose();
		}

		public static void MakeMove(int sou, int des)
		{
			list[des].piece = list[sou].piece;
			list[sou].piece = null;
		}

		public void MakeMove(int gm)
		{
			animated = true;
			int flags = gm & 0xFF0000;
			int sou = gm & 0xFF;
			int des = (gm >> 8) & 0xFF;
			int xs = (sou & 0xf) - 4;
			int ys = (sou >> 4) - 4;
			int xd = (des & 0xf) - 4;
			int yd = (des >> 4) - 4;
			sou = ys * 8 + xs;
			des = yd * 8 + xd;
			CPiece pd = list[des].piece;
			if (pd != null)
				list[sou].piece.desImage = pd.image;
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

		public static void SetColor(Color c)
		{
			colorBoard = c;
			SetColor();
		}

		public static void SetColor()
		{
			CRapColor.SetColor(colorBoard);
			colorLabelB = CRapColor.GetColor(CRapColor.H, 0.4, 0.2);
			colorLabelW = CRapColor.GetColor(CRapColor.H, 0.4, 0.8);
			colorListB = CRapColor.GetColor(CRapColor.H, 0.2, 0.8);
			colorListW = CRapColor.GetColor(CRapColor.H, 0.2, 0.9);
			colorMessage = CRapColor.GetColor(CRapColor.H, 0.3, 0.9);
			colorChartD = CRapColor.GetColor(CRapColor.H, 0.8, 0.3);
			colorChartM = CRapColor.GetColor(CRapColor.H, 0.8, 0.4);
			colorChartL = CRapColor.GetColor(CRapColor.H, 0.8, 0.5);
		}

		public static void UpdatePosition()
		{
			animated = false;
			foreach (CField f in list)
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
				int yr = FormChess.boardRotate ? 7 - y : y;
				int y2 = frame + yr * field;
				for (int x = 0; x < 8; x++)
				{
					int i = y * 8 + x;
					int xr = FormChess.boardRotate ? 7 - x : x;
					int x2 = frame + xr * field;
					list[i].x = x2;
					list[i].y = y2;
					CPiece piece = list[i].piece;
					if (piece == null)
						continue;
					piece.SetPositionSta(x2, y2);
				}
			}
		}

		public static void SetImage()
		{
			for (int n = 0; n < 64; n++)
			{
				int i = CChess.arrField[n];
				int f = FormChess.Chess.g_board[i];
				if ((f & CChess.colorEmpty) > 0)
					list[n].piece = null;
				else
					list[n].piece.SetImage(n);
			}
		}

		public static void ShowAttack(bool show, bool white)
		{
			List<int> ml = CChess.This.GenerateAllMoves(white, false);
			foreach (int m in ml)
			{
				int d = (m >> 8) & 0xff;
				int r = FormChess.Chess.g_board[d] & 7;
				if (r > 0)
					if (show || (r == CChess.pieceKing))
					{
						int i = CChess.Con256To64(d);
						list[i].attacked = true;
					}
			}
		}

		public static void ClearAttack()
		{
			for (int n = 0; n < 64; n++)
				list[n].attacked = false;
		}

		public static void ShowAttack(bool show)
		{
			ClearAttack();
			if (show)
				ShowAttack(show, FormChess.Chess.whiteTurn);
			ShowAttack(show, !FormChess.Chess.whiteTurn);
		}

	}

}
