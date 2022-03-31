using Battleship.Domain.Consts;
using Battleship.Domain.Exceptions;
using Battleship.Domain.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Entity
{
    public class Ship
    {
        private List<Cell> cells = new();
        public List<Cell> Cells { get { return cells; } }

        public int Size { get; }
        public ShipDirection Direction { get; }
        public ShipStatus Status { get; set; }

        public Ship(int size, ShipDirection direction, ShipStatus status=ShipStatus.Live)
        {
            int maxShipSize = Configurations.GetIConfigurationRoot().GetValue<int>("Ship:maxSize");
            if(size <= 0 || size > maxShipSize)
            {
                throw new ShipSizeOutOfRangeException(size);
            }

            Size = size;
            Direction = direction;
            Status = status;
        }

        public ShipStatus UpdateStatus()
        {
            if(cells.Count == 0)
            {
                throw new ShipNotPlacedBeforeUpdateStatusException();
            }

            if(this.Cells.All(c => c.Status == CellStatus.Hit))
            {
                Status = ShipStatus.Sunk;
            }

            return Status;
        }
    }
}
