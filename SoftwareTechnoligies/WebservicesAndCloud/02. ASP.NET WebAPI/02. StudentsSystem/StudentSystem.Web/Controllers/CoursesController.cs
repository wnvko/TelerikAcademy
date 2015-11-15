namespace StudentSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Web.Models;

    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController()
            : this(new StudentsSystemData())
        {
        }

        public CoursesController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable<CourseModel> All()
        {
            var courses = this.data.Courses
                .All()
                .Select(CourseModel.FromCourse);

            return courses;
        }

        [HttpGet]
        public IHttpActionResult ById(Guid id)
        {
            var course = this.data.Courses
                .SearchFor(c => c.Id == id)
                .Select(CourseModel.FromCourse);

            if (course.Any())
            {
                return this.Ok(course);
            }

            return this.BadRequest(string.Format(HelperClass.NoCourseWithSuchId, id));
        }

        [HttpPost]
        public IHttpActionResult Create(CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                this.BadRequest(this.ModelState);
            }

            var newCourse = this.CreateNewCourse(course);

            this.data.Courses.Add(newCourse);
            this.data.SaveChanges();

            course.Id = newCourse.Id;
            return this.Ok(course);
        }

        [HttpPut]
        public IHttpActionResult Update(Guid id, CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingCourse = this.GetCourseByGuid(id);

            if (existingCourse == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoCourseWithSuchId, id));
            }

            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;

            this.data.SaveChanges();

            course.Id = existingCourse.Id;
            return this.Ok(course);
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            var existingCourse = this.GetCourseByGuid(id);

            if (existingCourse == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoCourseWithSuchId, id));
            }

            this.data.Courses.Delete(existingCourse);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IQueryable<StudentModel> Students(Guid id)
        {
            var existingCourse = this.GetCourseByGuid(id);

            if (existingCourse == null)
            {
                throw new HttpResponseException(new System.Net.Http.HttpResponseMessage());
            }

            var students = existingCourse.Students
                .AsQueryable()
                .Select(StudentModel.FromStudent);

            return students;
        }

        [HttpPut]
        public IHttpActionResult AddStudent(Guid id, int studentId)
        {
            var existingCourse = this.GetCourseByGuid(id);

            if (existingCourse == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoCourseWithSuchId, id));
            }

            var student = this.data.Students
                .SearchFor(s => s.StudentIdentification == studentId)
                .FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, studentId));
            }

            existingCourse.Students.Add(student);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult RemoveStudent(Guid id, int studentId)
        {
            var existingCourse = this.GetCourseByGuid(id);

            if (existingCourse == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoCourseWithSuchId, id));
            }

            var student = existingCourse.Students
                .AsQueryable()
                .Where(s => s.StudentIdentification == studentId)
                .FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, studentId));
            }

            existingCourse.Students.Remove(student);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IQueryable<HomeworkModel> Homeworks(Guid id)
        {
            var existingCourse = this.GetCourseByGuid(id);

            if (existingCourse == null)
            {
                throw new HttpResponseException(new System.Net.Http.HttpResponseMessage());
            }

            var homeworks = existingCourse.Homeworks
                .AsQueryable()
                .Select(HomeworkModel.FromHomework);

            return homeworks;
        }

        [HttpPut]
        public IHttpActionResult AddHomework(Guid id, int homeworkId)
        {
            var existingCourse = this.GetCourseByGuid(id);

            if (existingCourse == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoCourseWithSuchId, id));
            }

            var homework = this.data.Homeworks
                .SearchFor(hw => hw.Id == homeworkId)
                .FirstOrDefault();

            if (homework == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoHomeworkWithSuchId, homeworkId));
            }

            existingCourse.Homeworks.Add(homework);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult RemoveHomework(Guid id, int homeworkId)
        {
            var existingCourse = this.GetCourseByGuid(id);

            if (existingCourse == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoCourseWithSuchId, id));
            }

            var homework = existingCourse.Homeworks
                .AsQueryable()
                .Where(s => s.StudentIdentification == homeworkId)
                .FirstOrDefault();

            if (homework == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, homeworkId));
            }

            existingCourse.Homeworks.Remove(homework);
            this.data.SaveChanges();

            return this.Ok();
        }

        private Course GetCourseByGuid(Guid guid)
        {
            var existingCourse = this.data.Courses
                .SearchFor(c => c.Id == guid)
                .FirstOrDefault();

            return existingCourse;
        }

        private Course CreateNewCourse(CourseModel course)
        {
            var newCourse = new Course
            {
                Name = course.Name,
                Description = course.Description,
            };

            return newCourse;
        }
    }
}