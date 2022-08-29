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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, Name = "Marko Kivi", City = "Gothenburg", PhoneNumber = "031 123 345" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 2, Name = "Emil Kivi", City = "Gothenburg", PhoneNumber = "031 222 333" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 3, Name = "Johnny Brott", City = "Stockholm", PhoneNumber = "08 666 777" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 4, Name = "Håkan Bråkan", City = "Helsingborg", PhoneNumber = "040 111 555" });
        }
    }
}
