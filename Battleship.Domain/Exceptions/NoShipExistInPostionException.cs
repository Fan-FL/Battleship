using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Exceptions
{
    public class NoShipExistInPostionException : BattleshipException
    {
        public int Row { get; init; }
        public int Column { get; init; }
        public NoShipExistInPostionException(int row, int column)
            : base($"No ship in Position ({row}, {column}) .")
        {
            Row = row;
            Column = column;
        }
    }
}
