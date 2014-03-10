namespace FibonacciSumExample
{
    using System;
    using System.Numerics;

    class FibonacciSum
    {
        // Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

        static void Main()
        {
            int valueN;
            while (true)
            {
                Console.Write("\t Enter integer N>2: ");
                if (int.TryParse(Console.ReadLine(), out valueN) && valueN > 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            long fibonacciSmall = 0;
            long fibonacciBig = 1;
            long temp;
            BigInteger sum = 1;

            for (int i = 3; i <= valueN; i++)
            {
                temp = fibonacciBig;
                fibonacciBig += fibonacciSmall;
                fibonacciSmall = temp;
                sum += fibonacciBig;
            }
            Console.WriteLine("\t The sum of first {0} elements of Fibonacci sequence is {1}",valueN,sum);
        }
    }
}