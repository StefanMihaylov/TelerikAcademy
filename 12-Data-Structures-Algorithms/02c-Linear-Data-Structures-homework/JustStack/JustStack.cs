namespace JustStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class JustStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 5; // just for small tests

        private T[] storage;
        private int count;
        private int capacity;

        public JustStack()
        {
            this.capacity = InitialCapacity;
            this.storage = new T[this.capacity];
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public void Push(T value)
        {
            if (this.Count < this.Capacity)
            {
                this.storage[Count] = value;
                this.count++;
            }
            else
            {
                this.capacity = 2*this.Capacity;
                T[] newStorage = new T[this.Capacity];
                for (int i = 0; i < this.Count; i++)
                {
                    newStorage[i] = this.storage[i];
                }

                this.storage = newStorage;
                this.Push(value);
            }
        }

        public T Pop()
        {
            T value = this.Peek();
            this.count--;
            return value;
        }

        public T Peek()
        {
            if (this.Count <= 0)
            {
                throw new Exception("No elements in the stack");
            }

            int index = this.count - 1;
            T value = this.storage[index];
            return value;
        }

        public void Clear()
        {
            this.count = 0;
        }
        
        // for test purposes only
        public IEnumerator<T> GetEnumerator()
        {

            int index = this.Count-1;
            while (index >=0 )
            {
                yield return this.storage[index];
                index--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
