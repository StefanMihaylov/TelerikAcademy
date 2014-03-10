namespace FightersCon.StaticObjects
{
    public abstract class StaticObject : WorldObject
    {
        protected StaticObject(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body)
        {
        }

        public bool IsDestroyable { get; protected set; }
    }
}
