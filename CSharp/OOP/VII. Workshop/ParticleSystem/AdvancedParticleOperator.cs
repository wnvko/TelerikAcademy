using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class AdvancedParticleOperator : ParticleUpdater
    {
        List<ParticleAttractor> attractors = new List<ParticleAttractor>();
        List<ParticleRepeller> repellers = new List<ParticleRepeller>();
        List<Particle> particles = new List<Particle>();
        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var attractorCandidate = p as ParticleAttractor;
            var repellerCandidate = p as ParticleRepeller;
            if (attractorCandidate == null && repellerCandidate == null)
            {
                this.particles.Add(p);
            }
            else if (attractorCandidate != null)
            {
                this.attractors.Add(attractorCandidate);
            }
            else
            {
                this.repellers.Add(repellerCandidate);
            }


            return base.OperateOn(p); ;
        }

        public override void TickEnded()
        {
            foreach (var attractor in this.attractors)
            {
                foreach (var particle in this.particles)
                {
                    var currAcceleration = GetAccelerationFromParticleToAttractor(attractor, particle);

                    particle.Accelerate(currAcceleration);
                }
            }

            foreach (var repeller in repellers)
            {
                foreach (var particle in particles)
                {
                    int deltaCol = repeller.Position.Col - particle.Position.Col;
                    int deltaRow = repeller.Position.Row - particle.Position.Row;



                    int distance = (int)Math.Sqrt((deltaCol * deltaCol + deltaRow * deltaRow));
                    if (distance < repeller.Radius)
                    {
                        var currAcceleration = GetAccelerationFromParticleToAttractor(repeller, particle);
                        currAcceleration = new MatrixCoords(0, 0) - currAcceleration;

                        particle.Accelerate(currAcceleration);
                    }
                }
            }

            this.attractors.Clear();
            this.repellers.Clear();
            this.particles.Clear();
            base.TickEnded();
        }

        private static MatrixCoords GetAccelerationFromParticleToAttractor(ParticelInfluencer attractor, Particle particle)
        {
            var currParticleAttractorVector = attractor.Position - particle.Position;

            int pToAttrRow = currParticleAttractorVector.Row;
            pToAttrRow = DecreaseVectorCoordToPower(attractor, pToAttrRow);

            int pToAttrCol = currParticleAttractorVector.Col;
            pToAttrCol = DecreaseVectorCoordToPower(attractor, pToAttrCol);

            var currAcceleration = new MatrixCoords(pToAttrRow, pToAttrCol);
            return currAcceleration;
        }

        private static int DecreaseVectorCoordToPower(ParticelInfluencer attractor, int pToAttrCord)
        {
            if (Math.Abs(pToAttrCord) > attractor.Power)
            {
                pToAttrCord = (pToAttrCord / (int)Math.Abs(pToAttrCord)) * attractor.Power;
            }

            return pToAttrCord;
        }
    }
}
