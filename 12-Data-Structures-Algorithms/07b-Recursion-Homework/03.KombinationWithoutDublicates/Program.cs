
using System;

public class Program
{
    // Modify the previous program to skip duplicates: n=4, k=2 => (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)

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
                CombReps(index + 1, i + 1);
            }
        }
    }
}
