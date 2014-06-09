namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Poker.Enum;

    public class PokerExample
    {
        public static void Main()
        {
            ICard card = new Card(CardFaceEnum.Ace, CardSuitEnum.Clubs);
            Console.WriteLine("Card: " + card);

            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFaceEnum.Ace, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.King, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.King, CardSuitEnum.Spades),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Diamonds)
            });
            Console.WriteLine("Hand: " + hand);

            IPokerHandsChecker checker = new PokerHandsChecker();
            Console.WriteLine("Is hand valid: " + checker.IsValidHand(hand));
            Console.WriteLine("Is hand One pair: " + checker.IsOnePair(hand));
            Console.WriteLine("Is hand two pairs: " + checker.IsTwoPair(hand));
            Console.WriteLine();  
        }
    }
}
