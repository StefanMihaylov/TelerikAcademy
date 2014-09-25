namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int minIndex = i;
                T min = collection[minIndex];
                for (int j = i + 1; j < collection.Count; j++)
                {
                    T currentValue = collection[j];
                    if (min.CompareTo(currentValue) > 0)
                    {
                        minIndex = j;
                        min = collection[minIndex];
                    }
                }

                Swap(collection, i, minIndex);
            }
        }

        private void Swap(IList<T> collection, int index1, int index2)
        {
            if (index1 != index2)
            {
                T oldValue = collection[index1];
                collection[index1] = collection[index2];
                collection[index2] = oldValue;
            }
        }
    }
}
