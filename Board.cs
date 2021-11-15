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
            if (Cells[0, 2] != ' ')
            {
                if (Cells[0, 2] == Cells[1, 1] &&
                    Cells[1, 1] == Cells[2, 0])
                    return true;
            }

            return false;
        }

        public bool BoardDiagonalLeftToRightCompleted()
        {
            if (Cells[0, 0] != ' ')
            {
                if (Cells[0, 0] == Cells[1, 1] &&
                    Cells[1, 1] == Cells[2, 2])
                    return true;
            }

            return false;
        }

        public bool BoardColCompleted()
        {
            for (int col = 0; col < 3; col++)
            {
                if (Cells[0, col] != ' ')
                {
                    if (Cells[0, col] == Cells[1, col] &&
                        Cells[1, col] == Cells[2, col])
                        return true;
                }
            }

            return false;
        }

        public bool BoardRowCompleted()
        {
            for (int row = 0; row < 3; row++)
            {
                if (Cells[row, 0] != ' ')
                {
                    if (Cells[row, 0] == Cells[row, 1] &&
                        Cells[row, 1] == Cells[row, 2])
                        return true;
                }
            }

            return false;
        }
    }
}