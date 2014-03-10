namespace MobilePhone
{
    public class Display
    {
        private ushort? pixelsHorizontal;
        private ushort? pixelsVertical;
        private uint? numberOfColours;

        public Display()
            : this(null, null, null)
        {
        }

        public Display(ushort? pixelsHorizontal, ushort? pixelsVertical, uint? numberOfColours)
        {
            this.PixelsHorizontal = pixelsHorizontal;
            this.PixelsVertical = pixelsVertical;
            this.NumberOfColours = numberOfColours;
        }

        public ushort? PixelsHorizontal
        {
            get { return this.pixelsHorizontal; }
            set
            {
                if (value == null || value > 0)
                {
                    this.pixelsHorizontal = value;
                }
                else
                {
                    throw new System.ArgumentException("Display pixels shold be greather than zero");
                }
            }
        }

        public ushort? PixelsVertical
        {
            get { return this.pixelsVertical; }
            set
            {
                if (value == null || value > 0)
                {
                    this.pixelsVertical = value;
                }
                else
                {
                    throw new System.ArgumentException("Display pixels shold be greather than zero");
                }
            }
        }

        public uint? NumberOfColours
        {
            get { return this.numberOfColours; }
            set
            {
                if (value == null || value > 0)
                {
                    this.numberOfColours = value;
                }
                else
                {
                    throw new System.ArgumentException("Display number of colours shold be greather than zero");
                }
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            result.AppendFormat("\n   Resolution: {0}x{1}\n", this.PixelsVertical, this.PixelsHorizontal);
            result.AppendFormat("   Number of colours: {0}", this.NumberOfColours);
            return result.ToString();
        }
    }
}
