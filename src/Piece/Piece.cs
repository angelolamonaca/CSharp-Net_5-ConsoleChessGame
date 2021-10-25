using System.Collections.Generic;
using ConsoleChessGame.Enums;

namespace ConsoleChessGame.Piece
{
    public abstract class Piece
    {
        protected Color Color { get; set; }

        protected Piece(Color color)
        {
            Color = color;
        }

        public abstract bool PotentialMove(Status status, int target);
        public abstract List<int> PotentialMoveList(Status status, int target);
        public abstract bool PotentialAttack(Status status, int target);
        public abstract List<int> PotentialAttackList(Status status, int target);
        
    }
}