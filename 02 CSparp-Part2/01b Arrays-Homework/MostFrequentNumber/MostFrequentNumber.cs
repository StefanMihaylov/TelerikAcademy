using System;

namespace MostFrequentNumber
{
    class MostFrequentNumber
    {
        // Write a program that finds the most frequent number in an array. Example:
	    // {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)

        static void Main()
        {
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
                    array = new int []{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3};
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

            int maxCounter = 0;
            int maxElement = 0;
            int currentCounter;
            for (int i = 0; i < array.Length - 1; i++)
            {
                currentCounter = 1;
                for (int j = i + 1; j < array.Length; j++)
			    {
                    if (array[i] == array[j])
                    {
                        currentCounter++;
                    }
			    }
                if (currentCounter > maxCounter)
                {
                    maxCounter = currentCounter;
                    maxElement = array[i];
                }
            }

            if (maxCounter > 1)
            {
                Console.WriteLine(" Most frequent number is {0}, found {1} times", maxElement, maxCounter);
            }
            else
            {
                Console.WriteLine(" All elements are different ");
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
    }
}
