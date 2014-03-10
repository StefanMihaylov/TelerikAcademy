using System;
using System.Numerics;

namespace Thribonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int A = int.Parse(Console.ReadLine());
            int B = int.Parse(Console.ReadLine());
            int C = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            BigInteger result = 0;
            if (N == 1)
            {
                result = A;
            }
            else if (N == 2)
            {
                result = B;
            }
            else if (N == 3)
            {
                result = C;
            }
            else
            {
                BigInteger A1 = A;
                BigInteger B1 = B;
                BigInteger C1 = C;
                for (int i = 3; i < N; i++)
                {
                    result = A1 + B1 + C1;
                    A1 = B1;
                    B1 = C1;
                    C1 = result;
                }
            }
            Console.WriteLine(result);
        }
    }
}
