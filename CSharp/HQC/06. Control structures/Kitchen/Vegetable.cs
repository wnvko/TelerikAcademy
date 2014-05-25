namespace Kitchen
{
    public abstract class Vegetable
    {
        public bool HasBeenPeeled { get; set; }

        public bool IsGood { get; set; }

        public static Vegetable Peel(Vegetable vegetable)
        {
            Vegetable peeledVegetable = vegetable;
            peeledVegetable.HasBeenPeeled = true;
            return peeledVegetable;
        }
    }
}
