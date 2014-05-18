namespace ProblemTwo
{
    public enum Sex
    {
        Man,
        Woman
    }

    public class Person
    {
        public Sex Sex { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public void CreatePerson(int age)
        {
            Person person = new Person();
            person.Age = age;

            if (age % 2 == 0)
            {
                person.Name = "Батката";
                person.Sex = Sex.Man;
            }
            else
            {
                person.Name = "Мацето";
                person.Sex = Sex.Woman;
            }
        }
    }
}
