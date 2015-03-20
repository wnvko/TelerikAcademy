namespace Zoo
{
    using System;

    public class Cat : Animal
    {
        public Cat(int age, string name, Sex sex)
            : base(age, name, sex)
        { 
        }

        public override void SayWahtYouCan()
        {
            base.SayWahtYouCan();
            Console.WriteLine(" Cat: mew mew");
        }
    }
}
