namespace TheSchool
{
    using System;
    using System.Text;

    public class Person : IComment
    {
        private string name;
        private string listOfComments;

        public Person(string name)
        {
            this.Name = name;
            this.listOfComments = string.Empty;
        }

        public Person(string name, string comment)
            : this(name)
        {
            this.listOfComments = comment;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Person name cannot be null or empty!");
                }

                this.name = value;
            }
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
