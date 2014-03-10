namespace CheckBitInPositionExample
{
    using System;

    class CheckBitInPosition
    {
        // Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. Example: v=5; p=1 -> false

        static void Main()
        {
            Console.Write("\t Enter integer number:");
            int inputValue = int.Parse(Console.ReadLine());
            Console.Write("\t Enter bit position:");
            int position = int.Parse(Console.ReadLine());
            
            int mask = 1 << position;
            bool outputValue = (inputValue & mask) != 0;

            Console.WriteLine("\n\t Is the {0} bit of {1} equal to 1? -> {2} \n",
                position, Convert.ToString(inputValue, 2),outputValue);
        }
    }
}
