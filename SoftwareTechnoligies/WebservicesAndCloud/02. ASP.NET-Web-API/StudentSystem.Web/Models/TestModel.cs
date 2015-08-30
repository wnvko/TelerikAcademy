namespace StudentSystem.Web.Models
{
    using System;
    using System.Linq.Expressions;

    using StudentSystem.Models;

    public class TestModel
    {
        public static Expression<Func<Test, TestModel>> FromTest
        {
            get
            {
                return t => new TestModel
                {
                    Id = t.Id,
                    CourseId = t.CourseId,
                };
            }
        }

        public int Id { get; set; }

        public virtual Guid CourseId { get; set; }
    }
}