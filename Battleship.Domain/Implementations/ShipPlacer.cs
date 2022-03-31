using Battleship.Domain.Consts;
using Battleship.Domain.Entity;
using Battleship.Domain.Exceptions;
using Battleship.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Implementations
{
    public class ShipPlacer : IShipPlacer
    {
        public void PlaceShip(Board board, Ship ship, int row, int column)
        {
            if (row >= board.Rows || column >= board.Columns || row < 0 || column < 0)
            {
                throw new ShipPositionOutOfRangeException(row, column);
            }
            if (ship.Direction == ShipDirection.Horizontal && column + ship.Size - 1 >= board.Columns)
            {
                throw new ShipPositionOutOfRangeException(row, column);
            }
            if(ship.Direction == ShipDirection.Vertical && row + ship.Size - 1 >= board.Rows)
            {
                throw new ShipPositionOutOfRangeException(row, column);
            }

            if (ship.Direction == ShipDirection.Horizontal)
            {
                for (int i = 0; i <= ship.Size - 1; i++)
                {
                    if (board.GetCellStatus(row, column + i) != CellStatus.Unoccupied)
                    {
                        throw new PositionAlreadyOccupiedException(row, column + i);
                    }
                }
            }
            else
            {
                for (int i = 0; i <= ship.Size - 1; i++)
                {
                    if (board.GetCellStatus(row + i, column) != CellStatus.Unoccupied)
                    {
                        throw new PositionAlreadyOccupiedException(row + i, column);
                    }
                }
            }

            board.Ships.Add(ship);

            if (ship.Direction == ShipDirection.Horizontal)
            {
                for(int i = 0; i <= ship.Size - 1; i++)
                {
                    board.SetCellStatus(row, column + i, CellStatus.Occupied);
                    Cell currentCell = board._cells[row, column + i];
                    currentCell.Status = CellStatus.Occupied;
                    currentCell.Ship = ship;
                    ship.Cells.Add(currentCell);
                }
            }
            else
            {
                for (int i = 0; i <= ship.Size - 1; i++)
                {
                    board.SetCellStatus(row + i, column, CellStatus.Occupied);
                    Cell currentCell = board._cells[row + i, column];
                    currentCell.Status = CellStatus.Occupied;
                    currentCell.Ship = ship;
                    ship.Cells.Add(currentCell);
                }
            }
        }
    }
}
