using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(c => c.firstName).NotNull().NotEmpty()
                .Must(c => c.All(Char.IsLetter)).MaximumLength(20)
                .WithMessage("Person name error");
            RuleFor(c => c.lastName).NotNull().NotEmpty()
                .Must(c => c.All(Char.IsLetter)).MaximumLength(20)
                .WithMessage("Person name error");
        }
    }
}
