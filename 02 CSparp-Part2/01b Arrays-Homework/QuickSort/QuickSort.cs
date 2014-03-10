using System;

namespace QuickSortExample
{
    class QuickSortTest
    {
        // Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

        static void Main()
        {
            int[] array = { };
            Console.WriteLine(" \"1\" - test random array");
            Console.WriteLine(" \"2\" - test your array");
            Console.Write(" Enter your choice (1 or 2) : ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    array = RandomArray(10, -10, 10); // random array, 10 elements, from -10 to +10
                    break;
                case 2:
                    array = UserArray();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Environment.Exit(0);
                    break;
            } 

            // print choosen array
            Console.WriteLine();
            PrintAray(array);

            QuickSort(array,0,array.Length-1);

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));
            PrintAray(array);
            Console.WriteLine();
        }

        static void QuickSort(int[] array, int low, int high)
        {
            int pivot;
            if (low < high)
            {
                pivot = Partition(array, low, high);
                QuickSort(array, low, pivot - 1);
                QuickSort(array, pivot + 1, high);
            }
        }

        static int Partition(int[] array, int low, int high)
        {
            int i = low - 1;
            for (int j = low; j <= high - 1; j++)
            {
                if (array[j] <= array[high])
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, high);
            return i + 1;
        }

        static void Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        static int[] UserArray()
        {
            // initialize array enter by the user
            Console.Write("Enter number of elements: ");
            int number = int.Parse(Console.ReadLine());
            int[] tempArray = new int[number];
            for (int i = 0; i < number; i++)
            {
                Console.Write("Element [{0}] = ", i);
                tempArray[i] = int.Parse(Console.ReadLine());
            }
            return tempArray;
        }

        static void PrintAray(int[] array)
        {
            Console.Write(" Array: ");
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write("{0} ", array[index]);
            }
            Console.WriteLine();
        }

        static int[] RandomArray(int N, int minElement, int maxElement)
        {
            // Initialize random array for testing the sort algorithms
            int[] tempArray = new int[N];
            Random randomGenerator = new Random();
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = randomGenerator.Next(minElement, maxElement + 1);
            }
            return tempArray;
        }
    }
}
