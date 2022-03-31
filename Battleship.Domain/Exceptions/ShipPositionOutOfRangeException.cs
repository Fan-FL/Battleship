using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Exceptions
{
    public class ShipPositionOutOfRangeException : BattleshipException
    {
        public int Row { get; init; }
        public int Column { get; init; }
        public ShipPositionOutOfRangeException(int row, int column)
            : base($"Ship position ({row}, {column}) is out of range.")
        {
            Row = row;
            Column = column;
        }
    }
}
