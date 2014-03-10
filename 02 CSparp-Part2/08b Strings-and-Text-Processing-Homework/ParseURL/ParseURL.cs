using System;
using System.Text;

class ParseURL
{
    // Write a program that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements. 

    static void Main()
    {
        string text = @"http://www.devbg.org/forum/index.php";

        int index = text.IndexOf("://");
        if (index < 0)
        {
            throw new ArgumentException("Invalid URL address");
        }
        Console.WriteLine(" Protokol: {0}",text.Substring(0,index));

        
        int start = index + 3; // "://".length = 3        
        index = text.IndexOf("/", start);
        if (index < 0)
        {
            throw new ArgumentException("Invalid URL address");
        }
        Console.WriteLine("   Server: {0}", text.Substring(start, index - start));
        Console.WriteLine(" Resource: {0}", text.Substring(index));
    }
}

