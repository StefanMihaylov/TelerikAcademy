namespace SequenceSumExample
{
    using System;

    class SequenceSum
    {
        //Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

        static void Main()
        {
            decimal sum = 1m;
            decimal number = 2m;

            while ( (1/number).CompareTo(0.001m) >= 0 )
            {
                if (number % 2 ==0 )
                {
                  sum += 1 / number;
                }
                else
                {
                  sum -= 1 / number;
                }               
                number++;
            }
            Console.WriteLine("\t Sum is {0:f5}",sum);
        }
    }
}
