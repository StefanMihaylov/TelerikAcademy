namespace CharTestExample
{
    using System;

    class CharTest
    {
        /* Declare a character variable and assign it with the symbol that has Unicode code 72. Hint: first use the Windows Calculator to find the hexadecimal representation of 72.  */ 

        static void Main()
        {
            char var = '\u0048'; // 'H'
            Console.WriteLine("\t ASCII code 72 ('H') = {0} \n", var);
        }
    }
}
