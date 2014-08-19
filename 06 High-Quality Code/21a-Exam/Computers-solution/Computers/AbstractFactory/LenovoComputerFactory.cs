namespace Computers.AbstractFactory
{
    using System.Collections.Generic;

    public class LenovoComputerFactory : AbstractManufactorer
    {
        public override ServerComputer MakeServerComputer()
        {
            var ram = new Ram(Eight);
            var video = new VideoCard(true);
            var mainboard = new Mainboard(ram, video);

            var cpu = new Cpu(2, 128, mainboard);
            var hdd = new HardDriver(new List<HardDriver> 
                        {
                            new HardDriver(500),
                            new HardDriver(500)
                        });

            var computer = new ServerComputer(cpu, mainboard, hdd);
            return computer;
        }

        public override LaptopComputer MakeLaptopComputer()
        {
            var ram = new Ram(Eight * 2);
            var video = new VideoCard(false);

            var mainboard = new Mainboard(ram, video);
            var cpu = new Cpu(2, 64, mainboard);
            var hdd = new HardDriver(1000);

            var computer = new LaptopComputer(cpu, mainboard, hdd);
            return computer;
        }

        public override PcComputer MakePcComputer()
        {
            var ram = new Ram(Eight / 2);
            var video = new VideoCard(true);
            var mainboard = new Mainboard(ram, video);
            var cpu = new Cpu(2, 64, mainboard);
            var hdd = new HardDriver(2000);

            var computer = new PcComputer(cpu, mainboard, hdd);
            return computer;
        }
    }
}
