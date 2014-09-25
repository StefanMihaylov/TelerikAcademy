using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;        

public class Program
{
    // Result: 100/100

    public const long Infinity = long.MaxValue;

    static void Main()
    {
        //// Load data from local HDD if program is run in VS
        if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
        {
            Console.SetIn(new StreamReader(@"..\..\Test3.txt"));
        }

        string[] firstRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int buildingsCount = int.Parse(firstRow[0]);
        int pathsCount = int.Parse(firstRow[1]);
        int hospitalsCount = int.Parse(firstRow[2]);

        var graph = new Graph<int>();
        var hospitals = new List<int>();

        var hospitalsIds = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < hospitalsIds.Length; i++)
        {
            hospitals.Add(int.Parse(hospitalsIds[i]));
        }

        for (int i = 0; i < pathsCount; i++)
        {
            string[] pathParts = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int firstId = int.Parse(pathParts[0]);
            int secondId = int.Parse(pathParts[1]);
            int path = int.Parse(pathParts[2]);

            graph.AddPath(firstId, secondId, path, true);
        }

        long minPath = Infinity;
        foreach (var hospitalId in hospitals)
        {
            graph.DijkstraMinPaths(hospitalId);

            long sum = 0;
            foreach (var nodePair in graph)
            {
                if (!hospitals.Contains(nodePair.Key))
                {
                    sum += nodePair.Value.MinPath;
                }
            }

            if (minPath > sum)
            {
                minPath = sum;
            }
        }

        Console.WriteLine(minPath);
    }
}

// Graph classes - Graph, Graph node and Heap

public class Graph<T> : IEnumerable<KeyValuePair<T, Node<T>>>
{
    private Dictionary<T, Node<T>> storage;

    public Graph()
    {
        this.storage = new Dictionary<T, Node<T>>();
    }

    public void AddPath(T from, T to, int path, bool bothWay)
    {
        if (!this.storage.ContainsKey(from))
        {
            this.storage[from] = new Node<T>(from);
        }

        if (!this.storage.ContainsKey(to))
        {
            this.storage[to] = new Node<T>(to);
        }

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
}

public class Node<T> : IComparable<Node<T>>, IComparable
{
    public Node(T id)
    {
        this.Value = id;
        this.Used = false;
        this.Paths = new Dictionary<T, int>();
    }

    public T Value { get; private set; }

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
