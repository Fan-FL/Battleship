using Battleship.Domain.Consts;
using Battleship.Domain.Entity;
using Battleship.Domain.Exceptions;
using Battleship.Domain.Shared;
using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace Battleship.Domain.UnitTest
{
    public class ShipTest
    {
        [Fact]
        public void Construct_Throws_ShipSizeOutOfRangeException_When_Size_Less_Than_0_Or_Greater_THAN_MAX_SIZE()
        {
            int maxShipSize = Configurations.GetIConfigurationRoot().GetValue<int>("Ship:maxSize");

            Assert.Throws<ShipSizeOutOfRangeException>(() => new Ship(0, ShipDirection.Horizontal));
            Assert.Throws<ShipSizeOutOfRangeException>(() => new Ship(maxShipSize+1, ShipDirection.Horizontal));
        }

        [Fact]
        public void UpdateStatus_to_Sunk_When_All_Cells_Hit()
        {
            int shipSize = 2;
            Ship ship = new Ship(shipSize, ShipDirection.Horizontal);
            for(int i = 0; i < shipSize; i++)
            {
                ship.Cells.Add(new Cell(i, 0, CellStatus.Hit));
            }

            ShipStatus status = ship.UpdateStatus();

            Assert.Equal<ShipStatus>(ShipStatus.Sunk, status);
        }

        [Fact]
        public void UpdateStatus_Remain_Live_When_NOT_All_Cells_Hit()
        {
            int shipSize = 2;
            Ship ship = new Ship(shipSize, ShipDirection.Horizontal);
            ship.Cells.Add(new Cell(0, 0, CellStatus.Hit));
            ship.Cells.Add(new Cell(1, 0, CellStatus.Occupied));

            ShipStatus status = ship.UpdateStatus();

            Assert.Equal<ShipStatus>(ShipStatus.Live, status);
        }
        
        [Fact]
        public void UpdateStatus_Throws_ShipNotPlacedBeforeUpdateStatusException_When_No_Cells_Added()
        {
            int shipSize = 2;
            Ship ship = new Ship(shipSize, ShipDirection.Horizontal);

            Assert.Throws<ShipNotPlacedBeforeUpdateStatusException>(() => ship.UpdateStatus());
        }
    }
}