using Microsoft.EntityFrameworkCore;
using Progress.Models;

namespace Progress.Services.Database
{
    public class DBContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }

        public DBContext()
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseNpgsql(Environment.GetEnvironmentVariable("DB_CONN"));
        }
    }
}