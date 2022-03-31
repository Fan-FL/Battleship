using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Exceptions
{
    public class PositionAlreadyAttackedException : BattleshipException
    {
        public int Row { get; init; }
        public int Column { get; init; }
        public PositionAlreadyAttackedException(int row, int column)
            : base($"Position ({row}, {column} has already attacekd. )")
        {
            Row = row;
            Column = column;
        }
    }
}
