using Battleship.Domain.Consts;
using Battleship.Domain.Events;
using Battleship.Domain.Exceptions;
using Battleship.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Entity
{
    public class Board
    {
        public int Rows { get; init; }
        public int Columns { get; init; }
        public Cell[,] _cells { get; set; }
        public List<Ship> Ships { get; init; }
        public Board(int width, int height)
        {
            Rows = height;
            Columns = width;
            _cells = new Cell[width, height];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _cells[i, j] = new Cell(i, j);
                }
            }
            Ships = new List<Ship>();
        }

        public CellStatus GetCellStatus(int row, int column)
        {
            return _cells[row, column].Status;
        }

        public void SetCellStatus(int row, int column, CellStatus status)
        {
            _cells[row, column].Status = status;
        }

        public ShipStatus updateShipStatus(int row, int column)
        {
            Ship? ship = _cells[row, column].Ship;
            if (ship != null)
            {
                return ship.UpdateStatus();
            }
            else
            {
                throw new NoShipExistInPostionException(row, column);
            }
            
        }
    }
}
