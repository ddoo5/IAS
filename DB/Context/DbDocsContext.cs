using System;
using System.Reflection.Metadata;
using System.Xml.Linq;
using IAS.Models;
using Microsoft.EntityFrameworkCore;

namespace IAS.DB.Context
{
	public class DbDocsContext : DbContext
	{
        public virtual DbSet<DocumentModel> Documents { get; set; }
        public virtual DbSet<WordsModel> Words { get; set; }
        public virtual DbSet<WordDocumentModel> WordDocuments { get; set; }


        public DbDocsContext(DbContextOptions options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=test.db;Cache=Shared");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentModel>();
            modelBuilder.Entity<WordsModel>();
            modelBuilder.Entity<WordDocumentModel>();
        }
    }
}

