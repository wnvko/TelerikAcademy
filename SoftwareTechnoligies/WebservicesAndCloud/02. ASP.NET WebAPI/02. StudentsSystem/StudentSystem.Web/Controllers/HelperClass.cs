namespace StudentSystem.Web.Controllers
{
    using StudentSystem.Models;
    using StudentSystem.Web.Models;

    public class HelperClass
    {
        public const string NoCourseWithSuchId = "There is no course with Id:{0} in the system";
        public const string NoStudentWithSuchId = "There is no student with Id:{0} in the system";
        public const string NoAssistant = "Student with Id:{0} has no assistant";
        public const string NoHomeworkWithSuchId = "There is no homework with Id:{0} in the system";
        public const string NoTestWithSuchId = "There is no test with Id:{0} in the system";

        public static CourseModel CreateNewCourseModel(Course course)
        {
            var courseModel = new CourseModel();
            courseModel.Id = course.Id;
            courseModel.Description = course.Description;
            courseModel.Name = course.Name;
            
            return courseModel;
        }

        public static StudentModel CreateNewStudentModel(Student student)
        {
            var studentModel = new StudentModel();
            studentModel.FirstName = student.FirstName;
            studentModel.LastName = student.LastName;
            studentModel.Level = student.Level;
            studentModel.AdditionalInfo.Address = student.AdditionalInformation.Address;
            studentModel.AdditionalInfo.Email = student.AdditionalInformation.Email;

            return studentModel;
        }
    }
}