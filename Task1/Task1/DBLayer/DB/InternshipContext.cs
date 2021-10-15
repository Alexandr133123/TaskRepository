using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.IO;
using Microsoft.Extensions.Configuration;
using Task1.DBLayer.Model;


namespace Task1.DBLayer.DB
{
    public partial class InternshipContext : DbContext
    {
        public InternshipContext()
        {
        }

        public InternshipContext(DbContextOptions<InternshipContext> options)
            : base(options)
        {
        }

        public  DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            if (!optionsBuilder.IsConfigured)
            {

                var builder = new ConfigurationBuilder();

                builder.SetBasePath(Directory.GetCurrentDirectory());

                builder.AddJsonFile("appsettings.json");

                var config = builder.Build();

                string connectionString = config.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PkPersonId)
                    .HasName("PK__Person__1EA68AAD453CD310");

                entity.ToTable("Person");

                entity.Property(e => e.PkPersonId).HasColumnName("PK_PersonId");

                entity.Property(e => e.FkParentPersonId).HasColumnName("FK_ParentPersonId");

                entity.Property(e => e.PersonName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.FkParentPerson)
                    .WithMany(p => p.InverseFkParentPerson)
                    .HasForeignKey(d => d.FkParentPersonId)
                    .HasConstraintName("FK__Person__FK_Paren__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
