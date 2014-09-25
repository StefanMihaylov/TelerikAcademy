namespace JustHashSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>> //where K : IHashCodeProvider
    {
        public const int InitialCapacity = 16;

        private LinkedList<KeyValuePair<K, T>>[] storage;

        public HashTable()
        {
            this.storage = new LinkedList<KeyValuePair<K, T>>[InitialCapacity];
            this.Count = 0;
        }

        public int Count
        {
            get;
            private set;
        }

        public int Capacity
        {
            get
            {
                return this.storage.Length;
            }
        }

        public void Clear()
        {
            this.storage = new LinkedList<KeyValuePair<K, T>>[this.Capacity];
            this.Count = 0;
        }

        public void Add(K key, T value)
        {
            int index = this.GetHash(key);
            if (this.storage[index] == null)
            {
                this.storage[index] = new LinkedList<KeyValuePair<K, T>>();
            }

            bool hasKey = this.storage[index].Any(p => p.Key.Equals(key));
            if (hasKey)
            {
                throw new ArgumentException(string.Format("Key \"{0}\" already exist", key));
            }

            var pair = new KeyValuePair<K, T>(key, value);
            this.storage[index].AddLast(pair);
            this.Count++;

            if (this.Count >= this.Capacity * 0.75)
            {
                this.ReorderTable();
            }
        }

        public T Find(K key)
        {
            int index = this.GetHash(key);

            if (this.storage[index] != null)
            {
                foreach (var pair in this.storage[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair.Value;
                    }
                }
            }

            throw new ArgumentException(string.Format("Key \"{0}\" not found", key));
        }

        public KeyValuePair<K, T> Remove(K key)
        {
            int index = this.GetHash(key);

            if (this.storage[index] != null)
            {
                foreach (var pair in this.storage[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        this.storage[index].Remove(pair);
                        return pair;
                    }
                }
            }

            throw new ArgumentException(string.Format("Key \"{0}\" not found", key));
        }

        public ICollection<K> Keys()
        {
            var result = new List<K>();
            foreach (var pair in this)
            {
                result.Add(pair.Key);
            }

            return result;
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                int index = this.GetHash(key);

                if (this.storage[index] != null)
                {
                    var oldPair = new KeyValuePair<K, T>();
                    bool pairFound = false;

                    foreach (var pair in this.storage[index])
                    {
                        if (pair.Key.Equals(key))
                        {
                            oldPair = pair;
                            pairFound = true;
                        }
                    }

                    if (pairFound)
                    {
                        var newPair = new KeyValuePair<K, T>(key, value);
                        this.storage[index].Remove(oldPair);
                        this.storage[index].AddLast(newPair);
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("Key \"{0}\" not found", key));
                    }
                }                
            }
        }

        public bool ContainsKey(K key)
        {
            int index = this.GetHash(key);

            if (this.storage[index] != null)
            {
                foreach (var pair in this.storage[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var list in this.storage)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetHash(K key, int capacity)
        {
            int hash = key.GetHashCode();
            hash %= capacity;
            return Math.Abs(hash);
        }

        private int GetHash(K key)
        {
            return this.GetHash(key, this.Capacity);
        }

        private void ReorderTable()
        {
            var cashedStorage = this.storage;

            var newCapacity = this.Capacity * 2;
            this.storage = new LinkedList<KeyValuePair<K, T>>[newCapacity];

            this.Count = 0;
            foreach (var list in cashedStorage)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        this.Add(pair.Key, pair.Value);
                    }
                }
            }
        }
    }
}
