

namespace Variations
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        // Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
        // Example: n=3, k=2, set = {hi, a, b} => (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)


        public static int[] array;
        public static int N;
        public static int K;

        static void Main()
        {
            Console.Write("Enter number N: ");
            N = int.Parse(Console.ReadLine());

            Console.Write("Enter number K: ");
            K = int.Parse(Console.ReadLine());

            array = new int[K];            

            GenerateVariations(0);
        }

        static void GenerateVariations(int index)
        {
            if (index >= K)
            {
                Console.WriteLine("\t ({0})", string.Join(", ", array));
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    array[index] = i;
                    GenerateVariations(index + 1);
                }
            }
        }
    }
}
