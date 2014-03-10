
namespace FightersCon.MovableObjects
{
    public abstract class Character : MovableObject
    {
        protected Character(MatrixCoords topLeft, char[,] body, MatrixCoords speed,
            int attackPower, int defencePower)
            : base(topLeft, body, speed, attackPower, defencePower)
        {
        }
    }
}
