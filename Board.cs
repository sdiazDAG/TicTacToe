using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    
    public class Board
    {
        private readonly Dictionary<string, GameSymbol> cells;

        public Board()
        {
            cells = new Dictionary<string, GameSymbol>
            {
                {new Position(0, 0).ToString(), GameSymbol.FreeCell},
                {new Position(0, 1).ToString(), GameSymbol.FreeCell},
                {new Position(0, 2).ToString(), GameSymbol.FreeCell},
                {new Position(1, 0).ToString(), GameSymbol.FreeCell},
                {new Position(1, 1).ToString(), GameSymbol.FreeCell},
                {new Position(1, 2).ToString(), GameSymbol.FreeCell},
                {new Position(2, 0).ToString(), GameSymbol.FreeCell},
                {new Position(2, 1).ToString(), GameSymbol.FreeCell},
                {new Position(2, 2).ToString(), GameSymbol.FreeCell}
            };
        }

        public Board(Dictionary<string, GameSymbol> cells)
        {
            this.cells = cells;
        }
        
        public override bool Equals(object? obj)
        {
            var newBoard = obj as Board;
            var result = newBoard.cells.Except(this.cells);
            return !result.Any();
        }
        
        public Board SetPlayerMovement(string position, GameSymbol playerSymbol)
        {
            if (!BoardCellIsEmpty(position)) throw new NotFreePositionException();
            cells[position.ToString()] = playerSymbol;
            return this;
        }
        
        public bool BoardCellIsEmpty(string position)
        {
            var currentCell = cells
                .Where(cell => cell.Key == position.ToString())
                .Select(cell => cell.Value)
                .FirstOrDefault();
            return currentCell == GameSymbol.FreeCell;
        } 
        
        public bool BoardDiagonalRightToLeftCompleted()
        {
            if (BoardCellIsEmpty(new Position(0, 2).ToString())) return false;
            return cells[new Position(0, 2).ToString()] == cells[new Position(1, 1).ToString()] &&
                   cells[new Position(1, 1).ToString()] == cells[new Position(2, 0).ToString()];
        }
        
        public bool BoardDiagonalLeftToRightCompleted()
        {
            if (BoardCellIsEmpty(new Position(0, 0).ToString())) return false;
            return cells[new Position(0, 0).ToString()] == cells[new Position(1, 1).ToString()] &&
                   cells[new Position(1, 1).ToString()] == cells[new Position(2, 2).ToString()];
        }
        
        public bool IsThereBoardColumnCompleted()
        {
            for (short col = 0; col < 3; col++)
            {
                if (IsColumnCompleted(col)) return true;
            }
            return false;
        }

        private bool IsColumnCompleted(short col)
        {
            if (BoardCellIsEmpty(new Position(0, col).ToString())) return false;
            return cells[new Position(0, col).ToString()] == cells[new Position(1, col).ToString()] &&
                   cells[new Position(1, col).ToString()] == cells[new Position(2, col).ToString()];
        }

        public bool IsThereBoardRowCompleted()
        {
            for (short row = 0; row < 3; row++)
            {
                if (IsRowCompleted(row)) return true;
            }
            return false;
        }

        private bool IsRowCompleted(short row)
        {
            if (BoardCellIsEmpty(new Position(row, 0).ToString())) return false;
            return cells[new Position(row, 0).ToString()] == cells[new Position(row, 1).ToString()] &&
                   cells[new Position(row, 1).ToString()] == cells[new Position(row, 2).ToString()];
        }
    }
}