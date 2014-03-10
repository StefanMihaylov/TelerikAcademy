namespace ParticleSystem
{
    using System;

    public class ChaoticParticle : Particle
    {
        protected Random randomGenerator;
        protected readonly uint maxSpeed;

        // constructor
        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random generator,uint maxSpeed)
            : base(position, speed)
        {
            if (generator != null)
            {
                this.randomGenerator = generator;
            }

            this.maxSpeed = maxSpeed;
        }        

        protected override void Move()
        {
            int minValue = -(int)this.maxSpeed;
            int maxValue = (int)this.maxSpeed;
            int newRowSpeed = this.randomGenerator.Next(minValue, maxValue + 1);
            int newColSpeed = this.randomGenerator.Next(minValue, maxValue + 1);
            this.Accelerate (new MatrixCoords(newRowSpeed, newColSpeed) - this.Speed);
            base.Move();
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'Q' } };
        }
    }
}
