using Microsoft.EntityFrameworkCore;
using TestWeb.Models;

namespace TestWeb.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Localization> Localizations { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<DiseaseBySymptom> DiseaseBySymptoms { get; set; }

    }
}
