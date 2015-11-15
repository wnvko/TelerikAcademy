namespace MusicLibrary.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using MusicLibrary.Models;

    public class ArtistModel
    {
        public static Expression<Func<Artist, ArtistModel>> FromArtist
        {
            get
            {
                return a => new ArtistModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth,
                    CountryId = a.CountryId,
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int CountryId { get; set; }
    }
}