using NSChess;

namespace RapChessGui
{
    public class ChessExt:CChess
    {
        public void Rotate()
        {
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 4; y++)
                {
                    int i1 = y * 8 + x;
                    int i2 = (7 - y) * 8 + (7 - x);
                    (board[i1], board[i2]) = (board[i2], board[i1]);
                }
        }

    }
}
