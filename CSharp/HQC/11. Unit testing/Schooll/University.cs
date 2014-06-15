using System;
using System.Collections.Generic;

public class University
{
    private string name;
    private ICollection<Course> courses;
    private int uniqueStudentNumber;

    public University(string name)
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
                if (value != null && value != string.Empty)
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

    public int UniqueStudentNumber
    {
        get
        {
            return ++this.uniqueStudentNumber;
        }
    }

    public void AddCourse(Course course)
    {
        if (this.courses.Contains(course))
        {
            Console.WriteLine("The {0} course is already added to the school. {0} courde will not be added again.", course.Name);
        }
        else
        {
            this.courses.Add(course);
            course.AddUniversity(this);
        }
    }
}