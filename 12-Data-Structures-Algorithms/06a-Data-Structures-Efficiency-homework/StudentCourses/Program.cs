using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourses
{
    public class Program
    {
        //  A text file students.txt holds information about students and their courses in the following format. Using SortedDictionary<K,T> print the courses in alphabetical order and for each of them prints the students ordered by family and then by name

        public static void Main()
        {
            var dict = new SortedDictionary<string, SortedSet<string>>();
            var pairsList = ReadFile("..\\..\\students.txt");

            foreach (var pair in pairsList)
            {
                if (!dict.ContainsKey(pair.Value))
                {
                    dict[pair.Value] = new SortedSet<string>();
                }

                dict[pair.Value].Add(pair.Key);
            }

            foreach (var pair in dict)
            {
                Console.WriteLine("{0} : {1}", pair.Key, string.Join(", ", pair.Value));
            }
        }

        private static List<KeyValuePair<string, string>> ReadFile(string fileName)
        {
            try
            {
                var result = new List<KeyValuePair<string, string>>();

                using (var lineReader = new StreamReader(fileName))
                {
                    string line;

                    while ((line = lineReader.ReadLine()) != null)
                    {
                        string[] words = line.Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        result.Add(new KeyValuePair<string, string>(words[0] + " " + words[1], words[2]));
                    }
                }

                return result;

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}
