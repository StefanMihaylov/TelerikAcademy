using System;
using System.Collections.Generic;

public class Program
{
    // Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n. Example: n=3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3},	{2, 3, 1}, {3, 1, 2},{3, 2, 1}

    public static int N;

    public static void Main()
    {
        Console.Write("Enter number N: ");
        N = int.Parse(Console.ReadLine());

        int[] array = new int[N];

        // fill the data
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i + 1;
        }

        Permutations(array, 0);
    }

    private static void Permutations<T>(IList<T> collection, int index)
    {
        if (index >= collection.Count)
        {
            Console.WriteLine("\t ({0})", string.Join(", ", collection));
        }
        else
        {
            Permutations(collection, index + 1);
            for (int i = index + 1; i < collection.Count; i++)
            {
                Swap(collection, index, i);
                Permutations(collection, index + 1);
                Swap(collection, index, i);
            }
        }
    }

    private static void Swap<T>(IList<T> collection, int fromIndex, int toIndex)
    {
        T oldElement = collection[fromIndex];
        collection[fromIndex] = collection[toIndex];
        collection[toIndex] = oldElement;
    }
}

