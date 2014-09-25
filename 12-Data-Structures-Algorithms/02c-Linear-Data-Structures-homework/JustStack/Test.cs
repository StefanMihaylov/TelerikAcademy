namespace JustStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Test
    {
        /*  Implement the ADT stack as auto-resizable array. Resize the capacity on demand (when no space is available to add / insert a new element). */

        public static void Main()
        {
            JustStack<int> stack = new JustStack<int>();
            int value;

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            Console.WriteLine("Push 1,2,3,4 => Stack: {0} | Capacity: {1}", string.Join(", ", stack),stack.Capacity);

            value = stack.Pop();
            Console.WriteLine("Pop: {1} => Stack: {0}", string.Join(", ", stack), value);

            value = stack.Peek();
            Console.WriteLine("Peek: {1} => Stack: {0}", string.Join(", ", stack), value);

            stack.Push(5);
            stack.Push(6);
            Console.WriteLine("Push 5, 6 => Stack: {0} | Capacity: {1}", string.Join(", ", stack), stack.Capacity);

            stack.Push(7);
            Console.WriteLine("Push 7 => Stack: {0} | Capacity: {1}", string.Join(", ", stack), stack.Capacity);

            stack.Clear();
            Console.WriteLine("Clear => Stack: {0} | Capacity: {1}", string.Join(", ", stack), stack.Capacity);
        }
    }
}
