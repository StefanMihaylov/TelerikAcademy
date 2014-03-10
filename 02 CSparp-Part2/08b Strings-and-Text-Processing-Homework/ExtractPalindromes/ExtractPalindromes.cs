using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExtractPalindromes
{
    // Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

    static void Main()
    {
        string text = "In the automata exe, a set of all Bob in a given alphabet is ABBA a typical example of a language that is context-free kayak, but not SOS regular.";  // Sentense with no meaning and random plased palindromes
        
        char[] separators = { ' ', ',', '.', '!', '\n', '\r' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var word in words)
        {
            char[] arr = word.ToLower().ToCharArray();
            Array.Reverse(arr);
            string reversed = new string(arr);
            if ((word.Length > 1) && (word.ToLower() == reversed))
            {
                Console.WriteLine(word);
            }
        }
    }
}

