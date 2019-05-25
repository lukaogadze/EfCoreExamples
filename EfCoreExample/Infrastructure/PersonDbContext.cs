using EfCoreExample.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
                .UseSqlServer( @"Server=(localdb)\mssqllocaldb;Database=People;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person", "Core");
            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<Person>().Property(x => x.Id).HasColumnName("Id").ValueGeneratedNever();

            modelBuilder.Entity<Person>().Property(x => x.FirstName).HasColumnName("FirstName");
            modelBuilder.Entity<Person>().Property(x => x.LastName).HasColumnName("LastName");
            modelBuilder.Entity<Person>().Property(x => x.Address).HasColumnName("Address")
                .HasConversion(
                    address => JsonConvert.SerializeObject(address),
                    address => JsonConvert.DeserializeObject<Address>(address)
                );

        }
    }
}
