namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    class Chair : Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(string chairModel, string chairMaterial, decimal chairPrice, decimal chairHeight, int chairLegs)
            : base(chairModel, chairMaterial, chairPrice, chairHeight)
        {
            this.NumberOfLegs = chairLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }

            protected set
            {
                if (value <= 0) // or better <= 2 ??
                {
                    throw new ArgumentOutOfRangeException("Chair legs must be positive number");
                }
                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Legs: {1}", base.ToString(), this.NumberOfLegs);
        }
    }
}
