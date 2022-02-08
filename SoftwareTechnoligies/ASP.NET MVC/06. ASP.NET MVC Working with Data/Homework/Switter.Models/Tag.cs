namespace Switter.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }

        public int SwittId { get; set; }

        [ForeignKey("SwittId")]
        public virtual Switt Switt { get; set; }
    }
}