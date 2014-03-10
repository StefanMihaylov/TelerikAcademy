using System;

namespace LeastMajorityMultiple
{
    class LeastMajorityMultiple
    {
        static int gcd(int a, int b)
        {
            int temp;
            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static void Main(string[] args)
        {
            int[] data = new int[5];
            for (int i = 0; i < 5; i++)
            {
               data[i] = int.Parse(Console.ReadLine());
            }

            int counter;
            long current;
            int bits;
            long result = long.MaxValue;
            for (int i = 1; i < 32; i++)
            {
                counter = 0;
                current = 1;
                for (int j = 0; j < 5; j++)
                {
                    bits = i & (1 << j);
                    if (bits != 0)
                    {
                        counter++;
                        current = (current * data[j]) / (long)gcd((int)current, data[j]);
                    }
                }
                if (counter >= 3 && current < result)
                {
                    result = current;
                }
            }
            Console.WriteLine(result);
        }
    }
}
