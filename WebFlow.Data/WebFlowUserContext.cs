using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFlow.Model;
using WebFlow.Model.Account;

namespace WebFlow.Data
{
    public class WebFlowUserContext : DbContext
    {
        public WebFlowUserContext()
            : base("WebFlowData")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
