using System;
using ConsoleChessGame.Enums;
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
                    _chessBoard[i, j] = i switch
                    {
                        0 => j switch
                        {
                            0 or 7 => new Box(id, new Rook(Color.Black)),
                            1 or 6 => new Box(id, new Knight(Color.Black)),
                            2 or 5 => new Box(id, new Bishop(Color.Black)),
                            3 => new Box(id, new Queen(Color.Black)),
                            4 => new Box(id, new King(Color.Black)),
                            _ => throw new ArgumentOutOfRangeException()
                        },
                        1 => new Box(id, new Pawn(Color.Black)),
                        6 => new Box(id, new Pawn(Color.White)),
                        7 => j switch
                        {
                            0 or 7 => new Box(id, new Rook(Color.White)),
                            1 or 6 => new Box(id, new Knight(Color.White)),
                            2 or 5 => new Box(id, new Bishop(Color.White)),
                            3 => new Box(id, new Queen(Color.White)),
                            4 => new Box(id, new King(Color.White)),
                            _ => throw new ArgumentOutOfRangeException()
                        },
                        _ => new Box(id)
                    };
                }
            }
        }

        public Piece.Piece Get(int pos)
        {
            Piece.Piece piece = null;
            try
            {
                if (pos is < 11 or > 88) 
                    throw new ArgumentException("Position value is out of range, it should be an integer between 11 and 88", 
                        nameof(pos));
                var row = Math.Abs(
                    Convert.ToInt32(
                        char.GetNumericValue(
                            pos.ToString()[1]))-8);
                var column = Convert.ToInt32(
                    char.GetNumericValue(
                        pos.ToString()[0]))-1;
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
            try
            {
                if (piece == null) 
                    throw new ArgumentException("The piece cannot be null, it must be a valid piece.",
                        nameof(piece));
                for (var i = 0; i < 8; i++)
                {
                    for (var j = 0; j < 8; j++)
                    {
                        if (_chessBoard[i, j].Piece == piece) return _chessBoard[i, j].Id;
                    }
                }
                throw new ArgumentException("Piece is not present on the board, it is not possible to determine the position",
                    nameof(piece));
            }
            catch (ArgumentException e)
            {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.StackTrace);
            }
            return -1;
        }

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < 8; i++, result += "\n")
            {
                for (var j = 0; j < 8; j++)
                {
                    result += _chessBoard[i,j] + " ";
                }
            }
            return result;
        }
    }
}