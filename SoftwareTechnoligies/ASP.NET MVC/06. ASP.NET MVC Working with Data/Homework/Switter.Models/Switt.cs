namespace Switter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Switt
    {
        private ICollection<Tag> tags;

        public Switt()
        {
            this.tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        
        public string SwitterUserId { get; set; }

        [ForeignKey("SwitterUserId")]
        public virtual SwitterUser SwitterUser { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
