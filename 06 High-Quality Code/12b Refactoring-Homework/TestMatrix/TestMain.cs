namespace TestMatrix
{    
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WalkInMatrix;

    [TestClass]
    public class TestMain
    {
        // http://www.softwareandi.com/2012/02/how-to-write-automated-tests-for.html
        [TestMethod]
        public void TestPrintMethod()
        {
            string expected = "  1  16  17  18  19  20 \r\n 15   2  27  28  29  21 \r\n 14  31   3  26  30  22 \r\n 13  36  32   4  25  23 \r\n 12  35  34  33   5  24 \r\n 11  10   9   8   7   6 \r\n";

            int[,] matrix = new int[,]
            {
                { 01, 16, 17, 18, 19, 20 }, 
                { 15, 02, 27, 28, 29, 21 },
                { 14, 31, 03, 26, 30, 22 },
                { 13, 36, 32, 04, 25, 23 },
                { 12, 35, 34, 33, 05, 24 },
                { 11, 10, 09, 08, 07, 06 }
            };

            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                Run.Print(matrix);
                string actual = writer.ToString();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestReadNumberMethodWhenEnterOne()
        {
            int expected = 1;

            using (var reader = new StringReader("1"))
            {
                Console.SetIn(reader);

                int actual = Run.ReadNumber(1, 100);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestReadNumberMethodWhenEnterInvalidNumeberThenFive()
        {
            int expected = 5;

            using (var reader = new StringReader("-1 \n 5"))
            {
                Console.SetIn(reader);

                int actual = Run.ReadNumber(1, 100);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestReadNumberMethodWhenEnterInvalidNumeberThenFifty()
        {
            int expected = 50;

            using (var reader = new StringReader("101 \n 50"))
            {
                Console.SetIn(reader);

                int actual = Run.ReadNumber(1, 100);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestMainMethod()
        {
            string expected = "Enter a positive number:   1  16  17  18  19  20 \r\n 15   2  27  28  29  21 \r\n 14  31   3  26  30  22 \r\n 13  36  32   4  25  23 \r\n 12  35  34  33   5  24 \r\n 11  10   9   8   7   6 \r\n";

            using (var writer = new StringWriter())
            {
                using (var reader = new StringReader("6"))
                {
                    Console.SetOut(writer);
                    Console.SetIn(reader);
                    Run.Main();
                    string actual = writer.ToString();

                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}
