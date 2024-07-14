using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public sealed class SpecialtyValidator : AbstractValidator<Specialty>
{
    public SpecialtyValidator()
    {
        RuleFor(x => x.Title).SetValidator(new TitleValidator());
    }
}