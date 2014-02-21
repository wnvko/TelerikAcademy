namespace Zoo
{
    using System;

    class Cat : Animal
    {
        public Cat(int age, string name, char sex)
            : base(age, name, sex)
        { }
        public override void SayWahtYouCan()
        {
            base.SayWahtYouCan();
            Console.WriteLine("mew mew");
        }
    }
}
