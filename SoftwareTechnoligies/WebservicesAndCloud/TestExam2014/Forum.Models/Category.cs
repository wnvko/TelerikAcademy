namespace Forum.Models
{
    using System.Collections.Generic;

    public class Category
    {
        private ICollection<Thread> threads;

        public Category()
        {
            this.threads = new HashSet<Thread>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Thread> Threads
        {
            get { return this.threads; }
            set { this.threads = value; }
        }
    }
}