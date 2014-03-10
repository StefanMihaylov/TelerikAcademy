using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyDwarf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load data from local HDD if program is run in VS
            //bool debugPrint = false;
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                Console.SetIn(new StreamReader(@"..\..\Input.txt"));
                //debugPrint = true;
            }

            string[] inputString = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int[] valley = new int[inputString.Length];
            for (int i = 0; i < inputString.Length; i++)
            {
                valley[i] = int.Parse(inputString[i]);
            }

            int N = int.Parse(Console.ReadLine());
            long maxCoins = long.MinValue;
            for (int i = 0; i < N; i++)
            {
                long coins = GetCoins(valley, Console.ReadLine());
                if (coins > maxCoins)
                {
                    maxCoins = coins;
                }
            }
            Console.WriteLine(maxCoins);
        }

        static long GetCoins(int[] valley, string track)
        {
            bool[] visited = new bool[valley.Length];

            string[] trackString = track.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int[] steps = new int[trackString.Length];
            for (int i = 0; i < trackString.Length; i++)
            {
                steps[i] = int.Parse(trackString[i]);
            }

            long coins = 0;
            int position = 0;
            int index = 0;
            while (true)
            {
                if ((position < 0 || position >= valley.Length) || visited[position])
                {
                    break;
                }

                coins += valley[position];
                visited[position] = true;
                position += steps[index];
                index = (index + 1) % steps.Length;
            }

            return coins;
        }
    }
}
