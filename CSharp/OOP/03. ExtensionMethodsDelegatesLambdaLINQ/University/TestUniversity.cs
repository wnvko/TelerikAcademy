namespace University
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TestUniversity
    {
        public static void Main(string[] args)
        {
            Student[] courseOne = new Student[40];
            for (int i = 0; i < courseOne.Length; i++)
            {
                courseOne[i] = Student.RandomStudent();
            }

            // all students from group 2 with Linq
            var groupTwoLinq =
                from student in courseOne
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            Console.WriteLine("Group two with LINQ");
            foreach (var student in groupTwoLinq)
            {
                Console.WriteLine("{0,-10} {1,-10} {2}", student.FirstName, student.LastName, student.GroupNumber);
            }

            Console.WriteLine();

            // all students from group 2 with lambda
            var groupTwoLambda = courseOne.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName);

            Console.WriteLine("Group two with lambda");
            foreach (var student in groupTwoLambda)
            {
                Console.WriteLine("{0,-10} {1,-10} {2}", student.FirstName, student.LastName, student.GroupNumber);
            }

            Console.WriteLine();

            // all students with mail in abv
            Console.WriteLine("Students with email in abv.bg");
            var studentsInABV =
                from student in courseOne
                where student.Email.Contains("@abv.bg")
                select student;

            foreach (var student in studentsInABV)
            {
                Console.WriteLine("{0,-10} {1,-10} {2}", student.FirstName, student.LastName, student.Email);
            }

            Console.WriteLine();

            // all students with phones in Sofia
            Console.WriteLine("Students with phones in Sofia:");
            var sofiaGuys =
                from student in courseOne
                where student.Tel.StartsWith("02")
                select student;

            foreach (var student in sofiaGuys)
            {
                Console.WriteLine("{0,-10} {1,-10} {2}", student.FirstName, student.LastName, student.Tel);
            }

            Console.WriteLine();

            Console.WriteLine("Students with at least one mark Excellent (6)");
            var excelentGuys =
                from students in courseOne
                where students.Marks.Contains(6)
                select new { FullName = students.FirstName + " " + students.LastName, Marks = string.Join(" ", students.Marks.ToArray()) };

            foreach (var student in excelentGuys)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            Console.WriteLine("Students with exactly  two marks \"2\":");
            var poorGuys = courseOne.Where(x => x.Marks.Count(y => y == 2) >= 2);

            foreach (var student in poorGuys)
            {
                Console.WriteLine("{0,-10} {1,-10} {2}", student.FirstName, student.LastName, string.Join(" ", student.Marks.ToArray()));
            }

            Console.WriteLine();

            Console.WriteLine("2006 students marks");
            var students2006 = courseOne.Where(x => x.FN % 100 == 6);

            foreach (var student in students2006)
            {
                Console.WriteLine("FN: {3} {0,-10} {1,-10} {2}", student.FirstName, student.LastName, string.Join(" ", student.Marks.ToArray()), student.FN);
            }

            Console.WriteLine();

            List<Group> departments = new List<Group>()
                {
                    new Group(0),
                    new Group(1),
                    new Group(2),
                    new Group(3),
                    new Group(4),
                };

            // All students from "Mathematics" department with Join operator.
            Console.WriteLine("All mathematics are:");
            var mathematics =
                from student in courseOne
                join grpN in departments on student.GroupNumber equals grpN.GroupNumber
                where grpN.DepartmentName == "Mathematics"
                select student;

            foreach (var student in mathematics)
            {
                Console.WriteLine("{0,-10} {1,-10} {2}", student.FirstName, student.LastName, student.Group.DepartmentName);
            }

            Console.WriteLine();

            // All departments with Join operator.
            Console.WriteLine("All groups are (LINQ):");
            var groups =
                from student in courseOne
                join grpN in departments on student.GroupNumber equals grpN.GroupNumber
                orderby student.GroupNumber
                select student;

            foreach (var student in groups)
            {
                Console.WriteLine("Group: {2,-12} {0,-10} {1,-10}", student.FirstName, student.LastName, student.Group.DepartmentName);
            }

            Console.WriteLine();

            // All departments with extensions
            Console.WriteLine("All groups are (extensions):");
            var groupsExtensions = courseOne.OrderBy(x => x.GroupNumber);
            foreach (var student in groupsExtensions)
            {
                Console.WriteLine("Group: {2,-12} {0,-10} {1,-10}", student.FirstName, student.LastName, student.Group.DepartmentName);
            }
        }
    }
}
