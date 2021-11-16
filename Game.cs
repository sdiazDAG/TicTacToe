namespace TicTacToe
{
    public class Game
    {
        private readonly Board gameBoard;

        public Game(Board gameBoard)
        {
            this.gameBoard = gameBoard;
        }

        public Board SetPlayerMovement(string position, GameSymbol playerSymbol)
        {
            return gameBoard.SetPlayerMovement(position, playerSymbol);
        }

        public bool IsThereWinner()
        {
            return gameBoard.IsThereBoardRowCompleted() || (gameBoard.IsThereBoardColumnCompleted() ||
                                                     (gameBoard.BoardDiagonalLeftToRightCompleted() ||
                                                      gameBoard.BoardDiagonalRightToLeftCompleted()));
        }

        public bool IsFinished() =>  true;
    }
}