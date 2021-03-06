﻿namespace ArtistsSystem.Api
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtistsSystemDbContext, Configuration>());
        }
    }
}