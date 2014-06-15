using System;
using System.Collections.Generic;

public class Schooll
{
    private string name;
    private ICollection<Course> courses;
    private int uniqueStudentNumber;

    public Schooll(string name)
    {
        this.Name = name;
        this.uniqueStudentNumber = 10000;
        this.courses = new List<Course>();
    }

    public ICollection<Course> Courses
    {
        get
        {
            return this.courses;
        }
    }

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
                    throw new ArgumentNullException("The school name cannot be null or empty string.");
                }
            }
        }
    }

    public int UniqueStudentNuber
    {
        get
        {
            return this.uniqueStudentNumber++;
        }
    }

    public void AddCourse(Course course)
    {
        this.courses.Add(course);
    }
}