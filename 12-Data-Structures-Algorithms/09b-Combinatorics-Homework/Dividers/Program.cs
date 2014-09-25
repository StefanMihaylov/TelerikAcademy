namespace Dividers
{
    using System;
    using System.Collections.Generic;
    
    // result: 100/100

    class Program
    {
        static char[] array;
        static bool[] used;

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            var input = new char[N];
            for (int i = 0; i < N; i++)
            {
                input[i] = char.Parse(Console.ReadLine());
            }

            var result = AllVariations(input);

            var minNumber = new KeyValuePair<int, int>(int.MaxValue, int.MaxValue);

            foreach (var number in result)
            {
                var currentPair = MinDevider(number, minNumber.Value);
                if (currentPair.Value < minNumber.Value)
                {
                    minNumber = currentPair;
                }
                else if (currentPair.Value == minNumber.Value && currentPair.Key < minNumber.Key)
                {
                    minNumber = currentPair;
                }
            }

            Console.WriteLine(minNumber.Key);
        }

        private static ICollection<int> AllVariations(char[] input)
        {
            var result = new HashSet<int>();
            array = new char[input.Length];
            used = new bool[input.Length];
            Variations(result, input, 0);
            return result;
        }

        private static void Variations(ICollection<int> result, char[] input, int index)
        {
            if (index >= input.Length)
            {
                string number = string.Join(string.Empty, array);
                result.Add(int.Parse(number));
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        array[index] = input[i];
                        Variations(result, input, index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static KeyValuePair<int, int> MinDevider(int number, int minDivider)
        {
            int dividers = 0;
            for (int i = 2; i <= number; i++)
            {
                if (number % i == 0)
                {
                    dividers++;
                    if (dividers > minDivider)
                    {
                        new KeyValuePair<int, int>(number, -1);
                    }
                }
            }

            minDivider = dividers;
            return new KeyValuePair<int, int>(number, minDivider);
        }
    }
}
