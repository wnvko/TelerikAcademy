namespace University
{
    using System;

    public class Group
    {
        private static string[] departments = new string[5] { "Biology", "Economics", "Mathematics", "History", "Geography" };

        private int groupNumber;
        private string departmentName;

        public Group(int groupNumber)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departments[groupNumber];
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set { this.groupNumber = value; }
        }

        public string DepartmentName
        {
            get { return this.departmentName; }
            private set { this.departmentName = value; }
        }
    }
}