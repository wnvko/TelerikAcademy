namespace Infestation
{
  public  class InfestationSpores :ISupplement
    {
        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType().Name == "InfestationSpores")
            {

            }
        }

        public int PowerEffect
        {
            get { return -1; }
        }

        public int HealthEffect
        {
            get { return 0; }
        }

        public int AggressionEffect
        {
            get { return 20; }
        }
    }
}
