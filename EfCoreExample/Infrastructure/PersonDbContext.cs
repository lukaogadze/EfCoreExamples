using EfCoreExample.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace EfCoreExample.Infrastructure
{
    public class PersonDbContext : DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });
        public PersonDbContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Person> People { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer( @"Server=localhost;Database=People;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person", "Core");
            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<Person>().Property(x => x.Id).HasColumnName("Id").ValueGeneratedNever();

            modelBuilder.Entity<Person>().Property(x => x.FirstName).HasColumnName("FirstName");
            modelBuilder.Entity<Person>().Property(x => x.LastName).HasColumnName("LastName");

            modelBuilder.Entity<Person>().Property<string>("_city").HasColumnName("City");
            modelBuilder.Entity<Person>().Property<string>("_street").HasColumnName("Street");
            modelBuilder.Entity<Person>().Property<string>("_apartamentNumber").HasColumnName("ApartamentNumber");

            modelBuilder.Entity<Person>().Ignore(x => x.Address);

        }
    }
}
