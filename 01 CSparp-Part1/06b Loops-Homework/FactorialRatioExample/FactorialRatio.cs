
namespace FactorialRatioExample
{
    using System;
    using System.Numerics;

    class FactorialRatio
    {
        // Write a program that calculates N!/K! for given N and K (1<K<N)

        static void Main()
        {
            int nominator; // Enter value N            
            while (true)
            {
                Console.Write("\t Enter integer N>1: ");
                if (int.TryParse(Console.ReadLine(), out nominator) && nominator > 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            int denominator; // Enter value K            
            while (true)
            {
                Console.Write("\t Enter integer K (1<K<{0}): ", nominator);
                if (int.TryParse(Console.ReadLine(), out denominator) && denominator > 1 && denominator < nominator)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            BigInteger result = Factorial(nominator) / Factorial(denominator);
            Console.WriteLine("\t {0}!/{1}! = {2}",nominator,denominator,result);
        }

        static BigInteger Factorial(int value)
        {
            // calculate factorial of number
            BigInteger result = 1;
            for (int i = 2; i <= value; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
