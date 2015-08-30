namespace StudentSystem.Web.Models
{
    using StudentSystem.Models;
    using System.Collections.Generic;

    public class AssistantModel : StudentModel
    {
        public AssistantModel(Student student)
        {
            this.StudentIdentification = student.StudentIdentification;
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.Level = student.Level;
            this.AdditionalInfo.Address = student.AdditionalInformation.Address;
            this.AdditionalInfo.Email = student.AdditionalInformation.Email;
        }

        private ICollection<StudentModel> trainees;

        public AssistantModel()
        {
            this.trainees = new HashSet<StudentModel>();
        }

        public ICollection<StudentModel> Trainees
        {
            get { return this.trainees; }
            set { this.trainees = value; }
        }
    }
}