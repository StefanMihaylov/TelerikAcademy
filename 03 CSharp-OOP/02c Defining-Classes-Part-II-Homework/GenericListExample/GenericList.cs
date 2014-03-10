namespace GenericListExample
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GenericList<T> where T : IComparable
    {
        private T[] elements;
        private int count;
        private int capacity;

        // constructors
        public GenericList(int capacity)
        {
            this.Capacity = capacity;
            this.Count = 0;
            this.elements = new T[this.Capacity];
        }

        public GenericList()
            : this(4)
        {

        }

        // properties
        public int Count
        {
            get { return this.count; }
            private set { this.count = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        // indexer
        public T this[int index]
        {

            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return this.elements[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                this.elements[index] = value;
            }
        }

        // methods
        public void Add(T element)
        {
            if (this.Count >= this.Capacity)
            {
                AutoGrow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            for (int i = index; i < this.Count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
            this.Count--;
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (this.Count >= this.Capacity)
            {
                AutoGrow();
            }

            for (int i = this.Count - 1; i >= index; i--)
            {
                this.elements[i+1] = this.elements[i];
            }
            this.elements[index] = element;
            this.Count++;
        }

        public void Clear()
        {
            this.elements = new T[this.Capacity];
        }

        public int FindFirst(T element)
        {
            int index = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                if (i == this.Count - 1)
                {
                    result.AppendFormat("{0}", this.elements[i]);
                }
                else
                {
                    result.AppendFormat("{0} ", this.elements[i]);
                }
            }
            return result.ToString();
        }

        private void AutoGrow()
        {
            this.Capacity *= 2;
            T[] newArray = new T[this.Capacity];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.elements[i];
            }
            this.elements = newArray;
        }

        public T Min()
        {
            T result = this.elements[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (this.elements[i].CompareTo(result) < 0)
                {
                    result = this.elements[i];
                }
            }
            return result;
        }

        public T Max()
        {
            T result = this.elements[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (this.elements[i].CompareTo(result) > 0)
                {
                    result = this.elements[i];
                }
            }
            return result;
        }
    }
}
