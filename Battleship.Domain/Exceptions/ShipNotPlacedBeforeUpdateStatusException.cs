using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Exceptions
{
    public class ShipNotPlacedBeforeUpdateStatusException : BattleshipException
    {
        public ShipNotPlacedBeforeUpdateStatusException()
            : base($"Cannot update ship status before placing on cells")
        {
        }
    }
}
