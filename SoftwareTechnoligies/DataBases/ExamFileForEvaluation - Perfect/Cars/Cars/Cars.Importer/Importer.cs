namespace Cars.Importer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    using Cars.Data;
    using Cars.Models;

    internal class Importer
    {
        private string folderPath;

        internal Importer(string folderPath)
        {
            this.folderPath = folderPath;
        }

        internal void Import()
        {
            var files = Directory.GetFiles(this.folderPath);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                Console.WriteLine("Importing from {0}...", fileInfo.Name);
                Console.Write("0%");

                var db = new CarsDbContext();
                var jsonAsString = File.ReadAllText(file);
                var cars = JsonConvert.DeserializeObject<List<CarInfo>>(jsonAsString);
                var count = cars.Count();
                var index = 0;
                var manufacturers = db.Manufacturers.ToDictionary(m => m.Name);
                var cities = db.Cities.ToDictionary(c => c.Name);

                foreach (var car in cars)
                {
                    var newCar = new Car()
                    {
                        Model = car.Model,
                        Year = car.Year,
                        TransmissionType = car.TransmissionType == 0 ? TransmissionType.Manual : TransmissionType.Automatic,
                        Price = car.Price
                    };

                    if (!manufacturers.ContainsKey(car.ManufacturerName))
                    {
                        manufacturers[car.ManufacturerName] = new Manufacturer()
                        {
                            Name = car.ManufacturerName
                        };
                    }

                    newCar.Manufacturer = manufacturers[car.ManufacturerName];

                    var dealer = new Dealer()
                    {
                        Name = car.Dealer.Name
                    };

                    if (!cities.ContainsKey(car.Dealer.City))
                    {
                        cities[car.Dealer.City] = new City()
                        {
                            Name = car.Dealer.City
                        };
                    }

                    dealer.Cities.Add(cities[car.Dealer.City]);

                    newCar.Dealer = dealer;

                    db.Cars.Add(newCar);

                    if (index % 100 == 0)
                    {
                        db.SaveChanges();

                        Console.Write("\r{0}%", index * 100 / count);
                    }

                    index++;
                }

                db.SaveChanges();
                Console.WriteLine("\r100%");
                Console.WriteLine("Importing from {0} completed.", fileInfo.Name);
            }
        }
    }
}