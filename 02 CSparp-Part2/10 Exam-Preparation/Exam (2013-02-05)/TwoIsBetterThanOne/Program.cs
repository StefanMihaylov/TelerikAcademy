using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoIsBetterThanOne
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

            // problem 1
            string[] inputProblem1 = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            long[] limits = new long[inputProblem1.Length];
            for (int i = 0; i < inputProblem1.Length; i++)
            {
                limits[i] = long.Parse(inputProblem1[i]);
            }

            Console.WriteLine(HappyNumbers(limits[0], limits[1]));


            // problem 2
            string[] inputProblem2 = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<int> numbers = new List<int>(inputProblem2.Length);
            for (int i = 0; i < inputProblem2.Length; i++)
            {
                numbers.Add(int.Parse(inputProblem2[i]));
            }

            int persentage = int.Parse(Console.ReadLine());

            numbers.Sort();
            decimal realIndex = numbers.Count * persentage / 100.0m;
            int index = (int)(numbers.Count * (persentage / 100.0));
            if (persentage != 0)
            {
                if (realIndex == index)
                {
                    Console.WriteLine(numbers[index - 1]);
                }
                else
                {
                    Console.WriteLine(numbers[index]);
                }
            }
            else
            {
                Console.WriteLine(numbers[0]);
            } 

            // Console.WriteLine(FindElementFromSecondTask(numbers, persentage));
        }

        private static int FindElementFromSecondTask(List<int> numbers, int percentile) // autor
        {
            numbers.Sort();

            for (int i = 0; i < numbers.Count; i++)
            {
                // int countOfSmallerOrEqualNumber = numbers.Count(t => numbers[i] >= t);
                int countOfSmallerOrEqualNumber = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[i] >= numbers[j])
                    {
                        countOfSmallerOrEqualNumber++;
                    }
                }

                if (countOfSmallerOrEqualNumber >= numbers.Count * (percentile / 100.0))
                {
                    return numbers[i];
                }
            }

            return numbers[numbers.Count - 1];
        }

        static bool IsPalidrom(long input)
        {
            string number = input.ToString();

            for (int index = 0; index < number.Length / 2; index++)
            {
                if (number[index] != number[number.Length - index - 1])
                {
                    return false;
                }
            }
            return true;
        }

        static long HappyNumbers(long minLimit, long maxLimit)
        {
            long maxNumber = (long)Math.Pow(10, 18);

            List<long> numbers = new List<long>() { 3, 5 };
            int left = 0;

            //   while (numbers[numbers.Count - 1] < maxLimit)
            while (left < numbers.Count)
            {
                int right = numbers.Count;
                for (int i = left; i < right; i++)
                {
                    if (numbers[i] <= maxNumber)
                    {
                        numbers.Add(numbers[i] * 10 + 3);
                        numbers.Add(numbers[i] * 10 + 5);
                    }
                }
                left = right;
            }

            long counter = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= minLimit && numbers[i] <= maxLimit && IsPalidrom(numbers[i]))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
