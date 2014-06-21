namespace WalkInMatrix
{
    using System;

    public abstract class Point
    {
        protected int x;
        protected int y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public abstract int X { get; set; }

        public abstract int Y { get; set; }

        public override bool Equals(object other)
        {
            var toCompareWith = other as Point;
            if (toCompareWith == null)
            {
                return false;
            }

            return this.X == toCompareWith.X && this.Y == toCompareWith.Y;
        }

        public override int GetHashCode()
        {
            return (this.X * 1000) + this.Y;
        }

        public override string ToString()
        {
            return "{" + this.X + ", " + this.Y + "}";
        }
    }
}
