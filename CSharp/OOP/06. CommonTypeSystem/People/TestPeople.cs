namespace People
{
    using System;

    public class TestPeople
    {
        public static void Main(string[] args)
        {
            Person gosho = new Person("Gosho", 25);
            Person joro = new Person("Joro");

            Console.WriteLine(gosho);
            Console.WriteLine(joro);

            Person pesho = new Person(string.Empty); // throw a ArgumentException
            Console.WriteLine(pesho);
        }
    }
}
