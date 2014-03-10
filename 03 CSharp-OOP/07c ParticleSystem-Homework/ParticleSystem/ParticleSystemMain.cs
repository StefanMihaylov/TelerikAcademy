using System;

namespace ParticleSystem
{
    class ParticleSystemMain
    {
        const int Rows = 38;
        const int Cols = 50;

        static readonly Random randomGenerator = new Random();

        static void Main()
        {
            var renderer = new ConsoleRenderer(Rows, Cols);
            //var particleOperator = new AdvancedParticleOperator();
            var particleOperator = new UpdatedAdvancedParticleOperator();
            var engine = new Engine(renderer, particleOperator, null, 300);

            GenerateInitialData(engine);

            engine.Run();
        }

        private static void GenerateInitialData(Engine engine)
        {
            /* Code written by Joro
             
            engine.AddParticle(new Particle(new MatrixCoords(0, 8), new MatrixCoords(1, 0)));
            engine.AddParticle(new DyingParticle(new MatrixCoords(20, 5), new MatrixCoords(-1, 1), 12));

            var emitterPosition = new MatrixCoords(29, 0);
            var emitterSpeed = new MatrixCoords(0, 0);
            var emitter = new ParticleEmitter(emitterPosition, emitterSpeed, RandomGenerator, 5, 2, GenerateRandomParticle);
            engine.AddParticle(emitter);

            var attractorPosition = new MatrixCoords(10, 3);
            var attractor = new ParticleAttractor(attractorPosition, new MatrixCoords(0, 0), 1);
            var attractorPosition2 = new MatrixCoords(10, 13);
            var attractor2 = new ParticleAttractor(attractorPosition2, new MatrixCoords(0, 0), 3);
            //engine.AddParticle(attractor);
            //engine.AddParticle(attractor2);
             */

            // homework            
            // Exercise 1 & 2 = Chaotic Particle , symbol "Q", speed [-2;2]
            var chaoticPosition = new MatrixCoords(15, 15);
            var chaoticSpeed = new MatrixCoords(0, 0);
            engine.AddParticle(new ChaoticParticle(chaoticPosition, chaoticSpeed, randomGenerator, 2));

            // Exercise 3 & 4 = Shicken Particle , symbol "@", speed [-3;3], stop for 10 ticks, chance not to stop 90%
            var chickenPosition = new MatrixCoords(10, 10);
            engine.AddParticle(new ChickenParticle(chickenPosition, chaoticSpeed, randomGenerator, 3, 10, 90));

            // Exercise 5 & 6 = Repeller Particle , symbol "*", speed [0;0], power=3, repeller raduis = 5;

             /*  // comment that row to test ParticleRepeller but comment ChickenParticle !!!
           
           var repellerPosition = new MatrixCoords(10, 18);
           var repellerPosition2 = new MatrixCoords(30, 22);
           var repellerSpeed = new MatrixCoords(0, 0);
           engine.AddParticle(new ParticleRepeller(repellerPosition, repellerSpeed, 3, 5.0));
           engine.AddParticle(new ParticleRepeller(repellerPosition2, repellerSpeed, 3, 5.0));
            
           var emitterPosition = new MatrixCoords(20, 20);
           var emitterSpeed = new MatrixCoords(0, 0);
           var emitter = new ParticleEmitter(emitterPosition, emitterSpeed, randomGenerator, 5, 2, GenerateRandomParticle);
           engine.AddParticle(emitter);
       
            //*/
        }

        static Particle GenerateRandomParticle(ParticleEmitter emitterParameter)
        {
            MatrixCoords particlePos = emitterParameter.Position;

            int particleRowSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);
            int particleColSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);

            MatrixCoords particleSpeed = new MatrixCoords(particleRowSpeed, particleColSpeed);

            Particle generated = null;

            int particleTypeIndex = emitterParameter.RandomGenerator.Next(0, 2);
            switch (particleTypeIndex)
            {
                case 0: generated = new Particle(particlePos, particleSpeed); break;
                case 1:
                    uint lifespan = (uint)emitterParameter.RandomGenerator.Next(8);
                    generated = new DyingParticle(particlePos, particleSpeed, lifespan);
                    break;
                default:
                    throw new Exception("No such particle for this particleTypeIndex");
            }
            return generated;
        }
    }
}
