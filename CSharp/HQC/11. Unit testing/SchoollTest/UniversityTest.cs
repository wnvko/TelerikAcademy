using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoollTest
{
    [TestClass]
    public class UniversityTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateNullNameUniversity()
        {
            University university = new University(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateEmtyStringNameUniversity()
        {
            University university = new University(string.Empty);
        }

        [TestMethod]
        public void AddExistingCourse()
        {
            University university = new University("first");
            Course course = new Course("second");

            university.AddCourse(course);
            university.AddCourse(course);

            Assert.AreEqual(university.Courses.Count, 1, "There have to be only one course.");
        }
    }
}
