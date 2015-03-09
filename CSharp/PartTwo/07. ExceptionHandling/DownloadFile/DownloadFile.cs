/*
 * Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current
 * directory. Find in Google how to download files in C#. Be sure to catch all exceptions and to
 * free any used resources in the finally block.
 */

using System;
using System.Diagnostics;
using System.Net;

public class DownloadFile
{

    public static void Main()
    {
        WebClient ninjaLogo = new WebClient();
        using (ninjaLogo)
        {
            try
            {
                ninjaLogo.DownloadFile(@"http://telerikacademy.com/Content/Images/news-img01.png", @"..\..\NinjaLogo.png");
                Process.Start(@"..\..\NinjaLogo.png");

                // Wrong URL
                ninjaLogo.DownloadFile(@"htttttttp://telerikacademy.com/Content/Images/news-img01.png", @"..\..\NinjaLogo.png");
            }
            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("The url or destination file is null.");
            }
            catch (WebException)
            {
                Console.Error.WriteLine("Web problem occured.File is not saved.");
            }
            catch (NotSupportedException)
            {
                Console.Error.WriteLine("Not supported exception occured.File is not saved.");
            }
            finally
            {
                ninjaLogo.Dispose();
            }
        }
    }
}
