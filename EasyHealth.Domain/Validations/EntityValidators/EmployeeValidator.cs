using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(x => x.Name).SetValidator(new NameValidator());
        RuleFor(x => x.Sector)
            .NotEmpty().WithMessage("O campo setor não pode ser vázio!");
        RuleFor(x => x.Gender).Must(GenderValidation);
        RuleFor(x => x.BirthDate).Must(MinimumAgeVaidation);
        RuleFor(x => x.Email).SetValidator(new EmailValidator());
        RuleFor(x => x.Address).SetValidator(new AddressValidator());
        RuleFor(x => x.Document).SetValidator(new DocumentValidator());
        RuleForEach(x => x.Roles)
            .NotEmpty().WithMessage("O funcionário deve ter um perfil!")
            .SetValidator(new RoleValidator());
    }

    private static bool GenderValidation(EGender gender)
    {
        return gender switch
        {
            EGender.Male => true,
            EGender.Female => true,
            _ => false
        };
    }

    private static bool MinimumAgeVaidation(DateTime birthDate)
        => birthDate <= DateTime.UtcNow.AddDays(-18);
}