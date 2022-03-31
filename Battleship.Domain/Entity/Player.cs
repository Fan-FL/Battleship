using Battleship.Domain.Consts;
using Battleship.Domain.Events;
using Battleship.Domain.Interfaces;
using Battleship.Domain.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain.Entity
{
    public class Player
    {
        private readonly IAttacker _attacker;
        private readonly IShipPlacer _shipPlacer;
        public List<IDomainEvent> Events { get; init; }

        public string Name { get; init; }
        private readonly Board _board;
        public Player(string name, IAttacker attacker, IShipPlacer shipPlacer)
        {
            Name = name;
            _attacker = attacker;
            _shipPlacer = shipPlacer;
            int width = Configurations.GetIConfigurationRoot().GetValue<int>("Board:width");
            int height = Configurations.GetIConfigurationRoot().GetValue<int>("Board:height");
            _board = new Board(width, height);
            Events = new List<IDomainEvent>();
        }

        public AttackStatus BeAttacked(int row, int column)
        {
            AttackStatus attackStatus = _attacker.Attack(_board, row, column);
            if (GameOver())
            {
                attackStatus = AttackStatus.AllSunk;
            }
            Events.Add(new Attacked(_board, row, column, attackStatus));
            return attackStatus;
        }

        public void PlaceShip(int row, int column, int shipSize, ShipDirection shipDirection)
        {
            Ship ship = new Ship(shipSize, shipDirection);
            _shipPlacer.PlaceShip(_board, ship, row, column);
            Events.Add(new ShipPlaced(_board, row, column, ship));
        }

        public bool GameOver()
        {
            return _board.Ships.All(s => s.Status == ShipStatus.Sunk);
        }
    }
}
