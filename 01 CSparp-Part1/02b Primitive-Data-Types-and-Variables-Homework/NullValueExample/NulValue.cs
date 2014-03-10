namespace NullValueExample
{
    using System;

    class NulValue
    {
        /* Create a program that assigns null values to an integer and to double variables. Try to print them on the console, try to add some values or the null literal to them and see the result. */
        
        static void Main()
        {
            int? var1 = null;
            double? var2 = null;
            Console.WriteLine("\n\tPrint Values: {0}, {1}\n",var1, var2);

            var1 = 5;
            var2 = 2.4;
            Console.WriteLine("\tPrint Values: {0}, {1}\n", var1, var2);
        }
    }
}
