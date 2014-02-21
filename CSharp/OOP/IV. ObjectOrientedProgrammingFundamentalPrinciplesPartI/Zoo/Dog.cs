namespace Zoo
{
    using System;

    class Dog : Animal
    {
        public Dog(int age, string name, char sex)
            : base(age, name, sex)
        { }
        public override void SayWahtYouCan()
        {
            base.SayWahtYouCan();
            Console.WriteLine("bau bau");
        }
    }
}
