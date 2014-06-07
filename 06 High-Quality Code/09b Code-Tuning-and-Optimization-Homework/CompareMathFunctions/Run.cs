namespace CompareMathFunctions
{
    using System;
    using System.Diagnostics;

    public class Run
    {
        /* 2. Write a program to compare the performance of add, subtract, increment, multiply, divide for int, long, float, double and decimal values.*/

        /* 3. Write a program to compare the performance of square root, natural logarithm, sinus for float, double and decimal values.*/

        public const int NumberOfCalculations = 100000;

        public static void Main()
        {
            Console.WriteLine("\n Comparison tables. All values in microseconds. Number of calculations: {0} \n", NumberOfCalculations);

            CompareAritmeticFunctions();

            CompareFloatFunctions();
        }

        private static long MeasureTime<T>(Func<T, T> calculation, T startValue)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            T result = startValue;
            for (int i = 0; i < NumberOfCalculations; i++)
            {
                // the return value of the function is not assigned to the result, so the calculations will be with the constant numbers
                calculation(result);
            }

            stopwatch.Stop();
            return stopwatch.Elapsed.Ticks; // 1 tick = 100 ns
        }

        private static void CompareAritmeticFunctions()
        {
            long[,] result = new long[5, 5];

            // add
            result[0, 0] = MeasureTime<int>(x => x + 200, 500);
            result[0, 1] = MeasureTime<long>(x => x + 200, 500);
            result[0, 2] = MeasureTime<float>(x => x + 200.0f, 500.0f);
            result[0, 3] = MeasureTime<double>(x => x + 200.0, 500.0);
            result[0, 4] = MeasureTime<decimal>(x => x + 200.0m, 500.0m);

            // subtract
            result[1, 0] = MeasureTime<int>(x => x - 200, 500);
            result[1, 1] = MeasureTime<long>(x => x - 200, 500);
            result[1, 2] = MeasureTime<float>(x => x - 200.0f, 500.0f);
            result[1, 3] = MeasureTime<double>(x => x - 200.0, 500.0);
            result[1, 4] = MeasureTime<decimal>(x => x - 200.0m, 500.0m);

            // increment
            result[2, 0] = MeasureTime<int>(x => x++, 500);
            result[2, 1] = MeasureTime<long>(x => x++, 500);
            result[2, 2] = MeasureTime<float>(x => x++, 500.0f);
            result[2, 3] = MeasureTime<double>(x => x++, 500.0);
            result[2, 4] = MeasureTime<decimal>(x => x++, 500.0m);

            // multiply
            result[3, 0] = MeasureTime<int>(x => x * 200, 500);
            result[3, 1] = MeasureTime<long>(x => x * 200, 500);
            result[3, 2] = MeasureTime<float>(x => x * 200.0f, 500.0f);
            result[3, 3] = MeasureTime<double>(x => x * 200.0, 500.0);
            result[3, 4] = MeasureTime<decimal>(x => x * 200.0m, 500.0m);

            // divide
            result[4, 0] = MeasureTime<int>(x => x / 200, 500);
            result[4, 1] = MeasureTime<long>(x => x / 200, 500);
            result[4, 2] = MeasureTime<float>(x => x / 200.0f, 500.0f);
            result[4, 3] = MeasureTime<double>(x => x / 200.0, 500.0);
            result[4, 4] = MeasureTime<decimal>(x => x / 200.0m, 500.0m);

            // print result
            Console.WriteLine(new string('-', 72));
            Console.WriteLine(" \t\t |{0,8} | {1,8} | {2,8} | {3,8} | {4,8} |", "int", "long", "float", "double", "decimal");
            Console.WriteLine(new string('-', 72));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                switch (i)
                {
                    case 0:
                        Console.Write(" Add\t\t |");
                        break;
                    case 1:
                        Console.Write(" subtract\t |");
                        break;
                    case 2:
                        Console.Write(" increment\t |");
                        break;
                    case 3:
                        Console.Write(" multiply\t |");
                        break;
                    case 4:
                        Console.Write(" divide\t\t |");
                        break;
                    default:
                        Console.Write(" unknown?\t |");
                        break;
                }

                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write("{0,8:f1} | ", ((double)result[i, j]) / 10.0);
                }

                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 72));
            Console.WriteLine();
        }

        private static void CompareFloatFunctions()
        {
            long[,] resultTask3 = new long[3, 3];

            // SQRT
            resultTask3[0, 0] = MeasureTime<float>(x => (float)Math.Sqrt(x), 500.0f);
            resultTask3[0, 1] = MeasureTime<double>(x => Math.Sqrt(x), 500.0);
            resultTask3[0, 2] = MeasureTime<decimal>(x => (decimal)Math.Sqrt((double)x), 500.0m);

            // LOG
            resultTask3[1, 0] = MeasureTime<float>(x => (float)Math.Log(x), 500.0f);
            resultTask3[1, 1] = MeasureTime<double>(x => Math.Log(x), 500.0);
            resultTask3[1, 2] = MeasureTime<decimal>(x => (decimal)Math.Log((double)x), 500.0m);

            // Sin
            resultTask3[2, 0] = MeasureTime<float>(x => (float)Math.Sin(x), 500.0f);
            resultTask3[2, 1] = MeasureTime<double>(x => Math.Sin(x), 500.0);
            resultTask3[2, 2] = MeasureTime<decimal>(x => (decimal)Math.Sin((double)x), 500.0m);

            // print the result
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(" \t\t |{0,8} | {1,8} | {2,8} |", "float", "double", "decimal");
            Console.WriteLine(new string('-', 50));

            for (int i = 0; i < resultTask3.GetLength(0); i++)
            {
                switch (i)
                {
                    case 0: Console.Write(" Sqrt\t\t |");
                        break;
                    case 1: Console.Write(" Log\t\t |");
                        break;
                    case 2: Console.Write(" Sin\t\t |");
                        break;
                    default: Console.Write(" unknown?\t |");
                        break;
                }

                for (int j = 0; j < resultTask3.GetLength(1); j++)
                {
                    Console.Write("{0,8:f1} | ", ((double)resultTask3[i, j]) / 10.0);
                }

                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }
    }
}
