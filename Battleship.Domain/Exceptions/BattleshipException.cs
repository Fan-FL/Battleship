using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Exceptions
{
    public abstract class BattleshipException : Exception
    {
        protected BattleshipException(string message) : base(message) { }
    }
}
