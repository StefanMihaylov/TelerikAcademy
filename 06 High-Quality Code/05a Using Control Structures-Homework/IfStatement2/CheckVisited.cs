namespace IfStatement2
{
    public class CheckVisited
    {
        public const int MinX = 0;
        public const int MaxX = 100;

        public const int MinY = 0;
        public const int MaxY = 100;

        public static void Main()
        {
            int x = 50;
            int y = 30;
            bool isVsited = false;

            if (!isVsited && ((MinX <= x) && (x <= MaxX)) && ((MinY <= y) && (y <= MaxY)))
            {
                VisitCell();
            }
        }

        public static void VisitCell()
        {
        }
    }
}
