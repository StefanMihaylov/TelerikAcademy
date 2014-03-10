using System;

namespace FightersCon.StaticObjects
{
    public class Fence : StaticObject
    {
        public const int FenceLife = 20;

        public Fence(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body)
        {
            IsDestroyable = true;
            //this.Life = Init.StaticLife;
            this.Life = FenceLife;
        }
        public override void Update()
        {
        }
    }
}
