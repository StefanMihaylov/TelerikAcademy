using System;

namespace AddNumbersExample
{
    class AddNumbers
    {
        // Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]). Each of the numbers that will be added could have up to 10 000 digits.

        public static char[] BigNumberInput(string text)
        {
            // Enter int and convert it to char array
            string inputValue;
            while (true)
            {
                Console.Write("{0}", text);
                inputValue = Console.ReadLine();
                inputValue.Trim();
                bool error = false;

                if (inputValue.Length > 0)
                {
                    char[] output = new char[inputValue.Length];
                    for (int index = 0; index < inputValue.Length; index++)
                    {
                        if (inputValue[index]>='0' && inputValue[index]<='9')
                        {
                            output[inputValue.Length - index - 1] = inputValue[index];
                        }
                        else
                        {
                            error = true;
                            break;
                        }
                    }
                    if (!error)
                    {
                        return output;
                    }                    
                }
                else
                {
                    error = true;
                }

                if (error)
                {
                    Console.WriteLine("\t Invalid value! Try again!");
                }
            }
        }

        public static char[] AddBigNumber(char[] number1, char[] number2)
        {
            char[] output = new char[Math.Max(number1.Length, number2.Length)+1];
            int result = 0;
            for (int index = 0; index < output.Length-1; index++)
            {
                if (index < number1.Length && index < number2.Length)
                {
                    result += ((int)number1[index]) - 48 + ((int)number2[index]) - 48;
                }
                else if (index < number1.Length)
                {
                    result += ((int)number1[index]) - 48;
                }
                else
                {
                    result += (int)number2[index] - 48;
                }
                output[index] = (char)((result % 10) + 48);
                result /= 10;
            }
            output[output.Length - 1] = (char)(result + 48);

            return Trim(output);
        }

        public static string ArrayToString(char[] number)
        {
            Array.Reverse(number);
            return string.Join("", number);
        }

        public static char[] Trim(char[] number)
        {
            int length = 0;
            for (int index = number.Length-1; index >= 0; index--)
            {
                if (number[index] != '0')
                {
                    length = index;
                    break;
                }
            }
            length++;
            char[] result = new char[length];
            Array.Copy(number, result, length);
            return result;
        }

        static void Main()
        {

            char[] number1 = BigNumberInput(" Enter first positive integer: ");
            char[] number2 = BigNumberInput(" Enter second positive integer: ");

            ArrayLibrary.printArray(number1);         
            ArrayLibrary.printArray(number2);         

            char[] sum = AddBigNumber(number1, number2);
            Console.WriteLine(new string('-',40));    
            ArrayLibrary.printArray(sum);             

            Console.WriteLine(" Sum is: {0}", ArrayToString(sum));
        }
    }
}
