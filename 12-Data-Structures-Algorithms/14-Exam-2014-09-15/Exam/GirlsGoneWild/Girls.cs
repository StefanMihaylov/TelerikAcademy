using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GirlsGoneWild
{
    class Girls
    {
        static bool[] useN;
        static bool[] useL;

        static void Main()
        {
            // Load data from local HDD if program is run in VS
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                Console.SetIn(new StreamReader(@"..\..\Test.txt"));
            }

            int shirtsNumber = int.Parse(Console.ReadLine());
            string skirtString = Console.ReadLine();
            int girls = int.Parse(Console.ReadLine());

            var array = new int[4];

            char[] skirts = skirtString.ToArray();
            Array.Sort(skirts);

            useN = new bool[shirtsNumber];
            useL = new bool[skirts.Length];

            var result = new SortedSet<string>();

            Action action = () => { result.Add(PrintVariations(array, skirts)); };

            GenerateCombinationsNoRepetitions(shirtsNumber, array, skirts, 0, 0, 0, action);

            Console.WriteLine(result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }


        static void GenerateCombinationsNoRepetitions(int allItems, IList<int> arr, IList<char> objects,
            int index, int start1, int start2, Action action)
        {
            if (index >= arr.Count)
            {
                action();
            }
            else
            {
                for (int i = start1; i < allItems; i++)
                {
                    arr[index] = i;
                    index++;
                    for (int j = start2; j < objects.Count; j++)
                    {
                        arr[index] = j;
                        GenerateCombinationsNoRepetitions(allItems, arr, objects, index + 1, i + 1, j + 1, action);
                    }

                    index--;
                }
            }
        }

        static string PrintVariations(IList<int> arr, IList<char> objects)
        {
            Console.Write(string.Join(",", arr));
            Console.Write(" - ");

            char[] result = new char[arr.Count + 1];
            int index = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (i % 2 == 0)
                {
                    result[index] = arr[i].ToString()[0];
                }
                else
                {
                    result[index] = objects[arr[i]];
                }

                index++;
                if (i == 1)
                {
                    result[index] = '-';
                    index++;
                }

            }

            Console.WriteLine(new string(result));
            return new string(result);
        }
    }
}
