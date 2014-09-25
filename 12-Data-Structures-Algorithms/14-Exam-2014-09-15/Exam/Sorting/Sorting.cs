using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sorting
{
    class Sorting
    {
        static void Main()
        {
            // Load data from local HDD if program is run in VS
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                Console.SetIn(new StreamReader(@"..\..\Test02.txt"));
            }
            var random = new Random();

            int N = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(n => int.Parse(n)).ToArray();
            int K = int.Parse(Console.ReadLine());


            int[] sortedNumbers = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                sortedNumbers[i] = numbers[i];
            }
            Array.Sort(sortedNumbers);

            bool isEqual = Compare(numbers, sortedNumbers);
            if (isEqual)
            {
                Console.WriteLine(0);
            }
            else
            {
                Swap(numbers, 0, K);
                isEqual = Compare(numbers, sortedNumbers);
                if (isEqual)
                {
                    Console.WriteLine(1);
                }
                else
                {
                    Console.WriteLine(random.Next(2, N));
                }
            }
        }

        static bool Compare(int[] numbers, int[] sorted)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != sorted[i])
                {
                    return false;
                }
            }

            return true;
        }

        static void Swap(int[] numbers, int start, int length)
        {
            for (int i = start; i < length / 2; i++)
            {
                int oldValue = numbers[i];
                numbers[i] = numbers[length - i - 1];
                numbers[length - i - 1] = oldValue;
            }
        }
    }
}
