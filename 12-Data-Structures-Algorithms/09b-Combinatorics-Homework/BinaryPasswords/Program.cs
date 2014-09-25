namespace BinaryPasswords
{
    using System;

    // result: 100 / 100

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    count++;
                }
            }

            long result = 1;
            for (int i = 0; i < count; i++)
            {
                result *= 2;
            }

            Console.WriteLine(result);
        }
    }
}
