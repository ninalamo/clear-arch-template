using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly ApplicationDbContext _context;

        public CommandTestBase()
        {
            _context = ApplicationDbContextFactory.Create();
        }

        public void Dispose()
        {
            ApplicationDbContextFactory.Destroy(_context);
        }
    }
}
