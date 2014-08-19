namespace Computers.AbstractFactory
{
    using Computers;
    using Computers.Interfaces;

    public class ServerComputer : Computer
    {
        public ServerComputer(Cpu cpu, IMotherboard motherboard, HardDriver hardDrives)
            : base(cpu, motherboard, hardDrives)
        {
        }
    }
}
