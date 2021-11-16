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
            var expectedBoard = new Board(new Dictionary<string, PlayerSymbol>
            {
                {new Position(0, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(0, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(0, 2).ToString(), PlayerSymbol.FreeCell},
                {new Position(1, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(1, 1).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 2).ToString(), PlayerSymbol.FreeCell}
            });

            var currentBoard = game.SetPlayerMovement(new Position(1, 1), PlayerSymbol.PlayerOneSymbol);
            
            Assert.Equal(expectedBoard, currentBoard);
        }

        [Fact]
        public void PlayerTwoPlaysSecondMovement()
        {
            var board = new Board(new Dictionary<string, PlayerSymbol>
            {
                {new Position(0, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(0, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(0, 2).ToString(), PlayerSymbol.FreeCell},
                {new Position(1, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(1, 1).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 2).ToString(), PlayerSymbol.FreeCell}
            });
            var game = new Game(board);
            var expectedBoard = new Board(new Dictionary<string, PlayerSymbol>
            {
                {new Position(0, 0).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(0, 2).ToString(), PlayerSymbol.FreeCell},
                {new Position(1, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(1, 1).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 2).ToString(), PlayerSymbol.FreeCell}
            });

            var currentBoard = game.SetPlayerMovement(new Position(0, 0), PlayerSymbol.PlayerTwoSymbol);

            Assert.Equal(expectedBoard, currentBoard);
        }

        [Fact]
        public void PlayerOnePlaysThirdMovement()
        {
            var board = new Board(new Dictionary<string, PlayerSymbol>
            {
                {new Position(0, 0).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(0, 2).ToString(), PlayerSymbol.FreeCell},
                {new Position(1, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(1, 1).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 2).ToString(), PlayerSymbol.FreeCell}
            });
            var game = new Game(board);
            var expectedBoard = new Board(new Dictionary<string, PlayerSymbol>
            {
                {new Position(0, 0).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(0, 2).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(1, 1).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 2).ToString(), PlayerSymbol.FreeCell}
            });

            var currentBoard = game.SetPlayerMovement(new Position(0, 2), PlayerSymbol.PlayerOneSymbol);

            Assert.Equal(expectedBoard, currentBoard);
        }

        [Fact]
        public void PlayerTwoPlaysFourthMovementInNotFreePosition()
        {
            var board = new Board(new Dictionary<string, PlayerSymbol>
            {
                {new Position(0, 0).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(0, 2).ToString(), PlayerSymbol.FreeCell},
                {new Position(1, 0).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 1).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 2).ToString(), PlayerSymbol.FreeCell}
            });
            var game = new Game(board);

            Action action = () => game.SetPlayerMovement(new Position(1, 0), PlayerSymbol.PlayerTwoSymbol);

            Assert.Throws<NotFreePositionException>(action);
        }

        [Fact]
        public void PlayerOneWinGame()
        {
            var board = new Board(new Dictionary<string, PlayerSymbol>
            {
                {new Position(0, 0).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(0, 2).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(1, 1).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(2, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 2).ToString(), PlayerSymbol.FreeCell}
            });
            var game = new Game(board);

            game.SetPlayerMovement(new Position(2, 0), PlayerSymbol.PlayerOneSymbol);

            var isWinner = game.IsThereWinner();

            Assert.True(isWinner);

            var winner = game.WhoIsTheWinner();

            Assert.Equal(PlayerSymbol.PlayerOneSymbol, winner);
        }

        [Fact]
        public void PlayerTwoWinGame()
        {
            var board = new Board(new Dictionary<string, PlayerSymbol>
            {
                {new Position(0, 0).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(0, 2).ToString(), PlayerSymbol.FreeCell},
                {new Position(1, 0).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(1, 1).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 2).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(2, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 2).ToString(), PlayerSymbol.PlayerOneSymbol}
            });
            var game = new Game(board);

            game.SetPlayerMovement(new Position(2, 0), PlayerSymbol.PlayerTwoSymbol);

            var isWinner = game.IsThereWinner();

            Assert.True(isWinner);

            var winner = game.WhoIsTheWinner();

            Assert.Equal(PlayerSymbol.PlayerTwoSymbol, winner);
        }

        [Fact]
        public void GameHaveNotWinner()
        {
            var board = new Board(new Dictionary<string, PlayerSymbol>
            {
                {new Position(0, 0).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(0, 1).ToString(), PlayerSymbol.FreeCell},
                {new Position(0, 2).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 0).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 1).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(1, 2).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(2, 0).ToString(), PlayerSymbol.FreeCell},
                {new Position(2, 1).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(2, 2).ToString(), PlayerSymbol.FreeCell}
            });
            var game = new Game(board);

            var isWinner = game.IsThereWinner();

            Assert.False(isWinner);
        }

        [Fact]
        public void GameFinishedAndHaveNotNotWinner()
        {
            var board = new Board(new Dictionary<string, PlayerSymbol>
            {
                {new Position(0, 0).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(0, 1).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(0, 2).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 0).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(1, 1).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(1, 2).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(2, 0).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(2, 1).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(2, 2).ToString(), PlayerSymbol.PlayerTwoSymbol}
            });
            var game = new Game(board);

            var isWinner = game.IsThereWinner();

            Assert.False(isWinner);

            var isFinished = game.IsFinished();

            Assert.True(isFinished);

            PlayerSymbol? winner = game.WhoIsTheWinner();

            Assert.Null(winner);
        }

        [Fact]
        public void GameFinishedThenPlayerCanNotMove()
        {
            var board = new Board(new Dictionary<string, PlayerSymbol>
            {
                {new Position(0, 0).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(0, 1).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(0, 2).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(1, 0).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(1, 1).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(1, 2).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(2, 0).ToString(), PlayerSymbol.PlayerTwoSymbol},
                {new Position(2, 1).ToString(), PlayerSymbol.PlayerOneSymbol},
                {new Position(2, 2).ToString(), PlayerSymbol.PlayerTwoSymbol}
            });
            var game = new Game(board);

            Action action = () => game.SetPlayerMovement(new Position(1, 0), PlayerSymbol.PlayerTwoSymbol);

            Assert.Throws<FinishedGameException>(action);
        }
    }
}
