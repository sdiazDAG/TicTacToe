namespace TicTacToe
{
    public class Position
    {
        public Position(short x, short y)
        {
            X = x;
            Y = y;
        }

        public short X { get; private set; }
        public short Y { get; private set; }

        public override string ToString()
        {
            return $"{this.X},{this.Y}";
        }

    }
}