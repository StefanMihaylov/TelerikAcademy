namespace IsPrimeExample
{
    using System;

    class IsPrime
    {
        // Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime 

        static void Main()
        {
            Console.Write("\n\t Enter integer between 2 and 100:");
            int inputValue = int.Parse(Console.ReadLine());
            bool notPrime = false;

            for (int i = 2; i <= (int)Math.Sqrt(inputValue); i++)
            {
                if (inputValue%i==0)
                {
                    notPrime = true;
                    break;                    
                }
            }
            Console.WriteLine("\t {0} is {1}\n", inputValue, notPrime ? "composite number" : "prime number");
        }
    }
}
