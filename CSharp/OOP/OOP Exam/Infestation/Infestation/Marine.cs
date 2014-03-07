namespace Infestation
{
    class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            var weaponarySkil = new WeaponrySkill();
            this.AddSupplement(weaponarySkil);
        }

        protected override UnitInfo GetOptimalAttackableUnit(System.Collections.Generic.IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Power < this.Aggression)
                {
                    if (unit.Health > optimalAttackableUnit.Health)
                    {
                        optimalAttackableUnit = unit;
                    }
                }
            }

            return optimalAttackableUnit;
        }
    }
}
