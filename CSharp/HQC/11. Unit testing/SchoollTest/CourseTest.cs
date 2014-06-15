using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoollTest
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateNullNameCourse()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateEmtyStringNameCourse()
        {
            Course course = new Course(string.Empty);
        }

        [TestMethod]
        public void TryAddMoreThan30StudentsInCourse()
        {
            Course course = new Course("the course");
            University university = new University("the university");
            university.AddCourse(course);

            for (int i = 0; i < 50; i++)
            {
                Student student = new Student("a", "b");
                course.AddStudent(student);
            }

            Assert.AreEqual(course.StudentsList.Count, 30, "Students in course cannot be more than 30");
        }

        [TestMethod]
        public void TryAddTwiceSameStudentInCourse()
        {
            Course course = new Course("the course");
            University university = new University("the university");
            university.AddCourse(course);

            Student student = new Student("a", "b");
            course.AddStudent(student);
            course.AddStudent(student);

            Assert.AreEqual(course.StudentsList.Count, 1, "Students in course is only one.");
        }

        [TestMethod]
        public void RemoveStudentFromEmptyCourse()
        {
            Course course = new Course("the course");
            University university = new University("the university");
            university.AddCourse(course);

            Student student = new Student("a", "b");
            course.RemoveStudent(student);

            Assert.AreEqual(course.StudentsList.Count, 0, "Thereare no students in the course.");
        }
    }
}
