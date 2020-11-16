using AutoMapper;
using Core.Application.Biz.People.Commands.UpsertPerson;
using Core.Domain.Entities;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }


        [Fact]
        public void ShouldMapEmployeeToEmployeeLookupDto()
        {
            var entity = new Person();

            var result = _mapper.Map<UpsertPersonCommand>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<UpsertPersonCommand>();
        }


    }
}
