using System;
using System.Collections.Generic;

namespace FightersCon
{
    public abstract class WorldObject : IWorldObject, IRenderable, IObjectProducer
    {
        public const int InitialLife = 100;

        private MatrixCoords topLeft;
        protected char[,] body;

        protected WorldObject(MatrixCoords topLeft, char[,] body)
        {
            this.TopLeft = topLeft;
            this.body = body;
            this.IsDestroyed = false;
            this.Life = InitialLife;
        }

        public int Life { get;  set; }
        public bool IsDestroyed { get; set; }

        public MatrixCoords TopLeft
        {
            get { return this.topLeft; }
            set { this.topLeft = value; }
        }

        public abstract void Update();

        public virtual MatrixCoords GetTopLeft()
        {
            return this.TopLeft;
        }

        // this method returns the same matrix as the previous method but as a public one,
        //so other objects could also be able to use it. 
        public virtual char[,] GetImage()                   //IRenderable interface
        {
            return this.body;
        }

        public virtual IEnumerable<WorldObject> ProduceObjects() // this method returns a list of the game objects.
        {
            return new List<WorldObject>();
        }
    }
}
