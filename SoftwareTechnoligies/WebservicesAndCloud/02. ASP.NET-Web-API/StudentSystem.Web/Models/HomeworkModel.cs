namespace StudentSystem.Web.Models
{
    using System;
    using System.Linq.Expressions;

    using StudentSystem.Models;

    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return hw => new HomeworkModel
                {
                    Id = hw.Id,
                    FileUrl = hw.FileUrl,
                    TimeSent = hw.TimeSent,
                    StudentIdentification = hw.StudentIdentification,
                    CourseId = hw.CourseId
                };
            }
        }

        public int Id { get; set; }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        public int StudentIdentification { get; set; }

        public Guid CourseId { get; set; }
    }
}
