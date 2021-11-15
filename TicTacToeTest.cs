using System;
using Xunit;

namespace TicTacToe
{
    public class TicTacToeTest
    {
        [Fact]
        public void PlayerOnePlaysFirstMovement()
        {
            var _board = new Board(new[,] {{' ', ' ', ' '}, {' ', ' ', ' '}, {' ', ' ', ' '}});
            var _game = new Game(_board);
            var expectedValue = new Board(new[,] { { ' ', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } });

            var actualValue = _game.SetPlayerMovement(new Position(1, 1), 'X');
            
            Assert.Equal(expectedValue.Cells, actualValue.Cells);
        }

        [Fact]
        public void PlayerTwoPlaysSecondMovement()
        {
            var _board = new Board(new[,] { { ' ', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } });
            var _game = new Game(_board);
            var expectedValue = new Board(new[,] {{'O', ' ', ' '}, {' ', 'X', ' '}, {' ', ' ', ' '}});

            var actualValue = _game.SetPlayerMovement(new Position(0, 0), 'O');

            Assert.Equal(expectedValue.Cells, actualValue.Cells);
        }

        [Fact]
        public void PlayerOnePlaysThirdMovement()
        {
            var _board = new Board(new[,] { { 'O', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } });
            var _game = new Game(_board);
            var expectedValue = new Board(new char[3, 3] {{'O', ' ', 'X'}, {' ', 'X', ' '}, {' ', ' ', ' '}});

            var actualValue = _game.SetPlayerMovement(new Position(0, 2), 'X');

            Assert.Equal(expectedValue.Cells, actualValue.Cells);
        }

        [Fact]
        public void PlayerTwoPlaysFourthMovementInNotFreePosition()
        {
            var _board = new Board(new[,] { { 'O', ' ', 'X' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } });
            var _game = new Game(_board);

            Action action = () => _game.SetPlayerMovement(new Position(0, 2), 'O');

            Assert.Throws<NotFreePositionException>(action);
        }

        [Fact]
        public void PlayerOneWinGame()
        {
            var _board = new Board(new[,] { { 'O', ' ', 'X' }, { 'O', 'X', ' ' }, { ' ', ' ', ' ' } });
            var _game = new Game(_board);

            var actualValue = _game.SetPlayerMovement(new Position(2, 0), 'X');

            var isWinner = _game.IsThereWinner();

            Assert.True(isWinner);
        }

        [Fact]
        public void PlayerTwoWinGame()
        {
            var _board = new Board(new[,] { { 'O', ' ', 'X' }, { 'O', 'X', ' ' }, { ' ', ' ', 'X' } });
            var _game = new Game(_board);

            var actualValue = _game.SetPlayerMovement(new Position(2, 0), 'O');

            var isWinner = _game.IsThereWinner();

            Assert.True(isWinner);
        }
    }
}
