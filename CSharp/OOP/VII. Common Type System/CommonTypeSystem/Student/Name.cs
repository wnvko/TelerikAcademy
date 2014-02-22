namespace Students
{
    using System;

    public struct Name : ICloneable, IComparable<Name>
    {
        private string firstName;
        private string middleName;
        private string lastName;

        public Name(string firstName, string middleName, string lastName)
            : this()
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                this.lastName = value;
            }
        }

        public object Clone()
        {
            Name clonedName = new Name();
            clonedName.FirstName = String.Copy(this.firstName);
            clonedName.MiddleName = String.Copy(this.MiddleName);
            clonedName.LastName = String.Copy(this.LastName);

            return clonedName;
        }

        public int CompareTo(Name other)
        {
            int compareValue = 0;
            compareValue = this.FirstName.CompareTo(other.FirstName);
            if (compareValue == 0)
            {
                compareValue = this.MiddleName.CompareTo(other.MiddleName);
                if (compareValue == 0)
                {
                    compareValue = this.LastName.CompareTo(other.LastName);
                }
            }

            return compareValue;
        }
    }
}
