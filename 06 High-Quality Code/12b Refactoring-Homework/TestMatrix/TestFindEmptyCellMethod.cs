namespace TestMatrix
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WalkInMatrix;

    [TestClass]
    public class TestFindEmptyCellMethod
    {
        [TestMethod]
        public void FindZeroCell()
        {
            int[,] matrix = new int[3, 3];
            Cell actual = WalkInMatrix.FindFirstEmptyCell(matrix);
            Cell expected = new Cell(0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindEndOfRowCell()
        {
            int[,] matrix = new int[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 0 },
                    { 0, 0, 0 },
                };
            Cell actual = WalkInMatrix.FindFirstEmptyCell(matrix);
            Cell expected = new Cell(1, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindEndOfColCell()
        {
            int[,] matrix = new int[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 0, 0 },
                };
            Cell actual = WalkInMatrix.FindFirstEmptyCell(matrix);
            Cell expected = new Cell(2, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MatrixCellsAreFull()
        {
            int[,] matrix = new int[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 },
                };
            Cell actual = WalkInMatrix.FindFirstEmptyCell(matrix);

            Assert.IsNull(actual);
        }
    }
}
