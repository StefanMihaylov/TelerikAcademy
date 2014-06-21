namespace TestMatrix
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WalkInMatrix;

    [TestClass]
    public class TestCell
    {
        [TestMethod]
        public void EnterZeroValueForXDirection()
        {
            Cell actual = new Cell(0, 1);
            Cell expected = new Cell();
            expected.X = 0;
            expected.Y = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnterZeroValueForYDirection()
        {
            Cell actual = new Cell(1, 0);
            Cell expected = new Cell();
            expected.X = 1;
            expected.Y = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnterValueOneForBothDirections()
        {
            Cell actual = new Cell(1, 1);
            Cell expected = new Cell();
            expected.X = 1;
            expected.Y = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCellEmptyConsructor()
        {
            Cell actual = new Cell();
            Cell expected = new Cell();
            expected.X = 0;
            expected.Y = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EnterNegativeValueForXDirection()
        {
            Cell actual = new Cell(-1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EnterNegativeValueForYDirection()
        {
            Cell actual = new Cell(1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EnterNegativeValueForBothDirections()
        {
            Cell actual = new Cell(-1, -1);
        }

        [TestMethod]
        public void TestCellAddByZero()
        {
            Cell actual = new Cell(1, 1) + new Vector(0, 0);
            Cell expected = new Cell(1, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCellAddByOneAndZero()
        {
            Cell actual = new Cell(1, 1) + new Vector(1, 0);
            Cell expected = new Cell(2, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCellAddByZeroAndOne()
        {
            Cell actual = new Cell(1, 1) + new Vector(0, 1);
            Cell expected = new Cell(1, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCellAddByOne()
        {
            Cell actual = new Cell(1, 1) + new Vector(1, 1);
            Cell expected = new Cell(2, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCellAddByMinusOne()
        {
            Cell actual = new Cell(1, 1) + new Vector(-1, -1);
            Cell expected = new Cell(0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString()
        {
            string actual = new Cell(1, 1).ToString();
            string expected = "{1, 1}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            int actual = new Cell(1, 1).GetHashCode();
            int expected = 1001;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEquals()
        {
            Cell firstCell = new Cell(1, 1);
            Cell secondCell = new Cell(1, 1);
            bool actual = firstCell.Equals(secondCell);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestNotEquals()
        {
            Cell firstCell = new Cell(0, 1);
            Cell secondCell = new Cell(1, 1);
            bool actual = firstCell.Equals(secondCell);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TestNotEquals2()
        {
            int number = 1;
            Cell secondCell = new Cell(1, 1);
            bool actual = secondCell.Equals(number);

            Assert.IsFalse(actual);
        }
    }
}
