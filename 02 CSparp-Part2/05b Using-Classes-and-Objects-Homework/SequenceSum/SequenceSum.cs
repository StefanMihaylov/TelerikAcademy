using System;

class SequenceSum
{
    // You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from given string and calculates their sum.
    // Example: string = "43 68 9 23 318" -> result = 461
    
    static int CalculateSum(string sequence)
    {
        string[] numbers = sequence.Split(' ');

        int currentNumber;
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (int.TryParse(numbers[i], out currentNumber))
            {
                sum += currentNumber;
            }
            else
            {
                Console.WriteLine("Warning! \"{0}\" is not valid number and it isn't included in the sum", numbers[i]);
            }
        }
        return sum;
    }

    static void Main()
    {        
        Console.Write(" Enter sequence of numbers, separated by spaces: ");

        int sum = CalculateSum(Console.ReadLine());

        Console.WriteLine(" Sequence sum is {0}",sum);
    }
}
