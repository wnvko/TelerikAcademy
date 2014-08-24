namespace StudentSystem.Client
{
    using System.Data.Entity;
    using StudentsSystem.Data;
    using StudentsSystem.Data.Migrations;
    using StudentsSystem.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer<StudentsSystemContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemContext, Configuration>());
            var db = new StudentsSystemContext();

            Student pesho = new Student();
            Course php = new Course();

            pesho.Course.Add(php);
            pesho.FacultyNumber = "FN0001";
            pesho.Name = "Pesho";
            db.Students.Add(pesho);

            php.Description = "PHP";
            php.Materials = "No materials";
            php.Student.Add(pesho);
            db.Courses.Add(php);

            db.SaveChanges();
        }
    }
}