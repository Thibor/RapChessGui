﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using NSChess;
using NSRapColor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace RapChessGui
{

    static class Colors
    {
        public static Color red = Color.FromArgb(0x80, 0x00, 0x00);
        public static Color chartM;
        public static Color chartD;
        public static Color chartL;
        public static Color message;
        public static Color listW;
        public static Color listB;
        public static Color labelW;
        public static Color labelB;
        public static Color board;

        public static void SetColor()
        {
            CRapColor.SetColor(FormOptions.color);
            labelB = CRapColor.GetColor(CRapColor.H, 0.4, 0.2);
            labelW = CRapColor.GetColor(CRapColor.H, 0.4, 0.8);
            listB = CRapColor.GetColor(CRapColor.H, 0.2, 0.8);
            listW = CRapColor.GetColor(CRapColor.H, 0.2, 0.9);
            message = CRapColor.GetColor(CRapColor.H, 0.3, 0.9);
            chartD = CRapColor.GetColor(CRapColor.H, 0.8, 0.3);
            chartM = CRapColor.GetColor(CRapColor.H, 0.8, 0.4);
            chartL = CRapColor.GetColor(CRapColor.H, 0.8, 0.5);
            board = CRapColor.GetColor(CRapColor.H, 0.2, 0.3);
        }
    }

    public class CPiece
    {
        public int desImage = -1;
        public int image = -1;
        public Point curXY = new Point();
        public Point souXY = new Point();
        public Point desXY = new Point();

        public bool Animate()
        {
            if ((curXY.X == desXY.X) && (curXY.Y == desXY.Y))
                return false;
            double dif = CBoard.timer.Elapsed.TotalMilliseconds / FormOptions.animationSpeed;
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
            }
        }

        public void SetPositionSta(int x, int y)
        {
            curXY.X = x;
            curXY.Y = y;
            desXY.X = x;
            desXY.Y = y;
            souXY.X = x;
            souXY.Y = y;
        }


    }

    public class CField
    {
        public bool circle = false;
        public int x;
        public int y;
        public Color color = Color.Empty;
        public CPiece piece = null;
        readonly CBackground background;

        public CField(CBackground b)
        {
            background = b;
        }

        public Rectangle GetRect()
        {
            Rectangle rec = new Rectangle();
            rec.X = x;
            rec.Y = y;
            rec.Width = background.fieldSize;
            rec.Height = background.fieldSize;
            return rec;
        }

    }

    public class CBackground
    {
        bool rotate = false;
        public int arrowSize = 1;
        public int fieldSize = 10;
        public int frameSize = 10;
        public int bmpX = 0;
        public int bmpY = 0;
        public int size = 10;
        public int sizem1 = 9;
        int width = 10;
        int height = 10;
        Bitmap board = new Bitmap(10, 10);

        public void Resize(int w, int h)
        {
            if (w < 0xf) w = 0xf;
            if (h < 0xf) h = 0xf;
            if ((w == width) && (h == height))
                return;
            width = w;
            height = h;
            fieldSize = Math.Min(w, h) / 9;
            arrowSize = fieldSize / 6;
            frameSize = fieldSize >> 1;
            size = 8 * fieldSize + 2 * frameSize;
            sizem1 = size - 1;
            bmpX = (w - size) >> 1;
            bmpY = (h - size) >> 1;
            Render();
        }

        void RenderFields(Graphics g)
        {
            using (SolidBrush brushB = new SolidBrush(Color.FromArgb(76, 0x00, 0x00, 0x00)))
            using (SolidBrush brushW = new SolidBrush(Color.FromArgb(76, 0xff, 0xff, 0xff)))
            {
                for (int y = 0; y < 8; y++)
                {
                    int y2 = frameSize + y * fieldSize;
                    for (int x = 0; x < 8; x++)
                    {
                        int x2 = frameSize + x * fieldSize;
                        bool bgColor = ((y ^ x) & 1) == 1;
                        if (bgColor)
                            g.FillRectangle(brushB, x2, y2, fieldSize, fieldSize);
                        else
                            g.FillRectangle(brushW, x2, y2, fieldSize, fieldSize);
                    }
                }
            }
        }

        void RenderGrid(Graphics g)
        {
            using (Pen penW = new Pen(Color.White, 1))
            using (Pen penB = new Pen(Color.Black, 1))
            {
                int e = frameSize + 8 * fieldSize;
                for (int n = 0; n < 9; n++)
                {
                    int n2 = frameSize + n * fieldSize;
                    g.DrawLine(penB, frameSize, n2, e, n2);
                    g.DrawLine(penB, n2, frameSize, n2, e);
                }
                g.DrawLine(penW, 0, 0, sizem1, 0);
                g.DrawLine(penW, 0, 0, 0, sizem1);
                g.DrawLine(penB, 1, sizem1, sizem1, sizem1);
                g.DrawLine(penB, sizem1, 1, sizem1, sizem1);
            }
        }

        void RenderNotation(Graphics g)
        {
            using (GraphicsPath gp = new GraphicsPath())
            using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            using (Font font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold))
            using (Brush foreBrush = new SolidBrush(Color.White))
            using (Pen outline = new Pen(Color.Black, 4))
            {
                string abc = "ABCDEFGH";
                Rectangle rec = new Rectangle();
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
                g.DrawPath(outline, gp);
                g.FillPath(foreBrush, gp);
            }
        }

        public void Render()
        {
            board = new Bitmap(size, size);
            using (Graphics graphics = Graphics.FromImage(board))
            using (SolidBrush brush = new SolidBrush(Colors.board))
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.FillRectangle(brush, 0, 0, size, size);
                RenderFields(graphics);
                RenderGrid(graphics);
                RenderNotation(graphics);
            }
        }

        public Bitmap GetBitmap(bool rotateBoard)
        {
            if (rotate == rotateBoard)
                return board;
            rotate = rotateBoard;
            Render();
            return board;
        }

    }

    public class CBoard
    {
        public static Color Green = Color.FromArgb(0xa0, 0x00, 0xff, 0x00);
        public static Color Red = Color.FromArgb(0xa0, 0xff, 0x00, 0x00);
        public static Color Blue = Color.FromArgb(0xa0, 0x00, 0x00, 0xff);
        public static Color Yellow = Color.FromArgb(0xa0, 0xff, 0xff, 0x00);
        public static Color Orange = Color.FromArgb(0xa0, 0xff, 0x80, 0x00);
        public bool animated = false;
        public bool done = true;
        public bool rotate = false;
        public CField[] arrField = new CField[64];
        public Bitmap boardBmp;
        public CArrowList arrows = new CArrowList();
        public CBackground background = new CBackground();
        public static readonly Stopwatch timer = new Stopwatch();

        public CBoard()
        {
            for (int n = 0; n < 64; n++)
                arrField[n] = new CField(background);
        }

        public void ClearArrows()
        {
            arrows.Clear();
            ClearCircles();
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
            int shift = arrow.shift * background.arrowSize;
            using (Pen pen = new Pen(arrow.color,background.arrowSize))
            {
                pen.StartCap = LineCap.RoundAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                Point p1 = GetMiddle(arrow.a);
                Point p2 = GetMiddle(arrow.b);
                if (p1.X == p2.X)
                {
                    p1.X += shift;
                    p2.X += shift;
                }
                else
                {
                    p1.Y+= shift;
                    p2.Y+= shift;
                }
                g.DrawLine(pen,p1,p2);
            }
        }

        public void DrawArrows(Graphics g)
        {
            foreach (CArrow a in arrows)
                DrawArrow(g, a);
        }

        void DrawCircle(Graphics g, Rectangle rec)
        {
            using (Brush brushBlue = new SolidBrush(Blue))
            using (Pen pen = new Pen(brushBlue, background.arrowSize))
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
            int xr = rotate ? 7 - x : x;
            int yr = rotate ? 7 - y : y;
            x = background.frameSize + xr * background.fieldSize + (background.fieldSize >> 1);
            y = background.frameSize + yr * background.fieldSize + (background.fieldSize >> 1);
            return new Point(x, y);
        }

        public void GetFieldXY(int x, int y, out int ox, out int oy)
        {
            ox = (x - background.frameSize - background.bmpX) / background.fieldSize;
            oy = (y - background.frameSize - background.bmpY) / background.fieldSize;
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
                DrawArrows(gb);
            g.DrawImage(bmp, background.bmpX, background.bmpY);
        }


        public void UpdateField(int index)
        {
            int rank = FormChess.chess.board[index] & 7;
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
            ShowAttack();
            Render();
        }

        public void Resize(int w, int h)
        {
            background.Resize(w, h);
            SetPosition();
            Render();
        }

        public void Render()
        {
            boardBmp = new Bitmap(background.GetBitmap(rotate));
            using (Graphics g = Graphics.FromImage(boardBmp))
            using (Brush brushRed = new SolidBrush(Red))
            using (Brush brushYellow = new SolidBrush(Color.FromArgb(0xa0, 0xff, 0xff, 0xff)))
            using (Brush brushWhite = new SolidBrush(Color.White))
            using (Brush brushBlack = new SolidBrush(Color.Black))
            using (Font fontPiece = new Font(FormChess.pfc.Families[0], background.fieldSize))
            using (Pen penBlack = new Pen(Color.Black, 4))
            using (Pen penWhite = new Pen(Color.White, 4))
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
                    int yr = rotate ? 7 - y : y;
                    int y2 = background.frameSize + yr * background.fieldSize;
                    for (int x = 0; x < 8; x++)
                    {
                        int i = y * 8 + x;
                        int xr = rotate ? 7 - x : x;
                        int x2 = background.frameSize + xr * background.fieldSize;
                        rec.X = x2;
                        rec.Y = y2;
                        rec.Width = background.fieldSize;
                        rec.Height = background.fieldSize;
                        Color c = arrField[i].color;
                        if ((i == CDrag.lastSou) || (i == CDrag.lastDes))
                            g.FillRectangle(brushYellow, rec);
                        else if ((c != Color.Empty) && (CData.gameMode != CGameMode.edit))
                            using (Brush b = new SolidBrush(c))
                            {
                                g.FillRectangle(b, rec);
                            }
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
                        if ((i == CDrag.lastDes) && CDrag.dragged)
                            piece.SetPositionSta(CDrag.mouseX - background.frameSize - background.bmpX, CDrag.mouseY - background.frameSize - background.bmpY);
                        else
                            piece.SetPositionAni(x2, y2);
                        rec.X = piece.curXY.X;
                        rec.Y = piece.curXY.Y;
                        gp1 = piece.image > 5 ? gpB : gpW;
                        image = piece.image % 6;
                        gp1.AddString("pnbrqk"[image].ToString(), fontPiece.FontFamily, (int)fontPiece.Style, fontPiece.Size, rec, sf);
                    }
                }
                if (FormChess.chess.WhiteTurn)
                {
                    g.DrawPath(penWhite, gpB);
                    g.FillPath(brushBlack, gpB);
                    g.DrawPath(penBlack, gpW);
                    g.FillPath(brushWhite, gpW);

                }
                else
                {
                    g.DrawPath(penBlack, gpW);
                    g.FillPath(brushWhite, gpW);
                    g.DrawPath(penWhite, gpB);
                    g.FillPath(brushBlack, gpB);

                }
            }
        }

        public void MakeMove(int sou, int des)
        {
            arrField[des].piece = arrField[sou].piece;
            arrField[sou].piece = null;
        }

        public void MakeMove(int emo)
        {
            int flags = emo & 0xFF0000;
            int sou = emo & 0xFF;
            int des = (emo >> 8) & 0xFF;
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
        }

        public void Animate()
        {
            animated = false;
            foreach (CField f in arrField)
            {
                CPiece p = f.piece;
                if (p != null)
                    if (p.Animate())
                        animated = true;
            }
        }

        public void SetPosition()
        {
            for (int y = 0; y < 8; y++)
            {
                int yr = rotate ? 7 - y : y;
                int y2 = background.frameSize + yr * background.fieldSize;
                for (int x = 0; x < 8; x++)
                {
                    int i = y * 8 + x;
                    int xr = rotate ? 7 - x : x;
                    int x2 = background.frameSize + xr * background.fieldSize;
                    arrField[i].x = x2;
                    arrField[i].y = y2;
                    CPiece piece = arrField[i].piece;
                    if (piece == null)
                        continue;
                    piece.SetPositionSta(x2, y2);
                }
            }
        }

        public void ShowAttack(bool show, bool white, bool mate)
        {
            List<int> ml = FormChess.chess.GenerateAllMoves(white, false);
            foreach (int m in ml)
            {
                int d = (m >> 8) & 0xff;
                int r = FormChess.chess.board[d] & 7;
                if (r == CChess.pieceKing)
                    arrField[d].color = mate ? Red : Orange;
                else if (r > 0)
                    arrField[d].color = show ? Orange : Color.Empty;
            }
        }

        public void ShowAttack()
        {
            ClearColors();
            if (CData.gameMode == CGameMode.edit)
                return;
            bool show = FormOptions.showAttack;
            bool mate = FormChess.chess.GetGameState() == CGameState.mate;
            ShowAttack(show, FormChess.chess.WhiteTurn, mate);
            ShowAttack(show, !FormChess.chess.WhiteTurn, mate);
        }

        public void StartAnimation()
        {
            animated = true;
            done = false;
            timer.Restart();
            Render();
        }

    }

}
