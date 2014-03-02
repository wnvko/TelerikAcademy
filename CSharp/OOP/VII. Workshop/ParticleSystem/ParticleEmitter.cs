using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleEmitter : Particle
    {
        private uint maxEmittedPerTickCount;
        private Func<ParticleEmitter, Particle> randomParticleGeneratorMethod;

        public ParticleEmitter(MatrixCoords position, MatrixCoords speed,
            Random randomGenerator,
            uint maxEmittedPerTickCount, uint maxAbsSpeedCord,
            Func<ParticleEmitter, Particle> randomParticleGeneratorMethod)
            : base(position, speed)
        {
            this.RandomGenerator = randomGenerator;
            this.maxEmittedPerTickCount = maxEmittedPerTickCount;
            this.MinSpeedCord = -(int)maxAbsSpeedCord;
            this.MaxSpeedCord = (int)maxAbsSpeedCord;
            this.randomParticleGeneratorMethod = randomParticleGeneratorMethod;
        }

        public Random RandomGenerator { get; private set; }
        public int MaxSpeedCord { get; private set; }
        public int MinSpeedCord { get; private set; }

        public override IEnumerable<Particle> Update()
        {
            var baseProduced = base.Update();

            List<Particle> produced = new List<Particle>();
            int emittedCount = this.RandomGenerator.Next((int)maxEmittedPerTickCount + 1);

            for (int i = 0; i < emittedCount; i++)
            {
                Particle p = GetRandomPatricle();
                produced.Add(p);
            }

            produced.AddRange(baseProduced);
            return produced;
        }

        private Particle GetRandomPatricle()
        {
            Particle result = this.randomParticleGeneratorMethod(this);
            return result;
        }
    }
}
