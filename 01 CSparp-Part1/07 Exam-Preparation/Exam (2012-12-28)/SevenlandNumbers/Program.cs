using System;

namespace SevenlandNumbers
{
    class Program
    {
        static void Main()
        {
            int K = int.Parse(Console.ReadLine());

            int decimalK = 0;
            int multiplier = 1;
            while (K>0)
            {
                decimalK += multiplier*(K % 10);
                multiplier *= 7;
                K /= 10;
            }

            decimalK++;
            int nextK = 0;
            multiplier = 1;
            while (decimalK > 0)
            {
                nextK += multiplier * (decimalK % 7);
                multiplier *= 10;
                decimalK /= 7;
            }

            Console.WriteLine(nextK);
        }
    }
}
