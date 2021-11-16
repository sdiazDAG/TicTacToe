using System;
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
            if (cells[new Position(0, 2).ToString()] == GameSymbol.FreeCell) return false;
            return cells[new Position(0, 2).ToString()] == cells[new Position(1, 1).ToString()] &&
                   cells[new Position(1, 1).ToString()] == cells[new Position(2, 0).ToString()];
        }
        
        public bool BoardDiagonalLeftToRightCompleted()
        {
            if (cells[new Position(0, 0).ToString()] == GameSymbol.FreeCell) return false;
            return cells[new Position(0, 0).ToString()] == cells[new Position(1, 1).ToString()] &&
                   cells[new Position(1, 1).ToString()] == cells[new Position(2, 2).ToString()];
        }
        
        public bool BoardColCompleted()
        {
            for (short col = 0; col < 3; col++)
            {
                if (cells[new Position(0, col).ToString()] == GameSymbol.FreeCell) continue;
                if (cells[new Position(0, col).ToString()] == cells[new Position(1, col).ToString()] &&
                    cells[new Position(1, col).ToString()] == cells[new Position(2, col).ToString()])
                    return true;
            }
            return false;
        }
        
        public bool BoardRowCompleted()
        {
            for (short row = 0; row < 3; row++)
            {
                if (cells[new Position(row, 0).ToString()] == GameSymbol.FreeCell) continue;
                if (cells[new Position(row, 0).ToString()] == cells[new Position(row, 1).ToString()] &&
                    cells[new Position(row, 1).ToString()] == cells[new Position(row, 2).ToString()])
                    return true;
            }
            return false;
        }
    }
}