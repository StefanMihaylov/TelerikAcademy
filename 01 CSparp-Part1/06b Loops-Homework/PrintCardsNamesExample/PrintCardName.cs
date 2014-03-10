namespace PrintCardsNamesExample
{
    using System;

    class PrintCardName
    {
        // Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). The cards should be printed with their English names. Use nested for loops and switch-case.

        static void Main()
        {
            string result = "";
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    switch (j) //cards
                    {
                        case 1: result = "Ace"; break;
                        case 2: result = "Two"; break;
                        case 3: result = "Three"; break;
                        case 4: result = "Four"; break;
                        case 5: result = "Five"; break;
                        case 6: result = "Six"; break;
                        case 7: result = "Seven"; break;
                        case 8: result = "Eight"; break;
                        case 9: result = "Nine"; break;
                        case 10: result = "Ten"; break;
                        case 11: result = "Jack"; break;
                        case 12: result = "Queen"; break;
                        case 13: result = "King"; break;
                    }

                    result += " of ";

                    switch (i) // suits
                    {
                        case 1: result += "Clubs"; break;
                        case 2: result += "Diamonds"; break;
                        case 3: result += "Hearts"; break;
                        case 4: result += "Spades"; break;
                    }
                    Console.WriteLine("\t {1}: {0}",result,(i-1)*13+j);
                }
            }
        }
    }
}
