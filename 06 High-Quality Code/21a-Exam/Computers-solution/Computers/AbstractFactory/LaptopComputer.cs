namespace Computers.AbstractFactory
{
    using Computers;
    using Computers.Interfaces;

    public class LaptopComputer : Computer
    {
        private readonly LaptopBattery battery;

        public LaptopComputer(Cpu cpu, IMotherboard motherboard, HardDriver hardDrives)
            : base(cpu, motherboard, hardDrives)
        {
            this.battery = new LaptopBattery();
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);
            this.Mainboard.DrawOnVideoCard(string.Format("Battery status: {0}%", this.battery.Percentage));
        }
    }
}
