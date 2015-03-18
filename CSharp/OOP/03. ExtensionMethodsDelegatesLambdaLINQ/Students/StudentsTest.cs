namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsTest
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Ivan", "Ivanov", 22));
            students.Add(new Student("Petar", "Marinov", 31));
            students.Add(new Student("Maria", "Ivanova", 19));
            students.Add(new Student("Lili", "Hristova", 16));
            students.Add(new Student("Ivan", "Antonov", 22));
            students.Add(new Student("Georgi", "Stoychev", 26));
            students.Add(new Student("Marian", "Zhelyazkov", 30));
            students.Add(new Student("Aneta", "Petrova", 29));
            students.Add(new Student("Zdravko", "Velichkov", 19));
            students.Add(new Student("Pesho", "Peshov", 56));
            students.Add(new Student("Stanimir", "Bogdanov", 12));

            Console.WriteLine("Initial list:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            // find all students with first name before its last name alphabetically
            var specialStudents =
                from student in students
                where (student.FirstName.CompareTo(student.SecondName) < 0)
                select student;

            Console.WriteLine("Special list:");
            foreach (var student in specialStudents)
            {
                Console.WriteLine(student);
            }
            
            Console.WriteLine();

            // first and second name of students with age 18 - 24
            var students18_24 =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select new { FirstName = student.FirstName, SecondName = student.SecondName };

            Console.WriteLine("Special list 18 to 24:");
            foreach (var student in students18_24)
            {
                Console.WriteLine("{0,-15}{1}", student.FirstName, student.SecondName);
            }

            Console.WriteLine();

            // sort students by first and second name
            var sortedStudents = students.OrderBy(student => student.FirstName).ThenBy(student => student.SecondName);

            Console.WriteLine("Sorted to first and second name with lambda:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
            
            Console.WriteLine();

            var sortedStudentsLINQ =
                from student in students
                orderby student.SecondName
                orderby student.FirstName
                select student;

            Console.WriteLine("Sorted to first and second name with LINQ:");
            foreach (var student in sortedStudentsLINQ)
            {
                Console.WriteLine(student);
            }
            
            Console.WriteLine();
        }
    }
}
