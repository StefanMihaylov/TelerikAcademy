using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    // You are given a cable TV company. The company needs to lay cable to a new neighborhood (for every house). If it is constrained to bury the cable only along certain paths, then there would be a graph representing which points are connected by those paths. But the cost of some of the paths is more expensive because they are longer. If every house is a node and every path from house to house is an edge, find a way to minimize the cost for cables

    public static void Main()
    {
        var graph = new Graph<int>();
        graph.AddPath(1, 2, 14);
        graph.AddPath(1, 3, 16);
        graph.AddPath(2, 4, 14);
        graph.AddPath(1, 5, 18);
        graph.AddPath(2, 6, 9);
        graph.AddPath(3, 6, 8);
        graph.AddPath(3, 4, 14);
        graph.AddPath(7, 8, 9);
        graph.AddPath(4, 7, 15);
        graph.AddPath(4, 8, 11);
        graph.AddPath(9, 10, 7);
        graph.AddPath(1, 10, 12);
        graph.AddPath(3, 9, 11);
        graph.AddPath(8, 11, 8);
        graph.AddPath(11, 12, 12);
        graph.AddPath(9, 12, 17);
        graph.AddPath(5, 10, 13);
        graph.AddPath(6, 12, 15);
        graph.AddPath(7, 13, 7);
        graph.AddPath(8, 13, 10);
        graph.AddPath(11, 13, 13);
        graph.AddPath(7, 12, 12);
        graph.AddPath(11, 14, 7);
        graph.AddPath(12, 14, 10);

        // graph.Print();
        // Console.WriteLine("----------------------");
        var tree = graph.PrimMinimumTree(2);
        //tree.Print();
        long sum = SumPath(tree);
        Console.WriteLine("Minimal cable length is {0} m", sum);


        // https://www.youtube.com/watch?v=YyLaRffCdk4
        Console.WriteLine("\n Second example:");

        var secGraph = new Graph<char>();
        secGraph.AddPath('A', 'B', 2);
        secGraph.AddPath('A', 'G', 4);
        secGraph.AddPath('B', 'C', 4);
        secGraph.AddPath('B', 'D', 2);
        secGraph.AddPath('B', 'G', 6);
        secGraph.AddPath('C', 'D', 3);
        secGraph.AddPath('D', 'E', 5);
        secGraph.AddPath('D', 'F', 3);
        secGraph.AddPath('E', 'F', 3);
        secGraph.AddPath('E', 'H', 4);
        secGraph.AddPath('F', 'H', 4);
        secGraph.AddPath('F', 'G', 5);
        secGraph.AddPath('G', 'I', 2);
        secGraph.AddPath('H', 'I', 3);

        //secGraph.Print();
        //Console.WriteLine("----------------------");
        var secondTree = secGraph.PrimMinimumTree('H');
        // secondTree.Print();

        sum = SumPath(secondTree);
        Console.WriteLine("Minimal cable length is {0} m", sum);
    }

    private static long SumPath<T>(Graph<T> tree)
    {
        long sum = 0;
        foreach (var pair in tree)
        {
            foreach (var path in pair.Value.Paths.Values)
            {
                sum += path;
            }
        }
        return sum;
    }
}

// Graph classes - Graph, Graph node, Path and Heap

public class Graph<T> : IEnumerable<KeyValuePair<T, Node<T>>>
{
    private Dictionary<T, Node<T>> storage;

    public Graph()
    {
        this.storage = new Dictionary<T, Node<T>>();
    }

    public void AddNode(T value)
    {
        if (!this.storage.ContainsKey(value))
        {
            this.storage[value] = new Node<T>(value);
        }
    }

    public void AddPath(T from, T to, int path, bool bothWay = true)
    {
        this.AddNode(from);
        this.AddNode(to);
        this.storage[from].AddPath(to, path);

        if (bothWay)
        {
            this.storage[to].AddPath(from, path);
        }
    }

    public Node<T> FindId(T id)
    {
        return this.storage[id];
    }

    public IEnumerator<KeyValuePair<T, Node<T>>> GetEnumerator()
    {
        foreach (var pair in this.storage)
        {
            yield return pair;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Print()
    {
        foreach (var pair in this.storage)
        {
            Console.Write("{0} = {1} => ", pair.Key, pair.Value.MinPath);
            foreach (var node in pair.Value.Paths)
            {
                Console.Write("{0}-{1}; ", node.Key, node.Value);
            }
            Console.WriteLine();
        }
    }

    public void DijkstraMinPaths(T startId)
    {
        this.ResetGraph(startId);
        var queue = new MinPriorityQueue<Node<T>>();

        var startNode = this.FindId(startId);
        queue.Enqueue(startNode);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();

            if (!currentNode.Used)
            {
                currentNode.Used = true;
                foreach (var pathPair in currentNode.Paths)
                {
                    var nextNode = this.FindId(pathPair.Key);
                    if (!nextNode.Used)
                    {
                        var newMinPath = currentNode.MinPath + pathPair.Value;
                        if (newMinPath < nextNode.MinPath)
                        {
                            nextNode.MinPath = newMinPath;
                            queue.Enqueue(nextNode);
                        }
                    }
                }
            }
        }
    }

    private void ResetGraph(T startId)
    {
        foreach (var node in this.storage)
        {
            if (node.Key.Equals(startId))
            {
                node.Value.MinPath = 0;
                node.Value.Used = false;
            }
            else
            {
                node.Value.MinPath = int.MaxValue;
                node.Value.Used = false;
            }
        }
    }

    public Graph<T> PrimMinimumTree(T start)
    {
        var tree = new Graph<T>();
        var heap = new MinPriorityQueue<Path<T>>();

        var currentNode = this.FindId(start);
        tree.AddNode(start);
        foreach (var path in currentNode.Paths)
        {
            heap.Enqueue(new Path<T>(currentNode.Name, path));
        }
        currentNode.Used = true;

        while (heap.Count > 0)
        {
            var minPath = heap.Dequeue();
            var newNode = minPath.NextNode;
            currentNode = this.FindId(newNode);

            if (!currentNode.Used)
            {
                tree.AddPath(minPath.PrevNode, newNode, minPath.Distance, false);

                foreach (var path in currentNode.Paths)
                {
                    heap.Enqueue(new Path<T>(currentNode.Name, path));
                }
                currentNode.Used = true;
            }
        }

        return tree;
    }
}

public class Node<T> : IComparable<Node<T>>, IComparable
{
    public Node(T id)
    {
        this.Name = id;
        this.Used = false;
        this.Paths = new Dictionary<T, int>();
    }

