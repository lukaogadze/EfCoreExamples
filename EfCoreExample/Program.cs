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

            var luka = context.People.Where(x => x. == "Batumi").First();
        }
    }
}
