using System;

public class Student
{
    private Name foolName;
    private int uniqueNumber;

    public Student(string firstName, string lastName)
    {
        this.FoolName = new Name(firstName, lastName);
    }

    public Name FoolName
    {
        get
        {
            return this.foolName;
        }

        private set
        {
            this.foolName = value;
        }
    }

    public int UniqueNumber
    {
        get
        {
            if (this.uniqueNumber < 10000)
            {
                throw new IndexOutOfRangeException(String.Format("{0} is not part of any course in any school yet and has no Unique Number", this.FoolName));
            }
            else
            {
                return this.uniqueNumber;
            }
        }

        private set
        {
            if (value >= 10000)
            {
                this.uniqueNumber = value;
            }
        }
    }

    public void AddUniqueNumber(int uniqueNumber)
    {
        this.UniqueNumber = uniqueNumber;
    }
}