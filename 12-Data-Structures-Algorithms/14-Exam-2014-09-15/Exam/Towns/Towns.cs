using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towns
{
    class Towns
    {
        static void Main()
        {
            // Load data from local HDD if program is run in VS
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                Console.SetIn(new StreamReader(@"..\..\Test01.txt"));
            }

            int N = int.Parse(Console.ReadLine());
            int[] numbers = new int[N];

            for (int i = 0; i < N; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);
            }

            int maxNumber = 0;
            int maxIndex = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int current = numbers[i];
                if (maxNumber < current)
                {
                    maxNumber = current;
                    maxIndex = i;
                }
            }
            // Console.WriteLine(maxIndex);



            Console.WriteLine(N - 1);
        }
    }
}
