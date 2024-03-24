using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.country).NotNull().NotEmpty()
                .MaximumLength(20).Must(e => e.All(Char.IsLetter))
                .WithMessage("Country is required.");

            RuleFor(x => x.city).NotNull().NotEmpty()
                .MaximumLength(20).Must(e => e.All(Char.IsLetter))
                .WithMessage("City is required.");

            RuleFor(x => x.street).NotNull().NotEmpty()
                .MaximumLength(100).Must(e => e.All(Char.IsLetter))
                .WithMessage("Street is required.");
        }
    }
}
