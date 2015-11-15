namespace Forum.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    //You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User
    {
        private ICollection<Thread> threads;
        private ICollection<Post> posts;
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public User()
        {
            this.threads = new HashSet<Thread>();
            this.posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string NickName { get; set; }

        public string AuthCode { get; set; }

        public string SessionKey { get; set; }

        public virtual ICollection<Thread> Threads
        {
            get { return this.threads; }
            set { this.threads = value; }
        }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
