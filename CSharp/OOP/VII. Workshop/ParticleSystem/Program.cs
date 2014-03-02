using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class Program
    {
        const int Rows = 30;
        const int Cols = 60;

        static readonly Random RandomGenerator = new Random();
        static void Main(string[] args)
        {
            var renderer = new ConsoleRenderer(Rows, Cols);

            var particleOperator = new AdvancedParticleOperator();

            var engine = new Engine(renderer, particleOperator, null, 300);

            GenerateInitialData(engine);

            engine.Run();
        }

        private static void GenerateInitialData(Engine engine)
        {
            engine.AddParticle(
                new Particle(
                    new MatrixCoords(10, 10),
                    new MatrixCoords(0, 0))
                );

            engine.AddParticle(
                new DyingParticle(
                    new MatrixCoords(20, 30),
                    new MatrixCoords(-1, 1), 8)
                );

            var emitterPosition = new MatrixCoords(29, 0);
            var emitterSpeed = new MatrixCoords(0, 0);
            var emitter = new ParticleEmitter(emitterPosition, emitterSpeed, RandomGenerator, 5, 2, GenerateRandomParticle);

            //engine.AddParticle(emitter);

            var attractorPosition = new MatrixCoords(15, 15);
            var attractor = new ParticleAttractor(attractorPosition, new MatrixCoords(0, 0), 1);

            engine.AddParticle(attractor);

            var repellerPosition = new MatrixCoords(15, 25);
            var repeller = new ParticleRepeller(repellerPosition, new MatrixCoords(0, 0), 3, 10);

            engine.AddParticle(repeller);

            //engine.AddParticle(
            //    new ChickenParticle(
            //        new MatrixCoords(10, 10),
            //        new MatrixCoords(0, 0), RandomGenerator, 2)
            //    );

        }

        static Particle GenerateRandomParticle(ParticleEmitter emitterParameter)
        {
            MatrixCoords particlePos = emitterParameter.Position;

            int particleRowSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCord, emitterParameter.MaxSpeedCord + 1);
            int particleColSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCord, emitterParameter.MaxSpeedCord + 1);

            MatrixCoords particleSpeed = new MatrixCoords(particleRowSpeed, particleColSpeed);

            Particle generated = null;

            int particleTypeIndex = emitterParameter.RandomGenerator.Next(0, 2);
            switch (particleTypeIndex)
            {
                case 0: generated = new Particle(particlePos, particleSpeed); break;
                case 1:
                    int lifespan = emitterParameter.RandomGenerator.Next(8);
                    generated = new DyingParticle(particlePos, particleSpeed, (uint)lifespan);
                    break;
                default:
                    throw new Exception("No such particle for this particleTypeIndex");
                    break;
            }

            return generated;
        }
    }
}