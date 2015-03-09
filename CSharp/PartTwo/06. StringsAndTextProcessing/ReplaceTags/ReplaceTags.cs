/*
 * Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a>
 * with corresponding tags [URL=…]…/URL].
 */

using System;
using System.Text.RegularExpressions;

public class ReplaceTags
{
    public static void Main()
    {
        string htmlWithTags = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose" +
                              @"a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss" +
                              @"the courses.</p>";

        string fixedText = Regex.Replace(htmlWithTags, @"(?<=(<a\shref=.+?))\W>", "]");
        fixedText = fixedText.Replace(@"<a href=""", "[URL=");
        fixedText = fixedText.Replace(@"</a>", "[/URL]");

        Console.WriteLine("Input text:");
        Console.WriteLine(htmlWithTags);
        Console.WriteLine("\nOutput text:");
        Console.WriteLine(fixedText);
    }
}
