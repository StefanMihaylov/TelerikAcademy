namespace WalkInMatrix
{
    using System;

    public class Cell : Point
    {
        public Cell(int x, int y)
            : base(x, y)
        {
        }

        public Cell()
            : this(0, 0)
        {
        }

        public override int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("X coordinates cannot be negative");
                }

                this.x = value;
            }
        }

        public override int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Y coordinates cannot be negative");
                }

                this.y = value;
            }
        }

        public static Cell operator +(Cell operand1, Vector operand2)
        {
            return new Cell(operand1.X + operand2.X, operand1.Y + operand2.Y);
        }
    }
}
