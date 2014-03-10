using System;

class SelectionSort
{
    static void Main()
    {
        int[] array = { };
        Console.Write(" Enter \"1\" to test random array or \"2\" to test your array : ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                array = RandomArray(10,-10, 10); // random array, 10 elements, from -10 to +10
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
        PrintAray(array);
        Console.WriteLine();

        int position;
        for (int i = 0; i < array.Length; i++)
        {
            position = i;
            for (int j = i+1; j < array.Length; j++)
            {
                if (array[j] < array[position]) // find minimal value in the array
                {
                    position = j;
                }
            }

            swap(array, i, position); // exchange the places of current and minimal element
        }

        // Print rresult
        Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));
        PrintAray(array);
        Console.WriteLine();
    }
    
    static void swap(int[] array, int i, int position)
    {
        // exchange the places of current and minimal element
        int tempNumber = array[i];  
        array[i] = array[position];
        array[position] = tempNumber;
    }


    static int[] RandomArray(int N, int minElement, int maxElement)
    {
        // Initializ random array for testing the sort algorithms
        int[] tempArray = new int[N];
        Random randomGenerator = new Random();
        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = randomGenerator.Next(minElement, maxElement + 1);
        }
        return tempArray;
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


