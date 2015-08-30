namespace StudentSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Web.Models;

    public class HomeworksController : ApiController
    {
        private IStudentSystemData data;

        public HomeworksController()
            : this(new StudentsSystemData())
        {
        }

        public HomeworksController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable<HomeworkModel> All()
        {
            var homeworks = this.data.Homeworks
                .All()
                .Select(HomeworkModel.FromHomework);

            return homeworks;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var homework = this.data.Homeworks
                .SearchFor(hw => hw.Id == id)
                .Select(HomeworkModel.FromHomework);

            if (homework.Any())
            {
                return this.Ok(homework);
            }

            return this.BadRequest(string.Format(HelperClass.NoHomeworkWithSuchId, id));
        }

        [HttpPost]
        public IHttpActionResult Create(HomeworkModel homework)
        {
            if (!this.ModelState.IsValid)
            {
                this.BadRequest(this.ModelState);
            }

            var newHomework = new Homework
            {
                FileUrl = homework.FileUrl,
                TimeSent = homework.TimeSent,
                CourseId = homework.CourseId,
                StudentIdentification = homework.StudentIdentification,
            };

            this.data.Homeworks.Add(newHomework);
            this.data.SaveChanges();

            homework.Id = newHomework.Id;
            return this.Ok(homework);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, HomeworkModel homework)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingHomework = this.GetHomeworkById(id);

            if (existingHomework == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoHomeworkWithSuchId, id));
            }

            existingHomework.FileUrl = homework.FileUrl;
            existingHomework.TimeSent = homework.TimeSent;
            existingHomework.CourseId = homework.CourseId;
            existingHomework.StudentIdentification = homework.StudentIdentification;

            this.data.SaveChanges();

            homework.Id = existingHomework.Id;
            return this.Ok(homework);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingHomework = this.GetHomeworkById(id);

            if (existingHomework == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoHomeworkWithSuchId, id));
            }

            this.data.Homeworks.Delete(existingHomework);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult Course(int id)
        {
            var existingHomework = this.GetHomeworkById(id);

            if (existingHomework == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoHomeworkWithSuchId, id));
            }

            var course = existingHomework.Course;
            if (course == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoCourseWithSuchId, id));
            }

            var courseModel = HelperClass.CreateNewCourseModel(course);

            return Ok(courseModel);
        }

        [HttpPut]
        public IHttpActionResult AddCourse(int id, Guid courseId)
        {
            var existingHomework = this.GetHomeworkById(id);

            if (existingHomework == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoHomeworkWithSuchId, id));
            }

            var course = this.data.Courses
                .SearchFor(c => c.Id == courseId)
                .FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoCourseWithSuchId, courseId));
            }

            existingHomework.Course = course;
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult RemoveCourse(int id)
        {
            var existingHomework = this.GetHomeworkById(id);

            if (existingHomework == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoHomeworkWithSuchId, id));
            }

            existingHomework.Course = null;
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult Student(int id)
        {
            var existingHomework = this.GetHomeworkById(id);

            if (existingHomework == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoHomeworkWithSuchId, id));
            }

            var student = existingHomework.Student;
            if (student == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, id));
            }

            var studentModel = HelperClass.CreateNewStudentModel(student);

            return Ok(studentModel);
        }

        [HttpPut]
        public IHttpActionResult AddStudent(int id, int studentId)
        {
            var existingHomework = this.GetHomeworkById(id);

            if (existingHomework == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoHomeworkWithSuchId, id));
            }

            var student = this.data.Students
                .SearchFor(s => s.StudentIdentification == studentId)
                .FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, studentId));
            }

            existingHomework.Student = student;
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult RemoveStudent(int id)
        {
            var existingHomework = this.GetHomeworkById(id);

            if (existingHomework == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoHomeworkWithSuchId, id));
            }

            existingHomework.Student = null;
            this.data.SaveChanges();

            return this.Ok();
        }

        private Homework GetHomeworkById(int id)
        {
            var existingHomework = this.data.Homeworks
                .SearchFor(hw => hw.Id == id)
                .FirstOrDefault();

            return existingHomework;
        }

    }
}
