using System;

namespace SubsetSum
{
    class SubsetSum
    {
        // Write a program that reads two integer numbers N and K and an array of N elements from the console. Find in the array those K elements that have maximal sum.

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter number of elements N: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Enter number of elements K: ");
            int K = int.Parse(Console.ReadLine());
            if (K>=N)
            {
                Console.WriteLine("Incorrect input");
                Environment.Exit(0);
            }

            Console.WriteLine("Enter array of {0} elements:",N);
            int[] userArray = new int[N];
            for (int i = 0; i < N; i++)
            {
                Console.Write("Element [{0}] = ", i);
                userArray[i] = int.Parse(Console.ReadLine());
            }

            // print array
            Console.WriteLine();
            Console.Write(" Array: ");
            for (int index = 0; index < userArray.Length; index++)
            {
                Console.Write("{0} ", userArray[index]);
            }
            Console.WriteLine();


            int startPosition = 0;
            int currentSum = 0;
            int maxSequenceStart = startPosition;
            int maxSequenceSum = currentSum;

            for (int index = 0; index < N; index++)
            {
                if (index < K)  // calculate the sum of first K elements
                {
                    currentSum += userArray[index];
                    if (index == (K - 1))
                    {
                        maxSequenceSum = currentSum;
                    } 
                }
                else            // check if the sum of next sequence is larger
                {
                    currentSum = currentSum - userArray[index - K] + userArray[index];
                    if (currentSum > maxSequenceSum)
                    {
                        maxSequenceSum = currentSum;
                        maxSequenceStart = index - K + 1;
                    }
                }
            }

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));
            Console.Write(" Maximal sum is {0}. Sequence is highlighted in ",maxSequenceSum);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("yellow");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(" Array: ");
            for (int index = 0; index < userArray.Length; index++)
            {
                if (index >= maxSequenceStart && index < (maxSequenceStart + K))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("{0} ", userArray[index]);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
