namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Poker.Enum;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public const int CardsInHand = 5;

        public bool IsValidHand(IHand hand)
        {
            var handWithUniqueCards = this.GetUniqueCards(hand);
            var numberOfCards = handWithUniqueCards.Count();
            return numberOfCards == CardsInHand && numberOfCards == hand.Cards.Count;
        }

        public bool IsStraightFlush(IHand hand)
        {
            return this.GetHandCategory(hand) == HandCategoryEnum.StraightFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            return this.GetHandCategory(hand) == HandCategoryEnum.FourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            return this.GetHandCategory(hand) == HandCategoryEnum.FullHouse;
        }

        public bool IsFlush(IHand hand)
        {
            return this.GetHandCategory(hand) == HandCategoryEnum.Flush;
        }

        public bool IsStraight(IHand hand)
        {
            return this.GetHandCategory(hand) == HandCategoryEnum.Straight;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            return this.GetHandCategory(hand) == HandCategoryEnum.ThreeOfAKind;
        }

        public bool IsTwoPair(IHand hand)
        {
            return this.GetHandCategory(hand) == HandCategoryEnum.TwoPair;
        }

        public bool IsOnePair(IHand hand)
        {
            return this.GetHandCategory(hand) == HandCategoryEnum.OnePair;
        }

        public bool IsHighCard(IHand hand)
        {
            return this.GetHandCategory(hand) == HandCategoryEnum.HighCard;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private HandCategoryEnum GetHandCategory(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid poker hand. By the poker rules all the cards must be different.");
            }

            var handWithUniqueCards = this.GetUniqueCards(hand);
            var cardsGroupedByFace = handWithUniqueCards.GroupBy(c => c.Face)
                                                       .OrderByDescending(g => g.Count())
                                                       .ToArray();

            if (cardsGroupedByFace.Length == 2)
            {
                if (cardsGroupedByFace[0].Count() == 4)
                {
                    return HandCategoryEnum.FourOfAKind;
                }
                else if (cardsGroupedByFace[0].Count() == 3 && cardsGroupedByFace[1].Count() == 2)
                {
                    return HandCategoryEnum.FullHouse;
                }
            }
            else if (cardsGroupedByFace.Length == 3)
            {
                if (cardsGroupedByFace[0].Count() == 3)
                {
                    return HandCategoryEnum.ThreeOfAKind;
                }
                else if (cardsGroupedByFace[0].Count() == 2 && cardsGroupedByFace[1].Count() == 2)
                {
                    return HandCategoryEnum.TwoPair;
                }
            }
            else if (cardsGroupedByFace.Length == 4)
            {
                return HandCategoryEnum.OnePair;
            }

            var cardsGroupedBySuit = handWithUniqueCards.GroupBy(c => c.Suit)
                                       .OrderByDescending(g => g.Count())
                                       .ToArray();
            bool isFlush = cardsGroupedBySuit.Count() == 1;
            var isStraight = this.IsStraight(handWithUniqueCards);

            if (isFlush && isStraight)
            {
                return HandCategoryEnum.StraightFlush;
            }
            else if (isFlush)
            {
                return HandCategoryEnum.Flush;
            }
            else if (isStraight)
            {
                return HandCategoryEnum.Straight;
            }
            else
            {
                return HandCategoryEnum.HighCard;
            }
        }

        private bool IsStraight(IEnumerable<ICard> handWithUniqueCards)
        {
            var cardsSortedByFace = handWithUniqueCards.ToArray();
            Array.Sort(cardsSortedByFace, (a, b) => a.Face.CompareTo(b.Face));

            bool isStraight = cardsSortedByFace[cardsSortedByFace.Length - 1].Face - cardsSortedByFace[0].Face == 4 ||
                              (cardsSortedByFace[cardsSortedByFace.Length - 1].Face == CardFaceEnum.Ace &&
                               cardsSortedByFace[cardsSortedByFace.Length - 2].Face == CardFaceEnum.Five);
            return isStraight;
        }

        private IEnumerable<ICard> GetUniqueCards(IHand hand)
        {
            return hand.Cards.GroupBy(c => c.GetHashCode()).Select(grp => grp.First());
        }
    }
}
