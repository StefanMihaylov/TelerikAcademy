using System;
using System.Text;

class TextEncriptingByXOR
{
    // Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.

    private static string Encode(string text, string cypher)
    {
        StringBuilder result = new StringBuilder();

        int cypherIndex = 0;
        for (int i = 0; i < text.Length; i++)
        {
            result.Append((char)(text[i] ^ cypher[cypherIndex]));
            cypherIndex++;
            if (cypherIndex == cypher.Length)
            {
                cypherIndex = 0;
            }
        }
        return result.ToString();
    }

    static void Main()
    {
        string text = "We are living in an yellow submarine. We don't have anything else.";
        string cypher = "abcd";

        string encriptText = Encode(text, cypher);
        string result = Encode(encriptText, cypher);

        Console.WriteLine("        Text:{0}", text);
       // Console.WriteLine("Encoded text:{0}", encriptText); // text is full of non-printable characters
        Console.WriteLine("Decoded text:{0}", result);
    }
}
