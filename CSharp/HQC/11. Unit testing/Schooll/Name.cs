using System;

public struct Name
{
    private string firstName;
    private string lastName;

    public Name(string firstName, string lastName)
        : this()
    {
        this.FirstName = firstName;
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
            if (value != null && value != string.Empty)
            {
                this.firstName = value;
            }
            else
            {
                throw new ArgumentNullException("First name cannot be null or empty string.");
            }
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (value != null && value != string.Empty)
            {
                this.lastName = value;
            }
            else
            {
                throw new ArgumentNullException("First name cannot be null or empty string.");
            }
        }
    }
}