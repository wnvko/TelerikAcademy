namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = GetDateFromOtherInfo(this.OtherInfo);
            DateTime secondDate = GetDateFromOtherInfo(other.OtherInfo);
            return firstDate > secondDate;
        }

        private static DateTime GetDateFromOtherInfo(string otherInfo)
        {
            string birthDateAsString = otherInfo.Substring(otherInfo.Length - 10);
            DateTime birthDate = DateTime.Parse(birthDateAsString);
            return birthDate;
        }
    }
}
