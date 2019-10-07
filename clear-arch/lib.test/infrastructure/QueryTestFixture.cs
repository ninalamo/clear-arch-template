using AutoMapper;
using persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace lib.test.infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public ApplicationDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }
        public static long Seed_ID => 9999;



        public QueryTestFixture()
        {
            Context = ApplicationDbContextFactory.Create();
            Mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            ApplicationDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
