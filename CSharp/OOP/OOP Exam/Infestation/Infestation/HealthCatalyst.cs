namespace Infestation
{
    class HealthCatalyst : ISupplement
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
            get { return 3; }
        }

        public int AggressionEffect
        {
            get { return 0; }
        }
    }
}
