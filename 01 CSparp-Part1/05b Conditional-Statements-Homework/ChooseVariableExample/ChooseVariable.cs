namespace ChooseVariableExample
{
    using System;

    class ChooseVariable
    {
        // Write a program that, depending on the user's choice inputs int, double or string variable. If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. The program must show the value of that variable as a console output. Use switch statement.


        static void Main()
        {
            Console.WriteLine("\t Enter \"1\" for Integer \n\t Enter \"2\" for Double \n\t Enter \"3\" for String");
            int type;
            while (true)
            {
                Console.Write("\t Choose a variable type: ");
                if (int.TryParse(Console.ReadLine(), out type) && type>=1 && type<=3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            switch (type)
            {
                case 1:                                
                    int intValue;
                    while (true)
                    {
                        Console.Write("\t Enter integer value: ");
                        if (int.TryParse(Console.ReadLine(), out intValue))
                        {
                            Console.WriteLine("\t Result is {0}", intValue+1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\t\t Invalid value. Try again");
                        }
                    }
                    break;

                case 2:
                    double doubleValue;
                    while (true)
                    {
                        Console.Write("\t Enter double value: ");
                        if (double.TryParse(Console.ReadLine(), out doubleValue))
                        {
                            Console.WriteLine("\t Result is {0}", doubleValue + 1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\t\t Invalid value. Try again");
                        }
                    }
                    break;

                case 3:
                    Console.Write("\t Enter string: ");
                    string stringValue = Console.ReadLine();
                    stringValue += "*";
                    Console.WriteLine("\t Result is " + stringValue);
                    break;
            }
        }        
    }
}
