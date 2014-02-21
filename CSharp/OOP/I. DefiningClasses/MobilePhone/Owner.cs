namespace MobilePhone
{
    using System;

    internal struct Owner
    {
        private string firstName;
        private string secondName;

        // Constructors
        internal Owner(string firstName, string secondName)
            : this()
        {
            if (firstName.Length < 2 || !char.IsLetter(firstName[0]))
            {
                throw new ArgumentException("Unacceptable owner first name (less than two chars or do not start with letter).");
            }

            if (secondName.Length < 2 || !char.IsLetter(secondName[0]))
            {
                throw new ArgumentException("Unacceptable owner second name (less than two chars or do not start with letter).");
            }

            this.FirstName = firstName;
            this.SecondName = secondName;
        }

        // Properties
        internal string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        internal string SecondName
        {
            get { return this.secondName; }
            set { this.secondName = value; }
        }
    }
}