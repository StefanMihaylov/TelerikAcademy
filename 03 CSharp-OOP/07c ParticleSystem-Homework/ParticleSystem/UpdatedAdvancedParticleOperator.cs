using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class UpdatedAdvancedParticleOperator : ParticleUpdater
    {
        // copy-paste from AdvancedParticleOperator class with some changes

        private List<ParticleRepeller> repellers = new List<ParticleRepeller>();
        private List<Particle> particles = new List<Particle>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var repellerCandidate = p as ParticleRepeller;
            if (repellerCandidate == null)
            {
                this.particles.Add(p);
            }
            else
            {
                this.repellers.Add(repellerCandidate);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in this.repellers)
            {
                foreach (var particle in this.particles)
                {
                    int distanceCol = repeller.Position.Col - particle.Position.Col;
                    int distanceRow = repeller.Position.Row - particle.Position.Row;
                    double radius = Math.Sqrt(distanceRow * distanceRow + distanceCol * distanceCol);

                    if (radius < repeller.Radius)
                    {
                        var currAcceleration = GetAccelerationAwayFromRepeller(repeller, particle);
                        particle.Accelerate(currAcceleration);   
                    }                   
                }
            }

            this.repellers.Clear();
            this.particles.Clear();
            base.TickEnded();
        }

        private static MatrixCoords GetAccelerationAwayFromRepeller(ParticleRepeller repeller, Particle particle)
        {
            var currParticleToAttractorVector = repeller.Position - particle.Position;

            int pToAttrRow = currParticleToAttractorVector.Row;
            pToAttrRow = DecreaseVectorCoordToPower(repeller, pToAttrRow);

            int pToAttrCol = currParticleToAttractorVector.Col;
            pToAttrCol = DecreaseVectorCoordToPower(repeller, pToAttrCol);

            // attactor (pToAttrRow, pToAttrCol) ; repeller (-pToAttrRow, -pToAttrCol);
            var currAcceleration = new MatrixCoords(-pToAttrRow, -pToAttrCol);
            return currAcceleration;
        }

        private static int DecreaseVectorCoordToPower(ParticleRepeller repeller, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > repeller.Power)
            {
                pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * repeller.Power;
            }
            return pToAttrCoord;
        }
    }
}
