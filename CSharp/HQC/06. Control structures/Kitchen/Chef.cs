namespace Kitchen
{
    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();

            Vegetable peeledPotato = Vegetable.Peel(potato);
            Vegetable peeledCarrot = Vegetable.Peel(carrot);

            Vegetable cutPotato = this.Cut(potato);
            Vegetable cutCarrot = this.Cut(carrot);

            Bowl bowl = this.GetBowl();
            bowl.Add(cutPotato);
            bowl.Add(cutCarrot);
        }

        public void Cook(Vegetable vegetable)
        {
            // do something with vegetable...
        }

        private Carrot GetCarrot()
        {
            Carrot carrot = new Carrot();
            return carrot;
        }

        private Potato GetPotato()
        {
            Potato potato = new Potato();
            return potato;
        }

        private Vegetable Cut(Vegetable vegetable)
        {
            // Do something with vegetble
            return vegetable;
        }

        private Bowl GetBowl()
        {
            Bowl bowl = new Bowl();
            return bowl;
        }
    }
}