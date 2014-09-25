namespace JustQueue
{
    using System;

    public class Test
    {
        /* Implement the ADT queue as dynamic linked list. Use generics (LinkedQueue<T>) to allow storing different data types in the queue */

        public static void Main()
        {
            JustQueue<int> queue = new JustQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine("Enqueue 1,2,3,4 => Queue: {0}", string.Join(", ", queue));

            queue.Enqueue(5);
            queue.Enqueue(6);
            Console.WriteLine("Enqueue 5,6 => Queue: {0}", string.Join(", ", queue));

            int value = queue.Dequeue();
            Console.WriteLine("Dequeue: {1} => Queue: {0}", string.Join(", ", queue), value);
            value = queue.Dequeue();
            Console.WriteLine("Dequeue: {1} => Queue: {0}", string.Join(", ", queue), value);
            value = queue.Dequeue();
            Console.WriteLine("Dequeue: {1} => Queue: {0}", string.Join(", ", queue), value);

            value = queue.Peek();
            Console.WriteLine("Peek: {1} => Queue: {0}", string.Join(", ", queue), value);

            queue.Clear();
            Console.WriteLine("Clear => Queue: {0}", string.Join(", ", queue));
        }
    }
}
