namespace Forum.Models
{
    using System;
    using System.Collections.Generic;

    public class Post
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public Post()
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PostDate { get; set; }

        public virtual User User { get; set; }

        public int ThreadId { get; set; }

        public virtual Thread Thread { get; set; }

        public ICollection<Comment> Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public ICollection<Vote> Votes
        {
            get { return votes; }
            set { votes = value; }
        }
    }
}