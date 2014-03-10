namespace ExcangeExample
{
    using System;

    class ExchangeValues
    { 
        // Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.
        
        static void Main()
        { 
            // with temp variable
            int var1 = 5;
            int var2 = 10;
            int temp;
            Console.WriteLine("\t Values: {0}, {1}",var1,var2);
            temp = var1;
            var1 = var2;
            var2 = temp;
            Console.WriteLine("\t Values: {0}, {1}", var1, var2);

            // without temp variable
            var1 = 5;
            var2 = 10;
            Console.WriteLine("\n\t Values: {0}, {1}", var1, var2);
            var1 = var1 + var2;
            var2 = var1 - var2;
            var1 = var1 - var2;
            Console.WriteLine("\t Values: {0}, {1}", var1, var2);
        }
    }
}
