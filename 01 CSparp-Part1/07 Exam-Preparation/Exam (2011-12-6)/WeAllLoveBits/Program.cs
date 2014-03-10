using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAllLoveBits
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                uint number = uint.Parse(Console.ReadLine());

                uint pow = (uint)Math.Round((Math.Log10(number) / Math.Log10(2))+0.5);
                uint mask = (uint)Math.Pow(2,pow)-1;
                uint invNum = number^mask;
               
                // Solve
                int Pnew = 0;
                while (number > 0)
                {
                    Pnew <<= 1;
                    if ((number & 1) == 1)
                    {
                        Pnew |= 1;
                    }
                    number >>= 1;
                }

                Console.WriteLine(Pnew);                
            }
        }
    }
}
