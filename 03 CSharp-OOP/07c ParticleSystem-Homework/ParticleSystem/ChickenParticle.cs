namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class ChickenParticle : ChaoticParticle
    {
        private readonly uint stopTime;
        private uint stoppedTicks;
        private bool isStopped;
        private readonly uint stopChance;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random generator, uint maxSpeed,
            uint stopTime, uint stopChance)
            : base(position, speed, generator, maxSpeed)
        {
            if (stopChance < 0 && stopChance > 100)
            {
                throw new ArgumentOutOfRangeException("The chance to stop cannot be out of range [0...100]");
            }
            this.stopChance = stopChance;
            this.stopTime = stopTime;

            this.stoppedTicks = 0;  // same as default value
            this.isStopped = false; // same as default value
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '@' } };
        }

        protected override void Move()
        {
            if (!this.isStopped)
            {
                uint randomStopChance = (uint)this.randomGenerator.Next(0, 101);
                if (randomStopChance >= this.stopChance)
                {
                    this.isStopped = true;
                    this.stoppedTicks = this.stopTime;
                }

                base.Move();
            }
            else
            {
                if (this.stoppedTicks == this.stopTime)
                {
                    // generate
                }

                this.stoppedTicks--;

                if (this.stoppedTicks == 0)
                {
                    this.isStopped = false;
                }
            }
        }

        public override IEnumerable<Particle> Update()
        {
            var resultList = new List<Particle>();

            var baseList = base.Update();
            //resultList.Add(baseList);

            if (this.stoppedTicks == 0)
            {
                var newChicken = new ChickenParticle(this.Position, this.Speed, this.randomGenerator, this.maxSpeed,
                                 this.stopTime, this.stoppedTicks);
                resultList.Add(newChicken);
            }

            return resultList;
        }
    }
}
