namespace DivisibleByFiveExapmle
{
    using System;

    class DivisibleByFive
    {
        //Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

        static void Main()
        {
            uint inputA;
            while (true)
            {
                Console.Write("\t Enter first integer:");
                if (uint.TryParse(Console.ReadLine(), out inputA))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            uint inputB;
            while (true)
            {
                Console.Write("\t Enter second integer:");
                if (uint.TryParse(Console.ReadLine(), out inputB))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            if (inputA>inputB)
            {
                uint temp = inputB;
                inputB = inputA;
                inputA = temp;
            }

            int counter = 0;
            for (uint i = inputA; i <= inputB; i++)
            {
                if (i % 5 == 0)
                {
                    counter++;
                }
            }
            Console.WriteLine("\t Number of integers devided by 5 in the range [{0},{1}] is {2}", inputA, inputB,counter);
        }
    }
}
