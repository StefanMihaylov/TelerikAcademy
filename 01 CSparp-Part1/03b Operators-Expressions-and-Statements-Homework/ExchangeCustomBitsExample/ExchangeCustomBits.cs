namespace ExchangeCustomBitsExample
{
    using System;

    class ExchangeCustomBits
    {
        // * Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.


        static void Main()
        {
            Console.Write("\t Enter unsigned integer number:");
            uint number = uint.Parse(Console.ReadLine());
            Console.Write("\t Enter first bit:");
            int sourceP = int.Parse(Console.ReadLine());
            Console.Write("\t Enter second bit:");
            int sourceQ = int.Parse(Console.ReadLine());
            Console.Write("\t Enter number of bits:");
            int quantity = int.Parse(Console.ReadLine());

            if (sourceP > sourceQ)
            {
                int temp = sourceQ;
                sourceQ = sourceP;
                sourceP = temp;
            }

            if ((sourceQ + quantity) <= 32 && sourceP > 0 && sourceP < 32 && sourceQ > 0 && sourceQ < 32)
            {
                Console.WriteLine("\t  Input number: {0,10} ({1})", number, Convert.ToString(number, 2).PadLeft(32, '0'));
                int result = (int)number;
                int mask = Convert.ToInt32(new string('1', quantity),2);
                int sourceAMask = mask << sourceP;
                int sourceBMask = mask << sourceQ;
                int sourceAValue = result & sourceAMask;
                int sourceBValue = result & sourceBMask;

                result &= ~(sourceAMask | sourceBMask);
                result |= (sourceAValue << (sourceQ - sourceP));
                result |= (sourceBValue >> (sourceQ - sourceP));

                Console.WriteLine("\t Output number: {0,10} ({1})", result, Convert.ToString(result, 2).PadLeft(32, '0'));
            }
            else
            {
                Console.WriteLine("\t Invalid input data");
            }
        }        
    }
}
