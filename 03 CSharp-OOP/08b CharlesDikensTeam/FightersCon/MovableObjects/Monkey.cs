
namespace FightersCon.MovableObjects
{
    public class Monkey : Animal
    {
        private static readonly char[,] monkeyBody = new char[,] {{' ', ' ', '/', '~', '\\', ' '},
                                                   {' ', 'C', ' ','o', 'o', ' '},
                                                   {' ', '_', '(',' ', '^', ')'},
                                                   {'/', ' ', ' ',' ', '~', '\\'}};

        public Monkey(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, monkeyBody, speed, AnimalAttack, AnimalDefence)
        {
            this.Life = AnimalLife; 
            this.Bonus = AnimalDefence;
        }
    }
}
