namespace CopyrightSignExample
{
    using System;

    class CopyrightSign
    {
        /* Write a program that prints an isosceles triangle of 9 copyright symbols ©. Use Windows Character Map to find the Unicode code of the © symbol. Note: the © symbol may be displayed incorrectly. */
 
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // To be able to see the copyright sign change the console font

            int rows = 3;

            string spaces;
            string symbols;
            Console.WriteLine();
            for (int i = 0; i < rows; i++)
            {
                spaces = new string(' ', rows-i-1);
                symbols = new string('\u00A9', 2*i+1);
                Console.WriteLine("\t {0}", spaces + symbols + spaces);
            }
            Console.WriteLine();
        }
    }
}
