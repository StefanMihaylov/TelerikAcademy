
namespace FightersCon
{
    public struct MatrixCoords
    {
        // constructor (template) - we create initial values for the rows and the columns.
        public MatrixCoords(int row, int col) : this() 
        {
            this.Row = row;
            this.Col = col;
        }

        // we create a property to which we will add a value on a later stage.
        public int Row { get; set; } 

        public int Col { get; set; }

        // this method sums the coordinates (x + x, y + y) of the respective object.
        public static MatrixCoords operator +(MatrixCoords a, MatrixCoords b) 
        {
            return new MatrixCoords(a.Row + b.Row, a.Col + b.Col);
        }
        public static MatrixCoords operator *(MatrixCoords a, int b)
        {
            return new MatrixCoords(a.Row * b, a.Col * b);
        }

        // this method extracts the coordinates (x - x, y - y) of the respective object.
        public static MatrixCoords operator -(MatrixCoords a, MatrixCoords b) 
        {
            return new MatrixCoords(a.Row - b.Row, a.Col - b.Col);
        }

        // this method returns an answer to the question whether two cordinates are equal.
        public override bool Equals(object obj)
        {
            MatrixCoords objAsMatrixCoords = (MatrixCoords)obj;

            return objAsMatrixCoords.Row == this.Row && objAsMatrixCoords.Col == this.Col;
        }

        // this method is always written when the "Equals" boolean method exists.
        public override int GetHashCode() 
        {
            return this.Row.GetHashCode() * 7 + this.Col;
        }
    }
}
