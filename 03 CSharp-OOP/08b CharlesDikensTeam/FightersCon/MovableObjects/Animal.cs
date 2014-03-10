
namespace FightersCon.MovableObjects
{
    public abstract class Animal: MovableObject
    {
        protected const int AnimalLife = 100;
        protected const int AnimalAttack = 20;
        protected const int AnimalDefence = 100;
        protected const int AnimalBonus = 100;

        protected Animal(MatrixCoords topLeft, char[,] body, MatrixCoords speed, 
            int attackPower, int defencePower)
            : base(topLeft, body, speed, attackPower, defencePower)
        {
            this.Bonus = attackPower;
        }
         public int Bonus { get; protected set; }   
    }
}
