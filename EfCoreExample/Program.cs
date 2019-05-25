using EfCoreExample.Domain;
using EfCoreExample.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EfCoreExample
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonDbContext context = new PersonDbContext();
            //var address = new Address("Tbilisi", "wulukidze", "123");
            //var person = new Person("luka", "ogadze", address);            


            //context.People.Add(person);

            var luka = context.People.Where(x => EF.Property<string>(x, "City") == "Tbilisi").First();

            luka.Update(new Address("Batumi", "12", "000"));

            context.SaveChanges();
        }
    }
}