    public T Name { get; private set; }

    public int MinPath { get; set; }

    public bool Used { get; set; }

    public Dictionary<T, int> Paths { get; set; }

    public void AddPath(T nodeId, int distance)
    {
        this.Paths.Add(nodeId, distance);
    }

    public int CompareTo(Node<T> other)
    {
        return this.MinPath.CompareTo(other.MinPath);
    }

    public int CompareTo(object obj)
    {
        return this.MinPath.CompareTo((obj as Node<T>).MinPath);
    }
}

public class MinPriorityQueue<T> where T : IComparable<T>
{
    private const int InitialCapacity = 16;
    private T[] storage;

    public MinPriorityQueue()
    {
        this.storage = new T[InitialCapacity];
        this.Count = 0;
    }

    public int Count
    {
        get;
        private set;
    }

    public void Clear()
    {
        this.storage = new T[this.storage.Length];
        this.Count = 0;
    }

    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return this.storage[0];
    }

    public void Enqueue(T element)
    {
        this.storage[this.Count] = element;
        CheckParentPosition(this.Count);
        this.Count++;
        if (this.Count >= this.storage.Length)
        {
            DoubleTheStorageSize();
        }
    }

    public T Dequeue()
    {
        T result = this.Peek();

        if (this.Count > 1)
        {
            T last = this.storage[this.Count - 1];
            this.storage[0] = last;
        }

        this.storage[this.Count - 1] = default(T);
        this.Count--;

        RearrangeTheHeap(0);

        return result;
    }

    public override string ToString()
    {
        return string.Join(", ", this.storage);
    }

    private void DoubleTheStorageSize()
    {
        var cashedStorage = this.storage;
        this.storage = new T[2 * cashedStorage.Length];
        for (int i = 0; i < cashedStorage.Length; i++)
        {
            this.storage[i] = cashedStorage[i];
        }
    }

    private void CheckParentPosition(int childIndex)
    {
        int parentIndex = (int)Math.Floor((double)(childIndex - 1) / 2);
        if (parentIndex >= 0)
        {
            T parent = this.storage[parentIndex];
            T child = this.storage[childIndex];
            if (parent.CompareTo(child) > 0)
            {
                this.storage[parentIndex] = child;
                this.storage[childIndex] = parent;
                CheckParentPosition(parentIndex);
            }
        }
    }

    private void RearrangeTheHeap(int parentTndex)
    {
        int leftChildIndex = 2 * parentTndex + 1;
        int rightChildIndex = leftChildIndex + 1;
        int largestIndex = parentTndex;

        if (leftChildIndex < this.Count)
        {
            T leftChild = this.storage[leftChildIndex];
            T largest = this.storage[largestIndex];
            if (largest.CompareTo(leftChild) > 0)
            {
                largestIndex = leftChildIndex;
            }
        }

        if (rightChildIndex < this.Count)
        {
            T rightChild = this.storage[rightChildIndex];
            T largest = this.storage[largestIndex];
            if (largest.CompareTo(rightChild) > 0)
            {
                largestIndex = rightChildIndex;
            }
        }

        if (largestIndex != parentTndex)
        {
            T parent = this.storage[parentTndex];
            this.storage[parentTndex] = this.storage[largestIndex];
            this.storage[largestIndex] = parent;

            RearrangeTheHeap(largestIndex);
        }
    }

    public string Print(Func<T, object> action)
    {
        return string.Join("|", this.storage.Where(a => a != null).Select(action));
    }
}

public class Path<T> : IComparable<Path<T>>
{
    public Path(T prev, T next, int path)
    {
        this.PrevNode = prev;
        this.NextNode = next;
        this.Distance = path;
    }

    public Path(T prevNode, KeyValuePair<T, int> path)
        : this(prevNode, path.Key, path.Value)
    {
    }

    public T PrevNode { get; set; }

    public T NextNode { get; set; }

    public int Distance { get; set; }

    public int CompareTo(Path<T> other)
    {
        return this.Distance.CompareTo(other.Distance);
    }
}
