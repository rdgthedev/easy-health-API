using EasyHealth.Domain.Entities;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public sealed class RoleValidator : AbstractValidator<Role>
{
    public RoleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O campo nome não pode ser vázio!");
    }
}