using System;

namespace SortArrayMethodExample
{
    class SortArrayMethod
    {
        // Write a method that return the maximal element in a portion of array of integers starting at given index. Using it write another method that sorts an array in ascending / descending order.

        static int IndexOfMax(int[] array, int startIndex, int endIndex)
        {
            int index = startIndex;
            int element = array[startIndex];
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (array[i] > element)
                {
                    element = array[i];
                    index = i;
                }
            }
            return index;
        }

        static void SortDescending(int[] array)
        {
            int temporary;
            int maxIndex;
            for (int index = 0; index < array.Length; index++)
            {
                maxIndex = IndexOfMax(array, index, array.Length - 1);
                temporary = array[index];
                array[index] = array[maxIndex];
                array[maxIndex] = temporary;
            }
        }

        static void SortAscending(int[] array)
        {
            int temporary;
            int maxIndex;
            for (int index = array.Length - 1; index >= 0; index--)
            {
                maxIndex = IndexOfMax(array, 0, index);
                temporary = array[index];
                array[index] = array[maxIndex];
                array[maxIndex] = temporary;
            }
        }

        static void Main()
        {
            int[] inputArray = ArrayLibrary.InitializeArray();
            ArrayLibrary.printArray(inputArray);

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20)); 
            Console.WriteLine(" Array sorted in descending order");
            SortDescending(inputArray);
            ArrayLibrary.printArray(inputArray);

            Console.WriteLine();
            Console.WriteLine(" Array sorted in ascending order");
            SortAscending(inputArray);
            ArrayLibrary.printArray(inputArray);
        }
    }
}
