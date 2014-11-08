using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFlow.Model;

namespace WebFlow.Data
{
    public class WebFlowContext : DbContext
    {
        public WebFlowContext() : base(nameOrConnectionString: "WebFlowData")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<FileData> FileData { get; set; }
        public DbSet<DirectoryData> DirectoryData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<FileData>()
                .HasRequired(f => f.DirectoryData)
                .WithMany(d => d.Files)
                .HasForeignKey(f => f.DirectoryId);

            modelBuilder.Entity<DirectoryData>()
                .HasMany<FileData>(d => d.Files)
                .WithRequired()
                .WillCascadeOnDelete();
        }
    }
}
