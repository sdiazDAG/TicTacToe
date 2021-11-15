using System;
using Xunit;

namespace TicTacToe
{
    public class TicTacToeTest
    {
        [Fact]
        public void PlayerOnePlaysFirst()
        {
            char expectedValue = GetPlayerMovement();
            Assert.Equal(expectedValue, 'X');
        }

        private char GetPlayerMovement()
        {
            return 'X';
        }
    }
}
