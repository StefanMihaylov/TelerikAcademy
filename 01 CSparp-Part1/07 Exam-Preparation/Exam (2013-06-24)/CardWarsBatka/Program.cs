using System;
using System.Numerics;

namespace CardWarsBatka
{
    class Program
    {
        static int cardWeight(string card)
        {
            char letter = card[0];
            int result=0;
            if (letter >= '2' && letter <= '9')
            {
                result = 12 - int.Parse(letter.ToString());
            }
            else if (card=="10")
            {
                result = 2;
            }
            else if (card=="A")
            {
                result = 1;
            }
            else if (card == "J")
            {
                result = 11;
            }
            else if (card == "Q")
            {
                result = 12;
            }
            else if (card == "K")
            {
                result = 13;
            }
            return result;
        }

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            string currentCard;
            BigInteger scoreA=0;
            BigInteger scoreB=0;
            int wonGamesA = 0;
            int wonGamesB = 0;
            bool cardXA = false;
            bool cardXB = false;
            for (int i = 0; i < N; i++)
            {
                int cardSumA = 0;
                int cardSumB = 0;
                cardXA = false;
                cardXB = false;
                for (int j = 0; j < 3; j++)
                {
                    currentCard = Console.ReadLine();
                    if (currentCard=="X") 
                    {
                        cardXA = true;
                    }
                    else if (currentCard=="Y")
                    {
                        scoreA -= 200;
                    }
                    else if (currentCard == "Z")
                    {
                        scoreA *= 2;
                    }
                    else
                    {
                        cardSumA += cardWeight(currentCard);
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    currentCard = Console.ReadLine();
                    if (currentCard == "X")
                    {
                        cardXB = true;
                    }
                    else if (currentCard == "Y")
                    {
                        scoreB -= 200;
                    }
                    else if (currentCard == "Z")
                    {
                        scoreB *= 2;
                    }
                    else
                    {
                        cardSumB += cardWeight(currentCard);
                    }
                }
                //check scores
                if (cardXA ^ cardXB)
                {
                    break;
                }
                else if (cardXA && cardXB)
                {
                    scoreA += 50;
                    scoreB += 50;
                }

                if (cardSumA > cardSumB)
                {
                    scoreA += cardSumA;
                    wonGamesA++;
                }
                if (cardSumA < cardSumB)
                {
                    scoreB += cardSumB;
                    wonGamesB++;
                }
            }

            //result
            if (cardXA ^ cardXB)
            {
                if (cardXA)
                {
                    Console.WriteLine("X card drawn! Player one wins the match!");
                }
                if (cardXB)
                {
                    Console.WriteLine("X card drawn! Player two wins the match!");
                }
            }
            else if (scoreA>scoreB)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}",scoreA);
                Console.WriteLine("Games won: {0}",wonGamesA);
            }
            else if (scoreA < scoreB)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", scoreB);
                Console.WriteLine("Games won: {0}", wonGamesB);
            }
            else
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: {0}", scoreB);
            }
        }
    }
}
