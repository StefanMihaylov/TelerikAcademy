namespace OddOrEvenExample
{
    using System;

    class Program
    {
        // Write an expression that checks if given integer is odd or even.

        static void Main()
        {
            Console.Write("\t Enter integer:");
            int checkedValue = int.Parse(Console.ReadLine());
            Console.WriteLine("\t The value {0} is {1}\n",checkedValue, checkedValue%2 != 0 ? "Odd" : "Even");
        }
    }
}
