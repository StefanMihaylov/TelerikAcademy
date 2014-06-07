using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] inputArray, int startIndex, int count)
    {
        if (inputArray == null)
        {
            throw new ArgumentNullException("Input array cannot be null");
        }

        if (startIndex < 0)
        {
            throw new ArgumentNullException("The startIndex parameter cannot be negative");
        }

        if (count <= 0)
        {
            throw new ArgumentNullException("The count parameter cannot be zero or negative");
        }

        if (startIndex + count > inputArray.Length)
        {
            throw new ArgumentException("Required element index is outside the input array");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(inputArray[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (string.IsNullOrEmpty(str))
        {
            throw new ArgumentNullException("Input string cannot be null or empty");
        }

        if (count > str.Length)
        {
            throw new ArgumentException("Required count is outside the input string");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static void Main()
    {
        try
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine("Sunsequence: {0}", string.Join(string.Empty, substr));

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine("Sunsequence: {0}", string.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine("Sunsequence: {0}", string.Join(" ", allarr));

            /* throw an excepption
                var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
                Console.WriteLine("Sunsequence: {0}", string.Join(" ", emptyarr)); */

            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));

            //// Console.WriteLine(ExtractEnding("Hi", 100));

            Console.WriteLine(CheckPrime(23) ? "23 is prime." : "23 is not prime");
            Console.WriteLine(CheckPrime(33) ? "33 is prime." : "33 is not prime");

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
