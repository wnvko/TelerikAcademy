namespace Movies.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int LeadingMaleRoleId { get; set; }

        [ForeignKey("LeadingMaleRoleId")]
        public virtual LeadingMaleRole LeadingMaleRole { get; set; }

        [Required]
        public int LeadingFemaleRoleId { get; set; }

        [ForeignKey("LeadingFemaleRoleId")]
        public virtual LeadingFemaleRole LeadingFemaleRole { get; set; }
    }
}
