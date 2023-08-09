using Contacts.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Data
{
    //Tworzymy kontekst bazy danych, który dziedziczy po kontekscie .net identity z guid.
    public class DataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        private readonly DbContextOptions<DataContext> options;

        //Konfigurujemy konstruktor datacontext
        public DataContext(DbContextOptions<DataContext> _options) : base(_options)
        {
            this.options = _options;
        }

        //Nasze modele(tabele)
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Subcategory> Subcategories => Set<Subcategory>();

        //Wywołujemy tę metodę gdy konfigurujemy kontekst bazy danych.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //pobieramy connection stringa z appsettingsów.
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
