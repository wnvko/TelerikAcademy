namespace MusicLibrary.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using MusicLibrary.Models;

    public class ProducerModel
    {
        public static Expression<Func<Producer, ProducerModel>> FromProducer
        {
            get
            {
                return p => new ProducerModel
                {
                    Id = p.Id,
                    Name = p.Name,
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}