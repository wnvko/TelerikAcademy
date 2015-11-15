namespace MusicLibrary.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using MusicLibrary.Models;

    public class AlbumModel
    {
        public static Expression<Func<Album, AlbumModel>> FromAlbum
        {
            get
            {
                return a => new AlbumModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Year = a.Year,
                    ProducerId = a.ProducerId,
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Year { get; set; }

        public int ProducerId { get; set; }
    }
}