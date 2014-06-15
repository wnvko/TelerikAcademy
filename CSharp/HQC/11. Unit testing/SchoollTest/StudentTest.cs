using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoollTest
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatStudentWithNullName()
        {
            Student testStudent = new Student(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatStudentWithEmptyStringName()
        {
            Student testStudent = new Student(string.Empty, string.Empty);
        }

        [TestMethod]
        public void CreatOrdinaryStudent()
        {
            string firstName = "Pesho";
            string lastName = "Petrov";
            Name foolName = new Name(firstName, lastName);
            Student student = new Student(firstName, lastName);
            Assert.AreEqual(student.FoolName, foolName);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetUninitializedUniqueNumber()
        {
            string firstName = "Pesho";
            string lastName = "Petrov";
            Student student = new Student(firstName, lastName);
            int number = student.UniqueNumber;
        }
    }
}
