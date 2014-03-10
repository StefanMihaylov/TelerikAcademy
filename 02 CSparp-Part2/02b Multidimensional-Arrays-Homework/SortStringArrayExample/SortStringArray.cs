using System;

namespace SortStringArrayExample
{
    class SortStringArray
    {
        // You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).

        static void UserArray(string[] array)
        {
            for (int index = 0; index < array.GetLength(0); index++)
            {
                Console.Write(" Element [{0}] = ", index);
                array[index] = Console.ReadLine();
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

        static void RandomArray(string[] array, int minElement, int maxElement)
        {
            // Initialize random array
            Random randomGenerator = new Random();
            for (int index = 0; index < array.GetLength(0); index++)
            {
                char character = (char)randomGenerator.Next(97, 123);  // characters from 'a' to 'z'
                array[index] = new string(character, randomGenerator.Next(minElement, maxElement + 1));
            }
        }

        static void printArray(string[] array)
        {
            for (int index = 0; index < array.GetLength(0); index++)
            {
                Console.WriteLine("{0}", array[index]);
            }
        }

        static void StringArraySort(string[] array)
        {
            string temp;
            int minLenghtIndex;
            int minLenght;
            for (int index = 0; index < array.Length-1; index++)
            {
                minLenght = array[index].Length;
                minLenghtIndex = index;
                for (int search = index+1; search < array.Length; search++)
                {
                    if (array[search].Length < minLenght)
                    {                        
                        minLenght = array[search].Length;
                        minLenghtIndex = search;
                    }
                }
                temp = array[index];
                array[index] = array[minLenghtIndex];
                array[minLenghtIndex] = temp;
            }
        }

        static void Main()
        {
            int arrayLenght = intInput(" Enter array lenght N", 1, 20);
            string[] inputArray = new string[arrayLenght];
            Console.WriteLine("  Enter \"1\" to test random array");
            Console.WriteLine("  Enter \"2\" to test your array");
            int choise = intInput("  Enter your choise", 1, 2);
            switch (choise)
            {
                case 1:
                    RandomArray(inputArray, 1, 30); // random array filled with elements from 1 to 30 in lenght
                    break;
                case 2:
                    UserArray(inputArray);
                    break;
            }
            Console.WriteLine();
            Console.WriteLine(" Array:");
            printArray(inputArray);
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));

            StringArraySort(inputArray);

            Console.WriteLine(" Sorted array:");
            printArray(inputArray);
            Console.WriteLine();
        }
    }
}
