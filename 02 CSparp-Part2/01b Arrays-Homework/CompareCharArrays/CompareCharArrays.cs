using System;

namespace CompareCharArrays
{
    class CompareCharArrays
    {
        // Write a program that compares two char arrays lexicographically (letter by letter)

        static void Main()
        {     
            Console.Write(" Enter elements of  first array as string: ");
            string firstInputData = Console.ReadLine();
            Console.Write(" Enter elements of second array as string: ");
            string secondInputData = Console.ReadLine();

            char[] firstArray = firstInputData.ToCharArray();
            char[] SecondArray = secondInputData.ToCharArray();

            bool isDifferent = false;
            int minLenght = Math.Min(firstArray.Length, SecondArray.Length);

            // compare letter by letter
            for (int index = 0; index < minLenght; index++)
            {
                if (firstArray[index] != SecondArray[index])
                {
                    isDifferent = true;
                }
            }

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));     

            if (isDifferent)
            {
                Console.WriteLine(" Two arrays are different");
            }
            else if (firstArray.Length > SecondArray.Length)
            {
                // all elements of second array are equal to first elements of first array, but first array is longer
                Console.WriteLine(" Second array is smaller"); 
            }
            else if (firstArray.Length < SecondArray.Length)
            {
                // all elements of first array are equal to second elements of second array, but second array is longer
                Console.WriteLine(" First array is smaller"); 
            }
            else
            {
                Console.WriteLine(" Two arrays are equal");
            }
            Console.WriteLine();
        }
    }
}
