namespace StudentSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Web.Models;

    public class TestsController : ApiController
    {
        private IStudentSystemData data;

        public TestsController()
            : this(new StudentsSystemData())
        {
        }

        public TestsController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable<TestModel> All()
        {
            var tests = this.data.Tests
                .All()
                .Select(TestModel.FromTest);

            return tests;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var test = this.data.Tests
                .SearchFor(t => t.Id == id)
                .Select(TestModel.FromTest);

            if (test.Any())
            {
                return this.Ok(test);
            }

            return this.BadRequest(string.Format(HelperClass.NoTestWithSuchId, id));
        }

        [HttpPost]
        public IHttpActionResult Create(TestModel test)
        {
            if (!this.ModelState.IsValid)
            {
                this.BadRequest(this.ModelState);
            }

            var newTest = new Test
                {
                    CourseId = test.CourseId,
                };

            this.data.Tests.Add(newTest);
            this.data.SaveChanges();

            test.Id = newTest.Id;
            return this.Ok(test);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, TestModel test)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingTest = this.GetTestById(id);

            if (existingTest == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoTestWithSuchId, id));
            }

            existingTest.CourseId = test.CourseId;

            this.data.SaveChanges();

            test.Id = existingTest.Id;
            return this.Ok(test);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingTest = this.GetTestById(id);

            if (existingTest == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoTestWithSuchId, id));
            }

            this.data.Tests.Delete(existingTest);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult Course(int id)
        {
            var existingTest = this.GetTestById(id);

            if (existingTest == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoTestWithSuchId, id));
            }

            var course = existingTest.Course;
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
            var existingTest = this.GetTestById(id);

            if (existingTest == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoTestWithSuchId, id));
            }

            var course = this.data.Courses
                .SearchFor(c => c.Id == courseId)
                .FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoCourseWithSuchId, courseId));
            }

            existingTest.Course = course;
            this.data.SaveChanges();

            var courseModel = HelperClass.CreateNewCourseModel(course);
            return this.Ok(courseModel);
        }

        [HttpPut]
        public IHttpActionResult RemoveCourse(int id)
        {
            var existingTest = this.GetTestById(id);

            if (existingTest == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoTestWithSuchId, id));
            }
            existingTest.Course = null;
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IQueryable<StudentModel> Students(int id)
        {
            var existingTest = this.GetTestById(id);

            if (existingTest == null)
            {
                throw new HttpResponseException(new System.Net.Http.HttpResponseMessage());
            }

            var students = existingTest.Students
                .AsQueryable()
                .Select(StudentModel.FromStudent);

            return students;
        }

        [HttpPut]
        public IHttpActionResult AddStudent(int id, int studentId)
        {
            var existingTest = this.GetTestById(id);

            if (existingTest == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoTestWithSuchId, id));
            }

            var student = this.data.Students
                .SearchFor(s => s.StudentIdentification == studentId)
                .FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, studentId));
            }

            existingTest.Students.Add(student);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult RemoveStudent(int id, int studentId)
        {
            var existingTest = this.GetTestById(id);

            if (existingTest == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoTestWithSuchId, id));
            }

            var student = existingTest.Students
                .AsQueryable()
                .Where(s => s.StudentIdentification == studentId)
                .FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, studentId));
            }

            existingTest.Students.Remove(student);
            this.data.SaveChanges();

            return this.Ok();
        }

        private Test GetTestById(int id)
        {
            var existingTest = this.data.Tests
                .SearchFor(t => t.Id == id)
                .FirstOrDefault();

            return existingTest;
        }
    }
}
