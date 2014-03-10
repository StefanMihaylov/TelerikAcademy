namespace GreatestCommonDivisor
{
    using System;

    class GCD
    {
        //Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).

        static void Main()
        {
            int value1;
            while (true)
            {
                Console.Write("\t Enter integer 1: ");
                // the Euclidean algorithm is a method for computing the GCD of two (usually positive) integers
                if (int.TryParse(Console.ReadLine(), out value1) && value1 > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            int value2;
            while (true)
            {
                Console.Write("\t Enter integer 2: ");
                if (int.TryParse(Console.ReadLine(), out value2) && value2 > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            Console.Write("\t Greatest common devisor of {0} and {1} is ", value1, value2);
            int temp;
            while (value2!=0)
	        {
	            temp = value2;
                value2 = value1%value2;
                value1 = temp;
	        }
            Console.WriteLine(value1); // Greatest common devisor remains in "value1" variable
        }
    }
}
