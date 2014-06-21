namespace TestMatrix
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WalkInMatrix;

    [TestClass]
    public class TestVector
    {
        [TestMethod]
        public void EnterZeroValueForXDirection()
        {
            Vector actual = new Vector(0, 1);
            Vector expected = new Vector(0, 0);
            expected.X = 0;
            expected.Y = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnterZeroValueForYDirection()
        {
            Vector actual = new Vector(1, 0);
            Vector expected = new Vector(0, 0);
            expected.X = 1;
            expected.Y = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnterValueOneForBothDirections()
        {
            Vector actual = new Vector(1, 1);
            Vector expected = new Vector(0, 0);
            expected.X = 1;
            expected.Y = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnterValueMinusOneForBothDirections()
        {
            Vector actual = new Vector(-1, -1);
            Vector expected = new Vector(0, 0);
            expected.X = -1;
            expected.Y = -1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EnterNegativeValueForXDirection()
        {
            Vector actual = new Vector(-2, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EnterNegativeValueForYDirection()
        {
            Vector actual = new Vector(1, -2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EnterNegativeValueForBothDirections()
        {
            Vector actual = new Vector(-2, -2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EnterPositiveValueForBothDirections()
        {
            Vector actual = new Vector(2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EnterPositiveValueForXDirections()
        {
            Vector actual = new Vector(2, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EnterPositiveValueForYDirections()
        {
            Vector actual = new Vector(1, 2);
        }

        [TestMethod]
        public void TestChangeDirection1()
        {
            Vector actual = new Vector(1, 1);
            actual.Rotate();

            Vector expected = new Vector(1, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChangeDirection2()
        {
            Vector actual = new Vector(1, 0);
            actual.Rotate();

            Vector expected = new Vector(1, -1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChangeDirection3()
        {
            Vector actual = new Vector(1, -1);
            actual.Rotate();

            Vector expected = new Vector(0, -1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChangeDirection4()
        {
            Vector actual = new Vector(0, -1);
            actual.Rotate();

            Vector expected = new Vector(-1, -1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChangeDirection5()
        {
            Vector actual = new Vector(-1, -1);
            actual.Rotate();

            Vector expected = new Vector(-1, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChangeDirection6()
        {
            Vector actual = new Vector(-1, 0);
            actual.Rotate();
            
            Vector expected = new Vector(-1, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChangeDirection7()
        {
            Vector actual = new Vector(-1, 1);
            actual.Rotate();

            Vector expected = new Vector(0, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChangeDirection8()
        {
            Vector actual = new Vector(0, 1);
            actual.Rotate();

            Vector expected = new Vector(1, 1);

            Assert.AreEqual(expected, actual);
        }
    }
}
