using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWords
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<string> words = new List<string>();

            int maxLength = 0;
            for (int i = 0; i < N; i++)
            {
                words.Add(Console.ReadLine());
                if (maxLength < words[i].Length)
                {
                    maxLength = words[i].Length;
                }
            }

            // reorder
            for (int i = 0; i < words.Count; i++)
            {
                string temp = words[i];
                int index = temp.Length % (N + 1);
                words[i] = null;
                words.Insert(index, temp);
                words.Remove(null);                         
            }

            // print
            StringBuilder result = new StringBuilder();
            for (int index = 0; index < maxLength; index++)
            {
                for (int i = 0; i < words.Count; i++)
                {
                    if (index < words[i].Length)
                    {
                        result.Append(words[i][index]);
                    }                    
                }
            }

            Console.WriteLine(result);
        }
    }
}
