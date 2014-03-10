namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static T Sum<T>(this IEnumerable<T> collection) where T : struct, IConvertible, IComparable<T>
        {
            T result = default(T);
            foreach (var element in collection)
            {
                result += (dynamic)element;
            }
            return result;
        }

        public static decimal Average<T>(this IEnumerable<T> collection) where T : struct, IConvertible, IComparable<T>
        {
            decimal result = 0;
            int counter = 0;
            foreach (var element in collection)
            {
                result += (dynamic)element;
                counter++;
            }
            return result/counter;
        }

        public static T Product<T>(this IEnumerable<T> collection) where T : struct, IConvertible, IComparable<T>
        {
            dynamic result = 1;
            foreach (var element in collection)
            {
                result *= (dynamic)element;
            }
            return result;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            T min = collection.First();
            foreach (var element in collection)
            {
                if (element.CompareTo(min) < 0)
                {
                    min = element;
                }
            }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            T max = collection.First();
            foreach (var element in collection)
            {
                if (element.CompareTo(max) > 0)
                {
                    max = element;
                }
            }
            return max;
        }
    }
}
