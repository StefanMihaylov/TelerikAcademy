namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using Poker.Enum;

    [TestClass]
    public class TestIsValidMethod
    {
        private readonly IPokerHandsChecker checker = new PokerHandsChecker();

        [TestMethod]
        public void TestOnHandWithNoCards()
        {
            var handWithNoCards = new Hand(new List<ICard>());
            var result = this.checker.IsValidHand(handWithNoCards);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithFiveDifferentCards()
        {
            var handWithFiveDifferentCards = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Two, CardSuitEnum.Spades),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Diamonds)
            });

            var result = this.checker.IsValidHand(handWithFiveDifferentCards);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestOnHandWithSixDifferentCards()
        {
            var handWithSixDifferentCards = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Two, CardSuitEnum.Spades),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Three, CardSuitEnum.Spades)
            });

            var result = this.checker.IsValidHand(handWithSixDifferentCards);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualCards()
        {
            var handWithTwoEqualCard = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Two, CardSuitEnum.Spades),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Diamonds)
            });

            var result = this.checker.IsValidHand(handWithTwoEqualCard);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithFiveEqualCards()
        {
            var handWithFiveEqualCards = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs)
            });

            var result = this.checker.IsValidHand(handWithFiveEqualCards);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualPairOfCards()
        {
            var handWithTwoEqualPairOfCards = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Diamonds)
            });

            var result = this.checker.IsValidHand(handWithTwoEqualPairOfCards);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualOfFourCards()
        {
            var handWithTwoEqualOfFourCards = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Diamonds)
            });

            var result = this.checker.IsValidHand(handWithTwoEqualOfFourCards);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualOfSixCards()
        {
            var handWithTwoEqualOfSixCards = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Two, CardSuitEnum.Spades),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Diamonds)
            });

            var result = this.checker.IsValidHand(handWithTwoEqualOfSixCards);
            Assert.IsFalse(result);
        }
    }
}
