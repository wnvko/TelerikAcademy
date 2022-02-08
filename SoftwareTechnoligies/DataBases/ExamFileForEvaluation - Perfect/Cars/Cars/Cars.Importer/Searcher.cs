namespace Cars.Importer
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using Cars.Data;
    using Cars.Models;

    internal class Searcher
    {
        private readonly string filePath;

        internal Searcher(string filePath)
        {
            this.filePath = filePath;
        }

        internal void Search()
        {
            Console.WriteLine("Searching by queries in {0}", this.filePath);

            var db = new CarsDbContext();
            var xml = XElement.Load(this.filePath);
            var queries = xml.Descendants("Query");

            foreach (var xmlQuery in queries)
            {
                var query = db.Cars.AsQueryable();
                var outputFile = xmlQuery.Attribute("OutputFileName").Value;
                outputFile = "..\\..\\..\\..\\" + outputFile;

                var orderBy = xmlQuery.Element("OrderBy").Value;
                query = this.OrderBy(query, orderBy);

                var whereClauses = xmlQuery.Descendants("WhereClause");

                foreach (var whereClause in whereClauses)
                {
                    var propertyName = whereClause.Attribute("PropertyName").Value;
                    var type = whereClause.Attribute("Type").Value;
                    var value = whereClause.Value;
                    query = this.WhereClauses(query, propertyName, type, value);
                }

                var results = query.Select(c => new
                {
                    Model = c.Model,
                    Year = c.Year,
                    Price = c.Price,
                    Manufacturer = c.Manufacturer.Name,
                    TransmissionType = c.TransmissionType,
                    Dealer = new
                    {
                        Name = c.Dealer.Name,
                        Cities = c.Dealer.Cities.Select(city => city.Name)
                    }
                });

                var cars = new XElement("Cars");

                foreach (var result in results)
                {
                    var car = new XElement("Car");
                    car.Add(
                        new XAttribute("Manufacturer", result.Manufacturer),
                        new XAttribute("Model", result.Model),
                        new XAttribute("Year", result.Year),
                        new XAttribute("Price", result.Price),
                        new XElement("TransmissionType", result.TransmissionType.ToString().ToLower()));

                    var dealer = new XElement(
                        "Dealer", new XAttribute("Name", result.Dealer.Name));
                    var cities = new XElement("Cities");

                    foreach (var city in result.Dealer.Cities)
                    {
                        cities.Add(new XElement("City", city));
                    }

                    dealer.Add(cities);
                    car.Add(dealer);
                    cars.Add(car);
                }

                cars.Save(outputFile);
                Console.WriteLine("Generated file in: {0}", outputFile);
            }

            Console.WriteLine("Search finished.");
        }

        private IQueryable<Car> WhereClauses(IQueryable<Car> query, string propertyName, string type, string valueAsString)
        {
            if (propertyName == "Id")
            {
                var value = int.Parse(valueAsString);
                if (type == "Equals")
                {
                    query = query.Where(c => c.Id == value);
                }
                else if (type == "GreaterThan")
                {
                    query = query.Where(c => c.Id > value);
                }
                else if (type == "LessThan")
                {
                    query = query.Where(c => c.Id < value);
                }
            }
            else if (propertyName == "Year")
            {
                var value = int.Parse(valueAsString);
                if (type == "Equals")
                {
                    query = query.Where(c => c.Year == value);
                }
                else if (type == "GreaterThan")
                {
                    query = query.Where(c => c.Year > value);
                }
                else if (type == "LessThan")
                {
                    query = query.Where(c => c.Year < value);
                }
            }
            else if (propertyName == "Model")
            {
                if (type == "Equals")
                {
                    query = query.Where(c => c.Model.Equals(valueAsString));
                }
                else if (type == "Contains")
                {
                    query = query.Where(c => c.Model.Contains(valueAsString));
                }
            }
            else if (propertyName == "Price")
            {
                var price = decimal.Parse(valueAsString);
                if (type == "Equals")
                {
                    query = query.Where(c => c.Price == price);
                }
                else if (type == "GreaterThan")
                {
                    query = query.Where(c => c.Price > price);
                }
                else if (type == "LessThan")
                {
                    query = query.Where(c => c.Price < price);
                }
            }
            else if (propertyName == "Manufacturer")
            {
                if (type == "Equals")
                {
                    query = query.Where(c => c.Manufacturer.Name.Equals(valueAsString));
                }
                else if (type == "Contains")
                {
                    query = query.Where(c => c.Manufacturer.Name.Contains(valueAsString));
                }
            }
            else if (propertyName == "Dealer")
            {
                if (type == "Equals")
                {
                    query = query.Where(c => c.Dealer.Name.Equals(valueAsString));
                }
                else if (type == "Contains")
                {
                    query = query.Where(c => c.Dealer.Name.Contains(valueAsString));
                }
            }
            else if (propertyName == "City")
            {
                if (type == "Equals")
                {
                    query = query.Where(c => c.Dealer.Cities.Any(city => city.Name == valueAsString));
                }
            }

            return query;
        }

        private IQueryable<Car> OrderBy(IQueryable<Car> query, string orderBy)
        {
            if (orderBy == "Id")
            {
                query = query.OrderBy(c => c.Id);
            }
            else if (orderBy == "Year")
            {
                query = query.OrderBy(c => c.Year);
            }
            else if (orderBy == "Model")
            {
                query = query.OrderBy(c => c.Model);
            }
            else if (orderBy == "Price")
            {
                query = query.OrderBy(c => c.Price);
            }
            else if (orderBy == "Manufacturer")
            {
                query = query.OrderBy(c => c.Manufacturer.Name);
            }
            else if (orderBy == "Dealer")
            {
                query = query.OrderBy(c => c.Dealer.Name);
            }

            return query;
        }
    }
}