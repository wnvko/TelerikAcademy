namespace Infestation
{
    public class Parasite : Unit
    {
        public const int ParasitePower = 1;
        public const int ParasiteAggression = 1;
        public const int ParasiteHealth = 1;

        public Parasite(string id)
            : base(id, UnitClassification.Biological, Parasite.ParasiteHealth, Parasite.ParasitePower, Parasite.ParasiteAggression)
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
