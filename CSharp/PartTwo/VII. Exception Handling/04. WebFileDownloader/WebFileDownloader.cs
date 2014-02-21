/*
 * Write a program that downloads a file from Internet
 * (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores
 * it the current directory. Find in Google how to download
 * files in C#. Be sure to catch all exceptions and to free
 * any used resources in the finally block.
 */

namespace WebFileDownloader
{
    using System;
    using System.Net;

    public class WebFileDownloader
    {
        public static void Main()
        {
            WebClient googleLogo = new WebClient();
            using (googleLogo)
            {
                try
                {
                    googleLogo.DownloadFile(@"https://www.google.bg/images/srpr/logo11w.png", @"..\..\GoogleLogo.png");
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
            }
        }
    }
}