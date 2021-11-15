namespace TicTacToe
{
    public class Game
    {
        private char[,] Board;
        public Game()
        {
            Board = new char[3, 3] {{' ', ' ', ' '}, {' ', ' ', ' '}, {' ', ' ', ' '}};
        }

        public char[,] GetPlayerMovement(short x, short y)
        {
            if (x == 1 && y == 1)
                Board = new char[3, 3] {{' ', ' ', ' '}, {' ', 'X', ' '}, {' ', ' ', ' '}};
            else
                Board = new char[3, 3] { { 'O', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } };
            return Board;
        }
    }
}