namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    class Student : ICloneable, IComparable<Student>
    {
        private string ssn;
        private string mobilePhone;
        private string email;

        public Student(Name name, string ssn, Address address,
                       string mobilePhone, string email, int course,
                       Specialties specialty, Universities university, Faculties faculty)
        {
            this.Name = name;
            this.SSN = ssn;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.EMail = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public Name Name { get; set; }

        public string SSN
        {
            get
            {
                return this.ssn;
            }
            private set
            {
                if (Regex.IsMatch(value, @"^\d{3}-\d{2}-\d{4}$"))
                {
                    this.ssn = value;
                }
                else
                {
                    throw new ArgumentException("SSN shuold be in format XXX-XX-XXXX");
                }
            }
        }

        public Address Address { get; set; }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            private set
            {
                if (Regex.IsMatch(value, @"^0\d{2}-\d{3}-\d{3}$"))
                {
                    this.mobilePhone = value;
                }
                else
                {
                    throw new ArgumentException("Phone number shuold be in format 0XX-XXX-XXX");
                }
            }
        }

        public string EMail
        {
            get
            {
                return this.email;
            }
            private set
            {
                if (Regex.IsMatch(value, @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", RegexOptions.IgnoreCase))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentException("Wrong email format");
                }
            }
        }

        public int Course { get; set; }

        public Specialties Specialty { get; set; }

        public Universities University { get; set; }

        public Faculties Faculty { get; set; }

        public override bool Equals(object obj)
        {
            Student other = obj as Student;

            if (other == null)
            {
                return false;
            }

            if (
                this.Name.Equals(other.Name) &&
                this.SSN.Equals(other.SSN) &&
                this.Address.Equals(other.Address) &&
                this.MobilePhone.Equals(other.MobilePhone) &&
                this.EMail.Equals(other.EMail) &&
                this.Course.Equals(other.Course) &&
                this.Specialty.Equals(other.Specialty) &&
                this.University.Equals(other.University) &&
                this.Faculty.Equals(other.Faculty)
                )
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder studebtInformation = new StringBuilder();
            studebtInformation.AppendLine(string.Format("{0} {1} {2}", this.Name.FirstName, this.Name.MiddleName, this.Name.LastName));
            studebtInformation.AppendLine(string.Format("SSN: {0}", this.SSN));
            studebtInformation.AppendLine(string.Format("phone: {0}", this.MobilePhone));
            studebtInformation.AppendLine(string.Format("email: {0}", this.EMail));
            studebtInformation.AppendLine(string.Format("{0}, {1}, {2} - course: {3}", this.University, this.Faculty, this.Specialty, this.Course));

            return studebtInformation.ToString();
        }

        public override int GetHashCode()
        {
            int hashCode = this.Name.GetHashCode() ^ this.SSN.GetHashCode() ^ this.EMail.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Student first, Student second)
        {
            if (first.Equals(second))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Student first, Student second)
        {
            if (!first.Equals(second))
            {
                return true;
            }
            return false;
        }

        public object Clone()
        {
            Student clonedStudent = new Student(
                (Name)this.Name.Clone(), string.Copy(this.SSN),(Address)this.Address.Clone(),
                String.Copy(this.MobilePhone),String.Copy(this.EMail), this.Course,
                this.Specialty, this.University, this.Faculty
                );

            return clonedStudent;
        }

        public int CompareTo(Student other)
        {
            int compareValue = 0;
            compareValue = this.Name.CompareTo(other.Name);
            if (compareValue == 0)
            {
                compareValue = this.SSN.CompareTo(other.SSN);
            }
            return compareValue;
        }
    }
}