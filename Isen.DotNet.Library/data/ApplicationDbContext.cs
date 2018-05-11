using Isen.DotNet.Library.Models.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Isen.DotNet.Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        // 1 - Préciser les DbSet
        public DbSet<City> CityCollection { get;set; }
        public DbSet<Person> PersonCollection { get;set; }
        public DbSet<PointOfInterest> PointOfInterestCollection { get; set; }
        public DbSet<CategoriePoint> CategoriePointCollection { get; set; }
        public DbSet<Adresse> AdresseCollection { get; set; }
        public DbSet<Commune> CommuneCollection { get; set; }
        public DbSet<Departement> DepartementCollection { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(
            ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // 2 - Configurer les mappings tables / classes
            builder.Entity<City>()
                .ToTable("City")
                .HasMany(c => c.PersonCollection)
                .WithOne(p => p.City)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Person>()
                .ToTable("Person")
                .HasOne(p => p.City)
                .WithMany(c => c.PersonCollection)
                .HasForeignKey(p => p.CityId);

            builder.Entity<Departement>()
                .ToTable("Departement")
                .HasMany(c => c.CommuneCollection)
                .WithOne(p => p.Departement);

            builder.Entity<Commune>()
                .ToTable("Commune")
                .HasOne(p => p.Departement)
                .WithMany(c => c.CommuneCollection)
                .HasForeignKey(p => p.DepartementId);

            builder.Entity<Commune>()
                .ToTable("Commune")
                .HasMany(c => c.AddresseCollection)
                .WithOne(p => p.Commune);

            builder.Entity<CategoriePoint>()
                .ToTable("CategoriePoint")
                .HasMany(c=>c.PointOfInterestCollection)
                .WithOne(p => p.Categorie)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<PointOfInterest>()
                .ToTable("PointOfInterest")
                .HasOne(p => p.Categorie)
                .WithMany(c => c.PointOfInterestCollection)
                .HasForeignKey(p => p.CategorieId);
            
            builder.Entity<Adresse>()
                .ToTable("Adresse")
                .HasOne(p => p.PointOfInterest)
                .WithOne(c=>c.Adresse);
            
            builder.Entity<PointOfInterest>()
                .ToTable("PointOfInterest")
                .HasOne(p => p.Adresse)
                .WithOne(p=>p.PointOfInterest);

            builder.Entity<Adresse>()
                .ToTable("Adresse")
                .HasOne(p => p.Commune)
                .WithMany(c => c.AddresseCollection)
                .HasForeignKey(p => p.CommuneId);
        }
    }
}