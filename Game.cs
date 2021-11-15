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

        public Board SetPlayerMovement(Position position, char playerSymbol)
        {
            if (GameBoard.Cells[position.X, position.Y] == ' ')
            {
                GameBoard.Cells[position.X, position.Y] = playerSymbol;
                return GameBoard;
            }

            throw new NotFreePositionException();
        }

        public bool IsThereWinner(Board actualValue)
        {
            for (int row = 0; row < 3; row++)
            {
                if (actualValue.Cells[row, 0] != ' ')
                {
                    if (actualValue.Cells[row, 0] == actualValue.Cells[row, 1] &&
                        actualValue.Cells[row, 1] == actualValue.Cells[row, 2])
                        return true;
                }
            }

            for (int col = 0; col < 3; col++)
            {
                if (actualValue.Cells[0, col] != ' ')
                {
                    if (actualValue.Cells[0, col] == actualValue.Cells[1, col] &&
                        actualValue.Cells[1, col] == actualValue.Cells[2, col])
                        return true;
                }
            }

            if (actualValue.Cells[0, 0] != ' ')
            {
                if (actualValue.Cells[0, 0] == actualValue.Cells[1, 1] &&
                    actualValue.Cells[1, 1] == actualValue.Cells[2, 2])
                    return true;
            }

            if (actualValue.Cells[0, 2] != ' ')
            {
                if (actualValue.Cells[0, 2] == actualValue.Cells[1, 1] &&
                    actualValue.Cells[1, 1] == actualValue.Cells[2, 0])
                    return true;
            }

            return false;
        }
    }
}