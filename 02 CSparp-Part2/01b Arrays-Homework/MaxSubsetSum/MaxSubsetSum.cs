using System;

namespace MaxSubsetSum
{
    class MaxSubsetSum
    {
        static void Main()
        {
            // Write a program that finds the sequence of maximal sum in given array. Example:
	        // {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
	        // Can you do it with only one loop (with single scan through the elements of the array)?


            int[] array = { };
            Console.WriteLine(" \"1\" - test random array");
            Console.WriteLine(" \"2\" - test default array");
            Console.WriteLine(" \"3\" - test your array");
            Console.Write(" Enter your choice (1, 2 or 3) : ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    array = RandomArray(10, -10, 10); // random array, 10 elements, from -10 to +10
                    break;
                case 2:
                    array = new int[] {2, 3, -6, -1, 2, -1, 6, 4, -8, 8};
                    break;
                case 3:
                    array = UserArray();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Environment.Exit(0);
                    break;
            }

            // print choosen array
            Console.WriteLine();
            PrintAray(array);
            Console.WriteLine();

            // first algorithm - brutal force
            int sum=0;
            int maxSum = int.MinValue;
            int minLenght = int.MaxValue;
            int start = 0;
            int lenght = 1;
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
                    if ((maxSum < sum) || ((maxSum == sum) && (lenght < minLenght)))
                    {
                        maxSum = sum;
                        start = i;
                        minLenght = lenght;
                    }
                }
            }

            // Second algorithm - http://www.sysexpand.com/?path=exercises/maximum-subarray
            
            int sequenceStart = 0;
            int sequenceLenght = 1;
            int maxSequenceSum = array[0];
          
            int currentSum = array[0];
            int currentStart = 0;
            int currentLenght = 1;

            for (int index = 1; index < array.Length; index++)
            {
                if (array[index] >= currentSum + array[index])  
                {
                    // new sum is smaller than the old one => restart the sequence
                    currentSum = array[index];
                    currentStart = index;
                    currentLenght = 1;                    
                }
                else
                {
                    // add new member in the sequence
                    currentLenght++;
                    currentSum += array[index];
                }

                if ((currentSum > maxSequenceSum) || (currentSum == maxSequenceSum && currentLenght < sequenceLenght))
                {
                    sequenceStart = currentStart;
                    maxSequenceSum = currentSum;
                    sequenceLenght = currentLenght;
                }
            }

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));
            Console.Write(" Maximal sum is {0}.",maxSum);
            PrintArayColour(array, start, minLenght);
            Console.WriteLine();

            Console.WriteLine(" Second algorithm");
            Console.Write(" Maximal sum is {0}.", maxSequenceSum);
            PrintArayColour(array, sequenceStart, sequenceLenght);
            Console.WriteLine();
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
            Console.Write(" Sequence is highlighted in ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("yellow");
            Console.ForegroundColor = ConsoleColor.Gray;
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
