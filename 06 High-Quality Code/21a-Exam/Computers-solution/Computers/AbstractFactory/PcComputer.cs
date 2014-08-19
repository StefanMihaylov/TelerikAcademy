namespace Computers.AbstractFactory
{
    using Computers.Interfaces;

    public class PcComputer : Computer
    {
        public PcComputer(Cpu cpu, IMotherboard motherboard, HardDriver hardDrives)
            : base(cpu, motherboard, hardDrives)
        {
        }            
    }
}
