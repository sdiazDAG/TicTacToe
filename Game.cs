using System;

namespace TicTacToe
{
    public class Game
    {
        private readonly Board gameBoard;

        public Game(Board gameBoard)
        {
            this.gameBoard = gameBoard;
        }

        public Board SetPlayerMovement(string position, GameSymbol playerSymbol)
        {
            return gameBoard.SetPlayerMovement(position, playerSymbol);
        }

        public bool IsThereWinner()
        {
            if (gameBoard.BoardRowCompleted()) return true;

            if (gameBoard.BoardColCompleted()) return true;

            if (gameBoard.BoardDiagonalLeftToRightCompleted()) return true;

            if (gameBoard.BoardDiagonalRightToLeftCompleted()) return true;

            return false;
        }

        public bool IsFinished() =>  true;
    }
}