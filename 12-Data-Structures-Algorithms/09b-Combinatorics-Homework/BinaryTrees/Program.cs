namespace BinaryTrees
{
    using System;
    using System.Collections.Generic;

    // result: 65 / 100 - time limit :(

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();

            var permutations = NumberOfpermutations(input);
            //Console.WriteLine(permutations);

            //var combinations = NumberOfTreeCombinations(input.Length);
            // Console.WriteLine(combinations);

            var numbers = new long[input.Length + 1];
            numbers[0] = 1;
            for (int i = 1; i < numbers.Length; i++)
            {
                long sum = 0;
                for (int j = 0; j < i; j++)
                {
                    sum += numbers[j] * numbers[i - j - 1];
                }
                numbers[i] = sum;
            }

            var treeCcombinations = numbers[input.Length];
            Console.WriteLine(treeCcombinations);

            Console.WriteLine(treeCcombinations * permutations);
        }

        private static long NumberOfpermutations(char[] input)
        {
            Array.Sort(input);
            long counter = 0;
            PermuteRep(input, 0, ref counter);

            return counter;
        }

        static void PermuteRep(char[] arr, int start, ref long counter)
        {
            counter++;
            //Console.WriteLine(new string(arr));

            int n = arr.Length;
            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(arr, left, right);
                        PermuteRep(arr, left + 1, ref counter);
                    }
                }

                var firstelement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[n - 1] = firstelement;
            }
        }

        private static void Swap<T>(T[] arr, int left, int right)
        {
            T oldValue = arr[left];
            arr[left] = arr[right];
            arr[right] = oldValue;
        }
/*
        private static int NumberOfTreeCombinations(int maxNumber)
        {
            int counter = 0;
            var root = new TreeNode<string>();
            TreeCombinations(root, 0, maxNumber, ref counter, "T");
            return counter;
        }

        private static void TreeCombinations(TreeNode<string> node, int index, int maxIndex, ref int count, string symbol)
        {
            if (index >= maxIndex)
            {
                Console.WriteLine(symbol);
                count++;
                return;
            }

            node.Value = symbol;
            node.Left = new TreeNode<string>();
            node.Right = new TreeNode<string>();

            index++;
            TreeCombinations(node.Left, index, maxIndex, ref count, node.Value + 'L');
            TreeCombinations(node.Right, index, maxIndex, ref count, node.Value + 'R');
            index--;
        }

        public class TreeNode<T>
        {
            public T Value { get; set; }

            public TreeNode<T> Left { get; set; }

            public TreeNode<T> Right { get; set; }
        }*/
    }
}
