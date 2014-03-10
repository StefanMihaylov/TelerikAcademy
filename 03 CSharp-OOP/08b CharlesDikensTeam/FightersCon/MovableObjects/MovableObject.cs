using System;

namespace FightersCon.MovableObjects
{
    public abstract class MovableObject : WorldObject, IMovable, IControllable
    {
        private int attackPower;
        private int defencePower;

        protected MovableObject(MatrixCoords topLeft, char[,] body, MatrixCoords speed, 
            int attackPower, int defencePower)
            : base(topLeft, body)
        {
            this.Speed = speed;
            this.AttackPower = attackPower;
            this.DefensePower = defencePower;
        }

        public MatrixCoords Speed { get; set; }

        public int AttackPower
        {
            get { return this.attackPower; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidPowerValueException("Attack power value should be positive");
                }
                this.attackPower = value;
            }
        }

        public int DefensePower
        {
            get { return this.defencePower; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidPowerValueException("Defence power value should be positive!");
                }
                this.defencePower = value;
            }
        }

        public virtual void UpdatePosition() // update of the current posiition at the speed predefined.
        {
            this.TopLeft += this.Speed;
        }

        public override void Update() // this method is called at each iteration of the game
        {
            this.UpdatePosition(); // update of the current posiition at the speed predefined.
        }
    }
}
