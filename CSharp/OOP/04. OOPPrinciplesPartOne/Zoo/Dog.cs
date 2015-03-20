namespace Zoo
{
    using System;

    public class Dog : Animal
    {
        public Dog(int age, string name, Sex sex)
            : base(age, name, sex)
        { }
        public override void SayWahtYouCan()
        {
            base.SayWahtYouCan();
            Console.WriteLine(" Dog: bau bau");
        }
    }
}
