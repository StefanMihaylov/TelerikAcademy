namespace Matrix
{
    using System;
    using System.Collections;
    using System.Text;

    public class Matrix<T> where T : struct, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        private T[,] matrix;

        public Matrix(int row, int col)
        {
            matrix = new T[row, col];
        }

        public int Rows
        {
            get { return this.matrix.GetLength(0); }

        }

        public int Columns
        {
            get { return this.matrix.GetLength(1); }
        }

        // indexer
        public T this[int row, int col]
        {
            get
            {
                if ((row < 0 || row >= this.Rows) || (col < 0 || col >= this.Columns))
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return this.matrix[row, col];
            }
            set
            {
                if ((row < 0 || row >= this.Rows) || (col < 0 || col >= this.Columns))
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if ((firstMatrix.Rows != secondMatrix.Rows) && (firstMatrix.Columns != secondMatrix.Columns))
            {
                throw new IndexOutOfRangeException("The two matrices must have the same size");
            }
            Matrix<T> result = new Matrix<T>(firstMatrix.Rows, firstMatrix.Columns);
            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Columns; col++)
                {
                    result[row, col] = (dynamic)firstMatrix[row, col] + secondMatrix[row, col];
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if ((firstMatrix.Rows != secondMatrix.Rows) && (firstMatrix.Columns != secondMatrix.Columns))
            {
                throw new IndexOutOfRangeException("The two matrices must have the same size");
            }
            Matrix<T> result = new Matrix<T>(firstMatrix.Rows, firstMatrix.Columns);
            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Columns; col++)
                {
                    result[row, col] = (dynamic)firstMatrix[row, col] - secondMatrix[row, col];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Columns != secondMatrix.Rows)
            {
                throw new ApplicationException("The two matrices must have the appropriate size");
            }

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, secondMatrix.Columns);
            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < secondMatrix.Columns; j++)
                {
                    for (int k = 0; k < firstMatrix.Columns; k++)
                    {
                        resultMatrix[i, j] += (dynamic)firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }
            return resultMatrix;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix[i, j].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }
            return true; // all elements are different from 0
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (!matrix[i, j].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }
            return true; // all elements are equal to 0
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    result.AppendFormat("{0} ", this.matrix[i, j]);
                    if (j < this.Columns - 1)
                    {
                        result.Append(" ");
                    }
                }
                if (i < this.Rows - 1)
                {
                    result.AppendLine();
                }
            }

            return result.ToString();
        }
    }
}
