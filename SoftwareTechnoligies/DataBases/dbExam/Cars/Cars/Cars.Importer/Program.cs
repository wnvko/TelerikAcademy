namespace Cars.Importer
{
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using Cars.Data;
    using Cars.Models;
    using System;

    public class Program
    {
        private static CarsDbContext db;
        private static string FilesDirectory = @"../../../JSON/";
        private static string JSONInputFile = @"data.0.json";

        static void Main()
        {
            db = new CarsDbContext();

            Importer();
        }

        private static void Importer()
        {
            string jsonAsString = string.Empty;
            using (TextReader reader = File.OpenText(FilesDirectory + JSONInputFile))
            {
                jsonAsString = reader.ReadToEnd();
            }

            var template = new
            {
                Year = 0,
                TransmissionType = 0,
                ManufacturerName = "",
                Model = "",
                Price = 10.0m,
                Dealer = new
                {
                    Name = string.Empty,
                    City = string.Empty,
                },
            };

            var jsonObject = (JArray)JsonConvert.DeserializeObject(jsonAsString);

            foreach (var item in jsonObject)
            {
                var carAsTemplate = JsonConvert.DeserializeAnonymousType(item.ToString(), template);

                var yearasString = carAsTemplate.Year.ToString();
                DateTime year = DateTime.Parse(string.Format("{0}-01-01", yearasString));

                var currentManufacturer = db.Manufacturer.Where(m => m.Name == carAsTemplate.ManufacturerName).FirstOrDefault();

                if (currentManufacturer == null)
                {
                    currentManufacturer = new Manufacturer
                    {
                        Name = carAsTemplate.ManufacturerName,
                    };

                }

                var currentCity = db.City.Where(c => c.Name == carAsTemplate.Dealer.City).FirstOrDefault();

                if (currentCity == null)
                {
                    currentCity = new City
                    {
                        Name = carAsTemplate.Dealer.City,
                    };

                }

                Dealer currentDealer = new Dealer
                {
                    Name = carAsTemplate.Dealer.Name,
                };

                currentDealer.Cities.Add(currentCity);

                Car currentCar = new Car
                {
                    Model = carAsTemplate.Model,
                    TransmissionType = (Cars.Models.Car.Transmission)carAsTemplate.TransmissionType,
                    Year = year,
                    Price = carAsTemplate.Price,
                    Manufacturer = currentManufacturer,
                    Dealer = currentDealer,
                };

                db.Car.Add(currentCar);
                db.SaveChanges();
            }
        }
    }
}
