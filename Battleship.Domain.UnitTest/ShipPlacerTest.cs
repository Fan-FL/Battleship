using Battleship.Domain.Consts;
using Battleship.Domain.Entity;
using Battleship.Domain.Exceptions;
using Battleship.Domain.Implementations;
using Battleship.Domain.Interfaces;
using Xunit;

namespace Battleship.Domain.UnitTest
{
    public class ShipPlacerTest
    {

        [Fact]
        public void ShipPlacer_Throws_ShipPositionOutOfRangeException_When_Ship_Postion_Out_Of_Range()
        {
            Board board = new Board(10, 10);
            IShipPlacer shipPlacer = new ShipPlacer();
            int shipSize = 5;
            Ship ship1 = new Ship(shipSize, ShipDirection.Horizontal);
            Ship ship2 = new Ship(shipSize, ShipDirection.Vertical);

            Assert.Throws<ShipPositionOutOfRangeException>(() => shipPlacer.PlaceShip(board, ship1, 10, 9));
            Assert.Throws<ShipPositionOutOfRangeException>(() => shipPlacer.PlaceShip(board, ship1, -1, 0));
            Assert.Throws<ShipPositionOutOfRangeException>(() => shipPlacer.PlaceShip(board, ship1, 0, 6));
            Assert.Throws<ShipPositionOutOfRangeException>(() => shipPlacer.PlaceShip(board, ship2, 6, 0));
        }

        [Fact]
        public void ShipPlacer_Throws_PositionAlreadyOccupiedException_When_Ship_Overlap()
        {
            Board board = new Board(10, 10);
            IShipPlacer shipPlacer = new ShipPlacer();
            int shipSize = 2;
            board.SetCellStatus(5, 5, CellStatus.Occupied);
            board.SetCellStatus(5, 6, CellStatus.Hit);
            //overlap with ship3
            Ship ship1 = new Ship(shipSize, ShipDirection.Horizontal);
            ship1.Cells.Add(board._cells[5, 5]);
            ship1.Cells.Add(board._cells[5, 6]);
            board._cells[5, 5].Ship = ship1;
            board._cells[5, 6].Ship = ship1;

            //overlap with ship4
            board.SetCellStatus(8, 8, CellStatus.Occupied);
            board.SetCellStatus(9, 8, CellStatus.Hit);
            Ship ship2 = new Ship(shipSize, ShipDirection.Vertical);
            ship1.Cells.Add(board._cells[8, 8]);
            ship1.Cells.Add(board._cells[9, 8]);
            board._cells[8, 8].Ship = ship1;
            board._cells[9, 8].Ship = ship1;

            Ship ship3 = new Ship(3, ShipDirection.Vertical);
            Ship ship4 = new Ship(3, ShipDirection.Horizontal);

            Assert.Throws<PositionAlreadyOccupiedException>(() => shipPlacer.PlaceShip(board, ship3, 3, 5));
            Assert.Throws<PositionAlreadyOccupiedException>(() => shipPlacer.PlaceShip(board, ship3, 3, 6));

            Assert.Throws<PositionAlreadyOccupiedException>(() => shipPlacer.PlaceShip(board, ship4, 8, 6));
            Assert.Throws<PositionAlreadyOccupiedException>(() => shipPlacer.PlaceShip(board, ship4, 9, 6));
        }

        [Fact]
        public void ShipPlace_Then_CellStuts_Occupied_And_Board_Ship_added_And_Ship_Cell_Added()
        {
            Board board = new Board(10, 10);
            IShipPlacer shipPlacer = new ShipPlacer();
            int shipSize = 2;
            Ship ship1 = new Ship(shipSize, ShipDirection.Vertical);
            shipPlacer.PlaceShip(board, ship1, 1, 1);

            Assert.Equal<CellStatus>(CellStatus.Occupied, board._cells[1,1].Status);
            Assert.Equal<CellStatus>(CellStatus.Occupied, board._cells[2,1].Status);
            Assert.Single(board.Ships);
            Assert.All<Cell>(ship1.Cells, c=>Assert.Equal<CellStatus>(CellStatus.Occupied, c.Status));
            Assert.Equal(ShipStatus.Live, ship1.Status);

            Ship ship2 = new Ship(shipSize, ShipDirection.Horizontal);
            shipPlacer.PlaceShip(board, ship2, 5, 5);
            Assert.Equal<CellStatus>(CellStatus.Occupied, board._cells[5, 5].Status);
            Assert.Equal<CellStatus>(CellStatus.Occupied, board._cells[5, 6].Status);
            Assert.Equal(2, board.Ships.Count);
            Assert.All<Cell>(ship2.Cells, c => Assert.Equal<CellStatus>(CellStatus.Occupied, c.Status));
            Assert.Equal(ShipStatus.Live, ship2.Status);
        }
    }
}
