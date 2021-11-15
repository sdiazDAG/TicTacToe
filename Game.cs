using System;

namespace TicTacToe
{
    public class Game
    {
        private char[,] Board { get; set; }

        public Game(char[,] board)
        {
            Board = board;
        }

        public char[,] GetPlayerMovement(Position position, char playerSymbol)
        {
            if (Board[position.X, position.Y] == ' ')
            {
                Board[position.X, position.Y] = playerSymbol;
                return Board;
            }
            throw new NotFreePositionException();
        }
    }
}