namespace Movies.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class LeadingFemaleRole
    {
        private ICollection<Movie> movies;

        public LeadingFemaleRole()
        {
            this.movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(10, 100)]
        public int Age { get; set; }

        [Required]
        public string Studio { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }
    }
}
