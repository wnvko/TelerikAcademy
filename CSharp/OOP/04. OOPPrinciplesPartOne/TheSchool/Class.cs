namespace TheSchool
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Class : IComment
    {
        private string classID;
        private IList<Student> students;
        private IList<Teacher> teachers;
        private string listOfComments;

        public Class(string classID)
        {
            this.ClassID = classID;
            this.students = new List<Student>();
            this.teachers = new List<Teacher>();
            this.listOfComments = string.Empty;
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

            private set
            {
                if (this.classID != value)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("Class ID must not be null or empty");
                    }

                    this.classID = value;
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
                foreach (Student student in value)
                {
                    if (string.IsNullOrEmpty(student.ClassID))
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

        public string ListOfComments
        {
            get { return this.listOfComments; }
        }

        public void AddComment(string input)
        {
            StringBuilder currentList = new StringBuilder(this.listOfComments);
            currentList.AppendLine(input);
            this.listOfComments = currentList.ToString();
        }
    }
}