using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        public const string courseName = ": Name=";
        public const string teacherName = "; Teacher=";
        public const string topicNames = "; Topics=[";

        private string name;

        public Course(string name)
            : this(name, null)
        { }

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            Topic = new List<string>();
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
                    throw new ArgumentNullException("Course name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public ITeacher Teacher { get; set; }

        public List<string> Topic { get; set; }

        public void AddTopic(string topic)
        {
            this.Topic.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append(courseName);
            result.Append(this.Name);

            if (this.Teacher != null)
            {
                result.Append(teacherName);
                result.Append(this.Teacher.Name);
            }

            if (this.Topic.Count > 0)
            {
                result.Append(topicNames);
                for (int i = 0; i < this.Topic.Count; i++)
                {
                    result.Append(this.Topic[i]);
                    if (i < this.Topic.Count - 1)
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
