namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
        }

        // in-place sorting
        private void QuickSort(IList<T> collection, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int pivotIndex = leftIndex + (rightIndex - leftIndex - 1) / 2;
                Swap(collection, pivotIndex, rightIndex);
                T pivot = collection[rightIndex];

                int storeIndex = leftIndex;
                for (int i = leftIndex; i < rightIndex; i++)
                {
                    if (collection[i].CompareTo(pivot) < 0)
                    {
                        Swap(collection, i, storeIndex);
                        storeIndex++;
                    }
                }

                Swap(collection, storeIndex, rightIndex);

                QuickSort(collection, leftIndex, storeIndex - 1);
                QuickSort(collection, storeIndex + 1, rightIndex);
            }
        }

        // second implementation with new lists
        private IEnumerable<T> QuickSort2(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            T pivot = collection[(collection.Count - 1) / 2];

            IList<T> less = new List<T>();
            IList<T> equal = new List<T>();
            IList<T> greater = new List<T>();

            foreach (var item in collection)
            {
                if (item.CompareTo(pivot) < 0)
                {
                    less.Add(item);
                }
                else if (item.CompareTo(pivot) > 0)
                {
                    greater.Add(item);
                }
                else
                {
                    equal.Add(item);
                }
            }

            var left = QuickSort2(less);
            var right = QuickSort2(greater);
            var result = left.Concat(equal).Concat(right);
            return result;
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
