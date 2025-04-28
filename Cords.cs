using SnakeGame;

namespace SnakeGame
{
    public struct Coord
    {
        public int X, Y;
        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void ApplyMovementDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: Y--; break;
                case Direction.Down: Y++; break;
                case Direction.Left: X--; break;
                case Direction.Right: X++; break;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Coord coord && X == coord.X && Y == coord.Y;
        }

        public override int GetHashCode()
        {
            return X * 1 + Y;
        }
    }
}
