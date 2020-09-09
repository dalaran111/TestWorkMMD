using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestWorkMMD
{
    public partial class CountriesContext : DbContext
    {
        public CountriesContext()
        {
        }

        public CountriesContext(DbContextOptions<CountriesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citiess> Citiess { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dalar\\source\\repos\\TestWorkMMD\\TestWorkMMD\\CountryDB.mdf;Integrated Security=True; MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citiess>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.CountryCode).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Capital)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.CapitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Countries__Capit__160F4887");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Countries__Regio__17036CC0");
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
