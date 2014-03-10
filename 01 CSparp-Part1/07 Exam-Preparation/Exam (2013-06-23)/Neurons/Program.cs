using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurons
{
    class Program
    {
        static void Main()
        {
            int maxInt = 32;
            char[,] matrix = new char[maxInt, maxInt];
            string currentString;
            uint currentNumber;
            string currentBinary;
            int maxInput = 0;
            for (int i = 0; i < maxInt; i++)
            {
                currentString = Console.ReadLine();
                if (currentString.Equals("-1"))
                {
                    break;
                }                
                currentNumber = uint.Parse(currentString);
                maxInput = i + 1;
                currentBinary = Convert.ToString(currentNumber, 2).PadLeft(maxInt, '0');
                for (int j = 0; j < maxInt; j++)
                {
                    matrix[i, j] = currentBinary[maxInt-j-1];
                }
            }

            int leftBorder;
            int rightBorder;
            for (int i = 0; i < maxInput; i++)
            {
                rightBorder = 0;
                while ((rightBorder < maxInt) && (matrix[i, rightBorder] == '0'))
                {
                    rightBorder++;
                }
                leftBorder = maxInt-1;
                while ((leftBorder >= 0) && (matrix[i, leftBorder] == '0'))
                {
                    leftBorder--;
                }
                //Console.WriteLine("{0}>{1}",leftBorder,rightBorder);
                if (leftBorder>rightBorder)
                {
                    for (int j = rightBorder; j <= leftBorder; j++)
                    {
                        if (matrix[i,j]=='1')
                        {
                            matrix[i,j]='0';
                        }
                        else
                        {
                            matrix[i, j] = '1';
                        }
                    }
                }
            }

            uint result;
            uint mulitiplier;
            for (int i = 0; i < maxInput; i++)
            {
                result = 0;
                mulitiplier = 1;
                for (int j = 0; j < maxInt; j++)
                {
                    if (matrix[i, j] == '1')
                    {
                        result += mulitiplier;
                    }
                    mulitiplier *= 2;
                }
                Console.WriteLine(result);
            }
        }
    }
}
