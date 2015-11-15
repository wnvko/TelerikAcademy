namespace MusicLibrary.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    
    using MusicLibrary.Models;
    
    public class GenreModel
    {
        public static Expression<Func<Genre, GenreModel>> FromGenre
        {
            get
            {
                return g => new GenreModel
                {
                    Id = g.Id,
                    Name = g.Name,
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}