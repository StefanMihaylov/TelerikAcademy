using System;

namespace Carpets
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int halfN = N / 2;

            string row;

            for (int i = 0; i < halfN; i++)
            {
                row = new string('.', halfN - i - 1);
                
                for (int j = 0; j <= i; j++)
                {
                    if (j % 2 == 0)
                    {
                        row += "/";
                    }
                    else
                    {
                        row += " ";
                    }                    
                }
                for (int j = i; j >=0; j--)
                {
                    if (j % 2 == 0)
                    {
                        row += "\\";
                    }
                    else
                    {
                        row += " ";
                    }
                }
                row += new string('.', halfN - i - 1);
                Console.WriteLine(row);
            }

            for (int i = halfN-1; i >= 0; i--)
            {
                row = new string('.', halfN - i - 1);

                for (int j = 0; j <= i; j++)
                {
                    if (j % 2 == 0)
                    {
                        row += "\\";
                    }
                    else
                    {
                        row += " ";
                    }
                }
                for (int j = i; j >= 0; j--)
                {
                    if (j % 2 == 0)
                    {
                        row += "/";
                    }
                    else
                    {
                        row += " ";
                    }
                }
                row += new string('.', halfN - i - 1);
                Console.WriteLine(row);
            }
        }
    }
}
