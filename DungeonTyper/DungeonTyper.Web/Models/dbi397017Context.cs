using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
namespace DungeonTyper.Web.Models
{
    public partial class dbi397017Context : DbContext
    {
        public dbi397017Context()
        {
        }

        public dbi397017Context(DbContextOptions<dbi397017Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<CharacterClass> CharacterClass { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
                //See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=mssql.fhict.local;Database=dbi397017;User Id=dbi397017;Password=i397017;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(e => e.CharacterId)
                    .HasColumnName("CharacterID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CharacterClassId).HasColumnName("CharacterClassID");
            });

            modelBuilder.Entity<CharacterClass>(entity =>
            {
                entity.Property(e => e.CharacterClassId)
                    .HasColumnName("CharacterClassID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);
            });
        }
    }
}
