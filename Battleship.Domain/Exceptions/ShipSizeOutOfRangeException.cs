using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Exceptions
{
    public class ShipSizeOutOfRangeException : BattleshipException
    {
        public int Size { get; init; }
        public ShipSizeOutOfRangeException(int size)
            : base($"Ship size {size} is out of range.")
        {
            Size = size;
        }
    }
}
