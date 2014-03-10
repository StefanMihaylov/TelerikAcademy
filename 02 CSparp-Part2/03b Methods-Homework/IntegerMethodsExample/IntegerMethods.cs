using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegerMethodsExample
{
    class IntegerMethods
    {
        // Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.

        public static List<int> UserList()
        {
            // initialize List entered by the user
            List<int> userList = new List<int>();
            Console.WriteLine(" Enter sequence of numbers! Enter any letter or wrong number for exit");
            int number;
            
            Console.Write(" Enter number: ");
            while (int.TryParse(Console.ReadLine(), out number))
            {
                userList.Add(number);
                Console.Write(" Enter number: ");
            }
            if (userList.Count>0)
            {
                return userList;
            }
            else
            {
                Console.WriteLine(" The sequence of numbers should not be empty! Try again!");
                return UserList();
            }
            
        }

        public static List<int> RandomList(int maxLength ,int minElement, int maxElement)
        {
            // Initialize random list
            List<int> randomList = new List<int>();
            Random randomGenerator = new Random();
            if (maxElement < 5)
            {
                maxElement = 5;
            }
            int length = randomGenerator.Next(5, maxLength + 1); // minimal length = 5
            for (int index = 0; index < length; index++)
            {
                randomList.Add(randomGenerator.Next(minElement, maxElement + 1));
            }
            return randomList;
        }

        public static int intInput(string text, int min, int max)
        {
            int InputValue;
            while (true)
            {
                Console.Write("{0} from {1} to {2}: ", text, min, max);
                if (int.TryParse(Console.ReadLine(), out InputValue) && InputValue >= min && InputValue <= max)
                {
                    return InputValue;
                }
                else
                {
                    Console.WriteLine("\t Invalid value! Try again!");
                }
            }
        }

        public static void Print(List<int> print)
        {
            Console.Write(" Sequence:");
            for (int index = 0; index < print.Count; index++)
            {
                Console.Write(" {0}", print[index]);
            }
            Console.WriteLine();
        }

        static int Minimal(List<int> inputList)
        {
            return inputList.Min();
        }

        static int Maximal(List<int> inputList)
        {
            return inputList.Max();
        }

        static decimal Average(List<int> inputList)
        {
            return (decimal)inputList.Sum() / inputList.Count;
        }

        static long Sum(List<int> inputList)
        {
            return inputList.Sum();
        }

        static decimal Product(List<int> inputList)
        {
            decimal result = 1;
            foreach (var item in inputList)
            {
                result *= item;
            }
            return result;
        }

        static void Main()
        {
            List<int> inputList = new List<int>();
            Console.WriteLine("  Enter \"1\" to test random data");
            Console.WriteLine("  Enter \"2\" to test your data");
            int choise = intInput("  Enter your choise", 1, 2);
            
            switch (choise)
            {
                case 1:
                    inputList = RandomList(20, -10, 10);
                    break;
                case 2:
                    inputList = UserList();
                    break;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Print(inputList);
                Console.WriteLine();
                Console.WriteLine("  Enter \"0\" to exit");
                Console.WriteLine("  Enter \"1\" to find minimal number in input data");
                Console.WriteLine("  Enter \"2\" to find maximal number in input data");
                Console.WriteLine("  Enter \"3\" to find average of input data");
                Console.WriteLine("  Enter \"4\" to find sum of input data");
                Console.WriteLine("  Enter \"5\" to find product of input data");
                choise = intInput("  Enter your choise", 0, 5);
                switch (choise)
                {
                    case 0:
                        return;  // exit
                    case 1:
                        Console.WriteLine(" Minimal number is {0}", Minimal(inputList));
                        break;
                    case 2:
                        Console.WriteLine(" Minimal number is {0}", Maximal(inputList));
                        break;
                    case 3:
                        Console.WriteLine(" Average of the sequence of integers is {0:f3}", Average(inputList));
                        break;
                    case 4:
                        Console.WriteLine(" Sum of the sequence of integers is {0}", Sum(inputList));
                        break;
                    case 5:
                        Console.WriteLine(" Product of the sequence of integers is {0}", Product(inputList));
                        break;
                }
                Console.WriteLine();
                Console.Write(" Press any key to open the menu again ");
                Console.ReadKey();
            }
        }
    }
}
