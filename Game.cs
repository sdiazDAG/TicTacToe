using System;

namespace TicTacToe
{
    public class Game
    {
        public char[,] Board { get; set; }

        public Game(char[,] board)
        {
            Board = board;
        }

        public char[,] GetPlayerMovement(short x, short y, char playerSymbol)
        {
            if (Board[x, y] == ' ')
            {
                Board[x, y] = playerSymbol;
                return Board;
            }
            throw new NotFreePositionException();
        }
    }
}