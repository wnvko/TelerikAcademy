namespace MusicLibrary.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using MusicLibrary.Models;

    public class Client
    {
        private static string uri = "http://localhost:21008";
        static void Main()
        {
            Console.WriteLine("Please check the port on your machine and set the correct value in uri local variable.");
            Console.WriteLine("You can start both ConsolClient and Web application following the instructions here http://stackoverflow.com/questions/3850019/running-two-projects-at-once-in-visual-studio.");
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();

            var jsonClient = new HttpClient { BaseAddress = new Uri(uri) };
            jsonClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage jsonResponse = jsonClient.GetAsync("api/Songs/All").Result;
            if (jsonResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("JSON:");
                var songs = jsonResponse.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                foreach (Song song in songs)
                {
                    Console.WriteLine("{0} was first heard in {1} year.",song.Title, song.Year);
                }
            }

            var xmlClient = new HttpClient { BaseAddress = new Uri(uri) };
            jsonClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            HttpResponseMessage xmlResponse = jsonClient.GetAsync("api/Songs/All").Result;
            if (xmlResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("XML:");
                var songs = xmlResponse.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                foreach (Song song in songs)
                {
                    Console.WriteLine("{0} was first heard in {1} year.", song.Title, song.Year);
                }
            }

            Console.WriteLine("Press enter to finish.");
            Console.ReadLine();
        }
    }
}