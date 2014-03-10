using System;

namespace MaxEqualInArray
{
    class MaxEqualInArray
    {
        // Write a program that finds the maximal sequence of equal elements in an array.
		// Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.
        
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;

            int[] defaultArray = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
            int[] array = {};

            Console.Write("Enter \"1\" to test default array or \"2\" to test your array : ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    array = defaultArray;
                    break;
                case 2:
                    Console.Write("Enter number of elements: ");
                    int number = int.Parse(Console.ReadLine());
                    int[] userArray = new int[number];
                    for (int i = 0; i < number; i++)
                    {
                        Console.Write("Element [{0}] = ",i);
                        userArray[i] = int.Parse(Console.ReadLine());
                    }
                    array = userArray;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Environment.Exit(0);
                    break;
            }

            // print array
            Console.WriteLine();
            Console.Write(" Array: ");
            for (int index = 0; index < array.Length; index++)
			{
			    Console.Write("{0} ",array[index]);
			}
            Console.WriteLine();
            
            int startPosition = 0;
            int startElement = array[0]; // first element
            int numberOfElements = 1;

            int maxSequenceStart = startPosition;
            int maxSequenceLenght = numberOfElements;

            for (int index = 1; index < array.Length; index++)
            {
                if (array[index] == startElement)
                {
                    numberOfElements++;
                }
                else
                {
                    startElement = array[index];
                    if (numberOfElements > maxSequenceLenght)
                    {
                        maxSequenceLenght = numberOfElements;
                        maxSequenceStart = startPosition;
                    }
                    numberOfElements = 1;
                    startPosition = index;
                }
            }

            // check if last element is part of the sequence 
            if (numberOfElements > maxSequenceLenght)
            {
                maxSequenceLenght = numberOfElements;
                maxSequenceStart = startPosition;
            }

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));
            if (maxSequenceLenght == 1)
            {
                Console.WriteLine(" Sequence not found");
            }
            else
            {
                Console.Write(" Sequence is highlighted in ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("yellow");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Array: ");
                for (int index = 0; index < array.Length; index++)
                {
                    if (index >= maxSequenceStart && index < (maxSequenceStart + maxSequenceLenght))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write("{0} ", array[index]);
                }
             }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
