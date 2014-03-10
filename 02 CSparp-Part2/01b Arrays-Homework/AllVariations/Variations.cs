using System;

namespace AllVariations
{
    class VariationsGenerator
    {
        // Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. 
        // Example: N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

        static void Main()
        {
            Console.Write(" Enter number N: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write(" Enter number K: ");
            int K = int.Parse(Console.ReadLine());

            int[] array = new int[K];

            Variation(array, 0, N); 
        }

        private static void Variation(int[] array, int index, int end)
        {
            if (index == array.Length)          // Recursion bottom - when index reaches array length the result is printed
            {
                Print(array);
            }
            else
            {
                for (int i = 1; i <= end; i++)
                {
                    array[index] = i;
                    Variation(array, index + 1, end);     // The recursive element increases the index with 1 on each call
                }
            }
        }

        static void Print(int[] array)
        {
            //print the array
            Console.Write("{");
            for (int i = 0; i < array.Length; i++)
            {
                if (i != (array.Length - 1))
                {
                    Console.Write("{0}, ", array[i]);
                }
                else
                {
                    Console.WriteLine("{0}{1}", array[i], "}");
                }
            }
        }
    }
}
