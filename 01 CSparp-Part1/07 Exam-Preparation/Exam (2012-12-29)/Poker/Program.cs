using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main()
        {
            byte [] cards = new byte[5];

            for (int i = 0; i < 5; i++)
            {
                string currentCard = Console.ReadLine();
                currentCard = currentCard.Trim();
                if (currentCard.Length == 2)
                {
                    cards[i] = 10;
                }
                else
                {
                    char curr = char.Parse(currentCard);
                    if ((int)curr >= 50 && (int)curr <= 57)
                    {
                        cards[i] = (byte)((int)curr-48);
                    }
                    else if (curr == 'J')     
	                {
		                cards[i] = 11;
	                }
                   else if (curr == 'Q')     
	                {
		                cards[i] = 12;
	                }
                   else if (curr == 'K')     
	                {
		                cards[i] = 13;
	                }
                    else if (curr == 'A')     
	                {
		                cards[i] = 1;
	                }
                }
           }

            Array.Sort(cards);

            // 5 equal
            if (cards[0] == cards[4])
            {
                Console.WriteLine("Impossible");
                return;
            }  
            
            // 4 equal            
            if ((cards[0] == cards[3]) || (cards[1] == cards[4]))
            {
                Console.WriteLine("Four of a Kind");
                return;
            } 
            
            // 3+2 equal
            if ((cards[0] == cards[2] && cards[3] == cards[4]) || (cards[0] == cards[1] && cards[2] == cards[4]))
            {
                Console.WriteLine("Full House");
                return;
            }

            // 3 equal
            if ((cards[0] == cards[2] || cards[1] == cards[3]) || cards[2] == cards[4])
            {
                Console.WriteLine("Three of a Kind");
                return;
            }

            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    if (cards[i] == cards[j])
                    {
                        count++;
                    }
                }
            }
            if (count == 1)
            {
                Console.WriteLine("One Pair");
                return;
            }
            if (count == 2)
            {
                Console.WriteLine("Two Pairs");
                return;
            }

            // 2,3,4,5,6
            count = 0;
            for (int i = 1; i < 5; i++)
            {
                if (cards[i]==cards[i-1]+1)
                {
                    count++;
                }
            }
            if (count==4)
	        {
                Console.WriteLine("Straight");
                return;
	        }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    if(cards[i]==1)
                    {
                        cards[i] = 14;
                        break;
                    }
                }
                Array.Sort(cards);
                count = 0;
                for (int i = 1; i < 5; i++)
                {
                    if (cards[i] == cards[i - 1] + 1)
                    {
                        count++;
                    }
                }
                if (count == 4)
                {
                    Console.WriteLine("Straight");
                    return;
                }
            }

            Console.WriteLine("Nothing");

            /*
            foreach (var item in cards)
	        {
		        Console.Write("{0} ",item);
	        } */
        }
    }
}
