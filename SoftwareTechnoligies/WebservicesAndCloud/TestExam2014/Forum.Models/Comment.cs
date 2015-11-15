namespace Forum.Models
{
    using System;
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
