/*
 * Write a program that enters file name along with its full file path
 * (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the
 * console. Find in MSDN how to use System.IO.File.ReadAllText(…). Be
 * sure to catch all possible exceptions and print user-friendly error
 * messages.
 */

namespace FileReader
{
    using System;
    using System.IO;

    public class FileReader
    {
         public static void Main()
        {
             try
             {
                 string fileContent = File.ReadAllText(@"C:\Windows\system.ini");
                 Console.WriteLine(fileContent);
             }
             catch (ArgumentNullException)
             {
                 Console.Error.WriteLine("The file path is missing (null filepath).");
             }
             catch (ArgumentException)
             {
                 Console.Error.WriteLine("Wrong file path entered.");
             }
             catch (PathTooLongException)
             {
                 Console.Error.WriteLine("File path has too long name.");
             }
             catch (DirectoryNotFoundException)
             {
                 Console.Error.WriteLine("Wrong directory.");
             }
             catch (FileNotFoundException ex)
             {
                 Console.Error.WriteLine("File, {0}, is not found.", ex.FileName);
             }
             catch (IOException)
             {
                 Console.Error.WriteLine("Unknown I/O exception occured.");
             }
             catch (UnauthorizedAccessException)
             {
                 Console.Error.WriteLine("You do not have permissions to reach/open the file.");
             }
             catch (NotSupportedException)
             {
                 Console.Error.WriteLine("Invalid path format.");
             }
             catch (System.Security.SecurityException)
             {
                 Console.Error.WriteLine("You do not have the necessary permissions.");
             }
        }
    }
}