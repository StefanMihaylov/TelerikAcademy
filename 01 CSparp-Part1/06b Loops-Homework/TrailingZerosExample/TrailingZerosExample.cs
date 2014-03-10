namespace TrailingZerosExample
{
    using System;

    class TrailingZerosExample
    {
        /*  * Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:     N = 10 -> N! = 3628800 -> 2
	                    N = 20 -> N! = 2432902008176640000 -> 4
	        Does your program work for N = 50 000? */


        static void Main()
        {
            int valueN; // Enter value N            
            while (true)
            {
                Console.Write("\t Enter integer N>1: ");
                if (int.TryParse(Console.ReadLine(), out valueN) && valueN > 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            /* http://en.wikipedia.org/wiki/Trailing_zero
             The number of trailing zero of N! is SUM from i=1 to K of N/5^i. K is 5^(K+1) > N >= 5^K */

            int result = 0;
            int power = 1;
            int maxLimitSum = (int)(Math.Log(valueN) / Math.Log(5));

            for (int i = 1; i <= maxLimitSum; i++)
            {
                power *= 5;
                result += valueN / power;
            }
            Console.WriteLine("\t Number of trailing zeros of {0}! is {1}", valueN, result);            
        }
    }
}
