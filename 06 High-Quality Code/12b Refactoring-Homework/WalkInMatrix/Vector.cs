namespace WalkInMatrix
{
    using System;

    public class Vector : Point
    {
        public const double Angle = Math.PI / 4;

        public readonly int NumberOfRotations = (int)Math.Round(2 * Math.PI / Angle);
        
        public Vector(int x, int y)
            : base(x, y)
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
                if (value < -1 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("X coordinates cannot be out of range [-1,1]");
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
                if (value < -1 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("Y coordinates cannot be out of range [-1,1]");
                }

                this.y = value;
            }
        }        

        public void Rotate()
        {
            // rotate to 45 degrees   
            double sin45 = Math.Sin(-Angle);
            double cos45 = Math.Cos(-Angle);
            double directionX = (this.X * cos45) - (this.Y * sin45);
            double directionY = (this.X * sin45) + (this.Y * cos45);

            this.X = (int)Math.Round(directionX);
            this.Y = (int)Math.Round(directionY); 
        }
    }
}