namespace Zoo
{
    using System;

    public class Frog : Animal
    {
        public Frog(int age, string name, Sex sex)
            : base(age, name, sex)
        {
        }

        public override void SayWahtYouCan()
        {
            base.SayWahtYouCan();
            Console.WriteLine(" Frog: qua qua");
        }
    }
}
