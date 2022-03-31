using Battleship.Domain.Implementations;
using Battleship.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Entity
{
    public class Game
    {
        public Player Player1 { get; init; }
        public Player Player2 { get; init; }
        private readonly IAttacker _attacker;
        private readonly IShipPlacer _shipPlacer;
        public Game(string player1Name, string player2Name)
        {
            _attacker = new Attacker();
            _shipPlacer = new ShipPlacer();
            Player1 = new Player(player1Name, _attacker, _shipPlacer);
            Player2 = new Player(player2Name, _attacker, _shipPlacer);
        }
    }
}
