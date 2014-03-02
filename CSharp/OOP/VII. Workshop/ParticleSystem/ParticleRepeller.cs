using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleRepeller : ParticelInfluencer
    {
        public int Radius { get; private set; }
        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int attractionPower, int radius)
            : base(position, speed, attractionPower)
        {
            this.Radius = radius;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'R' } };
        }
    }
}
