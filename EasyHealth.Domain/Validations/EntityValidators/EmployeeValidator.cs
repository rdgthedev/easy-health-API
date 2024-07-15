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

        RuleFor(x => x.Gender)
            .Must(GenderValidation).WithMessage("Os gêneros precisam ser male e female!");

        RuleFor(x => x.BirthDate)
            .Must(MinimumAgeValidation).WithMessage("A idade deve ser pelo menos 18 anos!");

        RuleFor(x => x.Role)
            .NotNull().WithMessage("O funcionário deve ter um perfil!")
            .SetValidator(new RoleValidator());
        
        RuleFor(x => x.Email).SetValidator(new EmailValidator());
        RuleFor(x => x.Address).SetValidator(new AddressValidator());
        RuleFor(x => x.Document).SetValidator(new DocumentValidator());
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

    private static bool MinimumAgeValidation(DateTime birthDate)
        => birthDate <= DateTime.UtcNow.AddYears(-18);
}