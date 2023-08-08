using Contacts.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Data
{
    public class DataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        private readonly DbContextOptions<DataContext> options;

        public DataContext(DbContextOptions<DataContext> _options) : base(_options)
        {
            this.options = _options;
        }

        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Subcategory> Subcategories => Set<Subcategory>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
