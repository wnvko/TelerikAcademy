namespace TheSchool
{
    using System.Collections.Generic;

    public class Test
    {
        public static void Main(string[] args)
        {
            Student aniPetrova = new Student("Ani Petrova", "Class D");
            Student gerogiMalinov = new Student("Gerogi Malinov");
            Student hristoVasilev = new Student("Hristo Vasilev");

            List<Student> studentsInClassA = new List<Student>();
            studentsInClassA.Add(aniPetrova);
            studentsInClassA.Add(gerogiMalinov);
            studentsInClassA.Add(hristoVasilev);

            Discipline math = new Discipline("Math", 10, 10);
            Discipline language = new Discipline("Language", 20, 10);
            Discipline art = new Discipline("Art", 5, 10);

            Teacher petarPetrov = new Teacher("Petar Petrov");
            petarPetrov.Discipline.Add(math);
            petarPetrov.Discipline.Add(language);

            Teacher peshoPeshov = new Teacher("Pesho Peshov");
            peshoPeshov.Discipline.Add(art);

            List<Teacher> teachersForAClass = new List<Teacher>() { petarPetrov, peshoPeshov };

            Class classA = new Class("Class A", studentsInClassA);
            classA.Teachers = teachersForAClass;

            classA.AddComment("This is our first class.");
            classA.AddComment("This is our last class!");
        }
    }
}
