using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Context
{
    public class IPInitializer<TContext, TMigrationsConfiguration> : IDatabaseInitializer<TContext>
       where TContext : DbContext
       where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private readonly DbMigrationsConfiguration config;

        /// <summary>
        ///     Initializes a new instance of the MigrateDatabaseToLatestVersion class.
        /// </summary>
        public IPInitializer()
        {
            config = new TMigrationsConfiguration();
        }

        /// <summary>
        ///     Initializes a new instance of the MigrateDatabaseToLatestVersion class that will
        ///     use a specific connection string from the configuration file to connect to
        ///     the database to perform the migration.
        /// </summary>
        /// <param name="connectionString"> connection string to use for migration. </param>
        public IPInitializer(string connectionString)
        {
            config = new TMigrationsConfiguration { TargetDatabase = new DbConnectionInfo(connectionString, "System.Data.SqlClient") };
        }
        public void InitializeDatabase(TContext context)
        {
            if (context == null)
                throw new ArgumentException("Context passed to InitializeDatabase can not be null");
            var migrator = new DbMigrator(config);
            migrator.Update();
        }
    }

    public static class DatabaseHelper
    {
        /// <summary>
        /// This method will create data base for given parameters supplied by caller.
        /// </summary>
        /// <param name="serverName">Name of the server where database has to be created</param>
        /// <param name="databaseName">Name of database</param>
        /// <param name="userName">SQL user name</param>
        /// <param name="password">SQL password</param>
        /// <returns>void</returns>
        public static bool CreateDb(string serverName, string databaseName, string userName, string password)
        {
            bool integratedSecurity = !(!string.IsNullOrEmpty(userName) || !string.IsNullOrEmpty(password));
            var builder = new System.Data.SqlClient.SqlConnectionStringBuilder
            {
                DataSource = serverName,
                UserID = userName,
                Password = password,
                InitialCatalog = databaseName,
                IntegratedSecurity = integratedSecurity,
            };
            var db = new IdentityProfileAppContext();
            var dbInitializer = new IPInitializer<IdentityProfileAppContext, Configuration>(builder.ConnectionString);
            dbInitializer.InitializeDatabase(db);
            return true;
        }
    }
}
