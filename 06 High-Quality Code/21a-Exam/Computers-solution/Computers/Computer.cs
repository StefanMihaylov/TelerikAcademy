namespace Computers
{
    using System.Collections.Generic;
    using Computers.Interfaces;

    public class Computer
    {
        public Computer(Cpu cpu, IMotherboard motherboard, HardDriver hardDrives)
        {
            this.Cpu = cpu;
            this.Mainboard = motherboard;
            this.HardDrives = hardDrives;
        }

        public HardDriver HardDrives { get; set; }

        public IMotherboard Mainboard { get; set; }

        public Cpu Cpu { get; set; }

        public void Play(int guessNumber)
        {
            this.Cpu.GenerateRandomNumber(1, 10);
            var number = this.Mainboard.LoadRamValue();

            if (number != guessNumber)
            {
                this.Mainboard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.Mainboard.DrawOnVideoCard("You win!");
            }
        }

        public void Process(int data)
        {
            this.Mainboard.SaveRamValue(data);
            this.Cpu.SquareNumber();
        }
    }
}
