using System.Linq;

namespace TicTacToe
{
    
    public class Board
    {
        private readonly GameSymbol[,] cells;

        public Board()
        {
            cells = new[,] {{GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell}, {GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell}, {GameSymbol.FreeCell, GameSymbol.FreeCell, GameSymbol.FreeCell}};
        }
        public Board(GameSymbol[,] cells)
        {
            this.cells = cells;
        }

        public override bool Equals(object? obj)
        {
            return obj is Board newBoard && ToString() == newBoard.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Join(",", cells.Cast<GameSymbol>());
        }

        public Board SetPlayerMovement(Position position, GameSymbol playerSymbol)
        {
            if (BoardCellIsEmpty(position))
            {
                cells[position.X, position.Y] = playerSymbol;
                return this;
            }

            throw new NotFreePositionException();
        }

        public bool BoardCellIsEmpty(Position position) => (cells[position.X, position.Y] == GameSymbol.FreeCell);
        public bool BoardDiagonalRightToLeftCompleted()
        {
            if (cells[0, 2] == GameSymbol.FreeCell) return false;
            return cells[0, 2] == cells[1, 1] &&
                   cells[1, 1] == cells[2, 0];
        }

        public bool BoardDiagonalLeftToRightCompleted()
        {
            if (cells[0, 0] == GameSymbol.FreeCell) return false;
            return cells[0, 0] == cells[1, 1] &&
                   cells[1, 1] == cells[2, 2];
        }

        public bool BoardColCompleted()
        {
            for (var col = 0; col < 3; col++)
            {
                if (cells[0, col] == GameSymbol.FreeCell) continue;
                if (cells[0, col] == cells[1, col] &&
                    cells[1, col] == cells[2, col])
                    return true;
            }
            return false;
        }

        public bool BoardRowCompleted()
        {
            for (var row = 0; row < 3; row++)
            {
                if (cells[row, 0] == GameSymbol.FreeCell) continue;
                if (cells[row, 0] == cells[row, 1] &&
                    cells[row, 1] == cells[row, 2])
                    return true;
            }
            return false;
        }
    }
}