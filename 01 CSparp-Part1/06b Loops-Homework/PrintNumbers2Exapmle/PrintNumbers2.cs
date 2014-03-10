namespace PrintNumbers2Exapmle
{
    using System;

    class PrintNumbers2
    {
        // Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time

        static void Main(string[] args)
        {
            Console.Write("\t Enter number N:");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (i % 3 != 0 || i % 7 != 0)
                {
                    Console.WriteLine("\t {0}", i);
                }                
            }
        }
    }
}