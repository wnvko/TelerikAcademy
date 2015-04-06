namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Extended.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    public class WolfRaider : Creature
    {
        private const int WolfRaiderAttack = 8;
        private const int WolfRaiderDefense = 5;
        private const int WolfRaiderHealthPoints = 10;
        private const decimal WolfRaiderDamage = 3.5M;
        private const int DoubleDamageRounds = 7;

        public WolfRaider()
            : base(WolfRaiderAttack, WolfRaiderDefense, WolfRaiderHealthPoints, WolfRaiderDamage)
        {
            this.AddSpecialty(new DoubleDamage(DoubleDamageRounds));
        }
    }
}
