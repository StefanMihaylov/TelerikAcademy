namespace CheckBitExample
{
    using System;

    class CheckBit
    {
        // Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

        static void Main()
        {
            int inputValue = 123; //or 23

            int position = 3;
            int mask = 1 << position;
            bool outputValue = (inputValue & mask) != 0;
            Console.WriteLine("\n\t The third bit of {0} is {1}. \n",Convert.ToString(inputValue,2),outputValue ? "1" : "0");
        }
    }
}
