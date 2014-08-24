namespace StudentsSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        private ICollection<Student> student;
        private ICollection<Homework> homework;

        public Course()
        {
            this.student = new HashSet<Student>();
            this.homework = new HashSet<Homework>();
        }

        [Key]
        public int CourseId { get; set; }

        public string Description { get; set; }

        public string Materials { get; set; }

        public virtual ICollection<Student> Student
        {
            get { return this.student; }
            set { this.student = value; }
        }

        public virtual ICollection<Homework> Homework
        {
            get { return this.homework; }
            set { this.homework = value; }
        }
    }
}