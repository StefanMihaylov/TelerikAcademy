namespace PrintAgeExample
{
    using System;

    class PrintAge
    {
        //* Write a program to read your age from the console and print how old you will be after 10 years.
        
        static void Main()
        {
            byte age;
            Console.Write("\n\t How old are you?:");
            if (byte.TryParse(Console.ReadLine(),out age))
            {
                Console.WriteLine("\t In 10 years you will be {0} years old. \n", age + 10);
            }
            else
            {
                Console.WriteLine("\t Invalid age! \n");
            }            
        }
    }
}
