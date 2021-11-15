namespace TicTacToe
{
    public class Board
    {
        public Board(char[,] cells)
        {
            Cells = cells;
        }
        public char[,] Cells { get; }
    }
}