using Microsoft.EntityFrameworkCore;
using Progress.Models;

namespace Progress.Services.Database
{
    public class DBContext : DbContext
    {
        public DbSet<Patient> Patients{get;set;}
        public DbSet<Visit> Visits{get;set;}
        protected DBContext()
        {
            Database.EnsureCreated();
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseOracle(Environment.GetEnvironmentVariable("DB_CONN"));
        }
    }
}