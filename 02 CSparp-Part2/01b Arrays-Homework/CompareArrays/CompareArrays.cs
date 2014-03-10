using System;

namespace CompareArrays
{
    class CompareArrays
    {
        // Write a program that reads two arrays from the console and compares them element by element

        static void Main()
        {
            
            Console.Write("\t Enter number of elements: ");
            int numberOfElements = int.Parse(Console.ReadLine());

            int[] array1 = new int[numberOfElements];
            int[] array2 = new int[numberOfElements];
            int inputNumber;
            
            // read first and second array
            for (int variant = 1; variant <=2 ; variant++)
            {
                Console.WriteLine("\t Elements of array {0}:",variant);
                for (int index = 0; index < numberOfElements; index++)
                {
                    Console.Write("\t Array[{0}] = ",index);
                    inputNumber = int.Parse(Console.ReadLine());

                    if (variant == 1)
                    {
                        array1[index] = inputNumber;
                    }
                    else
                    {
                        array2[index] = inputNumber;
                    }
                }                
            }

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));            
            string resultSign="";
            bool isEqual = true;
            for (int index = 0; index < numberOfElements; index++)
            {
                if (array1[index] == array2[index])
                {
                    resultSign = "=";                    
                }
                else if (array1[index] > array2[index])
                {
                    resultSign = ">";
                    isEqual = false;
                }
                else
                {
                    resultSign = "<";
                    isEqual = false;
                }
                Console.WriteLine("\t Array1[{0}]={1} {3} Array2[{0}]={2}", index, array1[index], array2[index], resultSign);
            }
            Console.WriteLine("\t Two arrays are{0} equal",isEqual?"":" not");
            Console.WriteLine();
        }
    }
}
