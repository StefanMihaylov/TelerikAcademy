using System;

namespace DrunkenBeers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int sumM = 0;
            int sumV = 0;
            int digit;
            for (int i = 0; i < N; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    number *= -1;
                }

                int power = (int)Math.Round(Math.Log10(number) + 0.5);
                for (int j = 0; j < power; j++)
                {
                    digit = number % 10;
                    number /= 10;
                    if (power % 2 == 0)
                    {
                        if (j < power / 2)
                        {
                            sumV += digit;
                        }
                        else
                        {
                            sumM += digit;
                        }
                    }
                    else
                    {
                        if (j < power / 2)
                        {
                            sumV += digit;
                        }
                        else if (j > power / 2)
                        {
                            sumM += digit;
                        }
                        else
                        {
                            sumV += digit;
                            sumM += digit;
                        }
                    }
                }
            }

            if (sumM>sumV)
            {
                Console.WriteLine("M {0}",sumM-sumV);
            }
            else if (sumM < sumV)
            {
                Console.WriteLine("V {0}", sumV - sumM);
            }
            else
            {
                Console.WriteLine("No {0}", sumV+sumM);
            }
        }
    }
}
