namespace Infestation
{
    public class Queen : Unit
    {
        public const int QueenPower = 1;
        public const int QueenAggression = 1;
        public const int QueenHealth = 30;

        public Queen(string id)
            : base(id, UnitClassification.Psionic, Queen.QueenHealth, Queen.QueenPower, Queen.QueenAggression)
        {
            //var infestationSpores = new InfestationSpores();
            //this.AddSupplement(infestationSpores);
        }

        protected override UnitInfo GetOptimalAttackableUnit(System.Collections.Generic.IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MaxValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Id != this.Id)
                {
                    if (unit.Health < optimalAttackableUnit.Health)
                    {
                        optimalAttackableUnit = unit;
                    }
                }

            }

            return optimalAttackableUnit;
        }
    }
}
