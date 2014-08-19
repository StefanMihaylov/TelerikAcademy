namespace Computers
{    
    using System;
    using Computers.AbstractFactory;

    public class SimpleFactory
    {
        public const string DellName = "Dell";
        public const string HpName = "HP";
        public const string LenovoName = "Lenovo";
        public const string InvalidName = "Invalid manufacturer!";

        public virtual AbstractManufactorer MakeComputer(string manufacturer)
        {
            AbstractManufactorer computerManufacturer;
            if (manufacturer == HpName)
            {
                computerManufacturer = new HpComputerFactory();
            }
            else if (manufacturer == DellName)
            {
                computerManufacturer = new DellComputerFactory();
            }
            else if (manufacturer == LenovoName)
            {
                computerManufacturer = new LenovoComputerFactory();
            }
            else
            {
                throw new ArgumentException(InvalidName);
            }

            return computerManufacturer;
        }
    }
}
