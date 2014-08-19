namespace Computers
{
    using System;
    using Computers.Interfaces;

    public class VideoCard : IDrawable
    {
        public VideoCard(bool isMonochrom)
        {
            this.IsMonochrome = isMonochrom;
        }

        public bool IsMonochrome { get; set; }

        public void Draw(string text)
        {
            if (this.IsMonochrome)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(text);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                Console.ResetColor();
            }
        }

        public void DrawOnVideoCard(string data)
        {
            this.Draw(data);
        }
    }
}
