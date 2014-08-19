﻿namespace Computers
{
    public class LaptopBattery
    {
        public LaptopBattery()
        {
            this.Percentage = 100 / 2;
        }

        public int Percentage { get; private set; }

        public void Charge(int newPercentage)
        {
            this.Percentage += newPercentage;
            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }

            if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}
