using System;
using System.Collections.Generic;
using Xunit;

namespace TicTacToe
{
    public class TicTacToeTest
    {
        [Fact]
        public void PlayerOnePlaysFirstMovement()
        {
            var board = new Board();
            var game = new Game(board);
            var expectedBoard = new Board(new Dictionary<string, GameSymbol>
            {
                {new Position(0, 0).ToString(), GameSymbol.FreeCell},
                {new Position(0, 1).ToString(), GameSymbol.FreeCell},
                {new Position(0, 2).ToString(), GameSymbol.FreeCell},
                {new Position(1, 0).ToString(), GameSymbol.FreeCell},
                {new Position(1, 1).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), GameSymbol.FreeCell},
                {new Position(2, 0).ToString(), GameSymbol.FreeCell},
                {new Position(2, 1).ToString(), GameSymbol.FreeCell},
                {new Position(2, 2).ToString(), GameSymbol.FreeCell}
            });

            var currentBoard = game.SetPlayerMovement(new Position(1, 1).ToString(), GameSymbol.PlayerOneSymbol);
            
            Assert.Equal(expectedBoard, currentBoard);
        }

        [Fact]
        public void PlayerTwoPlaysSecondMovement()
        {
            var board = new Board(new Dictionary<string, GameSymbol>
            {
                {new Position(0, 0).ToString(), GameSymbol.FreeCell},
                {new Position(0, 1).ToString(), GameSymbol.FreeCell},
                {new Position(0, 2).ToString(), GameSymbol.FreeCell},
                {new Position(1, 0).ToString(), GameSymbol.FreeCell},
                {new Position(1, 1).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), GameSymbol.FreeCell},
                {new Position(2, 0).ToString(), GameSymbol.FreeCell},
                {new Position(2, 1).ToString(), GameSymbol.FreeCell},
                {new Position(2, 2).ToString(), GameSymbol.FreeCell}
            });
            var game = new Game(board);
            var expectedBoard = new Board(new Dictionary<string, GameSymbol>
            {
                {new Position(0, 0).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), GameSymbol.FreeCell},
                {new Position(0, 2).ToString(), GameSymbol.FreeCell},
                {new Position(1, 0).ToString(), GameSymbol.FreeCell},
                {new Position(1, 1).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), GameSymbol.FreeCell},
                {new Position(2, 0).ToString(), GameSymbol.FreeCell},
                {new Position(2, 1).ToString(), GameSymbol.FreeCell},
                {new Position(2, 2).ToString(), GameSymbol.FreeCell}
            });

            var currentBoard = game.SetPlayerMovement(new Position(0, 0).ToString(), GameSymbol.PlayerTwoSymbol);

            Assert.Equal(expectedBoard, currentBoard);
        }

        [Fact]
        public void PlayerOnePlaysThirdMovement()
        {
            var board = new Board(new Dictionary<string, GameSymbol>
            {
                {new Position(0, 0).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), GameSymbol.FreeCell},
                {new Position(0, 2).ToString(), GameSymbol.FreeCell},
                {new Position(1, 0).ToString(), GameSymbol.FreeCell},
                {new Position(1, 1).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), GameSymbol.FreeCell},
                {new Position(2, 0).ToString(), GameSymbol.FreeCell},
                {new Position(2, 1).ToString(), GameSymbol.FreeCell},
                {new Position(2, 2).ToString(), GameSymbol.FreeCell}
            });
            var game = new Game(board);
            var expectedBoard = new Board(new Dictionary<string, GameSymbol>
            {
                {new Position(0, 0).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), GameSymbol.FreeCell},
                {new Position(0, 2).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 0).ToString(), GameSymbol.FreeCell},
                {new Position(1, 1).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), GameSymbol.FreeCell},
                {new Position(2, 0).ToString(), GameSymbol.FreeCell},
                {new Position(2, 1).ToString(), GameSymbol.FreeCell},
                {new Position(2, 2).ToString(), GameSymbol.FreeCell}
            });

            var currentBoard = game.SetPlayerMovement(new Position(0, 2).ToString(), GameSymbol.PlayerOneSymbol);

            Assert.Equal(expectedBoard, currentBoard);
        }

        [Fact]
        public void PlayerTwoPlaysFourthMovementInNotFreePosition()
        {
            var board = new Board(new Dictionary<string, GameSymbol>
            {
                {new Position(0, 0).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), GameSymbol.FreeCell},
                {new Position(0, 2).ToString(), GameSymbol.FreeCell},
                {new Position(1, 0).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 1).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), GameSymbol.FreeCell},
                {new Position(2, 0).ToString(), GameSymbol.FreeCell},
                {new Position(2, 1).ToString(), GameSymbol.FreeCell},
                {new Position(2, 2).ToString(), GameSymbol.FreeCell}
            });
            var game = new Game(board);

            Action action = () => game.SetPlayerMovement(new Position(1, 0).ToString(), GameSymbol.PlayerTwoSymbol);

            Assert.Throws<NotFreePositionException>(action);
        }

        [Fact]
        public void PlayerOneWinGame()
        {
            var board = new Board(new Dictionary<string, GameSymbol>
            {
                {new Position(0, 0).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), GameSymbol.FreeCell},
                {new Position(0, 2).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 0).ToString(), GameSymbol.FreeCell},
                {new Position(1, 1).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(2, 0).ToString(), GameSymbol.FreeCell},
                {new Position(2, 1).ToString(), GameSymbol.FreeCell},
                {new Position(2, 2).ToString(), GameSymbol.FreeCell}
            });
            var game = new Game(board);

            game.SetPlayerMovement(new Position(2, 0).ToString(), GameSymbol.PlayerOneSymbol);

            var isWinner = game.IsThereWinner();

            Assert.True(isWinner);
        }

        [Fact]
        public void PlayerTwoWinGame()
        {
            var board = new Board(new Dictionary<string, GameSymbol>
            {
                {new Position(0, 0).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), GameSymbol.FreeCell},
                {new Position(0, 2).ToString(), GameSymbol.FreeCell},
                {new Position(1, 0).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(1, 1).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(2, 0).ToString(), GameSymbol.FreeCell},
                {new Position(2, 1).ToString(), GameSymbol.FreeCell},
                {new Position(2, 2).ToString(), GameSymbol.PlayerOneSymbol}
            });
            var game = new Game(board);

            game.SetPlayerMovement(new Position(2, 0).ToString(), GameSymbol.PlayerTwoSymbol);

            var isWinner = game.IsThereWinner();

            Assert.True(isWinner);
        }

        [Fact]
        public void GameHaveNotWinner()
        {
            var board = new Board(new Dictionary<string, GameSymbol>
            {
                {new Position(0, 0).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), GameSymbol.FreeCell},
                {new Position(0, 2).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 0).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 1).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(1, 2).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(2, 0).ToString(), GameSymbol.FreeCell},
                {new Position(2, 1).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(2, 2).ToString(), GameSymbol.FreeCell}
            });
            var game = new Game(board);

            var isWinner = game.IsThereWinner();

            Assert.False(isWinner);
        }

        [Fact]
        public void GameFinishedAndHaveNotNotWinner()
        {
            var board = new Board(new Dictionary<string, GameSymbol>
            {
                {new Position(0, 0).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(0, 1).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(0, 2).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(1, 0).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(1, 1).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(1, 2).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(2, 0).ToString(), GameSymbol.PlayerTwoSymbol},
                {new Position(2, 1).ToString(), GameSymbol.PlayerOneSymbol},
                {new Position(2, 2).ToString(), GameSymbol.PlayerTwoSymbol}
            });
            var game = new Game(board);

            var isWinner = game.IsThereWinner();

            Assert.False(isWinner);

            var isFinished = game.IsFinished();

            Assert.True(isFinished);
        }
    }
}
