namespace FightersCon
{
    public interface IMovable
    {
        MatrixCoords Speed
        {
            get;
        }

        void UpdatePosition();
    }
}
