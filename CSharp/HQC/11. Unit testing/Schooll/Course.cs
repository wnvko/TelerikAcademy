using System;
using System.Collections.Generic;
public class Course
{
    public const int MaxStudentsCount = 30;
    private string name;
    private ICollection<Student> studentsList;
    private University unviverity;

    public Course(string name)
    {
        this.Name = name;
        this.studentsList = new List<Student>();
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
                    throw new ArgumentNullException("The course name cannot be null or empty string.");
                }
            }
        }
    }

    public ICollection<Student> StudentsList
    {
        get
        {
            return this.studentsList;
        }
    }

    public void AddStudent(Student student)
    {
        if (studentsList.Count >= 30)
        {
            Console.WriteLine("This course is full. No more students can be added. {0} is not added.", student.FoolName);
        }
        else if (this.studentsList.Contains(student))
        {
            Console.WriteLine("{0} is already in this course. {0} will not be added again.", student.FoolName);
        }
        else
        {
            this.studentsList.Add(student);
            student.AddUniqueNumber(this.unviverity.UniqueStudentNumber);
        }
    }

    public void RemoveStudent(Student student)
    {
        if (studentsList.Count < 0)
        {
            Console.WriteLine("This course is empty. No students removed.");
        }
        else if (!this.studentsList.Contains(student))
        {
            Console.WriteLine("{0} is not in this course. {0} can not be removed.", student.FoolName);
        }
        else
        {
            this.studentsList.Remove(student);
        }
    }

    public void AddUniversity(University university)
    {
        this.unviverity = university;
    }
}