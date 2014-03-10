using System;

namespace SearchLetters
{
    class SearchLetters
    {
        static void Main()
        {

            char[] alphabet = new char[2*26];
            for (int i = 0; i < 26; i++)
            {
                alphabet[i] = (char)(i + 65);
                alphabet[i+26] = (char)(i + 97);
            }

            // print alphabet array
            // for (int i = 0; i < alphabet.Length; i++)
            // {
            //     Console.Write("{0} ",alphabet[i]);
            // }
            // Console.WriteLine(); 

            Console.Write(" Enter word: "); 
            string word = Console.ReadLine();

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));

            for (int i = 0; i < word.Length; i++)
            {
                int index = BinarySearch(word[i], alphabet);
                if (index >= 0)
                {
                    Console.WriteLine(" letter:{0} -> index:{1}", word[i], index);
                }
                else
                {
                    Console.WriteLine(" letter:{0} -> This isn't a letter", word[i]);
                }       
            }
        }

        static int BinarySearch(char letter, char[] alphabet)
        {
            // binary search
            int low = 0;
            int high = alphabet.Length - 1;
            while (low + 1 < high)
            {
                int test = (high + low) / 2;
                if (alphabet[test] > letter)
                {
                    high = test;
                }
                else
                {
                    low = test;
                }
            }

            if (alphabet[low] == letter)
            {
                return low;
            }
            else if (alphabet[high] == letter)
            {
                return high;
            }
            else
            {
                return -1;
            }
        }
    }
}
