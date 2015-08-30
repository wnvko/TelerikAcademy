using System;
using System.IO;
using System.Xml.Linq;

public class XMLCreator
{
    private static string[] names = { "My Everything", "Are You Experienced", "Abbey Road", "The Dark Side of the Moon", "London Calling", "OK Computer", "Thriller", "The Wall", "Back in Black", "Wish You Were Here", "Quadrophenia " };
    private static string[] artists = { "Ariana", "Sam", "Katty", "James", "Bono", "Ringo", "Colins", "Axel", "Iggy", "Madonna", "Michael" };
    private static string[] producers = { "DJ Shadow", "Paul Epworth", "George Clinton", "PeteRock", "RZA", "Roy Thomas Baker", "Jerry Wexler", "Jimmy Miller", "Steve Albini", "Trevor Horn" };
    private static string[] titles = { "Like a Rolling Stone", "(I Can't Get No) Satisfaction", "Imagine", "What's Going On", "Respect", "Good Vibrations", "Johnny B. Goode", "Hey Jude", "Smells Like Teen Spirit", "What'd I Say" };
    private static Random rnd = new Random();
    private static int catalogueEntities = 200;
    private static string xmlFilePath = @"../../../temp";
    private static string xmlFileName = @"/01.collection.xml";

    public static void Main()
    {
        XElement catalogue = new XElement("catalogue");

        for (int album = 0; album < catalogueEntities; album++)
        {
            XElement currentSong = new XElement("songs");
            int songs = rnd.Next(2, 7);
            for (int song = 0; song < songs; song++)
            {
                int minutes = rnd.Next(60);
                int seconds = rnd.Next(60);
                string duration = string.Format("{0:D2}:{1:D2}", minutes, seconds);
                currentSong.Add(
                        new XElement("title", titles[rnd.Next(titles.Length)]),
                        new XElement("duration", duration));
            }

            catalogue.Add(
                new XElement(
                    "album",
                    new XElement("name", names[rnd.Next(names.Length - 1)]),
                    new XElement("artist", artists[rnd.Next(artists.Length - 1)]),
                    new XElement("year", rnd.Next(1940, 2013)),
                    new XElement("producer", producers[rnd.Next(producers.Length - 1)]),
                    new XElement("price", rnd.Next(10000) / 100.0f),
                    currentSong));
        }

        Directory.CreateDirectory(xmlFilePath);
        catalogue.Save(xmlFilePath + xmlFileName);
    }
}
