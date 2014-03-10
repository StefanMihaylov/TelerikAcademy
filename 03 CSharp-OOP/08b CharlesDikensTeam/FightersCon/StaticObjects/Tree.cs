using System;


namespace FightersCon.StaticObjects
{
    public class Tree : StaticObject
    {
        public static char[,] TreeBody = new char[,] {{' ', '(', '~', '~', ')', ' '},
                                                  {'(', '~', '~', '~', '~', ')'},
                                                  {' ', '(', '~', '~', ')', ' '},
                                                  {' ', ' ', '|', '|', ' ', ' '},
                                                  {' ', '_', '|', '|', '_',' '}};
        public Tree(MatrixCoords topLeft)
            : base(topLeft, TreeBody)
        {
            IsDestroyable = false;
            this.Life = int.MaxValue;
        }
        public override void Update()
        {
        }
    }
}
