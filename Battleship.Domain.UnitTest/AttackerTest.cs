using Battleship.Domain.Consts;
using Battleship.Domain.Entity;
using Battleship.Domain.Exceptions;
using Battleship.Domain.Implementations;
using Battleship.Domain.Interfaces;
using Xunit;

namespace Battleship.Domain.UnitTest
{
    public class AttackerTest
    {

        [Fact]
        public void Attack_Throws_AttackPositionOutOfRangeException_When_Postion_Out_Of_Range()
        {
            Board board = new Board(10, 10);
            IAttacker attacker = new Attacker();

            Assert.Throws<AttackPositionOutOfRangeException>(() => attacker.Attack(board, 10, 10));
            Assert.Throws<AttackPositionOutOfRangeException>(() => attacker.Attack(board, -1, 0));
        }

        [Fact]
        public void Attack_Return_Hit_When_Ship_Occupied()
        {
            Board board = new Board(10, 10);
            IAttacker attacker = new Attacker();
            board.SetCellStatus(0, 0, CellStatus.Occupied);
            board.SetCellStatus(1, 0, CellStatus.Hit);
            int shipSize = 2;
            Ship ship = new Ship(shipSize, ShipDirection.Horizontal);
            ship.Cells.Add(board._cells[0, 0]);
            ship.Cells.Add(board._cells[1, 0]);
            board._cells[0, 0].Ship = ship;
            board._cells[1, 0].Ship = ship;

            Assert.Equal<AttackStatus>(AttackStatus.Hit, attacker.Attack(board, 0, 0));
            Assert.Equal<AttackStatus>(AttackStatus.Hit, attacker.Attack(board, 1, 0));
        }

        [Fact]
        public void Attack_Return_Miss_When_Ship_NotOccupied()
        {
            Board board = new Board(10, 10);
            IAttacker attacker = new Attacker();
            board.SetCellStatus(0, 0, CellStatus.Occupied);
            board.SetCellStatus(1, 0, CellStatus.Hit);
            int shipSize = 2;
            Ship ship = new Ship(shipSize, ShipDirection.Horizontal);
            ship.Cells.Add(board._cells[0, 0]);
            ship.Cells.Add(board._cells[1, 0]);
            board._cells[0, 0].Ship = ship;
            board._cells[1, 0].Ship = ship;

            Assert.Equal<AttackStatus>(AttackStatus.Miss, attacker.Attack(board, 0, 1));
            Assert.Equal<AttackStatus>(AttackStatus.Miss, attacker.Attack(board, 2, 0));
        }
    }
}
