using System;

namespace LargestNumber
{
    class LargestNumber
    {
        // Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K

        static void UserArray(int[] array)
        {
            for (int index = 0; index < array.GetLength(0); index++)
            {
                array[index] = intInput(string.Format(" Element [{0}] = ", index));
            }
        }

        static int intInput(string text, int min, int max)
        {
            int InputValue;
            while (true)
            {
                Console.Write("{0} from {1} to {2}: ", text, min, max);
                if (int.TryParse(Console.ReadLine(), out InputValue) && InputValue >= min && InputValue <= max)
                {
                    return InputValue;
                }
                else
                {
                    Console.WriteLine("\t Invalid value! Try again!");
                }
            }
        }

        static int intInput(string text)
        {
            int InputValue;
            while (true)
            {
                Console.Write(text);
                if (int.TryParse(Console.ReadLine(), out InputValue))
                {
                    return InputValue;
                }
                else
                {
                    Console.WriteLine("\t Invalid value! Try again!");
                }
            }
        }

        static void RandomArray(int[] array, int minElement, int maxElement)
        {
            // Initialize random array
            Random randomGenerator = new Random();
            for (int index = 0; index < array.GetLength(0); index++)
            {
                array[index] = randomGenerator.Next(minElement, maxElement + 1);
            }
        }

        static void printArray(int[] array)
        {
            Console.Write(" Array:");
            for (int index = 0; index < array.GetLength(0); index++)
            {
                Console.Write(" {0}", array[index]);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            int arrayLenght = intInput(" Enter array lenght N", 1, 20);
            int[] inputArray = new int[arrayLenght];
            Console.WriteLine("  Enter \"1\" to test random array");
            Console.WriteLine("  Enter \"2\" to test your array");
            int choise = intInput("  Enter your choise", 1, 2);
            switch (choise)
            {
                case 1:
                    RandomArray(inputArray, -20, 20); // random array filled with elements from -20 to 20
                    break;
                case 2:
                    UserArray(inputArray);
                    break;
            }

            int K = intInput(" Enter number K: ");

            Array.Sort(inputArray);

            int index = Array.BinarySearch(inputArray, K);
            if (index < 0)
            {
                index = ~index - 1;
            }

            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));
            printArray(inputArray);
            
            if (index >= 0)
            {
                Console.WriteLine(" Largest element smaller or equal to {0} is {1}", K, inputArray[index]);
            }
            else
            {
                Console.WriteLine(" Element smaller or equal to {0} doesn't exist",K);
            }
            Console.WriteLine();
        }
    }
}
