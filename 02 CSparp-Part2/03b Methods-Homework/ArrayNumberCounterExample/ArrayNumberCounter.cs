using System;

namespace ArrayNumberCounterExample
{
    class ArrayNumberCounter
    {
        //Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly

        static int NumberCounter(int[] array, int number)
        {
            int counter = 0;
            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] == number)
                {
                    counter++;
                }
            }
            return counter;
        }

        static void Main()
        {
            int[] inputArray = ArrayLibrary.InitializeArray(); // see methods in the project "00 ArrayLibrary"

            int number = ArrayLibrary.intInput(" Enter number: ");

            int counter = NumberCounter(inputArray, number);
            
            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));            

            if (counter > 0)
            {
                if (counter == 1)
                {
                    Console.WriteLine(" Number {0} is found once in the array", number);
                }
                else
                {
                    Console.WriteLine(" Number {0} is found {1} times in the array", number, counter);
                }
                ArrayLibrary.printArrayElements(inputArray, number);
            }
            else
            {
                Console.WriteLine(" Number {0} not found in the array", number);
                ArrayLibrary.printArray(inputArray);
            }            
        }
    }
}
