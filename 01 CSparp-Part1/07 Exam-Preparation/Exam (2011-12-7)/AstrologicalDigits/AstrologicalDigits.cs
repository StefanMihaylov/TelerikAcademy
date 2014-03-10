using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrologicalDigits
{
    class AstrologicalDigits
    {
        static void Main(string[] args)
        {
            string M = Console.ReadLine();
            int N;
            int temp;
            do
            {
                N = 0;
                for (int i = 0; i < M.Length; i++)
                {
                    temp=0;
                    if(int.TryParse(M[i].ToString(),out temp))
                    {
                        N+=temp;
                    }
                }
                M = N.ToString();
                
            } while (N>9);

            Console.WriteLine(N);
        }
    }
}
