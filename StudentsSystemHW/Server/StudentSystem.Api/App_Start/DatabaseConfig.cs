namespace StudentSystem.Api
{
    using System.Data.Entity;
    using StudentSystem.Data;
    using StudentSystem.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
            StudentSystemDbContext.Create().Database.Initialize(true);
        }
    }
}