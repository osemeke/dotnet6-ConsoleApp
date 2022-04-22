using CoreConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreConsoleApp.Data
{
    public class SQLiteDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=appdb\\myapp.db");

        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<TreatedItem> TreatedItems => Set<TreatedItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData(new Job
            {
                Id = 1,
                Name = "sl 2022 photo album",
                Status = "pending",
            });
        }
    }
}
//add-migration time -context SQLiteDbContext 
//update-database time -context SQLiteDbContext 