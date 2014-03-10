namespace CheckDigitExample
{
    using System;

    class CheckDigit
    {
        // Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732 -> true

        static void Main()
        {
            int inputValue = 1732; //1632
           
            int newValue = (inputValue / 100)%10;
            Console.WriteLine("\n\t Third digit of {0} {1} equal to 7!\n", inputValue, newValue == 7 ? "is" : "isn't");         
        }
    }
}
