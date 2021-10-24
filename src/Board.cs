using System;
using ConsoleChessGame.Piece;

namespace ConsoleChessGame
{
    public class ChessBoard
    {
        private readonly Box[,] _chessBoard = new Box[8, 8];
        public ChessBoard()
        {
            for (int i = 0, id = 18; i < 8; i++, id -= 81)
            {
                for (int j = 0; j < 8; j++, id+=10)
                {
                    _chessBoard[i, j] = i is 1 or 6? new Box(id, new Pawn()) : new Box(id);
                }
            }
        }

        public Piece.Piece Get(int pos)
        {
            Piece.Piece piece = null;
            try
            {
                if (pos < 11 || pos > 88) throw new ArgumentException("Position value is out of range, it should be an integer between 11 and 88", nameof(pos));
                int row = Math.Abs(Convert.ToInt32(Char.GetNumericValue(pos.ToString()[1]))-8);
                int column = Convert.ToInt32(Char.GetNumericValue(pos.ToString()[0]))-1;
                piece = _chessBoard[row, column].Piece;

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.StackTrace);
            }
            return piece;
        }

        public int GetPos(Piece.Piece piece)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (_chessBoard[i, j].Piece == piece) return _chessBoard[i, j].Id;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < 8; i++, result += "\n")
            {
                for (int j = 0; j < 8; j++)
                {
                    result += _chessBoard[i,j] + " ";
                }
            }
            return result;
        }
    }
}