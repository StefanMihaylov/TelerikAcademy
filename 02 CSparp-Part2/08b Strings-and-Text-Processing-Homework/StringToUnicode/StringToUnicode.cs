using System;
using System.Text;

class StringToUnicode
{
    // Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings

    static void Main()
    {
        Console.Write(" Enter text: ");
        string text = Console.ReadLine();

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            result.AppendFormat("\\U{0:x4}", (int)text[i]);
        }

        Console.WriteLine("Letters in unicode: {0}",result);
    }
}

