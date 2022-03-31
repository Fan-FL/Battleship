using Battleship.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Interfaces
{
    public interface IShipPlacer
    {
        public void PlaceShip(Board board, Ship ship, int row, int column);
    }
}
