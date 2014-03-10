namespace ParticleSystem
{
    using System;

    public class ParticleRepeller : Particle
    {
        public double Radius { get; private set; }
        public int Power { get; private set; }

        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int power, double repellerRadius) :
            base(position, speed)
        {
            this.Radius = repellerRadius;
            this.Power = power;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '*' } };
        }
    }
}
