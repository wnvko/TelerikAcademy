namespace StudentsSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    using StudentsSystem.Models;
    
    public sealed class Configuration : DbMigrationsConfiguration<StudentsSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentsSystem.Data.StudentsSystemContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            string[] studentNames = { "Gosho", "Tosho", "Mimi", "Ivan", "Petrana" };

            string[] studentFacultyNumbers = new string[10];
            for (int facultyNumber = 0; facultyNumber < studentFacultyNumbers.Length; facultyNumber++)
            {
                studentFacultyNumbers[facultyNumber] = string.Format("FN{0}", facultyNumber + 2);
            }

            string[] courseDescriptions = { "Databases", "High Quality Code", "C# 1", "OOP", "JavaScript", "HTML Basics", "Java" };

            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            HashSet<Student> students = new HashSet<Student>();
            HashSet<Course> courses = new HashSet<Course>();

            sw.Start();
            for (int i = 0; i < 100; i++)
            {
                string studentName = studentNames[rnd.Next(studentNames.Length)];
                string studentFacultyNumber = studentFacultyNumbers[rnd.Next(studentFacultyNumbers.Length)];

                string courseDescription = courseDescriptions[rnd.Next(courseDescriptions.Length)];

                Student currentStudent = new Student();
                currentStudent.Name = studentName;
                currentStudent.FacultyNumber = studentFacultyNumber;
                students.Add(currentStudent);

                Course course = new Course();
                course.Description = courseDescription;
                courses.Add(course);

                Console.WriteLine("N = {0} + {1}", i, sw.Elapsed);
            }

            context.Students.AddRange(students);
            context.Courses.AddRange(courses);
        }
    }
}
