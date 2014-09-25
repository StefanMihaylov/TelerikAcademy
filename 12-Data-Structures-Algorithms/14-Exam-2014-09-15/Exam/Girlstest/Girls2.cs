using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


class Program
{
    static bool[] usedN;
    static bool[] usedL;

    static void Main()
    {
        // Load data from local HDD if program is run in VS
        if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
        {
            Console.SetIn(new StreamReader(@"..\..\Test3.txt"));
        }

        int shirtsNumber = int.Parse(Console.ReadLine());
        string skirtString = Console.ReadLine();
        int girls = int.Parse(Console.ReadLine());

        var array = new int[girls * 2];

        char[] skirts = skirtString.ToArray();
        //Array.Sort(skirts);

        usedN = new bool[shirtsNumber];
        usedL = new bool[skirts.Length];

        var firstResult = new SortedSet<string>();

        Action action = () => { firstResult.Add(PrintVariations(array, skirts)); };

        GenerateCombinationsNoRepetitions(shirtsNumber, array, skirts, 0, action);

        var result = new SortedSet<string>();

        foreach (var item in firstResult)
        {
            var normal = item;
            string[] parts = normal.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                string reversed = string.Format("{0}-{1}", parts[1], parts[0]);
                if (!result.Contains(normal) && !result.Contains(reversed))
                {
                    result.Add(normal);
                }
            }
            else if (parts.Length == 3)
            {
                string reversed1 = string.Format("{0}-{1}-{2}", parts[0], parts[2], parts[1]);
                string reversed2 = string.Format("{0}-{1}-{2}", parts[1], parts[0], parts[2]);
                string reversed3 = string.Format("{0}-{1}-{2}", parts[1], parts[2], parts[0]);
                string reversed4 = string.Format("{0}-{1}-{2}", parts[2], parts[1], parts[0]);
                string reversed5 = string.Format("{0}-{1}-{2}", parts[2], parts[0], parts[1]);

                if (!result.Contains(normal) && !result.Contains(reversed1)&& 
                    !result.Contains(reversed2)&& !result.Contains(reversed3)&& 
                    !result.Contains(reversed4) && !result.Contains(reversed5))
                {
                    result.Add(normal);
                }
            }
            else
            {
                result.Add(normal);
            }
        }

        Console.WriteLine(result.Count);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }

    static void GenerateCombinationsNoRepetitions(int allItems, IList<int> arr, IList<char> objects,
        int index, Action action)
    {
        if (index >= arr.Count)
        {
            action();
        }
        else
        {
            for (int i = 0; i < allItems; i++)
            {
                if (!usedN[i])
                {
                    arr[index] = i;
                    usedN[i] = true;
                    index++;

                    for (int j = 0; j < objects.Count; j++)
                    {
                        if (!usedL[j])
                        {
                            arr[index] = j;
                            usedL[j] = true;
                            GenerateCombinationsNoRepetitions(allItems, arr, objects, index + 1, action);
                            usedL[j] = false;
                        }
                    }

                    index--;
                    usedN[i] = false;
                }
            }
        }
    }

    static string PrintVariations(IList<int> arr, IList<char> objects)
    {
        // Console.Write(string.Join(",", arr));
        // Console.Write(" - ");

        int dashes = arr.Count / 2 - 1;
        char[] result = new char[arr.Count + dashes];
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
                if (i < arr.Count - 1)
                {
                    index++;
                    result[index] = '-';
                }
            }

            index++;
        }

        // Console.WriteLine(new string(result));
        return new string(result);
    }
}
