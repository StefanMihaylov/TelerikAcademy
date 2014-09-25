namespace Trees
{
    public class NodeExtended<T>
    {
        public NodeExtended(Node<T> node, T sum)
        {
            this.Node = node;
            this.Sum = sum;
        }

        public Node<T> Node { get; set; }

        public T Sum { get; set; }
    }
}
