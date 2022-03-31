using Battleship.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Entity
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public CellStatus Status { get; set; }
        public Ship? Ship { get; set; }
        public Cell(int row, int column, CellStatus status = CellStatus.Unoccupied)
        {
            Row = row;
            Column = column;
            Status = status;
        }
    }
}
