namespace VariationWithoutDublicates
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        // Write a program for generating and printing all subsets of k strings from given set of strings.
        // Example: s = {test, rock, fun}, k=2 (test rock), (test fun), (rock fun)

        public static int[] array;
        public static bool[] used;
        public static int N;
        public static int K;

        public static string[] items = { "test", "rock", "fun" };

        static void Main()
        {
            //Console.Write("Enter number N: ");
            //N = int.Parse(Console.ReadLine());
            N = items.Length;

            //Console.Write("Enter number K: ");
            // K = int.Parse(Console.ReadLine());
            K = 2;
            array = new int[K];
            used = new bool[N];

            CombReps(0, 0);
        }

        // similar to tast 3
        static void CombReps(int index, int start)
        {
            if (index >= K)
            {
                Console.Write("\t ( ");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(items[array[i]] + " ");
                }
                Console.WriteLine(")");
            }
            else
            {
                for (int i = start; i < N; i++)
                {
                    array[index] = i;
                    CombReps(index + 1, i + 1);
                }
            }
        }
    }
}
