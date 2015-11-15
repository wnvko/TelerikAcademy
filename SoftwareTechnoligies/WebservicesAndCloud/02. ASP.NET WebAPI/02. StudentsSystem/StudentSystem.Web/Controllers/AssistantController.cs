namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Web.Models;

    public class AssistantController : ApiController
    {
        private IStudentSystemData data;

        public AssistantController() :this(new StudentsSystemData())
        {
        }

        public AssistantController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable<StudentModel> Trainees(int id)
        {
            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                throw new HttpResponseException(new HttpResponseMessage());
            }

            var trainees = existingStudent.Trainees
                .AsQueryable()
                .Select(StudentModel.FromStudent);

            return trainees;
        }

        [HttpPut]
        public IHttpActionResult AddTrainee(int id, int traineeId)
        {
            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, id));
            }

            var trainee = this.GetStudentById(traineeId);

            if (trainee == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, traineeId));
            }

            existingStudent.Trainees.Add(trainee);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult RemoveTrainee(int id, int traineeId)
        {
            var existingStudent = this.GetStudentById(id);

            if (existingStudent == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, id));
            }

            var trainee = existingStudent.Trainees
                .Where(s => s.StudentIdentification == traineeId)
                .FirstOrDefault();

            if (trainee == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoStudentWithSuchId, traineeId));
            }

            existingStudent.Trainees.Remove(trainee);
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
