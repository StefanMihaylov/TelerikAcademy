using System;
using System.Linq;

public class SelectNumbers
{
    // 6. Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

    public static void Main()
    {
        // initialize array with random nuimers from 10 to 199 
        Random randomGenerator = new Random(0);
        int[] numbers = new int[200];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = randomGenerator.Next(10, 200);
        }

        // using Lambda
        var selectedNumbers = numbers.Where(n => n % 21 == 0);
        foreach (var number in selectedNumbers)
        {
            Console.Write("{0} ",number);
        }
        Console.WriteLine();

        // using LINQ
        selectedNumbers = from num in numbers
                          where num % 21 == 0
                          select num;
        foreach (var number in selectedNumbers)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();

    }
}

