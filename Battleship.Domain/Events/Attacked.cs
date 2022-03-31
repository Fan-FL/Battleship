using Battleship.Domain.Consts;
using Battleship.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Events
{
    public record Attacked(Board board, int x, int y, AttackStatus status) : IDomainEvent;
}
