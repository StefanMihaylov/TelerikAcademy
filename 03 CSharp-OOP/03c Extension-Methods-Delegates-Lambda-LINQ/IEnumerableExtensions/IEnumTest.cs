namespace IEnumerableExtensions
{
    using System;

    public class IEnumTest
    {
        // 2. Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

        static void Main()
        {
            int[] numbers = new int[10];
            Console.Write("Array: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
                Console.Write("{0} ",numbers[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Sum = {0}",numbers.Sum());
            Console.WriteLine("Product = {0}",numbers.Product());
            Console.WriteLine("Max = {0}",numbers.Max());
            Console.WriteLine("Min = {0}",numbers.Min());
            Console.WriteLine("Average = {0}",numbers.Average());
        }
    }
}
