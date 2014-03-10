namespace PrintNumbersExample
{
    using System;

    class PrintNumbers
    {
        //Write a program that prints all the numbers from 1 to N

        static void Main()
        {
            Console.Write("\t Enter number N:");
            int number = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("\t {0}", i + 1);
            }
        }
    }
}
