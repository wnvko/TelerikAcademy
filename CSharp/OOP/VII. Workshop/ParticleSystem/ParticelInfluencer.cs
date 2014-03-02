using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticelInfluencer : Particle
    {
        public int Power { get; private set; }
        public ParticelInfluencer(MatrixCoords position, MatrixCoords speed, int attractionPower)
            : base(position, speed)
        {
            this.Power = attractionPower;
        }
    }
}
