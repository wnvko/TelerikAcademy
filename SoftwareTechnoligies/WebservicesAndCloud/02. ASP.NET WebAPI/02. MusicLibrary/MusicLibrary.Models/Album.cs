namespace MusicLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Album
    {
        private ICollection<Song> songs;
        private ICollection<Artist> artists;

        public Album()
        {
            this.songs = new HashSet<Song>();
            this.artists = new HashSet<Artist>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Year { get; set; }

        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        [NotMapped]
        public ICollection<Artist> Artists
        {
            get
            {
                foreach (Song song in this.songs)
                {
                    foreach (Artist artist in song.Artists)
                    {
                        this.artists.Add(artist);
                    }
                }

                return this.artists;
            }
        }
    }
}
