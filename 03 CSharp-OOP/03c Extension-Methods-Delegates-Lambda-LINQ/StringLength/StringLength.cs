using System;
using System.Linq;

class StringLength
{
    // 17. Write a program to return the string with maximum length from an array of strings. Use LINQ.

    static void Main( )
    {
        string[] strings = new string[] 
        {
            "Write a program to return",
            "the string with maximum length from an array of strings",
            "Implement an extension method Substring(int index, int length)",
            "Using the extension methods OrderBy() and ThenBy()", 
            "with lambda expressions sort the students by ",
            "first name and last name in descending order",
            "Implement the previous using the same query ",
            "expressed with extension methods",
            "Extract all students with phones in Sofia. Use LINQ.",
        };

        // using extention methods
        string longest = strings.OrderByDescending(s => s.Length).FirstOrDefault();
        Console.WriteLine("Longest string: {0}", longest);

        // using LINQ
        string longestLINQ = (from str in strings
                          orderby str.Length descending
                           select str).FirstOrDefault();
        Console.WriteLine("Longest string: {0}", longestLINQ);
    }
}

