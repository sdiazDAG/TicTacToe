namespace TicTacToe
{
    public class Game
    {
        private readonly Board gameBoard;
        private PlayerSymbol? lastPlayerWhoMoved;


        public Game(Board gameBoard)
        {
            this.gameBoard = gameBoard;
        }

        public Board SetPlayerMovement(Position position, PlayerSymbol playerSymbol)
        {
            if (IsFinished()) throw new FinishedGameException(); ; 
            var board = gameBoard.SetPlayerMovement(position.ToString(), playerSymbol);
            lastPlayerWhoMoved = playerSymbol;
            return board;
        }

        public bool IsThereWinner() => gameBoard.IsThereBoardRowCompleted() || (gameBoard.IsThereBoardColumnCompleted() ||
                                                     (gameBoard.BoardDiagonalLeftToRightCompleted() ||
                                                      gameBoard.BoardDiagonalRightToLeftCompleted()));

        public bool IsFinished() => gameBoard.IsBoardCompleted() || IsThereWinner();

        public PlayerSymbol? WhoIsTheWinner() => IsThereWinner() ? lastPlayerWhoMoved : null;
    }
}