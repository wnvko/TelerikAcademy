namespace StudentsSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        private ICollection<Course> course;
        private ICollection<Homework> homework;

        public Student()
        {
            this.course = new HashSet<Course>();
            this.homework = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        public string Name { get; set; }

        public string FacultyNumber { get; set; }

        public virtual ICollection<Course> Course
        {
            get { return this.course; }
            set { this.course = value; }
        }

        public virtual ICollection<Homework> Homework
        {
            get { return this.homework; }
            set { this.homework = value; }
        }
    }
}