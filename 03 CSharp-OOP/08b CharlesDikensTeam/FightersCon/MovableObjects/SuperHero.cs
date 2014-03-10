
namespace FightersCon.MovableObjects
{
    public class SuperHero : Character
    {
        private const int SuperHeroLife = 200;
        private const int SuperHeroGold = 100;
        private const int SuperHeroExpirience = 1;

        private static readonly char[,] heroBody = new char[,] {{'/', '/', '-', '-', '\\'},
                                                      {'C', ' ', 'O',' ', 'O'},
                                                      {' ', '\\', ' ',' ', '>'},
                                                      {' ', ' ', '\\','_', '-'}};                

        public SuperHero(MatrixCoords topLeft, MatrixCoords speed,int attackPower, int defencePower)
            : base(topLeft, heroBody, speed, attackPower, defencePower)
        {
            this.Life = SuperHeroLife;
            this.Gold = SuperHeroGold;
            this.Experience = SuperHeroExpirience;
        }

        public int Gold { get; private set; }
        public int Experience { get; private set; }

        // methods
        public bool Attack(MovableObject enemy)
        {
            //double enemyAtacs = this.Life / enemy.AttackPower;
            //double heroAttacs = enemy.Life / this.AttackPower;

            if (enemy.AttackPower <= this.AttackPower)
            {
                this.Experience += enemy.Life;
                this.AttackPower += this.Experience / 10;
                return true;
            }
            return false;
        }
    }
}


