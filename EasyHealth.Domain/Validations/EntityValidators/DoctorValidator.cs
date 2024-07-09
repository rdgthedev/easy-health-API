using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public sealed class DoctorValidator : AbstractValidator<Doctor>
{
    public DoctorValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O campo nome não pode ser inválido!")
            .Length(3, 60).WithMessage("O campo nome deve ter no mínimo 6 e no máximo 60 caracteres!");
        RuleFor(x => x.Gender).Must(GenderValidation);
        RuleFor(x => x.BirthDate).Must(MinimumAgeVaidation);
        RuleFor(x => x.Email).SetValidator(new EmailValidator());
        RuleFor(x => x.Address).SetValidator(new AddressValidator());
        RuleFor(x => x.Crm).SetValidator(new CrmValidator());
        RuleFor(x => x.Role).SetValidator(new RoleValidator());
        RuleForEach(x => x.Specialties)
            .NotEmpty().WithMessage("O médico deve ter no mínimo uma especialidade!")
            .SetValidator(new SpecialtyValidator());
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