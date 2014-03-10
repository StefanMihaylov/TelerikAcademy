using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Indices
{
    static void Main()
    {
        // Load data from local HDD if program is run in VS
        //bool debugPrint = false;
        if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
        {
            Console.SetIn(new StreamReader(@"..\..\Input.txt"));
            //debugPrint = true;
        }

        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];

        string[] inputNumbers = Console.ReadLine().Split(' ');

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(inputNumbers[i]);
        }

        bool[] visited = new bool[array.Length];
        StringBuilder result = new StringBuilder();

        int loopStart = -1;

        int index = 0;
        visited[index] = true;
        result.Append(index);
        result.Append(' ');
        while (true)
        {
            index = array[index];
            if (index < 0 || index >= array.Length)
            {
                break;
            }

            if (!visited[index])
            {
                visited[index] = true;
                result.Append(index);
                result.Append(' ');
            }
            else
            {
                loopStart = index;
                break;
            }
        }

        if (loopStart != -1)
        {            
            if (loopStart != 0)
            {
                int startIndex = result.ToString().IndexOf(string.Format("{0} ",loopStart));
                result[startIndex - 1] = '(';
            }
            else
            {
                result.Insert(loopStart, '(');
            }
            result[result.Length - 1] = ')';

        }

        Console.WriteLine(result.ToString().Trim());
    }
}

