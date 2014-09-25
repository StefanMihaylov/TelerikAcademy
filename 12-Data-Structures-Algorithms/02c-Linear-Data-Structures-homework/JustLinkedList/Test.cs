namespace JustLinkedList
{
    using System;

    public class Test
    {
        /* Implement the data structure linked list. Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>). Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).*/

        public static void Main()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            Console.WriteLine("Add last 1,2,3 => List: {0}", string.Join(", ", list));

            list.AddFirst(4);
            list.AddFirst(5);
            list.AddFirst(6);
            Console.WriteLine("Add first 4,5,6 => List: {0}", string.Join(", ", list));

            list.RemoveLast();
            Console.WriteLine("Remove last => List: {0}", string.Join(", ", list));

            list.RemoveFirst();
            Console.WriteLine("Remove first => List: {0}", string.Join(", ", list));

            list.Remove(4);
            Console.WriteLine("Remove 4 => List: {0}", string.Join(", ", list));

            list.Remove(2);
            Console.WriteLine("Remove 2 => List: {0}", string.Join(", ", list));

            list.Remove(5);
            Console.WriteLine("Remove 5 => List: {0}", string.Join(", ", list));

            list.Remove(1);
            Console.WriteLine("Remove 1 => List: {0}", string.Join(", ", list));
        }
    }
}
