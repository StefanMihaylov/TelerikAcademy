namespace Computers
{
    using System;
    using Computers.Interfaces;

    public class Cpu
    {
        public const string SquareValueTooSmall = "Number too low.";
        public const string SquareValueTooBig = "Number too high.";
        public const string SquareValueFormat = "Square of {0} is {1}.";

        public static readonly Random Random = new Random();

        private readonly IMaxSquareValue maxSquareValue;
        private IMotherboard mainboard;        

        public Cpu(byte numberOfCores, byte numberOfBits, IMotherboard mainboad)
            : this(numberOfCores, numberOfBits, mainboad, new MaxSquareValue())
        {
        }

        public Cpu(byte numberOfCores, byte numberOfBits, IMotherboard mainboad, IMaxSquareValue maxValue)
        {
            this.NumberOfCores = numberOfCores;
            this.NumberOfBits = numberOfBits;
            this.Mainboard = mainboad;
            this.maxSquareValue = maxValue;
        }

        public byte NumberOfCores { get; private set; }

        public byte NumberOfBits { get; private set; }

        private IMotherboard Mainboard
        {
            get
            {
                return this.mainboard;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Mainboard instance cannot be null");
                }

                this.mainboard = value;
            }
        }

        public void SquareNumber()
        {
            var maxValue = this.GetMaxSquareValue();
            this.SquareNumberByMaxValue(maxValue);
        }

        public int GetMaxSquareValue()
        {
            return this.maxSquareValue.GetMaxValue(this.NumberOfBits);
        }

        public void GenerateRandomNumber(int min, int max)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Next(0, 1000);
            }
            while (!(randomNumber >= min && randomNumber <= max));

            this.Mainboard.SaveRamValue(randomNumber);
        }

        private void SquareNumberByMaxValue(int maxValue)
        {
            var data = this.Mainboard.LoadRamValue();
            if (data < 0)
            {
                this.Mainboard.DrawOnVideoCard(SquareValueTooSmall);
            }
            else if (data > maxValue)
            {
                this.Mainboard.DrawOnVideoCard(SquareValueTooBig);
            }
            else
            {
                int value = data * data;
                this.Mainboard.DrawOnVideoCard(string.Format(SquareValueFormat, data, value));
            }
        }
    }
}
