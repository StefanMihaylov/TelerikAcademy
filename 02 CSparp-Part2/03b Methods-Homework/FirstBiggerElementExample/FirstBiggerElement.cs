using System;

namespace FirstBiggerElementExample
{
    class FirstBiggerElement
    {
        // Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element. Use the method from the previous exercise

        static int FirstBigger(int[] array)
        {
            for (int index = 0; index < array.Length; index++)
            {
                if (CheckNeighborsExample.CheckNeighbors.SmallerNeighbors(array, index) == 1) // exersise #05
                {
                    return index;
                }
            }
            return -1;
        }

        static void Main()
        {
            int[] inputArray = ArrayLibrary.InitializeArray(); 

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));
            int index = FirstBigger(inputArray);
            if (index >= 0)
            {
                Console.WriteLine(" First element bigger than two neighbors found");
                ArrayLibrary.printArrayIndex(inputArray, index);
            }
            else
            {
                Console.WriteLine(" Element bigger than two neighbors not found");
                ArrayLibrary.printArray(inputArray);
            }            
        }
    }
}
