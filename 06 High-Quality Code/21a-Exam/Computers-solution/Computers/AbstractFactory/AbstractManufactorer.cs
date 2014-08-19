namespace Computers.AbstractFactory
{
    public abstract class AbstractManufactorer
    {
        public const int Eight = 8;

        public abstract ServerComputer MakeServerComputer();

        public abstract LaptopComputer MakeLaptopComputer();

        public abstract PcComputer MakePcComputer();
    }
}
