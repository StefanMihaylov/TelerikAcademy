using System;

class SquareRoot
{
    // Write a program that reads an integer number and calculates and prints its square root. If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.

    static double Sqrt(double value)
    {
        if (value < 0)
        {
            throw new System.ArgumentOutOfRangeException("Sqrt for negative numbers is undefined!");
        }
        return Math.Sqrt(value);
    }

    static void Main()
    {
        Console.Write(" Enter number: ");
        string inputNumber = Console.ReadLine();
        try
        {
            int number = int.Parse(inputNumber);
            Console.WriteLine(" Square root of {0} is {1:f3}",number,Sqrt(number));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(" Invalid number! {0}", ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Invalid number! {0}",ex.Message);
        }

        finally
        {
            Console.WriteLine(" Good Bye! ");
        }
    }
}
