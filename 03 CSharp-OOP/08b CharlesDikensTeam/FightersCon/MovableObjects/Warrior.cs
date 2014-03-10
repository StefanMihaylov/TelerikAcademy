
namespace FightersCon.MovableObjects
{
    public class Warrior : Character
    {
        private const int WarriorLife = 200;

        private static readonly char[,] warriorBody = new char[,] {{' ', '@', '@', '@', '@', '@', ' '},
                                                      {'(', '|', '.',' ', '.', '|', ')'},
                                                      {' ', '\\', ' ','V', ' ', '/', ' '},
                                                      {' ', ' ', '\\','~', '/', ' ', ' '}};
       
        public Warrior(MatrixCoords topLeft, MatrixCoords speed, int attackPower = 20, int defencePower = 200)
            : base(topLeft, warriorBody, speed, attackPower, defencePower)
        {
            this.Life = WarriorLife;
        }
    }
}
