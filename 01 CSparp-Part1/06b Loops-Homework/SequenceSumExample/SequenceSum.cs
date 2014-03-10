namespace SequenceSumExample
{
    using System;

    class SequenceSum
    {
        //Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN

        static void Main(string[] args)
        {
            int valueN;
            while (true)
            {
                Console.Write("\t Enter integer N: ");
                if (int.TryParse(Console.ReadLine(), out valueN) && valueN > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            int ValueX;
            while (true)
            {
                Console.Write("\t Enter integer X: ");
                if (int.TryParse(Console.ReadLine(), out ValueX) && ValueX > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            decimal sum = 1;
            decimal factorialN = 1;
            decimal powerX = 1;
            for (int i = 1; i <= valueN; i++)
            {
                factorialN *= i;
                powerX *= ValueX;
                sum += factorialN / powerX;                
            }
            Console.WriteLine("\t The sum of firts {0} elements of the sequence is {1:f6}", valueN + 1, sum);
        }
    }
}