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
            var expectedValue = _game.GetPlayerMovement(1, 1);
            Assert.Equal(expectedValue, new char[3,3] {{' ', ' ', ' '} , {' ', 'X', ' '} , {' ', ' ', ' '}});
        }

        [Fact]
        public void PlayerTwoPlaysSecond()
        {
            var expectedValue = _game.GetPlayerMovement(0, 0);
            Assert.Equal(expectedValue, new char[3, 3] { { 'O', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } });
        }
    }
}
