namespace TicTacToe
{
    public class Game
    {
        private readonly Board gameBoard;
        private PlayerSymbol gameWinner;

        public Game(Board gameBoard)
        {
            this.gameBoard = gameBoard;
        }

        public Board SetPlayerMovement(string position, PlayerSymbol playerSymbol)
        {
            return gameBoard.SetPlayerMovement(position, playerSymbol);
        }

        public bool IsThereWinner()
        {
            return gameBoard.IsThereBoardRowCompleted() || (gameBoard.IsThereBoardColumnCompleted() ||
                                                     (gameBoard.BoardDiagonalLeftToRightCompleted() ||
                                                      gameBoard.BoardDiagonalRightToLeftCompleted()));
        }

        public bool IsFinished() => gameBoard.IsBoardCompleted() && !IsThereWinner();
    }
}