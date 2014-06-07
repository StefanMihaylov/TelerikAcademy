using System;
using System.Diagnostics;
using System.Linq;

public class AssertionsHomework
{
    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("array: [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted array: [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine();
        Console.WriteLine("value: -1000 -> result: {0}", BinarySearch(arr, -1000));
        Console.WriteLine("value: 0 -> result: {0}", BinarySearch(arr, 0));
        Console.WriteLine("value: 17 -> result: {0}", BinarySearch(arr, 17));
        Console.WriteLine("value: 10 -> result: {0}", BinarySearch(arr, 10));
        Console.WriteLine("value: 1000 -> result: {0}", BinarySearch(arr, 1000));
        Console.WriteLine();
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null.");
        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        for (int i = 0; i < arr.Length - 1; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i + 1]) < 0, "The array isn't sorted.");
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null");
        Debug.Assert(value != null, "Searched value cannot be null!");
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null.");
        Debug.Assert(startIndex >= 0, "Start index should be positive!");
        Debug.Assert(endIndex >= startIndex, "End index should be bigger than startindex!");
        Debug.Assert(endIndex < arr.Length, "End index should be smaller than the length of the array!");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null.");
        Debug.Assert(startIndex >= 0, "Start index cannot be negative!");
        Debug.Assert(endIndex >= startIndex, "End index should be bigger than start index!");
        Debug.Assert(endIndex < arr.Length, "End index should be smaller than the length of the array!");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }
}
