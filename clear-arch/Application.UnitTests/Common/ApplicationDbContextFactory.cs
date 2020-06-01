using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTests.Common
{
    public class ApplicationDbContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);

            context.Database.EnsureCreated();

            context.People.AddRange(new[] {
                new Person{ FirstName = "John", LastName = "Doe", Birthday = DateTimeOffset.Now.AddYears(-54) },
                new Person{ FirstName = "Linda", LastName = "Doe", Birthday = DateTimeOffset.Now.AddYears(-44) },
                new Person{ FirstName = "Indian", LastName = "Doe", Birthday = DateTimeOffset.Now.AddYears(-4) },
            });

            

            context.SaveChanges();

            return context;
        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
