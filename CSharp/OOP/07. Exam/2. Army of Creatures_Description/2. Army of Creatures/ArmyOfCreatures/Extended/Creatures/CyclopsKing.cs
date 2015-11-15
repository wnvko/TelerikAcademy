namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Extended.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    public class CyclopsKing : Creature
    {
        private const int CyclopsKingAttack = 17;
        private const int CyclopsKingDefense = 13;
        private const int CyclopsKingHealthPoints = 70;
        private const decimal CyclopsKingDamage = 18M;
        private const int AddAttackPoints = 3;
        private const int DoubleAttackRounds = 4;
        private const int DoubleDamageRounds = 1;

        public CyclopsKing()
            : base(CyclopsKingAttack, CyclopsKingDefense, CyclopsKingHealthPoints, CyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(AddAttackPoints));
            this.AddSpecialty(new DoubleAttackWhenAttacking(DoubleAttackRounds));
            this.AddSpecialty(new DoubleDamage(DoubleDamageRounds));
        }
    }
}
