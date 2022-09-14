using Lexicon_MVC.Models;
using Lexicon_MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lexicon_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // Updated to inherit from IdentityDbContext. Needed for Identity
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        // Use DbSet to create table based on class
        public DbSet<Person> People { get; set; } 
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }


        // Use OnModelCreating to Seed data to database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, CountryName = "Sweden" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, CountryName = "Norway" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, CountryName = "Finland" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 4, CountryName = "Denmark" });

            modelBuilder.Entity<City>().HasData(new City { CityId = 1, CityName = "Gothenburg", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 2, CityName = "Oslo", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 3, CityName = "Helsinki", CountryId = 3 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 4, CityName = "Copenhagen", CountryId = 4 });

            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, Name = "Marko Kivi", CityId = 1 , PhoneNumber = "031 123 345" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 2, Name = "Emil Kivi", CityId = 2, PhoneNumber = "031 222 333" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 3, Name = "Johnny Brott", CityId = 1, PhoneNumber = "08 666 777" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 4, Name = "Håkan Bråkan", CityId = 3, PhoneNumber = "040 111 555" });

            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 1, LanguageName = "Swedish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 2, LanguageName = "Norwegian" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 3, LanguageName = "Finnish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 4, LanguageName = "Danish" });

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(c => c.People)
                .UsingEntity(j => j.HasData(new { PeoplePersonId = 2, LanguagesLanguageId = 3 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(c => c.People)
                .UsingEntity(j => j.HasData(new { PeoplePersonId = 2, LanguagesLanguageId = 1 }));

            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"
            });

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
            
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                FirstName = "Admin",
                LastName = "Jedi",
                BirthDate = DateTime.Now,
                PasswordHash = hasher.HashPassword(null, "password")
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = userId,
            });

        }
    }
}
