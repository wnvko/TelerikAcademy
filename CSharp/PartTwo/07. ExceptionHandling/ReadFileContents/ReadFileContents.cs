/*
 * Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
 * reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…).
 * Be sure to catch all possible exceptions and print user-friendly error messages.
 */

using System;
using System.IO;

public class ReadFileContents
{
    public static void Main()
    {
        try
        {
            string fileName = @"C:\Windows\system.ini";
            string fileContent = File.ReadAllText(fileName);
            Console.WriteLine(fileContent);

            // Some wrong input. Please uncomment code bellow to test it

            //string wrongFileName = @"C:\Windows\system.in";
            //fileContent = File.ReadAllText(wrongFileName);

            //string nullFileName = null;
            //fileContent = File.ReadAllText(nullFileName);

            //string tooLongFileName = new string('a', 500);
            //fileContent = File.ReadAllText(tooLongFileName);

            //string wrongDirectoryFileName = @"C:\Vindows\system.ini";
            //fileContent = File.ReadAllText(wrongDirectoryFileName);
        }
        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("The file path is missing (null file path).");
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
            Console.Error.WriteLine("Unknown I/O exception occurred.");
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