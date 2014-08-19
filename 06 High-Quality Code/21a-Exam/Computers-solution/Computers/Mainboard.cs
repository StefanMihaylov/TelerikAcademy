namespace Computers
{
    using System;
    using Computers.Interfaces;

    public class Mainboard : IMotherboard
    {
        private Ram ram;
        private IDrawable video;

        public Mainboard(Ram ram, IDrawable video)
        {
            this.Ram = ram;
            this.Video = video;
        }

        public Ram Ram
        {
            get
            {
                return this.ram;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("RAM instance cannot be null");
                }

                this.ram = value;
            }
        }

        public IDrawable Video
        {
            get
            {
                return this.video;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Video card instance cannot be null");
                }

                this.video = value;
            }
        }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.Video.DrawOnVideoCard(data);
        }
    }
}
