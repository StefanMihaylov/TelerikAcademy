using System;

namespace FightersCon.StaticObjects
{
    public class House : StaticObject
    {
        public static char[,] HouseBody = new char[,] {{' ', ' ', ' ', '@', ' ', '@', ' ', '@', ' ', ' ', ' ', ' ', ' '},
                                                       {' ', ' ', '[', ']', '_', '_', '_', ' ', ' ', ' ', ' ', ' ', ' '},
                                                       {' ', '/', ' ', ' ', ' ', ' ', '/', '\\', '_', '_', '_', '_', ' '},
                                                       {'/', '_', '/', '\\', '_', '/', '/', '_', '_', '_', '_', '/', '\\'},
                                                       {'|', ' ', '|', '|', ' ', '|', '|', '|', ' ', ' ', '|', '|', '|'},
                                                       {'|', ' ', '|', '|', ' ', '|', '|', '|', '_', '_', '|', '|', '|'}};
        public House(MatrixCoords topLeft)
            : base(topLeft, HouseBody)
        {
            IsDestroyable = false;
            this.Life = int.MaxValue;
        }
        public override void Update()
        {
        }
    }
}
