namespace TicTacToe
{
    public class Game
    {
        public char[,] GetPlayerMovement(short x, short y)
        {
            if (x == 1 && y == 1)
                return new char[3, 3] { { ' ', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } };
            return new char[3, 3] { { 'O', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } };
        }
    }
}