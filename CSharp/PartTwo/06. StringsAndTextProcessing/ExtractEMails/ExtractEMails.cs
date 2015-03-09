/*
 * Write a program for extracting all email addresses from given text. All sub-strings that match
 * the format <identifier>@<host>…<domain> should be recognized as emails.
 */

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ExtractEMails
{
    public static void Main()
    {
        string textToCheck = "The official email of our office is <office_15>@<company.old12>...<com>, and the secret email of our " +
                             "boss is <big_boss_1>@<secrethost>...<opa>.";

        Regex identifier = new Regex(@"(?<=<)\w+?(?=(>@))");
        Regex host = new Regex(@"(?<=(@<)).+?(?=>\.\.\.)");
        Regex domain = new Regex(@"(?<=\.\.\.<).+?(?=>)");

        List<string> identifiers = new List<string>();
        List<string> hosts = new List<string>();
        List<string> domains = new List<string>();

        foreach (Match match in identifier.Matches(textToCheck))
        {
            identifiers.Add(match.ToString());
        }

        foreach (Match match in host.Matches(textToCheck))
        {
            hosts.Add(match.ToString());
        }

        foreach (Match match in domain.Matches(textToCheck))
        {
            domains.Add(match.ToString());
        }

        for (int counter = 0; counter < identifiers.Count; counter++)
        {
            Console.WriteLine("email No {0}: {1}@{2}.{3}", counter, identifiers[counter], hosts[counter], domains[counter]);
        }
    }
}