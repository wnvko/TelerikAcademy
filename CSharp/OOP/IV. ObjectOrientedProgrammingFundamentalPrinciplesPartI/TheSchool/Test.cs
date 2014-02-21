/*
 * We are given a school. In the school there are classes of students. Each class has a set of
 * teachers. Each teacher teaches a set of disciplines. Students have name and unique class
 * number. Classes have unique text identifier. Teachers have name. Disciplines have name,
 * number of lectures and number of exercises. Both teachers and students are people. Students,
 * classes, teachers and disciplines could have optional comments (free text block).
 * 
 * Your task is to identify the classes (in terms of  OOP) and their attributes and operations,
 * encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.
 */

namespace School
{
    using System;
    using System.Collections.Generic;

    class Test
    {
        public static void Main()
        {
            Student AniPetrova = new Student("Ani Petrova","Class D");
            Student GerogiMalinov = new Student("Gerogi Malinov");
            Student HristoVasilev = new Student("Hristo Vasilev");
            
            List<Student> studentsInClassA = new List<Student>();
            studentsInClassA.Add(AniPetrova);
            studentsInClassA.Add(GerogiMalinov);
            studentsInClassA.Add(HristoVasilev);

            Discipline math = new Discipline("Math", 10, 10);
            Discipline language = new Discipline("Language", 20, 10);
            Discipline art = new Discipline("Art", 5, 10);

            Teacher PetarPetrov = new Teacher("Petar Petrov");
            PetarPetrov.Discipline.Add(math);
            PetarPetrov.Discipline.Add(language);

            Teacher PeshoPeshov = new Teacher("Pesho Peshov");
            PeshoPeshov.Discipline.Add(art);
            
            List<Teacher> teachersForAClass = new List<Teacher>() { PetarPetrov, PeshoPeshov};

            Class classA = new Class("Class A", studentsInClassA);
            classA.Teachers = teachersForAClass;

            classA.AddComment("This is our first class.");
            classA.AddComment("This is our last class!");
        }
    }
}
