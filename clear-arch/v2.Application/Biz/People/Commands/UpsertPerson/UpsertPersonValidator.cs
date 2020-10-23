using FluentValidation;

namespace Core.Application.Biz.People.Commands.UpsertPerson
{
    public class UpsertPersonValidator : AbstractValidator<UpsertPersonCommand>
    {
        public UpsertPersonValidator()
        {
            RuleFor(i => i.FirstName).NotEmpty();
            RuleFor(i => i.LastName).NotEmpty();
        }
    }
}