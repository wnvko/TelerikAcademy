namespace MusicLibrary.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using MusicLibrary.Models;

    public class SongModel
    {
        public static Expression<Func<Song, SongModel>> FromSong
        {
            get
            {
                return s => new SongModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Year = s.Year,
                    AlbumId = s.AlbumId,
                    GenreId = s.GenreId,
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Range(0, int.MaxValue)]
        public int Year { get; set; }

        public int AlbumId { get; set; }

        public int GenreId { get; set; }
    }
}