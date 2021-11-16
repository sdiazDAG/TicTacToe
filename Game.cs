namespace TicTacToe
{
    public class Game
    {
        private readonly Board gameBoard;
        private PlayerSymbol? lastPlayer;


        public Game(Board gameBoard)
        {
            this.gameBoard = gameBoard;
        }

        public Board SetPlayerMovement(Position position, PlayerSymbol playerSymbol)
        {
            var board = gameBoard.SetPlayerMovement(position.ToString(), playerSymbol);
            lastPlayer = playerSymbol;
            return board;
        }

        public bool IsThereWinner() => gameBoard.IsThereBoardRowCompleted() || (gameBoard.IsThereBoardColumnCompleted() ||
                                                     (gameBoard.BoardDiagonalLeftToRightCompleted() ||
                                                      gameBoard.BoardDiagonalRightToLeftCompleted()));

        public bool IsFinished() => gameBoard.IsBoardCompleted() && !IsThereWinner();

        public PlayerSymbol? WhoIsTheWinner() => IsThereWinner() ? lastPlayer : null;
    }
}