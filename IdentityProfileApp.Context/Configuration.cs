using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Context
{
    internal sealed class Configuration : DbMigrationsConfiguration<IdentityProfileAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
    class version
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
