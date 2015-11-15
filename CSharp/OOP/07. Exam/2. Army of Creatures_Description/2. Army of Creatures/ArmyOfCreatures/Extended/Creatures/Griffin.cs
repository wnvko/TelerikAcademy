namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    public class Griffin : Creature
    {
        private const int GriffinAttack = 8;
        private const int GriffinDefense = 8;
        private const int GriffinHealthPoints = 25;
        private const decimal GriffinDamage = 4.5M;
        private const int DoubleDefenseRounds = 5;
        private const int AddDefensePoints = 3;

        public Griffin()
            : base(GriffinAttack, GriffinDefense, GriffinHealthPoints, GriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(DoubleDefenseRounds));
            this.AddSpecialty(new AddDefenseWhenSkip(AddDefensePoints));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
