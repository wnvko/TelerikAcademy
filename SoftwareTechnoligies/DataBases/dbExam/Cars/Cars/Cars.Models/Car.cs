namespace Cars.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Model { get; set; }

        [Required]
        public Transmission TransmissionType { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public int DealerId { get; set; }

        [Required]
        public virtual Dealer Dealer { get; set; }

        public enum Transmission
        {
            Manual = 0,
            Automatic = 1,
        }
    }
}
