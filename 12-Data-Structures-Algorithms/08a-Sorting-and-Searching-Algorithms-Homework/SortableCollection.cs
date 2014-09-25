namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;
        private static Random random;

        public SortableCollection()
        {
            this.items = new List<T>();
            random = new Random();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
            random = new Random();
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var element in this.Items)
            {
                if (element.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int left = 0;
            int right = this.Items.Count - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                if (this.Items[middle].CompareTo(item) == 0)
                {
                    return true;
                }
                else if (this.Items[middle].CompareTo(item) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            var n = this.Items.Count;
            for (var i = 0; i < n; i++)
            {
                // Exchange a[i] with random element in a[i..n-1]
                int randomIndex = i + random.Next(0, n - i);
                Swap(i, randomIndex);
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        private void Swap(int index1, int index2)
        {
            if (index1 != index2)
            {
                T oldValue = this.Items[index1];
                this.Items[index1] = this.Items[index2];
                this.Items[index2] = oldValue;
            }
        }
    }
}
