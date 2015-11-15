namespace StudentSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Web.Models;

    public class StudentsController : ApiController
    {
        private IStudentSystemData data;

        public StudentsController()
            : this(new StudentsSystemData())
        {
        }

        public StudentsController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable<StudentModel> All()
        {
            var students = this.data.Students
                .All()
                .Select(StudentModel.FromStudent);

            return students;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var student = this.data.Students
                .SearchFor(s => s.StudentIdentification == id)
                .Select(StudentModel.FromStudent);

            if (student.Any())
            {
                return this.Ok(student);
            }

            return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, id));
        }

        [HttpPost]
        public IHttpActionResult Create(StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                this.BadRequest(this.ModelState);
            }

            var newStudent = this.CreateNewStudent(student);

            this.data.Students.Add(newStudent);
            this.data.SaveChanges();

            student.StudentIdentification = newStudent.StudentIdentification;
            return this.Ok(student);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, id));
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Level = student.Level;

            this.data.SaveChanges();

            student.StudentIdentification = existingStudent.StudentIdentification;
            return this.Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, id));
            }

            this.data.Students.Delete(existingStudent);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IQueryable<CourseModel> Courses(int id)
        {
            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                throw new HttpResponseException(new HttpResponseMessage());
            }

            var courses = existingStudent.Courses
                .AsQueryable()
                .Select(CourseModel.FromCourse);

            return courses;
        }

        [HttpPut]
        public IHttpActionResult AddCourse(int id, Guid courseId)
        {
            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, id));
            }

            var course = this.data.Courses
                .SearchFor(c => c.Id == courseId)
                .FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoCourseWithSuchId, courseId));
            }

            existingStudent.Courses.Add(course);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult RemoveCourse(int id, Guid courseId)
        {
            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, id));
            }

            var course = existingStudent.Courses
                .Where(c => c.Id == courseId)
                .FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoCourseWithSuchId, courseId));
            }

            existingStudent.Courses.Remove(course);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult Assistant(int id)
        {
            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, id));
            }

            var assistant = existingStudent.Assistant;
            if (assistant == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoAssistant, id));
            }

            return Ok(assistant.StudentIdentification);
        }

        [HttpPut]
        public IHttpActionResult AddAssistant(int id, int assistantId)
        {
            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, id));
            }

            var assistant = this.GetStudentById(assistantId);

            if (assistant == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, assistantId));
            }

            existingStudent.Assistant = assistant;
            this.data.SaveChanges();

            return this.Ok(new AssistantModel(assistant));
        }

        [HttpPut]
        public IHttpActionResult RemoveAssistant(int id)
        {
            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, id));
            }

            existingStudent.Assistant = null;
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IQueryable<HomeworkModel> Homeworks(int id)
        {
            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                throw new HttpResponseException(new HttpResponseMessage());
            }

            var homeworks = existingStudent.Homeworks
                .AsQueryable()
                .Select(HomeworkModel.FromHomework);

            return homeworks;
        }

        [HttpPut]
        public IHttpActionResult AddHomework(int id, int homeworkId)
        {
            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, id));
            }

            var homework = this.data.Homeworks
                .SearchFor(hw => hw.Id == homeworkId)
                .FirstOrDefault();

            if (homework == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoHomeworkWithSuchId, homeworkId));
            }

            existingStudent.Homeworks.Add(homework);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult RemoveHomework(int id, int homeworkId)
        {
            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, id));
            }

            var homework = existingStudent.Homeworks
                .Where(hw => hw.Id == homeworkId)
                .FirstOrDefault();

            if (homework == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, homeworkId));
            }

            existingStudent.Homeworks.Remove(homework);
            this.data.SaveChanges();

            return this.Ok();
        }

        private Student GetStudentById(int id)
        {
            var existingStudent = this.data.Students
                .SearchFor(s => s.StudentIdentification == id)
                .FirstOrDefault();

            return existingStudent;
        }

        private Student CreateNewStudent(StudentModel student)
        {
            var newStudent = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Level = student.Level,
            };

            return newStudent;
        }
    }
}
