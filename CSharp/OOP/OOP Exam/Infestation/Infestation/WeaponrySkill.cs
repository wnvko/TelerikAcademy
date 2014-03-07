namespace Infestation
{
    class WeaponrySkill : ISupplement
    {
        public void ReactTo(ISupplement otherSupplement)
        {
        }

        public int PowerEffect
        {
            get { return 0; }
        }

        public int HealthEffect
        {
            get { return 0; }
        }

        public int AggressionEffect
        {
            get { return 0; }
        }
    }
}
