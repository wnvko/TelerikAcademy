namespace DataLayer
{
    using DataLayer.Migrations;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BugLoggerContext : DbContext
    {
        public BugLoggerContext()
            : base("BugLoggerDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerContext, Configuration>());
        }

        public virtual IDbSet<Bug> Bugs { get; set; }
    }
}
