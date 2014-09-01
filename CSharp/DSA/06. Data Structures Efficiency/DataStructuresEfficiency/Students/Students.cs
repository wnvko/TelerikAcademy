using System;
using System.Collections.Generic;
using System.IO;

class Students
{
    private const string InputFile = @"..\..\students.txt";

    static void Main(string[] args)
    {
        SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> students = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();
        List<string[]> inputData = new List<string[]>();

        GetData(inputData);
        FillData(students, inputData);
        PrintData(students);
    }

    private static void GetData(List<string[]> inputData)
    {
        StreamReader reader = new StreamReader(InputFile);
        using (reader)
        {
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                inputData.Add(line.Split(new char[] { '|', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries));

            }
        }
    }

    private static void FillData(SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> students, List<string[]> inputData)
    {
        foreach (string[] student in inputData)
        {
            if (!students.ContainsKey(student[2]))
            {
                students[student[2]] = new SortedDictionary<string, SortedSet<string>>();
            }

            if (!students[student[2]].ContainsKey(student[1]))
            {
                students[student[2]][student[1]] = new SortedSet<string>();
            }

            students[student[2]][student[1]].Add(student[0]);
        }
    }

    private static void PrintData(SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> students)
    {
        foreach (var course in students)
        {
            Console.WriteLine(course.Key);

            foreach (var lastName in course.Value)
            {

                foreach (var firstName in lastName.Value)
                {
                    Console.WriteLine("\t{0}, {1}", lastName.Key, firstName);
                }
            }
        }
    }
}