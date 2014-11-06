using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMyCode.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using CheckMyCode.Data.Migrations;

namespace CheckMyCode.Data
{
    public class CheckMyCodeDbContext : IdentityDbContext<User>
    {
        public CheckMyCodeDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CheckMyCodeDbContext, Configuration>());
        }

        public static CheckMyCodeDbContext Create()
        {
            return new CheckMyCodeDbContext();
        }
        //TODO: Add IdbSets
        //public IDbSet<Article> Articles { get; set; }
    }
}