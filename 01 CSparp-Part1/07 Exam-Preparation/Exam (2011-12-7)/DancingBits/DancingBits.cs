using System;

namespace DancingBitsByString
{
    class DancingBits
    {
        static void Main()
        {
            int K = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            string concat = "";

            int currentNum;
            string numToBinary;
            for (int i = 0; i < N; i++)
            {
                currentNum = int.Parse(Console.ReadLine());
                numToBinary = Convert.ToString(currentNum, 2);
                concat+=numToBinary;
            }

            int dancersCount = 0;
            int currentCount = 0;
            int currentBitValue = 1;

            for (int i = 0; i < concat.Length ; i++)
            {
                if (concat[i] == currentBitValue)
                {
                    currentCount++;
                }
                else
                {
                    currentBitValue = concat[i];
                    if (currentCount == K)
                    {
                        dancersCount++;
                    }
                    currentCount = 0;
                    i--;
                }
            }

            if (currentCount == K)
            {
                dancersCount++;
            }

            Console.WriteLine(dancersCount);
        }
    }
}
