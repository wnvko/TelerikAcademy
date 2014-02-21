
namespace School
{
    using System;
    using System.Collections.Generic;

    public class Class : Comment
    {
        private string classID;
        private IList<Student> students;
        private IList<Teacher> teachers;

        public Class(string classID)
        {
            this.ClassID = classID;
            students = new List<Student>();
            teachers = new List<Teacher>();
        }

        public Class(string classID, IList<Student> students)
            : this(classID)
        {
            this.Students = students;
        }

        public Class(string classId, IList<Teacher> teachers)
            : this(classId)
        {
            this.Teachers = teachers;
        }

        public string ClassID
        {
            get
            {
                return this.classID;
            }

            set
            {
                if (String.IsNullOrEmpty(this.classID))
                {
                    if (String.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("Class ID must not be null or empty");
                    }

                    this.classID = value;
                }
                else
                {
                    throw new ArgumentException("The Class ID is already set and cannot be changed!");
                }
            }
        }

        public IList<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                if (value.Count < 2 || value.Count > 40)
                {
                    throw new ArgumentException("Class must be 2 - 40 students!");
                }

                this.students = value;
                foreach (var student in value)
                {
                    if (String.IsNullOrEmpty(student.ClassID))
                    {
                        student.ClassID = this.ClassID;
                    }
                }
            }
        }

        public IList<Teacher> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; }
        }


    }
}