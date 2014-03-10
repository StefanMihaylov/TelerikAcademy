using System;
using System.Numerics;

namespace FactorielExample
{
    class Factoriel
    {
        //Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 

        static char[] MultiplyArray(char[] number, char[] multiplier)
        {
            char[] result = { };
            char[] currentRow = NewArray(number.Length + 1);
            int product;
            for (int indexMult = 0; indexMult < multiplier.Length; indexMult++)
            {
                product = 0;
                for (int indexNum = 0; indexNum < number.Length; indexNum++)
                {
                    product += ((int)number[number.Length - indexNum - 1] - 48) * ((int)multiplier[multiplier.Length - indexMult - 1] - 48);
                    currentRow[currentRow.Length - indexNum - 1] = (char)((product % 10) + 48);
                    product /= 10;
                }
                currentRow[0] = (char)(product + 48);
                result = AddArray(result, ShiftArray(Trim(currentRow), indexMult));
            } 
            return result;                   
        }

        static char[] NewArray(int lenght)
        {
            // create new array and initialize it with zeros
            char[] result = new char[lenght];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = '0';
            }
            return result;
        }

        static char[] ShiftArray(char[] number, int position)
        {
            // create new array and copy the old one with shifted position
            char[] result = NewArray(number.Length + position);            
            for (int index = 0; index < result.Length; index++)
            {
                if (index < number.Length)
                {
                    result[index] = number[index];
                }
            }
            return result;
        } 

        static char[] AddArray(char[] number1, char[] number2)
        {
            // add two arrays
            char[] output = NewArray(Math.Max(number1.Length, number2.Length) + 1);
            int result = 0;
            for (int index = 0; index < output.Length - 1; index++)
            {
                if (index < number1.Length && index < number2.Length)
                {
                    result += ((int)number1[number1.Length - index - 1]) - 48 + ((int)number2[number2.Length - index - 1]) - 48;
                }
                else if (index < number1.Length)
                {
                    result += ((int)number1[number1.Length - index - 1]) - 48;
                }
                else
                {
                    result += (int)number2[number2.Length - index - 1] - 48;
                }
                output[output.Length - index - 1] = (char)((result % 10) + 48);
                result /= 10;
            }
            output[0] = (char)(result + 48);
            return Trim(output);
        }

        static char[] Trim(char[] number)
        {
            // remove leading zeros in the array
            int length = 0;
            for (int index = 0; index < number.Length; index++)
            {
                if (number[index] != '0')
                {
                    length = index;
                    break;
                }
            }
            int destinationLength = number.Length - length;

            char[] result = new char[destinationLength];
            Array.Copy(number, length, result, 0, destinationLength);
            return result;
        }

        static void Main()
        {
            int number = ArrayLibrary.intInput(" Enter number", 1, 100);
            char[] result = {'1'};
            for (int i = 1; i <= number; i++)
			{
                result = MultiplyArray(result, i.ToString().ToCharArray());
			}
            Console.WriteLine(" {0}! = {1}", number, string.Join("", result));
           
            // to compare the result with BigInteger
            Console.WriteLine(" Result using BigInteger");
            BigInteger fact = 1;
            for (int i = 1; i <= number; i++)
            {
                fact *= i;
            }
            Console.WriteLine(" {0}! = {1}", number, fact);
        }
    }
}
