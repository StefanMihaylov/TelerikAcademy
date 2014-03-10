

namespace CatalanNumberExample
{
    using System;
    using System.Numerics;

    class CatalanNumber
    {
        // Write a program to calculate the Nth Catalan number by given N

        static void Main()
        {
            int valueN;
            while (true)
            {
                Console.Write("\t Enter integer N: ");
                if (int.TryParse(Console.ReadLine(), out valueN) && valueN >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            BigInteger catalanNumber = Factorial(2*valueN)/(Factorial(valueN+1)*Factorial(valueN));
            Console.WriteLine("\t Catalan number C{0} is {1}", valueN, catalanNumber);
        }

        static BigInteger Factorial(int value)
        {
            // calculate factorial of number
            BigInteger result = 1;
            if (value > 0)
            {
                for (int i = 2; i <= value; i++)
                {
                    result *= i;
                }
                return result;
            }
            else if (value == 0)
            {
                return 1;
            }
            else
            {
                Console.WriteLine("Wrong input variable of method 'Factorial'");
                return 0;                
            }

        }
    }
}
