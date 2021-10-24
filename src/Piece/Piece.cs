using System.Collections.Generic;
using System.Drawing;

namespace ConsoleChessGame.Piece
{
    public abstract class Piece
    {
        private Color _color;

        public abstract bool PotentialMove(Status status, int target);
        public abstract List<int> PotentialMoveList(Status status, int target);
        public abstract bool PotentialAttack(Status status, int target);
        public abstract List<int> PotentialAttackList(Status status, int target);
    }
}