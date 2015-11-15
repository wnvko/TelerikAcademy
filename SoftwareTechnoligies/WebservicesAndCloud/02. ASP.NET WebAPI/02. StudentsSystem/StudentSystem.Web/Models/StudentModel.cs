namespace StudentSystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using StudentSystem.Models;
    using System.ComponentModel.DataAnnotations;
    
    public class StudentModel
    {
        private StudentInfoModel additionalInformation;

        public StudentModel()
        {
            this.additionalInformation = new StudentInfoModel();
        }

        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return s => new StudentModel
                {
                    StudentIdentification = s.StudentIdentification,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Level = s.Level,
                    AdditionalInfo = new StudentInfoModel
                    {
                        Email = s.AdditionalInformation.Email,
                        Address = s.AdditionalInformation.Address
                    }
                };
            }
        }

        public int StudentIdentification { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int Level { get; set; }

        public virtual StudentModel Assistant { get; set; }

        public StudentInfoModel AdditionalInfo
        {
            get { return this.additionalInformation; }
            set { this.additionalInformation = value; }
        }
    }
}