using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinesOld
{
    class Lines
    {
        static void Main(string[] args)
        {
            char[,] array = new char[8, 8];
            int N;
            string binary;
            for (int i = 0; i < 8; i++)
            {
                N = int.Parse(Console.ReadLine());
                binary = Convert.ToString(N,2).PadLeft(8,'0');
                for (int j = 0; j < 8; j++)
                {
                    array[i, j] = binary[j];
                }
            }

            int[] result = new int[8];
            int counter;
            bool flag;

            for (int i = 0; i < 8; i++)
            {
                counter = 0;
                flag = false;
                for (int j = 0; j < 8; j++)
                {
                    if (flag)
                    {
                        if (array[i, j] == '1')
                        {
                            counter++;
                        }
                        else
                        {
                            flag = false;
                            if (counter > 0)
                            {
                                result[counter - 1]++;
                            }
                            counter = 0;
                        }
                    }
                    else
                    {
                        if (array[i, j] == '1')
                        {
                            flag = true;
                            counter++;                            
                        }
                    }
                }
                if (counter > 0)
                {
                    result[counter-1]++;
                }
            }
            
            for (int j = 0; j < 8; j++)
            {
                counter = 0;
                flag = false;
                for (int i = 0; i < 8; i++)
                {
                    if (flag)
                    {
                        if (array[i, j] == '1')
                        {
                            counter++;
                        }
                        else
                        {
                            flag = false;
                            if (counter > 0)
                            {
                                result[counter - 1]++;
                            }
                            counter = 0;
                        }
                    }
                    else
                    {
                        if (array[i, j] == '1')
                        {
                            flag = true;
                            counter++;
                        }
                    }
                }
                if (counter > 0)
                {
                    result[counter - 1]++;
                }
            }

            result[0] /= 2;

            int max = 0;
            int index = 0;
            for (int i = 0; i < 8; i++)
            {
                if (result[7 - i] != 0)
                {
                    index = 7 - i + 1;
                    max = result[7 - i];
                    break;
                }
            }
                          
            Console.WriteLine(index);
            Console.WriteLine(max);
        }
    }
}
