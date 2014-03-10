using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumber
{
    class Program
    {

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            
            //long[] number = new long[N];
            //int[] count = new int[N];

           List<long> number = new List<long>();
           List<int> count = new List<int>();
 
            long current;
            bool flag;
            //int maxArray = 0;
            for (int i = 0; i < N; i++)
            {
                current = long.Parse(Console.ReadLine());
                flag = false;
                for (int j = 0; j < number.Count; j++)
                {
                    if (number[j] == current)
                    {
                        count[j]++;
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    number.Add(current);
                    count.Add(1);
                }
            }

            long result = 0;
            for (int i = 0; i < number.Count; i++)
            {
                if (count[i]%2==1)
                {
                    result = number[i];
                    break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
