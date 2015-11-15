namespace MusicLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Artist
    {
        private ICollection<Song> songs;

        public Artist()
        {
            this.songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }
    }
}
