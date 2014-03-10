using System;
using System.Text;

class ReverseString
{
    // Write a program that reads a string, reverses it and prints the result at the console.
    // Example: "sample" -> "elpmas".

    static void Main()
    {
        Console.Write(" Enter text: ");
        string text = Console.ReadLine();
        char[] letters = text.ToCharArray();
        Array.Reverse(letters);
        Console.WriteLine(" Reverse text is: {0}",string.Join("",letters));
    }
}

