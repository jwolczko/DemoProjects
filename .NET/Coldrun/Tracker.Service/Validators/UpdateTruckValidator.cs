using FluentValidation;
using Tracker.Domain.ValueObjects;

namespace Tracker.Service.Validators;

public class UpdateTruckValidator : AbstractValidator<UpdateTruck>
{
    public UpdateTruckValidator()
    {
        When(x => x.Status.HasValue, () =>
        {
            RuleFor(x => x.ReasonOfUpdateStatus)
                .NotEmpty().WithMessage("ReasonOfUpdateStatus is required when Status is not null.")
                .When(x => x.Status.HasValue);
        });
    }
}