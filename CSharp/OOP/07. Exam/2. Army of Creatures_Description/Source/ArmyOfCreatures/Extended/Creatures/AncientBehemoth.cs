namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    public class AncientBehemoth : Creature
    {
        private const int AncientBehemothAttack = 19;
        private const int AncientBehemothDefense = 19;
        private const int AncientBehemothHealthPoints = 300;
        private const decimal AncientBehemothDamage = 40M;
        private const int ReduceEnemyDefensePercentage = 80;
        private const int DoubleDefenseRounds = 5;

        public AncientBehemoth()
            : base(AncientBehemothAttack, AncientBehemothDefense, AncientBehemothHealthPoints, AncientBehemothDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(ReduceEnemyDefensePercentage));
            this.AddSpecialty(new DoubleDefenseWhenDefending(DoubleDefenseRounds));
        }
    }
}
