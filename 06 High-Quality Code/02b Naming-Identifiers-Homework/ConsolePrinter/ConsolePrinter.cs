namespace ConsolePrinter
{
    using System;

    public class ConsolePrinter
    {
        public void Print(bool input)
        {
            string inputAsString = input.ToString();
            Console.WriteLine(inputAsString);
        }
    }
}
