using System;

namespace MergeSort
{
    class MergeSort
    {
        static void Main()
        {
            // * Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).
            //      http://www.softwareandfinance.com/CSharp/MergeSort_Recursive.html

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
            
            MergeSort_Recursive(array, 0, array.Length - 1);

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));
            PrintAray(array);
            Console.WriteLine();
        }

        static public void MergeSort_Recursive(int[] numbers, int left, int right)
        {
            if (right > left)
            {
                int mid = (right + left) / 2;
                MergeSort_Recursive(numbers, left, mid);
                MergeSort_Recursive(numbers, (mid + 1), right);

                DoMerge(numbers, left, (mid + 1), right);
            }
        }

        static public void DoMerge(int[] numbers, int left, int mid, int right)
        {
            int[] tempArray = new int[numbers.Length];

            int left_end = (mid - 1);
            int tmp_pos = left;
            int num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                {
                    tempArray[tmp_pos] = numbers[left];
                    tmp_pos++;
                    left++;
                }
                else
                {
                    tempArray[tmp_pos] = numbers[mid];
                    tmp_pos++;
                    mid++;
                }                    
            }

            while (left <= left_end)
            {
                tempArray[tmp_pos] = numbers[left];
                tmp_pos++;
                left++;
            }
            while (mid <= right)
            {
                tempArray[tmp_pos] = numbers[mid];
                tmp_pos++;
                mid++;
            }

            for (int i = 0; i < num_elements; i++)
            {
                numbers[right] = tempArray[right];
                right--;
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
