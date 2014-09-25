namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        // Implement a class PriorityQueue<T> based on the data structure "binary heap".

        public static void Main()
        {
            var queue = new PriorityQueue<int>();

            queue.Enqueue(3);
            Console.WriteLine("Queue: {0}", queue);
            queue.Enqueue(4);
            Console.WriteLine("Queue: {0}", queue);
            queue.Enqueue(5);
            Console.WriteLine("Queue: {0}", queue);
            queue.Enqueue(8);
            Console.WriteLine("Queue: {0}", queue);
            queue.Enqueue(11);
            Console.WriteLine("Queue: {0}", queue);
            queue.Enqueue(15);
            Console.WriteLine("Queue: {0}", queue);

            Console.WriteLine("Peek element: {0}", queue.Peek());
            Console.WriteLine("Count: {0}", queue.Count);

            while (queue.Count > 0)
            {
                Console.WriteLine("largest element: {0}, Queue: {1}", queue.Dequeue(), queue);
            }

            // queue.Dequeue(); throw exception
        }
    }
}
