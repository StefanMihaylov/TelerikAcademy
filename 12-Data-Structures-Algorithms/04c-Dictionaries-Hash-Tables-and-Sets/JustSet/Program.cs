namespace JustSet
{
    using System;

    public class Program
    {
        // Implement the data structure "set" in a class HashedSet<T> using your class HashTable<K,T> to hold the elements. Implement all standard set operations like Add(T), Find(T), Remove(T), Count, Clear(), union and intersect.

        public static void Main()
        {
            var set = new JustSet<int>();

            for (int i = 1; i <= 6; i++)
            {
                set.Add(i);
            }

            Console.WriteLine("\t Set: {0}", string.Join(", ", set));
            //set.Add(1); // throw exeption

            Console.WriteLine("\t Contains 5: {0}", set.Contains(5));

            Console.WriteLine("\t Remove 3: {0}", set.Remove(3));
            Console.WriteLine("\t Set: {0}", string.Join(", ", set));

            var otherSet = new JustSet<int>();
            for (int i = 4; i <= 9; i++)
            {
                otherSet.Add(i);
            }
            Console.WriteLine("\t Other Set: {0}", string.Join(", ", set));

            var union = set.Union(otherSet);
            var intersect = set.Intersect(otherSet);

            Console.WriteLine("\t Union: {0}", string.Join(", ", union));
            Console.WriteLine("\t Intersect: {0}", string.Join(", ", intersect));
        }
    }
}
