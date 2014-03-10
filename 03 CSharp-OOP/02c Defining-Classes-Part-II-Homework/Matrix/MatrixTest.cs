namespace Matrix
{
    using System;

    class MatrixTest
    {
        /*
   8. Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
   9. Implement an indexer this[row, col] to access the inner matrix cells.
   10. Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication. 
	    Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements). */

        static void Main()
        {
            Matrix<int> first = new Matrix<int>(3, 3);
            Matrix<int> second = new Matrix<int>(3, 3);

            Random randGenerator = new Random(0);
            for (int row = 0; row < first.Rows; row++)
            {
                for (int col = 0; col < first.Columns; col++)
                {
                    first[row, col] = randGenerator.Next(-10, 11);
                    second[row, col] = randGenerator.Next(-10, 11);
                }
            }

            Console.WriteLine(" First matrix:");
            Console.WriteLine(first);
            Console.WriteLine();

            Console.WriteLine(" Second matrix:");
            Console.WriteLine(second);
            Console.WriteLine();

            Console.WriteLine(" Addition:");
            Console.WriteLine(first + second);
            Console.WriteLine();

            Console.WriteLine(" Subtraction:");
            Console.WriteLine(first - second);
            Console.WriteLine();

            Console.WriteLine(" Multipication:");
            Console.WriteLine(first * second);
            Console.WriteLine();

            Console.WriteLine("Is first matrix does't contain zero: {0}", first ? true : false);
            Console.WriteLine();

            first[0, 0] = 0;
            Console.WriteLine("Is first matrix does't contain zero: {0}", first ? true : false);
            Console.WriteLine();

            // check exeptions
            //Console.WriteLine(first[0,3]);
        }
    }
}
