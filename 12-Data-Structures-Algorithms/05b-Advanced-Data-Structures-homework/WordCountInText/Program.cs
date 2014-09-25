namespace WordCountInText
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        // Write a program that finds a set of words (e.g. 1000 words) in a large text (e.g. 100 MB text file). Print how many times each word occurs in the text

        // http://en.wikipedia.org/wiki/Trie

        public static void Main()
        {
            var startTrie = new TrieNode('а'); //Cyrilic
            Stopwatch watch = new Stopwatch();

            watch.Start();
            var words = ReadFile("..\\..\\Lord-of-the-Rings.txt");
            Console.WriteLine(" File: Lord-of-the-Rings.txt");
            Console.WriteLine(" File read for {0}, {1} words, {2} unique words \n",
                                watch.Elapsed, words.Count, words.Distinct().Count());

            watch.Restart();
            AddToTrie(words, startTrie);
            Console.WriteLine(" Add to trie for {0}", watch.Elapsed);


            // in cyrillic only
            string[] searchWords = new string[] { "пръстен", "Фродо", "Арагорн", "син", "Араторн", "Хобит", "Гандалф", "меч", "орки", "запяха", "пушилист", "закуска", "храна", "елфи", "джудже", "Мордор", "енти", "лък", "огън", "стрели" };

            watch.Restart();
            var wordCount = SearchInTrie(searchWords, startTrie);
            var searchTime = watch.Elapsed;
            Console.WriteLine(" Search {1} words in trie for {0}", searchTime, searchWords.Length);
            Print(wordCount, searchWords);

            // using dictionary
            Console.WriteLine();
            IDictionary<string, int> dict = new Dictionary<string, int>();
            watch.Restart();
            AddtoDictionary(dict, words);
            Console.WriteLine(" Add to dictionaty for {0}", watch.Elapsed);

            wordCount = SearchInDictionary(searchWords, dict);
            searchTime = watch.Elapsed;
            Console.WriteLine(" Search {1} words in dictionaty for {0}", searchTime, searchWords.Length);
            // Print(wordCount, searchWords);
        }

        private static List<int> SearchInTrie(string[] searchWords, TrieNode startTrie)
        {
            List<int> wordCount = new List<int>(searchWords.Length);
            foreach (var word in searchWords)
            {
                wordCount.Add(startTrie.CountWords(startTrie, word.ToLower()));
            }
            return wordCount;
        }

        private static List<int> SearchInDictionary(string[] searchWords, IDictionary<string, int> dict)
        {
            List<int> wordCount = new List<int>(searchWords.Length);
            foreach (var word in searchWords)
            {
                wordCount.Add(dict[word.ToLower()]);
            }
            return wordCount;
        }

        private static void Print(List<int> wordCount, string[] searchWords)
        {
            for (int i = 0; i < wordCount.Count; i++)
            {
                Console.WriteLine("{0,20}: {1}", searchWords[i], wordCount[i]);
            }
        }

        private static List<string> ReadFile(string fileName)
        {
            try
            {
                using (var lineReader = new StreamReader(fileName))
                {
                    string line = lineReader.ReadToEnd();
                    var matches = Regex.Matches(line, @"[а-яА-Я]+");

                    var result = new List<string>();
                    foreach (var word in matches)
                    {
                        result.Add(word.ToString().ToLower());
                    }

                    return result;
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return null;
        }

        private static void AddToTrie(List<string> words, TrieNode startTrie)
        {
            foreach (var word in words)
            {
                startTrie.AddWord(startTrie, word);
                startTrie.AddOccuranceIfExists(startTrie, word);
            }
        }

        private static void AddtoDictionary(IDictionary<string, int> dict, List<string> words)
        {
            foreach (var word in words)
            {
                if (!dict.ContainsKey(word))
                {
                    dict[word] = 0;
                }

                dict[word]++;
            }
        }
    }
}
