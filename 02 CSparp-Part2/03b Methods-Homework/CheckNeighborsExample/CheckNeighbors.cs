using System;

namespace CheckNeighborsExample
{
    public class CheckNeighbors
    {
        // Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

        public static int SmallerNeighbors(int[] array, int index)
        {
            if ((index <= 0) || (index >= array.Length - 1))
            {
                return -1;
            }
            else if ((array[index - 1] < array[index]) && (array[index] > array[index + 1]))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static void Main()
        {
            int[] inputArray = ArrayLibrary.InitializeArray();            

            int index = ArrayLibrary.intInput(" Enter element index", 0, inputArray.Length - 1); 

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));
            ArrayLibrary.printArrayIndex(inputArray, index);

            int result = SmallerNeighbors(inputArray, index);
            if (result == 1)
            {
                Console.WriteLine(" The chosen element is bigger than two neighbors!");
            }
            else if (result == 0)
            {
                Console.WriteLine(" The chosen element isn't bigger than two neighbors!");
            }
            else
            {
                Console.WriteLine(" The chosen element doesn't have two neighbors!");
            }            
        }
    }
}
