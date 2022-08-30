using Lexicon_MVC.Models;
using Lexicon_MVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Lexicon_MVC.Data
{
    public class ApplicationDbContext : DbContext // Database connection to manage EF. Inherit from DbContext that will handle queries.
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Person> People { get; set; } // Use DbSet to create table named People based on class Person
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, Name = "Marko Kivi", City = "Gothenburg", PhoneNumber = "031 123 345" });
            //modelBuilder.Entity<Person>().HasData(new Person { PersonId = 2, Name = "Emil Kivi", City = "Gothenburg", PhoneNumber = "031 222 333" });
            //modelBuilder.Entity<Person>().HasData(new Person { PersonId = 3, Name = "Johnny Brott", City = "Stockholm", PhoneNumber = "08 666 777" });
            //modelBuilder.Entity<Person>().HasData(new Person { PersonId = 4, Name = "Håkan Bråkan", City = "Helsingborg", PhoneNumber = "040 111 555" });

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, CountryName = "Sweden" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, CountryName = "Norway" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, CountryName = "Finland" });

            modelBuilder.Entity<City>().HasData(new City { CityId = 1, CityName = "Gothenburg", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 2, CityName = "Oslo", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 3, CityName = "Helsinki", CountryId = 3 });

            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, Name = "Marko Kivi", CityId = 1 , PhoneNumber = "031 123 345" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 2, Name = "Emil Kivi", CityId = 2, PhoneNumber = "031 222 333" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 3, Name = "Johnny Brott", CityId = 1, PhoneNumber = "08 666 777" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 4, Name = "Håkan Bråkan", CityId = 3, PhoneNumber = "040 111 555" });
        }
    }
}
