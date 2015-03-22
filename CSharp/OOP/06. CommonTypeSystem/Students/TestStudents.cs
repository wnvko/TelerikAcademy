namespace Students
{
    using System;

    public class TestStudents
    {
        public static void Main(string[] args)
        {
            Name petio = new Name("Peter", "Petrov", "Petranov");
            Address petioHome = new Address("Kaspichan", "Vasil Levski", 5);
            Student petioTheStudent = new Student(petio, "123-45-7890", petioHome, "088-777-666", "petio@nekav.net", 3, Specialties.CSharpProgrammer, Universities.TelerikAcademy, Faculties.Second);
            Console.WriteLine(petioTheStudent);
            Console.WriteLine(petioTheStudent.GetHashCode());

            Student copyOfPetio = (Student)petioTheStudent.Clone();
            Console.WriteLine(object.ReferenceEquals(petioTheStudent.Name.FirstName, copyOfPetio.Name.FirstName));
            Console.WriteLine(object.ReferenceEquals(petioTheStudent.SSN, copyOfPetio.SSN));

            Console.WriteLine(petioTheStudent.CompareTo(copyOfPetio));
        }
    }
}
