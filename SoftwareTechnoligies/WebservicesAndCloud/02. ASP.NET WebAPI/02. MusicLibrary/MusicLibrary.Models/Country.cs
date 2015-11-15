namespace MusicLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        private ICollection<Artist> artists;

        public Country()
        {
            this.artists = new HashSet<Artist>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public virtual ICollection<Artist> Artist
        {
            get { return this.artists; }
            set { this.artists = value; }
        }
    }
}
