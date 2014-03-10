using System;

namespace GivenSubsetSum
{
    class GivenSubsetSum
    {
        // Write a program that finds in given array of integers a sequence of given sum S (if present). 
        // Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}

        static void Main()
        {
            int[] array = { };
            int subsetSum = 0;
            Console.WriteLine(" \"1\" - test default array and sum");
            Console.WriteLine(" \"2\" - test your array");
            Console.Write(" Enter your choice (1 or 2) : ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    array = new int[] { 4, 3, 1, 4, 2, 5, 8 };
                    subsetSum = 11;
                    break;
                case 2:
                    array = UserArray();
                    Console.Write(" Enter subsequence sum :");
                    subsetSum = int.Parse(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Environment.Exit(0);
                    break;
            }

            // print choosen array
            Console.WriteLine();
            PrintAray(array);
            Console.WriteLine(" Subsequence sum is {0}.", subsetSum);
            Console.WriteLine();

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));

            int sum;
            int lenght;
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    sum = 0;
                    lenght = 0;
                    for (int index = i; index <= j; index++)
                    {
                        sum += array[index];
                        lenght++;
                    }
                    if (sum == subsetSum) 
                    {
                        PrintArayColour(array, i, lenght);
                        result++;
                    }
                }
            }
            if (result == 0)
            {
                Console.WriteLine(" No subsequence with sum = {0}",subsetSum);
            }
        }

        static int[] RandomArray(int N, int minElement, int maxElement)
        {
            // Initialize random array for testing the sort algorithms
            int[] tempArray = new int[N];
            Random randomGenerator = new Random();
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = randomGenerator.Next(minElement, maxElement + 1);
            }
            return tempArray;
        }

        static int[] UserArray()
        {
            // initialize array enter by the user
            Console.Write("Enter number of elements: ");
            int number = int.Parse(Console.ReadLine());
            int[] tempArray = new int[number];
            for (int i = 0; i < number; i++)
            {
                Console.Write("Element [{0}] = ", i);
                tempArray[i] = int.Parse(Console.ReadLine());
            }
            return tempArray;
        }

        static void PrintAray(int[] array)
        {
            Console.Write(" Array: ");
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write("{0} ", array[index]);
            }
            Console.WriteLine();
        }

        static void PrintArayColour(int[] array, int start, int lenght)
        {
            Console.Write(" Array: ");
            for (int index = 0; index < array.Length; index++)
            {
                if (index >= start && index < start + lenght)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.Write("{0} ", array[index]);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
    }
}
