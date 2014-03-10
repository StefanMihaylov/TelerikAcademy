namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedChairHeight = 0.10m;

        public ConvertibleChair(string chairModel, string chairMaterial, decimal chairPrice, decimal chairHeight, int chairLegs)
            : base(chairModel, chairMaterial, chairPrice, chairHeight, chairLegs)
        {
            this.IsConverted = false;
        }

        public bool IsConverted {get; private set;}


        public void Convert()
        {
            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            return string.Format("{0}, State: {1}", base.ToString(), this.IsConverted ? "Converted" : "Normal");
        }

        public override decimal Height
        {
            get
            {
                if (IsConverted)
                {
                    return ConvertedChairHeight;
                }
                else
                {
                    return base.Height;
                }
                
            }
            protected set
            {
                base.Height = value;
            }
        }
    }
}
