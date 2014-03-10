using System;
using System.Text;

class ReplaceHTML
{
    // Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. 

    // Sample result: <p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>


    static void Main()
    {
        string text = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";

        Console.WriteLine(text);
        Console.WriteLine();

        string[] original = new string[] { "<a href=\"", "\"", "</a>" }; 
        string[] replace = new string[] { "[URL=", "]", "[/URL]" };  

        int index = text.IndexOf(original[0]);
        int counter = 0;  // number of URL for replacement
        while (index>=0)
        {
            counter++;
            index = text.IndexOf(original[0], index + 1);
        }

        StringBuilder result = new StringBuilder();

        index = -1;
        int previous = 0;
        for (int i = 0; i < counter; i++) // number of URL for replacement
        {
            for (int j = 0; j < original.Length; j++)  // different part of URL
            {
                index = text.IndexOf(original[j], index + 1);
                result.Append(text.Substring(previous,index-previous));
                result.Append(replace[j]);

                previous = index + original[j].Length;
                index = previous;
            }            
        }

        result.Append(text.Substring(previous));
        Console.WriteLine(result);
    }
}

