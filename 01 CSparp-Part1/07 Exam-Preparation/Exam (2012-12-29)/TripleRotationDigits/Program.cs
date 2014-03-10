using System;

namespace TripleRotationDigits
{
    class Program
    {
        static void Main()
        {
            int K = int.Parse(Console.ReadLine());

            int Klen;
            int Ktemp;
            int rem;
            int multipier;
            for (int i = 0; i < 3; i++)
            {
                Ktemp = K;
                Klen = 0;
                while (Ktemp>0)
                {
                    Ktemp /= 10;
                    Klen++;
                }
                multipier = 1;
                for (int j = 1; j < Klen; j++)
                {
                    multipier *= 10;
                }

                rem = K % 10;
                K = K/10+rem*multipier;
            }

            Console.WriteLine(K);
        }
    }
}
