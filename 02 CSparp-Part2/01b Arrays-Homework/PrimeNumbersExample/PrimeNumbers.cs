using System;

namespace PrimeNumbersExample
{
    class PrimeNumbers
    {
        // Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

        static void Main()
        {
            int maxNumber = 10000000;
            bool[] table = new bool[maxNumber];


            int sqrtNumber = (int)Math.Sqrt(table.Length);
            for (int i = 2; i < sqrtNumber; i++)
            {
                if (table[i] == false)
                {
                    for (int j = 2 * i; j < table.Length; j+=i)
                    {
                        table[j] = true; // set all bits that are devided by "i"
                    }
                }
            }

            // print result
            int print = 1000;
            Console.WriteLine(" Prime numbers form 2 to {0}:", print);
            int counter = 0;            
            for (int i = 2; i < table.Length; i++)
            {
                if (table[i] == false)
                {
                    counter++;
                    // print 1000 prime numbers only, just to check for errors. I don't need to know all 664579 prime numbers
                    if (i < print) Console.Write("{0,3}  ", i);
                }
            }           
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" There are {1} prime numbers form 2 to {0}", maxNumber, counter);            
        }
    }
}
