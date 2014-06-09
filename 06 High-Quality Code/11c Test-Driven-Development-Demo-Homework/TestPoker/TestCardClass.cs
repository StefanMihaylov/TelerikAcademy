namespace TestPoker
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using Poker.Enum;

    [TestClass]
    public class TestCardClass
    {
        [TestMethod]
        public void ToStringOfTenOfClubs()
        {
            var tenClubes = new Card(CardFaceEnum.Ten, CardSuitEnum.Clubs);
            Assert.AreEqual("10♣", tenClubes.ToString());
        }

        [TestMethod]
        public void ToStringOfSevenOfDiamonds()
        {
            var sevenDiamonds = new Card(CardFaceEnum.Seven, CardSuitEnum.Diamonds);
             Assert.AreEqual("7♦", sevenDiamonds.ToString());
        }

        [TestMethod]
        public void ToStringOfAceOfHearts()
        {
            var aceHearts = new Card(CardFaceEnum.Ace, CardSuitEnum.Hearts);
            Assert.AreEqual("A♥", aceHearts.ToString());
        }

        [TestMethod]
        public void ToStringOfKingOfHearts()
        {
            var kingHearts = new Card(CardFaceEnum.King, CardSuitEnum.Hearts);
            Assert.AreEqual("K♥", kingHearts.ToString());
        }

        [TestMethod]
        public void ToStringOfQueenOfHearts()
        {
            var queenHearts = new Card(CardFaceEnum.Queen, CardSuitEnum.Hearts);
            Assert.AreEqual("Q♥", queenHearts.ToString());
        }

        [TestMethod]
        public void ToStringOfJackOfHearts()
        {
            var jackHearts = new Card(CardFaceEnum.Jack, CardSuitEnum.Hearts);
            Assert.AreEqual("J♥", jackHearts.ToString());
        }

        [TestMethod]
        public void ToStringOfTwoOfSpades()
        {
            var twoSpades = new Card(CardFaceEnum.Two, CardSuitEnum.Spades);
            Assert.AreEqual("2♠", twoSpades.ToString());
        }

        [TestMethod]
        public void EqualTwoCradsOfTwoOfSpades()
        {
            var twoSpades = new Card(CardFaceEnum.Two, CardSuitEnum.Spades);
            var secondTwoSpades = new Card(CardFaceEnum.Two, CardSuitEnum.Spades);

            Assert.IsTrue(twoSpades.Equals(secondTwoSpades));
        }

        [TestMethod]
        public void NotEqualTwoCradsOfTwoOfSpades()
        {
            var twoSpades = new Card(CardFaceEnum.Two, CardSuitEnum.Spades);
            var twoClub = new Card(CardFaceEnum.Two, CardSuitEnum.Clubs);

            Assert.IsFalse(twoSpades.Equals(twoClub));
        }

        [TestMethod]
        public void CardEqualWithNull()
        {
            var twoSpades = new Card(CardFaceEnum.Two, CardSuitEnum.Spades);

            Assert.IsFalse(twoSpades.Equals(null));
        }
    }
}
