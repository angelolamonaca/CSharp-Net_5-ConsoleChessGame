using System;

namespace ConsoleChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard board = new ChessBoard();
            Console.WriteLine(board);
            Console.WriteLine(board.Get(12).GetType());
        }
    }
}