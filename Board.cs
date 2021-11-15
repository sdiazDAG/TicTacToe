namespace TicTacToe
{
    public class Board
    {
        public Board(char[,] cells)
        {
            Cells = cells;
        }
        public char[,] Cells { get; }

        public bool BoardDiagonalRightToLeftCompleted()
        {
            if (Cells[0, 2] == ' ') return false;
            return Cells[0, 2] == Cells[1, 1] &&
                   Cells[1, 1] == Cells[2, 0];
        }

        public bool BoardDiagonalLeftToRightCompleted()
        {
            if (Cells[0, 0] == ' ') return false;
            return Cells[0, 0] == Cells[1, 1] &&
                   Cells[1, 1] == Cells[2, 2];
        }

        public bool BoardColCompleted()
        {
            for (var col = 0; col < 3; col++)
            {
                if (Cells[0, col] == ' ') continue;
                if (Cells[0, col] == Cells[1, col] &&
                    Cells[1, col] == Cells[2, col])
                    return true;
            }
            return false;
        }

        public bool BoardRowCompleted()
        {
            for (var row = 0; row < 3; row++)
            {
                if (Cells[row, 0] == ' ') continue;
                if (Cells[row, 0] == Cells[row, 1] &&
                    Cells[row, 1] == Cells[row, 2])
                    return true;
            }
            return false;
        }
    }
}