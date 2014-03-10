using System;

namespace MathExpression
{
    class MathExpression
    {
        static void Main(string[] args)
        {
            decimal N = decimal.Parse(Console.ReadLine());
            decimal M = decimal.Parse(Console.ReadLine());
            decimal P = decimal.Parse(Console.ReadLine());

            decimal nomin = N * N + (1 / (P * M)) + 1337;
            decimal denom = N - 128.523123123m * P;
            decimal result = nomin/denom + (decimal)Math.Sin((double)((int)M % 180));
            Console.WriteLine("{0:f6}",result);
        }
    }
}
