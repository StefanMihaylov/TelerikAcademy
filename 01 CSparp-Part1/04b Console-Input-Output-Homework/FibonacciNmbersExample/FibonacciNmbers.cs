namespace FibonacciNmbersExample
{
    using System;
    using System.Numerics;

    class FibonacciNmbers
    {
        // Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …


        static void Main()
        {
            BigInteger number1 = 0;
            BigInteger number2 = 1;
            BigInteger temp;

            Console.WriteLine("\t {0,3} {1}", 1, number1);
            Console.WriteLine("\t {0,3} {1}", 2, number2);
            for (int i = 2; i < 100; i++)
            {
                temp = number2;
                number2 += number1;
                number1 = temp;
                Console.WriteLine("\t {0,3} {1}", i+1, number2);
            }
        }
    }
}
