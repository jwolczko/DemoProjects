using FluentValidation;
using Tracker.Domain.ValueObjects;

namespace Tracker.Service.Validators;

public class NewTruckValidator : AbstractValidator<NewTruck>
{
    public NewTruckValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required.");
    }
}
