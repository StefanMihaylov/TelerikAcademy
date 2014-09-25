using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCows.WebApi.Infrastructure
{
    public class GameLogic : IGameLogic
    {
        public bool IsNumberValid(int number)
        {
            char[] digits = number.ToString().ToCharArray();

            for (int i = 0; i < digits.Count(); i++)
            {
                for (int j = 1; j < digits.Count(); j++)
                {
                    if (i != j)
                    {
                        if (digits[i] == digits[j])
                        {
                            return false;
                        }
                    }

                }
            }

            return true;
        }


        public Tuple<int, int> CalculateBullsAndCows(int number, int guess)
        {
            char[] digits = number.ToString().ToCharArray();
            char[] guesses = guess.ToString().ToCharArray();


            int bulls = 0;
            int cows = 0;

            for (int i = 0; i < digits.Count(); i++)
            {
                for (int j = 0; j < digits.Count(); j++)
                {

                    if (digits[i] == guesses[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }

            return new Tuple<int, int>(bulls, cows);
        }


        public long CalculateScore(int wins, int losses)
        {
            return 100 * wins + 15 * losses;
        }
    }
}