using NSChess;
using NSRapColor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RapChessGui
{

    static class Colors
    {
        public static Color last = Color.FromArgb(0x40, 0xff, 0xff, 0x00);
        public static Color Green = Color.FromArgb(0xa0, 0x00, 0xff, 0x00);
        public static Color Red = Color.FromArgb(0xa0, 0xff, 0x00, 0x00);
        public static Color Blue = Color.FromArgb(0xa0, 0x00, 0x00, 0xff);
        public static Color Yellow = Color.FromArgb(0xa0, 0xff, 0xff, 0x00);
        public static Color Orange = Color.FromArgb(0xa0, 0xff, 0x80, 0x00);
        public static Color Aqua = Color.FromArgb(0xa0, 0x00, 0xff, 0xff);
        public static Color chartM;
        public static Color chartD;
        public static Color chartL;
        public static Color message;
        public static Color listW;
        public static Color listB;
        public static Color labelL;
        public static Color labelD;
        public static Color labelM;
        public static Color board;

        public static void SetColor()
        {
            CRapColor.SetColor(FormOptions.color);
            labelD = CRapColor.GetColor(CRapColor.H, 0.4, 0.2);
            labelL = CRapColor.GetColor(CRapColor.H, 0.4, 0.8);
            labelM = CRapColor.GetColor(CRapColor.H, 0.3, 0.8);
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
        public int imageDes = -1;
        public int image = -1;
        public Point curXY = new Point();
        public Point souXY = new Point();
        public Point desXY = new Point();

        public bool Animate()
        {
            if ((curXY.X == desXY.X) && (curXY.Y == desXY.Y))
                return false;
            double speed = Convert.ToDouble(FormChess.formOptions.nudSpeed.Value);
            double dif = CBoard.timer.Elapsed.TotalMilliseconds / speed;
            if (dif >= 1)
            {
                curXY.X = desXY.X;
                curXY.Y = desXY.Y;
                imageDes = -1;
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
            imageDes = -1;
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
        public int x = 0;
        public int y = 0;
        public Color color = Color.Empty;
        public CPiece piece = null;

        public int GetIndex()
        {
            return y * 8 + x;
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
        public Bitmap bmpBackground = new Bitmap(10, 10);

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
                    for (int x = 0; x < 8; x++)
                    {
                        Rectangle rec = GetRect(x, y);
                        bool bgColor = ((y ^ x) & 1) == 1;
                        if (bgColor)
                            g.FillRectangle(brushB, rec);
                        else
                            g.FillRectangle(brushW, rec);
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
                    rec.X = bmpBackground.Width - frameSize;
                    gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
                    rec.X = x2;
                    rec.Y = 0;
                    rec.Width = fieldSize;
                    rec.Height = frameSize;
                    letter = abc[n].ToString();
                    gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
                    rec.Y = bmpBackground.Height - frameSize;
                    gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
                }
                g.DrawPath(outline, gp);
                g.FillPath(foreBrush, gp);
            }
        }

        public void Render()
        {
            bmpBackground = new Bitmap(size, size);
            using (Graphics graphics = Graphics.FromImage(bmpBackground))
            using (SolidBrush brush = new SolidBrush(Colors.board))
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.FillRectangle(brush, 0, 0, size, size);
                RenderFields(graphics);
                RenderGrid(graphics);
                RenderNotation(graphics);
            }
        }

        public void SetRotate(bool rotateBoard)
        {
            if (rotate != rotateBoard)
            {
                rotate = rotateBoard;
                Render();
            }
        }

        public Rectangle GetRect(int x, int y)
        {
            if (rotate)
            {
                x = 7 - x;
                y = 7 - y;
            }
            Rectangle rec = new Rectangle();
            rec.X = frameSize + x * fieldSize;
            rec.Y = frameSize + y * fieldSize;
            rec.Width = fieldSize;
            rec.Height = fieldSize;
            return rec;
        }

    }

    public class CBoard
    {
        public bool animated = false;
        public bool done = true;
        public bool rotated = false;
        public CField[] arrField = new CField[64];
        public Bitmap bmpBoard;
        public CArrowList arrows = new CArrowList();
        public CBackground background = new CBackground();
        public static readonly Stopwatch timer = new Stopwatch();

        public CBoard()
        {
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 8; x++)
                    arrField[y * 8 + x] = new CField() { x = x, y = y };
        }

        public void ClearArrows()
        {
            arrows.Clear();
        }

        public void ClearMarks()
        {
            ClearArrows();
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
            //using (Brush brush = new SolidBrush(Color.Green))
            using (Pen pen = new Pen(arrow.color, background.arrowSize))
            //using (Pen pen = new Pen(Color.Green, background.arrowSize))
            using (Pen penBlack = new Pen(Color.Black, 2))
            using (GraphicsPath path = new GraphicsPath())
            {
                pen.StartCap = LineCap.Round;
                //pen.EndCap = LineCap.DiamondAnchor;
                pen.CustomEndCap = new AdjustableArrowCap(3, 3, true);
                pen.DashCap = DashCap.Round;
                Point p1 = GetMiddle(arrow.a);
                Point p2 = GetMiddle(arrow.b);
                if (p1.X == p2.X)
                {
                    p1.X += shift;
                    p2.X += shift;
                }
                else
                {
                    p1.Y += shift;
                    p2.Y += shift;
                }
                path.AddLine(p1, p2);
                path.Widen(pen);
                g.DrawLine(pen, p1, p2);
            }
        }

        public void DrawArrows(Graphics g)
        {
            foreach (CArrow a in arrows)
                DrawArrow(g, a);
        }

        void DrawCircle(Graphics g, Rectangle rec)
        {
            int s = background.arrowSize >> 1;
            rec.Inflate(-s, -s);
            using (Brush brushBlue = new SolidBrush(Colors.Aqua))
            using (Pen pen = new Pen(brushBlue, background.arrowSize))
            {
                g.DrawEllipse(pen, rec);
            }
        }

        public void DrawCircles(Graphics g)
        {
            foreach (CField f in arrField)
                if (f.circle)
                    DrawCircle(g, background.GetRect(f.x, f.y));
        }

        public Point GetMiddle(int x, int y)
        {
            int xr = rotated ? 7 - x : x;
            int yr = rotated ? 7 - y : y;
            x = background.frameSize + xr * background.fieldSize + (background.fieldSize >> 1);
            y = background.frameSize + yr * background.fieldSize + (background.fieldSize >> 1);
            return new Point(x, y);
        }

        public CField GetFieldXY(int x, int y)
        {
            int ox = (x - background.frameSize - background.bmpX) / background.fieldSize;
            int oy = (y - background.frameSize - background.bmpY) / background.fieldSize;
            if (ox < 0)
                ox = 0;
            if (oy < 0)
                oy = 0;
            if (ox > 7)
                ox = 7;
            if (oy > 7)
                oy = 7;
            if (rotated)
            {
                ox = 7 - ox;
                oy = 7 - oy;
            }
            return arrField[oy * 8 + ox];
        }

        Point GetMiddle(Point p)
        {
            return GetMiddle(p.X, p.Y);
        }

        public void Render(Graphics g)
        {
            g.DrawImage(bmpBoard, background.bmpX, background.bmpY);
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

        public void SetFen(bool clearMarks = true)
        {
            background.SetRotate(rotated);
            for (int n = 0; n < 64; n++)
                UpdateField(n);
            if (clearMarks)
                ClearMarks();
            SetPositionSta();
            ShowAttack();
            Render();
        }

        public void Resize(int w, int h)
        {
            background.Resize(w, h);
            SetPositionSta();
            Render();
        }

        /// <summary>
        /// Render fields pieces and marks on boardBmp
        /// </summary>
        public void Render()
        {
            background.SetRotate(rotated);
            bmpBoard = new Bitmap(background.bmpBackground);
            using (Graphics g = Graphics.FromImage(bmpBoard))
            using (Brush brushRed = new SolidBrush(Colors.Red))
            using (Brush brushLast = new SolidBrush(Colors.last))
            using (Brush brushWhite = new SolidBrush(Color.White))
            using (Brush brushBlack = new SolidBrush(Color.Black))
            using (Font fontPiece = new Font(FormChess.pfc.Families[0], background.fieldSize))
            using (Pen penBlack = new Pen(Color.Black, 4))
            using (Pen penWhite = new Pen(Color.White, 4))
            using (GraphicsPath gpW = new GraphicsPath())
            using (GraphicsPath gpB = new GraphicsPath())
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                g.SmoothingMode = SmoothingMode.HighQuality;
                for (int y = 0; y < 8; y++)
                    for (int x = 0; x < 8; x++)
                    {
                        int i = y * 8 + x;
                        CField field = arrField[i];
                        Rectangle rec = background.GetRect(x, y);
                        Color c = arrField[i].color;
                        if ((i == CDrag.lastSou) || (i == CDrag.lastDes))
                            g.FillRectangle(brushLast, rec);
                        else if ((c != Color.Empty) && (FormChess.gameMode != CGameMode.edit))
                            using (Brush b = new SolidBrush(c))
                            {
                                g.FillRectangle(b, rec);
                            }
                        CPiece piece = field.piece;
                        if (piece == null)
                            continue;
                        if (piece.image < 0)
                            continue;
                        GraphicsPath gp;
                        int image;
                        if (piece.imageDes >= 0)
                        {
                            gp = piece.imageDes > 5 ? gpB : gpW;
                            image = piece.imageDes % 6;
                            gp.AddString("pnbrqk"[image].ToString(), fontPiece.FontFamily, (int)fontPiece.Style, fontPiece.Size, rec, sf);
                        }
                        if ((i == CDrag.lastDes) && CDrag.dragged)
                            piece.SetPositionSta(CDrag.mouseX - background.frameSize - background.bmpX, CDrag.mouseY - background.frameSize - background.bmpY);
                        else
                            piece.SetPositionAni(rec.X, rec.Y);
                        rec.X = piece.curXY.X;
                        rec.Y = piece.curXY.Y;
                        gp = piece.image > 5 ? gpB : gpW;
                        image = piece.image % 6;
                        gp.AddString("pnbrqk"[image].ToString(), fontPiece.FontFamily, (int)fontPiece.Style, fontPiece.Size, rec, sf);
                    }
                DrawCircles(g);
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
                DrawArrows(g);
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
                arrField[sou].piece.imageDes = pd.image;
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

        public void SetAnimated()
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

        public void SetPositionSta()
        {
            foreach (CField f in arrField)
            {
                Rectangle rec = background.GetRect(f.x, f.y);
                f.piece?.SetPositionSta(rec.X, rec.Y);
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
                    arrField[d].color = mate ? Colors.Red : Colors.Orange;
                else if (r > 0)
                    arrField[d].color = show ? Colors.Orange : Color.Empty;
            }
        }

        public void ShowAttack()
        {
            ClearColors();
            if (FormChess.gameMode == CGameMode.edit)
                return;
            bool show = FormChess.formOptions.cbAttack.Checked;
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
