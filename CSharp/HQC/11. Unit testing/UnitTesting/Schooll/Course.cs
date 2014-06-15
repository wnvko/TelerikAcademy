using System;
using System.Collections.Generic;
public class Course
{
    private string name;
    private ICollection<Student> studentsList;



    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            {
                if (value != null || value != string.Empty)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentNullException("The course name cannot be null or empty string.");
                }
            }
        }
    }

}
