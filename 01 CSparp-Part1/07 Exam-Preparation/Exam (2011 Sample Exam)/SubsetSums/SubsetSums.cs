using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSums
{
    class SubsetSums
    {
        static void Main(string[] args)
        {
            long S = long.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            
            long[] arr = new long[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = long.Parse(Console.ReadLine());
            }

            int bit;
            int max = (int)Math.Pow(2,N);
            long sum = 0;
            int result = 0;
            for (int i = 1; i < max; i++)
            {
                sum = 0;
                for (int j = 0; j < N; j++)
                {
                    bit = i & (1 << j);
                    if (bit != 0)
                    {
                        sum += arr[j];
                    }
                }
                if (sum == S)
                {
                    result++;
                }
           }
            Console.WriteLine(result);
        }
    }
}
