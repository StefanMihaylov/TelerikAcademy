namespace Computers_Tests
{
    using Computers.Interfaces;

    public class DrawToString : IDrawable
    {
        public string StringData { get; private set; }

        public void DrawOnVideoCard(string data)
        {
            this.StringData = data;
        }
    }
}
