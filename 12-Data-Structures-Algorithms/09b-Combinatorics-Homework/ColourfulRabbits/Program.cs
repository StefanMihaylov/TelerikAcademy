namespace ColourfulRabbits
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        // result = 100/100

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < N; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (!dict.ContainsKey(currentNumber))
                {
                    dict[currentNumber] = 0;
                }
                dict[currentNumber]++;
            }

            var sum = 0;
            foreach (var pair in dict)
            {
                int numberOfRabbitsInColour = pair.Key + 1;
                int numberOfColours = (int)Math.Ceiling((pair.Value) / (decimal)(numberOfRabbitsInColour));
                sum += numberOfRabbitsInColour * numberOfColours;
            }

            Console.WriteLine(sum);
        }
    }
}
