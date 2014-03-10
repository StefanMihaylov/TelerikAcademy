using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tubes
{
    static void Main()
    {
        int numberOfTubes = int.Parse(Console.ReadLine());
        int pieces = int.Parse(Console.ReadLine());
        List<long> tubes = new List<long>();
        for (int i = 0; i < numberOfTubes; i++)
        {
            tubes.Add(long.Parse(Console.ReadLine()));
        }

        long min = 1;
        long result = CutTubes(tubes, min);
        if (result < pieces)
        {
            Console.WriteLine(-1);
            return;
        }

        long max = tubes.Max();
        result = CutTubes(tubes, max);
        if (result >= pieces)
        {
            Console.WriteLine(max);
            return;
        }

        long length = 0;
        while ((min+1) != max)
        {
            length = (max + min) / 2;
            result = CutTubes(tubes, length);
            if (result < pieces)
            {
                max = length;
            }
            else //if (result > pieces)
            {
                min = length;
            }
        }

        if (CutTubes(tubes, max) >= pieces)
        {
            Console.WriteLine(max);
        }
        else
        {
            Console.WriteLine(min);
        }
    }

    static long CutTubes(List<long> tubes, long length)
    {
        long counter = 0;
        for (int i = 0; i < tubes.Count; i++)
        {
            counter += tubes[i] / length;
        }
        return counter;
    }
}

