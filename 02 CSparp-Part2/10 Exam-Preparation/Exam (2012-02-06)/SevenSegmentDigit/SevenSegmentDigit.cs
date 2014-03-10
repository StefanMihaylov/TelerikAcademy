using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SevenSegmentDigit
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        byte[][] digits = new byte[N][];

        for (int i = 0; i < N; i++)
        {
            string inputString = Console.ReadLine();
            digits[i] = new byte[inputString.Length];
            for (int j = 0; j < inputString.Length; j++)
            {
                digits[i][j] = (byte)(inputString[j] - '0');
            }
        }

        List<string> sevenSegment = new List<string>() { "1111110", "0110000", "1101101", "1111001", "0110011", "1011011", "1011111", "1110000", "1111111", "1111011" };

        List<long> result = new List<long>();
        byte[] currentNumber = new byte[7];

        List<int> currentDigits = new List<int>();

        for (int i = 0; i < N; i++)
        {
            byte[] input = digits[i];
            currentDigits.Clear();
            for (byte A = input[0]; A < 2; A++)
            {
                currentNumber[0] = A;
                for (byte B = input[1]; B < 2; B++)
                {
                    currentNumber[1] = B;
                    for (byte C = input[2]; C < 2; C++)
                    {
                        currentNumber[2] = C;
                        for (byte D = input[3]; D < 2; D++)
                        {
                            currentNumber[3] = D;
                            for (byte E = input[4]; E < 2; E++)
                            {
                                currentNumber[4] = E;
                                for (byte F = input[5]; F < 2; F++)
                                {
                                    currentNumber[5] = F;
                                    for (byte G = input[6]; G < 2; G++)
                                    {
                                        currentNumber[6] = G;
                                        int number = sevenSegment.IndexOf(string.Join("", currentNumber));
                                        if (number >= 0)
                                        {
                                            currentDigits.Add(number);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            result = AddNumber(result, currentDigits);
        }

        result.Sort();
        Console.WriteLine(result.Count);
        for (int i = 0; i < result.Count; i++)
        {
            Console.WriteLine("{0:d" + N + "}", result[i]);
        }
    }

    static List<long> AddNumber(List<long> input, List<int> numbers)
    {
        List<long> result = new List<long>();
        if (input.Count == 0)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                result.Add(numbers[i]);
            }
        }
        else
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    result.Add(input[i] * 10 + numbers[j]);
                }
            }
        }

        return result;
    }
}

