using Application.UnitTests.Common;
using Core.Application.Biz.People.Commands.UpsertPerson;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.People.Commands.UpsertPerson
{
    public class UpsertPersonTest : CommandTestBase
    {
        public UpsertPersonTest()
        {
        }

        [Fact]
        public async Task CanCreatePerson()
        {
            var mediator = new Mock<IMediator>();
            var query = new UpsertPersonCommand { FirstName = "Nin", LastName = "Alamo" };

            var result = await new UpsertPersonHandler(_context).Handle(query, CancellationToken.None);

            result.ShouldBeOfType(typeof(Guid));
        }
    }
}
