namespace ReverseIntegers
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        /* Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class. */

        public static void Main()
        {
            // TODO: Add input validation

            Stack<int> numbers = new Stack<int>();            

            Console.Write("Enter positive number. Please, don't enter strings:  "); 
            int numbersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersCount; i++)
            {
                Console.Write("Enter number: ");
                int number = int.Parse(Console.ReadLine());
                numbers.Push(number);
            }

            Console.Write(" Reversed Numbers: ");
            while (numbers.Count > 0)
            {
                Console.Write("{0}{1} ", numbers.Pop(), numbers.Count > 0 ? ',' : ' ');
            }
            Console.WriteLine();
        }
    }
}
