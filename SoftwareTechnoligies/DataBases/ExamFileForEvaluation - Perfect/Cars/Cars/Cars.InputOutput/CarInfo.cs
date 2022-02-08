namespace Cars.Importer
{
    internal class CarInfo
    {
        public int Year { get; set; }

        public int TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public DealerInfo Dealer { get; set; }
    }
}