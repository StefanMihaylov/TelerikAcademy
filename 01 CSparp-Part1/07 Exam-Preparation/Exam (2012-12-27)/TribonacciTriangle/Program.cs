using System;
using System.Numerics;

namespace TribonacciTriangle
{
    class Program
    {
        static void Main()
        {
            int Ain = int.Parse(Console.ReadLine());
            int Bin = int.Parse(Console.ReadLine());
            int Cin = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());

            BigInteger A = Ain;
            BigInteger B = Bin;
            BigInteger C = Cin;
            BigInteger T;

            for (int i = 1; i <= L; i++)
            {
                if (i==1)
                {
                    Console.WriteLine(A);
                }
                else if (i==2)
                {
                    Console.WriteLine(B + " " + C);
                }
                else
                {
                    for (int element = 0; element < i; element++)
                    {
                        T = A + B + C;
                        A = B;
                        B = C;
                        C = T;
                        if (element < i-1)
                        {
                            Console.Write("{0} ",C);
                        }
                        else
                        {
                            Console.Write("{0}", C);
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
