namespace SumOfIntsExample
{
    using System;

    class SumOfInts
    {
        // Write a program that reads 3 integer numbers from the console and prints their sum
        
        static void Main()
        {
            int countMax = 3;
            int counter = 0;
            int inputNumber;
            int sum = 0;
            Console.WriteLine();

            while (counter < countMax)
            {
                Console.Write("\t Enter {0} integer:", counter+1);
                if (int.TryParse(Console.ReadLine(), out inputNumber))
                {
                    sum += inputNumber;
                    counter++;
                }
                else 
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }
            Console.WriteLine("\t Sum is " + sum);
            Console.WriteLine();
        }
    }
}
