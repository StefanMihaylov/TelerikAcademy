using System;

// library with some methods used in the homework

public class ArrayLibrary
{
    public static void RandomArray(int[] array, int minElement, int maxElement)
    {
        // Initialize random array
        Random randomGenerator = new Random();
        for (int index = 0; index < array.GetLength(0); index++)
        {
            array[index] = randomGenerator.Next(minElement, maxElement + 1);
        }
    }

    public static void UserArray(int[] array)
    {
        // initialize array entered by the user
        for (int index = 0; index < array.GetLength(0); index++)
        {
            array[index] = intInput(string.Format(" Element [{0}] = ", index));
        }
    }

    public static int intInput(string text, int min, int max)
    {
        // integer in the preset range, entered by the user 
        int InputValue;
        while (true)
        {
            Console.Write("{0} from {1} to {2}: ", text, min, max);
            if (int.TryParse(Console.ReadLine(), out InputValue) && InputValue >= min && InputValue <= max)
            {
                return InputValue;
            }
            else
            {
                Console.WriteLine("\t Invalid value! Try again!");
            }
        }
    }

    public static int intInput(string text)
    {
        // integer, entered by the user (overload of the previous method)
        int InputValue;
        while (true)
        {
            Console.Write(text);
            if (int.TryParse(Console.ReadLine(), out InputValue))
            {
                return InputValue;
            }
            else
            {
                Console.WriteLine("\t Invalid value! Try again!");
            }
        }
    }

    public static void printArrayIndex(int[] array, int elementIndex)
    {
        // print array on the console and highlight the preset element in yellow
        Console.Write(" Number is highlighted in ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("yellow");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.Write(" Array:");
        for (int index = 0; index < array.GetLength(0); index++)
        {
            if (index == elementIndex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.Write(" {0}", array[index]);
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();
    }

    public static void printArrayElements(int[] array, int element)
    {
        // print array on the console and highlight the preset element in yellow
        Console.Write(" Number is highlighted in ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("yellow");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.Write(" Array:");
        for (int index = 0; index < array.GetLength(0); index++)
        {
            if (array[index] == element)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.Write(" {0}", array[index]);
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();
    }

    public static void printArray(int[] array)
    {
        // print array on the console, no highlighting
        Console.Write(" Array:");
        for (int index = 0; index < array.GetLength(0); index++)
        {
            Console.Write(" {0}", array[index]);
        }
        Console.WriteLine();
    }

    public static void printArray(char[] array)
    {
        // print char array on the console, no highlighting
        Console.Write(" Array:");
        for (int index = 0; index < array.GetLength(0); index++)
        {
            Console.Write(" {0}", array[index]);
        }
        Console.WriteLine();
    }

    public static int[] InitializeArray()
    {
        // choose initializing method
        int arrayLength = ArrayLibrary.intInput(" Enter array length", 1, 25);
        int[] array = new int[arrayLength];

        Console.WriteLine("  Enter \"1\" to test random array");
        Console.WriteLine("  Enter \"2\" to test your array");
        int choise = ArrayLibrary.intInput("  Enter your choise", 1, 2);
        switch (choise)
        {
            case 1:
                ArrayLibrary.RandomArray(array, -10, 10); // random array filled with elements from -10 to 10
                break;
            case 2:
                ArrayLibrary.UserArray(array);
                break;
        }
        return array;
    }
}


