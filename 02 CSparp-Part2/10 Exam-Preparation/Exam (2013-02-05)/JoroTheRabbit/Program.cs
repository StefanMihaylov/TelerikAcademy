using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoroTheRabbit
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int[] steps = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                steps[i] = int.Parse(input[i]);
            }

            long maxCounter = long.MinValue;
            for (int startPosition = 0; startPosition < steps.Length; startPosition++)
            {
                for (int steplength = 1; steplength < steps.Length; steplength++)
                {
                    long counter = jumpsCounter(steps, startPosition, steplength);
                    if (maxCounter < counter)
                    {
                        maxCounter = counter;
                    }
                }
            }

            Console.WriteLine(maxCounter);
        }

        static long jumpsCounter(int[] steps, int startPosition, int steplength)
        {
            long counter = 1;
            int currentPosition = startPosition;

            while (true)
            {
                int nextPosition = (currentPosition + steplength);
                if (nextPosition >= steps.Length)
                {
                    nextPosition -= steps.Length;
                }

                if (steps[currentPosition] < steps[nextPosition] && nextPosition != startPosition)
                {
                    currentPosition = nextPosition;
                    counter++;
                }
                else
                {
                    return counter;
                }
            }
        }
    }
}
