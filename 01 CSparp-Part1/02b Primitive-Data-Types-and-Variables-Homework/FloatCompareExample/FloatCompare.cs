namespace FloatCompareExample
{
    using System;

    class FloatCompare
    {
        /*Write a program that safely compares floating-point numbers with precision of 0.000001. Examples:(5.3 ; 6.01) -> false;  (5.00000001 ; 5.00000003) -> true */

        static void Main()
        {
            double precision = 0.000001;

            double var1 = 5.3;
            double var2 = 6.01;
            Console.WriteLine("\t {0} == {1}? -> {2}",var1,var2,Math.Abs(var2-var1) < precision);

            var1 = 5.00000001;
            var2 = 5.00000003;
            Console.WriteLine("\t {0} == {1}? -> {2}", var1, var2, Math.Abs(var2 - var1) < precision);
        }
    }
}
