using System;

namespace TicTacToe
{
    public class Game
    {
        private Board GameBoard { get; set; }

        public Game(Board gameBoard)
        {
            GameBoard = gameBoard;
        }

        public Board SetPlayerMovement(Position position, GameSymbol playerSymbol)
        {
            return GameBoard.SetPlayerMovement(position, playerSymbol);
        }

        public bool IsThereWinner()
        {
            if (GameBoard.BoardRowCompleted()) return true;

            if (GameBoard.BoardColCompleted()) return true;

            if (GameBoard.BoardDiagonalLeftToRightCompleted()) return true;

            if (GameBoard.BoardDiagonalRightToLeftCompleted()) return true;

            return false;
        }

        public bool IsFinished() =>  true;
    }
}