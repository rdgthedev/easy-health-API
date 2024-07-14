using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public sealed class RoleValidator : AbstractValidator<Role>
{
    public RoleValidator()
    {
        RuleFor(x => x.Title).SetValidator(new TitleValidator());
    }
}