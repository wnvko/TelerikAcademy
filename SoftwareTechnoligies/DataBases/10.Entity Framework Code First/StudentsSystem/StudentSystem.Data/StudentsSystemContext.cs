namespace StudentsSystem.Data
{
    using System.Data.Entity;
    using StudentsSystem.Models;

    public class StudentsSystemContext : DbContext
    {
        public StudentsSystemContext()
            : base("name=StudentsSystemDb")
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Homework> Homeworks { get; set; }
    }
}