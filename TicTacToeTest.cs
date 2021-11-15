using System;
using Xunit;

namespace TicTacToe
{
    public class TicTacToeTest
    {
        

        [Fact]
        public void PlayerOnePlaysFirstMovement()
        {
            var _game = new Game(new char[3, 3] {{' ', ' ', ' '}, {' ', ' ', ' '}, {' ', ' ', ' '}});
            var expectedValue = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } };

            var actualValue = _game.GetPlayerMovement(1, 1, 'X');
            
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void PlayerTwoPlaysSecondMovement()
        {
            var _game = new Game(new char[3, 3] { { ' ', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } });
            var expectedValue = new char[3, 3] { { 'O', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } };

            var actualValue = _game.GetPlayerMovement(0, 0, 'O');
            
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void PlayerOnePlaysThirdMovement()
        {
            var _game = new Game(new char[3, 3] { { 'O', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } });
            var expectedValue = new char[3, 3] {{'O', ' ', 'X'}, {' ', 'X', ' '}, {' ', ' ', ' '}};

            var actualValue = _game.GetPlayerMovement(0, 2, 'X');
            
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void PlayerTwoPlaysFourthMovementInNotFreePosition()
        {
            var _game = new Game(new char[3, 3] { { 'O', ' ', 'X' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } });

            Action action = () => _game.GetPlayerMovement(0, 2, 'O');

            Assert.Throws<NotFreePositionException>(action);
        }
    }
}
