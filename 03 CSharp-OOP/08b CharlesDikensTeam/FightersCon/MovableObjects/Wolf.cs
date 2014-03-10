
namespace FightersCon.MovableObjects
{
    public class Wolf : Animal
    {
        private static readonly char[,] wolfBody = new char[,] {{' ', '_', '_', '_', '_', '|', '\\', ' ', ' ', ' '},
                                                       {'`', '_', '/', ' ', ' ', ' ', ' ', '\\', ' ', ' '},
                                                       {' ', '(', '\\', '_', '/', ')', ' ', ' ', '\\', ' '},
                                                       {' ', '/', '_', ' ', ' ', '_', ' ', ' ', ' ', '|'},
                                                       {' ', '\\', '/', '_', '/', '|', '|', ')', ' ', '/'},
                                                       {' ', ' ', ' ', ' ', '\'', '_', '_', '_', '\'', ' '}};
        public Wolf(MatrixCoords topLeft, MatrixCoords speed, int attackPower)
            : base(topLeft, wolfBody, speed, attackPower, 0)
        {
            this.Life = AnimalLife;
            this.Bonus = AnimalAttack;
        }
    }
}
