using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        public const string teacherName = "Teacher: Name=";
        public const string coursesList = "; Courses=[";

        private List<ICourse> courses;
        private string name;

        public Teacher(string name)
        {
            this.Name = name;
            courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Teacher name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(teacherName);
            result.Append(this.Name);

            if (courses.Count > 0)
            {
                result.Append(coursesList);
                for (int i = 0; i < courses.Count; i++)
                {
                    result.Append(courses[i].Name);
                    if (i < courses.Count - 1)
                    {
                        result.Append(", ");
                    }
                }
                result.Append("]");
            }

            return result.ToString();
        }
    }
}