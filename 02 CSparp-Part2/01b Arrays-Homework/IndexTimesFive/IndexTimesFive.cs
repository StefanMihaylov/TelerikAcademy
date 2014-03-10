using System;

namespace IndexTimesFive
{
    class IndexTimesFive
    {
        // Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console

        static void Main()
        {
            int[] arrayOfNumbers = new int[20];

            // array initialization
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                arrayOfNumbers[i] = i * 5;
            }

            // array printing
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));  
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                Console.WriteLine("\t Number {0,2} = {1}",i,arrayOfNumbers[i]);
            }        
        }
    }
}
