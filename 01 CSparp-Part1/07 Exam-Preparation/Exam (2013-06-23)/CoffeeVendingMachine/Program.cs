using System;

namespace CoffeeVendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            int N1 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            int N3 = int.Parse(Console.ReadLine());
            int N4 = int.Parse(Console.ReadLine());
            int N5 = int.Parse(Console.ReadLine());
            decimal A = decimal.Parse(Console.ReadLine());
            decimal P = decimal.Parse(Console.ReadLine());

            decimal amount = N1 * 0.05m + N2 * 0.1m + N3 * 0.2m + N4 * 0.5m + N5 * 1m;

            if (A < P)
            {
                Console.WriteLine("More {0:f2}",P-A);
            }
            else if (amount<(A-P))
            {
                Console.WriteLine("No {0:f2}",A-P-amount);
            }
            else
            {
                Console.WriteLine("Yes {0:f2}", amount -(A - P));
            }  
        }
    }
}
