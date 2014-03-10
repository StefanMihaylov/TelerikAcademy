using System;

namespace Combinations
{
    class Combinations
    {
        // Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. 
        // Example: N = 5, K = 2 => {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}


        static void Main()
        {
            Console.Write(" Enter number N: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write(" Enter number K: ");
            int K = int.Parse(Console.ReadLine());

            int[] array = new int[K];

            Combinat(array, 0, 1, N); 
        }

        static void Combinat(int[] array, int index, int start, int NCount)
        {
            if (index == array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = start; i <= NCount; i++)
                {
                    array[index] = i;
                    Combinat(array, index + 1, start + 1, NCount);
                    start++;
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
