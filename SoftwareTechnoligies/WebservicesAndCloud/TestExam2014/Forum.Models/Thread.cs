namespace Forum.Models
{
    using System;
    using System.Collections.Generic;

    public class Thread
    {
        private ICollection<Category> categories;
        private ICollection<Post> posts;

        public Thread()
        {
            this.categories = new HashSet<Category>();
            this.posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public virtual User  User { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
