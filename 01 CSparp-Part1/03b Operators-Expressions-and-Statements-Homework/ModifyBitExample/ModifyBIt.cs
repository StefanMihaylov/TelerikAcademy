namespace ModifyBitExample
{
    using System;

    class ModifyBIt
    {
        /* We are given integer number n, value v (v=0 or 1) and a position p. 
         * Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
	    Example: n = 5 (00000101), p=3, v=1 -> 13 (00001101)
	             n = 5 (00000101), p=2, v=0 -> 1 (00000001) */

        static void Main()
        {
            Console.Write("\t Enter integer number:");
            int number = int.Parse(Console.ReadLine());
            Console.Write("\t Enter bit position:");
            int position = int.Parse(Console.ReadLine());
            Console.Write("\t Enter bit value [0 or 1]:");
            int bitValue = int.Parse(Console.ReadLine());

            int mask = 1 << position;
            int result;

            if (bitValue == 0)
            {
                result = number & (~mask);
            }
            else
            {
                result = number | mask;
            }
            
            Console.WriteLine("\n\t Result: {0} ({1})",result, Convert.ToString(result, 2));
        }
    }
}
