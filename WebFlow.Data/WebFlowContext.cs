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

            //modelBuilder.Entity<DirectoryData>()
            //    .HasMany<DirectoryData>(d => d.SubDirs)
            //    .WithRequired()
            //    .WillCascadeOnDelete();

            //modelBuilder.Entity<DirectoryData>()
            //    .HasKey(d => d.DirectoryId)
            //    .HasMany(d => d.SubDirs)
            //    .WithOptional(pd => pd.ParentDirectory)
            //    .HasForeignKey(sd => sd.ParentDirId)
            //    .WillCascadeOnDelete(false);
            //.HasMany(d => d.SubDirs)

            //.WithRequired(sd => sd.ParentDirectory)
            //.HasForeignKey(sd => sd.DirectoryId)
            //.WillCascadeOnDelete();
            //.HasMany(d => d.SubDirs)
            //.WithRequired(sd => sd.ParentDirectory)
            //.HasForeignKey(sd => sd.ParentDirId)
            //.WillCascadeOnDelete(false);


            //modelBuilder.Entity<DirectoryData>()
            //    .HasMany(d => d.SubDirs)
            //    .WithRequired(sd => sd.ParentDirectory)
            //    .WillCascadeOnDelete();
            //modelBuilder.Entity<DirectoryData>()
            //    .HasMany<DirectoryData>(d => d.SubDirs)
            //    .WithRequired().HasForeignKey(d => d.ParentDirId)
            //    .WillCascadeOnDelete();
            //.HasForeignKey(d => d.DirectoryId)
            //.WillCascadeOnDelete();
        }
    }
}
