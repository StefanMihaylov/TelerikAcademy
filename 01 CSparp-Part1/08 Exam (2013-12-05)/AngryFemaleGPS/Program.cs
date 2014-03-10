using System;

namespace AngryFemaleGPS
{
    class Program
    {
        static void Main()
        {
            long N = long.Parse(Console.ReadLine());

            if( N < 0)
            {
                N *= -1;
            }

            int evenNumbersSum = 0;
            int oddNumbersSum = 0;
            int digit;

            while (N > 0)
            {
                digit = (int)(N % 10);
                N /= 10;
                if (digit % 2 == 0)
                {
                    evenNumbersSum += digit;
                }
                else
                {
                    oddNumbersSum += digit;
                }
            }

            if (evenNumbersSum > oddNumbersSum)
            {
                Console.WriteLine("right {0}", evenNumbersSum);
            }
            else if (oddNumbersSum > evenNumbersSum)
            {
                Console.WriteLine("left {0}", oddNumbersSum);
            }
            else
            {
                Console.WriteLine("straight {0}", oddNumbersSum);
            }
        }
    }
}
