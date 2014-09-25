namespace NestedLoops
{
    using System;

    public class Program
    {
        // 01. Write a recursive program that simulates the execution of n nested loops from 1 to n

        public static int[] array;
        public static int N;

        public static void Main()
        {
            Console.Write("Enter number of nested loops: ");
            N = int.Parse(Console.ReadLine());

            array = new int[N];

            GenerateAllStates(0);
        }

        private static void GenerateAllStates(int index)
        {
            if (index >= N)
            {
                Console.WriteLine("\t {0}",string.Join(", ", array));
                return;
            }

            for (int i = 1; i <= N; i++)
            {
                array[index] = i;
                GenerateAllStates(index + 1);
            }
        }
    }
}
