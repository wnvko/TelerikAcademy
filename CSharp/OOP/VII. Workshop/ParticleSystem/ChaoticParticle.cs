using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ChaoticParticle : Particle
    {
        public uint MaxSpeed { get; private set; }
        public Random Rnd { get; set; }
        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random rnd, uint maxSpeed)
            : base(position, speed)
        {
            this.Rnd = rnd;
            this.MaxSpeed = maxSpeed;
        }


        public override IEnumerable<Particle> Update()
        {
            int changedSpeedRow = Rnd.Next(-(int)MaxSpeed, (int)MaxSpeed + 1);
            int changedSpeedCol = Rnd.Next(-(int)MaxSpeed, (int)MaxSpeed + 1);

            var changedSpeed = new MatrixCoords(changedSpeedRow, changedSpeedCol);
            var zeroCoordinate = new MatrixCoords(0, 0);
            var neccesaryAcceleration = new MatrixCoords();
            
            neccesaryAcceleration = zeroCoordinate - this.Speed + changedSpeed;
            this.Accelerate(neccesaryAcceleration);

            return base.Update();
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'H' } };
        }
    }
}