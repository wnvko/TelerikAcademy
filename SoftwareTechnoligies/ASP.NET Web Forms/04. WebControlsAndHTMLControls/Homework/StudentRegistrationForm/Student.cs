namespace StudentRegistrationForm
{
    using System.Collections.Generic;

    public class Student
    {
        public Student()
        {
            this.Courses = new List<string>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FNumber { get; set; }

        public string University { get; set; }

        public string Specialty { get; set; }

        public List<string> Courses { get; set; }
    }
}