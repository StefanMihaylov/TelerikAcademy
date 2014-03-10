using System;

class ReadNumberExample
{
    // Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. If an invalid number or non-number text is entered, the method should throw an exception. Using this method write a program that enters 10 numbers:
    //	a1, a2, … a10, such that 1 < a1 < … < a10 < 100

    static int ReadNumber(int start, int end)
    {
        Console.Write(" Enter number between {0} and {1}: ", start,end);
        string input = Console.ReadLine();

        int result = int.Parse(input);
        if (result < start || result > end) // I don't know if "result == star" is allowd or NOT. It is allowed now.
        {
            throw new ArgumentOutOfRangeException();
        }
        return result;
    }

    static void Main()
    {
        int start = 1;
        int end = 100;
        for (int i = 0; i < 10; )
        {                 
            try
            {
                start = ReadNumber(start, end);
                i++; // if exception is catch the index isn't incremented
            }
            catch (Exception ex) // I use only one catch because there is no custom mesages
            {
                Console.WriteLine(" Invalid number! {0}",ex.Message);                
            }
        }
    }
}