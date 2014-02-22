namespace Persons
{
    using System;

    public class TestPerson
    {
        static void Main()
        {
            Person gosho = new Person("Gosho", 25);
            Person joro = new Person("Joro");

            Console.WriteLine(gosho);
            Console.WriteLine(joro);

            Person pesho = new Person(""); //throwa ArgumentException
            Console.WriteLine(pesho);
        }
    }
}
