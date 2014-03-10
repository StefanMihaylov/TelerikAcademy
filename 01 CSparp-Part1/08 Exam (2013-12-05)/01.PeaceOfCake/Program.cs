using System;

namespace _01.PeaceOfCake
{
    class Program
    {
        static void Main()
        {
            long A = long.Parse(Console.ReadLine());
            long B = long.Parse(Console.ReadLine());
            long C = long.Parse(Console.ReadLine());
            long D = long.Parse(Console.ReadLine());

            long nominator = A * D + B * C;
            long denominator = B * D;
            if (nominator/denominator>0)
            {
                Console.WriteLine(nominator / denominator);
            }
            else
            {
                Console.WriteLine("{0:f22}", (decimal)nominator / (decimal)denominator);
            }           
            Console.WriteLine("{0}/{1}",nominator,denominator);
        }
    }
}
