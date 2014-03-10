using System;

class FindSubstring
{
    // Write a program that finds how many times a substring is contained in a given text (perform case insensitive search)

    static void Main()
    {
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        string target = "in";

        int index = 0;
        int counter = 0;
        while (index >= 0)
        {
            index = text.IndexOf(target, index + 1, StringComparison.OrdinalIgnoreCase);
            if (index >=0 )
            {
                counter++;
            }
        }
        Console.WriteLine(" Number of \"{0}\" in text: {1}", target, counter);
    }
}

