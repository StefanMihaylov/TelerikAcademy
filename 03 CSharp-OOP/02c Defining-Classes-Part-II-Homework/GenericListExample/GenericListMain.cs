namespace GenericListExample
{
    using System;

    class GenericListMain
    {
        /*
        5. Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. Keep the elements of 
	        the list in an array with fixed capacity which is given as parameter in the class constructor. 
	        Implement methods for adding element, accessing element by index, removing element by index, inserting element at 
	        given position, clearing the list, finding element by its value and ToString(). Check all input parameters to avoid 
	        accessing elements at invalid positions.
        6. Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all 
	        elements to it.
        7. Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>. 
	        You may need to add a generic constraints for the type T. */

        static void Main()
        {
            GenericList<int> list = new GenericList<int>(2);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(-10);
            Console.WriteLine("List: {0}", list);

            list.RemoveAt(3);
            Console.WriteLine("Remove element at index 3");
            Console.WriteLine("List: {0}", list);

            list.InsertAt(2, 321);
            Console.WriteLine("Insert element 321 at index 2");
            Console.WriteLine("List: {0}", list);

            Console.WriteLine("Find element 4 => index: {0}", list.FindFirst(4));

            Console.WriteLine("Min element: {0}; Max element: {1}", list.Min(), list.Max());

            list.Clear();
            Console.WriteLine("Clear Elements");
            Console.WriteLine("List: {0}", list);

            // check exceptions
            //list.RemoveAt(10);
            //list.RemoveAt(-1);
        }
    }
}
