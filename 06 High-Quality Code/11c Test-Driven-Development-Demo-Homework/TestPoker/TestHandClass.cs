namespace TestPoker
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using Poker.Enum;    

    [TestClass]
    public class TestHandClass
    {
        [TestMethod]
        public void ToStringHandWithNoCards()
        {
            var emptyHand = new Hand(new List<ICard>());
            Assert.AreEqual(string.Empty, emptyHand.ToString());
        }

        [TestMethod]
        public void ToStringHandWithOneCardTenOfClubs()
        {
            var handWithOneCardTenOfClubs = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs)
            });

            var actual = handWithOneCardTenOfClubs.ToString();
            Assert.AreEqual("10♣", actual);
        }

        [TestMethod]
        public void ToStringHandWithFiveCards()
        {
            var handWithFiveCards = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs),
                new Card(CardFaceEnum.Seven, CardSuitEnum.Diamonds),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Two, CardSuitEnum.Spades),
                new Card(CardFaceEnum.Eight, CardSuitEnum.Diamonds)
            });

            var actual = handWithFiveCards.ToString();
            Assert.AreEqual("10♣ 7♦ A♥ 2♠ 8♦", actual);
        }

        [TestMethod]
        public void ToStringHandWithSameCards()
        {
            var handWithFiveCards = new Hand(new List<ICard>()
            {
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts),
                new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts)
            });

            var actual = handWithFiveCards.ToString();
            Assert.AreEqual("A♥ A♥ A♥ A♥", actual);
        }
    }
}
