namespace Computers_Tests
{
    using System;
    using Computers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;    

    [TestClass]
    public class BatteryChargeMethodTests
    {
        [TestMethod]
        public void ChargeTheBatteryWithZeroCharge()
        {
            var battery = new LaptopBattery();
            battery.Charge(0);
            var actual = battery.Percentage;
            Assert.AreEqual(50, actual);
        }

        [TestMethod]
        public void ChargeTheBatteryWithNegativeCharge()
        {
            var battery = new LaptopBattery();
            battery.Charge(-10);
            var actual = battery.Percentage;
            Assert.AreEqual(40, actual);
        }

        [TestMethod]
        public void ChargeTheBatteryWithPositiveCharge()
        {
            var battery = new LaptopBattery();
            battery.Charge(10);
            var actual = battery.Percentage;
            Assert.AreEqual(60, actual);
        }

        [TestMethod]
        public void ChargeTheBatteryTwiceWithPositiveCharge()
        {
            var battery = new LaptopBattery();
            battery.Charge(10);
            battery.Charge(10);
            var actual = battery.Percentage;
            Assert.AreEqual(70, actual);
        }

        [TestMethod]
        public void ChargeTheBatteryToCharge99()
        {
            var battery = new LaptopBattery();
            battery.Charge(49);
            var actual = battery.Percentage;
            Assert.AreEqual(99, actual);
        }

        [TestMethod]
        public void ChargeTheBatteryWithTwiceNegativeCharge()
        {
            var battery = new LaptopBattery();
            battery.Charge(-10);
            battery.Charge(-10);
            var actual = battery.Percentage;
            Assert.AreEqual(30, actual);
        }

        [TestMethod]
        public void ChargeTheBatteryWithNegativeAndPositiveCharge()
        {
            var battery = new LaptopBattery();
            battery.Charge(-10);
            battery.Charge(10);
            var actual = battery.Percentage;
            Assert.AreEqual(50, actual);
        }

        [TestMethod]
        public void OverchargeTheBattery()
        {
            var battery = new LaptopBattery();
            battery.Charge(100);
            var actual = battery.Percentage;
            Assert.AreEqual(100, actual);
        }

        [TestMethod]
        public void WithdrawTheBattery()
        {
            var battery = new LaptopBattery();
            battery.Charge(-100);
            var actual = battery.Percentage;
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void WithdrawTheBatteryToChargeOne()
        {
            var battery = new LaptopBattery();
            battery.Charge(-49);
            var actual = battery.Percentage;
            Assert.AreEqual(1, actual);
        }
    }
}
