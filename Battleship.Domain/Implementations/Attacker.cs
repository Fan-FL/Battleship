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
    public class Attacker : IAttacker
    {
        public AttackStatus Attack(Board board, int x, int y)
        {
            if (x >= board.Rows || y >= board.Columns || x < 0 || y < 0)
            {
                throw new AttackPositionOutOfRangeException(x, y);
            }

            if(board.GetCellStatus(x, y) == CellStatus.Occupied || board.GetCellStatus(x, y) == CellStatus.Hit)
            {
                board.SetCellStatus(x, y, CellStatus.Hit);
                board.updateShipStatus(x, y);
                return AttackStatus.Hit;
            }
            else
            {
                board.SetCellStatus(x, y, CellStatus.Miss);
                return AttackStatus.Miss;
            }
        }
    }
}
