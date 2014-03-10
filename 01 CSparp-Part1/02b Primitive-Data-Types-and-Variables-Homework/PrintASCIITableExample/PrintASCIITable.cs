namespace PrintASCIITableExample
{
    using System;

    class PrintASCIITable
    {
        /*Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints the entire ASCII table of characters on the console.*/
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // Characters 0-31 and 127 are non-printable chars
            int number;
            string symbol;
            int columns = 2;
            int rows = 128 / columns;

            Console.WriteLine("\t" + new string('-', 21*columns+1));
            Console.Write("\t");
            for (int i = 0; i < columns; i++)
            {
                Console.Write("| DEC | HEX |  Char  ");
            }
            Console.Write("|\n");
            Console.WriteLine("\t" + new string('-', 21*columns+1));            
         
            for (int i = 0; i < rows; i++)
            {
                Console.Write("\t");
                for (int j = 0; j < columns; j++)
                {                   
                    number = i+j*rows;
                    if (number >= 0 && number <= 31 || number == 127)
                    {
                        symbol = "Contr.";
                    }
                    else
                    {
                        symbol = ((char)number).ToString() + "   ";
                    }
                    Console.Write("| {0,3} | {0,3:X} | {1,6} ", number, symbol);
                }
                Console.Write("|\n");
            }
            Console.WriteLine("\t" + new string('-', 21 * columns+1));
            Console.WriteLine();
        }
    }
}
