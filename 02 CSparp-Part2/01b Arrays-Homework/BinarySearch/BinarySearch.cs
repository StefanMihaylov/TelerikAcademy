using System;

namespace BinarySearch
{
    class BinarySearch
    {
        // Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia). http://www.youtube.com/watch?v=wNVCJj642n4

        static void Main()
        {
            int[] array = UserArray();
            Console.Write(" Enter number for searching: ");
            int number = int.Parse(Console.ReadLine());

            Array.Sort(array);
            // print choosen array
            Console.WriteLine();
            PrintAray(array);

            // binary search
            int low = 0;
            int high = array.Length - 1;
            while (low + 1 < high)
            {
                int test = (high + low) / 2;
                if (array[test] > number)
                {
                    high = test;
                }
                else
                {
                    low = test;
                }
            }

            if (array[low] == number)
            {
                Console.WriteLine(" Number:{0} => Index:{1}", number, low);
            }
            else if (array[high] == number)
            {
                Console.WriteLine(" Number:{0} => Index:{1}", number, high);
            }
            else
            {
                Console.WriteLine(" {0} doesn't exist in the array", number);
            }
           
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
    }
}
