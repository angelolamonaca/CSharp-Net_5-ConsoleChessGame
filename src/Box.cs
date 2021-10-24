namespace ConsoleChessGame
{
    public class Box
    {
        public int Id { get; set; }
        public Piece.Piece Piece { get; set; }
        public Box(int id, Piece.Piece piece = null)
        {
            Id = id;
            Piece = piece;
        }

        public override string ToString()
        {
            if (Piece != null) return Piece.ToString();
            else return ".";
        }
    }
}