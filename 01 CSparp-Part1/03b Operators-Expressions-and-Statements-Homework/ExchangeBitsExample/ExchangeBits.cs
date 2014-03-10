namespace ExchangeBitsExample
{
    using System;

    class ExchangeBits
    {
        // Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer

        static void Main()
        {
            Console.Write("\t Enter unsigned integer number:");
            uint number = uint.Parse(Console.ReadLine());
            Console.WriteLine("\t  Input number: {0,10} ({1})", number, Convert.ToString(number, 2).PadLeft(32,'0'));

            uint sourceAMask = (uint)(7 << 3);
            uint sourceBMask = (uint)(7 << 24);
            uint sourceAValue = number & sourceAMask;
            uint sourceBValue = number & sourceBMask;

            number &= ~(sourceAMask | sourceBMask);
            number |= (sourceAValue << 21);
            number |= (sourceBValue >> 21);

            Console.WriteLine("\t Output number: {0,10} ({1})", number, Convert.ToString(number, 2).PadLeft(32, '0'));
        }
    }
}
