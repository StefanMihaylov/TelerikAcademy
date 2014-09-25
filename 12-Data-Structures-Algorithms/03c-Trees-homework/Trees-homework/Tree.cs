namespace Trees
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Tree
    {
        /* You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), each in the range (0..N-1). Write a program to read the tree and find:
        1 - the root node
        2 - all leaf nodes
        3 - all middle nodes
        4 - the longest path in the tree
        5 - * all paths in the tree with given sum S of their nodes
        6 - * all subtrees with given sum S of their nodes  */

        public static void Main()
        {
            Node<int>[] nodes = InitializeTree();

            // 1. Find the root
            var root = FindRoot(nodes);
            Console.WriteLine(" 1. The root of the tree is: {0}", root.Value);

            // 2. Find all leafs
            var leafs = FindAllLeafs(nodes);
            Console.WriteLine(" 2. eafs: {0}", string.Join(", ", leafs.Select(n => n.Value)));

            // 3. Find all middle nodes
            var middleNodes = FindAllMiddleNodes(nodes);
            Console.WriteLine(" 3. Middle nodes:  {0}", string.Join(", ", middleNodes.Select(n => n.Value)));

            // 4. Find the longest path from the root
            var longestPath = FindLongestPath(FindRoot(nodes));
            Console.WriteLine(" 4. Number of levels: {0}", longestPath + 1);

            // 5*. Find all paths in the tree with given sum S of their nodes
            int sum = 9;
            var childrenSum = FindAllPathsWithSum(root, sum);
            if (childrenSum.Count > 0)
            {
                Console.WriteLine(" 5. Path with sum {0} from root {1} to nodes {2}",
                    sum, root.Value, string.Join(" and ", childrenSum.Select(n => n.Value)));
            }
            else
            {
                Console.WriteLine(" 5. Path with sum {0} from root {1} do not exist", sum, root.Value);
            }

            // 6*. * all subtrees with given sum S of their nodes
            sum = 6;
            var subTreeRoots = FindAllSubTreesWithSum(nodes, sum);
            if (subTreeRoots.Count > 0)
            {
                Console.WriteLine(" 6. The subtrees with sum {0} start from roots {1}",
                    sum, string.Join(" and ", subTreeRoots.Select(n => n.Value)));
            }
            else
            {
                Console.WriteLine(" 6. Subtree with sum {0} do not exist", sum);
            }
        }

        private static Node<int>[] InitializeTree()
        {

            // Load data from local HDD if program is run in VS
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                Console.SetIn(new StreamReader(@"..\..\DemoTree.txt"));
            }

            var N = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[N];

            for (int i = 0; i < N; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 1; i <= N - 1; i++)
            {
                string edgeAsString = Console.ReadLine();
                var edgeParts = edgeAsString.Split(' ');

                int parentId = int.Parse(edgeParts[0]);
                int childId = int.Parse(edgeParts[1]);

                nodes[parentId].Children.Add(nodes[childId]);
                nodes[childId].HasParent = true;
            }

            return nodes;
        }

        private static Node<int> FindRoot(Node<int>[] nodes)
        {
            var hasParent = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    hasParent[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("nodes", "The tree has no root.");
        }

        private static List<Node<int>> FindAllLeafs(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static int FindLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        private static List<Node<int>> FindAllMiddleNodes(Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static List<Node<int>> FindAllPathsWithSum(Node<int> root, int sum)
        {
            List<Node<int>> result = new List<Node<int>>();

            Queue<NodeExtended<int>> queue = new Queue<NodeExtended<int>>();

            queue.Enqueue(new NodeExtended<int>(root, root.Value));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Sum == sum)
                {
                    result.Add(current.Node);
                }

                if (current.Node.Children != null)
                {
                    foreach (var child in current.Node.Children)
                    {
                        queue.Enqueue(new NodeExtended<int>(child, current.Sum + child.Value));
                    }
                }
            }

            return result;
        }

        private static List<Node<int>> FindAllSubTreesWithSum(Node<int>[] nodes, int searchedSum)
        {
            List<Node<int>> result = new List<Node<int>>();

            foreach (var node in nodes)
            {
                Queue<Node<int>> queue = new Queue<Node<int>>();
                
                queue.Enqueue(node);
                int sum = 0;
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    sum += current.Value;
                    if (current.Children != null)
                    {
                        foreach (var child in current.Children)
                        {
                            queue.Enqueue(child);
                        }
                    }
                }

                if (sum == searchedSum)
                {
                    result.Add(node);
                }
            }

            return result;
        }
    }
}
