using System;
using System.Linq;

namespace MissCat
{
    class MissCat
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] arr = new int[10];
            int temp;
            for (int i = 0; i < N; i++)
            {
                temp = int.Parse(Console.ReadLine());
                arr[temp - 1]++;
            }

            int max = arr.Max();
            int result=0;
            for (int i = 0; i < 10; i++)
            {
                if (arr[i] == max)
                {
                    result = i + 1;
                    break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
