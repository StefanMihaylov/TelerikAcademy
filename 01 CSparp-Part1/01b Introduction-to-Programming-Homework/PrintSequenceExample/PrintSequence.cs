namespace PrintSequenceExample
{
    using System;

    class PrintSequence
    {
        // Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
        static void Main()
        {
            int startNumber = 2;
            int currentNumber;
            Console.Write("\t Sequence: ");
            
            for (int i = 0; i < 10; i++)
            {
                currentNumber = startNumber + i;
                if (currentNumber % 2 == 0)
                {
                    Console.Write("{0} ",currentNumber);
                }
                else
                {
                    Console.Write("{0} ", -1*currentNumber);
                }
            }
            Console.Write("\n\n");
        }
    }
}
