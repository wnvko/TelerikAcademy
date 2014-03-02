using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ChickenParticle : ChaoticParticle
    {
        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random rnd, uint maxSpeed)
            : base(position, speed, rnd, maxSpeed)
        { }

        public override IEnumerable<Particle> Update()
        {
            List<Particle> result = new List<Particle>();
            int randomStop = Rnd.Next(11);
            if (randomStop == 10)
            {
                var addedChickenParticle = new ChickenParticle(this.Position, this.Speed, this.Rnd, this.MaxSpeed);
                result.Add(addedChickenParticle);
                return result;
            }
            else
            {
                return base.Update();
            }
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'C' } };
        }
    }
}
