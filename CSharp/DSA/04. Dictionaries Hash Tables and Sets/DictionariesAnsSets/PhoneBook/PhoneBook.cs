using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// This sollution is totaly inspired by 'Look into PhoneBook' problem
/// you may find in 'Fundamentals of Computer Programming with C#' by Nakov, p.810
/// </summary>
public class PhoneBook
{
    private const string InputFile = @"..\..\input.txt";
    private const string SearchString = @"..\..\search.txt";
    private static Dictionary<string, List<string>> phoneBook = new Dictionary<string, List<string>>();

    public static void Main()
    {
        ReadPhoneBook();
        ProcessQuerries();

    }

    private static void ReadPhoneBook()
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

                string[] entry = line.Split(new char[] { '|' });
                string names = entry[0].Trim();

                string town = entry[1].Trim();
                string[] nameTokens = names.Split(new char[] { ' ', '\t' });

                foreach (string name in nameTokens)
                {
                    AddToPhoneBook(name, line);
                    string nameAndTown = CombineNameAndTown(town, name);
                    AddToPhoneBook(nameAndTown, line);
                }
            }
        }
    }

    private static string CombineNameAndTown(string town, string name)
    {
        return name + " from " + town;
    }

    private static void AddToPhoneBook(string name, string phone)
    {
        name = name.ToLower();
        List<string> phones;

        if (!phoneBook.TryGetValue(name, out phones))
        {
            phones = new List<string>();
            phoneBook.Add(name, phones);
        }

        phones.Add(phone);
    }

    private static void ProcessQuerries()
    {
        StreamReader reader = new StreamReader(SearchString);
        using (reader)
        {
            while (true)
            {
                string query = reader.ReadLine();
                if (query == null)
                {
                    break;
                }

                ProcessQuery(query);
            }
        }
    }

    private static void ProcessQuery(string query)
    {
        if (query.StartsWith("find("))
        {
            string[] queryParams = query.Split(new char[] { '(', ' ', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
            string name = queryParams[1];
            name = name.Trim().ToLower();

            if (queryParams.Length < 3)
            {
                PrintAllMatches(name);
                return;
            }

            string town = queryParams[2];
            town = town.Trim().ToLower();
            string nameAndTown = CombineNameAndTown(town, name);
            PrintAllMatches(nameAndTown);
        }
        else
        {
            Console.WriteLine(string.Format("{0} is invalid command!", query));
        }
    }

    private static void PrintAllMatches(string name)
    {
        List<string> allMatches;

        if (phoneBook.TryGetValue(name, out allMatches))
        {
            foreach (string entry in allMatches)
            {
                Console.WriteLine(entry);
            }
        }
        else
        {
            Console.WriteLine("Not found!");
        }

        Console.WriteLine();
    }
}
