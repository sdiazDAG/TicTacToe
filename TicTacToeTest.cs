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

            var actualValue = _game.SetPlayerMovement(new Position(1, 1), 'X');
            
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void PlayerTwoPlaysSecondMovement()
        {
            var _game = new Game(new char[3, 3] { { ' ', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } });
            var expectedValue = new char[3, 3] { { 'O', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } };

            var actualValue = _game.SetPlayerMovement(new Position(0, 0), 'O');
            
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void PlayerOnePlaysThirdMovement()
        {
            var _game = new Game(new char[3, 3] { { 'O', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } });
            var expectedValue = new char[3, 3] {{'O', ' ', 'X'}, {' ', 'X', ' '}, {' ', ' ', ' '}};

            var actualValue = _game.SetPlayerMovement(new Position(0, 2), 'X');
            
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void PlayerTwoPlaysFourthMovementInNotFreePosition()
        {
            var _game = new Game(new char[3, 3] { { 'O', ' ', 'X' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } });

            Action action = () => _game.SetPlayerMovement(new Position(0, 2), 'O');

            Assert.Throws<NotFreePositionException>(action);
        }

        [Fact]
        public void PlayerOneWinGame()
        {
            var _game = new Game(new char[3, 3] { { 'O', ' ', 'X' }, { 'O', 'X', ' ' }, { ' ', ' ', ' ' } });

            var actualValue = _game.SetPlayerMovement(new Position(2, 0), 'X');

            var isWinner = _game.IsThereWinner(actualValue);

            Assert.True(isWinner);
        }
    }
}
