using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustHashSet
{
    public class Program
    {
        // Implement the data structure "hash table" in a class HashTable<K,T>. Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with initial capacity of 16. When the hash table load runs over 75%, perform resizing to 2 times larger capacity. Implement the following methods and properties: Add(key, value), Find(key)->value, Remove(key), Count, Clear(), this[], Keys. Try to make the hash table to support iterating over its elements with foreach

        public static void Main()
        {
            var dictionary = new HashTable<string, int>();

            for (int i = 1; i <= 9; i++)
            {
                dictionary.Add("Peter" + i, i);
            }

            foreach (var pair in dictionary)
            {
                Console.WriteLine("\t {0} : {1}", pair.Key, pair.Value);
            }

            Console.WriteLine();
            string key = "Peter2";
            Console.WriteLine("\t Contains \"{0}\"? -> {1}", key, dictionary.ContainsKey(key));
            key = "Ivan";
            Console.WriteLine("\t Contains \"{0}\"? -> {1}", key, dictionary.ContainsKey(key));

            Console.WriteLine();
            key = "Peter6";
            Console.WriteLine("\t Find \"{0}\"? -> {1}", key, dictionary.Find(key));
            key = "Ivan";
            // Console.WriteLine("\t Contains \"{0}\"? -> {1}", key, dictionary.Find(key)); // Exception

            Console.WriteLine("\n\t Keys: {0}", string.Join(", ", dictionary.Keys()));

            key = "Peter7";
            var removedPair = dictionary.Remove(key);
            Console.WriteLine("\n\t Remove \"{0}\"? -> {1}, {2}", key, removedPair.Key, removedPair.Value);

            key = "Peter8";
            int newValue = 20;
            dictionary[key] = newValue;
            Console.WriteLine("\n\t Modify \"{0}\" -> {1}", key, newValue);

            foreach (var pair in dictionary)
            {
                Console.WriteLine("\t {0} : {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("\n\t Clear");
            dictionary.Clear();
            foreach (var pair in dictionary)
            {
                Console.WriteLine("\t {0} : {1}", pair.Key, pair.Value);
            }
        }
    }
}
