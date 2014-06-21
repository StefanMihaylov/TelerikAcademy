namespace TestMatrix
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WalkInMatrix;

    [TestClass]
    public class TestFillMatrix
    {
        public const int TimeOut = 500;

        [TestMethod]
        [Timeout(TimeOut)]
        public void FinalResultMatrixSize1()
        {
            int[,] actual = WalkInMatrix.FillMatrix(1);
            int[,] expected = new int[,]
            {
                { 1 }
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Timeout(TimeOut)]
        public void FinalResultMatrixSize2()
        {
            int[,] actual = WalkInMatrix.FillMatrix(2);
            int[,] expected = new int[,]
            {
                { 1, 4 }, 
                { 3, 2 }
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Timeout(TimeOut)]
        public void FinalResultMatrixSize3()
        {
            int[,] actual = WalkInMatrix.FillMatrix(3);
            int[,] expected = new int[,]
            {
                { 1, 7, 8 }, 
                { 6, 2, 9 },
                { 5, 4, 3 }
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Timeout(TimeOut)]
        public void FinalResultMatrixSize4()
        {
            int[,] actual = WalkInMatrix.FillMatrix(4);
            int[,] expected = new int[,]
            {
                { 01, 10, 11, 12 }, 
                { 09, 02, 15, 13 },
                { 08, 16, 03, 14 },
                { 07, 06, 05, 04 }
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Timeout(TimeOut)]
        public void FinalResultMatrixSize5()
        {
            int[,] actual = WalkInMatrix.FillMatrix(5);
            int[,] expected = new int[,]
            {
                { 01, 13, 14, 15, 16 }, 
                { 12, 02, 21, 22, 17 },
                { 11, 23, 03, 20, 18 },
                { 10, 25, 24, 04, 19 },
                { 09, 08, 07, 06, 05 }
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Timeout(TimeOut)]
        public void FinalResultMatrixSize6()
        {
            int[,] actual = WalkInMatrix.FillMatrix(6);
            int[,] expected = new int[,]
            {
                { 01, 16, 17, 18, 19, 20 }, 
                { 15, 02, 27, 28, 29, 21 },
                { 14, 31, 03, 26, 30, 22 },
                { 13, 36, 32, 04, 25, 23 },
                { 12, 35, 34, 33, 05, 24 },
                { 11, 10, 09, 08, 07, 06 }
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Timeout(TimeOut)]
        public void FinalResultMatrixSize7()
        {
            int[,] actual = WalkInMatrix.FillMatrix(7);
            int[,] expected = new int[,]
            {
                { 01, 19, 20, 21, 22, 23, 24 }, 
                { 18, 02, 33, 34, 35, 36, 25 },
                { 17, 40, 03, 32, 39, 37, 26 },
                { 16, 48, 41, 04, 31, 38, 27 },
                { 15, 47, 49, 42, 05, 30, 28 },
                { 14, 46, 45, 44, 43, 06, 29 },
                { 13, 12, 11, 10, 09, 08, 07 }
            };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
