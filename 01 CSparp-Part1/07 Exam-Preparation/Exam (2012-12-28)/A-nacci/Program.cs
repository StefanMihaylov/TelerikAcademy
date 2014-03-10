using System;

namespace A_nacci
{
    class Program
    {
        static void Main()
        {
            char Ainput = char.Parse(Console.ReadLine());
            char Binput = char.Parse(Console.ReadLine());
            int H = int.Parse(Console.ReadLine());

            int A = (int)Ainput - 64;
            int B = (int)Binput - 64;
            int C = 0;
            int temp;
           
            for (int i = 0; i < H; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine((char)(A+64));
                }
                else if (i == 1)
                {
                    C = (A + B) % 26;
                    if (C == 0)
                    {
                        C = 26;
                    }
                    Console.WriteLine((char)(B + 64) + "" + (char)(C + 64));
                }
                else
                {
                    temp = (B + C) % 26;
                    if (temp == 0)
                    {
                        temp = 26;
                    }
                    C = (temp + C) % 26;
                    if (C == 0)
                    {
                        C = 26;
                    }
                    B = temp;
                    Console.WriteLine((char)(B + 64) + new string(' ', i - 1) + (char)(C + 64));
                }
            }
        }
    }
}
