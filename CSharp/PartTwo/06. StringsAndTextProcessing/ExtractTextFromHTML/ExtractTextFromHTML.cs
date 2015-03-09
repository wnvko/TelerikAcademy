/*
 * Write a program that extracts from given HTML file its title (if available), and its body text
 * without the HTML tags.
 */

using System;
using System.Text.RegularExpressions;

public class ExtractTextFromHTML
{
    public static void Main()
    {
        string textToCheck = @"<html><head><title>News</title></head>" +
                             @"<body><p><a href=""http://academy.telerik.com""" +
                             @">Telerik Academy</a>aims to provide free real-world" +
                             @"practical training for young people who want to turn" +
                             @"into skillful .NET software engineers.</p></body></html>";

        Console.WriteLine(textToCheck);

        Regex header = new Regex(@"(?<=title>).+(?=</title)");
        string headerContent = header.Match(textToCheck).ToString();
        Console.Write("\nHeader:{0,10}", headerContent);

        string bodyContent = textToCheck.Replace(headerContent, string.Empty);
        Regex body = new Regex(@"(?>)[\w\s\p{P}]+(?=</)");
        Console.Write("\nBody:        ");
        foreach (Match match in body.Matches(bodyContent))
        {
            Console.Write("{0} ", match.ToString());
        }

        Console.WriteLine();
    }
}
