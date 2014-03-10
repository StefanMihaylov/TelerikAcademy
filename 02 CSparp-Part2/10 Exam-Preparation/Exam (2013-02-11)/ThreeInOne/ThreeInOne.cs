using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ThreeInOne
{
    static void Main()
    {
        string blackJack = Console.ReadLine();
        Console.WriteLine(Points(blackJack));

        string cakes = Console.ReadLine();
        int friends = int.Parse(Console.ReadLine());
        Console.WriteLine(BiteCakes(cakes, friends));

        // problem 3
        string moneyInput = Console.ReadLine();
        string[] moneyString = moneyInput.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int[] money = new int[moneyString.Length];

        for (int i = 0; i < moneyString.Length; i++)
        {
            money[i] = int.Parse(moneyString[i]);
        }

        
        Console.WriteLine(BuyBeer(money[0],money[1],money[2],money[3],money[4],money[5])); // autor

        /*
         *int[] beer = new int[] { money[3], money[4], money[5] };
        int counter = 0;
        while (true)
        {
            if (money[0] >= beer[0] && money[1] >= beer[1] && money[2] >= beer[2])
            {
                Console.WriteLine(counter);
                return;
            }

            while (money[1] > beer[1])
            {
                if (money[0] < beer[0])
                {
                    if ((money[1] - beer[1]) >= 11)
                    {
                        money[0]++;
                        money[1] -= 11;
                        counter++;
                    }
                    else if ((money[2] - beer[2]) >= 11)
                    {
                        money[2] -= 11;
                        money[1]++;
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                
                }
                else if (money[2] < beer[2])
                {
                    if ((money[1] - beer[1]) >= 1)
                    {
                        money[2] += 9;
                        money[1]--;
                        counter++;
                    }
                }
                else
                {
                    Console.WriteLine(counter);
                    return;
                }
            }

            while (money[1] < beer[1])
            {
                if (money[2] > beer[2])
                {
                    if ((money[1] - beer[1]) >= 11)
                    {
                        money[2] -= 11;
                        money[1]++;
                        counter++;
                    }
                }
                else if (money[0] > beer[0])
                {
                    if ((money[1] - beer[1]) >= 1)
                    {
                        money[0]--;
                        money[1] += 9;
                        counter++;
                    }
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }
            }

            if (money[0] < beer[0])
            {
                if ((money[2] - beer[2]) >= 11)
                {
                    money[2] -= 11;
                    money[1]++;
                    counter++;
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }

            }
            if (money[2] < beer[2])
            {
                if ((money[0] - beer[0]) >= 1)
                {
                    money[0]--;
                    money[1] += 9;
                    counter++;
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }
            } 
        } */
    }

    static long BiteCakes(string cakesInput, int friends)
    {
        string[] cakesString = cakesInput.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int[] cakes = new int[cakesString.Length];

        for (int i = 0; i < cakesString.Length; i++)
        {
            cakes[i] = int.Parse(cakesString[i]);
        }

        Array.Sort(cakes);
        long result = 0;
        int player = 0;
        for (int i = cakes.Length - 1; i >= 0; i--)
        {
            if (player == 0)
            {
                result += cakes[i];
            }
            player++;
            if (player == friends + 1)
            {
                player = 0;
            }
        }
        return result;
    }

    static int Points(string blackJack)
    {
        string[] pointsString = blackJack.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int[] points = new int[pointsString.Length];

        for (int i = 0; i < pointsString.Length; i++)
        {
            points[i] = int.Parse(pointsString[i]);
        }

        int counter21 = 0;
        int index = 0;
        int max = points.Max();
        int counterMax = 0;
        int indexMax = 0;
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i] == 21)
            {
                counter21++;
                index = i;
            }
            else if (points[i] == max)
            {
                counterMax++;
                indexMax = i;
            }
        }

        if (counter21 == 1)
        {
            return index;
        }
        else if (counterMax == 1)
        {
            return indexMax;
        }
        else
        {
            return -1;
        }
    }

    private static int BuyBeer(int G1, int S1, int B1, int G2, int S2, int B2)
    {
        int exchangeOperations = 0;
        while (G2 > G1)
        {
            --G2;
            S2 += 11;
            exchangeOperations++;
        }

        while (S2 > S1)
        {
            if (G1 > G2)
            {
                --G1;
                S1 += 9;
                exchangeOperations++;
            }
            else
            {
                --S2;
                B2 += 11;
                exchangeOperations++;
            }
        }

        while (B2 > B1)
        {
            if (S1 > S2)
            {
                --S1;
                B1 += 9;
                exchangeOperations++;
            }
            else if (G1 > G2)
            {
                --G1;
                S1 += 9;
                exchangeOperations++;
            }
            else
            {
                return -1;
            }
        }

        return exchangeOperations;
    }
}

