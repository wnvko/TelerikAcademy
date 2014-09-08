namespace Cars.Data
{
    using System.Data.Entity;

    using Cars.Models;

    public class CarsDbContext : DbContext
    {
        public CarsDbContext()
            : base("CarsConnection")
        { }

        public IDbSet<Car> Car { get; set; }

        public IDbSet<City> City { get; set; }

        public IDbSet<Dealer> Dealer { get; set; }

        public IDbSet<Manufacturer> Manufacturer { get; set; }
    }
}
