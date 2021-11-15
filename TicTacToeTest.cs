using System;
using Xunit;

namespace TicTacToe
{
    public class TicTacToeTest
    {
        private readonly Game _game = new Game();

        [Fact]
        public void PlayerOnePlaysFirst()
        {
            char expectedValue = _game.GetPlayerMovement();
            Assert.Equal(expectedValue, 'X');
        }
    }
}
