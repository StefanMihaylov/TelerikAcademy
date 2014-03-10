using System;
using System.Text;

class Program
{
    // You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested

    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        string start = "<upcase>";
        string stop = "</upcase>";

        Console.WriteLine(text);

        StringBuilder result = new StringBuilder();

        int startIndex;
        int stopIndex;
        int lastStop = 0;
        while (true)
        {
            startIndex = text.IndexOf(start, lastStop);
            if (startIndex < 0)
            {
                break;
            }
            stopIndex = text.IndexOf(stop, startIndex + start.Length);
            if (stopIndex < 0)
            {
                break;
            }

            result.Append(text.Substring(lastStop, startIndex - lastStop));
            result.Append(text.Substring(startIndex + start.Length, stopIndex - (startIndex + start.Length)).ToUpper());
            lastStop = stopIndex + stop.Length;
        }

        result.Append(text.Substring(lastStop));        
    
        Console.WriteLine(result);
    }
}

