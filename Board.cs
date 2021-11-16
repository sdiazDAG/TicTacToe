using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace TicTacToe
{
    
    public class Board
    {
        public Board()
        {
            Cells = new[,] {{GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell}, {GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell}, {GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell}};
        }
        public Board(GameSymbol[,] cells)
        {
            Cells = cells;
        }
        public GameSymbol[,] Cells { get; private set; }

        public bool BoardCellIsEmpty(Position position) => (Cells[position.X, position.Y] == GameSymbol.FreeCell);
        public bool BoardDiagonalRightToLeftCompleted()
        {
            if (Cells[0, 2] == GameSymbol.FreeCell) return false;
            return Cells[0, 2] == Cells[1, 1] &&
                   Cells[1, 1] == Cells[2, 0];
        }

        public bool BoardDiagonalLeftToRightCompleted()
        {
            if (Cells[0, 0] == GameSymbol.FreeCell) return false;
            return Cells[0, 0] == Cells[1, 1] &&
                   Cells[1, 1] == Cells[2, 2];
        }

        public bool BoardColCompleted()
        {
            for (var col = 0; col < 3; col++)
            {
                if (Cells[0, col] == GameSymbol.FreeCell) continue;
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
                if (Cells[row, 0] == GameSymbol.FreeCell) continue;
                if (Cells[row, 0] == Cells[row, 1] &&
                    Cells[row, 1] == Cells[row, 2])
                    return true;
            }
            return false;
        }
    }
}