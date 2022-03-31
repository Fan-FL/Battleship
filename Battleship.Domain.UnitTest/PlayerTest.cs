using Battleship.Domain.Consts;
using Battleship.Domain.Entity;
using Battleship.Domain.Exceptions;
using Battleship.Domain.Implementations;
using Battleship.Domain.Interfaces;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Battleship.Domain.UnitTest
{
    public class PlayerTest
    {
        private readonly ITestOutputHelper output;

        public PlayerTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GameOver_Return_True_When_All_Ships_Sunk()
        {
            Player player1 = new Player("player1", new Attacker(), new ShipPlacer());
            player1.PlaceShip(0, 1, 2, ShipDirection.Vertical);
            player1.BeAttacked(0, 1);
            player1.BeAttacked(2, 1);

            Assert.False(player1.GameOver());
            player1.BeAttacked(1, 1);
            Assert.True(player1.GameOver());
            player1.Events.ForEach(e => output.WriteLine(e.ToString()));
        }

    }
}
