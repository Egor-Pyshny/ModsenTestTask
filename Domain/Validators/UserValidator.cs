using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.firstName).NotNull().NotEmpty()
                .Must(e => e.All(Char.IsLetter))
                .WithMessage("First name is required.")
                .MaximumLength(20).WithMessage("First name should not exceed 20 characters.");

            RuleFor(user => user.password).NotNull().NotEmpty()
                .MinimumLength(8).WithMessage("Second name should be more than 8 characters.")
                .MaximumLength(30).WithMessage("Second name should not exceed 20 characters.");

            RuleFor(user => user.secondName).NotNull().NotEmpty()
                .Must(e => e.All(Char.IsLetter))
                .WithMessage("Second name is required.")
                .MaximumLength(20).WithMessage("Second name should not exceed 20 characters.");

            RuleFor(user => user.thirdName).NotNull().NotEmpty()
                .Must(e => e.All(Char.IsLetter))
                .WithMessage("Third name is required.")
                .MaximumLength(20).WithMessage("Third name should not exceed 20 characters.");

            RuleFor(user => user.email).NotNull()
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(100).WithMessage("Email should not exceed 100 characters.")
                .EmailAddress().WithMessage("Invalid email address.");
        }
    }
}
