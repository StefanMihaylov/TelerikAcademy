using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int bulls = int.Parse(Console.ReadLine());
            int cows = int.Parse(Console.ReadLine());

            char[] numberDigits = new char[4];
            char[] guessDigits = new char[4];

            List<int> result = new List<int>();

            int guessBulls;
            int guessCows;

            for (int guess = 1111; guess <= 9999; guess++)
            {
                guessDigits = guess.ToString().ToCharArray();
                if (guessDigits[0] > '0' && guessDigits[1] > '0' && guessDigits[2] > '0' && guessDigits[3] > '0')
                {
                    guessBulls = 0;
                    guessCows = 0;
                    numberDigits = number.ToString().ToCharArray();                        
                    for (int i = 0; i < numberDigits.Length; i++)
                    {
                        if (numberDigits[i] == guessDigits[i])
                        {
                            guessBulls++;
                            numberDigits[i] = '*';
                            guessDigits[i] = '-';
                        }
                    }
                    for (int i = 0; i < numberDigits.Length; i++)
                    {
                        for (int j = 0; j < numberDigits.Length; j++)
                        {
                            if (numberDigits[i] == guessDigits[j])
                            {
                                guessCows++;
                                numberDigits[i] = '*';
                                guessDigits[j] = '-';
                            }
                        }
                    }
                    if (guessBulls == bulls && guessCows == cows)
                    {
                        result.Add(guess);
                    }
                }
            }

            if (result.Count>0)
	        {
		        foreach (var item in result)
	            {
		            Console.Write("{0} ", item);
	            }
	        }
            else
	        {
                Console.Write("No");
	        }            
        }
    }
}
