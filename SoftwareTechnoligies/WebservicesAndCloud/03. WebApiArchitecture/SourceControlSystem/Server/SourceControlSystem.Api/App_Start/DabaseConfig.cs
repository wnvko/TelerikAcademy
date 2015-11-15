namespace SourceControlSystem.Api
{
    using System.Data.Entity;
    using SourceControlSystem.Data;
    using SourceControlSystem.Data.Migrations;

    public static class DabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SourceControlSystemDbContext, Configuration>());
            SourceControlSystemDbContext.Create().Database.Initialize(true);
        }
    }
}