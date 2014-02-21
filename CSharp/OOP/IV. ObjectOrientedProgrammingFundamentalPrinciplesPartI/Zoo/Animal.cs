namespace Zoo
{
    using System;
    using System.Linq;

    public abstract class Animal : ISound
    {
        private int age;
        private string name;
        private char sex;

        public Animal(int age, string name, char sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative!");
                }

                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Name lenght cannot be less than two letters!");
                }

                this.name = value;
            }
        }

        public char Sex
        {
            get
            {
                return this.sex;
            }

            set
            {
                if (value != 'F' && value != 'f' && value != 'M' && value !='m')
                {
                    throw new ArgumentException("Sex can be only F or M!");
                }

                this.sex = value;
            }
        }

        public virtual void SayWahtYouCan()
        {
            string sexType = string.Empty;
            if (this.sex == 'f' || this.sex == 'F')
            {
                sexType = "female";
            }

            if (this.sex == 'm' || this.sex == 'M')
            {
                sexType = "male";
            }
            Console.Write("I am {0} {1} years old {2} {3}: ",Name, Age, sexType, this.GetType().Name.ToLower());
        }

        public static double AverageAge(params Animal[] animals)
        {
            var averageAge =
               (from animal in animals
                select animal).Average(a => a.Age);

            return averageAge;
        }
    }
}
