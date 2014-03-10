namespace StringConcatExample
{
    using System;

    class StringConcat
    {
        /* Declare two string variables and assign them with “Hello” and “World”. Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval). Declare a third string variable and initialize it with the value of the object variable (you should perform type casting). */

        static void Main()
        {
            string var1 = "Hello";
            string var2 = "World";
            object concat1 = var1 + " " + var2;
            string concat2 = (string)concat1;
            Console.WriteLine(concat2);
        }
    }
}
