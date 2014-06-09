namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using Poker.Enum;

    [TestClass]
    public class TestIsOnePairMethod
    {
        private readonly IPokerHandsChecker checker = new PokerHandsChecker();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnHandWithNoCards()
        {
            var handWithNoCards = new Hand(new List<ICard>());
            var result = this.checker.IsOnePair(handWithNoCards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnHandWithFourDifferentCardsOnEqualSuit()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Two, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Diamonds)
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnHandWithThreeEqualOnSuitOfFiveCards()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Six, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Six, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Six, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Clubs),
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
        }

        [TestMethod]
        public void TestOnHandWithValidFullHouse()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Six, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Six, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Six, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Spades),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Clubs),
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnHandWithInvalidFullHouse()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Six, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Six, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Six, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Six, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Spades),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Clubs),
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
        }

        [TestMethod]
        public void TestOnHandWithOnePair()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.King, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.King, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Nine, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Jack, CardSuitEnum.Clubs),
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestOnHandWithTwoPair()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.King, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.King, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Nine, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Nine, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Jack, CardSuitEnum.Clubs),
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnHandWithTwoEqualOnSuitOfFiveCards()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.King, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.King, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Nine, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Nine, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Jack, CardSuitEnum.Clubs),
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
        }

        [TestMethod]
        public void TestOnHandWithThreeOfAKind()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Six, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Six, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Six, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Clubs),
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithFourOfAKind()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Six, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Six, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Six, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Six, CardSuitEnum.Spades),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Clubs),
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithFiveDifferentCardsOnEqualSuit()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Two, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Diamonds)
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnHandWithTwoEqualOfFiveCardsOnEqualSuit()
        {
            var handWithTwoEqualOfFiveCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Two, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Diamonds)
            });

            var result = this.checker.IsOnePair(handWithTwoEqualOfFiveCardsOnEqualSuit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
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

            var result = this.checker.IsOnePair(handWithSixDifferentCards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
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

            var result = this.checker.IsOnePair(handWithTwoEqualCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnHandWithTwoEqualOnSuitCards()
        {
            var handWithTwoEqualCard = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Spades)
            });

            var result = this.checker.IsOnePair(handWithTwoEqualCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
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

            var result = this.checker.IsOnePair(handWithFiveEqualCards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
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

            var result = this.checker.IsOnePair(handWithTwoEqualPairOfCards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnHandWithTwoEqualOfFourCards()
        {
            var handWithTwoEqualOfFourCards = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Diamonds)
            });

            var result = this.checker.IsOnePair(handWithTwoEqualOfFourCards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnHandWithTwoEqualOfSixCardsWithDifferentFaces()
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

            var result = this.checker.IsOnePair(handWithTwoEqualOfSixCards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnHandWithTwoEqualOfSixCardsOnFiveWithEqualFaces()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Spades),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Diamonds)
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnHandWithTwoEqualOfSixCardsOnEqualSuit()
        {
            var handWithTwoEqualOfSixCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Two, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Clubs)
            });

            var result = this.checker.IsOnePair(handWithTwoEqualOfSixCardsOnEqualSuit);
        }

        [TestMethod]
        public void TestOnHandWithValidStraight_1()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Five, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Six, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Nine, CardSuitEnum.Clubs)
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithValidStraight_2()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ace, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Two, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Three, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Four, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Five, CardSuitEnum.Clubs)
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithValidStraight_3()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Jack, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Queen, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.King, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Clubs)
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithHighCard_1()
        {
            var handWithTwoEqualOfSixCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.King, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Queen, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Two, CardSuitEnum.Spades),
            });

            var result = this.checker.IsOnePair(handWithTwoEqualOfSixCardsOnEqualSuit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithHighCard_2()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Jack, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.King, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Clubs)
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithHighCard_3()
        {
            var handWithTwoEqualOfSixCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.King, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Queen, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ten, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Two, CardSuitEnum.Spades),
            });

            var result = this.checker.IsOnePair(handWithTwoEqualOfSixCardsOnEqualSuit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithValidStraightFlush_1()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Five, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Six, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Nine, CardSuitEnum.Clubs)
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithValidStraightFlush_2()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ace, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Two, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Three, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Four, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Five, CardSuitEnum.Clubs)
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestOnHandWithValidStraightFlush_3()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Jack, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Queen, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.King, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Clubs)
            });

            var result = this.checker.IsOnePair(handWithFiveDifferentCardsOnEqualSuit);
            Assert.IsFalse(result);
        }
    }
}
