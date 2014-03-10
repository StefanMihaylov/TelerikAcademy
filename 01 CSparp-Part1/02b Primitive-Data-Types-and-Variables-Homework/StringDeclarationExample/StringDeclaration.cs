namespace StringDeclarationExample
{
    using System;

    class StringDeclaration
    {
        /* Declare two string variables and assign them with following value: "The "use" of quotations causes difficulties". Do the above in two different ways: with and without using quoted strings.*/

        static void Main(string[] args)
        {
            string text1 = "The \"use\" of quotations causes difficulties";
            string text2 = @"The ""use"" of quotations causes difficulties";
            Console.WriteLine(text1);
            Console.WriteLine(text2);
        }
    }
}
