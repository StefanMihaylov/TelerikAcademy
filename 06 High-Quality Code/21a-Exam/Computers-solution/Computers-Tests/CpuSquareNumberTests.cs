namespace Computers_Tests
{
    using System;
    using Computers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CpuSquareNumberTests
    {
        private Mainboard mainboard;
        private DrawToString video;

        [TestInitialize]
        public void InitializeMainboard()
        {
            var ram = new Ram(8);
            this.video = new DrawToString();
            this.mainboard = new Mainboard(ram, video);
        }

        [TestMethod]
        public void TestInputOfZero()
        {
            var cpu = new Cpu(1, 32, this.mainboard);
            this.mainboard.SaveRamValue(0);
            cpu.SquareNumber();

            var actual = this.video.StringData;
            var expected = string.Format(Cpu.SquareValueFormat, 0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInputOfOne()
        {
            var cpu = new Cpu(1, 32, this.mainboard);
            this.mainboard.SaveRamValue(1);
            cpu.SquareNumber();
            var actual = this.video.StringData;
            var expected = string.Format(Cpu.SquareValueFormat, 1, 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInputOfTwo()
        {
            var cpu = new Cpu(1, 32, this.mainboard);
            this.mainboard.SaveRamValue(2);
            cpu.SquareNumber();
            var actual = this.video.StringData;
            var expected = string.Format(Cpu.SquareValueFormat, 2, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInputOf16()
        {
            var cpu = new Cpu(1, 32, this.mainboard);
            this.mainboard.SaveRamValue(16);
            cpu.SquareNumber();
            var actual = this.video.StringData;
            var expected = string.Format(Cpu.SquareValueFormat, 16, 256);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInputOfMinusOne()
        {
            var cpu = new Cpu(1, 32, this.mainboard);
            this.mainboard.SaveRamValue(-1);
            cpu.SquareNumber();
            var actual = this.video.StringData;
            var expected = Cpu.SquareValueTooSmall;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInputOfMaxValue()
        {
            var cpu = new Cpu(1, 32, this.mainboard);
            var maxValue = cpu.GetMaxSquareValue();

            this.mainboard.SaveRamValue(maxValue);
            cpu.SquareNumber();
            var actual = this.video.StringData;
            var expected = string.Format(Cpu.SquareValueFormat, maxValue, maxValue * maxValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInputOfHalfOfMaxValue()
        {
            var cpu = new Cpu(1, 32, this.mainboard);
            var testNumber = cpu.GetMaxSquareValue()/2;

            this.mainboard.SaveRamValue(testNumber);
            cpu.SquareNumber();
            var actual = this.video.StringData;
            var expected = string.Format(Cpu.SquareValueFormat, testNumber, testNumber * testNumber);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInputOfMaxValuePlusOne()
        {
            var cpu = new Cpu(1, 32, this.mainboard);
            var maxValue = cpu.GetMaxSquareValue() + 1;

            this.mainboard.SaveRamValue(maxValue);
            cpu.SquareNumber();
            var actual = this.video.StringData;
            var expected = Cpu.SquareValueTooBig;
            Assert.AreEqual(expected, actual);
        }
    }
}
