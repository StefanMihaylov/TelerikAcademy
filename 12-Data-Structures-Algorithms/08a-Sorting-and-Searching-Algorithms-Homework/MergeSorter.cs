namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var result = MergeSort(collection).ToList();

            // workaround for private setter of this.Items
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = result[i];
            }
        }

        private ICollection<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            var left = new List<T>();
            var right = new List<T>();

            int midleIndex = collection.Count / 2;
            for (int i = 0; i < collection.Count; i++)
            {
                if (i < midleIndex)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            left = MergeSort(left).ToList();
            right = MergeSort(right).ToList();

            return Merge(left, right);
        }

        private ICollection<T> Merge(IList<T> left, IList<T> right)
        {
            ICollection<T> result = new List<T>();

            int leftPointer = 0;
            int rightPointer = 0;

            while (leftPointer < left.Count || rightPointer < right.Count)
            {
                if (leftPointer < left.Count && rightPointer < right.Count)
                {
                    T firstLeft = left[leftPointer];
                    T firstRight = right[rightPointer];

                    if (firstLeft.CompareTo(firstRight) <= 0)
                    {
                        result.Add(firstLeft);
                        leftPointer++;
                    }
                    else
                    {
                        result.Add(firstRight);
                        rightPointer++;
                    }
                }
                else if (leftPointer < left.Count)
                {
                    T firstLeft = left[leftPointer];
                    result.Add(firstLeft);
                    leftPointer++;
                }
                else if (rightPointer < right.Count)
                {
                    T firstRight = right[rightPointer];
                    result.Add(firstRight);
                    rightPointer++;
                }
            }

            return result;
        }
    }
}
