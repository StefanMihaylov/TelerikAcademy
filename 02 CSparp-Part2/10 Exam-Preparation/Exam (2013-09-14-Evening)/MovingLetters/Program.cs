using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingLetters
{
    class Program
    {
        static void Main()
        {
             string text = Console.ReadLine(); 
            // string text = "Fun exam right";
            
            string[] words = text.Split(' ');

            int maxLenght = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > maxLenght)
                {
                    maxLenght = words[i].Length;
                }
            }
            

            StringBuilder arrangedText = new StringBuilder();
            for (int i = 0; i < maxLenght; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    int position = words[j].Length -1 - i;                    
                    if (position >= 0)
                    {                        
                        arrangedText.Append(words[j][position]);
                    }
                }
            }

            for (int index = 0; index < arrangedText.Length; index++)
            {
                char letter = arrangedText[index];
                int position = char.ToLower(letter) - 'a' + 1;
                position = (index + position) % arrangedText.Length;
                arrangedText.Remove(index,1);
                arrangedText.Insert(position, letter);
            }

            Console.WriteLine(arrangedText);
        }
    }
}
