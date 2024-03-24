using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(e => e.name).NotNull()
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name should not exceed 100 characters.");

            RuleFor(e => e.description).NotNull().NotEmpty()
                .WithMessage("Description is required.")
                .MaximumLength(4000).WithMessage("Description should not exceed 4000 characters.");

            RuleFor(e => e.plan).NotNull().NotEmpty()
                .WithMessage("Plan is required.")
                .MaximumLength(2000).WithMessage("Plan should not exceed 2000 characters.");

            RuleFor(e => e.spicker).NotNull().NotEmpty()
                .WithMessage("Speaker is required.");

            RuleFor(e => e.organizer).NotNull().NotEmpty()
                .WithMessage("Speaker is required.");

            RuleFor(e => e.time).NotNull().NotEmpty()
                .WithMessage("Time is required.")
                .GreaterThan(DateTime.Now).WithMessage("Time should be in the future.");

            RuleFor(e => e.address).NotEmpty()
                .NotNull().WithMessage("Address is required.");

            RuleFor(e => e.category).NotNull().NotEmpty()
                .MaximumLength(20).Must(e => e.All(Char.IsLetter))
                .WithMessage("Category is required.");

            RuleFor(e => e.maxParticipants).NotNull().NotEmpty()
                .WithMessage("Max participants is required.")
                .GreaterThan(0).WithMessage("Max participants should be greater than zero.");

            RuleFor(e => e.freePlaces).NotNull().NotEmpty()
                .WithMessage("Max participants is required.")
                .GreaterThan(0).LessThanOrEqualTo(e => e.maxParticipants)
                .WithMessage("Max participants should be greater than zero and less than max.");
        }
    }
}
