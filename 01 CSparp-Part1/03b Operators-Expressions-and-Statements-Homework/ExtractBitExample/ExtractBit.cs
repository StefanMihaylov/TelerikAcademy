

namespace ExtractBitExample
{
    using System;

    class ExtractBit
    {
        // Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2 -> value=1.
        
        static void Main()
        {
            Console.Write("\t Enter integer number:");
            int inputValue = int.Parse(Console.ReadLine());
            Console.Write("\t Enter bit position:");
            int position = int.Parse(Console.ReadLine());

            Console.WriteLine("\n\t The {0} bit of {1} ({2}) is {3}. \n",
                position, inputValue, Convert.ToString(inputValue, 2), (inputValue >> position) & 1);
        }
    }
}
