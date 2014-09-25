namespace KombinationWithDublicates
{
    using System;

    class Program
    {
        // Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set. Example: n=3, k=2 -> (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)

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

            CombReps(0, 1);
        }

        static void CombReps(int index, int start)
        {
            if (index >= K)
            {
                Console.WriteLine("\t ({0})", string.Join(", ", array));
            }
            else
            {
                for (int i = start; i <= N; i++)
                {
                    array[index] = i;
                    CombReps(index + 1, i);
                }
            }
        }
    }
}
