namespace SequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class SequenceWithQueue
    {
        /*   We are given the following sequence:
            S1 = N; 
            S2 = S1 + 1; S3 = 2*S1 + 1; S4 = S1 + 2;
            S5 = S2 + 1; S6 = 2*S2 + 1; S7 = S2 + 2; ...
        Using the Queue<T> class write a program to print its first 50 members for given N.
         Example: N=2 => 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ... */

        public static void Main()
        {
            Queue<int> queue = new Queue<int>();

            int startNumber = 2;
            int maxCount = 50;

            queue.Enqueue(startNumber);

            Console.WriteLine("{0} members starting from {1}.", maxCount, startNumber);
            Console.Write("Result: ");
            for (int i = 0; i < maxCount; i++)
            {
                int current = queue.Dequeue();
                Console.Write("{0}, ", current);

                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
            }
            Console.Write("...");
            Console.WriteLine();
        }
    }
}
