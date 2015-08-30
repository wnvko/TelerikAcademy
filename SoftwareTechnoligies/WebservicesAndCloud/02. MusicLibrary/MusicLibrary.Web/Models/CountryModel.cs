namespace MusicLibrary.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using MusicLibrary.Models;

    public class CountryModel
    {
        public static Expression<Func<Country, CountryModel>> FromCountry
        {
            get
            {
                return c => new CountryModel
                {
                    Id = c.Id,
                    Name = c.Name,
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}