using CoreConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreConsoleApp.Data
{
    public class SQLServerDbContext : DbContext
    {
        //    public SQLServerDbContext(DbContextOptions<SQLServerDbContext> options)
        //:       base(options)
        //    {

        //    }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("server=.;database=GITHUB;trusted_connection=true;");

        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<TreatedItem> TreatedItems => Set<TreatedItem>();

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    var connectionString = configuration.GetConnectionString("AppDb");
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

    }
}
//Install-Package Microsoft.EntityFrameworkCore -Version 6.0.4
//Install-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.4
//Install-Package Microsoft.EntityFrameworkCore.Design -Version 6.0.4
//Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.4
//Install-Package Microsoft.EntityFrameworkCore.Sqlite -Version 6.0.4
//Install-Package Microsoft.EntityFrameworkCore.InMemory -Version 6.0.4

//Install-Package Microsoft.Extensions.Configuration -Version 6.0.1