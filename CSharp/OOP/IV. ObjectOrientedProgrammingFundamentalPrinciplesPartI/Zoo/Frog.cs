namespace Zoo
{
    using System;

    class Frog : Animal
    {
        public Frog(int age, string name, char sex)
            : base(age, name, sex)
        { }
        public override void SayWahtYouCan()
        {
            base.SayWahtYouCan();
            Console.WriteLine("qua qua");
        }
    }
}
