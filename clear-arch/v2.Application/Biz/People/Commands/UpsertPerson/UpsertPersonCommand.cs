using MediatR;
using System;

namespace Core.Application.Biz.People.Commands.UpsertPerson
{
    public class UpsertPersonCommand : IRequest<Guid>
    {
        public Guid? PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NameSuffix { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public HomeAddress HomeAddress { get; set; }
    }
}