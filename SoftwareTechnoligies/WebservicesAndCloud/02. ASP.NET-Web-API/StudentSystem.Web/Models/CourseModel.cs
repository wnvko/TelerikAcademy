namespace StudentSystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using StudentSystem.Models;
    using System.ComponentModel.DataAnnotations;

    public class CourseModel
    {
        public CourseModel()
        {
            this.Id = Guid.NewGuid();
            //this.students = new HashSet<StudentModel>();
            //this.homeworks = new HashSet<HomeworkModel>();
        }

        public static Expression<Func<Course, CourseModel>> FromCourse
        {
            get
            {
                return c => new CourseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                };
            }
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
