using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariationWithoutRecursion
{
    class Variations
    {
        // Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. 
        // Example: N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

        static void Main()
        {
            Console.Write(" Enter number N: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write(" Enter number K: ");
            int K = int.Parse(Console.ReadLine());

            int[] array = new int[K];

            // initialize first variation 
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 1;
            }


            int index = array.Length - 1;
            int oldValue = 0;
            while (true)
            {
                Print(array);
                while (index >= 0 && array[index] == N)
                {
                    oldValue = array[index];
                    array[index] = 1;
                    index--;
                }
                if (index == -1 && oldValue == N)
                {
                    break;
                }
                array[index]++;
                index = array.Length - 1;
            }
        }

        static void Print(int[] array)
        {
            //print the array
            Console.Write("{");
            for (int i = 0; i < array.Length; i++)
            {
                if (i != (array.Length - 1))
                {
                    Console.Write("{0}, ", array[i]);
                }
                else
                {
                    Console.WriteLine("{0}{1}", array[i], "}");
                }
            }
        }
    }
}
