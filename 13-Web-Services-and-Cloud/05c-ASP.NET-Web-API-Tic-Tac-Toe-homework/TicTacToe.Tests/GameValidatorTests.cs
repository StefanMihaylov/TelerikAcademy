using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.GameLogic;

namespace TicTacToe.Tests
{
    [TestClass]
    public class GameValidatorTests
    {
        [TestMethod]
        public void NotFinishedPosition0()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("-XOOXOXOX");
            Assert.AreEqual(GameResult.NotFinished, actual);
        }

        [TestMethod]
        public void NotFinishedPosition1()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("X-XOXOOXO");
            Assert.AreEqual(GameResult.NotFinished, actual);
        }

        [TestMethod]
        public void NotFinishedPosition2()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("OX-XOXOXX");
            Assert.AreEqual(GameResult.NotFinished, actual);
        }

        [TestMethod]
        public void NotFinishedPosition3()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("XOX-OOOXX");
            Assert.AreEqual(GameResult.NotFinished, actual);
        }

        [TestMethod]
        public void NotFinishedPosition4()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("XOOO-XXOO");
            Assert.AreEqual(GameResult.NotFinished, actual);
        }

        [TestMethod]
        public void NotFinishedPosition5()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("XOXOO-OXX");
            Assert.AreEqual(GameResult.NotFinished, actual);
        }

        [TestMethod]
        public void NotFinishedPosition6()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("XOXOOX-XO");
            Assert.AreEqual(GameResult.NotFinished, actual);
        }

        [TestMethod]
        public void NotFinishedPosition7()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("OXOXOXX-X");
            Assert.AreEqual(GameResult.NotFinished, actual);
        }

        [TestMethod]
        public void NotFinishedPosition8()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("OXOXOXXX-");
            Assert.AreEqual(GameResult.NotFinished, actual);
        }

        [TestMethod]
        public void NotFinishedPosition0And8()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("-XOOXXOO-");
            Assert.AreEqual(GameResult.NotFinished, actual);
        }

        [TestMethod]
        public void WonByXRow0()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("XXXOXOOXO");
            Assert.AreEqual(GameResult.WonByX, actual);
        }

        [TestMethod]
        public void WonByXRow1()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("OXOXXXOXO");
            Assert.AreEqual(GameResult.WonByX, actual);
        }

        [TestMethod]
        public void WonByXRow2()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("OXOOXOXXX");
            Assert.AreEqual(GameResult.WonByX, actual);
        }

        [TestMethod]
        public void WonByORow0()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("OOOXOXXOX");
            Assert.AreEqual(GameResult.WonByO, actual);
        }

        [TestMethod]
        public void WonByORow1()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("XOXOOOXOX");
            Assert.AreEqual(GameResult.WonByO, actual);
        }

        [TestMethod]
        public void WonByORow2()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("XOXXOXOOO");
            Assert.AreEqual(GameResult.WonByO, actual);
        }

        [TestMethod]
        public void WonByXCol0()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("XOOXXOXOX");
            Assert.AreEqual(GameResult.WonByX, actual);
        }

        [TestMethod]
        public void WonByXCol1()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("OXOXXOOXX");
            Assert.AreEqual(GameResult.WonByX, actual);
        }

        [TestMethod]
        public void WonByXCol2()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("OOXXOXOXX");
            Assert.AreEqual(GameResult.WonByX, actual);
        }

        public void WonByOCol0()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("OXXOOXOXO");
            Assert.AreEqual(GameResult.WonByO, actual);
        }

        [TestMethod]
        public void WonByOCol1()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("XOXOOXXOO");
            Assert.AreEqual(GameResult.WonByO, actual);
        }

        [TestMethod]
        public void WonByOCol2()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("XXOOXOXOO");
            Assert.AreEqual(GameResult.WonByO, actual);
        }


        [TestMethod]
        public void WonByODiagonal1()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("OXXXOXXOO");
            Assert.AreEqual(GameResult.WonByO, actual);
        }

        [TestMethod]
        public void WonByODiagonal2()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("XXOOOXOXO");
            Assert.AreEqual(GameResult.WonByO, actual);
        }

        [TestMethod]
        public void Draw()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("XXOOXXXOO");
            Assert.AreEqual(GameResult.Draw, actual);
        }

        [TestMethod]
        public void RealTest1WinX()
        {
            var validator = new GameResultValidator();

            var actual = validator.GetResult("XO-XO-X--");
            Assert.AreEqual(GameResult.WonByX, actual);
        }
    }
}
