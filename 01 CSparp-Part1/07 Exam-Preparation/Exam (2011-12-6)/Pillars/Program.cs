using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillars
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 8;
            char[,] matrix = new char[N, N];
            string input;
            for (int i = 0; i < N; i++)
            {
                input = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(N, '0');
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = input[N-j-1];
                }
            }

            int counterL;
            int counterR;
            int resultCount = 0;
            int resultIndex = 0;
            bool flag=false;
            for (int i = 0; i < N ; i++)
            {
                counterL = 0;
                counterR = 0;
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < i; k++)
                    {
                        if (matrix[j,k] == '1')
                        {
                            counterL++;
                        }
                    }
                    for (int k = i+1; k < N; k++)
                    {
                        if (matrix[j, k] == '1')
                        {
                            counterR++;
                        }
                    }
                }

                if (counterL == counterR)
                {
                    resultIndex = i;
                    resultCount = counterR;
                    flag = true;
                }
            }
            if (flag)
            {
                Console.WriteLine(resultIndex);
                Console.WriteLine(resultCount);
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
