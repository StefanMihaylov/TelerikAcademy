namespace JustSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using JustHashSet;

    public class JustSet<T> : IEnumerable<T>
    {
        private HashTable<T, bool> storage;

        public JustSet()
        {
            this.storage = new HashTable<T, bool>();
        }

        public int Capacity
        {
            get
            {
                return this.storage.Capacity;
            }
        }

        public int Count
        {
            get
            {
                return this.storage.Count;
            }
        }

        public void Add(T value)
        {
            this.storage.Add(value, false);
        }

        public bool Contains(T value) // Method name "Contains" is better than "Find"
        {
            return this.storage.ContainsKey(value);
        }

        public void Clear()
        {
            this.storage.Clear();
        }

        public T Remove(T value)
        {
            var result = this.storage.Remove(value);
            return result.Key;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var pair in this.storage)
            {
                yield return pair.Key;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public JustSet<T> Union(JustSet<T> other)
        {
            var result = new JustSet<T>();

            foreach (var item in this)
            {
                result.Add(item);
            }

            foreach (var item in other)
            {
                if (!this.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public JustSet<T> Intersect(JustSet<T> other)
        {
            var result = new JustSet<T>();

            foreach (var first in this)
            {
                foreach (var second in other)
                {
                    if (first.Equals(second))
                    {
                        result.Add(first);
                    }
                }
            }

            return result;
        }
    }
}
