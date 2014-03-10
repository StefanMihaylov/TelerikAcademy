
namespace FactorialRatioExample
{
    using System;
    using System.Numerics;

    class FactorialRatio
    {
        //Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
        
        static void Main()
        {
            int biggerValue; // Enter value K            
            while (true)
            {
                Console.Write("\t Enter integer K>1: ");
                if (int.TryParse(Console.ReadLine(), out biggerValue) && biggerValue > 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            int smallerValue; // Enter value N           
            while (true)
            {
                Console.Write("\t Enter integer N (1<N<{0}): ", biggerValue);
                if (int.TryParse(Console.ReadLine(), out smallerValue) && smallerValue > 1 && smallerValue < biggerValue)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            BigInteger result = (Factorial(biggerValue) * Factorial(smallerValue));
            result /=  Factorial(biggerValue - smallerValue);
            Console.WriteLine("\t {0}!*{1}!/{3}! = {2}", biggerValue, smallerValue, result, biggerValue-smallerValue);
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