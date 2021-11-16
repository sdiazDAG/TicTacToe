using System;
using Xunit;

namespace TicTacToe
{
    public class TicTacToeTest
    {
        [Fact]
        public void PlayerOnePlaysFirstMovement()
        {
            var _board = new Board();
            var _game = new Game(_board);
            var expectedValue = new Board(new GameSymbol[,] { { GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell }, { GameSymbol.FreeCell, GameSymbol.PlayerOneSymbol, GameSymbol.FreeCell }, { GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell } });

            var actualValue = _game.SetPlayerMovement(new Position(1, 1), GameSymbol.PlayerOneSymbol);
            
            Assert.Equal(expectedValue.Cells, actualValue.Cells);
        }

        [Fact]
        public void PlayerTwoPlaysSecondMovement()
        {
            var _board = new Board(new GameSymbol[,] { { GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell }, { GameSymbol.FreeCell, GameSymbol.PlayerOneSymbol, GameSymbol.FreeCell }, { GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell } });
            var _game = new Game(_board);
            var expectedValue = new Board(new GameSymbol[,] {{GameSymbol.PlayerTwoSymbol, GameSymbol.FreeCell, GameSymbol.FreeCell}, {GameSymbol.FreeCell, GameSymbol.PlayerOneSymbol, GameSymbol.FreeCell}, {GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell}});

            var actualValue = _game.SetPlayerMovement(new Position(0, 0), GameSymbol.PlayerTwoSymbol);

            Assert.Equal(expectedValue.Cells, actualValue.Cells);
        }

        [Fact]
        public void PlayerOnePlaysThirdMovement()
        {
            var _board = new Board(new GameSymbol[,] { { GameSymbol.PlayerTwoSymbol, GameSymbol.FreeCell, GameSymbol.FreeCell }, { GameSymbol.FreeCell, GameSymbol.PlayerOneSymbol, GameSymbol.FreeCell }, { GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell } });
            var _game = new Game(_board);
            var expectedValue = new Board(new GameSymbol[,] {{GameSymbol.PlayerTwoSymbol, GameSymbol.FreeCell, GameSymbol.PlayerOneSymbol}, {GameSymbol.FreeCell, GameSymbol.PlayerOneSymbol, GameSymbol.FreeCell}, {GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell}});

            var actualValue = _game.SetPlayerMovement(new Position(0, 2), GameSymbol.PlayerOneSymbol);

            Assert.Equal(expectedValue.Cells, actualValue.Cells);
        }

        [Fact]
        public void PlayerTwoPlaysFourthMovementInNotFreePosition()
        {
            var _board = new Board(new GameSymbol[,] { { GameSymbol.PlayerTwoSymbol, GameSymbol.FreeCell, GameSymbol.PlayerOneSymbol }, { GameSymbol.FreeCell, GameSymbol.PlayerOneSymbol, GameSymbol.FreeCell }, { GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell } });
            var _game = new Game(_board);

            Action action = () => _game.SetPlayerMovement(new Position(0, 2), GameSymbol.PlayerTwoSymbol);

            Assert.Throws<NotFreePositionException>(action);
        }

        [Fact]
        public void PlayerOneWinGame()
        {
            var _board = new Board(new GameSymbol[,] { { GameSymbol.PlayerTwoSymbol, GameSymbol.FreeCell, GameSymbol.PlayerOneSymbol }, { GameSymbol.PlayerTwoSymbol, GameSymbol.PlayerOneSymbol, GameSymbol.FreeCell }, { GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell } });
            var _game = new Game(_board);

            var actualValue = _game.SetPlayerMovement(new Position(2, 0), GameSymbol.PlayerOneSymbol);

            var isWinner = _game.IsThereWinner();

            Assert.True(isWinner);
        }

        [Fact]
        public void PlayerTwoWinGame()
        {
            var _board = new Board(new GameSymbol[,] { { GameSymbol.PlayerTwoSymbol, GameSymbol.FreeCell, GameSymbol.PlayerOneSymbol }, { GameSymbol.PlayerTwoSymbol, GameSymbol.PlayerOneSymbol, GameSymbol.FreeCell }, { GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.PlayerOneSymbol } });
            var _game = new Game(_board);

            var actualValue = _game.SetPlayerMovement(new Position(2, 0), GameSymbol.PlayerTwoSymbol);

            var isWinner = _game.IsThereWinner();

            Assert.True(isWinner);
        }

        [Fact]
        public void GameHaveNotWinner()
        {
            var _board = new Board(new GameSymbol[,] { { GameSymbol.PlayerTwoSymbol, GameSymbol.FreeCell, GameSymbol.PlayerOneSymbol }, { GameSymbol.PlayerTwoSymbol, GameSymbol.PlayerOneSymbol, GameSymbol.FreeCell }, { GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.PlayerOneSymbol } });
            var _game = new Game(_board);

            var isWinner = _game.IsThereWinner();

            Assert.False(isWinner);
        }

        [Fact]
        public void GameFinishedAndHaveNotNotWinner()
        {
            var _board = new Board(new GameSymbol[,] { { GameSymbol.PlayerOneSymbol, GameSymbol.PlayerTwoSymbol, GameSymbol.PlayerOneSymbol }, { GameSymbol.PlayerTwoSymbol, GameSymbol.PlayerTwoSymbol, GameSymbol.PlayerOneSymbol }, { GameSymbol.PlayerTwoSymbol, GameSymbol.PlayerOneSymbol, GameSymbol.PlayerTwoSymbol } });
            var _game = new Game(_board);

            var isWinner = _game.IsThereWinner();

            Assert.False(isWinner);

            var isFinished = _game.IsFinished();

            Assert.True(isFinished);
        }
    }
}
