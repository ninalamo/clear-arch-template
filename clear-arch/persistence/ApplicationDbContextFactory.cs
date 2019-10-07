using Microsoft.EntityFrameworkCore;
using persistence.infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace persistence
{
    public class ApplicationDbContextFactory : DesignTimeDbContextFactoryBase<ApplicationDbContext>
    {
        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }
    }
}
