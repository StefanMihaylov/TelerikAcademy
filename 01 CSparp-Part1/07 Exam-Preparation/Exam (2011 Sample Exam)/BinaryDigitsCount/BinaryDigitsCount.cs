using System;

namespace BinaryDigitsCount
{
    class BinaryDigitsCount
    {
        static void Main(string[] args)
        {
            int B = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            uint input;
            int counter;
            uint mask;
            for (int i = 0; i < N; i++)
            {
                input = uint.Parse(Console.ReadLine());
                counter = 0;
                while (input!=0)
                {
                    mask = input & 1;
                    if (mask == B)
                    {
                        counter++;
                    }
                    input >>= 1;
                }
                Console.WriteLine(counter);
            }
        }
    }
}