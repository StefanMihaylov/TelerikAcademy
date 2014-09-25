using System;
using System.Collections;
using System.Collections.Generic;

namespace JustQueue
{
    class JustQueue<T> : IEnumerable<T>
    {
        private LinkedList<T> storage;

        public JustQueue()
        {
            this.Clear();
        }

        public int Count
        {
            get
            {
                return this.storage.Count;
            }
        }

        public void Clear()
        {
            this.storage = new LinkedList<T>();
        }

        public void Enqueue(T value)
        {
            this.storage.AddLast(value);
        }

        public T Dequeue()
        {
            T value = this.Peek();
            this.storage.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (this.Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            return this.storage.First.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
           return this.storage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
