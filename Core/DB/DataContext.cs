/**
 * The Unit of Work Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Unit of Work Library
 * https://github.com/mail4hafij/dotnetcore-startup-with-efcore
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Core.DB.Builder;
using Core.DB.Model;

namespace Core.DB
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// The following constructor is used by the migration script.
        /// The Core project does not have appsettings or 
        /// local.settings file to read from.
        /// ---------------------------------------------
        /// How to generate migration script:
        /// 1. Go to package manager console 
        /// 2. Set the Core project as default
        /// 3. Run 'add-migration' and provide a version name
        /// 4. Run 'update-database'
        /// </summary>
        public DataContext()
        {

        }

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<long>("PrimaryKeyGenerator").StartsAt(1000).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new UserBuilder());
            modelBuilder.ApplyConfiguration(new CarBuilder());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString  = _configuration.GetConnectionString("dbConnectionString");
            if (connectionString == null)
            {
                // Used by the Migration script. The src project does not have appsettings or 
                // local.settings file to read from.
                connectionString = "Data Source=.;Initial Catalog=efcore;Integrated Security=true;";
            }

            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
