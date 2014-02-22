namespace Students
{
    using System;

    public struct Address : ICloneable
    {
        private string city;
        private string street;
        private int number;

        public Address(string city, string street, int number)
            : this()
        {
            this.City = city;
            this.Street = street;
            this.Number = number;
        }

        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("City name cannot be null or empty.");
                }

                this.city = value;
            }
        }

        public string Street
        {
            get
            {
                return this.street;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Street name cannot be null or empty.");
                }

                this.street = value;
            }
        }

        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Street number cannot be < 1");
                }

                this.number = value;
            }
        }

        public object Clone()
        {
            Address clonedAddress = new Address();
            clonedAddress.City = String.Copy(this.City);
            clonedAddress.Street = String.Copy(this.Street);
            clonedAddress.Number = this.Number;
            return clonedAddress;
        }
    }
}
