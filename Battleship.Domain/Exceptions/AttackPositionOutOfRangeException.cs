using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Exceptions
{
    public class AttackPositionOutOfRangeException : BattleshipException
    {
        public int Row { get; init; }
        public int Column { get; init; }
        public AttackPositionOutOfRangeException(int row, int column)
            : base($"Position ({row}, {column}) is out of range.")
        {
            Row = row;
            Column = column;
        }
    }
}
