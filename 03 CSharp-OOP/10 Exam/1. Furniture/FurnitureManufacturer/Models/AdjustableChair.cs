namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string chairModel, string chairMaterial, decimal chairPrice, decimal chairHeight, int chairLegs)
            : base(chairModel, chairMaterial, chairPrice, chairHeight, chairLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            if (height > 0.0m)
            {
                this.Height = height;
            }
        }
    }
}
