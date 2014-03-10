using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class TwoGirlsOnePath
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');

        int N = input.Length;
        long[] path = new long[N];
        for (long i = 0; i < N; i++)
        {
            path[i] = long.Parse(input[i]);
        }

        int mollyPosition = 1;
        int dollyPosition = N;

        BigInteger sumMolly = 0;
        BigInteger sumDolly = 0;

        bool mollyWins = false;
        bool dollyWins = false;
        
        BigInteger currentFlowers;
        BigInteger newPosition;
        while (true)
        {
            if (mollyPosition != dollyPosition)
            {
                //molly
                currentFlowers = path[mollyPosition - 1];                
                if (currentFlowers == 0)
                {
                    dollyWins = true;
                }
                else
                {
                    sumMolly += currentFlowers;
                    path[mollyPosition - 1] = 0;

                    newPosition = (mollyPosition + currentFlowers) % N;
                    if (newPosition == 0) newPosition = N;
                    mollyPosition = (int)newPosition;   
                }           

                // dolly
                currentFlowers = path[dollyPosition - 1];
                if (currentFlowers == 0)
                {
                    mollyWins = true;
                }
                else
                {
                    sumDolly += currentFlowers;
                    path[dollyPosition - 1] = 0;

                    newPosition = (dollyPosition - currentFlowers) / N;
                    if (newPosition < 0)  newPosition *= -1;
                    newPosition ++;
                    newPosition = (dollyPosition - currentFlowers + (newPosition * N)) % N;
                    if (newPosition == 0) newPosition = N; 
                    dollyPosition = (int)newPosition;
                }               
            }
            else
            {
                currentFlowers = path[mollyPosition - 1];
                if (currentFlowers == 0)
                {
                    mollyWins = true;
                    dollyWins = true;
                }
                else
                {
                    if (currentFlowers % 2 != 0)
                    {
                        currentFlowers--;
                        path[mollyPosition - 1] = 1;
                    }
                    else
                    {
                        path[mollyPosition - 1] = 0;
                    }
                    sumMolly += currentFlowers / 2;

                    newPosition = (mollyPosition + currentFlowers) % N;
                    if (newPosition == 0) newPosition = N;
                    mollyPosition = (int)newPosition;
                     
                    sumDolly += currentFlowers / 2;

                    newPosition = (dollyPosition - currentFlowers) / N;
                    if (newPosition < 0) newPosition *= -1;
                    newPosition++;
                    newPosition = (dollyPosition - currentFlowers + newPosition * N) % N;
                    if (newPosition == 0) newPosition = N;
                    dollyPosition = (int)newPosition;
                }
            }

            if (mollyWins || dollyWins)
            {
                break;
            }
        }

        if (mollyWins && !dollyWins)
        {
            Console.WriteLine("Molly");
        }
        else if (!mollyWins && dollyWins)
        {
            Console.WriteLine("Dolly");
        }
        else if (mollyWins && dollyWins)
        {
            Console.WriteLine("Draw");
        }
        Console.WriteLine("{0} {1}", sumMolly, sumDolly);
    }
}
