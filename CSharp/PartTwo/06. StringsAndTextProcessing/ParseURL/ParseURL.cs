﻿/*
 * Write a program that parses an URL address given in the format: [protocol]://[server]/[resource]
 * and extracts from it the [protocol], [server] and [resource] elements.
 */

using System;
using System.Text.RegularExpressions;

public class ParseURL
{
    public static void Main()
    {
        string userURL = TakeUserInput("Enter an URL address: ");
        string protocol = string.Empty;
        string server = string.Empty;
        string resource = string.Empty;

        protocol = Regex.Match(userURL, @".+(?=:)").ToString();
        server = Regex.Match(userURL, @"(?<=(//)).+?(?=/)").ToString();
        resource = Regex.Match(userURL, @"(?<=(\.\w+)/).+").ToString();

        Console.WriteLine("[protocol] = {0}", protocol);
        Console.WriteLine("[server] = {0}", server);
        Console.WriteLine("[resource] = /{0}", resource);
    }

    private static string TakeUserInput(string adviseString)
    {
        Console.WriteLine(adviseString);
        string input = Console.ReadLine();
        return input;
    }
}
