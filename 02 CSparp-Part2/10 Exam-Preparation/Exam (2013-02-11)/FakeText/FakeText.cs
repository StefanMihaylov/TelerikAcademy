using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FakeText
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string[] commands = new string[N];

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < commands.Length; i++)
        {
            result.AppendLine(Console.ReadLine());
        }

        string currentText = result.ToString();
        int endTagIndex = currentText.IndexOf("</", 0);

        while (endTagIndex >= 0)
        {
            int endTagEnd = currentText.IndexOf(">", endTagIndex);
            string tag = currentText.Substring(endTagIndex + 2, endTagEnd - endTagIndex - 2);
            result.Remove(endTagIndex, endTagEnd - endTagIndex + 1);

            int startTagIndex = currentText.LastIndexOf("<", endTagIndex - 1);
            int startTagEnd = currentText.IndexOf(">", startTagIndex);
            Convert(result, tag, startTagEnd + 1, endTagIndex - startTagEnd - 1);
            result.Remove(startTagIndex, startTagEnd - startTagIndex + 1);

            currentText = result.ToString();
            endTagIndex = currentText.IndexOf("</", 0);
        }
        
        Console.WriteLine(result.ToString());
    }


    static void Convert(StringBuilder text, string tag, int start, int length)
    {
        tag = tag.ToLower();
        if (tag == "upper")
            for (int i = start; i < start + length; i++)
            {
                text[i] = char.ToUpper(text[i]);
            }
        else if (tag == "lower")
            for (int i = start; i < start + length; i++)
            {
                text[i] = char.ToLower(text[i]);
            }
        else if (tag == "del") text.Remove(start, length);
        else if (tag == "toggle")
        {
            for (int i = start; i < start + length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (char.IsLower(text[i]))
                    {
                        text[i] = char.ToUpper(text[i]);
                    }
                    else
                    {
                        text[i] = char.ToLower(text[i]);
                    }
                }
            }
        }
        else if (tag == "rev")
        {
            char[] temp = new char[length];
            for (int i = start, index = 0; i < start + length; i++, index++)
            {
                temp[index] = text[i];
            }
            Array.Reverse(temp);
            for (int i = start, index = 0; i < start + length; i++, index++)
            {
                text[i] = temp[index];
            }
        }
        else
        {
            throw new ArgumentException("Unknown command");
        }
    }
}

