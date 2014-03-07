namespace FurnitureManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using FurnitureManufacturer.Interfaces;

    public class Company : ICompany
    {
        private const string TenDigitsMatcher = @"(?<!\d)\d{10}(?!\d)";

        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "Name cannot be null or empty string.");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("Name cannot be shorter than five leters.");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                if (value.Length != 10 || !Regex.Match(value, TenDigitsMatcher).Success)
                {
                    throw new ArgumentException("Registration number must be in format ### ### #### where # is only digit");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (this.Furnitures.Contains(furniture))
            {
                this.Furnitures.Remove(furniture);
            }
        }

        public IFurniture Find(string model)
        {
            foreach (var furniture in this.Furnitures)
            {
                if (furniture.Model.ToLower() == model.ToLower())
                {
                    return furniture;
                }
            }

            return null;
        }

        public string Catalog()
        {
            StringBuilder catalogOutput = new StringBuilder();
            catalogOutput.AppendFormat("{0} - {1} - {2} {3}",
                                        this.Name,
                                        this.RegistrationNumber,
                                        this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                                        this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            if (this.Furnitures.Count>0)
            {
                catalogOutput.AppendLine();
                var catalogForOutput = this.Furnitures.OrderBy(p => p.Price).ThenBy(m => m.Model);

                foreach (var furniture in catalogForOutput)
                {
                    catalogOutput.AppendLine(furniture.ToString());
                }
            }

            return catalogOutput.ToString().Trim();
        }
    }
}
