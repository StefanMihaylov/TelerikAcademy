namespace JustLinkedList
{
    using System;

    public class LinkedList<T> : System.Collections.Generic.IEnumerable<T> where T : IComparable<T>
    {
        private LinkedListNode<T> Head { get; set; }

        private LinkedListNode<T> Tail { get; set; }

        public void AddLast(T value)
        {
            var newNode = new LinkedListNode<T>();
            newNode.Value = value;

            if (this.Head == null && this.Tail == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                this.Tail.Next = newNode;
                this.Tail = newNode;
            }
        }

        public void AddFirst(T value)
        {
            var newNode = new LinkedListNode<T>();
            newNode.Value = value;

            if (this.Head == null && this.Tail == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                newNode.Next = this.Head;
                this.Head = newNode;
            }
        }

        public void RemoveLast()
        {
            if (this.Tail == null)
            {
                throw new Exception("No elements in the linked list");
            }

            LinkedListNode<T> current = this.Head;
            while (current.Next != null && current.Next != this.Tail)
            {
                current = current.Next;
            }

            this.Tail = current;
            this.Tail.Next = null;
        }

        public void RemoveFirst()
        {
            if (this.Head == null)
            {
                throw new Exception("No elements in the linked list");
            }

            this.Head = this.Head.Next;
        }

        public void Remove(T value)
        {
            if (this.Head == null)
            {
                throw new Exception("No elements in the linked list");
            }

            if (this.Head == this.Tail)
            {
                if (this.Head.Value.Equals(value))
                {
                    this.Clear();
                }
            }
            else
            {
                LinkedListNode<T> current = this.Head;
                LinkedListNode<T> previous = null;

                while (current.Next != null)
                {
                    if (current.Value.Equals(value))
                    {
                        // first element
                        if (previous == null)
                        {
                            this.Head = this.Head.Next;
                        }
                        else
                        {
                            previous.Next = current.Next;                         
                        }

                        break;
                    }

                    previous = current;
                    current = current.Next;

                    // last element                            
                    if (current == this.Tail)
                    {
                        this.Tail = previous;
                        previous.Next = null;
                    }
                }
            }   
        }

        public void Clear()
        {
            this.Head = null;
            this.Tail = null;
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            var node = this.Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
